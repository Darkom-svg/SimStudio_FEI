using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Dialogs {
	public partial class MoveForm : Form
    {
        public bool OKPressed = false;
        public int srcRegIndex = 0;
        public int dstRegIndex = 0;

        public MoveForm()
        {
            InitializeComponent();
        }

        public int SrcRegIndex
        {
            get { return srcRegIndex; }
            set { srcRegIndex = value; }
        }

        public int DstRegIndex
        {
            get { return dstRegIndex; }
            set { dstRegIndex = value; }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            OKPressed = true;

            SrcRegIndex = Functions.ToValue(txtSrcRegister.Text);
            DstRegIndex = Functions.ToValue(txtDstRegister.Text);

            this.Close();
        }
    }
}