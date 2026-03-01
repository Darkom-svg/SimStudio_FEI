namespace DusanRodina.TrainingSimulator
{
    partial class MainTrainingForm
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
            System.Windows.Forms.Button TuringTrain;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTrainingForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFind = new System.Windows.Forms.ToolStripTextBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.roundedPanel1 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.FaTrain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundedPanel3 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.roundedPanel4 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.PdaTrain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.roundedPanel5 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.roundedPanel6 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.roundedPanel7 = new DusanRodina.SimStudio.Components.RoundedPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            TuringTrain = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.miniToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roundedPanel3.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.roundedPanel5.SuspendLayout();
            this.roundedPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.roundedPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // TuringTrain
            // 
            TuringTrain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            TuringTrain.Location = new System.Drawing.Point(75, 35);
            TuringTrain.Name = "TuringTrain";
            TuringTrain.Size = new System.Drawing.Size(110, 22);
            TuringTrain.TabIndex = 19;
            TuringTrain.Text = "Otvoriť";
            TuringTrain.UseVisualStyleBackColor = true;
            TuringTrain.Click += new System.EventHandler(this.TuringTrain_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.txtFind, this.helpToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(92, 19);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.TabStop = true;
            this.menuStrip1.Text = "miniToolStrip";
            this.menuStrip1.Visible = false;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewFile, this.miOpenFile, this.toolStripMenuItem1, this.miSaveFile, this.miSaveAsFile, this.toolStripMenuItem2, this.miExit });
            this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miFile.MergeIndex = 1;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(50, 15);
            this.miFile.Text = "Súbor";
            // 
            // miNewFile
            // 
            this.miNewFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miNewFile.Name = "miNewFile";
            this.miNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.miNewFile.Size = new System.Drawing.Size(155, 22);
            this.miNewFile.Text = "Nový";
            this.miNewFile.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.miNewFile.ToolTipText = "Vytvorí nový súbor";
            // 
            // miOpenFile
            // 
            this.miOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miOpenFile.Name = "miOpenFile";
            this.miOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.miOpenFile.Size = new System.Drawing.Size(155, 22);
            this.miOpenFile.Text = "Otvoriť";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
            // 
            // miSaveFile
            // 
            this.miSaveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miSaveFile.Name = "miSaveFile";
            this.miSaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miSaveFile.Size = new System.Drawing.Size(155, 22);
            this.miSaveFile.Text = "Uložiť";
            // 
            // miSaveAsFile
            // 
            this.miSaveAsFile.Name = "miSaveAsFile";
            this.miSaveAsFile.Size = new System.Drawing.Size(155, 22);
            this.miSaveAsFile.Text = "Uložiť ako...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(155, 22);
            this.miExit.Text = "Skončiť";
            // 
            // txtFind
            // 
            this.txtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(170, 15);
            this.txtFind.Text = "Zadajte text, ktorý chcete nájsť ";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.helpToolStripMenuItem.MergeIndex = 10;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(73, 15);
            this.helpToolStripMenuItem.Text = "Pomocník";
            // 
            // miAbout
            // 
            this.miAbout.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.miAbout.Name = "miAbout";
            this.miAbout.Size = new System.Drawing.Size(138, 22);
            this.miAbout.Text = "O programe";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.miniToolStrip.Location = new System.Drawing.Point(886, 23);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.miniToolStrip.Size = new System.Drawing.Size(31, 19);
            this.miniToolStrip.TabIndex = 0;
            this.miniToolStrip.TabStop = true;
            this.miniToolStrip.Text = "miniToolStrip";
            this.miniToolStrip.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.lblStatus.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.lblStatus.MergeIndex = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(196, 14);
            this.lblStatus.Text = "Trenážér, Copyright (C) 2026 FEI STU";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.roundedPanel7);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(15);
            this.splitContainer1.Size = new System.Drawing.Size(884, 461);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel1);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel3);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel5);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(16);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(442, 461);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.Controls.Add(this.roundedPanel2);
            this.roundedPanel1.Controls.Add(this.FaTrain);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.CornerRadius = 5;
            this.roundedPanel1.Location = new System.Drawing.Point(19, 31);
            this.roundedPanel1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 15);
            this.roundedPanel1.MinimumSize = new System.Drawing.Size(370, 0);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(370, 67);
            this.roundedPanel1.TabIndex = 0;
            this.roundedPanel1.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(75, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 26);
            this.label7.TabIndex = 21;
            this.label7.Text = "Konečný automat";
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BackColor = System.Drawing.Color.Silver;
            this.roundedPanel2.Controls.Add(this.label10);
            this.roundedPanel2.Controls.Add(this.label2);
            this.roundedPanel2.CornerRadius = 5;
            this.roundedPanel2.Location = new System.Drawing.Point(284, 0);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(86, 67);
            this.roundedPanel2.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 67);
            this.label2.TabIndex = 0;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FaTrain
            // 
            this.FaTrain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FaTrain.Location = new System.Drawing.Point(75, 35);
            this.FaTrain.Name = "FaTrain";
            this.FaTrain.Size = new System.Drawing.Size(110, 22);
            this.FaTrain.TabIndex = 19;
            this.FaTrain.Text = "Otvoriť";
            this.FaTrain.UseVisualStyleBackColor = true;
            this.FaTrain.Click += new System.EventHandler(this.FaTrain_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(75, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 26);
            this.label1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TrainingSimulator.Properties.Resources.Turing;
            this.pictureBox1.Location = new System.Drawing.Point(8, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel3.Controls.Add(this.label8);
            this.roundedPanel3.Controls.Add(this.roundedPanel4);
            this.roundedPanel3.Controls.Add(this.PdaTrain);
            this.roundedPanel3.Controls.Add(this.label4);
            this.roundedPanel3.Controls.Add(this.pictureBox2);
            this.roundedPanel3.CornerRadius = 5;
            this.roundedPanel3.Location = new System.Drawing.Point(19, 113);
            this.roundedPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 15);
            this.roundedPanel3.MinimumSize = new System.Drawing.Size(370, 0);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(370, 67);
            this.roundedPanel3.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(75, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(196, 26);
            this.label8.TabIndex = 21;
            this.label8.Text = "Zásobníkový automat";
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.Color.Silver;
            this.roundedPanel4.Controls.Add(this.label11);
            this.roundedPanel4.Controls.Add(this.label3);
            this.roundedPanel4.CornerRadius = 5;
            this.roundedPanel4.Location = new System.Drawing.Point(284, 0);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Size = new System.Drawing.Size(86, 67);
            this.roundedPanel4.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 67);
            this.label3.TabIndex = 0;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PdaTrain
            // 
            this.PdaTrain.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PdaTrain.Location = new System.Drawing.Point(75, 35);
            this.PdaTrain.Name = "PdaTrain";
            this.PdaTrain.Size = new System.Drawing.Size(110, 22);
            this.PdaTrain.TabIndex = 19;
            this.PdaTrain.Text = "Otvoriť";
            this.PdaTrain.UseVisualStyleBackColor = true;
            this.PdaTrain.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(75, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 26);
            this.label4.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TrainingSimulator.Properties.Resources.Turing;
            this.pictureBox2.Location = new System.Drawing.Point(8, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel5.Controls.Add(this.label9);
            this.roundedPanel5.Controls.Add(this.roundedPanel6);
            this.roundedPanel5.Controls.Add(TuringTrain);
            this.roundedPanel5.Controls.Add(this.label6);
            this.roundedPanel5.Controls.Add(this.pictureBox3);
            this.roundedPanel5.CornerRadius = 5;
            this.roundedPanel5.Location = new System.Drawing.Point(19, 198);
            this.roundedPanel5.MinimumSize = new System.Drawing.Size(370, 0);
            this.roundedPanel5.Name = "roundedPanel5";
            this.roundedPanel5.Size = new System.Drawing.Size(370, 67);
            this.roundedPanel5.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(75, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 26);
            this.label9.TabIndex = 21;
            this.label9.Text = "Turingov stroj";
            // 
            // roundedPanel6
            // 
            this.roundedPanel6.BackColor = System.Drawing.Color.Silver;
            this.roundedPanel6.Controls.Add(this.label12);
            this.roundedPanel6.Controls.Add(this.label5);
            this.roundedPanel6.CornerRadius = 5;
            this.roundedPanel6.Location = new System.Drawing.Point(284, 0);
            this.roundedPanel6.Name = "roundedPanel6";
            this.roundedPanel6.Size = new System.Drawing.Size(86, 67);
            this.roundedPanel6.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 67);
            this.label5.TabIndex = 0;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(75, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 26);
            this.label6.TabIndex = 18;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TrainingSimulator.Properties.Resources.Turing;
            this.pictureBox3.Location = new System.Drawing.Point(8, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // roundedPanel7
            // 
            this.roundedPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.roundedPanel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel7.Controls.Add(this.flowLayoutPanel2);
            this.roundedPanel7.CornerRadius = 5;
            this.roundedPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel7.Location = new System.Drawing.Point(15, 15);
            this.roundedPanel7.Name = "roundedPanel7";
            this.roundedPanel7.Size = new System.Drawing.Size(408, 431);
            this.roundedPanel7.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.CausesValidation = false;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(16);
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(408, 431);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(16, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 33);
            this.label10.TabIndex = 23;
            this.label10.Text = "0 %";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(16, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 33);
            this.label11.TabIndex = 23;
            this.label11.Text = "0 %";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(14, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 33);
            this.label12.TabIndex = 23;
            this.label12.Text = "99 %";
            // 
            // MainTrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainTrainingForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.miniToolStrip.ResumeLayout(false);
            this.miniToolStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            this.roundedPanel6.ResumeLayout(false);
            this.roundedPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.roundedPanel7.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel7;

        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel5;
        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;

        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel3;
        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button FaTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PdaTrain;
        private System.Windows.Forms.ProgressBar progressBar2;

        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel2;

        private System.Windows.Forms.Button finiteAutomatonButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private DusanRodina.SimStudio.Components.RoundedPanel roundedPanel1;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNewFile;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miSaveFile;
        private System.Windows.Forms.ToolStripMenuItem miSaveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAbout;

        private System.Windows.Forms.StatusStrip miniToolStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        #endregion
    }
}