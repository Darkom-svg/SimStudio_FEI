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
        private List<TaskDef> _allTasks = new List<TaskDef>();
        private string AppTitle;

        public MainTrainingForm()
        {
            InitializeComponent();
            AppTitle = this.Text;
            if (flowLayoutPanel2 != null)
            {
                flowLayoutPanel2.AutoScroll = true;
                flowLayoutPanel2.WrapContents = false;
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            }

            try
            {
                _allTasks = TaskStore.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nepodarilo sa načítať tasks.json.\n\n" + ex.Message,
                    AppTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                _allTasks = new List<TaskDef>();
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
            var randTask = new TaskDef();
            randTask.Id = category + "_Random";
            randTask.Category = category;
            randTask.Title = "Nahodná konfigurácia";
            randTask.Difficulty = "stredná";
            String randSpecification = "";
                
            if (category.Equals("FA"))
            {
                Random rnd = new Random();
                int i = rnd.Next(1, 6);
                int j = rnd.Next(1, 6);
                int k = rnd.Next(1, 6);
                int x = rnd.Next(1, 6);
                int y = rnd.Next(1, 6);
                randSpecification =
                    "Navrhnite konečný automat nad abecedou $\\Sigma = \\{a,b,c\\}$, ktorý prijíma práve tie slová $w$, pre ktoré platí:\n$$\n" +
                    i + "\\#_aw + " + j + "\\#_bw + " + k + "\\#_cw = " + x + "n + " + y +", \\quad n \\geq 0$$";
            }

            randTask.Specification = randSpecification;
            return randTask;
        }

        private void ShowCategory(string category)
        {
            if (flowLayoutPanel2 == null) return;

            flowLayoutPanel2.SuspendLayout();
            try {
                flowLayoutPanel2.Controls.Clear();

                var tasks = _allTasks
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
            int cardWidth = Math.Max(260, flowLayoutPanel2.ClientSize.Width - 25);

            var card = new RoundedPanel()
            {
                Padding = new System.Windows.Forms.Padding(3, 3, 3, 3),
                Margin = new System.Windows.Forms.Padding(0, 0, 0, 12),
                CornerRadius = 6,
                BackColor = System.Drawing.Color.Gainsboro,
                AutoSize = true,
                MinimumSize = new System.Drawing.Size(400, 60),
                MaximumSize = new System.Drawing.Size(800, 120)
            };

            var lblTitle = new Label
            {
                Text = task.Title,
                Location = new System.Drawing.Point(15, 10),
                Size = new System.Drawing.Size(200, 22),
                Font = new Font("Calibri", 14F, FontStyle.Bold),
                AutoEllipsis = true
            };

            var lblMeta = new Label
            {
                Text = $"Obtiažnosť: {task.Difficulty}",
                Location = new System.Drawing.Point(15, 40),
                Size = new System.Drawing.Size(200, 22),
                AutoEllipsis = true
            };

            var btnOpen = new Button
            {
                Anchor = System.Windows.Forms.AnchorStyles.Left,
                Location = new System.Drawing.Point(260, 40),
                Size = new System.Drawing.Size(110, 22),
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
            var ico = new ComponentResourceManager(this.GetType()).GetObject("$this.Icon") as Icon;
            if (ico != null) this.Icon = ico;
        }
        
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new DusanRodina.TrainingSimulator.Dialogs.AboutForm();
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