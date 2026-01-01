using DusanRodina.TuringCore.Simulation;
using System;
using System.Windows.Forms;

namespace DusanRodina.FiniteAutomaton.Dialogs {
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

            tfunction = new Transition(
                    cmbCurrentState.Text, txtReadSymbol.Text, cmbNewState.Text, txtReadSymbol.Text, Transition.Steps.Right);
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

            string[] states = TM.GetUsedStates();
            cmbCurrentState.Items.AddRange(states);
            cmbNewState.Items.AddRange(states);            
        }
    }
}