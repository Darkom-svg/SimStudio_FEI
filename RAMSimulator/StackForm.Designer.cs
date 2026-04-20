namespace FEI.RandomAccessMachine {
	partial class StackForm
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
            this.stackList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // stackList
            // 
            this.stackList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stackList.FormattingEnabled = true;
            this.stackList.IntegralHeight = false;
            this.stackList.Location = new System.Drawing.Point(0, 0);
            this.stackList.Name = "stackList";
            this.stackList.Size = new System.Drawing.Size(313, 334);
            this.stackList.TabIndex = 0;
            // 
            // StackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 334);
            this.Controls.Add(this.stackList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StackForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zásobník";
            this.Load += new System.EventHandler(this.StackForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox stackList;

    }
}