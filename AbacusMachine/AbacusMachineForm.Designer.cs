using System.Windows.Forms;
namespace DusanRodina.AbacusMachine {
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
			DusanRodina.SimStudio.Components.Registers.InfiniteRegisters infiniteRegisters1 = new DusanRodina.SimStudio.Components.Registers.InfiniteRegisters();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbacusMachineForm));
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabCode = new System.Windows.Forms.TabPage();
			this.speedPanel = new System.Windows.Forms.Panel();
			this.tbSpeed = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCode = new DusanRodina.SimStudio.Components.SyntaxTextBox();
			this.tabSimulation = new System.Windows.Forms.TabPage();
			this.pSimulation = new System.Windows.Forms.PictureBox();
			this.verticalScroll = new System.Windows.Forms.VScrollBar();
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lstRegisters = new DusanRodina.SimStudio.Components.RegisterList();
			this.menuStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabCode.SuspendLayout();
			this.speedPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
			this.tabSimulation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pSimulation)).BeginInit();
			this.toolStripPanel1.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile,
            this.miEdit,
            this.autokódToolStripMenuItem,
            this.miSimulation,
            this.miTools,
            this.miHelp});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(850, 24);
			this.menuStrip1.TabIndex = 23;
			// 
			// miFile
			// 
			this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewFile,
            this.miOpenFile,
            this.toolStripMenuItem2,
            this.miSaveFile,
            this.miSaveAsFile,
            this.toolStripMenuItem1,
            this.miExit});
			this.miFile.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.miFile.MergeIndex = 1;
			this.miFile.Name = "miFile";
			this.miFile.Size = new System.Drawing.Size(50, 20);
			this.miFile.Text = "Súbor";
			// 
			// miNewFile
			// 
			this.miNewFile.Image = global::DusanRodina.AbacusMachine.Properties.Resources.small_new;
			this.miNewFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miNewFile.Name = "miNewFile";
			this.miNewFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.miNewFile.Size = new System.Drawing.Size(155, 22);
			this.miNewFile.Text = "Nový";
			this.miNewFile.Click += new System.EventHandler(this.miNewFile_Click);
			// 
			// miOpenFile
			// 
			this.miOpenFile.Image = global::DusanRodina.AbacusMachine.Properties.Resources.open;
			this.miOpenFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miOpenFile.Name = "miOpenFile";
			this.miOpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.miOpenFile.Size = new System.Drawing.Size(155, 22);
			this.miOpenFile.Text = "Otvoriť";
			this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 6);
			// 
			// miSaveFile
			// 
			this.miSaveFile.Image = global::DusanRodina.AbacusMachine.Properties.Resources.save;
			this.miSaveFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miSaveFile.Name = "miSaveFile";
			this.miSaveFile.ShortcutKeyDisplayString = "Ctrl+S";
			this.miSaveFile.Size = new System.Drawing.Size(155, 22);
			this.miSaveFile.Text = "Uložiť";
			this.miSaveFile.Click += new System.EventHandler(this.miSaveFile_Click);
			// 
			// miSaveAsFile
			// 
			this.miSaveAsFile.Name = "miSaveAsFile";
			this.miSaveAsFile.Size = new System.Drawing.Size(155, 22);
			this.miSaveAsFile.Text = "Uložiť ako...";
			this.miSaveAsFile.Click += new System.EventHandler(this.miSaveAsFile_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 6);
			// 
			// miExit
			// 
			this.miExit.Name = "miExit";
			this.miExit.Size = new System.Drawing.Size(155, 22);
			this.miExit.Text = "Skončiť";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// miEdit
			// 
			this.miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCut,
            this.miCopy,
            this.miPaste,
            this.miDelete,
            this.toolStripMenuItem4,
            this.miSelectAll,
            this.toolStripMenuItem3,
            this.miFind,
            this.miReplace});
			this.miEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.miEdit.MergeIndex = 2;
			this.miEdit.Name = "miEdit";
			this.miEdit.Size = new System.Drawing.Size(56, 20);
			this.miEdit.Text = "Úpravy";
			// 
			// miCut
			// 
			this.miCut.Image = global::DusanRodina.AbacusMachine.Properties.Resources.small_cut;
			this.miCut.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miCut.Name = "miCut";
			this.miCut.Size = new System.Drawing.Size(194, 22);
			this.miCut.Text = "Vystrihnúť";
			this.miCut.Click += new System.EventHandler(this.miCut_Click);
			// 
			// miCopy
			// 
			this.miCopy.Image = global::DusanRodina.AbacusMachine.Properties.Resources.copy;
			this.miCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miCopy.Name = "miCopy";
			this.miCopy.Size = new System.Drawing.Size(194, 22);
			this.miCopy.Text = "Kopírovať";
			this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
			// 
			// miPaste
			// 
			this.miPaste.Image = global::DusanRodina.AbacusMachine.Properties.Resources.small_paste;
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
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(191, 6);
			// 
			// miSelectAll
			// 
			this.miSelectAll.Name = "miSelectAll";
			this.miSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.miSelectAll.Size = new System.Drawing.Size(194, 22);
			this.miSelectAll.Text = "Označiť všetko";
			this.miSelectAll.Click += new System.EventHandler(this.miSelectAll_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
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
			this.miReplace.Size = new System.Drawing.Size(194, 22);
			this.miReplace.Text = "Nahradiť";
			this.miReplace.Click += new System.EventHandler(this.miReplace_Click);
			// 
			// autokódToolStripMenuItem
			// 
			this.autokódToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAddValue,
            this.miSubstractValue,
            this.toolStripMenuItem6,
            this.miCopyRegister,
            this.miMoveRegister,
            this.miClearRegister});
			this.autokódToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.autokódToolStripMenuItem.MergeIndex = 3;
			this.autokódToolStripMenuItem.Name = "autokódToolStripMenuItem";
			this.autokódToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.autokódToolStripMenuItem.Text = "Autokód";
			// 
			// miAddValue
			// 
			this.miAddValue.Name = "miAddValue";
			this.miAddValue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
			this.miAddValue.Size = new System.Drawing.Size(281, 22);
			this.miAddValue.Text = "Pripočítať hodnotu";
			this.miAddValue.Click += new System.EventHandler(this.miAddValue_Click);
			// 
			// miSubstractValue
			// 
			this.miSubstractValue.Name = "miSubstractValue";
			this.miSubstractValue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
			this.miSubstractValue.Size = new System.Drawing.Size(281, 22);
			this.miSubstractValue.Text = "Odpočítať hodnotu";
			this.miSubstractValue.Click += new System.EventHandler(this.miSubstractValue_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(278, 6);
			// 
			// miCopyRegister
			// 
			this.miCopyRegister.Name = "miCopyRegister";
			this.miCopyRegister.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
			this.miCopyRegister.Size = new System.Drawing.Size(281, 22);
			this.miCopyRegister.Text = "Kopírovať z registra do registra";
			this.miCopyRegister.Click += new System.EventHandler(this.miCopyRegister_Click);
			// 
			// miMoveRegister
			// 
			this.miMoveRegister.Name = "miMoveRegister";
			this.miMoveRegister.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F4)));
			this.miMoveRegister.Size = new System.Drawing.Size(281, 22);
			this.miMoveRegister.Text = "Presunúť z registra do registra";
			this.miMoveRegister.Click += new System.EventHandler(this.miMoveRegister_Click);
			// 
			// miClearRegister
			// 
			this.miClearRegister.Name = "miClearRegister";
			this.miClearRegister.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F5)));
			this.miClearRegister.Size = new System.Drawing.Size(281, 22);
			this.miClearRegister.Text = "Vynulovať register";
			this.miClearRegister.Click += new System.EventHandler(this.miClearRegister_Click);
			// 
			// miSimulation
			// 
			this.miSimulation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRun,
            this.miPause,
            this.miStep,
            this.miStop,
            this.toolStripMenuItem5,
            this.miBreaks,
            this.resetToolStripMenuItem});
			this.miSimulation.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.miSimulation.MergeIndex = 4;
			this.miSimulation.Name = "miSimulation";
			this.miSimulation.Size = new System.Drawing.Size(70, 20);
			this.miSimulation.Text = "Simulácia";
			// 
			// miRun
			// 
			this.miRun.Image = global::DusanRodina.AbacusMachine.Properties.Resources.run;
			this.miRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miRun.Name = "miRun";
			this.miRun.ShortcutKeyDisplayString = "F5";
			this.miRun.Size = new System.Drawing.Size(130, 22);
			this.miRun.Text = "Spustiť";
			this.miRun.Click += new System.EventHandler(this.miRun_Click);
			// 
			// miPause
			// 
			this.miPause.Image = global::DusanRodina.AbacusMachine.Properties.Resources.pause;
			this.miPause.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miPause.Name = "miPause";
			this.miPause.Size = new System.Drawing.Size(130, 22);
			this.miPause.Text = "Pauza";
			this.miPause.Click += new System.EventHandler(this.miPause_Click);
			// 
			// miStep
			// 
			this.miStep.Name = "miStep";
			this.miStep.Size = new System.Drawing.Size(130, 22);
			this.miStep.Text = "Krok";
			this.miStep.Click += new System.EventHandler(this.miStep_Click);
			// 
			// miStop
			// 
			this.miStop.Image = global::DusanRodina.AbacusMachine.Properties.Resources.stop;
			this.miStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.miStop.Name = "miStop";
			this.miStop.Size = new System.Drawing.Size(130, 22);
			this.miStop.Text = "Zastaviť";
			this.miStop.Click += new System.EventHandler(this.miStop_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(127, 6);
			this.toolStripMenuItem5.Visible = false;
			// 
			// miBreaks
			// 
			this.miBreaks.Name = "miBreaks";
			this.miBreaks.Size = new System.Drawing.Size(130, 22);
			this.miBreaks.Text = "Prerušenia";
			this.miBreaks.Visible = false;
			// 
			// resetToolStripMenuItem
			// 
			this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
			this.resetToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.resetToolStripMenuItem.Text = "Reset";
			this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
			// 
			// miTools
			// 
			this.miTools.MergeAction = System.Windows.Forms.MergeAction.Insert;
			this.miTools.MergeIndex = 5;
			this.miTools.Name = "miTools";
			this.miTools.Size = new System.Drawing.Size(63, 20);
			this.miTools.Text = "Nástroje";
			this.miTools.Visible = false;
			// 
			// miHelp
			// 
			this.miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAbout});
			this.miHelp.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.miHelp.MergeIndex = 10;
			this.miHelp.Name = "miHelp";
			this.miHelp.Size = new System.Drawing.Size(73, 20);
			this.miHelp.Text = "Pomocník";
			// 
			// miAbout
			// 
			this.miAbout.MergeAction = System.Windows.Forms.MergeAction.Replace;
			this.miAbout.Name = "miAbout";
			this.miAbout.Size = new System.Drawing.Size(138, 22);
			this.miAbout.Text = "O programe";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabCode);
			this.tabControl1.Controls.Add(this.tabSimulation);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(560, 422);
			this.tabControl1.TabIndex = 12;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabCode
			// 
			this.tabCode.Controls.Add(this.speedPanel);
			this.tabCode.Controls.Add(this.txtCode);
			this.tabCode.Location = new System.Drawing.Point(4, 22);
			this.tabCode.Name = "tabCode";
			this.tabCode.Padding = new System.Windows.Forms.Padding(3);
			this.tabCode.Size = new System.Drawing.Size(552, 396);
			this.tabCode.TabIndex = 0;
			this.tabCode.Text = "Zdrojový kód";
			this.tabCode.UseVisualStyleBackColor = true;
			// 
			// speedPanel
			// 
			this.speedPanel.BackColor = System.Drawing.Color.White;
			this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.speedPanel.Controls.Add(this.tbSpeed);
			this.speedPanel.Controls.Add(this.label3);
			this.speedPanel.Location = new System.Drawing.Point(294, 56);
			this.speedPanel.Name = "speedPanel";
			this.speedPanel.Size = new System.Drawing.Size(200, 37);
			this.speedPanel.TabIndex = 23;
			// 
			// tbSpeed
			// 
			this.tbSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbSpeed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.tbSpeed.Location = new System.Drawing.Point(61, 3);
			this.tbSpeed.Maximum = 20;
			this.tbSpeed.Name = "tbSpeed";
			this.tbSpeed.Size = new System.Drawing.Size(134, 45);
			this.tbSpeed.TabIndex = 16;
			this.tbSpeed.Value = 19;
			this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
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
			// txtCode
			// 
			this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtCode.HideSelection = true;
			this.txtCode.Location = new System.Drawing.Point(6, 6);
			this.txtCode.Name = "txtCode";
			this.txtCode.SelectedText = "";
			this.txtCode.SelectionLength = 0;
			this.txtCode.SelectionStart = 0;
			this.txtCode.Size = new System.Drawing.Size(540, 384);
			this.txtCode.TabIndex = 1;
			this.txtCode.TextChanged += new DusanRodina.SimStudio.Components.SyntaxTextBox.TextChangedEventHandler(this.txtCode_TextChanged);
			// 
			// tabSimulation
			// 
			this.tabSimulation.Controls.Add(this.pSimulation);
			this.tabSimulation.Controls.Add(this.verticalScroll);
			this.tabSimulation.Location = new System.Drawing.Point(4, 22);
			this.tabSimulation.Name = "tabSimulation";
			this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
			this.tabSimulation.Size = new System.Drawing.Size(552, 396);
			this.tabSimulation.TabIndex = 1;
			this.tabSimulation.Text = "Simulácia";
			this.tabSimulation.UseVisualStyleBackColor = true;
			// 
			// pSimulation
			// 
			this.pSimulation.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pSimulation.Location = new System.Drawing.Point(3, 3);
			this.pSimulation.Name = "pSimulation";
			this.pSimulation.Size = new System.Drawing.Size(529, 390);
			this.pSimulation.TabIndex = 0;
			this.pSimulation.TabStop = false;
			this.pSimulation.Paint += new System.Windows.Forms.PaintEventHandler(this.pSimulation_Paint);
			this.pSimulation.Resize += new System.EventHandler(this.pSimulation_Resize);
			// 
			// verticalScroll
			// 
			this.verticalScroll.Dock = System.Windows.Forms.DockStyle.Right;
			this.verticalScroll.Location = new System.Drawing.Point(532, 3);
			this.verticalScroll.Name = "verticalScroll";
			this.verticalScroll.Size = new System.Drawing.Size(17, 390);
			this.verticalScroll.TabIndex = 2;
			this.verticalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.verticalScroll_Scroll);
			this.verticalScroll.ValueChanged += new System.EventHandler(this.verticalScroll_ValueChanged);
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
			this.toolStripPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolStripPanel1.Location = new System.Drawing.Point(0, 0);
			this.toolStripPanel1.Name = "toolStripPanel1";
			this.toolStripPanel1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.toolStripPanel1.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.toolStripPanel1.Size = new System.Drawing.Size(850, 49);
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator3,
            this.runToolStripButton,
            this.breakToolStripButton,
            this.stopToolStripButton,
            this.toolStripSeparator4,
            this.stepToolStripButton});
			this.mainToolStrip.Location = new System.Drawing.Point(3, 24);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(365, 25);
			this.mainToolStrip.TabIndex = 23;
			this.mainToolStrip.Text = "toolStrip1";
			// 
			// newStripButton
			// 
			this.newStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.small_new;
			this.newStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.newStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newStripButton.Name = "newStripButton";
			this.newStripButton.Size = new System.Drawing.Size(23, 22);
			this.newStripButton.Text = "Nový";
			this.newStripButton.Click += new System.EventHandler(this.newStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.open;
			this.openToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "Otvoriť";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.save;
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
			// runToolStripButton
			// 
			this.runToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.run;
			this.runToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.runToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.runToolStripButton.Name = "runToolStripButton";
			this.runToolStripButton.Size = new System.Drawing.Size(58, 22);
			this.runToolStripButton.Text = "Spustiť";
			this.runToolStripButton.Click += new System.EventHandler(this.runToolStripButton_Click);
			// 
			// breakToolStripButton
			// 
			this.breakToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.pause;
			this.breakToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.breakToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.breakToolStripButton.Name = "breakToolStripButton";
			this.breakToolStripButton.Size = new System.Drawing.Size(63, 22);
			this.breakToolStripButton.Text = "Prerušiť";
			this.breakToolStripButton.Visible = false;
			this.breakToolStripButton.Click += new System.EventHandler(this.breakToolStripButton_Click);
			// 
			// stopToolStripButton
			// 
			this.stopToolStripButton.Enabled = false;
			this.stopToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.stop;
			this.stopToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.stopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stopToolStripButton.Name = "stopToolStripButton";
			this.stopToolStripButton.Size = new System.Drawing.Size(69, 22);
			this.stopToolStripButton.Text = "Zastaviť";
			this.stopToolStripButton.Click += new System.EventHandler(this.stopToolStripButton_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// stepToolStripButton
			// 
			this.stepToolStripButton.Image = global::DusanRodina.AbacusMachine.Properties.Resources.run;
			this.stepToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.stepToolStripButton.Name = "stepToolStripButton";
			this.stepToolStripButton.Size = new System.Drawing.Size(51, 22);
			this.stepToolStripButton.Text = "Krok";
			this.stepToolStripButton.Click += new System.EventHandler(this.stepToolStripButton_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 49);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.lstRegisters);
			this.splitContainer1.Size = new System.Drawing.Size(850, 429);
			this.splitContainer1.SplitterDistance = 566;
			this.splitContainer1.TabIndex = 2;
			// 
			// lstRegisters
			// 
			this.lstRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstRegisters.Location = new System.Drawing.Point(3, 3);
			this.lstRegisters.MaximalCount = 10000;
			this.lstRegisters.Name = "lstRegisters";
			this.lstRegisters.Reading = false;
			this.lstRegisters.ReadingPos = 0;
			this.lstRegisters.Regs = infiniteRegisters1;
			this.lstRegisters.ScrollValue = 0;
			this.lstRegisters.Size = new System.Drawing.Size(274, 418);
			this.lstRegisters.TabIndex = 2;
			this.lstRegisters.Writing = false;
			this.lstRegisters.WritingPos = 0;
			this.lstRegisters.RegisterChanged += new DusanRodina.SimStudio.Components.RegisterList.RegisterChangedEventHandler(this.lstRegisters_RegisterChanged);
			// 
			// AbacusMachineForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(850, 478);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStripPanel1);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "AbacusMachineForm";
			this.Text = "Počítadlový stroj";
			this.Load += new System.EventHandler(this.AbacusMachineForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabCode.ResumeLayout(false);
			this.speedPanel.ResumeLayout(false);
			this.speedPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
			this.tabSimulation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pSimulation)).EndInit();
			this.toolStripPanel1.ResumeLayout(false);
			this.toolStripPanel1.PerformLayout();
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }        
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
        private DusanRodina.SimStudio.Components.SyntaxTextBox txtCode;
        private DusanRodina.SimStudio.Components.RegisterList lstRegisters;
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
        private ToolStripMenuItem resetToolStripMenuItem;
        private VScrollBar verticalScroll;
        private ToolStripPanel toolStripPanel1;
        private ToolStrip mainToolStrip;
        private ToolStripButton newStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton runToolStripButton;
        private ToolStripButton breakToolStripButton;
        private ToolStripButton stopToolStripButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton stepToolStripButton;
        private SplitContainer splitContainer1;
        private Panel speedPanel;
        private TrackBar tbSpeed;
        private Label label3;
    }
}

