using System.IO;
using System.Windows.Forms;
using FEI.SimStudio.Components.Controls;
using FEI.TuringCore.Components;
using FEI.TuringCore.Simulation;

namespace FEI.FiniteAutomaton {
	partial class FiniteAutomatonForm
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

            //Zmaze dočasný súbor
            if (tmpFormalSpecFileName != null)
            {
                File.Delete(tmpFormalSpecFileName);
            }

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
	        this.components = new System.ComponentModel.Container();
	        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiniteAutomatonForm));
	        this.splitContainer1 = new System.Windows.Forms.SplitContainer();
	        this.bAddTFunction = new System.Windows.Forms.Button();
	        this.txtCode = new FEI.SimStudio.Components.Controls.SyntaxTextBox();
	        this.label5 = new System.Windows.Forms.Label();
	        this.pFunctions = new System.Windows.Forms.PictureBox();
	        this.label6 = new System.Windows.Forms.Label();
	        this.sbyFunctions = new System.Windows.Forms.VScrollBar();
	        this.splitContainer2 = new System.Windows.Forms.SplitContainer();
	        this.tcMain = new System.Windows.Forms.TabControl();
	        this.functionsTab = new System.Windows.Forms.TabPage();
	        this.statesTab = new System.Windows.Forms.TabPage();
	        this.stateDiagramControl = new FEI.TuringCore.Components.StateDiagramControl();
	        this.bAddState = new System.Windows.Forms.Button();
	        this.processTab = new System.Windows.Forms.TabPage();
	        this.sbxThreads = new System.Windows.Forms.HScrollBar();
	        this.sbyThreads = new System.Windows.Forms.VScrollBar();
	        this.lblThreadCount = new System.Windows.Forms.Label();
	        this.label4 = new System.Windows.Forms.Label();
	        this.pThreads = new System.Windows.Forms.PictureBox();
	        this.logTab = new System.Windows.Forms.TabPage();
	        this.sbxLog = new System.Windows.Forms.HScrollBar();
	        this.sbyLog = new System.Windows.Forms.VScrollBar();
	        this.pLog = new System.Windows.Forms.PictureBox();
	        this.formalSpecificationTab = new System.Windows.Forms.TabPage();
	        this.formalSpecifiaction = new System.Windows.Forms.WebBrowser();
	        this.formalSpecificationMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
	        this.formalSpecSaveAs = new System.Windows.Forms.ToolStripMenuItem();
	        this.formalSpecPrint = new System.Windows.Forms.ToolStripMenuItem();
	        this.speedPanel = new System.Windows.Forms.Panel();
	        this.tbSpeed = new System.Windows.Forms.TrackBar();
	        this.label3 = new System.Windows.Forms.Label();
	        this.infiniteTapeControl = new FEI.TuringCore.Components.InfiniteTapeControl();
	        this.cmbTape = new System.Windows.Forms.ComboBox();
	        this.label1 = new System.Windows.Forms.Label();
	        this.label2 = new System.Windows.Forms.Label();
	        this.lblCurrentState = new System.Windows.Forms.Label();
	        this.lstErrors = new System.Windows.Forms.ListBox();
	        this.label7 = new System.Windows.Forms.Label();
	        this.statusStrip = new System.Windows.Forms.StatusStrip();
	        this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
	        this.lblStepCount = new System.Windows.Forms.ToolStripStatusLabel();
	        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
	        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	        this.miFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miNewFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miOpenFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
	        this.miSaveFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
	        this.miExitmiExitmiExit = new System.Windows.Forms.ToolStripMenuItem();
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
	        this.kopírovaťToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
	        this.označiťVšetkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
	        this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
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
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
	        this.splitContainer1.Panel1.SuspendLayout();
	        this.splitContainer1.Panel2.SuspendLayout();
	        this.splitContainer1.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pFunctions)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
	        this.splitContainer2.Panel1.SuspendLayout();
	        this.splitContainer2.Panel2.SuspendLayout();
	        this.splitContainer2.SuspendLayout();
	        this.tcMain.SuspendLayout();
	        this.functionsTab.SuspendLayout();
	        this.statesTab.SuspendLayout();
	        this.processTab.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pThreads)).BeginInit();
	        this.logTab.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pLog)).BeginInit();
	        this.formalSpecificationTab.SuspendLayout();
	        this.formalSpecificationMenu.SuspendLayout();
	        this.speedPanel.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
	        this.statusStrip.SuspendLayout();
	        this.menuStrip1.SuspendLayout();
	        this.toolStripPanel1.SuspendLayout();
	        this.mainToolStrip.SuspendLayout();
	        this.SuspendLayout();
	        // 
	        // splitContainer1
	        // 
	        resources.ApplyResources(this.splitContainer1, "splitContainer1");
	        this.splitContainer1.Name = "splitContainer1";
	        // 
	        // splitContainer1.Panel1
	        // 
	        resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
	        this.splitContainer1.Panel1.Controls.Add(this.bAddTFunction);
	        this.splitContainer1.Panel1.Controls.Add(this.txtCode);
	        this.splitContainer1.Panel1.Controls.Add(this.label5);
	        // 
	        // splitContainer1.Panel2
	        // 
	        resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
	        this.splitContainer1.Panel2.Controls.Add(this.pFunctions);
	        this.splitContainer1.Panel2.Controls.Add(this.label6);
	        this.splitContainer1.Panel2.Controls.Add(this.sbyFunctions);
	        // 
	        // bAddTFunction
	        // 
	        resources.ApplyResources(this.bAddTFunction, "bAddTFunction");
	        this.bAddTFunction.Name = "bAddTFunction";
	        this.bAddTFunction.UseVisualStyleBackColor = true;
	        this.bAddTFunction.Click += new System.EventHandler(this.bAddTFunction_Click);
	        // 
	        // txtCode
	        // 
	        resources.ApplyResources(this.txtCode, "txtCode");
	        this.txtCode.HideSelection = false;
	        this.txtCode.Name = "txtCode";
	        this.txtCode.SelectedText = "";
	        this.txtCode.SelectionLength = 0;
	        this.txtCode.SelectionStart = 0;
	        this.txtCode.TextChanged += new FEI.SimStudio.Components.Controls.SyntaxTextBox.TextChangedEventHandler(this.txtCode_TextChanged);
	        // 
	        // label5
	        // 
	        resources.ApplyResources(this.label5, "label5");
	        this.label5.Name = "label5";
	        // 
	        // pFunctions
	        // 
	        resources.ApplyResources(this.pFunctions, "pFunctions");
	        this.pFunctions.Name = "pFunctions";
	        this.pFunctions.TabStop = false;
	        this.pFunctions.Paint += new System.Windows.Forms.PaintEventHandler(this.pFunctions_Paint);
	        this.pFunctions.Resize += new System.EventHandler(this.pFunctions_Resize);
	        // 
	        // label6
	        // 
	        resources.ApplyResources(this.label6, "label6");
	        this.label6.Name = "label6";
	        // 
	        // sbyFunctions
	        // 
	        resources.ApplyResources(this.sbyFunctions, "sbyFunctions");
	        this.sbyFunctions.Name = "sbyFunctions";
	        this.sbyFunctions.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyFunctions_Scroll);
	        // 
	        // splitContainer2
	        // 
	        resources.ApplyResources(this.splitContainer2, "splitContainer2");
	        this.splitContainer2.BackColor = System.Drawing.SystemColors.ControlDark;
	        this.splitContainer2.Name = "splitContainer2";
	        // 
	        // splitContainer2.Panel1
	        // 
	        resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
	        this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
	        this.splitContainer2.Panel1.Controls.Add(this.tcMain);
	        this.splitContainer2.Panel1.Controls.Add(this.speedPanel);
	        this.splitContainer2.Panel1.Controls.Add(this.infiniteTapeControl);
	        this.splitContainer2.Panel1.Controls.Add(this.cmbTape);
	        this.splitContainer2.Panel1.Controls.Add(this.label1);
	        this.splitContainer2.Panel1.Controls.Add(this.label2);
	        this.splitContainer2.Panel1.Controls.Add(this.lblCurrentState);
	        // 
	        // splitContainer2.Panel2
	        // 
	        resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
	        this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
	        this.splitContainer2.Panel2.Controls.Add(this.lstErrors);
	        this.splitContainer2.Panel2.Controls.Add(this.label7);
	        this.splitContainer2.Panel2Collapsed = true;
	        // 
	        // tcMain
	        // 
	        resources.ApplyResources(this.tcMain, "tcMain");
	        this.tcMain.Controls.Add(this.functionsTab);
	        this.tcMain.Controls.Add(this.statesTab);
	        this.tcMain.Controls.Add(this.processTab);
	        this.tcMain.Controls.Add(this.logTab);
	        this.tcMain.Controls.Add(this.formalSpecificationTab);
	        this.tcMain.Name = "tcMain";
	        this.tcMain.SelectedIndex = 0;
	        this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
	        // 
	        // functionsTab
	        // 
	        resources.ApplyResources(this.functionsTab, "functionsTab");
	        this.functionsTab.Controls.Add(this.splitContainer1);
	        this.functionsTab.Name = "functionsTab";
	        this.functionsTab.UseVisualStyleBackColor = true;
	        // 
	        // statesTab
	        // 
	        resources.ApplyResources(this.statesTab, "statesTab");
	        this.statesTab.Controls.Add(this.stateDiagramControl);
	        this.statesTab.Controls.Add(this.bAddState);
	        this.statesTab.Name = "statesTab";
	        this.statesTab.UseVisualStyleBackColor = true;
	        // 
	        // stateDiagramControl
	        // 
	        resources.ApplyResources(this.stateDiagramControl, "stateDiagramControl");
	        this.stateDiagramControl.Name = "stateDiagramControl";
	        this.stateDiagramControl.TuringMachine = null;
	        this.stateDiagramControl.TransitionAdded += new FEI.TuringCore.Components.StateDiagramControl.TransitionEventHandler(this.stateDiagramControl_TransitionAdded);
	        this.stateDiagramControl.DiagramChanged += new FEI.TuringCore.Components.StateDiagramControl.DiagramChangedEventHandler(this.stateDiagramControl_DiagramChanged);
	        // 
	        // bAddState
	        // 
	        resources.ApplyResources(this.bAddState, "bAddState");
	        this.bAddState.Name = "bAddState";
	        this.bAddState.UseVisualStyleBackColor = true;
	        this.bAddState.Click += new System.EventHandler(this.bAddState_Click);
	        // 
	        // processTab
	        // 
	        resources.ApplyResources(this.processTab, "processTab");
	        this.processTab.Controls.Add(this.sbxThreads);
	        this.processTab.Controls.Add(this.sbyThreads);
	        this.processTab.Controls.Add(this.lblThreadCount);
	        this.processTab.Controls.Add(this.label4);
	        this.processTab.Controls.Add(this.pThreads);
	        this.processTab.Name = "processTab";
	        this.processTab.UseVisualStyleBackColor = true;
	        // 
	        // sbxThreads
	        // 
	        resources.ApplyResources(this.sbxThreads, "sbxThreads");
	        this.sbxThreads.Minimum = -100;
	        this.sbxThreads.Name = "sbxThreads";
	        this.sbxThreads.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxThreads_Scroll);
	        this.sbxThreads.ValueChanged += new System.EventHandler(this.sbxThreads_ValueChanged);
	        // 
	        // sbyThreads
	        // 
	        resources.ApplyResources(this.sbyThreads, "sbyThreads");
	        this.sbyThreads.Name = "sbyThreads";
	        this.sbyThreads.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyThreads_Scroll);
	        this.sbyThreads.ValueChanged += new System.EventHandler(this.sbyThreads_ValueChanged);
	        // 
	        // lblThreadCount
	        // 
	        resources.ApplyResources(this.lblThreadCount, "lblThreadCount");
	        this.lblThreadCount.Name = "lblThreadCount";
	        // 
	        // label4
	        // 
	        resources.ApplyResources(this.label4, "label4");
	        this.label4.Name = "label4";
	        // 
	        // pThreads
	        // 
	        resources.ApplyResources(this.pThreads, "pThreads");
	        this.pThreads.Name = "pThreads";
	        this.pThreads.TabStop = false;
	        this.pThreads.Click += new System.EventHandler(this.pThreads_Click);
	        this.pThreads.Paint += new System.Windows.Forms.PaintEventHandler(this.pThreads_Paint);
	        // 
	        // logTab
	        // 
	        resources.ApplyResources(this.logTab, "logTab");
	        this.logTab.Controls.Add(this.sbxLog);
	        this.logTab.Controls.Add(this.sbyLog);
	        this.logTab.Controls.Add(this.pLog);
	        this.logTab.Name = "logTab";
	        this.logTab.UseVisualStyleBackColor = true;
	        // 
	        // sbxLog
	        // 
	        resources.ApplyResources(this.sbxLog, "sbxLog");
	        this.sbxLog.Name = "sbxLog";
	        this.sbxLog.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbxLog_Scroll);
	        this.sbxLog.ValueChanged += new System.EventHandler(this.sbxLog_ValueChanged);
	        // 
	        // sbyLog
	        // 
	        resources.ApplyResources(this.sbyLog, "sbyLog");
	        this.sbyLog.Name = "sbyLog";
	        this.sbyLog.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyLog_Scroll);
	        this.sbyLog.ValueChanged += new System.EventHandler(this.sbyLog_ValueChanged);
	        // 
	        // pLog
	        // 
	        resources.ApplyResources(this.pLog, "pLog");
	        this.pLog.BackColor = System.Drawing.Color.White;
	        this.pLog.Name = "pLog";
	        this.pLog.TabStop = false;
	        this.pLog.Click += new System.EventHandler(this.pLog_Click);
	        this.pLog.Paint += new System.Windows.Forms.PaintEventHandler(this.pLog_Paint);
	        this.pLog.Resize += new System.EventHandler(this.pLog_Resize);
	        // 
	        // formalSpecificationTab
	        // 
	        resources.ApplyResources(this.formalSpecificationTab, "formalSpecificationTab");
	        this.formalSpecificationTab.Controls.Add(this.formalSpecifiaction);
	        this.formalSpecificationTab.Name = "formalSpecificationTab";
	        this.formalSpecificationTab.UseVisualStyleBackColor = true;
	        // 
	        // formalSpecifiaction
	        // 
	        resources.ApplyResources(this.formalSpecifiaction, "formalSpecifiaction");
	        this.formalSpecifiaction.AllowWebBrowserDrop = false;
	        this.formalSpecifiaction.ContextMenuStrip = this.formalSpecificationMenu;
	        this.formalSpecifiaction.Name = "formalSpecifiaction";
	        this.formalSpecifiaction.WebBrowserShortcutsEnabled = false;
	        // 
	        // formalSpecificationMenu
	        // 
	        resources.ApplyResources(this.formalSpecificationMenu, "formalSpecificationMenu");
	        this.formalSpecificationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.formalSpecSaveAs, this.formalSpecPrint });
	        this.formalSpecificationMenu.Name = "formalSpecificationMenu";
	        // 
	        // formalSpecSaveAs
	        // 
	        resources.ApplyResources(this.formalSpecSaveAs, "formalSpecSaveAs");
	        this.formalSpecSaveAs.Name = "formalSpecSaveAs";
	        this.formalSpecSaveAs.Click += new System.EventHandler(this.formalSpecSaveAs_Click);
	        // 
	        // formalSpecPrint
	        // 
	        resources.ApplyResources(this.formalSpecPrint, "formalSpecPrint");
	        this.formalSpecPrint.Name = "formalSpecPrint";
	        this.formalSpecPrint.Click += new System.EventHandler(this.formalSpecPrint_Click);
	        // 
	        // speedPanel
	        // 
	        resources.ApplyResources(this.speedPanel, "speedPanel");
	        this.speedPanel.BackColor = System.Drawing.Color.White;
	        this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.speedPanel.Controls.Add(this.tbSpeed);
	        this.speedPanel.Controls.Add(this.label3);
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
	        // infiniteTapeControl
	        // 
	        this.infiniteTapeControl.AcceptStatus = FEI.TuringCore.Simulation.AcceptanceStatus.None;
	        resources.ApplyResources(this.infiniteTapeControl, "infiniteTapeControl");
	        this.infiniteTapeControl.AllowBlanks = false;
	        this.infiniteTapeControl.ChangesAllowed = true;
	        this.infiniteTapeControl.CurrentSymbols = ((System.Collections.Generic.List<string>)(resources.GetObject("infiniteTapeControl.CurrentSymbols")));
	        this.infiniteTapeControl.EditedCell = -2147483648;
	        this.infiniteTapeControl.EditedTape = -1;
	        this.infiniteTapeControl.HeadPositions.Add(0);
	        this.infiniteTapeControl.IsInfinite = false;
	        this.infiniteTapeControl.Name = "infiniteTapeControl";
	        this.infiniteTapeControl.TapeChanged += new System.EventHandler(this.infiniteTapeControl_TapeChanged);
	        this.infiniteTapeControl.HeadPositionChanged += new System.EventHandler(this.infiniteTapeControl_HeadPositionChanged);
	        this.infiniteTapeControl.TapeCannotBeChanged += new System.EventHandler(this.infiniteTapeControl_TapeCannotBeChanged);
	        this.infiniteTapeControl.Load += new System.EventHandler(this.infiniteTapeControl_Load);
	        // 
	        // cmbTape
	        // 
	        resources.ApplyResources(this.cmbTape, "cmbTape");
	        this.cmbTape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
	        this.cmbTape.FormattingEnabled = true;
	        this.cmbTape.Items.AddRange(new object[] { resources.GetString("cmbTape.Items"), resources.GetString("cmbTape.Items1") });
	        this.cmbTape.Name = "cmbTape";
	        this.cmbTape.SelectedIndexChanged += new System.EventHandler(this.cmbTape_SelectedIndexChanged);
	        // 
	        // label1
	        // 
	        resources.ApplyResources(this.label1, "label1");
	        this.label1.Name = "label1";
	        // 
	        // label2
	        // 
	        resources.ApplyResources(this.label2, "label2");
	        this.label2.Name = "label2";
	        // 
	        // lblCurrentState
	        // 
	        resources.ApplyResources(this.lblCurrentState, "lblCurrentState");
	        this.lblCurrentState.Name = "lblCurrentState";
	        // 
	        // lstErrors
	        // 
	        resources.ApplyResources(this.lstErrors, "lstErrors");
	        this.lstErrors.FormattingEnabled = true;
	        this.lstErrors.Name = "lstErrors";
	        this.lstErrors.Click += new System.EventHandler(this.lstErrors_Click);
	        // 
	        // label7
	        // 
	        resources.ApplyResources(this.label7, "label7");
	        this.label7.Name = "label7";
	        // 
	        // statusStrip
	        // 
	        resources.ApplyResources(this.statusStrip, "statusStrip");
	        this.statusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
	        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel, this.lblStepCount });
	        this.statusStrip.Name = "statusStrip";
	        // 
	        // statusLabel
	        // 
	        resources.ApplyResources(this.statusLabel, "statusLabel");
	        this.statusLabel.Margin = new System.Windows.Forms.Padding(0, 3, 10, 2);
	        this.statusLabel.MergeAction = System.Windows.Forms.MergeAction.Replace;
	        this.statusLabel.MergeIndex = 0;
	        this.statusLabel.Name = "statusLabel";
	        // 
	        // lblStepCount
	        // 
	        resources.ApplyResources(this.lblStepCount, "lblStepCount");
	        this.lblStepCount.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
	        this.lblStepCount.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.lblStepCount.MergeIndex = 1;
	        this.lblStepCount.Name = "lblStepCount";
	        // 
	        // openFileDialog1
	        // 
	        resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
	        // 
	        // menuStrip1
	        // 
	        resources.ApplyResources(this.menuStrip1, "menuStrip1");
	        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miEdit, this.miMachine, this.miSimulation, this.txtFind, this.helpToolStripMenuItem });
	        this.menuStrip1.Name = "menuStrip1";
	        // 
	        // miFile
	        // 
	        resources.ApplyResources(this.miFile, "miFile");
	        this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNewFile, this.miOpenFile, this.toolStripMenuItem1, this.miSaveFile, this.miSaveAsFile, this.toolStripMenuItem2, this.miExitmiExitmiExit });
	        this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miFile.MergeIndex = 1;
	        this.miFile.Name = "miFile";
	        // 
	        // miNewFile
	        // 
	        resources.ApplyResources(this.miNewFile, "miNewFile");
	        this.miNewFile.Image = global::FEI.FiniteAutomaton.Properties.Resources._new;
	        this.miNewFile.Name = "miNewFile";
	        this.miNewFile.Click += new System.EventHandler(this.miNewFile_Click);
	        // 
	        // miOpenFile
	        // 
	        resources.ApplyResources(this.miOpenFile, "miOpenFile");
	        this.miOpenFile.Image = global::FEI.FiniteAutomaton.Properties.Resources.open;
	        this.miOpenFile.Name = "miOpenFile";
	        this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
	        // 
	        // toolStripMenuItem1
	        // 
	        resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
	        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
	        // 
	        // miSaveFile
	        // 
	        resources.ApplyResources(this.miSaveFile, "miSaveFile");
	        this.miSaveFile.Image = global::FEI.FiniteAutomaton.Properties.Resources.save;
	        this.miSaveFile.Name = "miSaveFile";
	        this.miSaveFile.Click += new System.EventHandler(this.miSaveFile_Click);
	        // 
	        // miSaveAsFile
	        // 
	        resources.ApplyResources(this.miSaveAsFile, "miSaveAsFile");
	        this.miSaveAsFile.Image = global::FEI.FiniteAutomaton.Properties.Resources.save;
	        this.miSaveAsFile.Name = "miSaveAsFile";
	        this.miSaveAsFile.Click += new System.EventHandler(this.miSaveAsFile_Click);
	        // 
	        // toolStripMenuItem2
	        // 
	        resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
	        this.toolStripMenuItem2.Name = "toolStripMenuItem2";
	        // 
	        // miExitmiExitmiExit
	        // 
	        resources.ApplyResources(this.miExitmiExitmiExit, "miExitmiExitmiExit");
	        this.miExitmiExitmiExit.Name = "miExitmiExitmiExit";
	        this.miExitmiExitmiExit.Click += new System.EventHandler(this.miExit_Click);
	        // 
	        // miEdit
	        // 
	        resources.ApplyResources(this.miEdit, "miEdit");
	        this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miCut, this.miCopy, this.miPaste, this.miDelete, this.toolStripMenuItem10, this.miSelectAll, this.toolStripMenuItem4, this.miFind, this.miReplace });
	        this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miEdit.MergeIndex = 2;
	        this.miEdit.Name = "miEdit";
	        // 
	        // miCut
	        // 
	        resources.ApplyResources(this.miCut, "miCut");
	        this.miCut.Image = global::FEI.FiniteAutomaton.Properties.Resources.small_cut;
	        this.miCut.Name = "miCut";
	        this.miCut.Click += new System.EventHandler(this.miCut_Click);
	        // 
	        // miCopy
	        // 
	        resources.ApplyResources(this.miCopy, "miCopy");
	        this.miCopy.Image = global::FEI.FiniteAutomaton.Properties.Resources.small_copy;
	        this.miCopy.Name = "miCopy";
	        this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
	        // 
	        // miPaste
	        // 
	        resources.ApplyResources(this.miPaste, "miPaste");
	        this.miPaste.Image = global::FEI.FiniteAutomaton.Properties.Resources.small_paste;
	        this.miPaste.Name = "miPaste";
	        this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
	        // 
	        // miDelete
	        // 
	        resources.ApplyResources(this.miDelete, "miDelete");
	        this.miDelete.Name = "miDelete";
	        this.miDelete.Click += new System.EventHandler(this.miDelete_Click);
	        // 
	        // toolStripMenuItem10
	        // 
	        resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
	        this.toolStripMenuItem10.Name = "toolStripMenuItem10";
	        // 
	        // miSelectAll
	        // 
	        resources.ApplyResources(this.miSelectAll, "miSelectAll");
	        this.miSelectAll.Name = "miSelectAll";
	        this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
	        // 
	        // toolStripMenuItem4
	        // 
	        resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
	        this.toolStripMenuItem4.Name = "toolStripMenuItem4";
	        // 
	        // miFind
	        // 
	        resources.ApplyResources(this.miFind, "miFind");
	        this.miFind.Name = "miFind";
	        this.miFind.Click += new System.EventHandler(this.miFind_Click);
	        // 
	        // miReplace
	        // 
	        resources.ApplyResources(this.miReplace, "miReplace");
	        this.miReplace.Name = "miReplace";
	        this.miReplace.Click += new System.EventHandler(this.miReplace_Click);
	        // 
	        // miMachine
	        // 
	        resources.ApplyResources(this.miMachine, "miMachine");
	        this.miMachine.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTransitions, this.miTape, this.toolStripMenuItem14, this.miSettings });
	        this.miMachine.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miMachine.MergeIndex = 3;
	        this.miMachine.Name = "miMachine";
	        // 
	        // miTransitions
	        // 
	        resources.ApplyResources(this.miTransitions, "miTransitions");
	        this.miTransitions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAddTransition, this.toolStripMenuItem12, this.miTransitionFormat });
	        this.miTransitions.Name = "miTransitions";
	        // 
	        // miAddTransition
	        // 
	        resources.ApplyResources(this.miAddTransition, "miAddTransition");
	        this.miAddTransition.Name = "miAddTransition";
	        this.miAddTransition.Click += new System.EventHandler(this.miAddTransition_Click);
	        // 
	        // toolStripMenuItem12
	        // 
	        resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
	        this.toolStripMenuItem12.Name = "toolStripMenuItem12";
	        // 
	        // miTransitionFormat
	        // 
	        resources.ApplyResources(this.miTransitionFormat, "miTransitionFormat");
	        this.miTransitionFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTFormat10, this.toolStripSeparator2, this.miTFormat1, this.miTFormat2, this.miTFormat3, this.toolStripMenuItem13, this.miTFormat4, this.miTFormat5, this.miTFormat6, this.miTFormat7, this.miTFormat8, this.miTFormat9 });
	        this.miTransitionFormat.Name = "miTransitionFormat";
	        // 
	        // miTFormat10
	        // 
	        resources.ApplyResources(this.miTFormat10, "miTFormat10");
	        this.miTFormat10.Checked = true;
	        this.miTFormat10.CheckState = System.Windows.Forms.CheckState.Checked;
	        this.miTFormat10.Name = "miTFormat10";
	        this.miTFormat10.Click += new System.EventHandler(this.miTFormat10_Click);
	        // 
	        // toolStripSeparator2
	        // 
	        resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
	        this.toolStripSeparator2.Name = "toolStripSeparator2";
	        // 
	        // miTFormat1
	        // 
	        resources.ApplyResources(this.miTFormat1, "miTFormat1");
	        this.miTFormat1.Name = "miTFormat1";
	        this.miTFormat1.Click += new System.EventHandler(this.miTFormat1_Click);
	        // 
	        // miTFormat2
	        // 
	        resources.ApplyResources(this.miTFormat2, "miTFormat2");
	        this.miTFormat2.Name = "miTFormat2";
	        this.miTFormat2.Click += new System.EventHandler(this.miTFormat2_Click);
	        // 
	        // miTFormat3
	        // 
	        resources.ApplyResources(this.miTFormat3, "miTFormat3");
	        this.miTFormat3.Name = "miTFormat3";
	        this.miTFormat3.Click += new System.EventHandler(this.miTFormat3_Click);
	        // 
	        // toolStripMenuItem13
	        // 
	        resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
	        this.toolStripMenuItem13.Name = "toolStripMenuItem13";
	        // 
	        // miTFormat4
	        // 
	        resources.ApplyResources(this.miTFormat4, "miTFormat4");
	        this.miTFormat4.Name = "miTFormat4";
	        this.miTFormat4.Click += new System.EventHandler(this.miTFormat4_Click);
	        // 
	        // miTFormat5
	        // 
	        resources.ApplyResources(this.miTFormat5, "miTFormat5");
	        this.miTFormat5.Name = "miTFormat5";
	        this.miTFormat5.Click += new System.EventHandler(this.miTFormat5_Click);
	        // 
	        // miTFormat6
	        // 
	        resources.ApplyResources(this.miTFormat6, "miTFormat6");
	        this.miTFormat6.Name = "miTFormat6";
	        this.miTFormat6.Click += new System.EventHandler(this.miTFormat6_Click);
	        // 
	        // miTFormat7
	        // 
	        resources.ApplyResources(this.miTFormat7, "miTFormat7");
	        this.miTFormat7.Name = "miTFormat7";
	        this.miTFormat7.Click += new System.EventHandler(this.miTFormat7_Click);
	        // 
	        // miTFormat8
	        // 
	        resources.ApplyResources(this.miTFormat8, "miTFormat8");
	        this.miTFormat8.Name = "miTFormat8";
	        this.miTFormat8.Click += new System.EventHandler(this.miTFormat8_Click);
	        // 
	        // miTFormat9
	        // 
	        resources.ApplyResources(this.miTFormat9, "miTFormat9");
	        this.miTFormat9.Name = "miTFormat9";
	        this.miTFormat9.Click += new System.EventHandler(this.miTFormat9_Click);
	        // 
	        // miTape
	        // 
	        resources.ApplyResources(this.miTape, "miTape");
	        this.miTape.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miInsertSymbols, this.toolStripSeparator1, this.miClearTape, this.toolStripMenuItem5, this.miExportTape, this.miImportTape, this.toolStripMenuItem6, this.miTapeStatistics });
	        this.miTape.Name = "miTape";
	        // 
	        // miInsertSymbols
	        // 
	        resources.ApplyResources(this.miInsertSymbols, "miInsertSymbols");
	        this.miInsertSymbols.Name = "miInsertSymbols";
	        this.miInsertSymbols.Click += new System.EventHandler(this.miInsertSymbols_Click);
	        // 
	        // toolStripSeparator1
	        // 
	        resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
	        this.toolStripSeparator1.Name = "toolStripSeparator1";
	        // 
	        // miClearTape
	        // 
	        resources.ApplyResources(this.miClearTape, "miClearTape");
	        this.miClearTape.Name = "miClearTape";
	        this.miClearTape.Click += new System.EventHandler(this.miClearTape_Click);
	        // 
	        // toolStripMenuItem5
	        // 
	        resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
	        this.toolStripMenuItem5.Name = "toolStripMenuItem5";
	        // 
	        // miExportTape
	        // 
	        resources.ApplyResources(this.miExportTape, "miExportTape");
	        this.miExportTape.Name = "miExportTape";
	        this.miExportTape.Click += new System.EventHandler(this.miExportTape_Click);
	        // 
	        // miImportTape
	        // 
	        resources.ApplyResources(this.miImportTape, "miImportTape");
	        this.miImportTape.Name = "miImportTape";
	        this.miImportTape.Click += new System.EventHandler(this.miImportTape_Click);
	        // 
	        // toolStripMenuItem6
	        // 
	        resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
	        this.toolStripMenuItem6.Name = "toolStripMenuItem6";
	        // 
	        // miTapeStatistics
	        // 
	        resources.ApplyResources(this.miTapeStatistics, "miTapeStatistics");
	        this.miTapeStatistics.Name = "miTapeStatistics";
	        this.miTapeStatistics.Click += new System.EventHandler(this.miTapeStatistics_Click);
	        // 
	        // toolStripMenuItem14
	        // 
	        resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
	        this.toolStripMenuItem14.Name = "toolStripMenuItem14";
	        // 
	        // miSettings
	        // 
	        resources.ApplyResources(this.miSettings, "miSettings");
	        this.miSettings.Name = "miSettings";
	        this.miSettings.Click += new System.EventHandler(this.miSettings_Click);
	        // 
	        // miSimulation
	        // 
	        resources.ApplyResources(this.miSimulation, "miSimulation");
	        this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miRun, this.miPause, this.miStep, this.miStop, this.toolStripMenuItem9, this.miBreaks, this.toolStripMenuItem11, this.miWriteLog, this.miStoreOriginalTape });
	        this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miSimulation.MergeIndex = 4;
	        this.miSimulation.Name = "miSimulation";
	        // 
	        // miRun
	        // 
	        resources.ApplyResources(this.miRun, "miRun");
	        this.miRun.Image = global::FEI.FiniteAutomaton.Properties.Resources.run;
	        this.miRun.Name = "miRun";
	        this.miRun.Click += new System.EventHandler(this.miRun_Click);
	        // 
	        // miPause
	        // 
	        resources.ApplyResources(this.miPause, "miPause");
	        this.miPause.Image = global::FEI.FiniteAutomaton.Properties.Resources.pause;
	        this.miPause.Name = "miPause";
	        this.miPause.Click += new System.EventHandler(this.miPause_Click);
	        // 
	        // miStep
	        // 
	        resources.ApplyResources(this.miStep, "miStep");
	        this.miStep.Image = global::FEI.FiniteAutomaton.Properties.Resources.next;
	        this.miStep.Name = "miStep";
	        this.miStep.Click += new System.EventHandler(this.miStep_Click);
	        // 
	        // miStop
	        // 
	        resources.ApplyResources(this.miStop, "miStop");
	        this.miStop.Image = global::FEI.FiniteAutomaton.Properties.Resources.stop;
	        this.miStop.Name = "miStop";
	        this.miStop.Click += new System.EventHandler(this.miStop_Click);
	        // 
	        // toolStripMenuItem9
	        // 
	        resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
	        this.toolStripMenuItem9.Name = "toolStripMenuItem9";
	        // 
	        // miBreaks
	        // 
	        resources.ApplyResources(this.miBreaks, "miBreaks");
	        this.miBreaks.Name = "miBreaks";
	        // 
	        // toolStripMenuItem11
	        // 
	        resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
	        this.toolStripMenuItem11.Name = "toolStripMenuItem11";
	        // 
	        // miWriteLog
	        // 
	        resources.ApplyResources(this.miWriteLog, "miWriteLog");
	        this.miWriteLog.Checked = true;
	        this.miWriteLog.CheckOnClick = true;
	        this.miWriteLog.CheckState = System.Windows.Forms.CheckState.Checked;
	        this.miWriteLog.Name = "miWriteLog";
	        this.miWriteLog.Click += new System.EventHandler(this.miWriteLog_Click);
	        // 
	        // miStoreOriginalTape
	        // 
	        resources.ApplyResources(this.miStoreOriginalTape, "miStoreOriginalTape");
	        this.miStoreOriginalTape.Checked = true;
	        this.miStoreOriginalTape.CheckOnClick = true;
	        this.miStoreOriginalTape.CheckState = System.Windows.Forms.CheckState.Checked;
	        this.miStoreOriginalTape.Name = "miStoreOriginalTape";
	        this.miStoreOriginalTape.Click += new System.EventHandler(this.miStoreOriginalTape_Click);
	        // 
	        // txtFind
	        // 
	        resources.ApplyResources(this.txtFind, "txtFind");
	        this.txtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
	        this.txtFind.Name = "txtFind";
	        this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
	        this.txtFind.Click += new System.EventHandler(this.txtFind_Click);
	        // 
	        // helpToolStripMenuItem
	        // 
	        resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
	        this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miAbout });
	        this.helpToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
	        this.helpToolStripMenuItem.MergeIndex = 10;
	        this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
	        // 
	        // miAbout
	        // 
	        resources.ApplyResources(this.miAbout, "miAbout");
	        this.miAbout.MergeAction = System.Windows.Forms.MergeAction.Replace;
	        this.miAbout.Name = "miAbout";
	        this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
	        // 
	        // kopírovaťToolStripMenuItem
	        // 
	        resources.ApplyResources(this.kopírovaťToolStripMenuItem, "kopírovaťToolStripMenuItem");
	        this.kopírovaťToolStripMenuItem.Name = "kopírovaťToolStripMenuItem";
	        // 
	        // toolStripMenuItem3
	        // 
	        resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
	        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
	        // 
	        // označiťVšetkoToolStripMenuItem
	        // 
	        resources.ApplyResources(this.označiťVšetkoToolStripMenuItem, "označiťVšetkoToolStripMenuItem");
	        this.označiťVšetkoToolStripMenuItem.Name = "označiťVšetkoToolStripMenuItem";
	        // 
	        // toolStripMenuItem7
	        // 
	        resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
	        this.toolStripMenuItem7.Name = "toolStripMenuItem7";
	        // 
	        // toolStripMenuItem8
	        // 
	        resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
	        this.toolStripMenuItem8.Name = "toolStripMenuItem8";
	        // 
	        // saveFileDialog1
	        // 
	        this.saveFileDialog1.DefaultExt = "tm";
	        resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
	        this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
	        // 
	        // toolStripPanel1
	        // 
	        resources.ApplyResources(this.toolStripPanel1, "toolStripPanel1");
	        this.toolStripPanel1.Controls.Add(this.menuStrip1);
	        this.toolStripPanel1.Controls.Add(this.mainToolStrip);
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
	        resources.ApplyResources(this.newStripButton, "newStripButton");
	        this.newStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.newStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources._new;
	        this.newStripButton.Name = "newStripButton";
	        this.newStripButton.Click += new System.EventHandler(this.newStripButton_Click);
	        // 
	        // openToolStripButton
	        // 
	        resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
	        this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.openToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.open;
	        this.openToolStripButton.Name = "openToolStripButton";
	        this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
	        // 
	        // saveToolStripButton
	        // 
	        resources.ApplyResources(this.saveToolStripButton, "saveToolStripButton");
	        this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.saveToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.save;
	        this.saveToolStripButton.Name = "saveToolStripButton";
	        this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
	        // 
	        // toolStripSeparator3
	        // 
	        resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
	        this.toolStripSeparator3.Name = "toolStripSeparator3";
	        // 
	        // runToolStripButton
	        // 
	        resources.ApplyResources(this.runToolStripButton, "runToolStripButton");
	        this.runToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.run;
	        this.runToolStripButton.Name = "runToolStripButton";
	        this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
	        // 
	        // breakToolStripButton
	        // 
	        resources.ApplyResources(this.breakToolStripButton, "breakToolStripButton");
	        this.breakToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.pause;
	        this.breakToolStripButton.Name = "breakToolStripButton";
	        this.breakToolStripButton.Click += new System.EventHandler(this.breakToolStripButton_Click);
	        // 
	        // stopToolStripButton
	        // 
	        resources.ApplyResources(this.stopToolStripButton, "stopToolStripButton");
	        this.stopToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.stop;
	        this.stopToolStripButton.Name = "stopToolStripButton";
	        this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
	        // 
	        // toolStripSeparator4
	        // 
	        resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
	        this.toolStripSeparator4.Name = "toolStripSeparator4";
	        // 
	        // stepToolStripButton
	        // 
	        resources.ApplyResources(this.stepToolStripButton, "stepToolStripButton");
	        this.stepToolStripButton.Image = global::FEI.FiniteAutomaton.Properties.Resources.next;
	        this.stepToolStripButton.Name = "stepToolStripButton";
	        this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
	        // 
	        // FiniteAutomatonForm
	        // 
	        resources.ApplyResources(this, "$this");
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
	        this.Controls.Add(this.splitContainer2);
	        this.Controls.Add(this.toolStripPanel1);
	        this.Controls.Add(this.statusStrip);
	        this.DoubleBuffered = true;
	        this.MainMenuStrip = this.menuStrip1;
	        this.Name = "FiniteAutomatonForm";
	        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTuringMachine_FormClosed);
	        this.Load += new System.EventHandler(this.frmTuringMachine_Load);
	        this.splitContainer1.Panel1.ResumeLayout(false);
	        this.splitContainer1.Panel1.PerformLayout();
	        this.splitContainer1.Panel2.ResumeLayout(false);
	        this.splitContainer1.Panel2.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
	        this.splitContainer1.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.pFunctions)).EndInit();
	        this.splitContainer2.Panel1.ResumeLayout(false);
	        this.splitContainer2.Panel1.PerformLayout();
	        this.splitContainer2.Panel2.ResumeLayout(false);
	        this.splitContainer2.Panel2.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
	        this.splitContainer2.ResumeLayout(false);
	        this.tcMain.ResumeLayout(false);
	        this.functionsTab.ResumeLayout(false);
	        this.statesTab.ResumeLayout(false);
	        this.processTab.ResumeLayout(false);
	        this.processTab.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.pThreads)).EndInit();
	        this.logTab.ResumeLayout(false);
	        ((System.ComponentModel.ISupportInitialize)(this.pLog)).EndInit();
	        this.formalSpecificationTab.ResumeLayout(false);
	        this.formalSpecificationMenu.ResumeLayout(false);
	        this.speedPanel.ResumeLayout(false);
	        this.speedPanel.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
	        this.statusStrip.ResumeLayout(false);
	        this.statusStrip.PerformLayout();
	        this.menuStrip1.ResumeLayout(false);
	        this.menuStrip1.PerformLayout();
	        this.toolStripPanel1.ResumeLayout(false);
	        this.toolStripPanel1.PerformLayout();
	        this.mainToolStrip.ResumeLayout(false);
	        this.mainToolStrip.PerformLayout();
	        this.ResumeLayout(false);
	        this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage functionsTab;
        private System.Windows.Forms.TabPage processTab;
        private System.Windows.Forms.TabPage logTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStepCount;
        private System.Windows.Forms.PictureBox pThreads;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNewFile;
        private System.Windows.Forms.ToolStripMenuItem miOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miSaveFile;
        private System.Windows.Forms.ToolStripMenuItem miSaveAsFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miExitmiExitmiExit;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem kopírovaťToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem označiťVšetkoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miFind;
        private System.Windows.Forms.ToolStripMenuItem miReplace;
        private System.Windows.Forms.ToolStripMenuItem miTape;
        private System.Windows.Forms.ToolStripMenuItem miInsertSymbols;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miClearTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miExportTape;
        private System.Windows.Forms.ToolStripMenuItem miImportTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem miTapeStatistics;
        private System.Windows.Forms.ToolStripMenuItem miSimulation;
        private System.Windows.Forms.ToolStripMenuItem miRun;
        private System.Windows.Forms.ToolStripMenuItem miPause;
        private System.Windows.Forms.ToolStripMenuItem miStep;
        private System.Windows.Forms.ToolStripMenuItem miStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem miBreaks;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private System.Windows.Forms.VScrollBar sbyLog;
        private System.Windows.Forms.PictureBox pLog;
        private System.Windows.Forms.TabPage statesTab;
        private System.Windows.Forms.ToolStripMenuItem miWriteLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentState;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.Button bAddState;
        private System.Windows.Forms.ToolStripMenuItem miStoreOriginalTape;
        private System.Windows.Forms.VScrollBar sbyThreads;
        private System.Windows.Forms.Label lblThreadCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem miTransitions;
        private System.Windows.Forms.ToolStripMenuItem miTransitionFormat;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem miAddTransition;
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
        private System.Windows.Forms.ToolStripMenuItem miMachine;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private HScrollBar sbxLog;
        private ToolStripSeparator toolStripMenuItem14;
        private ToolStripMenuItem miTFormat10;
        private ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bAddTFunction;
        private SyntaxTextBox txtCode;
        private Label label5;
        private System.Windows.Forms.PictureBox pFunctions;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.VScrollBar sbyFunctions;
        private TabPage formalSpecificationTab;
        private WebBrowser formalSpecifiaction;
        private ContextMenuStrip formalSpecificationMenu;
        private ToolStripMenuItem formalSpecSaveAs;
        private ToolStripMenuItem formalSpecPrint;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lstErrors;        
        private HScrollBar sbxThreads;
        private StateDiagramControl stateDiagramControl;
        private InfiniteTapeControl infiniteTapeControl;
        private System.Windows.Forms.ToolStripPanel toolStripPanel1;
        private System.Windows.Forms.ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ToolStripButton breakToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton stepToolStripButton;
        private System.Windows.Forms.Panel speedPanel;
        private TrackBar tbSpeed;
        private Label label3;
    }
}

