using System;
using System.Windows.Forms;
using FEI.AbacusMachine;
using FEI.FiniteAutomaton;
using FEI.PushdownAutomaton;
using FEI.RandomAccessMachine;
using FEI.TrainingSimulator;
using FEI.TuringMachineSimulator;

namespace FEI.SimStudio {
	public partial class SimulatorsForm : Form
    {
        public SimulatorsForm()
        {
            InitializeComponent();
            flowLayoutPanel1.Resize += flowLayoutPanel_Resize;
            ResizeSimulatorCards();
        }

        private void bTuring_Click(object sender, EventArgs e)
        {
            TuringMachineForm frm = new TuringMachineForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void bRAM_Click(object sender, EventArgs e)
        {
            RamSimulatorForm frm = new RamSimulatorForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void bAbacusMachine_Click(object sender, EventArgs e)
        {
            AbacusMachineForm frm = new AbacusMachineForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        private void bTrainer_Click(object sender, EventArgs e)
        {
            MainTrainingForm frm = new MainTrainingForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void oProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog(this);
        }

        private void miNewTM_Click(object sender, EventArgs e)
        {
            TuringMachineForm frm = new TuringMachineForm();
            frm.Show();
        }

        private void miNewRAM_Click(object sender, EventArgs e)
        {
            RamSimulatorForm frm = new RamSimulatorForm();
            frm.Show();
        }

        private void miNewAM_Click(object sender, EventArgs e)
        {
            AbacusMachineForm frm = new AbacusMachineForm();
            frm.Show();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void SimulatorsForm_Load(object sender, EventArgs e)
        {
            this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon"))); 
        }

        private void finiteAutomatonButton_Click(object sender, EventArgs e)
        {
            FiniteAutomatonForm frm = new FiniteAutomatonForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void pushDownAutomatonButton2_Click(object sender, EventArgs e)
        {
            PushdownAutomatonForm frm = new PushdownAutomatonForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        
        private void bExample_Click(object sender, EventArgs e)
        {
            ExamplesForm frm = new ExamplesForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        
        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            ResizeSimulatorCards();
        }

        private void ResizeSimulatorCards()
        {
            if (flowLayoutPanel1 == null)
                return;

            int width = flowLayoutPanel1.ClientSize.Width
                        - flowLayoutPanel1.Padding.Left
                        - flowLayoutPanel1.Padding.Right
                        - 10;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is RoundedPanel panel)
                {
                    panel.AutoSize = false;
                    panel.Width = Math.Max(250, width);
                }
            }
        }
    }
}