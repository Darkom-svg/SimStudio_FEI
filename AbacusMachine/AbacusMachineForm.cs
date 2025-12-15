using DusanRodina.AbacusMachine.Simulation;
using DusanRodina.SimStudio.Components;
using DusanRodina.SimStudio.Components.Dialogs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DusanRodina.AbacusMachine {
	public partial class AbacusMachineForm : Form
	{
		public static string AppTitle = "Počítadlový stroj (Abacus Machine)";

		private string openFileName = null;

		private bool OpenFileOK, SaveFileOK;

		VirtualAbacusMachine AM = new VirtualAbacusMachine();        
		System.Timers.Timer timRun = new System.Timers.Timer();
		System.Timers.Timer timReal = new System.Timers.Timer();
		int delay = 100;

		public AbacusMachineForm()
		{
			InitializeComponent();
			
			txtCode.RegexParsePattern = "\\w[0-9]+|[^A-Za-z0-9_ \\f\\t\\v]|\\w";
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("a", SyntaxTextBox.SyntaxType.WordStartsWith, Color.DarkCyan, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("s", SyntaxTextBox.SyntaxType.WordStartsWith, Color.DarkOrange, true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("(", Color.DarkBlue,true));
			txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord(")", Color.DarkBlue,true));
			txtCode.SyntaxWords.fComment = new SyntaxTextBox.SyntaxFormat(Color.Green);
			txtCode.SyntaxWords.fNumbers = new SyntaxTextBox.SyntaxFormat(Color.DarkBlue, true);

			timRun.SynchronizingObject = this;
			timReal.SynchronizingObject= this;
		}

		private void miExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void miSelectAll_Click(object sender, EventArgs e)
		{
			this.txtCode.SelectAll();
		}

		private void miCut_Click(object sender, EventArgs e)
		{
			this.txtCode.Cut();
		}

		private void miPaste_Click(object sender, EventArgs e)
		{
			this.txtCode.Paste();
		}

		private void miDelete_Click(object sender, EventArgs e)
		{
			this.txtCode.Delete();
		}        

		private void Stop()
		{
			AM.noNextStep = true;

			timReal.Stop();
			timRun.Stop();

			stopToolStripButton.Enabled = false;
			runToolStripButton.Visible = true;
			breakToolStripButton.Visible = false;
			stepToolStripButton.Enabled = true;
		}        

		private void Step()
		{
			if (AM.noNextStep) AM.Reset();
			stopToolStripButton.Enabled = true;

			// AM.regs = lstRegisters.Regs;
			lstRegisters.Regs = AM.regs;
			AM.Parse(txtCode.Text);
			AM.Step();

			UpdateSimulation();
		}

		private void Break()
		{
			if (timRun.Enabled)
			{
				timRun.Stop();

				runToolStripButton.Visible = true;
				breakToolStripButton.Visible = false;
			}
		}

		private void Run()
		{
			if (timRun.Enabled)
			{
				timRun.Stop();

				runToolStripButton.Visible = true;
				breakToolStripButton.Visible = false;
			}
			else
			{
				AM.Reset();
				stopToolStripButton.Enabled = true;
				runToolStripButton.Visible = false;
				breakToolStripButton.Visible = true;

				if (delay == 0)
				{
					timRun.Stop();
					timReal.Interval = 1;
					timReal.Elapsed += new System.Timers.ElapsedEventHandler(timReal_Elapsed);
					timReal.Start();
				}
				else
				{
					timReal.Stop();
					lstRegisters.Regs = AM.regs;
					timRun.Interval = delay;
					timRun.Elapsed += new System.Timers.ElapsedEventHandler(timRun_Elapsed);
					timRun.Start();
				}
			}
		}

		void timRun_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			AM.Step();
			UpdateSimulation();

			if (AM.noNextStep)
			{
				timRun.Stop();
				runToolStripButton.Visible = true;
				breakToolStripButton.Visible = false;
				stopToolStripButton.Enabled = false;
				stepToolStripButton.Enabled = true;
			}
		}

		void timReal_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			AM.Run();
			UpdateSimulation();

			if (AM.noNextStep)
			{
				timReal.Stop();
				runToolStripButton.Visible = true;
				breakToolStripButton.Visible = false;
				stopToolStripButton.Enabled = false;
				stepToolStripButton.Enabled = true;
			}
		}        

		private void UpdateSimulation()
		{
			verticalScroll.Value = Math.Min(Math.Max((AM.prgPointer * 70 / pSimulation.Width) * 50 - pSimulation.Height / 2, 0), verticalScroll.Maximum);

			pSimulation.Refresh();

			if (AM.prgPointer < AM.program.Count)
			{
				if (AM.program[AM.prgPointer].operation == AMOperation.Add || AM.program[AM.prgPointer].operation == AMOperation.Sub)
				{
					lstRegisters.Writing = true;
					lstRegisters.Reading = false;
					lstRegisters.WritingPos = AM.program[AM.prgPointer].register;
				}
				else if (AM.program[AM.prgPointer].operation == AMOperation.CycleEnd)
				{
					lstRegisters.Writing = false;
					lstRegisters.Reading = true;
					lstRegisters.ReadingPos = AM.program[AM.program[AM.prgPointer].register].register;
				}
			}
			lstRegisters.Refresh();
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

		private void miAbout_Click(object sender, EventArgs e)
		{
			AboutForm frm = new AboutForm();
			frm.ShowDialog(this);
		}

		private void pSimulation_Paint(object sender, PaintEventArgs e)
		{
			DrawSimulation(e.Graphics);
		}

		private void DrawSimulation(Graphics g)
		{            
			Rectangle rect;
			int y = (pSimulation.Height - 40) / 2;
			int x = 0;
			string txt="";
			string txt2 = "";
			Font fnt = new Font("Arial", 11, FontStyle.Regular);
			Font fnt2 = new Font("Arial", 9, FontStyle.Regular);
			StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
			StringFormat sf2 = new StringFormat();
				sf2.Alignment = StringAlignment.Far;
				sf2.LineAlignment = StringAlignment.Center;
			Color bgColor = Color.White;

			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

			Rectangle panelBounds = new Rectangle(0, 0, pSimulation.Width, pSimulation.Height);
			y = -verticalScroll.Value;
			for (int i = 0; i < AM.program.Count;i++)
			{               
				rect = new Rectangle(x, y, 60, 40);

				if (panelBounds.IntersectsWith(rect))
				{

					//Typ operácie
					switch (AM.program[i].operation)
					{
						case AMOperation.Add:
							txt = "add";
							txt2 = AM.program[i].register.ToString();
							bgColor = Color.FromArgb(60, Color.Green);
							break;
						case AMOperation.Sub:
							txt = "sub";
							txt2 = AM.program[i].register.ToString();
							bgColor = Color.FromArgb(60, Color.Red);
							break;
						case AMOperation.CycleStart:
							txt = "(";
							txt2 = "";
							bgColor = Color.FromArgb(60, Color.White);
							break;
						case AMOperation.CycleEnd:
							txt = ")";
							txt2 = AM.program[AM.program[i].register].register.ToString();
							bgColor = Color.FromArgb(60, Color.White);
							break;
					}                    

					if (AM.prgPointer == i)
					{
						Functions.FillRoundRectangle(g, new LinearGradientBrush(rect, Color.LightBlue, Color.DarkBlue, LinearGradientMode.Vertical), rect, 5);
						Functions.DrawRoundRectangle(g, new Pen(Color.Black, 3), rect, 5);

						rect.Inflate(-4, 0); rect.Offset(2, 0);
						g.DrawString(txt, fnt, Brushes.White, rect, sf);
						g.DrawString(txt2, fnt2, Brushes.White, new Rectangle(rect.X, rect.Y + 5, rect.Width, rect.Height), sf2);
					}
					else
					{
						Functions.FillRoundRectangle(g, new SolidBrush(bgColor), rect, 5);
						Functions.DrawRoundRectangle(g, Pens.Black, rect, 5);

						rect.Inflate(-4, 0); rect.Offset(2, 0);
						g.DrawString(txt, fnt, Brushes.Black, rect, sf);
						g.DrawString(txt2, fnt2, Brushes.Black, new Rectangle(rect.X, rect.Y + 5, rect.Width, rect.Height), sf2);
					}                    
				}

				x += 70;
				if (x + 70 > pSimulation.Width)
				{
					x = 0;
					y += 50;
				}
			}
		}

		private void SetScrollbar()
		{
			verticalScroll.Maximum = (AM.program.Count * 70 / pSimulation.Width) * 50;
			verticalScroll.LargeChange = pSimulation.Width;
		}

		private void pSimulation_Resize(object sender, EventArgs e)
		{
			SetScrollbar();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabSimulation)
			{                
				SetScrollbar();
			}
		}
		
		private void tbSpeed_Scroll(object sender, EventArgs e)
		{
			delay = (int)Math.Round(1000 - Math.Pow((double)tbSpeed.Value / tbSpeed.Maximum, 2) * 1000);
			if (delay!=0)
				timRun.Interval = delay;
			else
				timRun.Interval = 1;
		}

		private void miAddValue_Click(object sender, EventArgs e)
		{
			Dialogs.AddValueForm dlg = new AbacusMachine.Dialogs.AddValueForm();
			dlg.ShowDialog(this);

			if (dlg.OKPressed)
			{
				string res = "";
				string cmd = "";                
				cmd += "a" + dlg.RegIndex.ToString().Trim();
				for (int a = 0; a < dlg.Value; a++)
				{
					res += cmd;
				}
				res = "//R" + dlg.RegIndex.ToString() + " = R" + dlg.RegIndex.ToString() + " + " + dlg.Value.ToString()
					+ Environment.NewLine
					+ res;

				res += Environment.NewLine;
				
				txtCode.SelectedText = res;
				txtCode.UpdateHighlight();
			}
		}

		private void miSubstractValue_Click(object sender, EventArgs e)
		{
			Dialogs.SubstractValueForm dlg = new AbacusMachine.Dialogs.SubstractValueForm();
			dlg.ShowDialog(this);

			if (dlg.OKPressed)
			{
				string res = "";
				string cmd = "";                
				cmd += "s" + dlg.RegIndex.ToString().Trim();
				for (int a = 0; a < dlg.Value; a++)
				{
					res += cmd;
				}
				res = "//R" + dlg.RegIndex.ToString() + " = R" + dlg.RegIndex.ToString() + " - " + dlg.Value.ToString()
					+ Environment.NewLine
					+ res;

				res += Environment.NewLine;

				txtCode.SelectedText = res;
				txtCode.UpdateHighlight();
			}
		}

		private void miCopyRegister_Click(object sender, EventArgs e)
		{
			Dialogs.CopyForm dlg = new AbacusMachine.Dialogs.CopyForm();
			dlg.ShowDialog(this);

			if (dlg.OKPressed)
			{                
				//Skompilovanie
				AM.Parse(txtCode.Text);

				string regSrc = dlg.SrcRegIndex.ToString().Trim();
				string regDst = dlg.DstRegIndex.ToString().Trim();
				string regTmp = AM.GetFirstUnusedRegister(dlg.SrcRegIndex, dlg.DstRegIndex).ToString().Trim();
				string cmd = "";
				cmd += "//Kopírovanie registra R" + regSrc + " do registra " + regDst
					+ " (cez pomocný register R" + regTmp + ")";
				cmd += Environment.NewLine;
				cmd += "(s" + regSrc + "a" + regDst + "a" + regTmp + ")" + regSrc
							   + " (s" + regTmp + "a" + regSrc + ")" + regTmp;
				cmd += Environment.NewLine;

				txtCode.SelectedText = cmd;
				txtCode.Text = "//#" + regTmp + " pomocný register" 
					+ Environment.NewLine 
					+ txtCode.Text;
				txtCode.UpdateHighlight();
			}
		}

		private void miMoveRegister_Click(object sender, EventArgs e)
		{
			Dialogs.MoveForm dlg = new AbacusMachine.Dialogs.MoveForm();
			dlg.ShowDialog(this);

			if (dlg.OKPressed)
			{
				string regSrc = dlg.SrcRegIndex.ToString().Trim();
				string regDst = dlg.DstRegIndex.ToString().Trim();
				string cmd = "";
				cmd += "//Presunie register R" + regSrc + " do registra " + regDst;
				cmd += Environment.NewLine;
				cmd += "(s" + regSrc + "a" + regDst + ")" + regSrc;
				cmd += Environment.NewLine;

				txtCode.SelectedText = cmd;
				txtCode.UpdateHighlight();
			}
		}

		private void miClearRegister_Click(object sender, EventArgs e)
		{
			Dialogs.ClearForm dlg = new AbacusMachine.Dialogs.ClearForm();
			dlg.ShowDialog(this);

			if (dlg.OKPressed)
			{
				string reg = dlg.RegIndex.ToString().Trim();
				string cmd = "";
				cmd += "//Zmazanie registra R" + reg;
				cmd += Environment.NewLine;
				cmd += "(s" + reg + ")" + reg;
				cmd += Environment.NewLine;

				txtCode.SelectedText = cmd;
				txtCode.UpdateHighlight();
			}
		}

		private void txtCode_TextChanged(object sender, System.EventArgs e)
		{
			AM.Parse(txtCode.Text);
		}

		private void miNewFile_Click(object sender, EventArgs e)
		{
			File_New();
		}

		private void miOpenFile_Click(object sender, EventArgs e)
		{
			File_Open();
		}

		private void miSaveFile_Click(object sender, EventArgs e)
		{
			File_Save();
		}

		private void miSaveAsFile_Click(object sender, EventArgs e)
		{
			File_SaveAs();
		}

		private void miCopy_Click(object sender, EventArgs e)
		{
			txtCode.Copy();
		}

		private string OpenTextFile(string FileName)
		{
			string functionReturnValue = System.IO.File.ReadAllText(FileName, Encoding.Default);
			return functionReturnValue;
		}

		private void SaveTextFile(string FileName, string Text)
		{
			System.IO.TextWriter f = System.IO.File.CreateText(FileName);
			f.Write(Text);
			f.Close();
		}

		private void File_New()
		{
			AbacusMachineForm frm = new AbacusMachineForm();
			frm.Show();
		}

		private void File_Open() {
			if (MdiParent == null) {
				OpenFileOK = false;
				openFileDialog1.Title = "Otvoriť súbor";
				openFileDialog1.AddExtension = true;
				openFileDialog1.DefaultExt = "ram";
				openFileDialog1.Filter = "Súbor počítadlového stroja (*.am)|*.am|Textový súbor (*.txt)|*.txt|Všetky súbory|*.*";
				openFileDialog1.ShowDialog(this);
				if (OpenFileOK && this.openFileDialog1.FileName != "") {
					AbacusMachineForm abacusMachineForm = new AbacusMachineForm();
					abacusMachineForm.Show();
					abacusMachineForm.File_Open(this.openFileDialog1.FileName);
					abacusMachineForm.Activate();
					return;
				}
			} else {
				((IMainForm)MdiParent).OpenFile();
			}
		}

		public void File_Open(string filename)
		{
			this.openFileName = filename;
			txtCode.Text = OpenTextFile(filename);

			this.Text = System.IO.Path.GetFileName(filename)+ " - " + AppTitle;            
		}

		private void File_Save()
		{
			if (openFileName == null)
				File_SaveAs();
			else
			{
				SaveTextFile(openFileName, txtCode.Text);
			}
		}

		private void File_SaveAs()
		{
			SaveFileOK = false;
			saveFileDialog1.Title = "Uložiť súbor";
			saveFileDialog1.AddExtension = true;
			saveFileDialog1.DefaultExt = "am";
			saveFileDialog1.Filter = "Súbor počítadlového stroja|*.am|Všetky súbory|*.*";
			saveFileDialog1.ShowDialog(this);

			if (SaveFileOK && saveFileDialog1.FileName != "")
			{
				openFileName = saveFileDialog1.FileName;
				SaveTextFile(saveFileDialog1.FileName, txtCode.Text);
			}
		}

		private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			OpenFileOK = true;
		}

		private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
		{
			SaveFileOK = true;
		}

		private void lstRegisters_RegisterChanged(object sender, RegisterList.RegisterEventArgs arg)
		{
			string[] lines = txtCode.Text.Split('\n');
			string regDef = "//#" + arg.index;
			StringBuilder sb = new StringBuilder(txtCode.Text.Length + 100);
			bool added = false;

			foreach (string line in lines)
			{
				if (line.Trim().StartsWith(regDef))
				{
					sb.AppendLine("//#" + arg.index + " " + arg.register.Name + " = " + arg.register.Value);
					added = false;
				}
				else
				{
					sb.AppendLine(line);
				}
			}

			if (!added)
			{
				sb.Insert(0, "//#" + arg.index + " " + arg.register.Name + " = " + arg.register.Value + "\n");
			}

			AM.regs.regs[new InfiniteInteger(arg.index)].Value = arg.register.Value;
			txtCode.Text = sb.ToString();
		}

		private void resetToolStripMenuItem_Click(object sender, EventArgs e)
		{
			lstRegisters.Regs.ClearValues();
			lstRegisters.Invalidate();
		}

		private void verticalScroll_Scroll(object sender, ScrollEventArgs e)
		{
			pSimulation.Invalidate();
		}

		private void verticalScroll_ValueChanged(object sender, EventArgs e)
		{
			pSimulation.Invalidate();
		}

		private void AbacusMachineForm_Load(object sender, EventArgs e)
		{
			if (MdiParent != null) menuStrip1.Visible = false;
			this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon")));
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
			File_Save();
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
			Step();
		}

		private void miPause_Click(object sender, EventArgs e)
		{
			Break();
		}

		private void miRun_Click(object sender, EventArgs e)
		{
			Run();
		}

		private void miStep_Click(object sender, EventArgs e)
		{
			Step();
		}

		private void miStop_Click(object sender, EventArgs e)
		{
			Stop();
		}


	}
}