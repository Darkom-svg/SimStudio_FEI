namespace FEI.FiniteAutomaton.Dialogs {
	partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInitialState = new System.Windows.Forms.TextBox();
            this.txtFinalState = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFinalStates = new System.Windows.Forms.ListBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.bOK_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtInitialState
            // 
            resources.ApplyResources(this.txtInitialState, "txtInitialState");
            this.txtInitialState.Name = "txtInitialState";
            // 
            // txtFinalState
            // 
            resources.ApplyResources(this.txtFinalState, "txtFinalState");
            this.txtFinalState.Name = "txtFinalState";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblFinalStates
            // 
            this.lblFinalStates.FormattingEnabled = true;
            resources.ApplyResources(this.lblFinalStates, "lblFinalStates");
            this.lblFinalStates.Name = "lblFinalStates";
            // 
            // bAdd
            // 
            resources.ApplyResources(this.bAdd, "bAdd");
            this.bAdd.Name = "bAdd";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bRemove
            // 
            resources.ApplyResources(this.bRemove, "bRemove");
            this.bRemove.Name = "bRemove";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.bRemove);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.lblFinalStates);
            this.Controls.Add(this.txtFinalState);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInitialState);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInitialState;
        private System.Windows.Forms.TextBox txtFinalState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lblFinalStates;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bRemove;
    }
}