using System;
using System.Windows.Forms;

namespace DusanRodina.TuringCore.Dialogs {
	public partial class NewStateForm : Form
    {
        public NewStateForm()
        {
            InitializeComponent();
        }

        public Diagramming.State state = null;

        private void frmNewState_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            state = new Diagramming.State();
            state.Name = txtStateName.Text;
            state.Type = (Diagramming.StateType)cmbType.SelectedIndex;
            state.Description = txtStateDescription.Text;

            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            state = null;
            this.Close();
        }

    }
}