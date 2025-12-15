using DusanRodina.SimStudio.Components;
using System;
using System.Windows.Forms;

namespace DusanRodina.AbacusMachine.Dialogs {
	public partial class AddValueForm : Form
    {
        public bool OKPressed = false;
        public int regIndex = 0;
        public int value = 0;

        public AddValueForm()
        {
            InitializeComponent();
        }

        public int RegIndex
        {
            get { return regIndex; }
            set { regIndex = value; }
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            OKPressed = true;

            RegIndex = Functions.ToValue(txtRegIndex.Text);
            Value = Functions.ToValue(txtValue.Text);

            this.Close();
        }
    }
}