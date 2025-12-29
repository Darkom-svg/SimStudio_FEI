using System;
using System.Windows.Forms;
using System.Drawing;

namespace DusanRodina.SimStudio {
	public partial class SimulatorsForm : Form
    {
        public SimulatorsForm()
        {
            InitializeComponent();
        }

        private void bTuring_Click(object sender, EventArgs e)
        {
            TuringMachineSimulator.TuringMachineForm frm = new TuringMachineSimulator.TuringMachineForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void bRAM_Click(object sender, EventArgs e)
        {
            RandomAccessMachine.RAMSimulatorForm frm = new RandomAccessMachine.RAMSimulatorForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void bAbacusMachine_Click(object sender, EventArgs e)
        {
            AbacusMachine.AbacusMachineForm frm = new AbacusMachine.AbacusMachineForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        private void bTrainer_Click(object sender, EventArgs e)
        {
            return;
        }

        private void oProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog(this);
        }

        private void miNewTM_Click(object sender, EventArgs e)
        {
            TuringMachineSimulator.TuringMachineForm frm = new TuringMachineSimulator.TuringMachineForm();
            frm.Show();
        }

        private void miNewRAM_Click(object sender, EventArgs e)
        {
            RandomAccessMachine.RAMSimulatorForm frm = new RandomAccessMachine.RAMSimulatorForm();
            frm.Show();
        }

        private void miNewAM_Click(object sender, EventArgs e)
        {
            AbacusMachine.AbacusMachineForm frm = new AbacusMachine.AbacusMachineForm();
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
            FiniteAutomaton.FiniteAutomatonForm frm = new DusanRodina.FiniteAutomaton.FiniteAutomatonForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void pushDownAutomatonButton2_Click(object sender, EventArgs e)
        {
            PushdownAutomaton.PushdownAutomatonForm frm = new DusanRodina.PushdownAutomaton.PushdownAutomatonForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
    }
}