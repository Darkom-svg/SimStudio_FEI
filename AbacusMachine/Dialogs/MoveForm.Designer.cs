namespace FEI.AbacusMachine.Dialogs {
	partial class MoveForm
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

        private void InitializeComponent()
{
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoveForm));
    this.okButton = new System.Windows.Forms.Button();
    this.txtDstRegister = new System.Windows.Forms.TextBox();
    this.label3 = new System.Windows.Forms.Label();
    this.label2 = new System.Windows.Forms.Label();
    this.txtSrcRegister = new System.Windows.Forms.TextBox();
    this.label1 = new System.Windows.Forms.Label();
    this.cancelButton = new System.Windows.Forms.Button();
    this.SuspendLayout();
    // 
    // okButton
    // 
    resources.ApplyResources(this.okButton, "okButton");
    this.okButton.Name = "okButton";
    this.okButton.UseVisualStyleBackColor = true;
    this.okButton.Click += new System.EventHandler(this.bOK_Click);
    // 
    // txtDstRegister
    // 
    resources.ApplyResources(this.txtDstRegister, "txtDstRegister");
    this.txtDstRegister.Name = "txtDstRegister";
    // 
    // label3
    // 
    resources.ApplyResources(this.label3, "label3");
    this.label3.Name = "label3";
    // 
    // label2
    // 
    resources.ApplyResources(this.label2, "label2");
    this.label2.Name = "label2";
    // 
    // txtSrcRegister
    // 
    resources.ApplyResources(this.txtSrcRegister, "txtSrcRegister");
    this.txtSrcRegister.Name = "txtSrcRegister";
    // 
    // label1
    // 
    resources.ApplyResources(this.label1, "label1");
    this.label1.Name = "label1";
    // 
    // cancelButton
    // 
    resources.ApplyResources(this.cancelButton, "cancelButton");
    this.cancelButton.Name = "cancelButton";
    this.cancelButton.UseVisualStyleBackColor = true;
    this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
    // 
    // MoveForm
    // 
    resources.ApplyResources(this, "$this");
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.Controls.Add(this.okButton);
    this.Controls.Add(this.txtDstRegister);
    this.Controls.Add(this.label3);
    this.Controls.Add(this.label2);
    this.Controls.Add(this.txtSrcRegister);
    this.Controls.Add(this.label1);
    this.Controls.Add(this.cancelButton);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "MoveForm";
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.ResumeLayout(false);
    this.PerformLayout();
}

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox txtDstRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSrcRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
    }
}