using System.Windows.Forms;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Controls.RegisterList;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine {
	partial class AbacusMachineForm
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

            if (Application.OpenForms.Count == 0)
                Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
	        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbacusMachineForm));
	        FEI.SimStudio.Components.Registers.InfiniteRegisters infiniteRegisters1 = new FEI.SimStudio.Components.Registers.InfiniteRegisters();
	        this.splitContainer1 = new System.Windows.Forms.SplitContainer();
	        this.tabControl1 = new System.Windows.Forms.TabControl();
	        this.tabCode = new System.Windows.Forms.TabPage();
	        this.speedPanel = new System.Windows.Forms.Panel();
	        this.tbSpeed = new System.Windows.Forms.TrackBar();
	        this.label3 = new System.Windows.Forms.Label();
	        this.txtCode = new FEI.SimStudio.Components.Controls.SyntaxTextBox();
	        this.tabSimulation = new System.Windows.Forms.TabPage();
	        this.pSimulation = new System.Windows.Forms.PictureBox();
	        this.verticalScroll = new System.Windows.Forms.VScrollBar();
	        this.lstRegisters = new FEI.SimStudio.Components.Controls.RegisterList.RegisterList();
	        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	        this.miFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miNewFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
	        this.miSaveFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
	        this.miExit = new System.Windows.Forms.ToolStripMenuItem();
	        this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
	        this.miCut = new System.Windows.Forms.ToolStripMenuItem();
	        this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
	        this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
	        this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
	        this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
	        this.miFind = new System.Windows.Forms.ToolStripMenuItem();
	        this.miReplace = new System.Windows.Forms.ToolStripMenuItem();
	        this.autokódToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.miAddValue = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSubstractValue = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
	        this.miCopyRegister = new System.Windows.Forms.ToolStripMenuItem();
	        this.miMoveRegister = new System.Windows.Forms.ToolStripMenuItem();
	        this.miClearRegister = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSimulation = new System.Windows.Forms.ToolStripMenuItem();
	        this.miRun = new System.Windows.Forms.ToolStripMenuItem();
	        this.miPause = new System.Windows.Forms.ToolStripMenuItem();
	        this.miStep = new System.Windows.Forms.ToolStripMenuItem();
	        this.miStop = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
	        this.miBreaks = new System.Windows.Forms.ToolStripMenuItem();
	        this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.miTools = new System.Windows.Forms.ToolStripMenuItem();
	        this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
	        this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
	        this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
	        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
	        this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
	        this.mainToolStrip = new System.Windows.Forms.ToolStrip();
	        this.newStripButton = new System.Windows.Forms.ToolStripButton();
	        this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
	        this.runToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.breakToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.stopToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
	        this.stepToolStripButton = new System.Windows.Forms.ToolStripButton();
	        this.statusStrip = new System.Windows.Forms.StatusStrip();
	        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
	        this.splitContainer1.Panel1.SuspendLayout();
	        this.splitContainer1.Panel2.SuspendLayout();
	        this.splitContainer1.SuspendLayout();
	        this.tabControl1.SuspendLayout();
	        this.tabCode.SuspendLayout();
	        this.speedPanel.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
	        this.tabSimulation.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pSimulation)).BeginInit();
	        this.menuStrip1.SuspendLayout();
	        this.toolStripPanel1.SuspendLayout();
	        this.mainToolStrip.SuspendLayout();
	        this.statusStrip.SuspendLayout();
	        this.SuspendLayout();
	        // 
	        // splitContainer1
	        // 
	        resources.ApplyResources(this.splitContainer1, "splitContainer1");
	        this.splitContainer1.Name = "splitContainer1";
	        // 
	        // splitContainer1.Panel1
	        // 
	        this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
	        // 
	        // splitContainer1.Panel2
	        // 
	        this.splitContainer1.Panel2.Controls.Add(this.lstRegisters);
	        // 
	        // tabControl1
	        // 
	        resources.ApplyResources(this.tabControl1, "tabControl1");
	        this.tabControl1.Controls.Add(this.tabCode);
	        this.tabControl1.Controls.Add(this.tabSimulation);
	        this.tabControl1.Name = "tabControl1";
	        this.tabControl1.SelectedIndex = 0;
	        this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
	        // 
	        // tabCode
	        // 
	        this.tabCode.Controls.Add(this.speedPanel);
	        this.tabCode.Controls.Add(this.txtCode);
	        resources.ApplyResources(this.tabCode, "tabCode");
	        this.tabCode.Name = "tabCode";
	        this.tabCode.UseVisualStyleBackColor = true;
	        // 
	        // speedPanel
	        // 
	        this.speedPanel.BackColor = System.Drawing.Color.White;
	        this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.speedPanel.Controls.Add(this.tbSpeed);
	        this.speedPanel.Controls.Add(this.label3);
	        resources.ApplyResources(this.speedPanel, "speedPanel");
	        this.speedPanel.Name = "speedPanel";
	        // 
	        // tbSpeed
	        // 
	        resources.ApplyResources(this.tbSpeed, "tbSpeed");
	        this.tbSpeed.Maximum = 20;
	        this.tbSpeed.Name = "tbSpeed";
	        this.tbSpeed.Value = 19;
	        this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
	        // 
	        // label3
	        // 
	        resources.ApplyResources(this.label3, "label3");
	        this.label3.BackColor = System.Drawing.Color.Transparent;
	        this.label3.Name = "label3";
	        // 
	        // txtCode
	        // 
	        resources.ApplyResources(this.txtCode, "txtCode");
	        this.txtCode.HideSelection = true;
	        this.txtCode.Name = "txtCode";
	        this.txtCode.SelectedText = "";
	        this.txtCode.SelectionLength = 0;
	        this.txtCode.SelectionStart = 0;
	        this.txtCode.TextChanged += new FEI.SimStudio.Components.Controls.SyntaxTextBox.TextChangedEventHandler(this.txtCode_TextChanged);
	        // 
	        // tabSimulation
	        // 
	        this.tabSimulation.Controls.Add(this.pSimulation);
	        this.tabSimulation.Controls.Add(this.verticalScroll);
	        resources.ApplyResources(this.tabSimulation, "tabSimulation");
	        this.tabSimulation.Name = "tabSimulation";
	        this.tabSimulation.UseVisualStyleBackColor = true;
	        // 
	        // pSimulation
	        // 
	        resources.ApplyResources(this.pSimulation, "pSimulation");
	        this.pSimulation.Name = "pSimulation";
	        this.pSimulation.TabStop = false;
	        this.pSimulation.Paint += new System.Windows.Forms.PaintEventHandler(this.pSimulation_Paint);
	        this.pSimulation.Resize += new System.EventHandler(this.pSimulation_Resize);
	        // 
	        // verticalScroll
	        // 
	        resources.ApplyResources(this.verticalScroll, "verticalScroll");
	        this.verticalScroll.Name = "verticalScroll";
	        this.verticalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.verticalScroll_Scroll);
	        this.verticalScroll.ValueChanged += new System.EventHandler(this.verticalScroll_ValueChanged);
	        // 
	        // lstRegisters
	        // 
	        resources.ApplyResources(this.lstRegisters, "lstRegisters");
	        this.lstRegisters.MaximalCount = 10000;
	        this.lstRegisters.Name = "lstRegisters";
	        this.lstRegisters.Reading = false;
	        this.lstRegisters.ReadingPos = 0;
	        this.lstRegisters.Regs = infiniteRegisters1;
	        this.lstRegisters.ScrollValue = 0;
	        this.lstRegisters.Writing = false;
	        this.lstRegisters.WritingPos = 0;
	        this.lstRegisters.RegisterChanged += new FEI.SimStudio.Components.Controls.RegisterList.RegisterList.RegisterChangedEventHandler(this.lstRegisters_RegisterChanged);
	        // 
	        // menuStrip1
	        // 
	        resources.ApplyResources(this.menuStrip1, "menuStrip1");
	        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miEdit, this.autokódToolStripMenuItem, this.miSimulation, this.miTools, this.miHelp });
	        this.menuStrip1.Name = "menuStrip1";
	        // 
	        // miFile
	        // 
	        this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewFile, this.miOpenFile, this.toolStripMenuItem2, this.miSaveFile, this.miSaveAsFile, this.toolStripMenuItem1, this.miExit });
	        this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miFile.MergeIndex = 1;
	        this.miFile.Name = "miFile";
	        resources.ApplyResources(this.miFile, "miFile");
	        // 
	        // miNewFile
	        // 
	        this.miNewFile.Image = global::FEI.AbacusMachine.Properties.Resources.small_new;
	        resources.ApplyResources(this.miNewFile, "miNewFile");
	        this.miNewFile.Name = "miNewFile";
	        this.miNewFile.Click += new System.EventHandler(this.miNewFile_Click);
	        // 
	        // miOpenFile
	        // 
	        this.miOpenFile.Image = global::FEI.AbacusMachine.Properties.Resources.open;
	        resources.ApplyResources(this.miOpenFile, "miOpenFile");
	        this.miOpenFile.Name = "miOpenFile";
	        this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
	        // 
	        // toolStripMenuItem2
	        // 
	        this.toolStripMenuItem2.Name = "toolStripMenuItem2";
	        resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
	        // 
	        // miSaveFile
	        // 
	        this.miSaveFile.Image = global::FEI.AbacusMachine.Properties.Resources.save;
	        resources.ApplyResources(this.miSaveFile, "miSaveFile");
	        this.miSaveFile.Name = "miSaveFile";
	        this.miSaveFile.Click += new System.EventHandler(this.miSaveFile_Click);
	        // 
	        // miSaveAsFile
	        // 
	        this.miSaveAsFile.Image = global::FEI.AbacusMachine.Properties.Resources.save;
	        this.miSaveAsFile.Name = "miSaveAsFile";
	        resources.ApplyResources(this.miSaveAsFile, "miSaveAsFile");
	        this.miSaveAsFile.Click += new System.EventHandler(this.miSaveAsFile_Click);
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
	        // miEdit
	        // 
	        this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miCut, this.miCopy, this.miPaste, this.miDelete, this.toolStripMenuItem4, this.miSelectAll, this.toolStripMenuItem3, this.miFind, this.miReplace });
	        this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miEdit.MergeIndex = 2;
	        this.miEdit.Name = "miEdit";
	        resources.ApplyResources(this.miEdit, "miEdit");
	        // 
	        // miCut
	        // 
	        this.miCut.Image = global::FEI.AbacusMachine.Properties.Resources.small_cut;
	        resources.ApplyResources(this.miCut, "miCut");
	        this.miCut.Name = "miCut";
	        this.miCut.Click += new System.EventHandler(this.miCut_Click);
	        // 
	        // miCopy
	        // 
	        this.miCopy.Image = global::FEI.AbacusMachine.Properties.Resources.copy;
	        resources.ApplyResources(this.miCopy, "miCopy");
	        this.miCopy.Name = "miCopy";
	        this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
	        // 
	        // miPaste
	        // 
	        this.miPaste.Image = global::FEI.AbacusMachine.Properties.Resources.small_paste;
	        resources.ApplyResources(this.miPaste, "miPaste");
	        this.miPaste.Name = "miPaste";
	        this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
	        // 
	        // miDelete
	        // 
	        this.miDelete.Name = "miDelete";
	        resources.ApplyResources(this.miDelete, "miDelete");
	        this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
	        // 
	        // toolStripMenuItem4
	        // 
	        this.toolStripMenuItem4.Name = "toolStripMenuItem4";
	        resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
	        // 
	        // miSelectAll
	        // 
	        this.miSelectAll.Name = "miSelectAll";
	        resources.ApplyResources(this.miSelectAll, "miSelectAll");
	        this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
	        // 
	        // toolStripMenuItem3
	        // 
	        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
	        resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
	        // 
	        // miFind
	        // 
	        this.miFind.Name = "miFind";
	        resources.ApplyResources(this.miFind, "miFind");
	        this.miFind.Click += new System.EventHandler(this.miFind_Click);
	        // 
	        // miReplace
	        // 
	        this.miReplace.Name = "miReplace";
	        resources.ApplyResources(this.miReplace, "miReplace");
	        this.miReplace.Click += new System.EventHandler(this.miReplace_Click);
	        // 
	        // autokódToolStripMenuItem
	        // 
	        this.autokódToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAddValue, this.miSubstractValue, this.toolStripMenuItem6, this.miCopyRegister, this.miMoveRegister, this.miClearRegister });
	        this.autokódToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.autokódToolStripMenuItem.MergeIndex = 3;
	        this.autokódToolStripMenuItem.Name = "autokódToolStripMenuItem";
	        resources.ApplyResources(this.autokódToolStripMenuItem, "autokódToolStripMenuItem");
	        // 
	        // miAddValue
	        // 
	        this.miAddValue.Name = "miAddValue";
	        resources.ApplyResources(this.miAddValue, "miAddValue");
	        this.miAddValue.Click += new System.EventHandler(this.miAddValue_Click);
	        // 
	        // miSubstractValue
	        // 
	        this.miSubstractValue.Name = "miSubstractValue";
	        resources.ApplyResources(this.miSubstractValue, "miSubstractValue");
	        this.miSubstractValue.Click += new System.EventHandler(this.miSubstractValue_Click);
	        // 
	        // toolStripMenuItem6
	        // 
	        this.toolStripMenuItem6.Name = "toolStripMenuItem6";
	        resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
	        // 
	        // miCopyRegister
	        // 
	        this.miCopyRegister.Name = "miCopyRegister";
	        resources.ApplyResources(this.miCopyRegister, "miCopyRegister");
	        this.miCopyRegister.Click += new System.EventHandler(this.miCopyRegister_Click);
	        // 
	        // miMoveRegister
	        // 
	        this.miMoveRegister.Name = "miMoveRegister";
	        resources.ApplyResources(this.miMoveRegister, "miMoveRegister");
	        this.miMoveRegister.Click += new System.EventHandler(this.miMoveRegister_Click);
	        // 
	        // miClearRegister
	        // 
	        this.miClearRegister.Name = "miClearRegister";
	        resources.ApplyResources(this.miClearRegister, "miClearRegister");
	        this.miClearRegister.Click += new System.EventHandler(this.miClearRegister_Click);
	        // 
	        // miSimulation
	        // 
	        this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miRun, this.miPause, this.miStep, this.miStop, this.toolStripMenuItem5, this.miBreaks, this.resetToolStripMenuItem });
	        this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miSimulation.MergeIndex = 4;
	        this.miSimulation.Name = "miSimulation";
	        resources.ApplyResources(this.miSimulation, "miSimulation");
	        // 
	        // miRun
	        // 
	        this.miRun.Image = global::FEI.AbacusMachine.Properties.Resources.run;
	        resources.ApplyResources(this.miRun, "miRun");
	        this.miRun.Name = "miRun";
	        this.miRun.Click += new System.EventHandler(this.miRun_Click);
	        // 
	        // miPause
	        // 
	        this.miPause.Image = global::FEI.AbacusMachine.Properties.Resources.pause;
	        resources.ApplyResources(this.miPause, "miPause");
	        this.miPause.Name = "miPause";
	        this.miPause.Click += new System.EventHandler(this.miPause_Click);
	        // 
	        // miStep
	        // 
	        this.miStep.Image = global::FEI.AbacusMachine.Properties.Resources.next;
	        this.miStep.Name = "miStep";
	        resources.ApplyResources(this.miStep, "miStep");
	        this.miStep.Click += new System.EventHandler(this.miStep_Click);
	        // 
	        // miStop
	        // 
	        this.miStop.Image = global::FEI.AbacusMachine.Properties.Resources.stop;
	        resources.ApplyResources(this.miStop, "miStop");
	        this.miStop.Name = "miStop";
	        this.miStop.Click += new System.EventHandler(this.miStop_Click);
	        // 
	        // toolStripMenuItem5
	        // 
	        this.toolStripMenuItem5.Name = "toolStripMenuItem5";
	        resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
	        // 
	        // miBreaks
	        // 
	        this.miBreaks.Name = "miBreaks";
	        resources.ApplyResources(this.miBreaks, "miBreaks");
	        // 
	        // resetToolStripMenuItem
	        // 
	        this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
	        resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
	        this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
	        // 
	        // miTools
	        // 
	        this.miTools.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miTools.MergeIndex = 5;
	        this.miTools.Name = "miTools";
	        resources.ApplyResources(this.miTools, "miTools");
	        // 
	        // miHelp
	        // 
	        this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout, this.languageToolStripMenuItem });
	        this.miHelp.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
	        this.miHelp.MergeIndex = 10;
	        this.miHelp.Name = "miHelp";
	        resources.ApplyResources(this.miHelp, "miHelp");
	        // 
	        // miAbout
	        // 
	        this.miAbout.MergeAction = System.Windows.Forms.MergeAction.Replace;
	        this.miAbout.Name = "miAbout";
	        resources.ApplyResources(this.miAbout, "miAbout");
	        this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
	        // 
	        // languageToolStripMenuItem
	        // 
	        this.languageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Remove;
	        this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
	        resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
	        // 
	        // openFileDialog1
	        // 
	        this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
	        // 
	        // saveFileDialog1
	        // 
	        this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
	        // 
	        // toolStripPanel1
	        // 
	        this.toolStripPanel1.Controls.Add(this.menuStrip1);
	        this.toolStripPanel1.Controls.Add(this.mainToolStrip);
	        resources.ApplyResources(this.toolStripPanel1, "toolStripPanel1");
	        this.toolStripPanel1.Name = "toolStripPanel1";
	        this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
	        this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
	        // 
	        // mainToolStrip
	        // 
	        resources.ApplyResources(this.mainToolStrip, "mainToolStrip");
	        this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.newStripButton, this.openToolStripButton, this.saveToolStripButton, this.toolStripSeparator3, this.runToolStripButton, this.breakToolStripButton, this.stopToolStripButton, this.toolStripSeparator4, this.stepToolStripButton });
	        this.mainToolStrip.Name = "mainToolStrip";
	        // 
	        // newStripButton
	        // 
	        this.newStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.newStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.small_new;
	        resources.ApplyResources(this.newStripButton, "newStripButton");
	        this.newStripButton.Name = "newStripButton";
	        this.newStripButton.Click += new System.EventHandler(this.newStripButton_Click);
	        // 
	        // openToolStripButton
	        // 
	        this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.openToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.open;
	        resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
	        this.openToolStripButton.Name = "openToolStripButton";
	        this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
	        // 
	        // saveToolStripButton
	        // 
	        this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.saveToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.save;
	        resources.ApplyResources(this.saveToolStripButton, "saveToolStripButton");
	        this.saveToolStripButton.Name = "saveToolStripButton";
	        this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
	        // 
	        // toolStripSeparator3
	        // 
	        this.toolStripSeparator3.Name = "toolStripSeparator3";
	        resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
	        // 
	        // runToolStripButton
	        // 
	        this.runToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.run;
	        resources.ApplyResources(this.runToolStripButton, "runToolStripButton");
	        this.runToolStripButton.Name = "runToolStripButton";
	        this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
	        // 
	        // breakToolStripButton
	        // 
	        this.breakToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.pause;
	        resources.ApplyResources(this.breakToolStripButton, "breakToolStripButton");
	        this.breakToolStripButton.Name = "breakToolStripButton";
	        this.breakToolStripButton.Click += new System.EventHandler(this.breakToolStripButton_Click);
	        // 
	        // stopToolStripButton
	        // 
	        resources.ApplyResources(this.stopToolStripButton, "stopToolStripButton");
	        this.stopToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.stop;
	        this.stopToolStripButton.Name = "stopToolStripButton";
	        this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
	        // 
	        // toolStripSeparator4
	        // 
	        this.toolStripSeparator4.Name = "toolStripSeparator4";
	        resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
	        // 
	        // stepToolStripButton
	        // 
	        this.stepToolStripButton.Image = global::FEI.AbacusMachine.Properties.Resources.next;
	        resources.ApplyResources(this.stepToolStripButton, "stepToolStripButton");
	        this.stepToolStripButton.Name = "stepToolStripButton";
	        this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
	        // 
	        // statusStrip
	        // 
	        this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
	        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
	        resources.ApplyResources(this.statusStrip, "statusStrip");
	        this.statusStrip.Name = "statusStrip";
	        // 
	        // lblStatus
	        // 
	        this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
	        this.lblStatus.MergeAction = System.Windows.Forms.MergeAction.Replace;
	        this.lblStatus.MergeIndex = 0;
	        this.lblStatus.Name = "lblStatus";
	        resources.ApplyResources(this.lblStatus, "lblStatus");
	        // 
	        // AbacusMachineForm
	        // 
	        resources.ApplyResources(this, "$this");
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	        this.Controls.Add(this.splitContainer1);
	        this.Controls.Add(this.toolStripPanel1);
	        this.Controls.Add(this.statusStrip);
	        this.DoubleBuffered = true;
	        this.MainMenuStrip = this.menuStrip1;
	        this.Name = "AbacusMachineForm";
	        this.Load += new System.EventHandler(this.AbacusMachineForm_Load);
	        this.splitContainer1.Panel1.ResumeLayout(false);
	        this.splitContainer1.Panel2.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
	        this.splitContainer1.ResumeLayout(false);
	        this.tabControl1.ResumeLayout(false);
	        this.tabCode.ResumeLayout(false);
	        this.speedPanel.ResumeLayout(false);
	        this.speedPanel.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
	        this.tabSimulation.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.pSimulation)).EndInit();
	        this.menuStrip1.ResumeLayout(false);
	        this.menuStrip1.PerformLayout();
	        this.toolStripPanel1.ResumeLayout(false);
	        this.toolStripPanel1.PerformLayout();
	        this.mainToolStrip.ResumeLayout(false);
	        this.mainToolStrip.PerformLayout();
	        this.statusStrip.ResumeLayout(false);
	        this.statusStrip.PerformLayout();
	        this.ResumeLayout(false);
	        this.PerformLayout();
        }

        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNewFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miSaveFile;
        private System.Windows.Forms.ToolStripMenuItem miSaveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miFind;
        private System.Windows.Forms.ToolStripMenuItem miReplace;
        private System.Windows.Forms.ToolStripMenuItem miSimulation;
        private System.Windows.Forms.ToolStripMenuItem miRun;
        private System.Windows.Forms.ToolStripMenuItem miPause;
        private System.Windows.Forms.ToolStripMenuItem miStep;
        private System.Windows.Forms.ToolStripMenuItem miStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miBreaks;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private FEI.SimStudio.Components.Controls.SyntaxTextBox txtCode;
        private FEI.SimStudio.Components.Controls.RegisterList.RegisterList lstRegisters;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCode;
        private System.Windows.Forms.TabPage tabSimulation;
        private System.Windows.Forms.PictureBox pSimulation;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripMenuItem autokódToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miCopyRegister;
        private System.Windows.Forms.ToolStripMenuItem miAddValue;
        private System.Windows.Forms.ToolStripMenuItem miSubstractValue;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem miMoveRegister;
        private System.Windows.Forms.ToolStripMenuItem miClearRegister;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.VScrollBar verticalScroll;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ToolStripButton breakToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton stepToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel speedPanel;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label3;
    }
}

