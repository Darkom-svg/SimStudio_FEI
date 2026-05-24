namespace FEI.PushdownAutomaton.Dialogs {
	partial class TapeStatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TapeStatisticsForm));
            this.statisticsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCells = new System.Windows.Forms.Label();
            this.cmbTape = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statisticsListBox
            // 
            resources.ApplyResources(this.statisticsListBox, "statisticsListBox");
            this.statisticsListBox.FormattingEnabled = true;
            this.statisticsListBox.Name = "statisticsListBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblCells
            // 
            resources.ApplyResources(this.lblCells, "lblCells");
            this.lblCells.Name = "lblCells";
            // 
            // cmbTape
            // 
            resources.ApplyResources(this.cmbTape, "cmbTape");
            this.cmbTape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTape.FormattingEnabled = true;
            this.cmbTape.Items.AddRange(new object[] { resources.GetString("cmbTape.Items"), resources.GetString("cmbTape.Items1") });
            this.cmbTape.Name = "cmbTape";
            this.cmbTape.SelectedIndexChanged += new System.EventHandler(this.cmbTape_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // TapeStatisticsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.cmbTape);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCells);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statisticsListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TapeStatisticsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmTapeStatistics_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox statisticsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCells;
        private System.Windows.Forms.ComboBox cmbTape;
        private System.Windows.Forms.Label label3;
    }
}