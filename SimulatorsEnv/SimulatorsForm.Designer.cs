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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
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
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
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
            this.miNew.Size = new System.Drawing.Size(179, 24);
            this.miNew.Text = "Nový";
            // 
            // miNewTM
            // 
            this.miNewTM.Name = "miNewTM";
            this.miNewTM.Size = new System.Drawing.Size(187, 24);
            this.miNewTM.Text = "Turingov stroj";
            this.miNewTM.Click += new System.EventHandler(this.miNewTM_Click);
            // 
            // miNewRAM
            // 
            this.miNewRAM.Name = "miNewRAM";
            this.miNewRAM.Size = new System.Drawing.Size(187, 24);
            this.miNewRAM.Text = "RAM";
            this.miNewRAM.Click += new System.EventHandler(this.miNewRAM_Click);
            // 
            // miNewAM
            // 
            this.miNewAM.Name = "miNewAM";
            this.miNewAM.Size = new System.Drawing.Size(187, 24);
            this.miNewAM.Text = "Počítadlový stroj";
            this.miNewAM.Click += new System.EventHandler(this.miNewAM_Click);
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpen.Size = new System.Drawing.Size(179, 24);
            this.miOpen.Text = "Otvoriť";
            this.miOpen.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(176, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(179, 24);
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
            this.miAbout.Size = new System.Drawing.Size(159, 24);
            this.miAbout.Text = "O programe";
            this.miAbout.Click += new System.EventHandler(this.oProgrameToolStripMenuItem_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Location = new System.Drawing.Point(476, 3);
            this.pictureBox5.MaximumSize = new System.Drawing.Size(480, 240);
            this.pictureBox5.MinimumSize = new System.Drawing.Size(240, 120);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(467, 240);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1312, 719);
            this.splitContainer1.SplitterDistance = 554;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 22;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel6);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel5);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel4);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel3);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel2);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(21, 20, 21, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(554, 719);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // roundedPanel6
            // 
            this.roundedPanel6.AutoSize = true;
            this.roundedPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel6.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel6.Controls.Add(this.finiteAutomatonButton);
            this.roundedPanel6.Controls.Add(this.pictureBox3);
            this.roundedPanel6.Controls.Add(this.label1);
            this.roundedPanel6.CornerRadius = 5;
            this.roundedPanel6.Location = new System.Drawing.Point(25, 45);
            this.roundedPanel6.Margin = new System.Windows.Forms.Padding(4, 25, 4, 25);
            this.roundedPanel6.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel6.Name = "roundedPanel6";
            this.roundedPanel6.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel6.Size = new System.Drawing.Size(493, 83);
            this.roundedPanel6.TabIndex = 0;
            // 
            // finiteAutomatonButton
            // 
            this.finiteAutomatonButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.finiteAutomatonButton.Location = new System.Drawing.Point(100, 46);
            this.finiteAutomatonButton.Margin = new System.Windows.Forms.Padding(4);
            this.finiteAutomatonButton.Name = "finiteAutomatonButton";
            this.finiteAutomatonButton.Size = new System.Drawing.Size(147, 27);
            this.finiteAutomatonButton.TabIndex = 16;
            this.finiteAutomatonButton.Text = "Spustiť";
            this.finiteAutomatonButton.UseVisualStyleBackColor = true;
            this.finiteAutomatonButton.Click += new System.EventHandler(this.finiteAutomatonButton_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox3.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pictureBox3.Location = new System.Drawing.Point(11, 14);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 59);
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(100, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 33);
            this.label1.TabIndex = 17;
            this.label1.Text = "Konečný automat";
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.AutoSize = true;
            this.roundedPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel5.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel5.Controls.Add(this.pushDownAutomatonButton2);
            this.roundedPanel5.Controls.Add(this.pictureBox4);
            this.roundedPanel5.Controls.Add(this.label4);
            this.roundedPanel5.CornerRadius = 5;
            this.roundedPanel5.Location = new System.Drawing.Point(25, 153);
            this.roundedPanel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 25);
            this.roundedPanel5.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel5.Size = new System.Drawing.Size(493, 75);
            this.roundedPanel5.TabIndex = 19;
            // 
            // pushDownAutomatonButton2
            // 
            this.pushDownAutomatonButton2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pushDownAutomatonButton2.Location = new System.Drawing.Point(97, 38);
            this.pushDownAutomatonButton2.Margin = new System.Windows.Forms.Padding(4);
            this.pushDownAutomatonButton2.Name = "pushDownAutomatonButton2";
            this.pushDownAutomatonButton2.Size = new System.Drawing.Size(147, 27);
            this.pushDownAutomatonButton2.TabIndex = 19;
            this.pushDownAutomatonButton2.Text = "Spustiť";
            this.pushDownAutomatonButton2.UseVisualStyleBackColor = true;
            this.pushDownAutomatonButton2.Click += new System.EventHandler(this.pushDownAutomatonButton2_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox4.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pictureBox4.Location = new System.Drawing.Point(11, 6);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(64, 59);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(97, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(256, 33);
            this.label4.TabIndex = 20;
            this.label4.Text = "Zásobníkový automat";
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.AutoSize = true;
            this.roundedPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel4.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel4.Controls.Add(this.bTuring);
            this.roundedPanel4.Controls.Add(this.pIcon);
            this.roundedPanel4.Controls.Add(this.label2);
            this.roundedPanel4.CornerRadius = 5;
            this.roundedPanel4.Location = new System.Drawing.Point(25, 253);
            this.roundedPanel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 25);
            this.roundedPanel4.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel4.Size = new System.Drawing.Size(493, 74);
            this.roundedPanel4.TabIndex = 22;
            // 
            // bTuring
            // 
            this.bTuring.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bTuring.Location = new System.Drawing.Point(97, 37);
            this.bTuring.Margin = new System.Windows.Forms.Padding(4);
            this.bTuring.Name = "bTuring";
            this.bTuring.Size = new System.Drawing.Size(147, 27);
            this.bTuring.TabIndex = 1;
            this.bTuring.Text = "Spustiť";
            this.bTuring.UseVisualStyleBackColor = true;
            this.bTuring.Click += new System.EventHandler(this.bTuring_Click);
            // 
            // pIcon
            // 
            this.pIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pIcon.BackColor = System.Drawing.Color.Transparent;
            this.pIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pIcon.Image = global::FEI.SimStudio.Properties.Resources.Turing;
            this.pIcon.Location = new System.Drawing.Point(11, 5);
            this.pIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pIcon.Name = "pIcon";
            this.pIcon.Size = new System.Drawing.Size(64, 59);
            this.pIcon.TabIndex = 11;
            this.pIcon.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(97, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Turingov stroj";
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.AutoSize = true;
            this.roundedPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel3.Controls.Add(this.bRAM);
            this.roundedPanel3.Controls.Add(this.pictureBox1);
            this.roundedPanel3.Controls.Add(this.label3);
            this.roundedPanel3.CornerRadius = 5;
            this.roundedPanel3.Location = new System.Drawing.Point(25, 352);
            this.roundedPanel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 25);
            this.roundedPanel3.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel3.Size = new System.Drawing.Size(493, 78);
            this.roundedPanel3.TabIndex = 23;
            // 
            // bRAM
            // 
            this.bRAM.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bRAM.Location = new System.Drawing.Point(100, 41);
            this.bRAM.Margin = new System.Windows.Forms.Padding(4);
            this.bRAM.Name = "bRAM";
            this.bRAM.Size = new System.Drawing.Size(147, 27);
            this.bRAM.TabIndex = 4;
            this.bRAM.Text = "Spustiť";
            this.bRAM.UseVisualStyleBackColor = true;
            this.bRAM.Click += new System.EventHandler(this.bRAM_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = global::FEI.SimStudio.Properties.Resources.RAM;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(11, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(99, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(366, 33);
            this.label3.TabIndex = 14;
            this.label3.Text = "RAM - Random Access Machine";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.AutoSize = true;
            this.roundedPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel2.Controls.Add(this.bAbacusMachine);
            this.roundedPanel2.Controls.Add(this.pictureBox8);
            this.roundedPanel2.Controls.Add(this.label8);
            this.roundedPanel2.CornerRadius = 5;
            this.roundedPanel2.Location = new System.Drawing.Point(25, 455);
            this.roundedPanel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 25);
            this.roundedPanel2.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel2.Size = new System.Drawing.Size(493, 78);
            this.roundedPanel2.TabIndex = 24;
            // 
            // bAbacusMachine
            // 
            this.bAbacusMachine.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bAbacusMachine.Location = new System.Drawing.Point(100, 41);
            this.bAbacusMachine.Margin = new System.Windows.Forms.Padding(4);
            this.bAbacusMachine.Name = "bAbacusMachine";
            this.bAbacusMachine.Size = new System.Drawing.Size(147, 27);
            this.bAbacusMachine.TabIndex = 5;
            this.bAbacusMachine.Text = "Spustiť";
            this.bAbacusMachine.UseVisualStyleBackColor = true;
            this.bAbacusMachine.Click += new System.EventHandler(this.bAbacusMachine_Click);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox8.Image = global::FEI.SimStudio.Properties.Resources.Abacus;
            this.pictureBox8.Location = new System.Drawing.Point(11, 9);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(64, 59);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 13;
            this.pictureBox8.TabStop = false;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(100, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 33);
            this.label8.TabIndex = 15;
            this.label8.Text = "Počítadlový stroj";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.AutoSize = true;
            this.roundedPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel1.Controls.Add(this.bTrainer);
            this.roundedPanel1.Controls.Add(this.pictureBox2);
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.CornerRadius = 5;
            this.roundedPanel1.Location = new System.Drawing.Point(25, 558);
            this.roundedPanel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roundedPanel1.MinimumSize = new System.Drawing.Size(493, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.roundedPanel1.Size = new System.Drawing.Size(493, 76);
            this.roundedPanel1.TabIndex = 26;
            // 
            // bTrainer
            // 
            this.bTrainer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.bTrainer.Location = new System.Drawing.Point(99, 39);
            this.bTrainer.Margin = new System.Windows.Forms.Padding(4);
            this.bTrainer.Name = "bTrainer";
            this.bTrainer.Size = new System.Drawing.Size(147, 27);
            this.bTrainer.TabIndex = 5;
            this.bTrainer.Text = "Spustiť";
            this.bTrainer.UseVisualStyleBackColor = true;
            this.bTrainer.Click += new System.EventHandler(this.bTrainer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Image = global::FEI.SimStudio.Properties.Resources.small_Trainer;
            this.pictureBox2.Location = new System.Drawing.Point(11, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 59);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(100, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 33);
            this.label7.TabIndex = 15;
            this.label7.Text = "Trenažer";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox7, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(753, 719);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox7.Image = global::FEI.SimStudio.Properties.Resources.FEI_LOGO;
            this.pictureBox7.Location = new System.Drawing.Point(11, 20);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(11, 20, 11, 0);
            this.pictureBox7.MaximumSize = new System.Drawing.Size(1120, 442);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(731, 339);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(4, 359);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(745, 360);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sim Studio - FEI STU";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(19, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 48);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(8, 8);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(223, 48);
            this.panel3.TabIndex = 22;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 48);
            this.pictureBox6.TabIndex = 21;
            this.pictureBox6.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(70, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 26);
            this.label5.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(70, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 22);
            this.button1.TabIndex = 19;
            this.button1.Text = "Spustiť";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Location = new System.Drawing.Point(1239, 726);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(267, 123);
            this.panel8.TabIndex = 23;
            // 
            // SimulatorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 719);
            this.ControlBox = false;
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1327, 734);
            this.Name = "SimulatorsForm";
            this.Load += new System.EventHandler(this.SimulatorsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
        }

        private RoundedPanel roundedPanel1;

        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.Button bAbacusMachine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox8;

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bTrainer;
        private RoundedPanel roundedPanel3;
        private System.Windows.Forms.Button bRAM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private RoundedPanel roundedPanel4;
        private System.Windows.Forms.Button bTuring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pIcon;
        private RoundedPanel roundedPanel5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button pushDownAutomatonButton2;
        private RoundedPanel roundedPanel6;
        private System.Windows.Forms.Button finiteAutomatonButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.Panel panel8;

        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.PictureBox pictureBox7;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

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

