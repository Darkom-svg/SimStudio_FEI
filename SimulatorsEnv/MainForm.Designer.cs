using DusanRodina.SimStudio.Properties;

namespace DusanRodina.SimStudio {
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.simulatorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.finiteAutomatonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pushdownAutomatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turingMachineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rAMSimulatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abacusMachineToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.placeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finiteAutomatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stackAutomatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turingMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abacusMachineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.mainToolStrip = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this.topToolStripPanel.SuspendLayout();
            this.mainToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.simulatorsToolStripMenuItem1, this.placeholderToolStripMenuItem, this.windowsToolStripMenuItem1, this.helpToolStripMenuItem1 });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowsToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 1;
            // 
            // simulatorsToolStripMenuItem1
            // 
            this.simulatorsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openFileToolStripMenuItem, this.toolStripMenuItem1, this.finiteAutomatonToolStripMenuItem1, this.pushdownAutomatonToolStripMenuItem, this.turingMachineToolStripMenuItem1, this.rAMSimulatorToolStripMenuItem, this.abacusMachineToolStripMenuItem1 });
            this.simulatorsToolStripMenuItem1.Name = "simulatorsToolStripMenuItem1";
            this.simulatorsToolStripMenuItem1.Size = new System.Drawing.Size(76, 20);
            this.simulatorsToolStripMenuItem1.Text = "Simulátory";
            this.simulatorsToolStripMenuItem1.Paint += new System.Windows.Forms.PaintEventHandler(this.simulatorsToolStripMenuItem_Paint);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::DusanRodina.SimStudio.Properties.Resources.small_open;
            this.openFileToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.openFileToolStripMenuItem.Text = "Otvoriť";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // finiteAutomatonToolStripMenuItem1
            // 
            this.finiteAutomatonToolStripMenuItem1.Image = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.finiteAutomatonToolStripMenuItem1.Name = "finiteAutomatonToolStripMenuItem1";
            this.finiteAutomatonToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.finiteAutomatonToolStripMenuItem1.Text = "Konečný automat";
            this.finiteAutomatonToolStripMenuItem1.Click += new System.EventHandler(this.finiteAutomatonToolStripMenuItem_Click);
            // 
            // pushdownAutomatonToolStripMenuItem
            // 
            this.pushdownAutomatonToolStripMenuItem.Image = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.pushdownAutomatonToolStripMenuItem.Name = "pushdownAutomatonToolStripMenuItem";
            this.pushdownAutomatonToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pushdownAutomatonToolStripMenuItem.Text = "Zásobníkový automat";
            this.pushdownAutomatonToolStripMenuItem.Click += new System.EventHandler(this.pushdownAutomatonToolStripMenuItem_Click);
            // 
            // turingMachineToolStripMenuItem1
            // 
            this.turingMachineToolStripMenuItem1.Image = global::DusanRodina.SimStudio.Properties.Resources.Turing;
            this.turingMachineToolStripMenuItem1.Name = "turingMachineToolStripMenuItem1";
            this.turingMachineToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.turingMachineToolStripMenuItem1.Text = "Turingov stroj";
            this.turingMachineToolStripMenuItem1.Click += new System.EventHandler(this.turingMachineToolStripMenuItem_Click);
            // 
            // rAMSimulatorToolStripMenuItem
            // 
            this.rAMSimulatorToolStripMenuItem.Image = global::DusanRodina.SimStudio.Properties.Resources.RAM;
            this.rAMSimulatorToolStripMenuItem.Name = "rAMSimulatorToolStripMenuItem";
            this.rAMSimulatorToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.rAMSimulatorToolStripMenuItem.Text = "RAM";
            this.rAMSimulatorToolStripMenuItem.Click += new System.EventHandler(this.ramToolStripMenuItem_Click);
            // 
            // abacusMachineToolStripMenuItem1
            // 
            this.abacusMachineToolStripMenuItem1.Image = global::DusanRodina.SimStudio.Properties.Resources.Abacus;
            this.abacusMachineToolStripMenuItem1.Name = "abacusMachineToolStripMenuItem1";
            this.abacusMachineToolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            this.abacusMachineToolStripMenuItem1.Text = "Počítadlový stroj";
            this.abacusMachineToolStripMenuItem1.Click += new System.EventHandler(this.abacusMachineToolStripMenuItem_Click);
            // 
            // placeholderToolStripMenuItem
            // 
            this.placeholderToolStripMenuItem.MergeIndex = 1;
            this.placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
            this.placeholderToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.placeholderToolStripMenuItem.Text = "Placeholder";
            this.placeholderToolStripMenuItem.Visible = false;
            // 
            // windowsToolStripMenuItem1
            // 
            this.windowsToolStripMenuItem1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.windowsToolStripMenuItem1.MergeIndex = 9;
            this.windowsToolStripMenuItem1.Name = "windowsToolStripMenuItem1";
            this.windowsToolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.windowsToolStripMenuItem1.Text = "Okná";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aboutToolStripMenuItem1 });
            this.helpToolStripMenuItem1.MergeIndex = 10;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(73, 20);
            this.helpToolStripMenuItem1.Text = "Pomocník";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.aboutToolStripMenuItem1.Text = "O programe";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.MergeIndex = 9;
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.windowsToolStripMenuItem.Text = "Okná";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(65, 22);
            this.openToolStripButton.Text = "Otvoriť";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // simulatorsToolStripMenuItem
            // 
            this.simulatorsToolStripMenuItem.MergeIndex = 0;
            this.simulatorsToolStripMenuItem.Name = "simulatorsToolStripMenuItem";
            this.simulatorsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulatorsToolStripMenuItem.Text = "Simulátory";
            this.simulatorsToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.simulatorsToolStripMenuItem_Paint);
            // 
            // finiteAutomatonToolStripMenuItem
            // 
            this.finiteAutomatonToolStripMenuItem.Name = "finiteAutomatonToolStripMenuItem";
            this.finiteAutomatonToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.finiteAutomatonToolStripMenuItem.Text = "Konečný automat";
            this.finiteAutomatonToolStripMenuItem.Click += new System.EventHandler(this.finiteAutomatonToolStripMenuItem_Click);
            // 
            // stackAutomatonToolStripMenuItem
            // 
            this.stackAutomatonToolStripMenuItem.Name = "stackAutomatonToolStripMenuItem";
            this.stackAutomatonToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.stackAutomatonToolStripMenuItem.Text = "Zásobníkový automat";
            // 
            // turingMachineToolStripMenuItem
            // 
            this.turingMachineToolStripMenuItem.Name = "turingMachineToolStripMenuItem";
            this.turingMachineToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.turingMachineToolStripMenuItem.Text = "Turingov stroj";
            this.turingMachineToolStripMenuItem.Click += new System.EventHandler(this.turingMachineToolStripMenuItem_Click);
            // 
            // ramToolStripMenuItem
            // 
            this.ramToolStripMenuItem.Name = "ramToolStripMenuItem";
            this.ramToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ramToolStripMenuItem.Text = "RAM";
            this.ramToolStripMenuItem.Click += new System.EventHandler(this.ramToolStripMenuItem_Click);
            // 
            // abacusMachineToolStripMenuItem
            // 
            this.abacusMachineToolStripMenuItem.Name = "abacusMachineToolStripMenuItem";
            this.abacusMachineToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.abacusMachineToolStripMenuItem.Text = "Počítadlový stroj";
            this.abacusMachineToolStripMenuItem.Click += new System.EventHandler(this.abacusMachineToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.helpToolStripMenuItem.MergeIndex = 10;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.helpToolStripMenuItem.Text = "Pomocník";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "O programe";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // topToolStripPanel
            // 
            this.topToolStripPanel.Controls.Add(this.mainToolStrip);
            this.topToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topToolStripPanel.Location = new System.Drawing.Point(0, 24);
            this.topToolStripPanel.Name = "topToolStripPanel";
            this.topToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.topToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.topToolStripPanel.Size = new System.Drawing.Size(984, 25);
            // 
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openToolStripButton, this.toolStripSeparator1 });
            this.mainToolStrip.Location = new System.Drawing.Point(3, 0);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(83, 25);
            this.mainToolStrip.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.topToolStripPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sim Studio";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.topToolStripPanel.ResumeLayout(false);
            this.topToolStripPanel.PerformLayout();
            this.mainToolStrip.ResumeLayout(false);
            this.mainToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem simulatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finiteAutomatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turingMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abacusMachineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stackAutomatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripPanel topToolStripPanel;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem finiteAutomatonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pushdownAutomatonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turingMachineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rAMSimulatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abacusMachineToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}