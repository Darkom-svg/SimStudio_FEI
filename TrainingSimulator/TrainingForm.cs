using System;
using System.Windows.Forms;
using DusanRodina.TrainingSimulator;
using DusanRodina.TrainingSimulator.Dialogs;

namespace TrainingSimulator
{
    public partial class TrainingForm : Form
    {
        private MainTrainingForm.TaskDef _task;

        public TrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            _task = task;
            this.Text = "Trenažér (" + _task.Id + ")";

        }

        private void TaskWorkForm_Load(object sender, EventArgs e)
        {
            this.Text = _task.Title;
        }
        
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog(this);        
        }
    }
}