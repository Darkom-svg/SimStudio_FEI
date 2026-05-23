using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Dialogs {
	public partial class MoveForm : Form
    {
        public bool okPressed;
        public int srcRegIndex;
        public int dstRegIndex;

        public MoveForm()
        {
            InitializeComponent();
        }

        public int SrcRegIndex
        {
            get => srcRegIndex;
            set => srcRegIndex = value;
        }

        public int DstRegIndex
        {
            get => dstRegIndex;
            set => dstRegIndex = value;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            okPressed = true;

            SrcRegIndex = Functions.ToValue(txtSrcRegister.Text);
            DstRegIndex = Functions.ToValue(txtDstRegister.Text);

            this.Close();
        }
    }
}