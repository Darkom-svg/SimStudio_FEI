using DusanRodina.TuringCore.Simulation;
using System;
using System.Windows.Forms;

namespace DusanRodina.TuringMachineSimulator.Dialogs {
	public partial class AddTFunctionForm : Form
    {
        public VirtualTuringMachine TM;
        public Transition tfunction;        
        public bool OKPressed = false;        

        public AddTFunctionForm()
        {
            InitializeComponent();            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            OKPressed = true;

            Transition.Steps step= Transition.Steps.NoMove;
            switch (cmbStep.SelectedIndex) {
                case 0:
                    step = Transition.Steps.Left;
                    break;
                case 1:
                    step = Transition.Steps.Right;
                    break;
                case 2:
                    step = Transition.Steps.NoMove;
                    break;
            }

            tfunction = new Transition(
                    cmbCurrentState.Text, txtReadSymbol.Text, cmbNewState.Text, txtWriteSymbol.Text, step);
            tfunction.Comment = this.txtComment.Text;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddTFunction_Load(object sender, EventArgs e)
        {
            cmbCurrentState.Text = tfunction.CurrentState;
            cmbNewState.Text = tfunction.NewState;
            txtReadSymbol.Text = tfunction.ReadSymbol;
            txtWriteSymbol.Text = tfunction.WriteSymbol;

            string[] states = TM.GetUsedStates();
            cmbCurrentState.Items.AddRange(states);
            cmbNewState.Items.AddRange(states);
            cmbStep.SelectedIndex = 0;
        }
    }
}