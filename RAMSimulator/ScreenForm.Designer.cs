namespace DusanRodina.RandomAccessMachine {
	partial class ScreenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenForm));
            this.pScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pScreen
            // 
            this.pScreen.AccessibleDescription = null;
            this.pScreen.AccessibleName = null;
            resources.ApplyResources(this.pScreen, "pScreen");
            this.pScreen.BackColor = System.Drawing.Color.Black;
            this.pScreen.BackgroundImage = null;
            this.pScreen.Font = null;
            this.pScreen.ImageLocation = null;
            this.pScreen.Name = "pScreen";
            this.pScreen.TabStop = false;
            this.pScreen.Resize += new System.EventHandler(this.pScreen_Resize);
            this.pScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pScreen_Paint);
            // 
            // ScreenForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.pScreen);
            this.Font = null;
            this.Icon = null;
            this.Name = "ScreenForm";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pScreen;
    }
}