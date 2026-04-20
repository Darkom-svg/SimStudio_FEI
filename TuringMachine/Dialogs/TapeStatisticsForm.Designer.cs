namespace FEI.TuringMachineSimulator.Dialogs {
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
            this.statisticsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsListBox.FormattingEnabled = true;
            this.statisticsListBox.IntegralHeight = false;
            this.statisticsListBox.Location = new System.Drawing.Point(12, 80);
            this.statisticsListBox.Name = "statisticsListBox";
            this.statisticsListBox.Size = new System.Drawing.Size(401, 213);
            this.statisticsListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Výskyt symbolov:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(312, 300);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 31);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.bOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Počet obsadených buniek pásky:";
            // 
            // lblCells
            // 
            this.lblCells.AutoSize = true;
            this.lblCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCells.Location = new System.Drawing.Point(183, 40);
            this.lblCells.Name = "lblCells";
            this.lblCells.Size = new System.Drawing.Size(14, 13);
            this.lblCells.TabIndex = 4;
            this.lblCells.Text = "0";
            // 
            // cmbTape
            // 
            this.cmbTape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTape.FormattingEnabled = true;
            this.cmbTape.Items.AddRange(new object[] {
            "Štandardná páska",
            "Aktuálna páska"});
            this.cmbTape.Location = new System.Drawing.Point(58, 6);
            this.cmbTape.Name = "cmbTape";
            this.cmbTape.Size = new System.Drawing.Size(355, 21);
            this.cmbTape.TabIndex = 9;
            this.cmbTape.SelectedIndexChanged += new System.EventHandler(this.cmbTape_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Páska:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTapeStatistics
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.okButton;
            this.ClientSize = new System.Drawing.Size(425, 343);
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
            this.Name = "frmTapeStatistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Štatistiky pásky";
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