using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Dialogs {
	public partial class ClearForm : Form
    {
        public bool okPressed;
        public int regIndex;        

        public ClearForm()
        {
            InitializeComponent();
        }

        public int RegIndex
        {
            get => regIndex;
            set => regIndex = value;
        }        

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            okPressed = true;

            RegIndex = Functions.ToValue(txtRegIndex.Text);            

            this.Close();
        }
    }
}