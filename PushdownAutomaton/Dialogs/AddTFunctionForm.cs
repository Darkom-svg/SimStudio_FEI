using System;
using System.Windows.Forms;
using FEI.TuringCore.Simulation;

namespace FEI.PushdownAutomaton.Dialogs {
	public partial class AddTFunctionForm : Form
    {
        public VirtualTuringMachine tm;
        public Transition tFunction;        
        public bool okPressed;        

        public AddTFunctionForm()
        {
            InitializeComponent();            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            okPressed = true;            

            tFunction = new Transition(
                    cmbCurrentState.Text, txtReadSymbol.Text, cmbNewState.Text, txtReadSymbol.Text, Transition.Steps.Right);
            
            tFunction.StackRead = readStackTextBox.Text;
            tFunction.StackWrite = writeStackTextBox.Text;

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

            readStackTextBox.Text = tFunction.StackRead;
            writeStackTextBox.Text = tFunction.StackWrite;

            string[] states = tm.GetUsedStates();
            cmbCurrentState.Items.AddRange(states);
            cmbNewState.Items.AddRange(states);            
        }
    }
}