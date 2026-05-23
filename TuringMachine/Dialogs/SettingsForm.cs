using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FEI.TuringMachineSimulator.Dialogs {
	public partial class SettingsForm : Form
    {
        public bool OKPressed;

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
            foreach (var finalState in lblFinalStates.Items)
            {
                finalStates.Add((string)finalState);
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
            foreach (var finalState in finalStates)
            {
                if (!lblFinalStates.Items.Contains(finalState))
                {
                    lblFinalStates.Items.Add(finalState);
                }
            }

            txtInitialState.Text = initialState;
        }
    }
}