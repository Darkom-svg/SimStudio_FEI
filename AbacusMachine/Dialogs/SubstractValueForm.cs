using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Dialogs {
	public partial class SubstractValueForm : Form
    {
        public bool okPressed;
        public int regIndex;
        public int value;

        public SubstractValueForm()
        {
            InitializeComponent();
        }

        public int RegIndex
        {
            get => regIndex;
            set => regIndex = value;
        }

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        private void frmSubstractValue_Load(object sender, EventArgs e)
        {

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            okPressed = true;

            RegIndex = Functions.ToValue(txtRegIndex.Text);
            Value = Functions.ToValue(txtValue.Text);

            this.Close();
        }
    }
}