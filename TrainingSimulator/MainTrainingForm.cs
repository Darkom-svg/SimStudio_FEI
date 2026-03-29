using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using DusanRodina.SimStudio.Components;
using DusanRodina.TrainingSimulator.Dialogs;

namespace TrainingSimulator {
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
            public List<string> Formula { get; set; } = new List<string>();

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
                Category = category,
                Title = "Nahodná konfigurácia",
                Difficulty = "stredná"
            };

            if (category.Equals("FA"))
            {
                Random rnd = new Random();
                int i = new List<int> {1,-1}[rnd.Next(0, 2)] * rnd.Next(1, 6);
                String j = new List<String> {"+","-"}[rnd.Next(0, 2)] + rnd.Next(1, 6);
                String k = new List<String> {"+","-"}[rnd.Next(0, 2)] + rnd.Next(1, 6);
                String x = rnd.Next(1, 6).ToString();
                String y = rnd.Next(1, 6).ToString();

                randTask.Specification =
                    "Navrhnite konečný automat nad abecedou $\\Sigma = \\{a,b,c\\}$, ktorý prijíma práve tie slová $w$, pre ktoré platí:\n$$\n" +
                    $"{i}\\#_aw {j}\\#_bw {k}\\#_cw = {x}n + {y}, \\quad n \\geq 0$$";
                
                randTask.Formula = new List<string>
                {
                    $"{i}a",
                    $"{j}b",
                    $"{k}c",
                    "=",
                    x,
                    y
                };
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
            TrainingForm frm = new TrainingForm(task);
            frm.ShowDialog(this);
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