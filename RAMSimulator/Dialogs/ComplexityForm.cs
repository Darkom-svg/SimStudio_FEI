using DusanRodina.RandomAccessMachine.Simulation;
using System;
using System.Windows.Forms;

namespace DusanRodina.RandomAccessMachine.Dialogs {
	public partial class ComplexityForm : Form
    {
        public Simulator RAMSim;

        public ComplexityForm()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmComplexity_Load(object sender, EventArgs e)
        {
            RefreshValues();
        }

        public void RefreshValues()
        {
            this.txtTimeUniform.Text = RAMSim.timeUniCounter.ToString();
            this.txtTimeLogarithmic.Text = RAMSim.timeLogCounter.ToString();

            this.txtSpaceUniform.Text = RAMSim.spaceUniCounter.ToString();
            this.txtSpaceLogarithmic.Text = RAMSim.spaceLogCounter.ToString();

            this.txtAdd.Text = RAMSim.instructionCounter[(int)InstructionType.Add].ToString();
            this.txtSub.Text = RAMSim.instructionCounter[(int)InstructionType.Subs].ToString();
            this.txtMult.Text = RAMSim.instructionCounter[(int)InstructionType.Mult].ToString();
            this.txtDiv.Text = RAMSim.instructionCounter[(int)InstructionType.Div].ToString();

            this.txtLoad.Text = RAMSim.instructionCounter[(int)InstructionType.Load].ToString();
            this.txtStore.Text = RAMSim.instructionCounter[(int)InstructionType.Store].ToString();
            this.txtRead.Text = RAMSim.instructionCounter[(int)InstructionType.Read].ToString();
            this.txtWrite.Text = RAMSim.instructionCounter[(int)InstructionType.Write].ToString();

            this.txtJump.Text = RAMSim.instructionCounter[(int)InstructionType.Jump].ToString();
            this.txtJZero.Text = RAMSim.instructionCounter[(int)InstructionType.JZero].ToString();
            this.txtJGZero.Text = RAMSim.instructionCounter[(int)InstructionType.JGZero].ToString();

            this.txtHalt.Text = RAMSim.instructionCounter[(int)InstructionType.Halt].ToString();
            this.txtAccept.Text = RAMSim.instructionCounter[(int)InstructionType.Accept].ToString();
            this.txtReject.Text = RAMSim.instructionCounter[(int)InstructionType.Reject].ToString();
        }

    }
}