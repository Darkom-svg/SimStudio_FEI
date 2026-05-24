namespace FEI.SimStudio {
	public partial class SimulatorsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorsForm));
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewTM = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewRAM = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewAM = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.roundedPanel6 = new FEI.SimStudio.RoundedPanel();
            this.finiteAutomatonButton = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel5 = new FEI.SimStudio.RoundedPanel();
            this.pushDownAutomatonButton2 = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.roundedPanel4 = new FEI.SimStudio.RoundedPanel();
            this.bTuring = new System.Windows.Forms.Button();
            this.pIcon = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.roundedPanel3 = new FEI.SimStudio.RoundedPanel();
            this.bRAM = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new FEI.SimStudio.RoundedPanel();
            this.bAbacusMachine = new System.Windows.Forms.Button();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.roundedPanel1 = new FEI.SimStudio.RoundedPanel();
            this.bTrainer = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.roundedPanel7 = new FEI.SimStudio.RoundedPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.roundedPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.roundedPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.roundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).BeginInit();
            this.roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.roundedPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNew, this.miOpen, this.toolStripMenuItem1, this.miExit });
            this.miFile.Name = "miFile";
            resources.ApplyResources(this.miFile, "miFile");
            // 
            // miNew
            // 
            this.miNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewTM, this.miNewRAM, this.miNewAM });
            this.miNew.Name = "miNew";
            resources.ApplyResources(this.miNew, "miNew");
            // 
            // miNewTM
            // 
            this.miNewTM.Name = "miNewTM";
            resources.ApplyResources(this.miNewTM, "miNewTM");
            this.miNewTM.Click += new System.EventHandler(this.miNewTM_Click);
            // 
            // miNewRAM
            // 
            this.miNewRAM.Name = "miNewRAM";
            resources.ApplyResources(this.miNewRAM, "miNewRAM");
            this.miNewRAM.Click += new System.EventHandler(this.miNewRAM_Click);
            // 
            // miNewAM
            // 
            this.miNewAM.Name = "miNewAM";
            resources.ApplyResources(this.miNewAM, "miNewAM");
            this.miNewAM.Click += new System.EventHandler(this.miNewAM_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            resources.ApplyResources(this.miOpen, "miOpen");
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            resources.ApplyResources(this.miExit, "miExit");
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miWindow
            // 
            this.miWindow.Name = "miWindow";
            resources.ApplyResources(this.miWindow, "miWindow");
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
            this.miHelp.Name = "miHelp";
            resources.ApplyResources(this.miHelp, "miHelp");
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            resources.ApplyResources(this.miAbout, "miAbout");
            this.miAbout.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // pictureBox5
            // 
            resources.ApplyResources(this.pictureBox5, "pictureBox5");
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.TabStop = false;
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox7);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel6);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel5);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel4);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel3);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel2);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel1);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // roundedPanel6
            // 
            resources.ApplyResources(this.roundedPanel6, "roundedPanel6");
            this.roundedPanel6.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel6.Controls.Add(this.finiteAutomatonButton);
            this.roundedPanel6.Controls.Add(this.pictureBox3);
            this.roundedPanel6.Controls.Add(this.label1);
            this.roundedPanel6.CornerRadius = 5;
            this.roundedPanel6.Name = "roundedPanel6";
            // 
            // finiteAutomatonButton
            // 
            resources.ApplyResources(this.finiteAutomatonButton, "finiteAutomatonButton");
            this.finiteAutomatonButton.Name = "finiteAutomatonButton";
            this.finiteAutomatonButton.UseVisualStyleBackColor = true;
            this.finiteAutomatonButton.Click += new System.EventHandler(this.finiteAutomatonButton_Click);
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // roundedPanel5
            // 
            resources.ApplyResources(this.roundedPanel5, "roundedPanel5");
            this.roundedPanel5.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel5.Controls.Add(this.pushDownAutomatonButton2);
            this.roundedPanel5.Controls.Add(this.pictureBox4);
            this.roundedPanel5.Controls.Add(this.label4);
            this.roundedPanel5.CornerRadius = 5;
            this.roundedPanel5.Name = "roundedPanel5";
            // 
            // pushDownAutomatonButton2
            // 
            resources.ApplyResources(this.pushDownAutomatonButton2, "pushDownAutomatonButton2");
            this.pushDownAutomatonButton2.Name = "pushDownAutomatonButton2";
            this.pushDownAutomatonButton2.UseVisualStyleBackColor = true;
            this.pushDownAutomatonButton2.Click += new System.EventHandler(this.pushDownAutomatonButton2_Click);
            // 
            // pictureBox4
            // 
            resources.ApplyResources(this.pictureBox4, "pictureBox4");
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // roundedPanel4
            // 
            resources.ApplyResources(this.roundedPanel4, "roundedPanel4");
            this.roundedPanel4.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel4.Controls.Add(this.bTuring);
            this.roundedPanel4.Controls.Add(this.pIcon);
            this.roundedPanel4.Controls.Add(this.label2);
            this.roundedPanel4.CornerRadius = 5;
            this.roundedPanel4.Name = "roundedPanel4";
            // 
            // bTuring
            // 
            resources.ApplyResources(this.bTuring, "bTuring");
            this.bTuring.Name = "bTuring";
            this.bTuring.UseVisualStyleBackColor = true;
            this.bTuring.Click += new System.EventHandler(this.bTuring_Click);
            // 
            // pIcon
            // 
            resources.ApplyResources(this.pIcon, "pIcon");
            this.pIcon.BackColor = System.Drawing.Color.Transparent;
            this.pIcon.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pIcon.Name = "pIcon";
            this.pIcon.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // roundedPanel3
            // 
            resources.ApplyResources(this.roundedPanel3, "roundedPanel3");
            this.roundedPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel3.Controls.Add(this.bRAM);
            this.roundedPanel3.Controls.Add(this.pictureBox1);
            this.roundedPanel3.Controls.Add(this.label3);
            this.roundedPanel3.CornerRadius = 5;
            this.roundedPanel3.Name = "roundedPanel3";
            // 
            // bRAM
            // 
            resources.ApplyResources(this.bRAM, "bRAM");
            this.bRAM.Name = "bRAM";
            this.bRAM.UseVisualStyleBackColor = true;
            this.bRAM.Click += new System.EventHandler(this.bRAM_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::FEI.SimStudio.Properties.Resources.RAM;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // roundedPanel2
            // 
            resources.ApplyResources(this.roundedPanel2, "roundedPanel2");
            this.roundedPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel2.Controls.Add(this.bAbacusMachine);
            this.roundedPanel2.Controls.Add(this.pictureBox8);
            this.roundedPanel2.Controls.Add(this.label8);
            this.roundedPanel2.CornerRadius = 5;
            this.roundedPanel2.Name = "roundedPanel2";
            // 
            // bAbacusMachine
            // 
            resources.ApplyResources(this.bAbacusMachine, "bAbacusMachine");
            this.bAbacusMachine.Name = "bAbacusMachine";
            this.bAbacusMachine.UseVisualStyleBackColor = true;
            this.bAbacusMachine.Click += new System.EventHandler(this.bAbacusMachine_Click);
            // 
            // pictureBox8
            // 
            resources.ApplyResources(this.pictureBox8, "pictureBox8");
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::FEI.SimStudio.Properties.Resources.Abacus;
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.TabStop = false;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // roundedPanel1
            // 
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel1.Controls.Add(this.bTrainer);
            this.roundedPanel1.Controls.Add(this.pictureBox2);
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.CornerRadius = 5;
            this.roundedPanel1.Name = "roundedPanel1";
            // 
            // bTrainer
            // 
            resources.ApplyResources(this.bTrainer, "bTrainer");
            this.bTrainer.Name = "bTrainer";
            this.bTrainer.UseVisualStyleBackColor = true;
            this.bTrainer.Click += new System.EventHandler(this.bTrainer_Click);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FEI.SimStudio.Properties.Resources.Trainer;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // roundedPanel7
            // 
            resources.ApplyResources(this.roundedPanel7, "roundedPanel7");
            this.roundedPanel7.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel7.Controls.Add(this.button2);
            this.roundedPanel7.Controls.Add(this.pictureBox9);
            this.roundedPanel7.Controls.Add(this.label9);
            this.roundedPanel7.CornerRadius = 5;
            this.roundedPanel7.Name = "roundedPanel7";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.bExample_Click);
            // 
            // pictureBox9
            // 
            resources.ApplyResources(this.pictureBox9, "pictureBox9");
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Image = global::FEI.SimStudio.Properties.Resources.SimStudio;
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // pictureBox7
            // 
            resources.ApplyResources(this.pictureBox7, "pictureBox7");
            this.pictureBox7.Image = global::FEI.SimStudio.Properties.Resources.SimStudio_logo;
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // pictureBox6
            // 
            resources.ApplyResources(this.pictureBox6, "pictureBox6");
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Name = "label5";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SimulatorsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "SimulatorsForm";
            this.Load += new System.EventHandler(this.SimulatorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.roundedPanel6.ResumeLayout(false);
            this.roundedPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).EndInit();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.roundedPanel7.ResumeLayout(false);
            this.roundedPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
        }

        private FEI.SimStudio.RoundedPanel roundedPanel7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Label label9;

        private FEI.SimStudio.RoundedPanel roundedPanel1;

        private FEI.SimStudio.RoundedPanel roundedPanel2;
        private System.Windows.Forms.Button bAbacusMachine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox8;

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bTrainer;
        private FEI.SimStudio.RoundedPanel roundedPanel3;
        private System.Windows.Forms.Button bRAM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private FEI.SimStudio.RoundedPanel roundedPanel4;
        private System.Windows.Forms.Button bTuring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pIcon;
        private FEI.SimStudio.RoundedPanel roundedPanel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button pushDownAutomatonButton2;
        private FEI.SimStudio.RoundedPanel roundedPanel6;
        private System.Windows.Forms.Button finiteAutomatonButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.PictureBox pictureBox7;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private System.Windows.Forms.PictureBox pictureBox5;

        #endregion

        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miWindow;
        private System.Windows.Forms.ToolStripMenuItem miNewTM;
        private System.Windows.Forms.ToolStripMenuItem miNewRAM;
        private System.Windows.Forms.ToolStripMenuItem miNewAM;
    }
}

