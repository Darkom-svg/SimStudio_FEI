using FEI.SimStudio.Components.Controls;

namespace FEI.RandomAccessMachine.Dialogs {
	partial class CConversionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CConversionForm));
            this.txtCode = new FEI.SimStudio.Components.Controls.SyntaxTextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            resources.ApplyResources(this.txtCode, "txtCode");
            this.txtCode.HideSelection = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedText = "";
            this.txtCode.SelectionLength = 0;
            this.txtCode.SelectionStart = 0;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.bOK_Click);
            // 
            // CConversionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.txtCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CConversionForm";
            this.Load += new System.EventHandler(this.frmCConversion_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private FEI.SimStudio.Components.Controls.SyntaxTextBox txtCode;
        private System.Windows.Forms.Button okButton;
    }
}