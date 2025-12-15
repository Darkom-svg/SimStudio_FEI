using System;
using System.Windows.Forms;

namespace DusanRodina.AbacusMachine {
	public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}