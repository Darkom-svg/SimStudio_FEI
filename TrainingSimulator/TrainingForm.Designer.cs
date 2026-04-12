using System.ComponentModel;

namespace TrainingSimulator
{
    partial class TrainingForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainingForm));
            this.toolStripPanel1 = new System.Windows.Forms.ToolStripPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
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
            this.txtCode = new DusanRodina.SimStudio.Components.SyntaxTextBox();
            this.statesTab = new System.Windows.Forms.TabPage();
            this.bAddState = new System.Windows.Forms.Button();
            this.stateDiagramControl = new DusanRodina.TuringCore.Components.StateDiagramControl();
            this.logTab = new System.Windows.Forms.TabPage();
            this.formalSpecificationTab = new System.Windows.Forms.TabPage();
            this.formalSpecifiaction = new System.Windows.Forms.WebBrowser();
            this.lstErrors = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.splitContainer1.SuspendLayout();
            this.statesTab.SuspendLayout();
            this.formalSpecificationTab.SuspendLayout();
            this.speedPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripPanel1
            // 
            this.toolStripPanel1.Controls.Add(this.menuStrip1);
            this.toolStripPanel1.Controls.Add(this.mainToolStrip);
            this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripPanel1.Location = new System.Drawing.Point(0, 0);
            this.toolStripPanel1.Name = "toolStripPanel1";
            this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripPanel1.Size = new System.Drawing.Size(800, 52);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miEdit, this.miMachine, this.miSimulation, this.txtFind, this.helpToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miSaveFile, this.miSaveAsFile, this.toolStripSeparator5, this.miExit });
            this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(50, 23);
            this.miFile.Text = "Súbor";
            // 
            // miSaveFile
            // 
            this.miSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("miSaveFile.Image")));
            this.miSaveFile.Name = "miSaveFile";
            this.miSaveFile.Size = new System.Drawing.Size(127, 22);
            this.miSaveFile.Text = "Uložiť";
            this.miSaveFile.Click += new System.EventHandler(this.miSaveFile_Click);
            // 
            // miSaveAsFile
            // 
            this.miSaveAsFile.Image = ((System.Drawing.Image)(resources.GetObject("miSaveAsFile.Image")));
            this.miSaveAsFile.Name = "miSaveAsFile";
            this.miSaveAsFile.Size = new System.Drawing.Size(127, 22);
            this.miSaveAsFile.Text = "Uložiť ako";
            this.miSaveAsFile.Click += new System.EventHandler(this.miSaveAsFile_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(124, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(127, 22);
            this.miExit.Text = "Skončiť";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // miEdit
            // 
            this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miCut, this.miCopy, this.miPaste, this.miDelete, this.toolStripMenuItem10, this.miSelectAll, this.toolStripMenuItem4, this.miFind, this.miReplace });
            this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miEdit.MergeIndex = 2;
            this.miEdit.Name = "miEdit";
            this.miEdit.Size = new System.Drawing.Size(56, 23);
            this.miEdit.Text = "Úpravy";
            // 
            // miCut
            // 
            this.miCut.Image = ((System.Drawing.Image)(resources.GetObject("miCut.Image")));
            this.miCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miCut.Name = "miCut";
            this.miCut.Size = new System.Drawing.Size(194, 22);
            this.miCut.Text = "Vystrihnúť";
            this.miCut.Click += new System.EventHandler(this.miCut_Click);
            // 
            // miCopy
            // 
            this.miCopy.Image = ((System.Drawing.Image)(resources.GetObject("miCopy.Image")));
            this.miCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(194, 22);
            this.miCopy.Text = "Kopírovať";
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            // 
            // miPaste
            // 
            this.miPaste.Image = ((System.Drawing.Image)(resources.GetObject("miPaste.Image")));
            this.miPaste.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miPaste.Name = "miPaste";
            this.miPaste.Size = new System.Drawing.Size(194, 22);
            this.miPaste.Text = "Prilepiť";
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
            // 
            // miDelete
            // 
            this.miDelete.Name = "miDelete";
            this.miDelete.Size = new System.Drawing.Size(194, 22);
            this.miDelete.Text = "Zmazať";
            this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(191, 6);
            // 
            // miSelectAll
            // 
            this.miSelectAll.Name = "miSelectAll";
            this.miSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.miSelectAll.Size = new System.Drawing.Size(194, 22);
            this.miSelectAll.Text = "Označiť všetko";
            this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 6);
            // 
            // miFind
            // 
            this.miFind.Name = "miFind";
            this.miFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.miFind.Size = new System.Drawing.Size(194, 22);
            this.miFind.Text = "Hľadať";
            this.miFind.Click += new System.EventHandler(this.miFind_Click);
            // 
            // miReplace
            // 
            this.miReplace.Name = "miReplace";
            this.miReplace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.miReplace.Size = new System.Drawing.Size(194, 22);
            this.miReplace.Text = "Nahradiť";
            this.miReplace.Click += new System.EventHandler(this.miReplace_Click);
            // 
            // miMachine
            // 
            this.miMachine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTransitions, this.miTape, this.toolStripMenuItem14, this.miSettings });
            this.miMachine.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miMachine.MergeIndex = 3;
            this.miMachine.Name = "miMachine";
            this.miMachine.Size = new System.Drawing.Size(43, 23);
            this.miMachine.Text = "Stroj";
            // 
            // miTransitions
            // 
            this.miTransitions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAddTransition, this.toolStripMenuItem12, this.miTransitionFormat });
            this.miTransitions.Name = "miTransitions";
            this.miTransitions.Size = new System.Drawing.Size(132, 22);
            this.miTransitions.Text = "Prechody";
            // 
            // miAddTransition
            // 
            this.miAddTransition.Name = "miAddTransition";
            this.miAddTransition.Size = new System.Drawing.Size(216, 22);
            this.miAddTransition.Text = "Pridať prechodovú funkciu";
            this.miAddTransition.Click += new System.EventHandler(this.miAddTransition_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(213, 6);
            // 
            // miTransitionFormat
            // 
            this.miTransitionFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTFormat10, this.toolStripSeparator2, this.miTFormat1, this.miTFormat2, this.miTFormat3, this.toolStripMenuItem13, this.miTFormat4, this.miTFormat5, this.miTFormat6, this.miTFormat7, this.miTFormat8, this.miTFormat9 });
            this.miTransitionFormat.Name = "miTransitionFormat";
            this.miTransitionFormat.Size = new System.Drawing.Size(216, 22);
            this.miTransitionFormat.Text = "Tvar prechodovej funkcie";
            // 
            // miTFormat10
            // 
            this.miTFormat10.Checked = true;
            this.miTFormat10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miTFormat10.Name = "miTFormat10";
            this.miTFormat10.Size = new System.Drawing.Size(146, 22);
            this.miTFormat10.Text = "δ(q1,a1)=(q2)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // miTFormat1
            // 
            this.miTFormat1.Name = "miTFormat1";
            this.miTFormat1.Size = new System.Drawing.Size(146, 22);
            this.miTFormat1.Text = "f(q1,a1)=(q2)";
            // 
            // miTFormat2
            // 
            this.miTFormat2.Name = "miTFormat2";
            this.miTFormat2.Size = new System.Drawing.Size(146, 22);
            this.miTFormat2.Text = "(q1,a1)=(q2)";
            // 
            // miTFormat3
            // 
            this.miTFormat3.Name = "miTFormat3";
            this.miTFormat3.Size = new System.Drawing.Size(146, 22);
            this.miTFormat3.Text = "q1,a1,q2";
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(143, 6);
            // 
            // miTFormat4
            // 
            this.miTFormat4.Name = "miTFormat4";
            this.miTFormat4.Size = new System.Drawing.Size(146, 22);
            this.miTFormat4.Text = "[q1,a1][q2]";
            // 
            // miTFormat5
            // 
            this.miTFormat5.Name = "miTFormat5";
            this.miTFormat5.Size = new System.Drawing.Size(146, 22);
            this.miTFormat5.Text = "(q1,a1)(q2)";
            // 
            // miTFormat6
            // 
            this.miTFormat6.Name = "miTFormat6";
            this.miTFormat6.Size = new System.Drawing.Size(146, 22);
            this.miTFormat6.Text = "[q1,a1]->[q2]";
            // 
            // miTFormat7
            // 
            this.miTFormat7.Name = "miTFormat7";
            this.miTFormat7.Size = new System.Drawing.Size(146, 22);
            this.miTFormat7.Text = "(q1,a1)->(q2)";
            // 
            // miTFormat8
            // 
            this.miTFormat8.Name = "miTFormat8";
            this.miTFormat8.Size = new System.Drawing.Size(146, 22);
            this.miTFormat8.Text = "q1,a1->q2";
            // 
            // miTFormat9
            // 
            this.miTFormat9.Name = "miTFormat9";
            this.miTFormat9.Size = new System.Drawing.Size(146, 22);
            this.miTFormat9.Text = "q1,a1>q2";
            // 
            // miTape
            // 
            this.miTape.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miInsertSymbols, this.toolStripSeparator1, this.miClearTape, this.toolStripMenuItem5, this.miExportTape, this.miImportTape, this.toolStripMenuItem6, this.miTapeStatistics });
            this.miTape.Name = "miTape";
            this.miTape.Size = new System.Drawing.Size(132, 22);
            this.miTape.Text = "Páska";
            this.miTape.Visible = false;
            // 
            // miInsertSymbols
            // 
            this.miInsertSymbols.Name = "miInsertSymbols";
            this.miInsertSymbols.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.miInsertSymbols.Size = new System.Drawing.Size(238, 22);
            this.miInsertSymbols.Text = "Vložiť symboly";
            this.miInsertSymbols.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(235, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // miClearTape
            // 
            this.miClearTape.Name = "miClearTape";
            this.miClearTape.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.D)));
            this.miClearTape.Size = new System.Drawing.Size(238, 22);
            this.miClearTape.Text = "Zmazať pásku";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(235, 6);
            this.toolStripMenuItem5.Visible = false;
            // 
            // miExportTape
            // 
            this.miExportTape.Name = "miExportTape";
            this.miExportTape.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.E)));
            this.miExportTape.Size = new System.Drawing.Size(238, 22);
            this.miExportTape.Text = "Exportovať pásku";
            this.miExportTape.Visible = false;
            // 
            // miImportTape
            // 
            this.miImportTape.Name = "miImportTape";
            this.miImportTape.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.I)));
            this.miImportTape.Size = new System.Drawing.Size(238, 22);
            this.miImportTape.Text = "Importovať pásku";
            this.miImportTape.Visible = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(235, 6);
            // 
            // miTapeStatistics
            // 
            this.miTapeStatistics.Name = "miTapeStatistics";
            this.miTapeStatistics.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) | System.Windows.Forms.Keys.S)));
            this.miTapeStatistics.Size = new System.Drawing.Size(238, 22);
            this.miTapeStatistics.Text = "Štatistiky pásky";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(129, 6);
            // 
            // miSettings
            // 
            this.miSettings.Name = "miSettings";
            this.miSettings.Size = new System.Drawing.Size(132, 22);
            this.miSettings.Text = "Nastavenia";
            this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
            // 
            // miSimulation
            // 
            this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miRun, this.miPause, this.miStep, this.miStop, this.toolStripMenuItem9, this.miBreaks, this.toolStripMenuItem11, this.miWriteLog, this.miStoreOriginalTape });
            this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.miSimulation.MergeIndex = 4;
            this.miSimulation.Name = "miSimulation";
            this.miSimulation.Size = new System.Drawing.Size(70, 23);
            this.miSimulation.Text = "Simulácia";
            // 
            // miRun
            // 
            this.miRun.Image = ((System.Drawing.Image)(resources.GetObject("miRun.Image")));
            this.miRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRun.Name = "miRun";
            this.miRun.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRun.Size = new System.Drawing.Size(215, 22);
            this.miRun.Text = "Spustiť";
            // 
            // miPause
            // 
            this.miPause.Image = ((System.Drawing.Image)(resources.GetObject("miPause.Image")));
            this.miPause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miPause.Name = "miPause";
            this.miPause.Size = new System.Drawing.Size(215, 22);
            this.miPause.Text = "Pauza";
            // 
            // miStep
            // 
            this.miStep.Name = "miStep";
            this.miStep.Size = new System.Drawing.Size(215, 22);
            this.miStep.Text = "Krok";
            // 
            // miStop
            // 
            this.miStop.Image = ((System.Drawing.Image)(resources.GetObject("miStop.Image")));
            this.miStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miStop.Name = "miStop";
            this.miStop.Size = new System.Drawing.Size(215, 22);
            this.miStop.Text = "Zastaviť";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(212, 6);
            this.toolStripMenuItem9.Visible = false;
            // 
            // miBreaks
            // 
            this.miBreaks.Name = "miBreaks";
            this.miBreaks.Size = new System.Drawing.Size(215, 22);
            this.miBreaks.Text = "Prerušenia";
            this.miBreaks.Visible = false;
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(212, 6);
            // 
            // miWriteLog
            // 
            this.miWriteLog.Checked = true;
            this.miWriteLog.CheckOnClick = true;
            this.miWriteLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miWriteLog.Name = "miWriteLog";
            this.miWriteLog.Size = new System.Drawing.Size(215, 22);
            this.miWriteLog.Text = "Zaznamenávať priebeh";
            // 
            // miStoreOriginalTape
            // 
            this.miStoreOriginalTape.Checked = true;
            this.miStoreOriginalTape.CheckOnClick = true;
            this.miStoreOriginalTape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miStoreOriginalTape.Name = "miStoreOriginalTape";
            this.miStoreOriginalTape.Size = new System.Drawing.Size(215, 22);
            this.miStoreOriginalTape.Text = "Pamätať si pôvodnú pásku";
            this.miStoreOriginalTape.Visible = false;
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
            this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Replace;
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
            // mainToolStrip
            // 
            this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.saveToolStripButton, this.toolStripSeparator3, this.checkToolStripButton, this.toolStripSeparator4 });
            this.mainToolStrip.Location = new System.Drawing.Point(3, 27);
            this.mainToolStrip.Name = "mainToolStrip";
            this.mainToolStrip.Size = new System.Drawing.Size(150, 25);
            this.mainToolStrip.TabIndex = 22;
            this.mainToolStrip.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Uložiť";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // checkToolStripButton
            // 
            this.checkToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("checkToolStripButton.Image")));
            this.checkToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.checkToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.checkToolStripButton.Name = "checkToolStripButton";
            this.checkToolStripButton.Size = new System.Drawing.Size(103, 22);
            this.checkToolStripButton.Text = "Overiť riešenie";
            this.checkToolStripButton.Click += new System.EventHandler(this.checkToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 13;
            // 
            // statusLabel
            // 
            this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
            this.statusLabel.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.statusLabel.MergeIndex = 0;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(196, 17);
            this.statusLabel.Text = "Trenažér, Copyright (C) 2026 FEI STU";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 52);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
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
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(800, 376);
            this.splitContainer2.SplitterDistance = 266;
            this.splitContainer2.TabIndex = 14;
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.taskSpecificationTab);
            this.tcMain.Controls.Add(this.functionsTab);
            this.tcMain.Controls.Add(this.statesTab);
            this.tcMain.Controls.Add(this.logTab);
            this.tcMain.Controls.Add(this.formalSpecificationTab);
            this.tcMain.Location = new System.Drawing.Point(3, 3);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(794, 370);
            this.tcMain.TabIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // taskSpecificationTab
            // 
            this.taskSpecificationTab.Controls.Add(this.taskSpecification);
            this.taskSpecificationTab.Location = new System.Drawing.Point(4, 22);
            this.taskSpecificationTab.Name = "taskSpecificationTab";
            this.taskSpecificationTab.Size = new System.Drawing.Size(786, 344);
            this.taskSpecificationTab.TabIndex = 5;
            this.taskSpecificationTab.Text = "Zadanie";
            this.taskSpecificationTab.UseVisualStyleBackColor = true;
            // 
            // taskSpecification
            // 
            this.taskSpecification.AllowWebBrowserDrop = false;
            this.taskSpecification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskSpecification.Location = new System.Drawing.Point(0, 0);
            this.taskSpecification.MinimumSize = new System.Drawing.Size(20, 20);
            this.taskSpecification.Name = "taskSpecification";
            this.taskSpecification.Size = new System.Drawing.Size(786, 344);
            this.taskSpecification.TabIndex = 2;
            this.taskSpecification.WebBrowserShortcutsEnabled = false;
            // 
            // functionsTab
            // 
            this.functionsTab.Controls.Add(this.splitContainer1);
            this.functionsTab.Location = new System.Drawing.Point(4, 22);
            this.functionsTab.Name = "functionsTab";
            this.functionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.functionsTab.Size = new System.Drawing.Size(786, 344);
            this.functionsTab.TabIndex = 0;
            this.functionsTab.Text = "Prechodové funkcie";
            this.functionsTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bAddTFunction);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtCode);
            this.splitContainer1.Size = new System.Drawing.Size(780, 338);
            this.splitContainer1.SplitterDistance = 508;
            this.splitContainer1.TabIndex = 0;
            // 
            // bAddTFunction
            // 
            this.bAddTFunction.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bAddTFunction.Location = new System.Drawing.Point(2, 3);
            this.bAddTFunction.Name = "bAddTFunction";
            this.bAddTFunction.Size = new System.Drawing.Size(90, 30);
            this.bAddTFunction.TabIndex = 5;
            this.bAddTFunction.Text = "Pridať &prechod";
            this.bAddTFunction.UseVisualStyleBackColor = true;
            this.bAddTFunction.Click += new System.EventHandler(this.bAddTFunction_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(98, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(199, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pridá nový prechod prechodovej funkcie";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.HideSelection = true;
            this.txtCode.Location = new System.Drawing.Point(3, 39);
            this.txtCode.Name = "txtCode";
            this.txtCode.SelectedText = "";
            this.txtCode.SelectionLength = 0;
            this.txtCode.SelectionStart = 0;
            this.txtCode.Size = new System.Drawing.Size(502, 296);
            this.txtCode.TabIndex = 0;
            // 
            // statesTab
            // 
            this.statesTab.Controls.Add(this.bAddState);
            this.statesTab.Controls.Add(this.stateDiagramControl);
            this.statesTab.Location = new System.Drawing.Point(4, 22);
            this.statesTab.Name = "statesTab";
            this.statesTab.Padding = new System.Windows.Forms.Padding(3);
            this.statesTab.Size = new System.Drawing.Size(786, 344);
            this.statesTab.TabIndex = 1;
            this.statesTab.Text = "Stavový diagram";
            this.statesTab.UseVisualStyleBackColor = true;
            // 
            // bAddState
            // 
            this.bAddState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bAddState.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bAddState.Location = new System.Drawing.Point(669, 6);
            this.bAddState.Name = "bAddState";
            this.bAddState.Size = new System.Drawing.Size(111, 27);
            this.bAddState.TabIndex = 2;
            this.bAddState.Text = "Pridať &stav";
            this.bAddState.UseVisualStyleBackColor = true;
            this.bAddState.Click += new System.EventHandler(this.bAddState_Click);
            // 
            // stateDiagramControl
            // 
            this.stateDiagramControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.stateDiagramControl.AutoScroll = true;
            this.stateDiagramControl.Location = new System.Drawing.Point(0, 0);
            this.stateDiagramControl.Name = "stateDiagramControl";
            this.stateDiagramControl.Size = new System.Drawing.Size(663, 341);
            this.stateDiagramControl.TabIndex = 0;
            this.stateDiagramControl.TuringMachine = null;
            // 
            // logTab
            // 
            this.logTab.Location = new System.Drawing.Point(4, 22);
            this.logTab.Name = "logTab";
            this.logTab.Padding = new System.Windows.Forms.Padding(3);
            this.logTab.Size = new System.Drawing.Size(786, 344);
            this.logTab.TabIndex = 3;
            this.logTab.Text = "Záznam priebehu";
            this.logTab.UseVisualStyleBackColor = true;
            // 
            // formalSpecificationTab
            // 
            this.formalSpecificationTab.Controls.Add(this.formalSpecifiaction);
            this.formalSpecificationTab.Location = new System.Drawing.Point(4, 22);
            this.formalSpecificationTab.Name = "formalSpecificationTab";
            this.formalSpecificationTab.Size = new System.Drawing.Size(786, 344);
            this.formalSpecificationTab.TabIndex = 4;
            this.formalSpecificationTab.Text = "Formálna špecifikácia";
            this.formalSpecificationTab.UseVisualStyleBackColor = true;
            // 
            // formalSpecifiaction
            // 
            this.formalSpecifiaction.AllowWebBrowserDrop = false;
            this.formalSpecifiaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formalSpecifiaction.Location = new System.Drawing.Point(0, 0);
            this.formalSpecifiaction.MinimumSize = new System.Drawing.Size(20, 20);
            this.formalSpecifiaction.Name = "formalSpecifiaction";
            this.formalSpecifiaction.Size = new System.Drawing.Size(786, 344);
            this.formalSpecifiaction.TabIndex = 1;
            this.formalSpecifiaction.WebBrowserShortcutsEnabled = false;
            // 
            // lstErrors
            // 
            this.lstErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstErrors.FormattingEnabled = true;
            this.lstErrors.IntegralHeight = false;
            this.lstErrors.Location = new System.Drawing.Point(0, 17);
            this.lstErrors.Name = "lstErrors";
            this.lstErrors.Size = new System.Drawing.Size(150, 29);
            this.lstErrors.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(2);
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Zoznam chýb:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedPanel
            // 
            this.speedPanel.BackColor = System.Drawing.Color.White;
            this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedPanel.Controls.Add(this.panel1);
            this.speedPanel.Controls.Add(this.tbSpeed);
            this.speedPanel.Controls.Add(this.label3);
            this.speedPanel.Location = new System.Drawing.Point(597, 431);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new System.Drawing.Size(200, 37);
            this.speedPanel.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 37);
            this.panel1.TabIndex = 24;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.trackBar1.Location = new System.Drawing.Point(61, 3);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(134, 45);
            this.trackBar1.TabIndex = 16;
            this.trackBar1.Value = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Rýchlosť:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSpeed
            // 
            this.tbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbSpeed.Location = new System.Drawing.Point(61, 3);
            this.tbSpeed.Maximum = 20;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(134, 45);
            this.tbSpeed.TabIndex = 16;
            this.tbSpeed.Value = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(3, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Rýchlosť:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "tm";
            this.saveFileDialog1.Filter = "Súbor konečného automatu|*.fa| Súbor JFLAP|*.jff";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // TrainingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.speedPanel);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStripPanel1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainingForm";
            this.Text = "TrainingForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statesTab.ResumeLayout(false);
            this.formalSpecificationTab.ResumeLayout(false);
            this.speedPanel.ResumeLayout(false);
            this.speedPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Panel speedPanel;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Button bAddTFunction;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private DusanRodina.SimStudio.Components.SyntaxTextBox txtCode;

        private DusanRodina.TuringCore.Components.StateDiagramControl stateDiagramControl;

        private System.Windows.Forms.TabPage taskSpecificationTab;

        private System.Windows.Forms.TabPage functionsTab;

        private System.Windows.Forms.TabPage logTab;

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