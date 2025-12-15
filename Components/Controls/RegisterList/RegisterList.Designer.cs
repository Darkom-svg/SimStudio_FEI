namespace DusanRodina.SimStudio.Components {
	partial class RegisterList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sbyList = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // sbyList
            // 
            this.sbyList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sbyList.Location = new System.Drawing.Point(227, 1);
            this.sbyList.Margin = new System.Windows.Forms.Padding(1);
            this.sbyList.Name = "sbyList";
            this.sbyList.Size = new System.Drawing.Size(17, 330);
            this.sbyList.TabIndex = 0;
            this.sbyList.ValueChanged += new System.EventHandler(this.sbyList_ValueChanged);
            this.sbyList.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyList_Scroll);
            // 
            // RegisterList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbyList);
            this.DoubleBuffered = true;
            this.Name = "RegisterList";
            this.Size = new System.Drawing.Size(245, 332);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RegisterList_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RegisterList_MouseMove);
            this.Resize += new System.EventHandler(this.RegisterList_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RegisterList_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar sbyList;
    }
}
