using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DusanRodina.TuringMachineSimulator.Dialogs {
	public partial class SettingsForm : Form
    {
        public bool OKPressed = false;

        public string initialState = "";
        public List<string> finalStates = new List<string>();

        public SettingsForm()
        {
            InitializeComponent();

            tapesCountCombo.SelectedIndex = 0;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            OKPressed = true;
            finalStates.Clear();
            for (int a = 0; a < lblFinalStates.Items.Count; a++)
            {                
                finalStates.Add((string)lblFinalStates.Items[a]);                
            }
            initialState=txtInitialState.Text;
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (!lblFinalStates.Items.Contains(txtFinalState.Text))
            {
                lblFinalStates.Items.Add(txtFinalState.Text);
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (lblFinalStates.SelectedIndex>=0)
                lblFinalStates.Items.RemoveAt(lblFinalStates.SelectedIndex);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            for (int a = 0; a < finalStates.Count; a++)
            {
                if (!lblFinalStates.Items.Contains(finalStates[a]))
                {
                    lblFinalStates.Items.Add(finalStates[a]);
                }
            }
            txtInitialState.Text = initialState;
        }
    }
}