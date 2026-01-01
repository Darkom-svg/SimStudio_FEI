namespace DusanRodina.FiniteAutomaton.Dialogs {
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
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(160, 222);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(101, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.bOK_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(267, 222);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Zrušiť";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Počiatočný stav:";
            // 
            // txtInitialState
            // 
            this.txtInitialState.Location = new System.Drawing.Point(110, 6);
            this.txtInitialState.Name = "txtInitialState";
            this.txtInitialState.Size = new System.Drawing.Size(151, 20);
            this.txtInitialState.TabIndex = 12;
            // 
            // txtFinalState
            // 
            this.txtFinalState.Location = new System.Drawing.Point(110, 32);
            this.txtFinalState.Name = "txtFinalState";
            this.txtFinalState.Size = new System.Drawing.Size(151, 20);
            this.txtFinalState.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Koncové stavy:";
            // 
            // lblFinalStates
            // 
            this.lblFinalStates.FormattingEnabled = true;
            this.lblFinalStates.Location = new System.Drawing.Point(110, 58);
            this.lblFinalStates.Name = "lblFinalStates";
            this.lblFinalStates.Size = new System.Drawing.Size(151, 95);
            this.lblFinalStates.TabIndex = 15;
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdd.Location = new System.Drawing.Point(267, 30);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(101, 23);
            this.bAdd.TabIndex = 16;
            this.bAdd.Text = "Pridať";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bRemove
            // 
            this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemove.Location = new System.Drawing.Point(267, 58);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(101, 23);
            this.bRemove.TabIndex = 17;
            this.bRemove.Text = "Odobrať";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(380, 257);
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
            this.Text = "Nastavenia";
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