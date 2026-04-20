namespace FEI.RandomAccessMachine.Dialogs {
	partial class InstructionSetForm
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.instructionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.allowAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(323, 401);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(404, 401);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Zrušiť";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // instructionsCheckedListBox
            // 
            this.instructionsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.instructionsCheckedListBox.FormattingEnabled = true;
            this.instructionsCheckedListBox.IntegralHeight = false;
            this.instructionsCheckedListBox.Location = new System.Drawing.Point(12, 12);
            this.instructionsCheckedListBox.Name = "instructionsCheckedListBox";
            this.instructionsCheckedListBox.Size = new System.Drawing.Size(467, 383);
            this.instructionsCheckedListBox.TabIndex = 2;
            // 
            // allowAllButton
            // 
            this.allowAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.allowAllButton.Location = new System.Drawing.Point(13, 401);
            this.allowAllButton.Name = "allowAllButton";
            this.allowAllButton.Size = new System.Drawing.Size(116, 23);
            this.allowAllButton.TabIndex = 4;
            this.allowAllButton.Text = "Povoliť &všetky";
            this.allowAllButton.UseVisualStyleBackColor = true;
            this.allowAllButton.Click += new System.EventHandler(this.allowAllButton_Click);
            // 
            // InstructionSetForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(491, 436);
            this.Controls.Add(this.allowAllButton);
            this.Controls.Add(this.instructionsCheckedListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionSetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nastavenie inštrukčnej sady";
            this.Load += new System.EventHandler(this.InstructionSetForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckedListBox instructionsCheckedListBox;
        private System.Windows.Forms.Button allowAllButton;
    }
}