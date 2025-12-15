namespace DusanRodina.SimStudio {
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
            this.bTuring = new System.Windows.Forms.Button();
            this.bAbacusMachine = new System.Windows.Forms.Button();
            this.bRAM = new System.Windows.Forms.Button();
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
            this.label2 = new System.Windows.Forms.Label();
            this.pIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.finiteAutomatonButton = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pushDownAutomatonButton2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bTuring
            // 
            this.bTuring.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bTuring.Location = new System.Drawing.Point(118, 231);
            this.bTuring.Name = "bTuring";
            this.bTuring.Size = new System.Drawing.Size(110, 22);
            this.bTuring.TabIndex = 1;
            this.bTuring.Text = "Spustiť";
            this.bTuring.UseVisualStyleBackColor = true;
            this.bTuring.Click += new System.EventHandler(this.bTuring_Click);
            // 
            // bAbacusMachine
            // 
            this.bAbacusMachine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bAbacusMachine.Location = new System.Drawing.Point(120, 339);
            this.bAbacusMachine.Name = "bAbacusMachine";
            this.bAbacusMachine.Size = new System.Drawing.Size(110, 22);
            this.bAbacusMachine.TabIndex = 5;
            this.bAbacusMachine.Text = "Spustiť";
            this.bAbacusMachine.UseVisualStyleBackColor = true;
            this.bAbacusMachine.Click += new System.EventHandler(this.bAbacusMachine_Click);
            // 
            // bRAM
            // 
            this.bRAM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bRAM.Location = new System.Drawing.Point(118, 285);
            this.bRAM.Name = "bRAM";
            this.bRAM.Size = new System.Drawing.Size(110, 22);
            this.bRAM.TabIndex = 4;
            this.bRAM.Text = "Spustiť";
            this.bRAM.UseVisualStyleBackColor = true;
            this.bRAM.Click += new System.EventHandler(this.bRAM_Click);
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNew, this.miOpen, this.toolStripMenuItem1, this.miExit });
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(50, 20);
            this.miFile.Text = "Súbor";
            // 
            // miNew
            // 
            this.miNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewTM, this.miNewRAM, this.miNewAM });
            this.miNew.Name = "miNew";
            this.miNew.Size = new System.Drawing.Size(155, 22);
            this.miNew.Text = "Nový";
            // 
            // miNewTM
            // 
            this.miNewTM.Name = "miNewTM";
            this.miNewTM.Size = new System.Drawing.Size(162, 22);
            this.miNewTM.Text = "Turingov stroj";
            this.miNewTM.Click += new System.EventHandler(this.miNewTM_Click);
            // 
            // miNewRAM
            // 
            this.miNewRAM.Name = "miNewRAM";
            this.miNewRAM.Size = new System.Drawing.Size(162, 22);
            this.miNewRAM.Text = "RAM";
            this.miNewRAM.Click += new System.EventHandler(this.miNewRAM_Click);
            // 
            // miNewAM
            // 
            this.miNewAM.Name = "miNewAM";
            this.miNewAM.Size = new System.Drawing.Size(162, 22);
            this.miNewAM.Text = "Počítadlový stroj";
            this.miNewAM.Click += new System.EventHandler(this.miNewAM_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(155, 22);
            this.miOpen.Text = "Otvoriť";
            this.miOpen.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(155, 22);
            this.miExit.Text = "Skončiť";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miWindow
            // 
            this.miWindow.Name = "miWindow";
            this.miWindow.Size = new System.Drawing.Size(48, 20);
            this.miWindow.Text = "Okno";
            this.miWindow.Visible = false;
            // 
            // miHelp
            // 
            this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(73, 20);
            this.miHelp.Text = "Pomocník";
            // 
            // miAbout
            // 
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(138, 22);
            this.miAbout.Text = "O programe";
            this.miAbout.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(113, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Turingov stroj";
            // 
            // pIcon
            // 
            this.pIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pIcon.BackColor = System.Drawing.Color.Transparent;
            this.pIcon.BackgroundImage = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.pIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pIcon.Location = new System.Drawing.Point(50, 205);
            this.pIcon.Name = "pIcon";
            this.pIcon.Size = new System.Drawing.Size(48, 48);
            this.pIcon.TabIndex = 11;
            this.pIcon.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::DusanRodina.SimStudio.Properties.Resources.RAM;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(50, 259);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::DusanRodina.SimStudio.Properties.Resources.Abacus;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(50, 313);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(115, 259);
            this.label3.MaximumSize = new System.Drawing.Size(0, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(286, 26);
            this.label3.TabIndex = 14;
            this.label3.Text = "RAM - Random Access Machine";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(115, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 26);
            this.label7.TabIndex = 15;
            this.label7.Text = "Počítadlový stroj";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Location = new System.Drawing.Point(50, 97);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(113, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 26);
            this.label1.TabIndex = 17;
            this.label1.Text = "Konečný automat";
            // 
            // finiteAutomatonButton
            // 
            this.finiteAutomatonButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.finiteAutomatonButton.Location = new System.Drawing.Point(120, 123);
            this.finiteAutomatonButton.Name = "finiteAutomatonButton";
            this.finiteAutomatonButton.Size = new System.Drawing.Size(110, 22);
            this.finiteAutomatonButton.TabIndex = 16;
            this.finiteAutomatonButton.Text = "Spustiť";
            this.finiteAutomatonButton.UseVisualStyleBackColor = true;
            this.finiteAutomatonButton.Click += new System.EventHandler(this.finiteAutomatonButton_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Location = new System.Drawing.Point(50, 151);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(115, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Zásobníkový automat";
            // 
            // pushDownAutomatonButton2
            // 
            this.pushDownAutomatonButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pushDownAutomatonButton2.Location = new System.Drawing.Point(118, 177);
            this.pushDownAutomatonButton2.Name = "pushDownAutomatonButton2";
            this.pushDownAutomatonButton2.Size = new System.Drawing.Size(110, 22);
            this.pushDownAutomatonButton2.TabIndex = 19;
            this.pushDownAutomatonButton2.Text = "Spustiť";
            this.pushDownAutomatonButton2.UseVisualStyleBackColor = true;
            this.pushDownAutomatonButton2.Click += new System.EventHandler(this.pushDownAutomatonButton2_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(121, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 33);
            this.label5.TabIndex = 23;
            this.label5.Text = "SimStudio - FEI STU";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::DusanRodina.SimStudio.Properties.Resources.Fei_logo;
            this.pictureBox5.Location = new System.Drawing.Point(476, 3);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(480, 240);
            this.pictureBox5.MinimumSize = new System.Drawing.Size(240, 120);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(467, 240);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox5, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-8, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 529);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // SimulatorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(938, 521);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pushDownAutomatonButton2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finiteAutomatonButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pIcon);
            this.Controls.Add(this.bAbacusMachine);
            this.Controls.Add(this.bRAM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTuring);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.MinimumSize = new System.Drawing.Size(703, 459);
            this.Name = "SimulatorsForm";
            this.Load += new System.EventHandler(this.SimulatorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.PictureBox pictureBox5;

        #endregion

        private System.Windows.Forms.Button bTuring;
        private System.Windows.Forms.Button bAbacusMachine;
        private System.Windows.Forms.Button bRAM;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem miWindow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem miNewTM;
        private System.Windows.Forms.ToolStripMenuItem miNewRAM;
        private System.Windows.Forms.ToolStripMenuItem miNewAM;
        private System.Windows.Forms.PictureBox pIcon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button finiteAutomatonButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button pushDownAutomatonButton2;
    }
}

