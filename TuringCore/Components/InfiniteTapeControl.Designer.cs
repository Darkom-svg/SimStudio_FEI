namespace FEI.TuringCore.Components {
	partial class InfiniteTapeControl
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
            this.sbxTape = new System.Windows.Forms.HScrollBar();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.pTape = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pTape)).BeginInit();
            this.SuspendLayout();
            // 
            // sbxTape
            // 
            this.sbxTape.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sbxTape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sbxTape.Location = new System.Drawing.Point(0, 78);
            this.sbxTape.Minimum = -100;
            this.sbxTape.Name = "sbxTape";
            this.sbxTape.Size = new System.Drawing.Size(607, 19);
            this.sbxTape.TabIndex = 12;
            this.sbxTape.ValueChanged += new System.EventHandler(this.sbxTape_ValueChanged);
            this.sbxTape.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxTape_Scroll);
            // 
            // txtSymbol
            // 
            this.txtSymbol.AcceptsReturn = true;
            this.txtSymbol.AutoCompleteCustomSource.AddRange(new string[] {
            "Blank",
            "Black",
            "Blue",
            "Red",
            "Green",
            "Yellow",
            "Orange"});
            this.txtSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymbol.Font = new System.Drawing.Font("Arial", 12F);
            this.txtSymbol.Location = new System.Drawing.Point(180, 29);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(46, 26);
            this.txtSymbol.TabIndex = 13;
            this.txtSymbol.Visible = false;
            this.txtSymbol.TextChanged += new System.EventHandler(this.txtSymbol_TextChanged);
            this.txtSymbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSymbol_KeyDown);
            this.txtSymbol.LostFocus += new System.EventHandler(this.txtSymbol_LostFocus);
            // 
            // pTape
            // 
            this.pTape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pTape.BackColor = System.Drawing.Color.White;
            this.pTape.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pTape.Location = new System.Drawing.Point(0, 0);
            this.pTape.Margin = new System.Windows.Forms.Padding(0);
            this.pTape.Name = "pTape";
            this.pTape.Size = new System.Drawing.Size(607, 78);
            this.pTape.TabIndex = 14;
            this.pTape.TabStop = false;
            this.pTape.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pTape_MouseMove);
            this.pTape.Resize += new System.EventHandler(this.pTape_Resize);
            this.pTape.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pTape_MouseDown);
            this.pTape.Paint += new System.Windows.Forms.PaintEventHandler(this.pTape_Paint);
            // 
            // InfiniteTapeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbxTape);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.pTape);
            this.Name = "InfiniteTapeControl";
            this.Size = new System.Drawing.Size(607, 97);
            ((System.ComponentModel.ISupportInitialize)(this.pTape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar sbxTape;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.PictureBox pTape;
    }
}
