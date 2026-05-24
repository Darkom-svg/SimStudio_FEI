namespace FEI.SimStudio.Components.Dialogs {
	partial class ReplaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReplaceForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chWholeWords = new System.Windows.Forms.CheckBox();
            this.chIgnoreCase = new System.Windows.Forms.CheckBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bFind = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.txtReplaceWith = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bReplace = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.rbUp);
            this.groupBox2.Controls.Add(this.rbDown);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // rbUp
            // 
            resources.ApplyResources(this.rbUp, "rbUp");
            this.rbUp.Name = "rbUp";
            this.rbUp.UseVisualStyleBackColor = true;
            // 
            // rbDown
            // 
            resources.ApplyResources(this.rbDown, "rbDown");
            this.rbDown.Checked = true;
            this.rbDown.Name = "rbDown";
            this.rbDown.TabStop = true;
            this.rbDown.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.chWholeWords);
            this.groupBox1.Controls.Add(this.chIgnoreCase);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chWholeWords
            // 
            resources.ApplyResources(this.chWholeWords, "chWholeWords");
            this.chWholeWords.Name = "chWholeWords";
            this.chWholeWords.UseVisualStyleBackColor = true;
            // 
            // chIgnoreCase
            // 
            resources.ApplyResources(this.chIgnoreCase, "chIgnoreCase");
            this.chIgnoreCase.Name = "chIgnoreCase";
            this.chIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // txtFind
            // 
            resources.ApplyResources(this.txtFind, "txtFind");
            this.txtFind.Name = "txtFind";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // bFind
            // 
            resources.ApplyResources(this.bFind, "bFind");
            this.bFind.Name = "bFind";
            this.bFind.UseVisualStyleBackColor = true;
            this.bFind.Click += new System.EventHandler(this.bFind_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // txtReplaceWith
            // 
            resources.ApplyResources(this.txtReplaceWith, "txtReplaceWith");
            this.txtReplaceWith.Name = "txtReplaceWith";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // bReplace
            // 
            resources.ApplyResources(this.bReplace, "bReplace");
            this.bReplace.Name = "bReplace";
            this.bReplace.UseVisualStyleBackColor = true;
            this.bReplace.Click += new System.EventHandler(this.bReplace_Click);
            // 
            // ReplaceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bReplace);
            this.Controls.Add(this.txtReplaceWith);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bFind);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbUp;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chWholeWords;
        private System.Windows.Forms.CheckBox chIgnoreCase;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bFind;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox txtReplaceWith;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bReplace;

    }
}