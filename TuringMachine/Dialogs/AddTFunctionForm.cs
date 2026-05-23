using System;
using System.Windows.Forms;
using FEI.TuringCore.Simulation;

namespace FEI.TuringMachineSimulator.Dialogs {
	public partial class AddTFunctionForm : Form
    {
        public VirtualTuringMachine TM;
        public Transition tFunction;        
        public bool OKPressed;        

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

            tFunction = new Transition(
                    cmbCurrentState.Text, txtReadSymbol.Text, cmbNewState.Text, txtWriteSymbol.Text, step);
            tFunction.Comment = this.txtComment.Text;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddTFunction_Load(object sender, EventArgs e)
        {
            cmbCurrentState.Text = tFunction.CurrentState;
            cmbNewState.Text = tFunction.NewState;
            txtReadSymbol.Text = tFunction.ReadSymbol;
            txtWriteSymbol.Text = tFunction.WriteSymbol;

            string[] states = TM.GetUsedStates();
            cmbCurrentState.Items.AddRange(states);
            cmbNewState.Items.AddRange(states);
            cmbStep.SelectedIndex = 0;
        }
    }
}