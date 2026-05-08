using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace FEI.SimStudio {
    public partial class ExamplesForm : Form
    {
        private List<ExampleFile> allExamples = new List<ExampleFile>();
        public static string AppTitle;
        public ExamplesForm()
        {
            InitializeComponent();
             AppTitle = Text;
            if (flowLayoutPanel2 != null)
            {
                flowLayoutPanel2.AutoScroll = true;
                flowLayoutPanel2.WrapContents = false;
                flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            }

            try
            {
                allExamples = LoadExampleFiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Nepodarilo sa načítať vzorové riešenia.\n\n" + ex.Message,
                    AppTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                allExamples = new List<ExampleFile>();
            }

            ShowCategory("FA");
        }

        private sealed class ExampleFile
        {
            public string Title { get; set; } = "";
            public string Category { get; set; } = "";
            public string FullPath { get; set; } = "";
            public string Description { get; set; } = "";
        }

        private List<ExampleFile> LoadExampleFiles()
        {
            var result = new List<ExampleFile>();

            string baseDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Examples");

            if (!Directory.Exists(baseDir))
                return result;

            LoadCategoryFiles(result, baseDir, "FA", "*.fa");
            LoadCategoryFiles(result, baseDir, "PDA", "*.pa");
            LoadCategoryFiles(result, baseDir, "TM", "*.tm");

            return result;
        }

        private void LoadCategoryFiles(
            List<ExampleFile> result,
            string baseDir,
            string category,
            string pattern)
        {
            string categoryDir = Path.Combine(baseDir, category);

            if (!Directory.Exists(categoryDir))
                return;

            foreach (string file in Directory.GetFiles(categoryDir, pattern))
            {
                string title;
                string description;

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    XmlNode titleNode = doc.SelectSingleNode("//title");

                    if (titleNode != null &&
                        !string.IsNullOrWhiteSpace(titleNode.InnerText))
                    {
                        title = titleNode.InnerText.Trim();
                    }
                    else
                    {
                        title = Path.GetFileNameWithoutExtension(file);
                    }
                }
                catch
                {
                    title = Path.GetFileNameWithoutExtension(file);
                }
                
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    XmlNode titleNode = doc.SelectSingleNode("//description");

                    if (titleNode != null &&
                        !string.IsNullOrWhiteSpace(titleNode.InnerText))
                    {
                        description = titleNode.InnerText.Trim();
                    }
                    else
                    {
                        description = "";
                    }
                }
                catch
                {
                    description = "";
                }

                result.Add(new ExampleFile
                {
                    Category = category,
                    FullPath = file,
                    Description = description,
                    Title = title
                });
            }
        }

        private void ShowCategory(string category)
        {
            flowLayoutPanel2.SuspendLayout();

            try
            {
                flowLayoutPanel2.Controls.Clear();

                var examples = allExamples
                    .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                    .OrderBy(e => e.Title);

                foreach (var example in examples)
                    flowLayoutPanel2.Controls.Add(CreateExampleCard(example));
            }
            finally
            {
                flowLayoutPanel2.ResumeLayout(true);
            }
        }

        private Control CreateExampleCard(ExampleFile example)
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
                Text = example.Title,
                Location = new Point(15, 10),
                Size = new Size(230, 22),
                Font = new Font("Calibri", 14F, FontStyle.Bold),
                AutoEllipsis = true,
                AutoSize = false
            };

            var lblMeta = new Label
            {
                Text = example.Description,
                Location = new Point(15, 40),
                Size = new Size(230, 45),
                AutoEllipsis = false,
                AutoSize = false
            };

            var btnOpen = new Button
            {
                Anchor = AnchorStyles.Left,
                Location = new Point(260, 40),
                Size = new Size(110, 22),
                Text = "Otvoriť",
                UseVisualStyleBackColor = true,
            };
            btnOpen.Click += (_, __) => OpenExample(example);

            card.Controls.Add(btnOpen);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblTitle);

            return card;
        }

        
        private void OpenExample(ExampleFile example)
        {
            if (!File.Exists(example.FullPath))
            {
                MessageBox.Show(
                    "Súbor sa nenašiel:\n" + example.FullPath,
                    AppTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (example.Category.Equals("FA", StringComparison.OrdinalIgnoreCase))
            {
                var frm = new FiniteAutomaton.FiniteAutomatonForm();
                frm.OpenFile(example.FullPath);
                frm.ShowDialog(this);
            }
            else if (example.Category.Equals("PDA", StringComparison.OrdinalIgnoreCase))
            {
                var frm = new PushdownAutomaton.PushdownAutomatonForm();
                frm.OpenFile(example.FullPath);
                frm.ShowDialog(this);
            }
            else if (example.Category.Equals("TM", StringComparison.OrdinalIgnoreCase))
            {
                var frm = new TuringMachineSimulator.TuringMachineForm();
                frm.OpenFile(example.FullPath);
                frm.ShowDialog(this);
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
            TrainingSimulator.Dialogs.AboutForm dlg = new TrainingSimulator.Dialogs.AboutForm();
            dlg.ShowDialog(this);
        }


        private void FaTrain_Click(object sender, EventArgs e)
        {
            ShowCategory("FA");
        }

        private void PdaTrain_Click(object sender, EventArgs e)
        {
            ShowCategory("PDA");
        }

        private void TuringTrain_Click(object sender, EventArgs e)
        {
            ShowCategory("TM");
        }
        
    }


}