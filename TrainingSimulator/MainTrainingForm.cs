using DusanRodina.TrainingSimulator.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DusanRodina.TrainingSimulator {
    public partial class MainTrainingForm : Form
    {
        public MainTrainingForm()
        {
            InitializeComponent();
            AppTitle = this.Text;

        }
        
        string AppTitle;
        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (MdiParent != null) menuStrip1.Visible = false;
            var ico = new ComponentResourceManager(this.GetType()).GetObject("$this.Icon") as Icon;
            if (ico != null) this.Icon = ico;
        }
        
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new TrainingSimulator.Dialogs.AboutForm();
            dlg.ShowDialog(this);
        } 
    }
}