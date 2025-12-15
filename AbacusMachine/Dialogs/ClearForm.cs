using DusanRodina.SimStudio.Components;
using System;
using System.Windows.Forms;

namespace DusanRodina.AbacusMachine.Dialogs {
	public partial class ClearForm : Form
    {
        public bool OKPressed = false;
        public int regIndex = 0;        

        public ClearForm()
        {
            InitializeComponent();
        }

        public int RegIndex
        {
            get { return regIndex; }
            set { regIndex = value; }
        }        

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            OKPressed = true;

            RegIndex = Functions.ToValue(txtRegIndex.Text);            

            this.Close();
        }
    }
}