using System.Windows.Forms;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Controls.RegisterList;
using FEI.SimStudio.Components.Registers;

namespace FEI.RandomAccessMachine {
	partial class RamSimulatorForm
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
	        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RamSimulatorForm));
	        FEI.SimStudio.Components.Registers.InfiniteRegisters infiniteRegisters1 = new FEI.SimStudio.Components.Registers.InfiniteRegisters();
	        this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
	        this.panel1 = new System.Windows.Forms.Panel();
	        this.speedPanel = new System.Windows.Forms.Panel();
	        this.tbSpeed = new System.Windows.Forms.TrackBar();
	        this.label2 = new System.Windows.Forms.Label();
	        this.lstRegs = new FEI.SimStudio.Components.Controls.RegisterList.RegisterList();
	        this.ftInputTape = new FEI.SimStudio.Components.Controls.InputOutputTape();
	        this.ftOutputTape = new FEI.SimStudio.Components.Controls.InputOutputTape();
	        this.lblInputTape = new System.Windows.Forms.Label();
	        this.lblOutputTape = new System.Windows.Forms.Label();
	        this.txtProgram = new FEI.SimStudio.Components.Controls.SyntaxTextBox();
	        this.pProc = new System.Windows.Forms.PictureBox();
	        this.picProgram = new System.Windows.Forms.PictureBox();
	        this.sbyProgram = new System.Windows.Forms.VScrollBar();
	        this.errorTitleLabel = new System.Windows.Forms.Label();
	        this.errorTextBox = new System.Windows.Forms.TextBox();
	        this.closeErrorsButton = new System.Windows.Forms.Button();
	        this.statusStrip = new System.Windows.Forms.StatusStrip();
	        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
	        this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
	        this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
	        this.menuStrip1 = new System.Windows.Forms.MenuStrip();
	        this.miFile = new System.Windows.Forms.ToolStripMenuItem();
	        this.miNew = new System.Windows.Forms.ToolStripMenuItem();
	        this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
	        this.miSave = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSaveAs = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
	        this.miExit = new System.Windows.Forms.ToolStripMenuItem();
	        this.miEdit = new System.Windows.Forms.ToolStripMenuItem();
	        this.miCut = new System.Windows.Forms.ToolStripMenuItem();
	        this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
	        this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
	        this.miDelete = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
	        this.miSelectAll = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
	        this.miFind = new System.Windows.Forms.ToolStripMenuItem();
	        this.miReplace = new System.Windows.Forms.ToolStripMenuItem();
	        this.miView = new System.Windows.Forms.ToolStripMenuItem();
	        this.miViewAll = new System.Windows.Forms.ToolStripMenuItem();
	        this.miViewCode = new System.Windows.Forms.ToolStripMenuItem();
	        this.miViewSimulation = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
	        this.miScreen = new System.Windows.Forms.ToolStripMenuItem();
	        this.miStack = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
	        this.miConsole = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSimulation = new System.Windows.Forms.ToolStripMenuItem();
	        this.miRun = new System.Windows.Forms.ToolStripMenuItem();
	        this.miRunMaxSpeed = new System.Windows.Forms.ToolStripMenuItem();
	        this.miPause = new System.Windows.Forms.ToolStripMenuItem();
	        this.miStep = new System.Windows.Forms.ToolStripMenuItem();
	        this.miStop = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
	        this.miBreaks = new System.Windows.Forms.ToolStripMenuItem();
	        this.miTools = new System.Windows.Forms.ToolStripMenuItem();
	        this.miTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.miClearTapes = new System.Windows.Forms.ToolStripMenuItem();
	        this.miClearInputTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.miClearOutputTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
	        this.miAutoClearOutput = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
	        this.miExportInputTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.miExportOutputTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
	        this.miImportInputTape = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
	        this.miConvertFromC = new System.Windows.Forms.ToolStripMenuItem();
	        this.miConvertFromPascal = new System.Windows.Forms.ToolStripMenuItem();
	        this.miConvertFromBasic = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
	        this.miComplexity = new System.Windows.Forms.ToolStripMenuItem();
	        this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
	        this.instructionSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        this.miSettings = new System.Windows.Forms.ToolStripMenuItem();
	        this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
	        this.miAbout = new System.Windows.Forms.ToolStripMenuItem();
	        this.txtFind = new System.Windows.Forms.ToolStripTextBox();
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
	        this.label3 = new System.Windows.Forms.Label();
	        this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
	        ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
	        this.mainSplitContainer.Panel1.SuspendLayout();
	        this.mainSplitContainer.Panel2.SuspendLayout();
	        this.mainSplitContainer.SuspendLayout();
	        this.panel1.SuspendLayout();
	        this.speedPanel.SuspendLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.pProc)).BeginInit();
	        ((System.ComponentModel.ISupportInitialize)(this.picProgram)).BeginInit();
	        this.statusStrip.SuspendLayout();
	        this.menuStrip1.SuspendLayout();
	        this.toolStripPanel1.SuspendLayout();
	        this.mainToolStrip.SuspendLayout();
	        this.SuspendLayout();
	        // 
	        // mainSplitContainer
	        // 
	        resources.ApplyResources(this.mainSplitContainer, "mainSplitContainer");
	        this.mainSplitContainer.Name = "mainSplitContainer";
	        // 
	        // mainSplitContainer.Panel1
	        // 
	        this.mainSplitContainer.Panel1.Controls.Add(this.panel1);
	        // 
	        // mainSplitContainer.Panel2
	        // 
	        this.mainSplitContainer.Panel2.Controls.Add(this.errorTitleLabel);
	        this.mainSplitContainer.Panel2.Controls.Add(this.errorTextBox);
	        this.mainSplitContainer.Panel2.Controls.Add(this.closeErrorsButton);
	        this.mainSplitContainer.Panel2Collapsed = true;
	        // 
	        // panel1
	        // 
	        this.panel1.Controls.Add(this.speedPanel);
	        this.panel1.Controls.Add(this.lstRegs);
	        this.panel1.Controls.Add(this.ftInputTape);
	        this.panel1.Controls.Add(this.ftOutputTape);
	        this.panel1.Controls.Add(this.lblInputTape);
	        this.panel1.Controls.Add(this.lblOutputTape);
	        this.panel1.Controls.Add(this.txtProgram);
	        this.panel1.Controls.Add(this.pProc);
	        this.panel1.Controls.Add(this.picProgram);
	        this.panel1.Controls.Add(this.sbyProgram);
	        resources.ApplyResources(this.panel1, "panel1");
	        this.panel1.Name = "panel1";
	        // 
	        // speedPanel
	        // 
	        this.speedPanel.BackColor = System.Drawing.Color.White;
	        this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.speedPanel.Controls.Add(this.tbSpeed);
	        this.speedPanel.Controls.Add(this.label2);
	        resources.ApplyResources(this.speedPanel, "speedPanel");
	        this.speedPanel.Name = "speedPanel";
	        // 
	        // tbSpeed
	        // 
	        resources.ApplyResources(this.tbSpeed, "tbSpeed");
	        this.tbSpeed.BackColor = System.Drawing.Color.White;
	        this.tbSpeed.Maximum = 20;
	        this.tbSpeed.Name = "tbSpeed";
	        this.tbSpeed.Value = 19;
	        this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
	        // 
	        // label2
	        // 
	        resources.ApplyResources(this.label2, "label2");
	        this.label2.BackColor = System.Drawing.Color.Transparent;
	        this.label2.Name = "label2";
	        // 
	        // lstRegs
	        // 
	        resources.ApplyResources(this.lstRegs, "lstRegs");
	        this.lstRegs.MaximalCount = 10000;
	        this.lstRegs.Name = "lstRegs";
	        this.lstRegs.Reading = false;
	        this.lstRegs.ReadingPos = 0;
	        this.lstRegs.Regs = infiniteRegisters1;
	        this.lstRegs.ScrollValue = 0;
	        this.lstRegs.Writing = false;
	        this.lstRegs.WritingPos = 0;
	        this.lstRegs.ViewPositionChange += new System.EventHandler(this.lstRegs_ViewPositionChange);
	        this.lstRegs.RegisterChanged += new FEI.SimStudio.Components.Controls.RegisterList.RegisterList.RegisterChangedEventHandler(this.lstRegs_RegisterChanged);
	        // 
	        // ftInputTape
	        // 
	        this.ftInputTape.AddRecordButton = true;
	        resources.ApplyResources(this.ftInputTape, "ftInputTape");
	        this.ftInputTape.CellWidth = 80;
	        this.ftInputTape.Name = "ftInputTape";
	        this.ftInputTape.Records = new string[0];
	        this.ftInputTape.Rewritable = true;
	        this.ftInputTape.RecordAdded += new System.EventHandler(this.ftInputTape_RecordAdded);
	        this.ftInputTape.RecordChanged += new System.EventHandler(this.ftInputTape_RecordChanged);
	        // 
	        // ftOutputTape
	        // 
	        this.ftOutputTape.AddRecordButton = false;
	        resources.ApplyResources(this.ftOutputTape, "ftOutputTape");
	        this.ftOutputTape.CellWidth = 80;
	        this.ftOutputTape.Name = "ftOutputTape";
	        this.ftOutputTape.Records = new string[0];
	        this.ftOutputTape.Rewritable = false;
	        // 
	        // lblInputTape
	        // 
	        resources.ApplyResources(this.lblInputTape, "lblInputTape");
	        this.lblInputTape.Name = "lblInputTape";
	        // 
	        // lblOutputTape
	        // 
	        resources.ApplyResources(this.lblOutputTape, "lblOutputTape");
	        this.lblOutputTape.Name = "lblOutputTape";
	        // 
	        // txtProgram
	        // 
	        resources.ApplyResources(this.txtProgram, "txtProgram");
	        this.txtProgram.HideSelection = false;
	        this.txtProgram.Name = "txtProgram";
	        this.txtProgram.SelectedText = "";
	        this.txtProgram.SelectionLength = 0;
	        this.txtProgram.SelectionStart = 0;
	        this.txtProgram.TextChanged += new FEI.SimStudio.Components.Controls.SyntaxTextBox.TextChangedEventHandler(this.txtProgram_TextChanged);
	        // 
	        // pProc
	        // 
	        resources.ApplyResources(this.pProc, "pProc");
	        this.pProc.Name = "pProc";
	        this.pProc.TabStop = false;
	        this.pProc.Paint += new System.Windows.Forms.PaintEventHandler(this.pProc_Paint);
	        this.pProc.Resize += new System.EventHandler(this.pProc_Resize);
	        // 
	        // picProgram
	        // 
	        resources.ApplyResources(this.picProgram, "picProgram");
	        this.picProgram.Name = "picProgram";
	        this.picProgram.TabStop = false;
	        this.picProgram.Paint += new System.Windows.Forms.PaintEventHandler(this.picProgram_Paint);
	        this.picProgram.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picProgram_MouseDown);
	        this.picProgram.Resize += new System.EventHandler(this.picProgram_Resize);
	        // 
	        // sbyProgram
	        // 
	        resources.ApplyResources(this.sbyProgram, "sbyProgram");
	        this.sbyProgram.Name = "sbyProgram";
	        this.sbyProgram.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sbyProgram_Scroll);
	        // 
	        // errorTitleLabel
	        // 
	        resources.ApplyResources(this.errorTitleLabel, "errorTitleLabel");
	        this.errorTitleLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
	        this.errorTitleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
	        this.errorTitleLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
	        this.errorTitleLabel.Name = "errorTitleLabel";
	        // 
	        // errorTextBox
	        // 
	        resources.ApplyResources(this.errorTextBox, "errorTextBox");
	        this.errorTextBox.BackColor = System.Drawing.SystemColors.Window;
	        this.errorTextBox.Name = "errorTextBox";
	        this.errorTextBox.ReadOnly = true;
	        // 
	        // closeErrorsButton
	        // 
	        resources.ApplyResources(this.closeErrorsButton, "closeErrorsButton");
	        this.closeErrorsButton.Name = "closeErrorsButton";
	        this.closeErrorsButton.UseVisualStyleBackColor = true;
	        this.closeErrorsButton.Click += new System.EventHandler(this.closeErrorsButton_Click);
	        // 
	        // statusStrip
	        // 
	        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
	        resources.ApplyResources(this.statusStrip, "statusStrip");
	        this.statusStrip.Name = "statusStrip";
	        // 
	        // lblStatus
	        // 
	        this.lblStatus.MergeAction = System.Windows.Forms.MergeAction.Replace;
	        this.lblStatus.MergeIndex = 0;
	        this.lblStatus.Name = "lblStatus";
	        resources.ApplyResources(this.lblStatus, "lblStatus");
	        // 
	        // openFileDialog1
	        // 
	        this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
	        // 
	        // saveFileDialog1
	        // 
	        this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
	        // 
	        // menuStrip1
	        // 
	        resources.ApplyResources(this.menuStrip1, "menuStrip1");
	        this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miFile, this.miEdit, this.miView, this.miSimulation, this.miTools, this.miHelp, this.txtFind });
	        this.menuStrip1.Name = "menuStrip1";
	        // 
	        // miFile
	        // 
	        this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miNew, this.miOpen, this.toolStripMenuItem1, this.miSave, this.miSaveAs, this.toolStripMenuItem2, this.miExit });
	        this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miFile.MergeIndex = 1;
	        this.miFile.Name = "miFile";
	        resources.ApplyResources(this.miFile, "miFile");
	        // 
	        // miNew
	        // 
	        this.miNew.Image = global::FEI.RandomAccessMachine.Properties.Resources.small_new;
	        resources.ApplyResources(this.miNew, "miNew");
	        this.miNew.Name = "miNew";
	        this.miNew.Click += new System.EventHandler(this.miNew_Click);
	        // 
	        // miOpen
	        // 
	        this.miOpen.Image = global::FEI.RandomAccessMachine.Properties.Resources.open;
	        resources.ApplyResources(this.miOpen, "miOpen");
	        this.miOpen.Name = "miOpen";
	        this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
	        // 
	        // toolStripMenuItem1
	        // 
	        this.toolStripMenuItem1.Name = "toolStripMenuItem1";
	        resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
	        // 
	        // miSave
	        // 
	        this.miSave.Image = global::FEI.RandomAccessMachine.Properties.Resources.save;
	        resources.ApplyResources(this.miSave, "miSave");
	        this.miSave.Name = "miSave";
	        this.miSave.Click += new System.EventHandler(this.miSave_Click);
	        // 
	        // miSaveAs
	        // 
	        this.miSaveAs.Image = global::FEI.RandomAccessMachine.Properties.Resources.save;
	        this.miSaveAs.Name = "miSaveAs";
	        resources.ApplyResources(this.miSaveAs, "miSaveAs");
	        this.miSaveAs.Click += new System.EventHandler(this.miSaveAs_Click);
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
	        this.miExit.Click += new System.EventHandler(this.miExit_Click);
	        // 
	        // miEdit
	        // 
	        this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miCut, this.miCopy, this.miPaste, this.miDelete, this.toolStripMenuItem7, this.miSelectAll, this.toolStripMenuItem8, this.miFind, this.miReplace });
	        this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miEdit.MergeIndex = 2;
	        this.miEdit.Name = "miEdit";
	        resources.ApplyResources(this.miEdit, "miEdit");
	        // 
	        // miCut
	        // 
	        this.miCut.Image = global::FEI.RandomAccessMachine.Properties.Resources.small_cut;
	        resources.ApplyResources(this.miCut, "miCut");
	        this.miCut.Name = "miCut";
	        this.miCut.Click += new System.EventHandler(this.miCut_Click);
	        // 
	        // miCopy
	        // 
	        this.miCopy.Image = global::FEI.RandomAccessMachine.Properties.Resources.copy;
	        resources.ApplyResources(this.miCopy, "miCopy");
	        this.miCopy.Name = "miCopy";
	        this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
	        // 
	        // miPaste
	        // 
	        this.miPaste.Image = global::FEI.RandomAccessMachine.Properties.Resources.small_paste;
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
	        // toolStripMenuItem7
	        // 
	        this.toolStripMenuItem7.Name = "toolStripMenuItem7";
	        resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
	        // 
	        // miSelectAll
	        // 
	        this.miSelectAll.Name = "miSelectAll";
	        resources.ApplyResources(this.miSelectAll, "miSelectAll");
	        this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
	        // 
	        // toolStripMenuItem8
	        // 
	        this.toolStripMenuItem8.Name = "toolStripMenuItem8";
	        resources.ApplyResources(this.toolStripMenuItem8, "toolStripMenuItem8");
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
	        // miView
	        // 
	        this.miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miViewAll, this.miViewCode, this.miViewSimulation, this.toolStripMenuItem10, this.miScreen, this.miStack, this.toolStripMenuItem12, this.miConsole });
	        this.miView.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miView.MergeIndex = 3;
	        this.miView.Name = "miView";
	        resources.ApplyResources(this.miView, "miView");
	        // 
	        // miViewAll
	        // 
	        this.miViewAll.Checked = true;
	        this.miViewAll.CheckState = System.Windows.Forms.CheckState.Checked;
	        this.miViewAll.Name = "miViewAll";
	        resources.ApplyResources(this.miViewAll, "miViewAll");
	        this.miViewAll.Click += new System.EventHandler(this.miViewAll_Click);
	        // 
	        // miViewCode
	        // 
	        this.miViewCode.Name = "miViewCode";
	        resources.ApplyResources(this.miViewCode, "miViewCode");
	        this.miViewCode.Click += new System.EventHandler(this.miViewCode_Click);
	        // 
	        // miViewSimulation
	        // 
	        this.miViewSimulation.Name = "miViewSimulation";
	        resources.ApplyResources(this.miViewSimulation, "miViewSimulation");
	        this.miViewSimulation.Click += new System.EventHandler(this.miViewSimulation_Click);
	        // 
	        // toolStripMenuItem10
	        // 
	        this.toolStripMenuItem10.Name = "toolStripMenuItem10";
	        resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
	        // 
	        // miScreen
	        // 
	        this.miScreen.Name = "miScreen";
	        resources.ApplyResources(this.miScreen, "miScreen");
	        this.miScreen.Click += new System.EventHandler(this.miScreen_Click);
	        // 
	        // miStack
	        // 
	        this.miStack.Name = "miStack";
	        resources.ApplyResources(this.miStack, "miStack");
	        this.miStack.Click += new System.EventHandler(this.miStack_Click);
	        // 
	        // toolStripMenuItem12
	        // 
	        this.toolStripMenuItem12.Name = "toolStripMenuItem12";
	        resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
	        // 
	        // miConsole
	        // 
	        this.miConsole.Name = "miConsole";
	        resources.ApplyResources(this.miConsole, "miConsole");
	        this.miConsole.Click += new System.EventHandler(this.miConsole_Click);
	        // 
	        // miSimulation
	        // 
	        this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miRun, this.miRunMaxSpeed, this.miPause, this.miStep, this.miStop, this.toolStripMenuItem4, this.miBreaks });
	        this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miSimulation.MergeIndex = 4;
	        this.miSimulation.Name = "miSimulation";
	        resources.ApplyResources(this.miSimulation, "miSimulation");
	        // 
	        // miRun
	        // 
	        this.miRun.Image = global::FEI.RandomAccessMachine.Properties.Resources.run;
	        resources.ApplyResources(this.miRun, "miRun");
	        this.miRun.Name = "miRun";
	        this.miRun.Click += new System.EventHandler(this.miRun_Click);
	        // 
	        // miRunMaxSpeed
	        // 
	        this.miRunMaxSpeed.Image = global::FEI.RandomAccessMachine.Properties.Resources.run;
	        this.miRunMaxSpeed.Name = "miRunMaxSpeed";
	        resources.ApplyResources(this.miRunMaxSpeed, "miRunMaxSpeed");
	        this.miRunMaxSpeed.Click += new System.EventHandler(this.miRunMaxSpeed_Click);
	        // 
	        // miPause
	        // 
	        this.miPause.Image = global::FEI.RandomAccessMachine.Properties.Resources.pause;
	        resources.ApplyResources(this.miPause, "miPause");
	        this.miPause.Name = "miPause";
	        this.miPause.Click += new System.EventHandler(this.miPause_Click);
	        // 
	        // miStep
	        // 
	        this.miStep.Image = global::FEI.RandomAccessMachine.Properties.Resources.next;
	        this.miStep.Name = "miStep";
	        resources.ApplyResources(this.miStep, "miStep");
	        this.miStep.Click += new System.EventHandler(this.miStep_Click);
	        // 
	        // miStop
	        // 
	        this.miStop.Image = global::FEI.RandomAccessMachine.Properties.Resources.stop;
	        resources.ApplyResources(this.miStop, "miStop");
	        this.miStop.Name = "miStop";
	        this.miStop.Click += new System.EventHandler(this.miStop_Click);
	        // 
	        // toolStripMenuItem4
	        // 
	        this.toolStripMenuItem4.Name = "toolStripMenuItem4";
	        resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
	        // 
	        // miBreaks
	        // 
	        this.miBreaks.Name = "miBreaks";
	        resources.ApplyResources(this.miBreaks, "miBreaks");
	        // 
	        // miTools
	        // 
	        this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miTape, this.toolStripSeparator1, this.miConvertFromC, this.miConvertFromPascal, this.miConvertFromBasic, this.toolStripMenuItem3, this.miComplexity, this.toolStripMenuItem9, this.instructionSetToolStripMenuItem, this.miSettings });
	        this.miTools.MergeAction = System.Windows.Forms.MergeAction.Insert;
	        this.miTools.MergeIndex = 5;
	        this.miTools.Name = "miTools";
	        resources.ApplyResources(this.miTools, "miTools");
	        // 
	        // miTape
	        // 
	        this.miTape.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.miClearTapes, this.miClearInputTape, this.miClearOutputTape, this.toolStripMenuItem11, this.miAutoClearOutput, this.toolStripMenuItem5, this.miExportInputTape, this.miExportOutputTape, this.toolStripMenuItem6, this.miImportInputTape });
	        this.miTape.Name = "miTape";
	        resources.ApplyResources(this.miTape, "miTape");
	        // 
	        // miClearTapes
	        // 
	        this.miClearTapes.Name = "miClearTapes";
	        resources.ApplyResources(this.miClearTapes, "miClearTapes");
	        this.miClearTapes.Click += new System.EventHandler(this.miClearTapes_Click);
	        // 
	        // miClearInputTape
	        // 
	        this.miClearInputTape.Name = "miClearInputTape";
	        resources.ApplyResources(this.miClearInputTape, "miClearInputTape");
	        this.miClearInputTape.Click += new System.EventHandler(this.miClearInputTape_Click);
	        // 
	        // miClearOutputTape
	        // 
	        this.miClearOutputTape.Name = "miClearOutputTape";
	        resources.ApplyResources(this.miClearOutputTape, "miClearOutputTape");
	        this.miClearOutputTape.Click += new System.EventHandler(this.miClearOutputTape_Click);
	        // 
	        // toolStripMenuItem11
	        // 
	        this.toolStripMenuItem11.Name = "toolStripMenuItem11";
	        resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
	        // 
	        // miAutoClearOutput
	        // 
	        this.miAutoClearOutput.Checked = true;
	        this.miAutoClearOutput.CheckOnClick = true;
	        this.miAutoClearOutput.CheckState = System.Windows.Forms.CheckState.Checked;
	        this.miAutoClearOutput.Name = "miAutoClearOutput";
	        resources.ApplyResources(this.miAutoClearOutput, "miAutoClearOutput");
	        this.miAutoClearOutput.Click += new System.EventHandler(this.miAutoClearOutput_Click);
	        // 
	        // toolStripMenuItem5
	        // 
	        this.toolStripMenuItem5.Name = "toolStripMenuItem5";
	        resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
	        // 
	        // miExportInputTape
	        // 
	        this.miExportInputTape.Name = "miExportInputTape";
	        resources.ApplyResources(this.miExportInputTape, "miExportInputTape");
	        // 
	        // miExportOutputTape
	        // 
	        this.miExportOutputTape.Name = "miExportOutputTape";
	        resources.ApplyResources(this.miExportOutputTape, "miExportOutputTape");
	        // 
	        // toolStripMenuItem6
	        // 
	        this.toolStripMenuItem6.Name = "toolStripMenuItem6";
	        resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
	        // 
	        // miImportInputTape
	        // 
	        this.miImportInputTape.Name = "miImportInputTape";
	        resources.ApplyResources(this.miImportInputTape, "miImportInputTape");
	        // 
	        // toolStripSeparator1
	        // 
	        this.toolStripSeparator1.Name = "toolStripSeparator1";
	        resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
	        // 
	        // miConvertFromC
	        // 
	        this.miConvertFromC.Name = "miConvertFromC";
	        resources.ApplyResources(this.miConvertFromC, "miConvertFromC");
	        this.miConvertFromC.Click += new System.EventHandler(this.miConvertFromC_Click);
	        // 
	        // miConvertFromPascal
	        // 
	        this.miConvertFromPascal.Name = "miConvertFromPascal";
	        resources.ApplyResources(this.miConvertFromPascal, "miConvertFromPascal");
	        // 
	        // miConvertFromBasic
	        // 
	        this.miConvertFromBasic.Name = "miConvertFromBasic";
	        resources.ApplyResources(this.miConvertFromBasic, "miConvertFromBasic");
	        // 
	        // toolStripMenuItem3
	        // 
	        this.toolStripMenuItem3.Name = "toolStripMenuItem3";
	        resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
	        // 
	        // miComplexity
	        // 
	        this.miComplexity.Name = "miComplexity";
	        resources.ApplyResources(this.miComplexity, "miComplexity");
	        this.miComplexity.Click += new System.EventHandler(this.miComplexity_Click);
	        // 
	        // toolStripMenuItem9
	        // 
	        this.toolStripMenuItem9.Name = "toolStripMenuItem9";
	        resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
	        // 
	        // instructionSetToolStripMenuItem
	        // 
	        this.instructionSetToolStripMenuItem.Name = "instructionSetToolStripMenuItem";
	        resources.ApplyResources(this.instructionSetToolStripMenuItem, "instructionSetToolStripMenuItem");
	        this.instructionSetToolStripMenuItem.Click += new System.EventHandler(this.instructionSetToolStripMenuItem_Click);
	        // 
	        // miSettings
	        // 
	        this.miSettings.Name = "miSettings";
	        resources.ApplyResources(this.miSettings, "miSettings");
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
	        // txtFind
	        // 
	        this.txtFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
	        this.txtFind.Name = "txtFind";
	        resources.ApplyResources(this.txtFind, "txtFind");
	        this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
	        this.txtFind.Click += new System.EventHandler(this.txtFind_Click);
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
	        this.newStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.small_new;
	        resources.ApplyResources(this.newStripButton, "newStripButton");
	        this.newStripButton.Name = "newStripButton";
	        this.newStripButton.Click += new System.EventHandler(this.newStripButton_Click);
	        // 
	        // openToolStripButton
	        // 
	        this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.openToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.open;
	        resources.ApplyResources(this.openToolStripButton, "openToolStripButton");
	        this.openToolStripButton.Name = "openToolStripButton";
	        this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
	        // 
	        // saveToolStripButton
	        // 
	        this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
	        this.saveToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.save;
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
	        this.runToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.run;
	        resources.ApplyResources(this.runToolStripButton, "runToolStripButton");
	        this.runToolStripButton.Name = "runToolStripButton";
	        this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
	        // 
	        // breakToolStripButton
	        // 
	        this.breakToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.pause;
	        resources.ApplyResources(this.breakToolStripButton, "breakToolStripButton");
	        this.breakToolStripButton.Name = "breakToolStripButton";
	        this.breakToolStripButton.Click += new System.EventHandler(this.breakToolStripButton_Click);
	        // 
	        // stopToolStripButton
	        // 
	        resources.ApplyResources(this.stopToolStripButton, "stopToolStripButton");
	        this.stopToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.stop;
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
	        this.stepToolStripButton.Image = global::FEI.RandomAccessMachine.Properties.Resources.next;
	        resources.ApplyResources(this.stepToolStripButton, "stepToolStripButton");
	        this.stepToolStripButton.Name = "stepToolStripButton";
	        this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
	        // 
	        // label3
	        // 
	        resources.ApplyResources(this.label3, "label3");
	        this.label3.BackColor = System.Drawing.Color.Transparent;
	        this.label3.Name = "label3";
	        // 
	        // languageToolStripMenuItem
	        // 
	        this.languageToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Remove;
	        this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
	        resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
	        // 
	        // RamSimulatorForm
	        // 
	        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
	        resources.ApplyResources(this, "$this");
	        this.Controls.Add(this.mainSplitContainer);
	        this.Controls.Add(this.statusStrip);
	        this.Controls.Add(this.toolStripPanel1);
	        this.DoubleBuffered = true;
	        this.MainMenuStrip = this.menuStrip1;
	        this.Name = "RamSimulatorForm";
	        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RAMSimulatorForm_FormClosed);
	        this.Load += new System.EventHandler(this.RAMSimulatorForm_Load);
	        this.Disposed += new System.EventHandler(this.RAMSimulatorForm_Disposed);
	        this.mainSplitContainer.Panel1.ResumeLayout(false);
	        this.mainSplitContainer.Panel2.ResumeLayout(false);
	        this.mainSplitContainer.Panel2.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
	        this.mainSplitContainer.ResumeLayout(false);
	        this.panel1.ResumeLayout(false);
	        this.panel1.PerformLayout();
	        this.speedPanel.ResumeLayout(false);
	        this.speedPanel.PerformLayout();
	        ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.pProc)).EndInit();
	        ((System.ComponentModel.ISupportInitialize)(this.picProgram)).EndInit();
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

        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;

        #endregion

        private InputOutputTape ftInputTape;
        private InputOutputTape ftOutputTape;
        private System.Windows.Forms.Label lblInputTape;
        private System.Windows.Forms.Label lblOutputTape;
        private SyntaxTextBox txtProgram;
        private System.Windows.Forms.PictureBox picProgram;
        private System.Windows.Forms.VScrollBar sbyProgram;
        private System.Windows.Forms.PictureBox pProc;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miNew;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miSave;
        private System.Windows.Forms.ToolStripMenuItem miSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miView;
        private System.Windows.Forms.ToolStripMenuItem miViewAll;
        private System.Windows.Forms.ToolStripMenuItem miViewCode;
        private System.Windows.Forms.ToolStripMenuItem miViewSimulation;
        private System.Windows.Forms.ToolStripMenuItem miTools;
        private System.Windows.Forms.ToolStripMenuItem miConvertFromC;
        private System.Windows.Forms.ToolStripMenuItem miConvertFromPascal;
        private System.Windows.Forms.ToolStripMenuItem miConvertFromBasic;
        private System.Windows.Forms.ToolStripMenuItem miSimulation;
        private System.Windows.Forms.ToolStripMenuItem miRun;
        private System.Windows.Forms.ToolStripMenuItem miPause;
        private System.Windows.Forms.ToolStripMenuItem miStep;
        private System.Windows.Forms.ToolStripMenuItem miStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem miBreaks;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem miSettings;
        private System.Windows.Forms.ToolStripMenuItem miTape;
        private System.Windows.Forms.ToolStripMenuItem miClearTapes;
        private System.Windows.Forms.ToolStripMenuItem miEdit;
        private System.Windows.Forms.ToolStripMenuItem miCut;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ToolStripMenuItem miDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem miSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem miFind;
        private System.Windows.Forms.ToolStripMenuItem miReplace;
        private System.Windows.Forms.ToolStripMenuItem miClearInputTape;
        private System.Windows.Forms.ToolStripMenuItem miClearOutputTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem miExportInputTape;
        private System.Windows.Forms.ToolStripMenuItem miExportOutputTape;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem miImportInputTape;
        private RegisterList lstRegs;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
        private System.Windows.Forms.ToolStripMenuItem miAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox txtFind;
        private System.Windows.Forms.ToolStripMenuItem miComplexity;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem miScreen;
        private System.Windows.Forms.ToolStripMenuItem miRunMaxSpeed;
        private ToolStripSeparator toolStripMenuItem11;
        private ToolStripMenuItem miAutoClearOutput;
        private ToolStripMenuItem miStack;
        private ToolStripSeparator toolStripMenuItem12;
        private ToolStripMenuItem miConsole;
        private ToolStripPanel toolStripPanel1;
        private ToolStrip mainToolStrip;
        private System.Windows.Forms.ToolStripButton newStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton runToolStripButton;
        private System.Windows.Forms.ToolStripButton breakToolStripButton;
        private System.Windows.Forms.ToolStripButton stopToolStripButton;
        private ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton stepToolStripButton;
        private Panel panel1;
        private Label label3;
        private Panel speedPanel;
        private TrackBar tbSpeed;
        private Label label2;
        private ToolStripMenuItem instructionSetToolStripMenuItem;
        private SplitContainer mainSplitContainer;
        private Button closeErrorsButton;
        private Label errorTitleLabel;
        private TextBox errorTextBox;
    }
}

