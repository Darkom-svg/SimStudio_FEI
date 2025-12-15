using System;
using System.Windows.Forms;

namespace DusanRodina.SimStudio.Components.Dialogs {
	public partial class FindForm : Form
    {
        //Textbox, v ktorom sa bude vyhľadávať
        public Components.SyntaxTextBox textBox = null;

        public FindForm()
        {
            InitializeComponent();
        }

        private void bFind_Click(object sender, EventArgs e)
        {
            int direction=0;
            if (rbDown.Checked) direction = 0;
            if (rbUp.Checked) direction = 1;

            Finding.Find(textBox, txtFind.Text, chIgnoreCase.Checked, chWholeWords.Checked, direction);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}