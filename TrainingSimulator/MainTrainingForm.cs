using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using FEI.SimStudio.Components;
using FEI.TrainingSimulator.Dialogs;

namespace FEI.TrainingSimulator {
    public partial class MainTrainingForm : Form
    {
        private List<TaskDef> allTasks;

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
                allTasks = TaskStore.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nepodarilo sa načítať tasks.json.\n\n" + ex.Message,
                    appTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                allTasks = new List<TaskDef>();
            }

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
            public string Formula { get; set; } = "";

        }

        public static class TaskStore
        {
            public static List<TaskDef> Load(string fileName = "tasks.json")
            {
                var baseDir = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(baseDir, fileName);
                var json = File.ReadAllText(path);

                var opts = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                return JsonSerializer.Deserialize<List<TaskDef>>(json, opts) ?? new List<TaskDef>();
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
                
                randTask.Formula = $"{i}#a{j}#b{k}#c={modulo}n+{y}";
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
                // Todo: Aj pre ostatné automaty
                if (category.Equals("FA"))
                {
                    flowLayoutPanel2.Controls.Add(CreateTaskCard(RandomTask(category)));
                }
            }
            finally {
                flowLayoutPanel2.ResumeLayout(true);
            }
        }

        private Control CreateTaskCard(TaskDef task)
        {
            var card = new RoundedPanel
            {
                Padding = new Padding(3, 3, 3, 3),
                Margin = new Padding(0, 0, 0, 12),
                CornerRadius = 6,
                BackColor = Color.Gainsboro,
                AutoSize = true,
                MinimumSize = new Size(400, 60),
                MaximumSize = new Size(800, 120)
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
                Anchor = AnchorStyles.Left,
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
            if (task.Category.Equals("FA"))
            {
                FaTrainingForm frm = new FaTrainingForm(task);
                frm.ShowDialog(this);
            }
            else if (task.Category.Equals("PDA"))
            {
                PdaTrainingForm frm = new PdaTrainingForm(task);
                frm.ShowDialog(this);
            }
            else
            {
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
        
    }


}