using System;
using System.Windows.Forms;

namespace FEI.SimStudio.Components.Controls.RegisterList {
	public partial class RegisterEditForm : Form
    {
        public string regName = "";
        public string regValue = "0";        

        public RegisterEditForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            regName = nameText.Text;
            regValue = valueText.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterEditForm_Load(object sender, EventArgs e)
        {
            nameText.Text = regName;
            valueText.Text = regValue;
        }
    }
}
