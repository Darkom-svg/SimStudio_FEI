using System.ComponentModel;
using FEI.SimStudio.Components.Controls;
using FEI.TuringCore.Components;

namespace FEI.TrainingSimulator
{
    partial class TmTrainingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        private void InitializeComponent()
{
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TmTrainingForm));
    this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
    this.miFile = new System.Windows.Forms.ToolStripMenuItem();
    this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
    this.miSaveFile = new System.Windows.Forms.ToolStripMenuItem();
    this.miSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
    this.miExit = new System.Windows.Forms.ToolStripMenuItem();
    this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
    this.miCut = new System.Windows.Forms.ToolStripMenuItem();
    this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
    this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
    this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
    this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
    this.miFind = new System.Windows.Forms.ToolStripMenuItem();
    this.miReplace = new System.Windows.Forms.ToolStripMenuItem();
    this.miMachine = new System.Windows.Forms.ToolStripMenuItem();
    this.miTransitions = new System.Windows.Forms.ToolStripMenuItem();
    this.miAddTransition = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
    this.miTransitionFormat = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat10 = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
    this.miTFormat1 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat2 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat3 = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
    this.miTFormat4 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat5 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat6 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat7 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat8 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTFormat9 = new System.Windows.Forms.ToolStripMenuItem();
    this.miTape = new System.Windows.Forms.ToolStripMenuItem();
    this.miInsertSymbols = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
    this.miClearTape = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
    this.miExportTape = new System.Windows.Forms.ToolStripMenuItem();
    this.miImportTape = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
    this.miTapeStatistics = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
    this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
    this.miSimulation = new System.Windows.Forms.ToolStripMenuItem();
    this.miRun = new System.Windows.Forms.ToolStripMenuItem();
    this.miPause = new System.Windows.Forms.ToolStripMenuItem();
    this.miStep = new System.Windows.Forms.ToolStripMenuItem();
    this.miStop = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
    this.miBreaks = new System.Windows.Forms.ToolStripMenuItem();
    this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
    this.miWriteLog = new System.Windows.Forms.ToolStripMenuItem();
    this.miStoreOriginalTape = new System.Windows.Forms.ToolStripMenuItem();
    this.txtFind = new System.Windows.Forms.ToolStripTextBox();
    this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
    this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
    this.mainToolStrip = new System.Windows.Forms.ToolStrip();
    this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
    this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
    this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
    this.checkToolStripButton = new System.Windows.Forms.ToolStripButton();
    this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
    this.statusStrip = new System.Windows.Forms.StatusStrip();
    this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
    this.splitContainer2 = new System.Windows.Forms.SplitContainer();
    this.tcMain = new System.Windows.Forms.TabControl();
    this.taskSpecificationTab = new System.Windows.Forms.TabPage();
    this.taskSpecification = new System.Windows.Forms.WebBrowser();
    this.functionsTab = new System.Windows.Forms.TabPage();
    this.splitContainer1 = new System.Windows.Forms.SplitContainer();
    this.bAddTFunction = new System.Windows.Forms.Button();
    this.label5 = new System.Windows.Forms.Label();
    this.txtCode = new FEI.SimStudio.Components.Controls.SyntaxTextBox();
    this.pTests = new System.Windows.Forms.PictureBox();
    this.label6 = new System.Windows.Forms.Label();
    this.sbyTests = new System.Windows.Forms.VScrollBar();
    this.statesTab = new System.Windows.Forms.TabPage();
    this.bAddState = new System.Windows.Forms.Button();
    this.stateDiagramControl = new FEI.TuringCore.Components.StateDiagramControl();
    this.formalSpecificationTab = new System.Windows.Forms.TabPage();
    this.formalSpecifiaction = new System.Windows.Forms.WebBrowser();
    this.lstErrors = new System.Windows.Forms.ListBox();
    this.label7 = new System.Windows.Forms.Label();
    this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
    this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
    this.toolStripPanel1.SuspendLayout();
    this.menuStrip1.SuspendLayout();
    this.mainToolStrip.SuspendLayout();
    this.statusStrip.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
    this.splitContainer2.Panel1.SuspendLayout();
    this.splitContainer2.Panel2.SuspendLayout();
    this.splitContainer2.SuspendLayout();
    this.tcMain.SuspendLayout();
    this.taskSpecificationTab.SuspendLayout();
    this.functionsTab.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
    this.splitContainer1.Panel1.SuspendLayout();
    this.splitContainer1.Panel2.SuspendLayout();
    this.splitContainer1.SuspendLayout();
    ((System.ComponentModel.ISupportInitialize)(this.pTests)).BeginInit();
    this.statesTab.SuspendLayout();
    this.formalSpecificationTab.SuspendLayout();
    this.SuspendLayout();
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
    // menuStrip1
    // 
    resources.ApplyResources(this.menuStrip1, "menuStrip1");
    this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miEdit, this.miMachine, this.miSimulation, this.txtFind, this.helpToolStripMenuItem });
    this.menuStrip1.Name = "menuStrip1";
    // 
    // miFile
    // 
    this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miOpenFile, this.toolStripSeparator6, this.miSaveFile, this.miSaveAsFile, this.toolStripSeparator5, this.miExit });
    this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
    this.miFile.Name = "miFile";
    resources.ApplyResources(this.miFile, "miFile");
    // 
    // miOpenFile
    // 
    resources.ApplyResources(this.miOpenFile, "miOpenFile");
    this.miOpenFile.Name = "miOpenFile";
    this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
    // 
    // toolStripSeparator6
    // 
    this.toolStripSeparator6.Name = "toolStripSeparator6";
    resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
    // 
    // miSaveFile
    // 
    resources.ApplyResources(this.miSaveFile, "miSaveFile");
    this.miSaveFile.Name = "miSaveFile";
    this.miSaveFile.Click += new System.EventHandler(this.miSaveFile_Click);
    // 
    // miSaveAsFile
    // 
    resources.ApplyResources(this.miSaveAsFile, "miSaveAsFile");
    this.miSaveAsFile.Name = "miSaveAsFile";
    this.miSaveAsFile.Click += new System.EventHandler(this.miSaveAsFile_Click);
    // 
    // toolStripSeparator5
    // 
    this.toolStripSeparator5.Name = "toolStripSeparator5";
    resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
    // 
    // miExit
    // 
    this.miExit.Name = "miExit";
    resources.ApplyResources(this.miExit, "miExit");
    this.miExit.Click += new System.EventHandler(this.miExit_Click);
    // 
    // miEdit
    // 
    this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miCut, this.miCopy, this.miPaste, this.miDelete, this.toolStripMenuItem10, this.miSelectAll, this.toolStripMenuItem4, this.miFind, this.miReplace });
    this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
    this.miEdit.MergeIndex = 2;
    this.miEdit.Name = "miEdit";
    resources.ApplyResources(this.miEdit, "miEdit");
    // 
    // miCut
    // 
    resources.ApplyResources(this.miCut, "miCut");
    this.miCut.Name = "miCut";
    this.miCut.Click += new System.EventHandler(this.miCut_Click);
    // 
    // miCopy
    // 
    resources.ApplyResources(this.miCopy, "miCopy");
    this.miCopy.Name = "miCopy";
    this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
    // 
    // miPaste
    // 
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
    // toolStripMenuItem10
    // 
    this.toolStripMenuItem10.Name = "toolStripMenuItem10";
    resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
    // 
    // miSelectAll
    // 
    this.miSelectAll.Name = "miSelectAll";
    resources.ApplyResources(this.miSelectAll, "miSelectAll");
    this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
    // 
    // toolStripMenuItem4
    // 
    this.toolStripMenuItem4.Name = "toolStripMenuItem4";
    resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
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
    // miMachine
    // 
    this.miMachine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTransitions, this.miTape, this.toolStripMenuItem14, this.miSettings });
    this.miMachine.MergeAction = System.Windows.Forms.MergeAction.Insert;
    this.miMachine.MergeIndex = 3;
    this.miMachine.Name = "miMachine";
    resources.ApplyResources(this.miMachine, "miMachine");
    // 
    // miTransitions
    // 
    this.miTransitions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAddTransition, this.toolStripMenuItem12, this.miTransitionFormat });
    this.miTransitions.Name = "miTransitions";
    resources.ApplyResources(this.miTransitions, "miTransitions");
    // 
    // miAddTransition
    // 
    this.miAddTransition.Name = "miAddTransition";
    resources.ApplyResources(this.miAddTransition, "miAddTransition");
    this.miAddTransition.Click += new System.EventHandler(this.miAddTransition_Click);
    // 
    // toolStripMenuItem12
    // 
    this.toolStripMenuItem12.Name = "toolStripMenuItem12";
    resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
    // 
    // miTransitionFormat
    // 
    this.miTransitionFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTFormat10, this.toolStripSeparator2, this.miTFormat1, this.miTFormat2, this.miTFormat3, this.toolStripMenuItem13, this.miTFormat4, this.miTFormat5, this.miTFormat6, this.miTFormat7, this.miTFormat8, this.miTFormat9 });
    this.miTransitionFormat.Name = "miTransitionFormat";
    resources.ApplyResources(this.miTransitionFormat, "miTransitionFormat");
    // 
    // miTFormat10
    // 
    this.miTFormat10.Checked = true;
    this.miTFormat10.CheckState = System.Windows.Forms.CheckState.Checked;
    this.miTFormat10.Name = "miTFormat10";
    resources.ApplyResources(this.miTFormat10, "miTFormat10");
    this.miTFormat10.Click += new System.EventHandler(this.miTFormat10_Click);
    // 
    // toolStripSeparator2
    // 
    this.toolStripSeparator2.Name = "toolStripSeparator2";
    resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
    // 
    // miTFormat1
    // 
    this.miTFormat1.Name = "miTFormat1";
    resources.ApplyResources(this.miTFormat1, "miTFormat1");
    this.miTFormat1.Click += new System.EventHandler(this.miTFormat1_Click);
    // 
    // miTFormat2
    // 
    this.miTFormat2.Name = "miTFormat2";
    resources.ApplyResources(this.miTFormat2, "miTFormat2");
    this.miTFormat2.Click += new System.EventHandler(this.miTFormat2_Click);
    // 
    // miTFormat3
    // 
    this.miTFormat3.Name = "miTFormat3";
    resources.ApplyResources(this.miTFormat3, "miTFormat3");
    this.miTFormat3.Click += new System.EventHandler(this.miTFormat3_Click);
    // 
    // toolStripMenuItem13
    // 
    this.toolStripMenuItem13.Name = "toolStripMenuItem13";
    resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
    // 
    // miTFormat4
    // 
    this.miTFormat4.Name = "miTFormat4";
    resources.ApplyResources(this.miTFormat4, "miTFormat4");
    this.miTFormat4.Click += new System.EventHandler(this.miTFormat4_Click);
    // 
    // miTFormat5
    // 
    this.miTFormat5.Name = "miTFormat5";
    resources.ApplyResources(this.miTFormat5, "miTFormat5");
    this.miTFormat5.Click += new System.EventHandler(this.miTFormat5_Click);
    // 
    // miTFormat6
    // 
    this.miTFormat6.Name = "miTFormat6";
    resources.ApplyResources(this.miTFormat6, "miTFormat6");
    this.miTFormat6.Click += new System.EventHandler(this.miTFormat6_Click);
    // 
    // miTFormat7
    // 
    this.miTFormat7.Name = "miTFormat7";
    resources.ApplyResources(this.miTFormat7, "miTFormat7");
    this.miTFormat7.Click += new System.EventHandler(this.miTFormat7_Click);
    // 
    // miTFormat8
    // 
    this.miTFormat8.Name = "miTFormat8";
    resources.ApplyResources(this.miTFormat8, "miTFormat8");
    this.miTFormat8.Click += new System.EventHandler(this.miTFormat8_Click);
    // 
    // miTFormat9
    // 
    this.miTFormat9.Name = "miTFormat9";
    resources.ApplyResources(this.miTFormat9, "miTFormat9");
    this.miTFormat9.Click += new System.EventHandler(this.miTFormat9_Click);
    // 
    // miTape
    // 
    this.miTape.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miInsertSymbols, this.toolStripSeparator1, this.miClearTape, this.toolStripMenuItem5, this.miExportTape, this.miImportTape, this.toolStripMenuItem6, this.miTapeStatistics });
    this.miTape.Name = "miTape";
    resources.ApplyResources(this.miTape, "miTape");
    // 
    // miInsertSymbols
    // 
    this.miInsertSymbols.Name = "miInsertSymbols";
    resources.ApplyResources(this.miInsertSymbols, "miInsertSymbols");
    // 
    // toolStripSeparator1
    // 
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
    // 
    // miClearTape
    // 
    this.miClearTape.Name = "miClearTape";
    resources.ApplyResources(this.miClearTape, "miClearTape");
    // 
    // toolStripMenuItem5
    // 
    this.toolStripMenuItem5.Name = "toolStripMenuItem5";
    resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
    // 
    // miExportTape
    // 
    this.miExportTape.Name = "miExportTape";
    resources.ApplyResources(this.miExportTape, "miExportTape");
    // 
    // miImportTape
    // 
    this.miImportTape.Name = "miImportTape";
    resources.ApplyResources(this.miImportTape, "miImportTape");
    // 
    // toolStripMenuItem6
    // 
    this.toolStripMenuItem6.Name = "toolStripMenuItem6";
    resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
    // 
    // miTapeStatistics
    // 
    this.miTapeStatistics.Name = "miTapeStatistics";
    resources.ApplyResources(this.miTapeStatistics, "miTapeStatistics");
    // 
    // toolStripMenuItem14
    // 
    this.toolStripMenuItem14.Name = "toolStripMenuItem14";
    resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
    // 
    // miSettings
    // 
    this.miSettings.Name = "miSettings";
    resources.ApplyResources(this.miSettings, "miSettings");
    this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
    // 
    // miSimulation
    // 
    this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miRun, this.miPause, this.miStep, this.miStop, this.toolStripMenuItem9, this.miBreaks, this.toolStripMenuItem11, this.miWriteLog, this.miStoreOriginalTape });
    this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
    this.miSimulation.MergeIndex = 4;
    this.miSimulation.Name = "miSimulation";
    resources.ApplyResources(this.miSimulation, "miSimulation");
    // 
    // miRun
    // 
    resources.ApplyResources(this.miRun, "miRun");
    this.miRun.Name = "miRun";
    // 
    // miPause
    // 
    resources.ApplyResources(this.miPause, "miPause");
    this.miPause.Name = "miPause";
    // 
    // miStep
    // 
    this.miStep.Name = "miStep";
    resources.ApplyResources(this.miStep, "miStep");
    // 
    // miStop
    // 
    resources.ApplyResources(this.miStop, "miStop");
    this.miStop.Name = "miStop";
    // 
    // toolStripMenuItem9
    // 
    this.toolStripMenuItem9.Name = "toolStripMenuItem9";
    resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
    // 
    // miBreaks
    // 
    this.miBreaks.Name = "miBreaks";
    resources.ApplyResources(this.miBreaks, "miBreaks");
    // 
    // toolStripMenuItem11
    // 
    this.toolStripMenuItem11.Name = "toolStripMenuItem11";
    resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
    // 
    // miWriteLog
    // 
    this.miWriteLog.Checked = true;
    this.miWriteLog.CheckOnClick = true;
    this.miWriteLog.CheckState = System.Windows.Forms.CheckState.Checked;
    this.miWriteLog.Name = "miWriteLog";
    resources.ApplyResources(this.miWriteLog, "miWriteLog");
    // 
    // miStoreOriginalTape
    // 
    this.miStoreOriginalTape.Checked = true;
    this.miStoreOriginalTape.CheckOnClick = true;
    this.miStoreOriginalTape.CheckState = System.Windows.Forms.CheckState.Checked;
    this.miStoreOriginalTape.Name = "miStoreOriginalTape";
    resources.ApplyResources(this.miStoreOriginalTape, "miStoreOriginalTape");
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
    this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
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
    // mainToolStrip
    // 
    resources.ApplyResources(this.mainToolStrip, "mainToolStrip");
    this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.openToolStripButton, this.saveToolStripButton, this.toolStripSeparator3, this.checkToolStripButton, this.toolStripSeparator4 });
    this.mainToolStrip.Name = "mainToolStrip";
    // 
    // openToolStripButton
    // 
    this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
    this.openToolStripButton.Name = "openToolStripButton";
    this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
    // 
    // saveToolStripButton
    // 
    this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
    resources.ApplyResources(this.saveToolStripButton, "saveToolStripButton");
    this.saveToolStripButton.Name = "saveToolStripButton";
    this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
    // 
    // toolStripSeparator3
    // 
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
    // 
    // checkToolStripButton
    // 
    this.checkToolStripButton.Image = global::FEI.TrainingSimulator.Properties.Resources.validated;
    resources.ApplyResources(this.checkToolStripButton, "checkToolStripButton");
    this.checkToolStripButton.Name = "checkToolStripButton";
    this.checkToolStripButton.Click += new System.EventHandler(this.checkToolStripButton_Click);
    // 
    // toolStripSeparator4
    // 
    this.toolStripSeparator4.Name = "toolStripSeparator4";
    resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
    // 
    // statusStrip
    // 
    this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
    this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
    resources.ApplyResources(this.statusStrip, "statusStrip");
    this.statusStrip.Name = "statusStrip";
    // 
    // statusLabel
    // 
    this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
    this.statusLabel.MergeAction = System.Windows.Forms.MergeAction.Replace;
    this.statusLabel.MergeIndex = 0;
    this.statusLabel.Name = "statusLabel";
    resources.ApplyResources(this.statusLabel, "statusLabel");
    // 
    // splitContainer2
    // 
    resources.ApplyResources(this.splitContainer2, "splitContainer2");
    this.splitContainer2.Name = "splitContainer2";
    // 
    // splitContainer2.Panel1
    // 
    this.splitContainer2.Panel1.Controls.Add(this.tcMain);
    // 
    // splitContainer2.Panel2
    // 
    this.splitContainer2.Panel2.Controls.Add(this.lstErrors);
    this.splitContainer2.Panel2.Controls.Add(this.label7);
    this.splitContainer2.Panel2Collapsed = true;
    // 
    // tcMain
    // 
    resources.ApplyResources(this.tcMain, "tcMain");
    this.tcMain.Controls.Add(this.taskSpecificationTab);
    this.tcMain.Controls.Add(this.functionsTab);
    this.tcMain.Controls.Add(this.statesTab);
    this.tcMain.Controls.Add(this.formalSpecificationTab);
    this.tcMain.Name = "tcMain";
    this.tcMain.SelectedIndex = 0;
    this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
    // 
    // taskSpecificationTab
    // 
    this.taskSpecificationTab.Controls.Add(this.taskSpecification);
    resources.ApplyResources(this.taskSpecificationTab, "taskSpecificationTab");
    this.taskSpecificationTab.Name = "taskSpecificationTab";
    this.taskSpecificationTab.UseVisualStyleBackColor = true;
    // 
    // taskSpecification
    // 
    this.taskSpecification.AllowWebBrowserDrop = false;
    resources.ApplyResources(this.taskSpecification, "taskSpecification");
    this.taskSpecification.Name = "taskSpecification";
    this.taskSpecification.WebBrowserShortcutsEnabled = false;
    // 
    // functionsTab
    // 
    this.functionsTab.Controls.Add(this.splitContainer1);
    resources.ApplyResources(this.functionsTab, "functionsTab");
    this.functionsTab.Name = "functionsTab";
    this.functionsTab.UseVisualStyleBackColor = true;
    // 
    // splitContainer1
    // 
    resources.ApplyResources(this.splitContainer1, "splitContainer1");
    this.splitContainer1.Name = "splitContainer1";
    // 
    // splitContainer1.Panel1
    // 
    this.splitContainer1.Panel1.Controls.Add(this.bAddTFunction);
    this.splitContainer1.Panel1.Controls.Add(this.label5);
    this.splitContainer1.Panel1.Controls.Add(this.txtCode);
    // 
    // splitContainer1.Panel2
    // 
    this.splitContainer1.Panel2.Controls.Add(this.pTests);
    this.splitContainer1.Panel2.Controls.Add(this.label6);
    this.splitContainer1.Panel2.Controls.Add(this.sbyTests);
    // 
    // bAddTFunction
    // 
    resources.ApplyResources(this.bAddTFunction, "bAddTFunction");
    this.bAddTFunction.Name = "bAddTFunction";
    this.bAddTFunction.UseVisualStyleBackColor = true;
    this.bAddTFunction.Click += new System.EventHandler(this.bAddTFunction_Click);
    // 
    // label5
    // 
    resources.ApplyResources(this.label5, "label5");
    this.label5.Name = "label5";
    // 
    // txtCode
    // 
    resources.ApplyResources(this.txtCode, "txtCode");
    this.txtCode.HideSelection = true;
    this.txtCode.Name = "txtCode";
    this.txtCode.SelectedText = "";
    this.txtCode.SelectionLength = 0;
    this.txtCode.SelectionStart = 0;
    // 
    // pTests
    // 
    resources.ApplyResources(this.pTests, "pTests");
    this.pTests.Name = "pTests";
    this.pTests.TabStop = false;
    this.pTests.Paint += new System.Windows.Forms.PaintEventHandler(this.pTests_Paint);
    this.pTests.Resize += new System.EventHandler(this.pTests_Resize);
    // 
    // label6
    // 
    resources.ApplyResources(this.label6, "label6");
    this.label6.Name = "label6";
    // 
    // sbyTests
    // 
    resources.ApplyResources(this.sbyTests, "sbyTests");
    this.sbyTests.Name = "sbyTests";
    this.sbyTests.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyTests_Scroll);
    // 
    // statesTab
    // 
    this.statesTab.Controls.Add(this.bAddState);
    this.statesTab.Controls.Add(this.stateDiagramControl);
    resources.ApplyResources(this.statesTab, "statesTab");
    this.statesTab.Name = "statesTab";
    this.statesTab.UseVisualStyleBackColor = true;
    // 
    // bAddState
    // 
    resources.ApplyResources(this.bAddState, "bAddState");
    this.bAddState.Name = "bAddState";
    this.bAddState.UseVisualStyleBackColor = true;
    this.bAddState.Click += new System.EventHandler(this.bAddState_Click);
    // 
    // stateDiagramControl
    // 
    resources.ApplyResources(this.stateDiagramControl, "stateDiagramControl");
    this.stateDiagramControl.Name = "stateDiagramControl";
    this.stateDiagramControl.TuringMachine = null;
    // 
    // formalSpecificationTab
    // 
    this.formalSpecificationTab.Controls.Add(this.formalSpecifiaction);
    resources.ApplyResources(this.formalSpecificationTab, "formalSpecificationTab");
    this.formalSpecificationTab.Name = "formalSpecificationTab";
    this.formalSpecificationTab.UseVisualStyleBackColor = true;
    // 
    // formalSpecifiaction
    // 
    this.formalSpecifiaction.AllowWebBrowserDrop = false;
    resources.ApplyResources(this.formalSpecifiaction, "formalSpecifiaction");
    this.formalSpecifiaction.Name = "formalSpecifiaction";
    this.formalSpecifiaction.WebBrowserShortcutsEnabled = false;
    // 
    // lstErrors
    // 
    resources.ApplyResources(this.lstErrors, "lstErrors");
    this.lstErrors.FormattingEnabled = true;
    this.lstErrors.Name = "lstErrors";
    // 
    // label7
    // 
    resources.ApplyResources(this.label7, "label7");
    this.label7.Name = "label7";
    // 
    // saveFileDialog1
    // 
    this.saveFileDialog1.DefaultExt = "tm";
    resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
    this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
    // 
    // openFileDialog1
    // 
    resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
    // 
    // TmTrainingForm
    // 
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
    resources.ApplyResources(this, "$this");
    this.Controls.Add(this.splitContainer2);
    this.Controls.Add(this.toolStripPanel1);
    this.Controls.Add(this.statusStrip);
    this.Name = "TmTrainingForm";
    this.Load += new System.EventHandler(this.frmTuringMachine_Load);
    this.toolStripPanel1.ResumeLayout(false);
    this.toolStripPanel1.PerformLayout();
    this.menuStrip1.ResumeLayout(false);
    this.menuStrip1.PerformLayout();
    this.mainToolStrip.ResumeLayout(false);
    this.mainToolStrip.PerformLayout();
    this.statusStrip.ResumeLayout(false);
    this.statusStrip.PerformLayout();
    this.splitContainer2.Panel1.ResumeLayout(false);
    this.splitContainer2.Panel2.ResumeLayout(false);
    this.splitContainer2.Panel2.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
    this.splitContainer2.ResumeLayout(false);
    this.tcMain.ResumeLayout(false);
    this.taskSpecificationTab.ResumeLayout(false);
    this.functionsTab.ResumeLayout(false);
    this.splitContainer1.Panel1.ResumeLayout(false);
    this.splitContainer1.Panel1.PerformLayout();
    this.splitContainer1.Panel2.ResumeLayout(false);
    this.splitContainer1.Panel2.PerformLayout();
    ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
    this.splitContainer1.ResumeLayout(false);
    ((System.ComponentModel.ISupportInitialize)(this.pTests)).EndInit();
    this.statesTab.ResumeLayout(false);
    this.formalSpecificationTab.ResumeLayout(false);
    this.ResumeLayout(false);
    this.PerformLayout();
}

        private System.Windows.Forms.PictureBox pTests;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.VScrollBar sbyTests;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.ToolStripButton openToolStripButton;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;

        private System.Windows.Forms.Button bAddState;

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem miExit;

        private System.Windows.Forms.ToolStripMenuItem miSaveFile;
        private System.Windows.Forms.ToolStripMenuItem miSaveAsFile;

        private System.Windows.Forms.ToolStripMenuItem miFile;

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;

        private System.Windows.Forms.WebBrowser taskSpecification;

        private System.Windows.Forms.WebBrowser formalSpecifiaction;

        private System.Windows.Forms.ListBox lstErrors;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Button bAddTFunction;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private FEI.SimStudio.Components.Controls.SyntaxTextBox txtCode;

        private FEI.TuringCore.Components.StateDiagramControl stateDiagramControl;

        private System.Windows.Forms.TabPage taskSpecificationTab;

        private System.Windows.Forms.TabPage functionsTab;

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage formalSpecificationTab;
        private System.Windows.Forms.TabPage statesTab;

        private System.Windows.Forms.SplitContainer splitContainer2;

        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miFind;
        private System.Windows.Forms.ToolStripMenuItem miReplace;
        private System.Windows.Forms.ToolStripMenuItem miMachine;
        private System.Windows.Forms.ToolStripMenuItem miTransitions;
        private System.Windows.Forms.ToolStripMenuItem miAddTransition;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem miTransitionFormat;
        private System.Windows.Forms.ToolStripMenuItem miTFormat10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miTFormat1;
        private System.Windows.Forms.ToolStripMenuItem miTFormat2;
        private System.Windows.Forms.ToolStripMenuItem miTFormat3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem miTFormat4;
        private System.Windows.Forms.ToolStripMenuItem miTFormat5;
        private System.Windows.Forms.ToolStripMenuItem miTFormat6;
        private System.Windows.Forms.ToolStripMenuItem miTFormat7;
        private System.Windows.Forms.ToolStripMenuItem miTFormat8;
        private System.Windows.Forms.ToolStripMenuItem miTFormat9;
        private System.Windows.Forms.ToolStripMenuItem miTape;
        private System.Windows.Forms.ToolStripMenuItem miInsertSymbols;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miClearTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miExportTape;
        private System.Windows.Forms.ToolStripMenuItem miImportTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem miTapeStatistics;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miSimulation;
        private System.Windows.Forms.ToolStripMenuItem miRun;
        private System.Windows.Forms.ToolStripMenuItem miPause;
        private System.Windows.Forms.ToolStripMenuItem miStep;
        private System.Windows.Forms.ToolStripMenuItem miStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem miBreaks;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem miWriteLog;
        private System.Windows.Forms.ToolStripMenuItem miStoreOriginalTape;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton checkToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

        #endregion
    }
}