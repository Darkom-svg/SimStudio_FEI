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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.txtFind, this.helpToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewFile, this.miOpenFile, this.toolStripMenuItem1, this.miSaveFile, this.miSaveAsFile, this.toolStripMenuItem2, this.miExit });
            this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miFile.MergeIndex = 1;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(50, 23);
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
            this.txtFind.Size = new System.Drawing.Size(170, 23);
            this.txtFind.Text = "Zadajte text, ktorý chcete nájsť ";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.helpToolStripMenuItem.MergeIndex = 10;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
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
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 17;
            // 
            // lblStatus
            // 
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.lblStatus.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.lblStatus.MergeIndex = 0;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(196, 17);
            this.lblStatus.Text = "Trenážér, Copyright (C) 2026 FEI STU";
            // 
            // MainTrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainTrainingForm";
            this.Text = "Trenažér";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        #endregion
    }
}