using FEI.SimStudio.Components;

namespace FEI.TrainingSimulator
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
            this.taskSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.roundedPanel1 = new FEI.SimStudio.Components.RoundedPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.FaTrain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roundedPanel3 = new FEI.SimStudio.Components.RoundedPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.PdaTrain = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.roundedPanel5 = new FEI.SimStudio.Components.RoundedPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.roundedPanel7 = new FEI.SimStudio.Components.RoundedPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            TuringTrain = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.miniToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roundedPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.roundedPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.roundedPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // TuringTrain
            // 
            resources.ApplyResources(TuringTrain, "TuringTrain");
            TuringTrain.Name = "TuringTrain";
            TuringTrain.UseVisualStyleBackColor = true;
            TuringTrain.Click += new System.EventHandler(this.TuringTrain_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.txtFind, this.helpToolStripMenuItem, this.taskSetToolStripMenuItem });
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.TabStop = true;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewFile, this.miOpenFile, this.toolStripMenuItem1, this.miSaveFile, this.miSaveAsFile, this.toolStripMenuItem2, this.miExit });
            this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miFile.MergeIndex = 1;
            this.miFile.Name = "miFile";
            resources.ApplyResources(this.miFile, "miFile");
            // 
            // miNewFile
            // 
            resources.ApplyResources(this.miNewFile, "miNewFile");
            this.miNewFile.Name = "miNewFile";
            // 
            // miOpenFile
            // 
            resources.ApplyResources(this.miOpenFile, "miOpenFile");
            this.miOpenFile.Name = "miOpenFile";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // miSaveFile
            // 
            resources.ApplyResources(this.miSaveFile, "miSaveFile");
            this.miSaveFile.Name = "miSaveFile";
            // 
            // miSaveAsFile
            // 
            this.miSaveAsFile.Name = "miSaveAsFile";
            resources.ApplyResources(this.miSaveAsFile, "miSaveAsFile");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            resources.ApplyResources(this.miExit, "miExit");
            // 
            // txtFind
            // 
            this.txtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtFind.Name = "txtFind";
            resources.ApplyResources(this.txtFind, "txtFind");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.helpToolStripMenuItem.MergeIndex = 10;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // miAbout
            // 
            this.miAbout.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.miAbout.Name = "miAbout";
            resources.ApplyResources(this.miAbout, "miAbout");
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // taskSetToolStripMenuItem
            // 
            this.taskSetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.setsToolStripMenuItem, this.addTaskToolStripMenuItem });
            this.taskSetToolStripMenuItem.Name = "taskSetToolStripMenuItem";
            resources.ApplyResources(this.taskSetToolStripMenuItem, "taskSetToolStripMenuItem");
            // 
            // setsToolStripMenuItem
            // 
            this.setsToolStripMenuItem.Name = "setsToolStripMenuItem";
            resources.ApplyResources(this.setsToolStripMenuItem, "setsToolStripMenuItem");
            this.setsToolStripMenuItem.Click += new System.EventHandler(this.sadyToolStripMenuItem_Click);
            // 
            // addTaskToolStripMenuItem
            // 
            this.addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            resources.ApplyResources(this.addTaskToolStripMenuItem, "addTaskToolStripMenuItem");
            this.addTaskToolStripMenuItem.Click += new System.EventHandler(this.addTaskToolStripMenuItem_Click);
            // 
            // miniToolStrip
            // 
            resources.ApplyResources(this.miniToolStrip, "miniToolStrip");
            this.miniToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.TabStop = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.lblStatus.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.lblStatus.MergeIndex = 0;
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.roundedPanel7);
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel1);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel3);
            this.flowLayoutPanel1.Controls.Add(this.roundedPanel5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel1.Controls.Add(this.label7);
            this.roundedPanel1.Controls.Add(this.FaTrain);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.CornerRadius = 5;
            resources.ApplyResources(this.roundedPanel1, "roundedPanel1");
            this.roundedPanel1.Name = "roundedPanel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Name = "label7";
            // 
            // FaTrain
            // 
            resources.ApplyResources(this.FaTrain, "FaTrain");
            this.FaTrain.Name = "FaTrain";
            this.FaTrain.UseVisualStyleBackColor = true;
            this.FaTrain.Click += new System.EventHandler(this.FaTrain_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FEI.TrainingSimulator.Properties.Resources.Turing;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel3.Controls.Add(this.label8);
            this.roundedPanel3.Controls.Add(this.PdaTrain);
            this.roundedPanel3.Controls.Add(this.label4);
            this.roundedPanel3.Controls.Add(this.pictureBox2);
            this.roundedPanel3.CornerRadius = 5;
            resources.ApplyResources(this.roundedPanel3, "roundedPanel3");
            this.roundedPanel3.Name = "roundedPanel3";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Name = "label8";
            // 
            // PdaTrain
            // 
            resources.ApplyResources(this.PdaTrain, "PdaTrain");
            this.PdaTrain.Name = "PdaTrain";
            this.PdaTrain.UseVisualStyleBackColor = true;
            this.PdaTrain.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::FEI.TrainingSimulator.Properties.Resources.Turing;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // roundedPanel5
            // 
            this.roundedPanel5.BackColor = System.Drawing.Color.Gainsboro;
            this.roundedPanel5.Controls.Add(this.label9);
            this.roundedPanel5.Controls.Add(TuringTrain);
            this.roundedPanel5.Controls.Add(this.label6);
            this.roundedPanel5.Controls.Add(this.pictureBox3);
            this.roundedPanel5.CornerRadius = 5;
            resources.ApplyResources(this.roundedPanel5, "roundedPanel5");
            this.roundedPanel5.Name = "roundedPanel5";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Name = "label9";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Name = "label6";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::FEI.TrainingSimulator.Properties.Resources.Turing;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // roundedPanel7
            // 
            resources.ApplyResources(this.roundedPanel7, "roundedPanel7");
            this.roundedPanel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.roundedPanel7.Controls.Add(this.flowLayoutPanel2);
            this.roundedPanel7.CornerRadius = 5;
            this.roundedPanel7.Name = "roundedPanel7";
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.CausesValidation = false;
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // MainTrainingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roundedPanel3.ResumeLayout(false);
            this.roundedPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.roundedPanel5.ResumeLayout(false);
            this.roundedPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.roundedPanel7.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.ToolStripMenuItem setsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem taskSetToolStripMenuItem;

        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

        private FEI.SimStudio.Components.RoundedPanel roundedPanel7;

        private FEI.SimStudio.Components.RoundedPanel roundedPanel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;

        private FEI.SimStudio.Components.RoundedPanel roundedPanel3;
        private System.Windows.Forms.Button FaTrain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Button PdaTrain;
        private System.Windows.Forms.ProgressBar progressBar2;

        private System.Windows.Forms.Button finiteAutomatonButton;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.PictureBox pictureBox1;

        private FEI.SimStudio.Components.RoundedPanel roundedPanel1;

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