using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using FEI.PushdownAutomaton.Dialogs;
using FEI.PushdownAutomaton.IO.Jff;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Dialogs;
using FEI.SimStudio.Components.Registers;
using FEI.TuringCore.Components;
using FEI.TuringCore.Simulation;

namespace FEI.PushdownAutomaton {
	public partial class PushdownAutomatonForm : Form
	{
		ResourceManager resMan = new ResourceManager(typeof(PushdownAutomatonForm).FullName,
			 System.Reflection.Assembly.GetExecutingAssembly());

		private string sourceCodeText = null;

		public PushdownAutomatonForm()
		{ 
			InitializeComponent();

			AppTitle = this.Text;

			timMachine.SynchronizingObject = this;
			timMachine.Elapsed += new System.Timers.ElapsedEventHandler(timMachine_Elapsed);
			timMachine.AutoReset = false;
			timMachine.Enabled = false;            
		}


		string AppTitle;
		string openFileName = null;

		private PushdownAutomaton pushdownAutomaton = new PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };
		public PushdownAutomaton PushdownAutomaton
		{
			get { return pushdownAutomaton; }
			set
			{                
				pushdownAutomaton = value;
				stateDiagramControl.TuringMachine = pushdownAutomaton;
			}
		}

		bool CodeChanged = false;        

		//Formát prechodovej funkcie
		string TransitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
		//Formát 
		string WildCardFormat = "\\a=\\s{\\m,\\n}\\s";        

		//Zdržanie pri vykonávaní programu
		int delay = 10;

		//Vlákno stroja        
		System.Threading.Thread thRealTime;

		System.Timers.Timer timMachine = new System.Timers.Timer();
		bool pause = false;
		bool prgStop = true;
		bool prgReset = true; //Resetovať stroj pri najbližšom štarte

		AcceptanceStatus tapeAcceptance = AcceptanceStatus.None;                

		public bool PrgStop
		{
			get { return prgStop; }
			set
			{
				prgStop = value;
				if (prgStop)
				{
					UpdateTapeSettings();
				}
			}
		}        

		public bool PrgReset
		{
			get { return prgReset; }
			set
			{
				prgReset = value;
			}
		}

		private void frmTuringMachine_Load(object sender, System.EventArgs e)
		{
			if (MdiParent != null) menuStrip1.Visible = false;
			this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon"))); 

			stateDiagramControl.TuringMachine = PushdownAutomaton;
			
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("δ", Color.Blue, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("f", Color.Blue, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("(", Color.Black, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord(")", Color.Black, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord(",", Color.Black, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("=", Color.Black, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("L", Color.Blue, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("R", Color.Blue, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("0", Color.Blue, true));
			txtCode.SyntaxWords.Add(new  SyntaxTextBox.SyntaxWord("Blank", Color.Blue, true));
			txtCode.SyntaxWords.fStrings = new SyntaxTextBox.SyntaxFormat(Color.DarkRed, true);
			txtCode.SyntaxWords.fNumbers = new SyntaxTextBox.SyntaxFormat(Color.DarkBlue, true);
			txtCode.SyntaxWords.fComment = new SyntaxTextBox.SyntaxFormat(Color.DarkGreen);
			
			cmbTape.SelectedIndex = 0;            

			infiniteTapeControl.Tapes = PushdownAutomaton.OriginalTapes;

			AddSpeedPanel();
		}

		private void AddSpeedPanel()
		{
			ToolStripControlHost host = new ToolStripControlHost(speedPanel);
			host.Alignment = ToolStripItemAlignment.Right;
			host.Width = 200;
			host.AutoSize = false;
			mainToolStrip.Items.Add(host);
		}

		private void UpdateErrors(List<TMError> errors)
		{
			lstErrors.Items.Clear();
		   
			// Zobrazenie chýb
			if (errors.Count > 0)
			{                
				lstErrors.Items.AddRange(errors.ToArray());
				splitContainer2.Panel2Collapsed = false;
			}
		}        

		private void bNext_Click(object sender, System.EventArgs e)
		{
			if (PrgReset)
			{
				Reset();
				cmbTape.SelectedIndex = 1;
			}
			if (!stopToolStripButton.Enabled) stopToolStripButton.Enabled = true;

			NextStep();

			//Aktívny stav
			PushdownAutomaton.StateDiagram.activeState = PushdownAutomaton.CurrentState;
			PushdownAutomaton.StateDiagram.activeTransition = PushdownAutomaton.LastUsedTransition;

			//Prekreslenie stavového diagramu
			if (tcMain.SelectedTab == statesTab)
			{                
				stateDiagramControl.Refresh();
			}

			RefreshStack();
			
			//Obnovenie komboboxu s páskami
			RefreshTapeComboBox();

			//Neuchovávať pôvodnú pásku
			if (!PushdownAutomaton.StoreOriginalTape)
			{
				PushdownAutomaton.OriginalTapes = PushdownAutomaton.ActiveTapes;                
				//TM.StartPositions = TM.HeadPositions;
			}

			if (PushdownAutomaton.NoNextStep) stepToolStripButton.Enabled = false;

			UpdateTapeSettings();
		}

		private void txtCode_TextChanged(object sender, System.EventArgs e)
		{
			CodeChanged = true;
		}        

		//Spustí
		private void RunRealTime()
		{
			lock (PushdownAutomaton)
			{
				//Preklad prechodov
				if (ParseTFunctions(sourceCodeText) == false)
				{
					if (MessageBox.Show("Program obsahuje chyby. Chcete pokračovať?", "Chyba počas prekladu",
						MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;
				}

				while (!PushdownAutomaton.IsAccepted() && !PrgStop)
				{
					PushdownAutomaton.NextStep(true);
					if (PushdownAutomaton.NoNextStep) break;                    
				}

				//Program skončil v koncovom stave
				if (PushdownAutomaton.IsAccepted())
				{
					MessageBox.Show("Zásobníkový automat úspešne dokončil program. (Bol dosiahnutý koncový stav.)", "Zásobníkový automat", MessageBoxButtons.OK, MessageBoxIcon.Information);
					tapeAcceptance = AcceptanceStatus.Accept;
				}
				else //Program skončil v inom ako koncovom stave, neexistujú prechodové funkcie pre ďalší chod
				{
					MessageBox.Show("Zásobníkový automat sa nemôže dostať do koncového stav. Neexistujú prechodové funkcie na prechod do ďalšieho stavu.", "Zásobníkový automat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
					tapeAcceptance = AcceptanceStatus.Reject;
				}
				PrgReset = true;

				//Koniec programu turingovho stroja (program nie je zastavený umelo)
				if (!PrgStop)
				{
					StopMachine();
				}

				//Neuchovávať pôvodnú pásku
				if (!PushdownAutomaton.StoreOriginalTape)
				{
					PushdownAutomaton.OriginalTapes = PushdownAutomaton.ActiveTapes;
					//TM.StartPosition = TM.Position;

				}                

				UpdateGUI_AfterSimulationFinish();
			}
		}

		private bool ParseTFunctions(string sourceCodeText)
		{
			PushdownAutomatonParser parser = new PushdownAutomatonParser(PushdownAutomaton, TransitionFormat, WildCardFormat);
			bool retval = parser.ParseTFunctions(sourceCodeText);

			CodeChanged = false;
			UpdateErrors(parser.Errors);
			Functions_SetScrollbar();

			PushdownAutomaton.StateDiagram.UpdateForPA(PushdownAutomaton);

			return retval;
		}

		private void UpdateGUI_AfterSimulationFinish()
		{
			if (this.InvokeRequired)
			{
				this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { UpdateGUI_AfterSimulationFinish(); })));
			}
			else
			{
				UpdateScrollbars();
				UpdateTapeSettings();
				infiniteTapeControl.UpdateScrollbars();

				lblCurrentState.Text = PushdownAutomaton.ActiveThread.CurrentState;
				this.lblStepCount.Text = "Počet vlákien: " + PushdownAutomaton.ThreadCount.ToString() + ", Počet vykonaných funkcií: " + PushdownAutomaton.StepCount.ToString();
				runToolStripButton.Text = "Spustiť";
				stopToolStripButton.Enabled = false;
				stepToolStripButton.Enabled = true;
				this.Refresh();
			}
		}

		private void UpdateScrollbars()
		{
			int minX = int.MaxValue;
			int maxX = int.MinValue;

			for (int i = 0; i < PushdownAutomaton.ThreadCount; i++)
			{
				for (int j = 0; j < PushdownAutomaton.Thread(i).Tapes.Count; j++)
				{
					if (minX > PushdownAutomaton.Thread(i).Tapes[j].GetFirstNonBlankCell())
						minX = PushdownAutomaton.Thread(i).Tapes[j].GetFirstNonBlankCell();
					if (maxX < PushdownAutomaton.Thread(i).Tapes[j].GetLastNonBlankCell())
						maxX = PushdownAutomaton.Thread(i).Tapes[j].GetLastNonBlankCell();
				}
			}

			sbxThreads.LargeChange = (int)Math.Floor((double)pThreads.Width / 2);
			sbxThreads.Minimum = (minX - 20) * 40;
			sbxThreads.Maximum = (maxX + 20) * 40;
		}

		//Obnovenie komboboxu s páskami
		private void RefreshTapeComboBox()
		{
			if (PushdownAutomaton.ThreadCountChanged)
			{
				PushdownAutomaton.ThreadCountChanged = false;

				int lastSelected = cmbTape.SelectedIndex;
				cmbTape.Items.Clear();
				cmbTape.Items.Add("Pôvodná páska");
				cmbTape.Items.Add("Aktívna páska (Vlákno č." + (PushdownAutomaton.ActiveThreadIndex + 1).ToString() + ")");
				for (int a = 0; a < PushdownAutomaton.ThreadCount; a++)
				{
					cmbTape.Items.Add("Páska vlákna č." + (a + 1).ToString() + ")");
				}
				cmbTape.SelectedIndex = lastSelected;
			}
		}

		//Ďalší krok
		private void NextStep()
		{
			if (CodeChanged)
			{
				if (ParseTFunctions(txtCode.Text) == false)
				{
					if (MessageBox.Show("Program obsahuje chyby. Chcete pokračovať?", "Chyba počas prekladu",
						MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;
				}
			}
			if (prgReset)
				Reset();
			if (PushdownAutomaton.IsAccepted()) {
				TuringFinish();
				return;
			}

			PushdownAutomaton.NextStep(false);
			if (PushdownAutomaton.NoNextStep)
			{                
				StopMachine();                
				return;
			}
			UpdateUI();
			RefreshStack();
			RefreshTapeComboBox();
			lblStepCount.Text = "Počet vlákien: " + PushdownAutomaton.ThreadCount.ToString() + ", Počet vykonaných funkcií: " + PushdownAutomaton.StepCount.ToString();
			lblThreadCount.Text = PushdownAutomaton.ThreadCount.ToString();
		}

		private void UpdateUI() {
			//Obnovenie informácií                    
			infiniteTapeControl.UpdateScrollbars();
			infiniteTapeControl.AdjustTapeView(PushdownAutomaton.HeadPositions[0]);
			//infiniteTapeControl.HeadPositions = TM.HeadPositions;

			//Nastavnie posuvníkov
			SetThreadPanelScrollbars();

			pFunctions.Refresh();

			lblCurrentState.Text = PushdownAutomaton.RunningThread.CurrentState;
			lblThreadCount.Text = PushdownAutomaton.ThreadCount.ToString();
			lblCurrentState.Refresh();

			infiniteTapeControl.Refresh();
			pThreads.Refresh();

			//Skrolovanie logu
			if (tcMain.SelectedTab == logTab) {
				Log_SetScrollbars();
				sbyLog.Value = Math.Max(sbyLog.Maximum - sbyLog.LargeChange, 0);
				pLog.Refresh();
			}
			//Prekreslenie stavového diagramu
			if (tcMain.SelectedTab == statesTab) {
				//Aktívny stav
				PushdownAutomaton.StateDiagram.activeState = PushdownAutomaton.CurrentState;
				PushdownAutomaton.StateDiagram.activeTransition = PushdownAutomaton.LastUsedTransition;

				stateDiagramControl.Refresh();
			}
		}


		private void Run()
		{
			if ((pause || PrgStop) && !timMachine.Enabled) //(thMachine == null || thMachine.ThreadState != System.Threading.ThreadState.Running)
			{
				if (PrgReset) Reset();
				UpdateTapeSettings();

				//Preklad prechodov
				if (ParseTFunctions(txtCode.Text) == false)
				{
					if (MessageBox.Show("Program obsahuje chyby. Chcete pokračovať?", "Chyba počas prekladu",
						MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) return;
				}

				stopToolStripButton.Enabled = true;
				//runToolStripButton.Text = "Pauza";
				runToolStripButton.Visible = false;
				breakToolStripButton.Visible = true;

				PrgStop = false;
				pause = false;
				cmbTape.SelectedIndex = 1;


				if (delay != 0)
				{
					timMachine.Interval = (delay == 0) ? 1 : delay;
					timMachine.Start();
				}
				else //Real-Time
				{
					sourceCodeText = txtCode.Text;
					thRealTime = new System.Threading.Thread(RunRealTime);
					thRealTime.Start();
				}
			}
			else
			{
				Break();
				//timMachine.Stop();
				//PrgStop = true;                
			}
		}

		private void Break()
		{
			runToolStripButton.Visible = true;
			breakToolStripButton.Visible = false;
			pause = true;
		}

		void timMachine_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			lock (PushdownAutomaton)
			{
				if (PushdownAutomaton.IsAccepted())
				{
					TuringFinish();
					return;
				}

				PushdownAutomaton.NextStep(true);
				if (!PushdownAutomaton.NoNextStep)
				{
					UpdateUI();                    
				}
				else
				{
					TuringFinish();
				}

				RefreshStack();
				//Obnovenie komboboxu pások
				RefreshTapeComboBox();
				//Obnovenie ostatných textov
				this.lblStepCount.Text = "Počet vlákien: " + PushdownAutomaton.ThreadCount.ToString() + ", Počet vykonaných funkcií: " + PushdownAutomaton.StepCount.ToString();                
				lblThreadCount.Text = PushdownAutomaton.ThreadCount.ToString();
			}
			
			if (!pause && !PrgStop) timMachine.Start();
		}

		private void RefreshStack()
		{
			stackListBox.Items.Clear();
			foreach (var item in pushdownAutomaton.ActiveThread.Stack)
			{
				stackListBox.Items.Add(item);
			}
		}

		private void TuringFinish()
		{
			timMachine.Enabled = false;
			PrgStop = true;

			//Program skončil v koncovom stave
			if (PushdownAutomaton.IsAccepted())
			{
				MessageBox.Show("Zásobníkový automat úspešne dokončil program. (Páska bola prečítaná dokonca a bol dosiahnutý koncový stav.)", "Zásobníkový automat", MessageBoxButtons.OK, MessageBoxIcon.Information);
				tapeAcceptance = AcceptanceStatus.Accept;
			}
			else //Program skončil v inom ako koncovom stave, neexistujú prechodové funkcie pre ďalší chod
			{
				MessageBox.Show("Zásobníkový automat sa nemôže dostať do koncového stav. Neexistujú prechodové funkcie na prechod do ďalšieho stavu.", "Zásobníkový automat", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				tapeAcceptance = AcceptanceStatus.Reject;
			}
			PrgReset = true;

			//Koniec programu turingovho stroja (program nie je zastavený umelo)
			if (!PrgStop)
			{
				StopMachine();
			}

			//Neuchovávať pôvodnú pásku
			if (!PushdownAutomaton.StoreOriginalTape)
			{
				PushdownAutomaton.OriginalTapes = PushdownAutomaton.ActiveTapes;
				//TM.StartPosition = TM.Position;
			}

			UpdateGUI_AfterSimulationFinish();
		}        

		private void File_New()
		{
			PushdownAutomatonForm frm = new PushdownAutomatonForm();
			frm.MdiParent = this.MdiParent;
			frm.Show();
		}                

		private void CreateNewFile()
		{
			PushdownAutomaton = new PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };
			txtCode.Text = "";
			this.Refresh();
		}

		private void OpenFileInNewWindow(string fileName)
		{            
			if (!string.IsNullOrEmpty(fileName))
			{
				this.Text = System.IO.Path.GetFileName(fileName) + " - " + AppTitle;

				PushdownAutomatonForm frm = new PushdownAutomatonForm();
				frm.MdiParent = this.MdiParent;
				frm.Show();
				frm.OpenFile(fileName);
				frm.Activate();
			}
		}

		public void OpenFile(string fileName)
		{
			if (fileName.EndsWith(".pa"))
			{
				PushdownAutomaton = new PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead }; 
				txtCode.Text = PushdownAutomaton.Load(fileName);
				ParseTFunctions(txtCode.Text);
				
				openFileName = fileName;
				this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + AppTitle;
			}
			else if (fileName.EndsWith(".jff"))
			{
				JffReader reader = new JffReader(fileName);
				PushdownAutomaton = reader.Read();
				if (PushdownAutomaton == null)
				{
					PushdownAutomaton = new PushdownAutomaton();
				}
				else
				{
					StringBuilder sb = new StringBuilder();
					foreach (var tf in PushdownAutomaton.GetTFunctions())
					{
						sb.AppendLine(WriteTransition(tf, TransitionFormat));
					}
					txtCode.Text = sb.ToString();
				}
			}                       

			UpdateTapeSettings();
			infiniteTapeControl.UpdateScrollbars();
			this.Refresh();            
		}

		private void File_Save(string fileName)
		{                        
			if (!Functions.IsEmpty(fileName))
			{                
				if (!fileName.EndsWith(".pa")) fileName += ".pa";
				PushdownAutomaton.Save(fileName, txtCode.Text);
				
				openFileName = fileName;
				this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + AppTitle;
			}
		}

		private void File_SaveJff(string fileName)
		{
			if (!Functions.IsEmpty(fileName))
			{
				if (!fileName.EndsWith(".jff")) fileName += ".jff";
				JffWriter writer = new JffWriter(pushdownAutomaton, fileName);
				writer.Save(); 
			}
		}

		//Zoznam funkcií
		#region Zoznam funkcií
		private void pFunctions_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Rectangle rect,rect2;
			string txt;

			int sc = PushdownAutomaton.StepCount;

			Font fntBold = new Font("Arial", 11, FontStyle.Bold);
			Font fnt = new Font("Arial", 11);
			Font fntItalic = new Font("Arial", 11, FontStyle.Italic);
			StringFormat sfRight = new StringFormat();
			sfRight.Alignment = StringAlignment.Far;

			int i = 0;
			for (int a = 0; a <= (int)Math.Floor((double)pFunctions.Height / 20); a++)
			{
				i = a + (int)sbyFunctions.Value;
				if (i > PushdownAutomaton.TFunctionCount - 1) break; 

				rect = new Rectangle(0, a * 20, pFunctions.Width, 20);
				//Odlíšenie párnych a nepárnych riadkov
				if (i % 2 == 0)
				{
					g.FillRectangle(new SolidBrush(Functions.OddLineColor), rect);
				}

				//Funkcia, ktorá sa použije v nasledujúcom kroku
				if (PushdownAutomaton.CurrentState == PushdownAutomaton.TFunction(i).CurrentState)
				{
					if (PushdownAutomaton.CurrentSymbols.Equals(PushdownAutomaton.TFunction(i).ReadSymbol))
					{
						g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Green)), rect);
					}
					else
					{
						g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Yellow)), rect);
					}
				}

				//Text funkcie - aktuálny stav
				txt = PushdownAutomaton.TFunction(i).CurrentState + ", " + PushdownAutomaton.TFunction(i).ReadSymbol + " -> ";
				g.DrawString(txt, fntBold, Brushes.Black, (RectangleF)(rect));

				//Text funkcie - koncový stav
				txt = PushdownAutomaton.TFunction(i).NewState + ", " + PushdownAutomaton.TFunction(i).WriteSymbol + ", ";
				if (PushdownAutomaton.TFunction(i).Step == Transition.Steps.Left)
				{
					txt += " " + resMan.GetString("Left");
				}
				else if (PushdownAutomaton.TFunction(i).Step == Transition.Steps.Right)
				{
					txt += " " + resMan.GetString("Right");
				}
				else
				{
					txt += " Stoj";
				}
				rect2=rect;rect2.Offset(110,0);
				g.DrawString(txt, fnt, Brushes.Black, (RectangleF)(rect2));

				//Využitie funkcie
				if (sc == 0)
				{
					txt = "0 %";
				}
				else
				{
					txt = Math.Round((double)PushdownAutomaton.TFunction(i).UseCount / sc * 100, 2).ToString() + " %";
				}
				rect2 = rect; rect2.Offset(-25, 0);
				g.DrawString(txt, fntItalic, new SolidBrush(Color.FromArgb(120, Color.Black)), (RectangleF)(rect2),sfRight);

			}

			g.DrawRectangle(Pens.Black, 0, 0, pFunctions.Width - 1, pFunctions.Height - 1);
		}

		private void Functions_SetScrollbar()
		{
			if (this.InvokeRequired)
			{
				this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { Functions_SetScrollbar(); })));
			}
			else
			{
				int max;
				max = PushdownAutomaton.TFunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
				if (max < 0)
					max = 0;

				sbyFunctions.Maximum = max;
				sbyFunctions.SmallChange = 1;
				sbyFunctions.LargeChange = (int)Math.Floor((double)pFunctions.Height / 20);
				sbyFunctions.Visible = true;

				pFunctions.Refresh();
			}
		}

		private void sbyFunctions_Change()
		{
			pFunctions.Refresh();
		}

		private void pFunctions_Resize(object sender, System.EventArgs e)
		{
			Functions_SetScrollbar();
		}

		#endregion

		private void frmTuring_Closed(object sender, System.EventArgs e)
		{         
		}

		public void ExeCommand(string Command, bool IsNewMenu)
		{
			//Parameter
			string CValue;
			if (Command.IndexOf('(') > 0)
			{
				int i = Command.IndexOf('(');
				CValue = Command.Substring(i + 1, Command.LastIndexOf(')') - i - 1);
				Command = Command.Substring(0, i);
			}

			switch (Command)
			{                
				case "TAPE:CLEAR":
					PushdownAutomaton.OriginalTapes = new List<InfiniteTape>();
					infiniteTapeControl.Refresh();                    
					break;
				case "MACHINE:SETTINGS":
					//frmSettings dlg = new frmSettings(TM);
					//dlg.ShowDialog(this);
					break;
				case "CHANGESTATE":
					//TM.CurrentState = CValue;
					//lblCurrentState.Text = TM.CurrentState;                    
					break;
			}
		}

		private void lblCurrentState_Click(object sender, System.EventArgs e)
		{
			if (CodeChanged)
				ParseTFunctions(txtCode.Text);

			ContextMenu menu = new ContextMenu();            
			
			string[] States = PushdownAutomaton.GetUsedStates();
			for (int a = 0; a <= States.Length - 1; a++)
			{
				//mState.AddItem("Stav " + States(a), "CHANGESTATE(" + States(a) + ")");
				menu.MenuItems.Add("Stav " + States[a]);
			}

			Point pt = statusStrip.PointToScreen(new Point(0, lblCurrentState.Height));
			menu.Show(statusStrip, pt, LeftRightAlignment.Left);
		}

		private void pThreads_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			int offy = 80;
			Rectangle rect;
			Font fnt = new Font("Arial", 14);
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;
			Rectangle windowRect = new Rectangle(0,0,pThreads.Width,pThreads.Height);

			//Vykreslenie spracovania vlákien
			for (int a = 0; a <= PushdownAutomaton.ThreadCount - 1; a++)
			{                
				rect = new Rectangle(0, a * offy-sbyThreads.Value, pThreads.Width, offy);
				if (rect.IntersectsWith(windowRect))
				{
					if (PushdownAutomaton.Thread(a).Tapes.Count > 0)
					{
						int first = 0;
						InfiniteTapeControl.DrawTape(g, rect, PushdownAutomaton.Thread(a).Tapes[0],
							AcceptanceStatus.None, sbxThreads.Value, int.MinValue, false,
							out first);

						g.DrawRectangle(Pens.Black, rect);

						g.FillRectangle(new SolidBrush(Color.FromArgb(40, Color.Black)),
								new Rectangle(0, a * offy - sbyThreads.Value, 100, offy));

						//Stav
						rect = new Rectangle(10, a * offy + 10 - sbyThreads.Value, 80, 30);
						Functions.FillRoundRectangle(g, Brushes.White, rect, 5);
						Functions.DrawRoundRectangle(g, new Pen(Color.Black, 3), rect, 5);
						g.DrawString(PushdownAutomaton.Thread(a).CurrentState, fnt, Brushes.Black, rect, sf);
					}
				}
			}

			//Okraje
			g.DrawRectangle(Pens.Black, new Rectangle(0, 0, pThreads.Width - 1, pThreads.Height - 1));
		}        

   

		private void miExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void miCut_Click(object sender, EventArgs e)
		{
			this.txtCode.Cut();
		}

		private void miCopy_Click(object sender, EventArgs e)
		{
			this.txtCode.Copy();
		}

		private void miPaste_Click(object sender, EventArgs e)
		{
			this.txtCode.Paste();
		}

		private void miDelete_Click(object sender, EventArgs e)
		{
			this.txtCode.Delete();
		}

		private void miSelectAll_Click(object sender, EventArgs e)
		{
			this.txtCode.SelectAll();
		}

		private void miRun_Click(object sender, EventArgs e)
		{
			Run();
		}

		private void miStep_Click(object sender, EventArgs e)
		{
			NextStep();
		}

		private void miInsertSymbols_Click(object sender, EventArgs e)
		{

		}

		private void miCompressTape_Click(object sender, EventArgs e)
		{
			foreach (InfiniteTape tape in PushdownAutomaton.OriginalTapes)
			{
				tape.Compress();
			}
			infiniteTapeControl.Refresh();
		}

		private void miClearTape_Click(object sender, EventArgs e)
		{
			PushdownAutomaton.OriginalTapes = new List<InfiniteTape>();
			PushdownAutomaton.OriginalTapes.Add(new InfiniteTape());
		}

		private void miExportTape_Click(object sender, EventArgs e)
		{

		}

		private void miImportTape_Click(object sender, EventArgs e)
		{

		}

		private void miTapeStatistics_Click(object sender, EventArgs e)
		{
			//TapeStatisticsForm dlg = new TapeStatisticsForm();
			//dlg.tm = TuringMachine;
			//dlg.tapeIndex = cmbTape.SelectedIndex;
			//dlg.ShowDialog(this);
		}

		private void bAddTFunction_Click(object sender, EventArgs e)
		{
			AddTransition();
		}        

		private string WriteTransition(Transition tf, string transitionFormat)
		{
			string res="";
			int pos=0;
			int i = 0, l = 0;
			int n = 0; //Index vstupu
			string arg="";

			//String step = "";
			//switch (tf.Step)
			//{
			//    case Transition.Steps.Left:
			//        step = "L";
			//        break;
			//    case Transition.Steps.Right:
			//        step = "R";
			//        break;
			//    case Transition.Steps.NoMove:
			//        step = "0";
			//        break;
			//}

			transitionFormat=transitionFormat.Replace("\\s", " ");
			
			while(true) {
				i = transitionFormat.IndexOf("\\a", l);
				if (i == -1)
				{
					res += transitionFormat.Substring(l);
					break;
				}

				if (n == 0) arg = tf.CurrentState;
				else if (n == 1) arg = tf.ReadSymbol;
				else if (n == 2) arg = tf.StackRead;
				else if (n == 3) arg = tf.NewState;                
				else if (n == 4) arg = tf.StackWrite;

				res += transitionFormat.Substring(l, i - l) + arg;

				l = i + 2;
				n++;

			}            

			return res;
		}        

		private void miWriteLog_Click(object sender, EventArgs e)
		{
			PushdownAutomaton.WriteLog = miWriteLog.Checked;
		}

		//Vykreslenie logu
		private void pLog_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Font fnt = new Font("Arial", 10);
			int lineHeight = 60;

			if (PushdownAutomaton.Log.Count == 0)
			{
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString("Neexistujú žiadne záznamy. Záznamy priebehu sa vytvárajú počas vykonávania simulácie a môžete si ich prezrieť aj po jej skončení.",
					fnt, Brushes.Black, new RectangleF(0, 0, pLog.Width, pLog.Height), sf);
				return;
			}
			
			Font fntIndex = new Font("Arial", 10,FontStyle.Bold);
			StringFormat sf1 = new StringFormat();
				sf1.Alignment = StringAlignment.Near;
				sf1.LineAlignment = StringAlignment.Center;
			StringFormat sf2 = new StringFormat();
				sf2.Alignment = StringAlignment.Center;
				sf2.LineAlignment = StringAlignment.Center;
			RectangleF rect;
			Brush lineBrush = new SolidBrush(Color.FromArgb(30, Color.Black));
			Color highlightColor=Color.Transparent;
			int i=0,a=0;
			int c=0;
			int n = 0;
			int tapeFrom,tapeTo;
			tapeFrom = sbxLog.Value - 10;
			tapeTo= tapeFrom + (pLog.Width -150) /33;

			int logFrom, logTo;
			logFrom = sbyLog.Value;
			logTo = logFrom + pLog.Height / lineHeight + 1;
			if (logTo > PushdownAutomaton.Log.Count) logTo = PushdownAutomaton.Log.Count;

			g.SmoothingMode = SmoothingMode.AntiAlias;            
			
			for (i = logFrom; i<logTo; i++)
			{
				a=i-sbyLog.Value;                               

				//Odlíšenie riadkov
				if (i % 2 == 1) {
					g.FillRectangle(lineBrush, new Rectangle(0, a * lineHeight, this.Width, lineHeight));
				}

				g.DrawString((i+1).ToString(),
					fntIndex, Brushes.Black, new RectangleF(0, a * lineHeight, 40, lineHeight), sf1);

				// Prechodová funkcia
				g.DrawString(PushdownAutomaton.Log[i].Transition,
					fnt, Brushes.Black, new RectangleF(40, a * lineHeight + 2, pLog.Width, 20), sf1);
				g.DrawLine(new Pen(Color.FromArgb(80, Color.Black), 1), 40, a * lineHeight + 21, 35 + pLog.Width, a * lineHeight + 21);

				g.DrawString(resMan.GetString("Log_State") + " " + PushdownAutomaton.Log[i].State,
					fnt, Brushes.Black, new RectangleF(40, a * lineHeight + 20, 110, 20), sf1);
				g.DrawString(resMan.GetString("Log_Position") + " " + PushdownAutomaton.Log[i].Itapes[0].HeadPosition.ToString(),
					fnt, Brushes.Black, new RectangleF(40, a * lineHeight + 40, 110, 20), sf1);                                


				//Políčka pásky
				n = 0;
				for (c=tapeFrom;c<tapeTo;c++){
					rect = new RectangleF(150 + n * 36, a * lineHeight + 25, 30, 30);
					if (PushdownAutomaton.Log[i].GetHeadPosition(0) == c)
					{
						highlightColor = Color.Blue;
					}
					else if (i > 0 && PushdownAutomaton.Log[i].TapeChanged && PushdownAutomaton.Log[i - 1].GetHeadPosition(0) == c)
					{
						highlightColor = Color.Red;
					}
					else
					{
						highlightColor = Color.Transparent;
					}

					InfiniteTapeControl.DrawTapeSymbol(g, PushdownAutomaton.Log[i].Itapes[0][c], Rectangle.Round(rect), highlightColor, false);

					n++;
				}
			}
		}

		private void sbyLog_Scroll(object sender, ScrollEventArgs e)
		{
			sbyLog_ValueChanged(sender, new EventArgs());
		}

		private void sbyLog_ValueChanged(object sender, EventArgs e)
		{
			pLog.Invalidate();
		}

		private void Log_SetScrollbars()
		{
			//Vertikálny posuvník
			int max = PushdownAutomaton.Log.Count;
			sbyLog.LargeChange = (int)Math.Floor((double)pLog.Height / 60);
			sbyLog.Maximum = max;

			//Horizontálny posuvník            
			max = Math.Abs(PushdownAutomaton.OriginalTapes[0].GetLastNonBlankCell() - PushdownAutomaton.OriginalTapes[0].GetFirstNonBlankCell());
			sbxLog.LargeChange = 1;
			sbxLog.Minimum = PushdownAutomaton.Log.GetFirstNonBlankCell();
			sbxLog.Maximum = PushdownAutomaton.Log.GetLastNonBlankCell();
		}

		private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcMain.SelectedTab == logTab)
			{
				Log_SetScrollbars();
			}
			else if (tcMain.SelectedTab == statesTab)
			{                                
				UpdateStateDiagram();
			}
			else if (tcMain.SelectedTab == formalSpecificationTab)
			{
				//Načíta prechodové funkcie z kódu
				ParseTFunctions(txtCode.Text);
				//Vytvorí formálnu špecifikáciu
				CreateFormalSpecification();
			}
		}

		// Vytvorí formálnu špecifikáciu
		private string tmpFormalSpecFileName = null;
		private void CreateFormalSpecification()
		{
			if (tmpFormalSpecFileName != null)
			{
				File.Delete(tmpFormalSpecFileName);
			}

			string tmpDirPath = new FileInfo(Application.ExecutablePath).Directory.FullName + "\\tmp\\";
			tmpFormalSpecFileName = tmpDirPath + (new Random()).Next(1000000) + ".html";
			StringBuilder sb = new StringBuilder();

			if (!Directory.Exists(tmpDirPath))
			{
				Directory.CreateDirectory(tmpDirPath);
			}

			sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
			sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"sk\" lang=\"sk\">");
			//Hlavicka
			sb.AppendLine("<head>");
				sb.AppendLine("<title>Formálna špecifikácia</title>");
				
				sb.AppendLine("<style>");
				sb.AppendLine("body { font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; }");
				sb.AppendLine("h1 {");
				sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 30px;");
				sb.AppendLine("font-weight: bold; border-bottom-style: dotted;");
				sb.AppendLine("border-bottom-width: 3px; border-bottom-color: #000066;");
				sb.AppendLine("color: #000066; padding-bottom: 5px; margin-bottom: 10px;");
				sb.AppendLine("}");
				sb.AppendLine("h2 {");
				sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 16px;");
				sb.AppendLine("font-weight: bold;");                
				sb.AppendLine("color: #000066; margin-bottom: 5px;");
				sb.AppendLine("}");
				sb.AppendLine("</style>");
			sb.AppendLine("</head>");
			
			//Telo
			sb.AppendLine("<body>");
				//Nadpis
				sb.AppendLine("<h1>Formálna špecifikácia</h1>");

				sb.AppendLine("<div>");
				sb.AppendLine("Zásobníkový automat <strong>ZA = (K, Σ, Γ, δ, " + PushdownAutomaton.StartState + ", Z, F)</strong>");
				sb.AppendLine("</div>");

				// Množina stavov
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>K</strong> = {" + PushdownAutomaton.GetUsedStatesAsString() + "}");
				sb.AppendLine("</div>");
				// Vstupná abeceda
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Σ</strong> = {" + PushdownAutomaton.GetUsedSymbolsAsString() + "}");
				sb.AppendLine("</div>");
				// Zásobniková abeceda
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Γ</strong> = {" + PushdownAutomaton.GetUsedStackSymbolsAsString() + "}");
				sb.AppendLine("</div>");
				// Počiatočný stav
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>" + PushdownAutomaton.StartState + "</strong> - počiatočný stav");
				sb.AppendLine("</div>");
				// Symbol na dne zasobnika
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Z</strong> - symbol na dne zásobníka");
				sb.AppendLine("</div>");            
				// Množina koncových stavov
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", PushdownAutomaton.FinalStates.ToArray()) + "}");
				sb.AppendLine("</div>");

				// Prechodové funkcie
				sb.AppendLine("<div>");
				sb.AppendLine("<h2>Prechodová funkcia δ</h2>");
				foreach (Transition f in PushdownAutomaton.GetTFunctions())
				{
					sb.AppendLine("<div>");
					sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol + ", " + f.StackRead + 
						") = (" + f.NewState + ", "  + f.StackWrite + ")");
					sb.AppendLine("</div>");
				}
				sb.AppendLine("</div>");                
				
			sb.AppendLine("</body>");

			sb.AppendLine("</html>");

			System.IO.TextWriter tw = new System.IO.StreamWriter(
				new FileStream(tmpFormalSpecFileName, FileMode.Create, FileAccess.Write), Encoding.UTF8);
			tw.Write(sb.ToString());
			tw.Close();

			formalSpecifiaction.Navigate(tmpFormalSpecFileName);
		}        

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			if (saveFileDialog1.FilterIndex == 1)
				File_Save(saveFileDialog1.FileName);
			else if (saveFileDialog1.FilterIndex == 2)
				File_SaveJff(saveFileDialog1.FileName);
		}

		private void miNewFile_Click(object sender, EventArgs e)
		{
			File_New();
		}

		private void miOpenFile_Click(object sender, EventArgs e)
		{
			File_Open();
		}

		private void File_Open() {
			if (MdiParent == null) {
				openFileDialog1.ShowDialog(this);
				OpenFileInNewWindow(openFileDialog1.FileName);
				return;
			}
			((IMainForm)MdiParent).OpenFile();
		}

		private void miSaveFile_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void miSaveAsFile_Click(object sender, EventArgs e)
		{
			SaveAs();            
		}        

		private void Stop()
		{
			PrgStop = true;
			timMachine.Stop();
			StopMachine(); 
		}

		private void StopMachine()
		{
			if (this.InvokeRequired)
			{
				this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { StopMachine(); })));
			}
			else
			{
				PrgStop = true;
				runToolStripButton.Text = "Spustiť";
				stopToolStripButton.Enabled = false;
				PrgReset = true;
				stepToolStripButton.Enabled = true;

				if (cmbTape.SelectedIndex != 0)
				{
					infiniteTapeControl.ChangesAllowed = false;
				}
			}

		}

		private void Reset()
		{
			PushdownAutomaton.Reset();

			tapeAcceptance = AcceptanceStatus.None;

			PushdownAutomaton.Log.Clear();
			PushdownAutomaton.CurrentState = PushdownAutomaton.StartState;
			PrgReset = false;
			pause = false;

			//Zrušenie všetkých paralelných vlákien (okrem hlavného)
			PushdownAutomaton.RemoveAllThreads();

			//Nastavenie štandardnej pásky
			//TM.Position = TM.StartPosition;
			PushdownAutomaton.ActiveTapes = InfiniteTape.DeepCopyTapes(PushdownAutomaton.OriginalTapes);
		}

		private void miStop_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private void miPause_Click(object sender, EventArgs e)
		{
			Break();
		}

		private void txtFind_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				int i = txtCode.Text.IndexOf(txtFind.Text, Math.Min(txtCode.SelectionStart + 1,txtCode.Text.Length));
				if (i == -1)
				{
					txtCode.SelectionStart = 0;
					txtCode.SelectionLength = 0;
				}
				else
				{
					txtCode.SelectionStart = i;
					txtCode.SelectionLength = txtFind.Text.Length;
				}
				txtCode.Refresh();
			}
		}

		private void txtFind_Click(object sender, EventArgs e)
		{
			txtFind.SelectAll();
		}

		private void tbSpeed_Scroll(object sender, EventArgs e)
		{
			delay = (int)Math.Round(1000 - Math.Pow((double)tbSpeed.Value / tbSpeed.Maximum, 2) * 1000);
			if (delay == 0)
			{
				if (!PrgStop && (thRealTime == null || thRealTime.ThreadState == System.Threading.ThreadState.Stopped))
				{                    
					timMachine.Stop();                    

					System.Threading.Thread.SpinWait(10);
					
					UpdateTapeSettings();
					sourceCodeText = txtCode.Text;
					thRealTime = new System.Threading.Thread(RunRealTime);
					thRealTime.Start();                    
				}
			}
			else
			{
				timMachine.Interval = delay;
			}
		}

		private void tbSpeed_ValueChanged(object sender, EventArgs e)
		{
			tbSpeed_Scroll(sender, new EventArgs());
		}

		private void miAbout_Click(object sender, EventArgs e)
		{
			AboutForm dlg = new AboutForm();
			dlg.ShowDialog(this);
		}        

		private void bAddState_Click(object sender, EventArgs e)
		{            
			stateDiagramControl.AddNewState(Point.Empty);
		}        

		//Obnoví diagram stavov
		private void UpdateStateDiagram()
		{
			//Načíta prechodové funkcie z kódu
			ParseTFunctions(txtCode.Text);

			PushdownAutomaton.StateDiagram.UpdateForPA(PushdownAutomaton);
		}        

		private void sbyFunctions_Scroll(object sender, ScrollEventArgs e)
		{
			pFunctions.Refresh();
		}

		private void pThreads_Click(object sender, EventArgs e)
		{

		}

		private void miStoreOriginalTape_Click(object sender, EventArgs e)
		{
			PushdownAutomaton.StoreOriginalTape = miStoreOriginalTape.Checked;
		}

		private void sbyThreads_Scroll(object sender, ScrollEventArgs e)
		{
			pThreads.Invalidate();            
		}

		private void sbyThreads_ValueChanged(object sender, EventArgs e)
		{
			pThreads.Invalidate();
		}

		private void SetThreadPanelScrollbars()
		{
			sbyThreads.Maximum = PushdownAutomaton.ThreadCount * 80;
			sbyThreads.SmallChange = 80;
			sbyThreads.LargeChange = pThreads.Height;
		}

		private bool selectIndexNotChanged = false;
		private void cmbTape_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (selectIndexNotChanged) return;

			UpdateTapeSettings();

			infiniteTapeControl.UpdateScrollbars();
			infiniteTapeControl.Refresh();
		}

		private void miFind_Click(object sender, EventArgs e)
		{
			FindForm frm = new FindForm();
			frm.textBox = txtCode;
			frm.Show(this);
		}

		private void miReplace_Click(object sender, EventArgs e)
		{
			ReplaceForm frm = new ReplaceForm();
			frm.textBox = txtCode;
			frm.Show(this);
		}

		private void miTFormat1_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\sf\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = true; miTFormat2.Checked = false; miTFormat3.Checked = false; 
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false; 
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat2_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = true; miTFormat3.Checked = false; 
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false; 
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat3_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a,\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = true;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat4_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s[\\a,\\a,\\a]\\s[\\a,\\a]\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = true; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat5_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = true; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat6_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s[\\a,\\a,\\a]\\s->\\s[\\a,\\a]\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = true;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat7_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s->\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = true; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat8_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a->\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = true; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat9_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a>\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = true;
			miTFormat10.Checked = false;
		}

		private void miTFormat10_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = true;
			miTFormat10.Checked = false;
		}

		private void miAddTransition_Click(object sender, EventArgs e)
		{
			AddTransition();
		}

		private void miSettings_Click(object sender, EventArgs e)
		{             
			SettingsForm frm = new SettingsForm();
			frm.initialState = PushdownAutomaton.StartState;
			frm.finalStates = new List<string>(PushdownAutomaton.FinalStates);
			frm.ShowDialog(this);
			if (frm.OKPressed)
			{
				PushdownAutomaton.StartState = frm.initialState;
				PushdownAutomaton.FinalStates = frm.finalStates;
				UpdateStateDiagram();
			}
		}

		private void Save()
		{
			if (openFileName == null) SaveAs();
			else File_Save(openFileName);
		}

		private void SaveAs()
		{
			saveFileDialog1.ShowDialog(this);
		}

		

		private void frmTuringMachine_FormClosed(object sender, FormClosedEventArgs e)
		{
			timMachine.Stop();
			timMachine.Dispose();
		}

		private void sbxLog_Scroll(object sender, ScrollEventArgs e)
		{
			pLog.Invalidate();
		}

		private void sbxLog_ValueChanged(object sender, EventArgs e)
		{
			pLog.Invalidate();
		}        
		
		private void formalSpecSaveAs_Click(object sender, EventArgs e)
		{
			
		}

		private void formalSpecPrint_Click(object sender, EventArgs e)
		{
			formalSpecifiaction.Print();
		}

		private void lstErrors_Click(object sender, EventArgs e)
		{
			if (lstErrors.SelectedItem !=null)
			{
				TMError error = ((TMError)lstErrors.SelectedItem);
				txtCode.SelectLine(error.Line);
			}
		}

		private void pLog_Click(object sender, EventArgs e)
		{

		}

		private void infiniteTapeControl_TapeChanged(object sender, EventArgs e)
		{

		}

		private void infiniteTapeControl_HeadPositionChanged(object sender, EventArgs e)
		{

		}

		private void infiniteTapeControl_TapeCannotBeChanged(object sender, EventArgs e)
		{

		}

		private void UpdateTapeSettings()
		{
			if (this.InvokeRequired)
			{
				this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { UpdateTapeSettings(); })));
			}
			else
			{               
				infiniteTapeControl.ChangesAllowed = true;
				if (cmbTape.SelectedIndex != 0)
				{
					if (PrgStop)
					{
						infiniteTapeControl.ChangesAllowed = false;
					}
				}

				if (cmbTape.SelectedIndex == 0) //Pôvodná páska            
				{
					infiniteTapeControl.Tapes = PushdownAutomaton.OriginalTapes;
					//infiniteTapeControl.HeadPosition = TM.StartPosition;
					infiniteTapeControl.AcceptStatus = AcceptanceStatus.None;
				}
				else if (cmbTape.SelectedIndex == 1) //Aktívna páska            
				{
					infiniteTapeControl.Tapes = PushdownAutomaton.ActiveTapes;
					//infiniteTapeControl.HeadPosition = TM.Position;
					infiniteTapeControl.AcceptStatus = tapeAcceptance;

					selectIndexNotChanged = true;
					if (infiniteTapeControl.ChangesAllowed)
						cmbTape.Items[1] = "Aktívna páska";
					else
						cmbTape.Items[1] = "Výsledná páska";
					selectIndexNotChanged = false;
				}
				else //Pásky ostatných vlákien
				{
					infiniteTapeControl.Tapes = PushdownAutomaton.Thread(cmbTape.SelectedIndex - 2).Tapes;
					//infiniteTapeControl.HeadPosition = TM.Thread(cmbTape.SelectedIndex - 2).Position;
					infiniteTapeControl.AcceptStatus = tapeAcceptance;
				}

			}
		}

		private void sbxThreads_Scroll(object sender, ScrollEventArgs e)
		{
			sbxThreads_ValueChanged(sender, new EventArgs());
		}

		private void sbxThreads_ValueChanged(object sender, EventArgs e)
		{
			pThreads.Invalidate();
		}

		private void pLog_Resize(object sender, EventArgs e)
		{
			Log_SetScrollbars();
		}

		private void AddTransition()
		{
			AddTransition(new Transition());
		}

		private void AddTransition(Transition def_tf)
		{             
			AddTFunctionForm dlg = new AddTFunctionForm();
			dlg.TM = this.PushdownAutomaton;
			dlg.tfunction = def_tf;
			dlg.ShowDialog(this);
			if (dlg.OKPressed)
			{
				Transition tf = dlg.tfunction;
				txtCode.Text += Environment.NewLine;
				txtCode.Text += WriteTransition(tf, TransitionFormat);
				if (tf.Comment.Trim() != "") txtCode.Text += " //" + tf.Comment;
				txtCode.Text += Environment.NewLine;
				ParseTFunctions(txtCode.Text);
			}
		}

		private void stateDiagramControl_TransitionAdded(object sender, TransitionEventArgs e)
		{
			AddTransition(e.Transition);
		}

		private void stateDiagramControl_DiagramChanged(object sender, EventArgs e)
		{            
			UpdateStateDiagram();
		}

		private void infiniteTapeControl_Load(object sender, EventArgs e)
		{

		}

		private void newStripButton_Click(object sender, EventArgs e)
		{
			File_New(); 
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			File_Open();
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void runToolStripButton_Click(object sender, EventArgs e)
		{
			Run();
		}

		private void breakToolStripButton_Click(object sender, EventArgs e)
		{
			Break();
		}

		private void stopToolStripButton_Click(object sender, EventArgs e)
		{
			Stop();
		}

		private void stepToolStripButton_Click(object sender, EventArgs e)
		{
			NextStep();
		}
		
	}          

}