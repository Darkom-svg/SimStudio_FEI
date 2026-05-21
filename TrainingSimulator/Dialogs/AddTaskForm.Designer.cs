namespace FEI.TrainingSimulator.Dialogs {
	partial class AddTaskForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTaskForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaskSetPath = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbModel = new System.Windows.Forms.ComboBox();
            this.referencePathButton = new System.Windows.Forms.Button();
            this.txtSpecification = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.formulaPanel = new System.Windows.Forms.Panel();
            this.toolTipLabel1 = new System.Windows.Forms.Label();
            this.txtFormula = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.regexPanel = new System.Windows.Forms.Panel();
            this.toolTipLabel2 = new System.Windows.Forms.Label();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.referenceModelPanel = new System.Windows.Forms.Panel();
            this.toolTipLabel3 = new System.Windows.Forms.Label();
            this.txtReferencePath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.taskSetPathButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipLabel4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.formulaPanel.SuspendLayout();
            this.regexPanel.SuspendLayout();
            this.referenceModelPanel.SuspendLayout();
            this.SuspendLayout();
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.txtTitle.Name = "txtTitle";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAdd
            // 
            resources.ApplyResources(this.bAdd, "bAdd");
            this.bAdd.Name = "bAdd";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtTaskSetPath
            // 
            resources.ApplyResources(this.txtTaskSetPath, "txtTaskSetPath");
            this.txtTaskSetPath.Name = "txtTaskSetPath";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtId
            // 
            resources.ApplyResources(this.txtId, "txtId");
            this.txtId.Name = "txtId";
            // 
            // cmbModel
            // 
            resources.ApplyResources(this.cmbModel, "cmbModel");
            this.cmbModel.FormattingEnabled = true;
            this.cmbModel.Items.AddRange(new object[] { resources.GetString("cmbModel.Items"), resources.GetString("cmbModel.Items1"), resources.GetString("cmbModel.Items2") });
            this.cmbModel.Name = "cmbModel";
            this.cmbModel.SelectedIndexChanged += new System.EventHandler(this.cmbModel_SelectedIndexChanged);
            // 
            // referencePathButton
            // 
            resources.ApplyResources(this.referencePathButton, "referencePathButton");
            this.referencePathButton.Name = "referencePathButton";
            this.referencePathButton.UseVisualStyleBackColor = true;
            this.referencePathButton.Click += new System.EventHandler(this.referencePathButton_Click);
            // 
            // txtSpecification
            // 
            resources.ApplyResources(this.txtSpecification, "txtSpecification");
            this.txtSpecification.Name = "txtSpecification";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cmbMode
            // 
            resources.ApplyResources(this.cmbMode, "cmbMode");
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] { resources.GetString("cmbMode.Items"), resources.GetString("cmbMode.Items1"), resources.GetString("cmbMode.Items2") });
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.SelectedIndexChanged += new System.EventHandler(this.cmbMode_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.formulaPanel);
            this.flowLayoutPanel1.Controls.Add(this.regexPanel);
            this.flowLayoutPanel1.Controls.Add(this.referenceModelPanel);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // formulaPanel
            // 
            this.formulaPanel.Controls.Add(this.toolTipLabel1);
            this.formulaPanel.Controls.Add(this.txtFormula);
            this.formulaPanel.Controls.Add(this.label6);
            resources.ApplyResources(this.formulaPanel, "formulaPanel");
            this.formulaPanel.Name = "formulaPanel";
            // 
            // toolTipLabel1
            // 
            resources.ApplyResources(this.toolTipLabel1, "toolTipLabel1");
            this.toolTipLabel1.Name = "toolTipLabel1";
            this.toolTipLabel1.MouseHover += new System.EventHandler(this.toolTipLabel1_MouseHover);
            // 
            // txtFormula
            // 
            resources.ApplyResources(this.txtFormula, "txtFormula");
            this.txtFormula.Name = "txtFormula";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // regexPanel
            // 
            this.regexPanel.Controls.Add(this.toolTipLabel2);
            this.regexPanel.Controls.Add(this.txtRegex);
            this.regexPanel.Controls.Add(this.label8);
            resources.ApplyResources(this.regexPanel, "regexPanel");
            this.regexPanel.Name = "regexPanel";
            // 
            // toolTipLabel2
            // 
            resources.ApplyResources(this.toolTipLabel2, "toolTipLabel2");
            this.toolTipLabel2.Name = "toolTipLabel2";
            this.toolTipLabel2.MouseHover += new System.EventHandler(this.toolTipLabel2_MouseHover);
            // 
            // txtRegex
            // 
            resources.ApplyResources(this.txtRegex, "txtRegex");
            this.txtRegex.Name = "txtRegex";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // referenceModelPanel
            // 
            this.referenceModelPanel.Controls.Add(this.toolTipLabel3);
            this.referenceModelPanel.Controls.Add(this.txtReferencePath);
            this.referenceModelPanel.Controls.Add(this.label10);
            this.referenceModelPanel.Controls.Add(this.referencePathButton);
            resources.ApplyResources(this.referenceModelPanel, "referenceModelPanel");
            this.referenceModelPanel.Name = "referenceModelPanel";
            // 
            // toolTipLabel3
            // 
            resources.ApplyResources(this.toolTipLabel3, "toolTipLabel3");
            this.toolTipLabel3.Name = "toolTipLabel3";
            this.toolTipLabel3.MouseHover += new System.EventHandler(this.toolTipLabel3_MouseHover);
            // 
            // txtReferencePath
            // 
            resources.ApplyResources(this.txtReferencePath, "txtReferencePath");
            this.txtReferencePath.Name = "txtReferencePath";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // taskSetPathButton
            // 
            resources.ApplyResources(this.taskSetPathButton, "taskSetPathButton");
            this.taskSetPathButton.Name = "taskSetPathButton";
            this.taskSetPathButton.UseVisualStyleBackColor = true;
            this.taskSetPathButton.Click += new System.EventHandler(this.taskSetPathButton_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { resources.GetString("comboBox1.Items"), resources.GetString("comboBox1.Items1"), resources.GetString("comboBox1.Items2") });
            this.comboBox1.Name = "comboBox1";
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.SystemColors.HighlightText;
            // 
            // toolTipLabel4
            // 
            resources.ApplyResources(this.toolTipLabel4, "toolTipLabel4");
            this.toolTipLabel4.Name = "toolTipLabel4";
            this.toolTipLabel4.MouseHover += new System.EventHandler(this.toolTipLabel4_MouseHover);
            // 
            // AddTaskForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.toolTipLabel4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.taskSetPathButton);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSpecification);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtTaskSetPath);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbModel);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTaskForm";
            this.ShowInTaskbar = false;
            this.flowLayoutPanel1.ResumeLayout(false);
            this.formulaPanel.ResumeLayout(false);
            this.formulaPanel.PerformLayout();
            this.regexPanel.ResumeLayout(false);
            this.regexPanel.PerformLayout();
            this.referenceModelPanel.ResumeLayout(false);
            this.referenceModelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label toolTipLabel4;

        private System.Windows.Forms.Label toolTipLabel1;
        private System.Windows.Forms.Label toolTipLabel2;
        private System.Windows.Forms.Label toolTipLabel3;
        private System.Windows.Forms.ToolTip toolTip1;

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.Button taskSetPathButton;

        private System.Windows.Forms.Panel formulaPanel;
        private System.Windows.Forms.TextBox txtFormula;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegex;
        private System.Windows.Forms.Panel regexPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReferencePath;
        private System.Windows.Forms.Label label10;

        private System.Windows.Forms.Panel referenceModelPanel;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

        private System.Windows.Forms.ComboBox cmbMode;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button referencePathButton;

        private System.Windows.Forms.TextBox txtSpecification;

        private System.Windows.Forms.ComboBox cmbModel;

        private System.Windows.Forms.TextBox txtId;

        private System.Windows.Forms.TextBox txtTaskSetPath;
        private System.Windows.Forms.Label label9;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
    }
}