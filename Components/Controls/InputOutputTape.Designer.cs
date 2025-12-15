namespace DusanRodina.SimStudio.Components {
	partial class InputOutputTape
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputOutputTape));
			this.sbxTape = new System.Windows.Forms.HScrollBar();
			this.txtText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// sbxTape
			// 
			this.sbxTape.AccessibleDescription = null;
			this.sbxTape.AccessibleName = null;
			resources.ApplyResources(this.sbxTape, "sbxTape");
			this.sbxTape.BackgroundImage = null;
			this.sbxTape.Font = null;
			this.sbxTape.Name = "sbxTape";
			this.sbxTape.ValueChanged += new System.EventHandler(this.sbxTape_ValueChanged);
			this.sbxTape.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxTape_Scroll);
			// 
			// txtText
			// 
			this.txtText.AccessibleDescription = null;
			this.txtText.AccessibleName = null;
			resources.ApplyResources(this.txtText, "txtText");
			this.txtText.BackgroundImage = null;
			this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtText.Name = "txtText";
			this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
			this.txtText.Leave += new System.EventHandler(this.txtText_LostFocus);
			// 
			// InputOutputTape
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add(this.txtText);
			this.Controls.Add(this.sbxTape);
			this.DoubleBuffered = true;
			this.Font = null;
			this.Name = "InputOutputTape";
			this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FiniteTape_MouseWheel);
			this.MouseLeave += new System.EventHandler(this.FiniteTape_MouseLeave);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.TapeComponent_Paint);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FiniteTape_MouseMove);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FiniteTape_MouseDown);
			this.Resize += new System.EventHandler(this.FiniteTape_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.HScrollBar sbxTape;
		private System.Windows.Forms.TextBox txtText;
	}
}
