namespace DusanRodina.SimStudio.Components {
	partial class SyntaxTextBox
    {
        //UserControl overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer
        private System.ComponentModel.IContainer components = null;

        internal RTBox txtbox;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.txtbox = new Components.SyntaxTextBox.RTBox();
            this.SuspendLayout();
            // 
            // txtbox
            // 
            this.txtbox.AcceptsTab = true;
            this.txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox.BackColor = System.Drawing.Color.White;
            this.txtbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox.DetectUrls = false;
            this.txtbox.Location = new System.Drawing.Point(5, 5);
            this.txtbox.Name = "txtbox";
            this.txtbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtbox.ShowSelectionMargin = true;
            this.txtbox.Size = new System.Drawing.Size(334, 291);
            this.txtbox.TabIndex = 0;
            this.txtbox.Text = "";
            this.txtbox.TextChanged += new System.EventHandler(this.txtbox_TextChanged);
            // 
            // SyntaxTextBox
            // 
            this.Controls.Add(this.txtbox);
            this.Name = "SyntaxTextBox";
            this.Size = new System.Drawing.Size(344, 304);
            this.Enter += new System.EventHandler(this.QRichTextBox_GotFocus);
            this.Leave += new System.EventHandler(this.QRichTextBox_LostFocus);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SyntaxTextBox_Paint);
            this.ResumeLayout(false);

        }

    }
}
