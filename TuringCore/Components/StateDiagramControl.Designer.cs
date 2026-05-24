namespace FEI.TuringCore.Components {
	partial class StateDiagramControl
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
            this.sbyStates = new System.Windows.Forms.VScrollBar();
            this.pStates = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sbxStates = new System.Windows.Forms.HScrollBar();
            this.placeholderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pStates)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sbyStates
            // 
            this.sbyStates.Dock = System.Windows.Forms.DockStyle.Right;
            this.sbyStates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sbyStates.Location = new System.Drawing.Point(439, 0);
            this.sbyStates.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.sbyStates.Name = "sbyStates";
            this.sbyStates.Size = new System.Drawing.Size(16, 304);
            this.sbyStates.TabIndex = 5;
            this.sbyStates.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyStates_Scroll);
            this.sbyStates.ValueChanged += new System.EventHandler(this.sbyStates_ValueChanged);
            // 
            // pStates
            // 
            this.pStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pStates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pStates.Location = new System.Drawing.Point(0, 0);
            this.pStates.Name = "pStates";
            this.pStates.Size = new System.Drawing.Size(439, 304);
            this.pStates.TabIndex = 4;
            this.pStates.TabStop = false;
            this.pStates.Paint += new System.Windows.Forms.PaintEventHandler(this.pStates_Paint);
            this.pStates.DoubleClick += new System.EventHandler(this.pStates_DoubleClick);
            this.pStates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pStates_MouseDown);
            this.pStates.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pStates_MouseMove);
            this.pStates.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pStates_MouseUp);
            this.pStates.Resize += new System.EventHandler(this.pStates_Resize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sbxStates);
            this.panel1.Controls.Add(this.placeholderButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 16);
            this.panel1.TabIndex = 8;
            // 
            // sbxStates
            // 
            this.sbxStates.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.sbxStates.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sbxStates.Location = new System.Drawing.Point(0, 0);
            this.sbxStates.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.sbxStates.Name = "sbxStates";
            this.sbxStates.Size = new System.Drawing.Size(439, 16);
            this.sbxStates.TabIndex = 7;
            this.sbxStates.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxStates_Scroll);
            this.sbxStates.ValueChanged += new System.EventHandler(this.sbxStates_ValueChanged);
            // 
            // placeholderButton
            // 
            this.placeholderButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.placeholderButton.Enabled = false;
            this.placeholderButton.Location = new System.Drawing.Point(439, 0);
            this.placeholderButton.Name = "placeholderButton";
            this.placeholderButton.Size = new System.Drawing.Size(16, 16);
            this.placeholderButton.TabIndex = 8;
            this.placeholderButton.UseVisualStyleBackColor = true;
            // 
            // StateDiagramControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pStates);
            this.Controls.Add(this.sbyStates);
            this.Controls.Add(this.panel1);
            this.Enabled = false;
            this.Name = "StateDiagramControl";
            this.Size = new System.Drawing.Size(455, 320);
            ((System.ComponentModel.ISupportInitialize)(this.pStates)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.VScrollBar sbyStates;
        private System.Windows.Forms.PictureBox pStates;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar sbxStates;
        private System.Windows.Forms.Button placeholderButton;
    }
}
