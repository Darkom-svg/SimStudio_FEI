namespace DusanRodina.FiniteAutomaton.Dialogs {
	partial class AddTFunctionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTFunctionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReadSymbol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.cmbCurrentState = new System.Windows.Forms.ComboBox();
            this.cmbNewState = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtReadSymbol
            // 
            resources.ApplyResources(this.txtReadSymbol, "txtReadSymbol");
            this.txtReadSymbol.Name = "txtReadSymbol";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAdd
            // 
            resources.ApplyResources(this.bAdd, "bAdd");
            this.bAdd.Name = "bAdd";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // cmbCurrentState
            // 
            resources.ApplyResources(this.cmbCurrentState, "cmbCurrentState");
            this.cmbCurrentState.FormattingEnabled = true;
            this.cmbCurrentState.Name = "cmbCurrentState";
            // 
            // cmbNewState
            // 
            resources.ApplyResources(this.cmbNewState, "cmbNewState");
            this.cmbNewState.FormattingEnabled = true;
            this.cmbNewState.Name = "cmbNewState";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // AddTFunctionForm
            // 
            this.AcceptButton = this.bAdd;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbNewState);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtReadSymbol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCurrentState);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTFunctionForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmAddTFunction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReadSymbol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.ComboBox cmbCurrentState;
        private System.Windows.Forms.ComboBox cmbNewState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtComment;
    }
}