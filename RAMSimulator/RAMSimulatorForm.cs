using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using FEI.SimStudio.Components;
using FEI.RandomAccessMachine.Dialogs;
using FEI.RandomAccessMachine.Simulation;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Controls.RegisterList;
using FEI.SimStudio.Components.Dialogs;
using FEI.SimStudio.Components.Registers;

namespace FEI.RandomAccessMachine {
	public partial class RAMSimulatorForm : Form {
		const string AppTitle = "Random Access Machine (RAM)";

		public string openFileName = null;

		public bool fileChanged = false;
		public bool isFileEmpty = true;

		private bool AutoClearOutput = true;

		private List<InstructionType> allowedInstructions = new List<InstructionType>()
			{
				InstructionType.Accept,
				InstructionType.Add, InstructionType.Div, InstructionType.Halt, InstructionType.JGZero,
				InstructionType.Jump, InstructionType.JZero, InstructionType.Load, InstructionType.Mult,
				InstructionType.Read, InstructionType.Reject, InstructionType.Store, InstructionType.Subs,
				InstructionType.Write
			};

		public RAMSimulatorForm() {
			try {
				RAMSim = new Simulator(this);
				RAMSim.RefreshAnimation += new EventHandler(RAMSim_RefreshAnimation);
				RAMSim.ProgramFinished += new EventHandler(RAMSim_ProgramFinished);
				RAMSim.ProgramPaused += new EventHandler(RAMSim_ProgramPaused);
				RAMSim.OutputTapeChanged += new EventHandler(RAMSim_OutputTapeChanged);
				RAMSim.ReadingPositionChanged += new EventHandler(RAMSim_ReadingChanged);
				RAMSim.ReadingStatusChanged += new EventHandler(RAMSim_ReadingChanged);
				RAMSim.WritingPositionChanged += new EventHandler(RAMSim_WritingChanged);
				RAMSim.WritingStatusChanged += new EventHandler(RAMSim_WritingChanged);
				RAMSim.InstructionExecuted += new EventHandler(RAMSim_InstructionExecuted);
				RAMSim.ConsoleChanged += new EventHandler(RAMSim_ConsoleChanged);
			} catch { }

			InitializeComponent();

			lstRegs.Regs = RAMSim.regs;
			lstRegs.Regs[0] = new RegisterCell(0, "ACC");
		}

		//Obrázky
		Image iRam;
		Image[] iRead = new Image[4];
		Image[] iWrite = new Image[2];

		Simulator RAMSim = null;

		ComplexityForm ComplexityWindow = null;
		ScreenForm RamScreen = null;
		StackForm RamStack = null;
		ConsoleForm RamConsole = null;

		private bool OpenFileOK, SaveFileOK;

		void RAMSim_RefreshAnimation(object sender, EventArgs e) {
			try {
				if (RAMSim.prgPointer < sbyProgram.Value)
					sbyProgram.Value = RAMSim.prgPointer;
				if (RAMSim.prgPointer > sbyProgram.Value + (int)Math.Floor((double)picProgram.Height / 20) - 1)
					sbyProgram.Value = RAMSim.prgPointer - (int)Math.Floor((double)picProgram.Height / 20) + 1;
			} catch { }

			safeRefresh(picProgram);
			safeRefresh(lstRegs);
			safeRefresh(pProc);
		}

		delegate void SafeRefreshCallback(Control obj);
		private void safeRefresh(Control obj) {
			if (obj.InvokeRequired) {
				SafeRefreshCallback d = new SafeRefreshCallback(safeRefresh);
				this.Invoke(d, new object[] { obj });
			} else {
				obj.Refresh();
			}
		}

		delegate void SafeSetTextCallback(Control obj, string text);
		private void safeSetText(Control obj, string text) {
			if (obj.InvokeRequired) {
				SafeSetTextCallback d = new SafeSetTextCallback(safeSetText);
				this.Invoke(d, new object[] { obj, text });
			} else {
				obj.Text = text;
			}
		}

		void RAMSim_InstructionExecuted(object sender, EventArgs e) {
			if (RAMSim.Speed != 0) {
				if (ComplexityWindow != null) ComplexityWindow.RefreshValues();
				if (RamScreen != null) RamScreen.RefreshScreen();
				if (RamStack != null) RamStack.RefreshStack();
			}
		}

		void RAMSim_ConsoleChanged(object sender, EventArgs e) {
			if (InvokeRequired) {
				Invoke(new MethodInvoker(ConsoleChanged));
				return;
			}
			ConsoleChanged();
		}

		void ConsoleChanged() {
			if (RamConsole != null) RamConsole.RefreshConsole();
		}

		void RAMSim_ReadingChanged(object sender, EventArgs e) {
			lstRegs.ReadingPos = (int)Math.Round(RAMSim.CurReadPos);
			lstRegs.Reading = RAMSim.Reading;
		}

		void RAMSim_WritingChanged(object sender, EventArgs e) {
			lstRegs.WritingPos = (int)Math.Round(RAMSim.CurWritePos);
			lstRegs.Writing = RAMSim.Writing;
		}

		void RAMSim_OutputTapeChanged(object sender, EventArgs e) {
			this.ftOutputTape.Tape.Clear();
			this.ftOutputTape.Tape.AddRange(RAMSim.OutputTape);
			this.InvokeRefresh(ftOutputTape);
		}

		void RAMSim_ProgramFinished(object sender, EventArgs e) {
			if (ComplexityWindow != null) ComplexityWindow.RefreshValues();
			if (RamScreen != null) RamScreen.RefreshScreen();
			if (RamStack != null) RamStack.RefreshStack();
			if (RamConsole != null) RamConsole.RefreshConsole();

			//Štatistiky vykonaného programu
			this.lblStatus.Text = "Počet vykonaných inštrucií: " + RAMSim.CycleCount.ToString()
					+ ", Trvanie: " + new DateTime(DateTime.Now.Ticks - RAMSim.StartTime).ToLongTimeString()
					+ ", Rýchlosť: " + (RAMSim.CycleCount / (Math.Max((double)(DateTime.Now.Ticks - RAMSim.StartTime) / 10000000, double.Epsilon))).ToString() + " inštrukcií za sekundu";
			this.InvokeRefresh(this);

			stopToolStripButton.Enabled = false;
			runToolStripButton.Visible = true;
			runToolStripButton.Enabled = true;
			breakToolStripButton.Visible = false;
			stepToolStripButton.Enabled = true;

			ftOutputTape.Tape.Clear();
			ftOutputTape.Tape.AddRange(RAMSim.OutputTape);
			ftOutputTape.UpdateScrollbars();
			ftOutputTape.Refresh();
		}

		void RAMSim_ProgramPaused(object sender, EventArgs e) {
			if (ComplexityWindow != null) ComplexityWindow.RefreshValues();
			if (RamScreen != null) RamScreen.RefreshScreen();
			if (RamStack != null) RamStack.RefreshStack();
			if (RamConsole != null) RamConsole.RefreshConsole();

			//runToolStripButton.Text = "Spustiť";            
			sbyProgram.Visible = true;
		}

		public bool IsFileEmpty {
			get { return isFileEmpty; }
			set { isFileEmpty = value; }
		}

		public bool FileChanged {
			get { return fileChanged; }
			set {
				fileChanged = value;
				if (fileChanged)
					saveToolStripButton.Enabled = true;
				else
					saveToolStripButton.Enabled = false;
			}
		}

		private void LoadGraphics() {
			try {
				string myPath = Application.ExecutablePath;
				myPath = myPath.Substring(0, myPath.LastIndexOf('\\'));


				iRam = Image.FromFile(myPath + "\\graphics\\RAM.png");

				iRead[0] = Image.FromFile(myPath + "\\graphics\\ReadOff.png");
				iRead[1] = Image.FromFile(myPath + "\\graphics\\Read.png");
				iRead[2] = Image.FromFile(myPath + "\\graphics\\ReadPOff.png");
				iRead[3] = Image.FromFile(myPath + "\\graphics\\ReadP.png");
				iWrite[0] = Image.FromFile(myPath + "\\graphics\\WriteOff.png");
				iWrite[1] = Image.FromFile(myPath + "\\graphics\\Write.png");
			} catch { }
		}
		private void DisposeGraphics() {
			try {
				iRam.Dispose();
				for (int a = 0; a <= iRead.Length - 1; a++) {
					iRead[a].Dispose();
				}
				for (int a = 0; a <= iWrite.Length - 1; a++) {
					iWrite[a].Dispose();
				}
			} catch { }
		}

		private void txtProgram_TextChanged(object sender, System.EventArgs e) {
			FileChanged = true;
			IsFileEmpty = false;

			Compile(false);
			UpdateInputTape();

			picProgram.Refresh();
			//Nastaví  posuvníky
			SetScrolls();
			//Obnoví zoznam registrov
			lstRegs.Refresh();
		}

		private bool Compile(bool showErrors) {
			try {
				Compiler compiler = new Compiler(allowedInstructions);
				compiler.CompileIn(RAMSim, txtProgram.Text);
				return true;
			} catch (CompilerException ex) {
				if (showErrors) {
					errorTextBox.Text += Environment.NewLine + Environment.NewLine + ex.ToString();
					errorTextBox.SelectionStart = errorTextBox.Text.Length - 1;
					errorTextBox.ScrollToCaret();
					mainSplitContainer.Panel2Collapsed = false;
				}
				return false;
			}
		}

		//Vykreslí tabuľku inštrukcií
		private void DrawIns(Graphics G) {
			if (RAMSim.program == null) {
				DrawInsTable(G);
				return;
			}

			int i;
			Font insFont = new Font(picProgram.Font, FontStyle.Bold);
			Pen skipPen = new Pen(Color.White, 2);

			G.SmoothingMode = SmoothingMode.AntiAlias;

			for (int a = 0; a <= (int)Math.Floor((double)picProgram.Height / 20); a++) {
				i = a + sbyProgram.Value;
				if ((RAMSim.program != null) && i < RAMSim.program.Count) {
					if (i % 2 == 1) {
						G.FillRectangle(Brushes.LightGray, new Rectangle(0, a * 20, picProgram.Width, 20));
					}
					//Aktuálna inštrukcia
					if (Math.Round(RAMSim.CurProgramPos) == i && i == RAMSim.prgPointer) {
						DrawGRect(G, Color.Yellow, new Rectangle(0, a * 20, picProgram.Width, 20));
					} else {
						if (i == RAMSim.prgPointer)
							G.FillRectangle(new SolidBrush(Color.FromArgb(60, Color.Yellow)),
								new Rectangle(0, a * 20, picProgram.Width, 20));
					}

					//Breakpoint
					if (RAMSim.program[i].Stop) {
						G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DarkRed)), new Rectangle(0, a * 20, picProgram.Width, 20));
						G.FillEllipse(Brushes.DarkRed, new Rectangle(3, 3 + a * 20, 15, 15));
						G.DrawEllipse(Pens.Black, new Rectangle(3, 3 + a * 20, 15, 15));
					}
					//Skip
					if (RAMSim.program[i].Skip) {
						G.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DarkBlue)), new Rectangle(0, a * 20, picProgram.Width, 20));
						//G.FillEllipse(Brushes.DarkBlue, New Rectangle(3, 3 + a * 20, 15, 15))
						//G.DrawEllipse(Pens.Black, New Rectangle(3, 3 + a * 20, 15, 15))
						G.DrawLine(skipPen, 5, 5 + a * 20, 15, 15 + a * 20);
						G.DrawLine(skipPen, 5 + 10, 5 + a * 20, 5, 15 + a * 20);
					}

					G.DrawString(i.ToString(), this.Font, Brushes.Black, 20, a * 20);
					G.DrawString(RAMSim.labeledProgram[i].Label, this.Font, Brushes.Black, 50, a * 20);
					G.DrawString(Compiler.GetCommand(RAMSim.program[i].Command), insFont, Brushes.Black, 110, a * 20);
					if (RAMSim.labeledProgram[i].OpLabel != "") {
						G.DrawString(RAMSim.labeledProgram[i].OpLabel, this.Font, Brushes.Blue, 170, a * 20);
					} else {
						G.DrawString(Compiler.GetOT(RAMSim.program[i].OperandType) + RAMSim.program[i].Operand.ToString(), this.Font, Brushes.Black, 170, a * 20);
					}

				}
			}

			DrawInsTable(G);
		}

		//Vykreslí okraje tabuľky inštrukcií
		private void DrawInsTable(Graphics G) {
			G.DrawLine(Pens.Black, 20, 0, 20, picProgram.Height);
			G.DrawLine(Pens.Black, 50, 0, 50, picProgram.Height);
			G.DrawLine(Pens.Black, 110, 0, 110, picProgram.Height);
			G.DrawRectangle(Pens.Black, 0, 0, picProgram.Width - 1, picProgram.Height - 1);
		}

		private void picProgram_Click(object sender, System.EventArgs e) {

		}

		private void picProgram_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			DrawIns(e.Graphics);
		}

		private void Run() {
			if (!Compile(true)) {
				MessageBox.Show("Program nie je možné skompilovať, obsahuje chyby.", "Chyby", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			if (AutoClearOutput) { RAMSim.OutputTape.Clear(); ftOutputTape.Clear(); }
			if (RAMSim.RamConsole) ShowConsole();

			RAMSim.Run();

			runToolStripButton.Visible = false;
			breakToolStripButton.Visible = true;
			stopToolStripButton.Enabled = true;
			stepToolStripButton.Enabled = false;
		}

		private void Break() {
			RAMSim.PrgStop = true;

			runToolStripButton.Visible = true;
			breakToolStripButton.Visible = false;
			stopToolStripButton.Enabled = true;
			stepToolStripButton.Enabled = true;
		}

		private void bRun_Click(object sender, System.EventArgs e) {
			UpdateInputTape();
			
			if (RAMSim.PrgStop) {
				Run();
			} else {
				Break();
			}
		}



		public delegate void RepaintDelegate(Control c);
		private void InvokeRefresh(Control c) {
			if (c.InvokeRequired) {
				System.Delegate d = new RepaintDelegate(InvokeRefresh);
				this.Invoke(d, c);
			} else {
				c.Refresh();
			}
		}

		private void bStep_Click(object sender, System.EventArgs e) {
			if (RAMSim.EndOfPrg) {
				Reset();
			}

			UpdateInputTape();
			Step();

			ftOutputTape.Tape.Clear();
			ftOutputTape.Tape.AddRange(RAMSim.OutputTape);
			ftOutputTape.UpdateScrollbars();
			ftOutputTape.Refresh();
		}

		private void Step() {
			if (RAMSim.program == null) return;

			stopToolStripButton.Enabled = true;
			RAMSim.Step();
			lstRegs.Refresh();
			picProgram.Refresh();
		}

		//Vykreslí označenie
		public void DrawGRect(Graphics G, Color BColor, Rectangle Rect) {
			Pen pero = new Pen(Color.Black, 2);

			pero.Alignment = PenAlignment.Inset;
			G.FillRectangle(new LinearGradientBrush(Rect, BColor, Color.White, LinearGradientMode.Vertical), Rect);
			G.FillRectangle(new LinearGradientBrush(new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height / 2), Color.White, Color.FromArgb(100, Color.White), LinearGradientMode.Vertical), new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height / 2));
			G.DrawRectangle(pero, Rect);
			pero.Dispose();
		}

		private void bReset_Click(object sender, System.EventArgs e) {
			RAMSim.Stop();
			stopToolStripButton.Enabled = false;
			runToolStripButton.Enabled = true;
			runToolStripButton.Visible = true;
			stepToolStripButton.Visible = true;
			breakToolStripButton.Visible = false;
		}

		private void Reset() {
			RAMSim.Reset();

			lstRegs.Refresh();
			picProgram.Refresh();
			sbyProgram.Visible = true;
			//runToolStripButton.Text = "Spustiť";
			stopToolStripButton.Enabled = false;
			runToolStripButton.Enabled = true;
			runToolStripButton.Visible = true;
			stepToolStripButton.Visible = true;
			breakToolStripButton.Visible = false;

			if (AutoClearOutput) { RAMSim.OutputTape.Clear(); ftOutputTape.Clear(); }
			//ftOutputTape.Clear();
			//RAMSim.OutputTape.Clear();

			RAMSim.InputTape.AddRange(ftInputTape.Records);
		}

		private string OpenTextFile(string FileName) {
			string functionReturnValue = System.IO.File.ReadAllText(FileName, Encoding.Default);
			return functionReturnValue;
		}

		private void SaveTextFile(string FileName, string Text) {
			System.IO.TextWriter f = System.IO.File.CreateText(FileName);
			f.Write(Text);
			f.Close();

			FileChanged = false;
		}

		private void mExit_Click(object sender, System.EventArgs e) {
			this.Close();
		}

		private void SetScrolls() {
			if (RAMSim == null || RAMSim.program == null || RAMSim.program.Count == 0) {
				sbyProgram.Maximum = 0;
				return;
			}

			sbyProgram.LargeChange = (int)Math.Floor((double)picProgram.Height / 20);
			if (RAMSim != null)
				sbyProgram.Maximum = RAMSim.program.Count - 1;
		}

		private void picProgram_Resize(object sender, System.EventArgs e) {
			SetScrolls();
			picProgram.Invalidate();
		}


		private void pProc_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			Graphics g = e.Graphics;

			int x;
			int y;
			int i;
			Pen linePen;
			x = (int)Math.Floor((double)(pProc.Width - iRam.Width) / 2);
			y = (int)Math.Floor((double)(pProc.Height - iRam.Height) / 2);
			g.DrawImage(iRam, x, y, iRam.Width, iRam.Height);

			g.SmoothingMode = SmoothingMode.AntiAlias;

			//Registre: Čítacia hlava
			i = (int)((RAMSim.CurReadPos - lstRegs.ScrollValue) * 20);
			if (RAMSim.Reading)
				linePen = new Pen(Color.Green, 2);
			else
				linePen = Pens.Black;
			g.DrawLine(linePen, x + iRam.Width, y + (int)iRam.Height / 2, pProc.Width - iRead[BoolValue(RAMSim.Reading)].Width, i + 10);
			g.DrawImage(iRead[BoolValue(RAMSim.Reading)],
				pProc.Width - iRead[BoolValue(RAMSim.Reading)].Width, i + (int)(20 - iRead[BoolValue(RAMSim.Reading)].Height) / 2,
				iRead[BoolValue(RAMSim.Reading)].Width, iRead[BoolValue(RAMSim.Reading)].Height);

			//Registre: Zapisovacia hlava
			i = (int)((RAMSim.CurWritePos - lstRegs.ScrollValue) * 20);
			if (RAMSim.Writing)
				linePen = new Pen(Color.Red, 2);
			else
				linePen = Pens.Black;
			g.DrawLine(linePen, x + iRam.Width, y + (int)iRam.Height / 2, pProc.Width - iWrite[BoolValue(RAMSim.Writing)].Width, i + 10);
			g.DrawImage(iWrite[BoolValue(RAMSim.Writing)], pProc.Width - iWrite[BoolValue(RAMSim.Writing)].Width, i + (int)(20 - iWrite[BoolValue(RAMSim.Writing)].Height) / 2, iWrite[BoolValue(RAMSim.Writing)].Width, iWrite[BoolValue(RAMSim.Writing)].Height);

			//Program: Čítacia hlava
			i = (int)((RAMSim.CurProgramPos - sbyProgram.Value) * 20);
			if (RAMSim.Executing)
				linePen = new Pen(Color.Green, 2);
			else
				linePen = Pens.Black;
			g.DrawLine(linePen, x, y + (int)iRam.Height / 2, iRead[2 + BoolValue(RAMSim.Executing)].Width, i + 10);
			g.DrawImage(iRead[2 + BoolValue(RAMSim.Executing)],
				0, i + (int)(20 - iRead[2 + BoolValue(RAMSim.Executing)].Height) / 2,
				iWrite[BoolValue(RAMSim.Writing)].Width, iRead[2 + BoolValue(RAMSim.Executing)].Height);
		}

		public int BoolValue(bool value) {
			return value ? 1 : 0;
		}

		private void RAMSimulatorForm_Disposed(object sender, System.EventArgs e) {
			DisposeGraphics();
		}

		//private void RAMSimulatorForm_Load(object sender, System.EventArgs e)
		//{

		//}        

		private void pProc_Resize(object sender, System.EventArgs e) {
			pProc.Refresh();
		}

		private void picProgram_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (RAMSim.program == null) return;

			if (e.X < 20) {
				int i = (int)Math.Floor((double)e.Y / 20) + sbyProgram.Value;
				if (i < RAMSim.program.Count) {
					if (e.Button == MouseButtons.Left) {
						RAMSim.InvertBreakPointAt(i);
					} else {
						RAMSim.InvertSkipPointAt(i);
					}
					picProgram.Refresh();
				}
			}
		}

		#region Pohľady
		private void View_All() {
			miViewAll.Checked = true;
			miViewCode.Checked = false;
			miViewSimulation.Checked = false;

			lstRegs.Left = this.ClientSize.Width - 250;
			lstRegs.Width = 240;
			lstRegs.Visible = true;

			picProgram.Left = lstRegs.Left - 308;
			picProgram.Width = 304;
			picProgram.Visible = true;
			picProgram.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

			sbyProgram.Left = picProgram.Right - sbyProgram.Width - 1;
			sbyProgram.Visible = true;

			txtProgram.Left = 8;
			txtProgram.Width = picProgram.Left - 16;
			txtProgram.Visible = true;

			pProc.Visible = false;
		}

		private void View_SourceCode() {
			miViewAll.Checked = false;
			miViewCode.Checked = true;
			miViewSimulation.Checked = false;

			picProgram.Visible = false;
			lstRegs.Visible = false;
			sbyProgram.Visible = false;
			lstRegs.Visible = false;
			pProc.Visible = false;

			txtProgram.Left = 8;
			txtProgram.Width = this.ClientSize.Width - 16;
			txtProgram.Visible = true;
		}

		private void View_Simulation() {
			miViewAll.Checked = false;
			miViewCode.Checked = false;
			miViewSimulation.Checked = true;

			lstRegs.Left = this.ClientSize.Width - 208;
			lstRegs.Width = 200;
			lstRegs.Visible = true;

			pProc.Left = lstRegs.Left - 286;
			pProc.Width = 286;
			pProc.Visible = true;

			picProgram.Left = 8;
			picProgram.Width = pProc.Left - 8;
			picProgram.Visible = true;
			picProgram.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

			sbyProgram.Left = picProgram.Right - sbyProgram.Width;
			sbyProgram.Visible = true;

			txtProgram.Visible = false;
		}
		#endregion

		private void sbyProgram_Scroll(object sender, ScrollEventArgs e) {
			picProgram.Refresh();
			pProc.Refresh();
		}

		private void RAMSimulatorForm_Load(object sender, EventArgs e) {
			if (MdiParent != null) menuStrip1.Visible = false;
			this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon")));

			//Načítanie grafiky
			LoadGraphics();
			picProgram.Refresh();

			//Formátovanie inštrukcií            
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("add", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("sub", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("mul", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("mult", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("div", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("load", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("store", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("read", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("write", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("jump", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("jzero", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("jgtz", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("jgzero", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("halt", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("accept", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("reject", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("while", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("{", Color.Black, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("}", Color.Black, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("gzero", Color.Purple, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("push", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("pop", Color.Blue, true));
			txtProgram.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("print", Color.Blue, true));

			//Ďalšie formátovanie
			txtProgram.SyntaxWords.fStrings = new SyntaxTextBox.SyntaxFormat(Color.DarkRed, true);
			txtProgram.SyntaxWords.fNumbers = new SyntaxTextBox.SyntaxFormat(Color.DarkBlue, true);
			txtProgram.SyntaxWords.fComment = new SyntaxTextBox.SyntaxFormat(Color.DarkGreen);

			AddSpeedPanel();
		}

		private void AddSpeedPanel() {
			ToolStripControlHost host = new ToolStripControlHost(speedPanel);
			host.Alignment = ToolStripItemAlignment.Right;
			host.Width = 200;
			host.AutoSize = false;
			mainToolStrip.Items.Add(host);
		}

		private void miOpen_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void OpenFile() {
			if (MdiParent == null) {
				OpenFileOK = false;
				openFileDialog1.Title = "Otvoriť súbor RAM";
				openFileDialog1.AddExtension = true;
				openFileDialog1.DefaultExt = "ram";
				openFileDialog1.Filter = "Súbor RAM (*.ram)|*.ram|Textový súbor (*.txt)|*.txt|Všetky súbory|*.*";
				openFileDialog1.ShowDialog(this);

				if (OpenFileOK && openFileDialog1.FileName != "") {
					if (!IsFileEmpty) {
						RAMSimulatorForm rAMSimulatorForm = new RAMSimulatorForm();
						rAMSimulatorForm.MdiParent = MdiParent;
						rAMSimulatorForm.Show();
						rAMSimulatorForm.File_Open(openFileDialog1.FileName);
						rAMSimulatorForm.Activate();
						return;
					}
					File_Open(openFileDialog1.FileName);
					return;
				}

			} else {
				((IMainForm)MdiParent).OpenFile();
			}
		}

		public void File_Open(string filename) {
			this.openFileName = filename;
			txtProgram.Text = OpenTextFile(filename);

			this.Text = System.IO.Path.GetFileName(openFileName) + " - " + AppTitle;
		}

		private void miSave_Click(object sender, EventArgs e) {
			File_Save();
		}

		private void miViewAll_Click(object sender, EventArgs e) {
			View_All();
		}

		private void miViewCode_Click(object sender, EventArgs e) {
			View_SourceCode();
		}

		private void miViewSimulation_Click(object sender, EventArgs e) {
			View_Simulation();
		}

		private void miConvertFromC_Click(object sender, EventArgs e) {
			CConversionForm dlg = new CConversionForm();
			dlg.ShowDialog(this);
			if (dlg.OKPressed) {
				txtProgram.Text = dlg.resCode;
			}
		}

		private void miClearTapes_Click(object sender, EventArgs e) {
			RAMSim.InputTape.Clear();
			RAMSim.OutputTape.Clear();

			ftInputTape.Clear();
			ftOutputTape.Clear();
		}

		private void miClearInputTape_Click(object sender, EventArgs e) {
			RAMSim.InputTape.Clear();
			ftInputTape.Clear();
		}

		private void miClearOutputTape_Click(object sender, EventArgs e) {
			RAMSim.OutputTape.Clear();
			ftOutputTape.Clear();
		}

		private void miNew_Click(object sender, EventArgs e) {
			NewFile();
		}

		private void NewFile() {
			RAMSimulatorForm frm = new RAMSimulatorForm();
			frm.MdiParent = this.MdiParent;
			frm.Show();
		}

		private void miExit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void miCut_Click(object sender, EventArgs e) {
			this.txtProgram.Cut();
		}

		private void miCopy_Click(object sender, EventArgs e) {
			this.txtProgram.Copy();
		}

		private void miPaste_Click(object sender, EventArgs e) {
			this.txtProgram.Paste();
		}

		private void miDelete_Click(object sender, EventArgs e) {
			this.txtProgram.Delete();
		}

		private void miSelectAll_Click(object sender, EventArgs e) {
			this.txtProgram.SelectAll();
		}

		private void miRun_Click(object sender, EventArgs e) {
			Run();
		}

		private void miPause_Click(object sender, EventArgs e) {
			Break();
		}

		private void miStep_Click(object sender, EventArgs e) {
			Step();
		}

		private void miStop_Click(object sender, EventArgs e) {
			Reset();
		}

		private void miFind_Click(object sender, EventArgs e) {
			FindForm frm = new FindForm();
			frm.textBox = txtProgram;
			frm.Show(this);
		}

		private void miReplace_Click(object sender, EventArgs e) {
			ReplaceForm frm = new ReplaceForm();
			frm.textBox = txtProgram;
			frm.Show(this);
		}

		private void miAbout_Click(object sender, EventArgs e) {
			AboutForm frm = new AboutForm();
			frm.ShowDialog(this);
		}

		private void txtFind_Click(object sender, EventArgs e) {
			txtFind.SelectAll();
		}

		private void txtFind_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				int i = txtProgram.Text.IndexOf(txtFind.Text, Math.Min(txtProgram.SelectionStart + 1, txtProgram.Text.Length));
				if (i == -1) {
					txtProgram.SelectionStart = 0;
					txtProgram.SelectionLength = 0;
				} else {
					txtProgram.SelectionStart = i;
					txtProgram.SelectionLength = txtFind.Text.Length;
				}
				txtProgram.Refresh();
			}
		}

		private void miSaveAs_Click(object sender, EventArgs e) {
			File_SaveAs();
		}

		private void File_SaveAs() {
			SaveFileOK = false;
			saveFileDialog1.Title = "Uložiť súbor RAM";
			saveFileDialog1.AddExtension = true;
			saveFileDialog1.DefaultExt = "ram";
			saveFileDialog1.Filter = "Súbor RAM (*.ram)|*.ram|Všetky súbory|*.*";
			saveFileDialog1.ShowDialog(this);

			if (SaveFileOK && saveFileDialog1.FileName != "") {
				openFileName = saveFileDialog1.FileName;
				SaveTextFile(saveFileDialog1.FileName, txtProgram.Text);
			}
		}

		private void File_Save() {
			if (openFileName == null)
				File_SaveAs();
			else {
				SaveTextFile(openFileName, txtProgram.Text);
			}
		}

		private void miComplexity_Click(object sender, EventArgs e) {
			ComplexityWindow = new ComplexityForm();
			ComplexityWindow.RAMSim = RAMSim;
			ComplexityWindow.Show(this);
		}

		private void ftInputTape_RecordAdded(object sender, EventArgs e) {
			UpdateInputTape();
		}

		private void UpdateInputTape() {
			RAMSim.InputTape = new List<string>(ftInputTape.Tape);
		}

		private void ftInputTape_RecordChanged(object sender, EventArgs e) {
			UpdateInputTape();
		}

		private void lstRegs_ViewPositionChange(object sender, EventArgs e) {
			pProc.Refresh();
		}

		private void miScreen_Click(object sender, EventArgs e) {
			if (RamScreen == null) {
				miScreen.Checked = true;
				RamScreen = new ScreenForm();
				RamScreen.simulator = this.RAMSim;
				RamScreen.Show(this);
			} else {
				miScreen.Checked = false;
				RamScreen.Close();
				RamScreen = null;
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
			OpenFileOK = true;
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) {
			SaveFileOK = true;
		}

		private void miRunMaxSpeed_Click(object sender, EventArgs e) {
			if (RAMSim.RamConsole) ShowConsole();
			RAMSim.RunAtMaxSpeed();
		}

		private void miAutoClearOutput_Click(object sender, EventArgs e) {
			AutoClearOutput = miAutoClearOutput.Checked;
		}

		private void lstRegs_RegisterChanged(object sender, RegisterList.RegisterEventArgs reg) {
			if (RAMSim.EndOfPrg) {
				string[] lines = txtProgram.Text.Split('\n');
				string regDef = "//#" + reg.index;
				StringBuilder sb = new StringBuilder(txtProgram.Text.Length + 100);
				bool added = false;

				foreach (string line in lines) {
					if (line.Trim().StartsWith(regDef)) {
						sb.AppendLine("//#" + reg.index + " " + reg.register.Name + " = " + reg.register.Value);
						added = true;
					} else {
						sb.AppendLine(line);
					}
				}

				if (!added) {
					sb.Insert(0, "//#" + reg.index + " " + reg.register.Name + " = " + reg.register.Value + "\n");
				}

				txtProgram.Text = sb.ToString();
			}
			RAMSim.regs.SetValue(new InfiniteInteger(reg.index), reg.register.Value);
		}

		private void miStack_Click(object sender, EventArgs e) {
			if (RamStack == null) {
				miStack.Checked = true;
				RamStack = new StackForm();
				RamStack.simulator = this.RAMSim;
				RamStack.Show(this);
			} else {
				miStack.Checked = false;
				RamStack.Close();
				RamStack = null;
			}

		}

		private void miConsole_Click(object sender, EventArgs e) {
			if (RamConsole == null) {
				ShowConsole();
			} else {
				HideConsole();
			}
		}

		private void HideConsole() {
			miConsole.Checked = false;
			RamConsole.Close();
			RamConsole = null;
		}

		private void ShowConsole() {
			miConsole.Checked = true;
			RamConsole = new ConsoleForm();
			RamConsole.simulator = this.RAMSim;
			RamConsole.Show(this);
		}

		private void newStripButton_Click(object sender, EventArgs e) {
			NewFile();
		}

		private void openToolStripButton_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void saveToolStripButton_Click(object sender, EventArgs e) {
			File_Save();
		}

		private void runToolStripButton_Click(object sender, EventArgs e) {
			Run();
		}

		private void breakToolStripButton_Click(object sender, EventArgs e) {
			Break();
		}

		private void stopToolStripButton_Click(object sender, EventArgs e) {
			Reset();
		}

		private void stepToolStripButton_Click(object sender, EventArgs e) {
			Step();
		}

		private void RAMSimulatorForm_FormClosed(object sender, FormClosedEventArgs e) {
			RAMSim.Stop();
		}


		private void tbSpeed_Scroll(object sender, EventArgs e) {
			RAMSim.Speed = (int)Math.Round(1000 - Math.Pow((double)tbSpeed.Value / tbSpeed.Maximum, 2) * 1000);
		}

		private void instructionSetToolStripMenuItem_Click(object sender, EventArgs e) {
			InstructionSetForm frm = new InstructionSetForm();
			frm.AllowedInstructions = new List<InstructionType>(allowedInstructions);
			if (frm.ShowDialog(this) == DialogResult.OK) {
				allowedInstructions = frm.AllowedInstructions;
			}
		}

		private void closeErrorsButton_Click(object sender, EventArgs e) {
			mainSplitContainer.Panel2Collapsed = true;
		}


	}
}