namespace FEI.RandomAccessMachine {
	partial class ConsoleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleForm));
            this.consoleText = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // consoleText
            // 
            this.consoleText.AccessibleDescription = null;
            this.consoleText.AccessibleName = null;
            resources.ApplyResources(this.consoleText, "consoleText");
            this.consoleText.BackColor = System.Drawing.Color.Black;
            this.consoleText.BackgroundImage = null;
            this.consoleText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleText.ForeColor = System.Drawing.Color.White;
            this.consoleText.Name = "consoleText";
            this.consoleText.ReadOnly = true;
            this.consoleText.TextChanged += new System.EventHandler(this.consoleText_TextChanged);
            this.consoleText.Enter += new System.EventHandler(this.consoleText_Enter);
            // 
            // inputText
            // 
            this.inputText.AcceptsReturn = true;
            this.inputText.AcceptsTab = true;
            this.inputText.AccessibleDescription = null;
            this.inputText.AccessibleName = null;
            resources.ApplyResources(this.inputText, "inputText");
            this.inputText.BackColor = System.Drawing.Color.Black;
            this.inputText.BackgroundImage = null;
            this.inputText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputText.ForeColor = System.Drawing.Color.White;
            this.inputText.Name = "inputText";
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            this.inputText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputText_KeyDown);
            // 
            // ConsoleForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.consoleText);
            this.Controls.Add(this.inputText);
            this.Font = null;
            this.Icon = null;
            this.Name = "ConsoleForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.ConsoleForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox consoleText;
        private System.Windows.Forms.TextBox inputText;

    }
}