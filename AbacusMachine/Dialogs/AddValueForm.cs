using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Dialogs {
	public partial class AddValueForm : Form
    {
        public bool okPressed;
        private int regIndex;
        private int value;

        public AddValueForm()
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