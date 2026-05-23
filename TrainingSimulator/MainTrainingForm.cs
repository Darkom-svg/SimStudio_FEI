using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Windows.Forms;
using FEI.SimStudio.Components;
using FEI.TrainingSimulator.Dialogs;

namespace FEI.TrainingSimulator {
    public partial class MainTrainingForm : Form
    {
        private List<TaskDef> allTasks;
        private string currentTaskSetFile = "Tasks/tasks.xml";

        public MainTrainingForm()
        {
            InitializeComponent();
            var appTitle = Text;
            if (flowLayoutPanel2 != null)
            {
                flowLayoutPanel2.AutoScroll = true;
                flowLayoutPanel2.WrapContents = false;
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            }

            try
            {
                allTasks = TaskStore.Load(currentTaskSetFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nepodarilo sa načítať tasks.xml.\n\n" + ex.Message,
                    appTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                allTasks = new List<TaskDef>();
            }
            flowLayoutPanel1.Resize += flowLayoutPanel1_Resize;
            flowLayoutPanel2.Resize += flowLayoutPanel2_Resize;
            ShowCategory("FA");
        }

        public sealed class TaskDef
        {
            public string Id { get; set; } = "";
            public string Title { get; set; } = "";
            public string Category { get; set; } = "";
            public string Mode { get; set; } = "";
            public string Difficulty { get; set; } = "";
            public string Specification { get; set; } = "";
            public string Verification { get; set; } = "";

        }

        public static class TaskStore
        {
            public static List<TaskDef> Load(string fileName)
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(baseDir, fileName);

                if (!File.Exists(path))
                    throw new FileNotFoundException("Nenašiel som " + fileName + " v " + baseDir);

                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                var result = new List<TaskDef>();

                XmlNodeList taskNodes = doc.SelectNodes("//task");

                foreach (XmlNode taskNode in taskNodes)
                {
                    result.Add(new TaskDef
                    {
                        Id = ReadNode(taskNode, "id"),
                        Title = ReadNode(taskNode, "title"),
                        Category = ReadNode(taskNode, "category"),
                        Mode = ReadNode(taskNode, "mode"),
                        Difficulty = ReadNode(taskNode, "difficulty"),
                        Specification = ReadNode(taskNode, "specification"),
                        Verification = ReadNode(taskNode, "verification")
                    });
                }
                return result;
            }

            private static string ReadNode(XmlNode parent, string name)
            {
                XmlNode node = parent.SelectSingleNode(name);

                if (node == null)
                    return "";

                return node.InnerText.Trim();
            }
        }

        private TaskDef RandomTask(string category)
        {
            var randTask = new TaskDef
            {
                Id = category + "_Random",
                Mode = "Formula",
                Category = category,
                Title = "Nahodný príklad",
                Difficulty = "stredná"
            };

            if (category.Equals("FA"))
            {
                Random rnd = new Random();
                int modulo = rnd.Next(2, 6);
                int i = new List<int> {1,-1}[rnd.Next(0, 2)] * rnd.Next(1, modulo);
                String j = new List<String> {"+","-"}[rnd.Next(0, 2)] + rnd.Next(1, modulo);
                String k = new List<String> {"+","-"}[rnd.Next(0, 2)] + rnd.Next(1, modulo);
                String y = rnd.Next(1, modulo).ToString();

                randTask.Specification = $@"
                Navrhnite deterministický konečný automat, príp. jeho stavový diagram, ktorý rozpoznáva jazyk $L_A$

                $$L_A = \{{ w \in \{{a,b,c\}}^* \mid {i}\#_a w {j}\#_b w {k}\#_c w = {modulo}n + {y},\; n \in \mathbb{{Z}} \}}$$
                ";
                
                randTask.Verification = $"{i}#a{j}#b{k}#c={modulo}n+{y}";
            }
            
            return randTask;
        }

        private void ShowCategory(string category)
        {
            if (flowLayoutPanel2 == null) return;

            flowLayoutPanel2.SuspendLayout();
            try {
                flowLayoutPanel2.Controls.Clear();

                var tasks = allTasks
                    .Where(t => string.Equals(t.Category, category, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(t => t.Id)
                    .ThenBy(t => t.Title);

                foreach (var task in tasks)
                    flowLayoutPanel2.Controls.Add(CreateTaskCard(task));
                if (category.Equals("FA"))
                {
                    flowLayoutPanel2.Controls.Add(CreateTaskCard(RandomTask(category)));
                }
            }
            finally {
                flowLayoutPanel2.ResumeLayout(true);
            }
            ResizeCardsInFlowPanel(flowLayoutPanel2);
        }

        private Control CreateTaskCard(TaskDef task)
        {
            var card = new RoundedPanel
            {
                Padding = new Padding(3, 3, 3, 3),
                Margin = new Padding(0, 0, 0, 12),
                CornerRadius = 6,
                BackColor = Color.Gainsboro,
                AutoSize = false,
                MinimumSize = new Size(400, 67),
                MaximumSize = new Size(1200, 70)
            };

            var lblTitle = new Label
            {
                Text = task.Title,
                Location = new Point(15, 10),
                Size = new Size(200, 22),
                Font = new Font("Calibri", 14F, FontStyle.Bold),
                AutoEllipsis = true
            };

            var lblMeta = new Label
            {
                Text = $"Obtiažnosť: {task.Difficulty}",
                Location = new Point(15, 40),
                Size = new Size(200, 22),
                AutoEllipsis = true
            };

            var btnOpen = new Button
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(260, 40),
                Size = new Size(110, 22),
                Text = "Začať",
                UseVisualStyleBackColor = true,
            };
            btnOpen.Click += (_, __) => OpenTask(task);

            card.Controls.Add(btnOpen);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblTitle);

            return card;
        }
        
        private void OpenTask(TaskDef task)
        {
            switch (task.Category)
            {
                case "FA":
                {
                    FaTrainingForm frm = new FaTrainingForm(task);
                    frm.ShowDialog(this);
                    break;
                }
                case "PDA":
                {
                    PdaTrainingForm frm = new PdaTrainingForm(task);
                    frm.ShowDialog(this);
                    break;
                }
                case "TM":
                {
                    TmTrainingForm frm = new TmTrainingForm(task);
                    frm.ShowDialog(this);
                    break;
                }
                default:
                    throw new System.NotImplementedException();
            }
        }

        
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (MdiParent != null) menuStrip1.Visible = false;
            var ico = new ComponentResourceManager(GetType()).GetObject("$this.Icon") as Icon;
            if (ico != null) Icon = ico;
        }
        
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog(this);
        }


        private void TuringTrain_Click(object sender, EventArgs e)
        {
            ShowCategory("TM");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowCategory("PDA");            
        }

        private void FaTrain_Click(object sender, EventArgs e)
        {
            ShowCategory("FA"); 
            
        }
        
        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            ResizeCardsInFlowPanel(flowLayoutPanel1);
        }
        
        private void flowLayoutPanel2_Resize(object sender, EventArgs e)
        {
            ResizeCardsInFlowPanel(flowLayoutPanel2);
        }
        
        private void ResizeCardsInFlowPanel(FlowLayoutPanel flowPanel)
        {
            if (flowPanel == null)
                return;

            int width = flowPanel.ClientSize.Width
                        - flowPanel.Padding.Left
                        - flowPanel.Padding.Right
                        - 25;

            foreach (Control control in flowPanel.Controls)
            {
                if (control is RoundedPanel panel)
                {
                    panel.AutoSize = false;
                    panel.Width = Math.Max(250, width);
                    panel.Invalidate();
                }
            }
        }

        private void sadyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tasksDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Tasks");
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = tasksDir;

            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;
            
            string selectedFile = dialog.FileName;
            string selectedDir = Path.GetDirectoryName(selectedFile);
            string targetFile = selectedFile;
            
            if (selectedDir != null && !selectedDir.Equals(tasksDir, StringComparison.OrdinalIgnoreCase))
            {
                DialogResult result = MessageBox.Show(
                    "Vybraný súbor sa nenachádza v priečinku príkladov.\n\n" +
                    "Chcete ho skopírovať do priečinka príkladov a používať odtiaľ?",
                    "Sada príkladov",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    targetFile = Path.Combine(tasksDir, Path.GetFileName(selectedFile));
                    File.Copy(selectedFile, targetFile, true);
                }
            }

            try
            {
                currentTaskSetFile = targetFile;
                allTasks = TaskStore.Load(currentTaskSetFile);
                ShowCategory("FA");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nepodarilo sa načítať vybranú sadu príkladov.\n\n" + ex.Message,
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new AddTaskForm(currentTaskSetFile);
            frm.ShowDialog(this);
        }
    }
}