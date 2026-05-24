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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionSetForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.instructionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.allowAllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // instructionsCheckedListBox
            // 
            resources.ApplyResources(this.instructionsCheckedListBox, "instructionsCheckedListBox");
            this.instructionsCheckedListBox.FormattingEnabled = true;
            this.instructionsCheckedListBox.Name = "instructionsCheckedListBox";
            // 
            // allowAllButton
            // 
            resources.ApplyResources(this.allowAllButton, "allowAllButton");
            this.allowAllButton.Name = "allowAllButton";
            this.allowAllButton.UseVisualStyleBackColor = true;
            this.allowAllButton.Click += new System.EventHandler(this.allowAllButton_Click);
            // 
            // InstructionSetForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.allowAllButton);
            this.Controls.Add(this.instructionsCheckedListBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionSetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
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