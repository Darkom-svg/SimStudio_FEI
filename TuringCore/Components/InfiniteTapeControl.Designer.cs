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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfiniteTapeControl));
            this.sbxTape = new System.Windows.Forms.HScrollBar();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.pTape = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pTape)).BeginInit();
            this.SuspendLayout();
            // 
            // sbxTape
            // 
            resources.ApplyResources(this.sbxTape, "sbxTape");
            this.sbxTape.Minimum = -100;
            this.sbxTape.Name = "sbxTape";
            this.sbxTape.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxTape_Scroll);
            this.sbxTape.ValueChanged += new System.EventHandler(this.sbxTape_ValueChanged);
            // 
            // txtSymbol
            // 
            this.txtSymbol.AcceptsReturn = true;
            this.txtSymbol.AutoCompleteCustomSource.AddRange(new string[] { resources.GetString("txtSymbol.AutoCompleteCustomSource"), resources.GetString("txtSymbol.AutoCompleteCustomSource1"), resources.GetString("txtSymbol.AutoCompleteCustomSource2"), resources.GetString("txtSymbol.AutoCompleteCustomSource3"), resources.GetString("txtSymbol.AutoCompleteCustomSource4"), resources.GetString("txtSymbol.AutoCompleteCustomSource5"), resources.GetString("txtSymbol.AutoCompleteCustomSource6") });
            this.txtSymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSymbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSymbol, "txtSymbol");
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.TextChanged += new System.EventHandler(this.txtSymbol_TextChanged);
            this.txtSymbol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSymbol_KeyDown);
            this.txtSymbol.LostFocus += new System.EventHandler(this.txtSymbol_LostFocus);
            // 
            // pTape
            // 
            resources.ApplyResources(this.pTape, "pTape");
            this.pTape.BackColor = System.Drawing.Color.White;
            this.pTape.Name = "pTape";
            this.pTape.TabStop = false;
            this.pTape.Paint += new System.Windows.Forms.PaintEventHandler(this.pTape_Paint);
            this.pTape.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pTape_MouseDown);
            this.pTape.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pTape_MouseMove);
            this.pTape.Resize += new System.EventHandler(this.pTape_Resize);
            // 
            // InfiniteTapeControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbxTape);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.pTape);
            this.Name = "InfiniteTapeControl";
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
