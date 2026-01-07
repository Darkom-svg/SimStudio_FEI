using DusanRodina.AbacusMachine;
using DusanRodina.FiniteAutomaton;
using DusanRodina.PushdownAutomaton;
using DusanRodina.RandomAccessMachine;
using DusanRodina.SimStudio.Components;
using DusanRodina.TuringMachineSimulator;
using static DusanRodina.SimStudio.AppColors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using DusanRodina.TrainingSimulator;

namespace DusanRodina.SimStudio {
	public partial class MainForm : Form, IMainForm {
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SimulatorsForm frm = new SimulatorsForm();
			frm.MdiParent = this;
			frm.WindowState = FormWindowState.Maximized;
			frm.Show();            
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutForm frm = new AboutForm();            
			frm.ShowDialog();
		}

		private void finiteAutomatonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FiniteAutomaton.FiniteAutomatonForm frm = new DusanRodina.FiniteAutomaton.FiniteAutomatonForm();
			frm.MdiParent = this;
			frm.Show();
		}     

		private void turingMachineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TuringMachineSimulator.TuringMachineForm frm = new DusanRodina.TuringMachineSimulator.TuringMachineForm();
			frm.MdiParent = this;
			frm.Show();
		}

		private void ramToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RandomAccessMachine.RAMSimulatorForm frm = new DusanRodina.RandomAccessMachine.RAMSimulatorForm();
			frm.MdiParent = this;
			frm.Show();
		}

		private void abacusMachineToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AbacusMachine.AbacusMachineForm frm = new DusanRodina.AbacusMachine.AbacusMachineForm();
			frm.MdiParent = this;
			frm.Show();            
		}

		private void MainForm_MdiChildActivate(object sender, EventArgs e)
		{
			if (ActiveMdiChild != null)
			{
				List<Control> controls = new List<Control>(ActiveMdiChild.Controls.Find("mainToolStrip", true));
				if (controls.Count > 0)
				{
					(controls[0] as ToolStrip).Visible = false;
					ToolStripManager.RevertMerge(mainToolStrip);
					ToolStripManager.Merge(controls[0] as ToolStrip, mainToolStrip);
				}
				
				ToolStripManager.RevertMerge(statusStrip);
				var statusStrips = ActiveMdiChild.Controls.Find("statusStrip", true);
				if (statusStrips.Length > 0 && statusStrips[0] is StatusStrip childStatusStrip)
				{
					childStatusStrip.Visible = false;
					ToolStripManager.Merge(childStatusStrip, statusStrip);
				}
				
			}
		}

		private void simulatorsToolStripMenuItem_Paint(object sender, PaintEventArgs e)
		{            
			Rectangle bounds = new Rectangle(0, 0, simulatorsToolStripMenuItem.Size.Width - 1, simulatorsToolStripMenuItem.Height - 1);

			if (simulatorsToolStripMenuItem.Selected)
			{
				e.Graphics.FillRectangle(new LinearGradientBrush(bounds, Color.White, Color.LightSteelBlue, LinearGradientMode.Vertical), bounds);
				e.Graphics.DrawRectangle(Pens.LightSteelBlue, bounds);
				e.Graphics.DrawString(simulatorsToolStripMenuItem.Text, simulatorsToolStripMenuItem.Font, Brushes.Black, bounds, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
			}
			else
			{
				e.Graphics.FillRectangle(new LinearGradientBrush(bounds, Color.LightSteelBlue, AppColors.PrimaryBlue, LinearGradientMode.Vertical), bounds);
				using (var pen = new Pen(AppColors.PrimaryBlue))
				{
					e.Graphics.DrawRectangle(pen, bounds);
				}
				e.Graphics.DrawString(simulatorsToolStripMenuItem.Text, simulatorsToolStripMenuItem.Font, Brushes.White, bounds, new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center });
			}
		}

		private void pushdownAutomatonToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PushdownAutomaton.PushdownAutomatonForm frm = new DusanRodina.PushdownAutomaton.PushdownAutomatonForm();
			frm.MdiParent = this;
			frm.Show();
		}

		public void OpenFile() {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Otvoriť";
			openFileDialog.Filter = "Všetky súbory simulátorov|*.fa;*.pa;*.tm;*.ram;*.am;*.jff|Súbor konečného automatu|*.fa|Súbor zásobníkového automatu|*.pa|Súbor Turingovho stroja|*.tm|Súbor RAM|*.ram|Súbor počítadlového stroja (*.am)|*.am|JFlap súbor|*.jff|Textový súbor (*.txt)|*.txt|Všetky súbory|*.*";
			if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
				string fileName = openFileDialog.FileName;
				MachineType machineType = MachineType.None;
				if (fileName.EndsWith(".jff")) {
					machineType = this.ResolveMachineType(fileName);
				}
				if (fileName.EndsWith(".fa") || machineType == MachineType.FiniteAutomaton) {
					FiniteAutomatonForm finiteAutomatonForm = new FiniteAutomatonForm();
					finiteAutomatonForm.MdiParent = this;
					finiteAutomatonForm.Show();
					finiteAutomatonForm.OpenFile(fileName);
					finiteAutomatonForm.Activate();
					return;
				}
				if (fileName.EndsWith(".pa") || machineType == MachineType.PushdownAutomaton) {
					PushdownAutomatonForm pushdownAutomatonForm = new PushdownAutomatonForm();
					pushdownAutomatonForm.MdiParent = this;
					pushdownAutomatonForm.Show();
					pushdownAutomatonForm.OpenFile(fileName);
					pushdownAutomatonForm.Activate();
					return;
				}
				if (fileName.EndsWith(".tm") || machineType == MachineType.TuringMachine) {
					TuringMachineForm turingMachineForm = new TuringMachineForm();
					turingMachineForm.MdiParent = this;
					turingMachineForm.Show();
					turingMachineForm.OpenFile(fileName);
					turingMachineForm.Activate();
					return;
				}
				if (fileName.EndsWith(".ram") || fileName.EndsWith(".txt")) {
					RAMSimulatorForm rAMSimulatorForm = new RAMSimulatorForm();
					rAMSimulatorForm.MdiParent = this;
					rAMSimulatorForm.Show();
					rAMSimulatorForm.File_Open(fileName);
					rAMSimulatorForm.Activate();
					return;
				}
				if (fileName.EndsWith(".am")) {
					AbacusMachineForm abacusMachineForm = new AbacusMachineForm();
					abacusMachineForm.MdiParent = this;
					abacusMachineForm.Show();
					abacusMachineForm.File_Open(fileName);
					abacusMachineForm.Activate();
				}
			}
		}

		private MachineType ResolveMachineType(string fileName) {
			MachineType result;
			try {
				using (XmlTextReader xmlTextReader = new XmlTextReader(fileName)) {
					while (xmlTextReader.Read()) {
						if (xmlTextReader.NodeType == XmlNodeType.Element) {
							if (xmlTextReader.Name.ToLower() != "structure") {
								xmlTextReader.Close();
								result = MachineType.None;
								return result;
							}
							break;
						}
					}
					string text = "";
					while (xmlTextReader.Read()) {
						XmlNodeType nodeType = xmlTextReader.NodeType;
						switch (nodeType) {
							case XmlNodeType.Element: {
									text = text + "." + xmlTextReader.Name.ToLower().Trim();
									bool flag = false;
									if (xmlTextReader.IsEmptyElement | flag) {
										text = text.Substring(0, text.LastIndexOf('.'));
									}
									break;
								}
							case XmlNodeType.Attribute:
								break;
							case XmlNodeType.Text:
								if (text.StartsWith(".")) {
									string text2 = text.Substring(1);
									string a;
									string a2;
									if ((a = text2) != null && a == "type" && (a2 = xmlTextReader.Value.Trim()) != null) {
										if (a2 == "fa") {
											result = MachineType.FiniteAutomaton;
											return result;
										}
										if (a2 == "pda") {
											result = MachineType.PushdownAutomaton;
											return result;
										}
										if (a2 == "turing") {
											result = MachineType.TuringMachine;
											return result;
										}
									}
								}
								break;
							default:
								if (nodeType == XmlNodeType.EndElement) {
									if (text.EndsWith("." + xmlTextReader.Name.ToLower().Trim())) {
										text = text.Substring(0, text.LastIndexOf('.'));
									}
								}
								break;
						}
					}
				}
				result = MachineType.None;
			} catch (Exception) {
				result = MachineType.None;
			}
			return result;
		}

		private void openToolStripButton_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void openFileToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void trianerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TrainingSimulator.MainTrainingForm frm = new DusanRodina.TrainingSimulator.MainTrainingForm();
			frm.MdiParent = this;
			frm.Show();
		}
	}
}
