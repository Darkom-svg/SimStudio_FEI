using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using FEI.TrainingSimulator.Properties;

namespace FEI.TrainingSimulator.Dialogs
{
    public partial class AddTaskForm : Form
    {
        private Dictionary<string,bool> testCases = new Dictionary<string, bool>();
        private List<string> testWords = new List<string>();

        public AddTaskForm(string currentTaskSetFile)
        {
            InitializeComponent();
            txtTaskSetPathtxtTaskSetPath.Text = currentTaskSetFile;
            cmbModel.SelectedIndex = 0;
            cmbMode.SelectedIndex = 0;
            cmbDifficulty.SelectedIndex = 0;
            checkBoxAccept.Checked = true;
            cmbDifficulty.SelectedIndex = 0;
            cmbTestWords.SelectedIndex = 0;
            UpdateVerificationPanels();
        }
        
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMode.Items.Clear();

            if (cmbModel.SelectedIndex == 0)
            {
                cmbMode.Items.Add("Formula");
                cmbMode.Items.Add("Regex");
                cmbMode.Items.Add(Resources.ReferenceAutomaton);
                cmbMode.Items.Add(Resources.TestCases);
            }
            else
            {
                cmbMode.Items.Add(Resources.ReferenceAutomaton);
                cmbMode.Items.Add(Resources.TestCases);
            }

            cmbMode.SelectedIndex = 0;
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVerificationPanels();
        }
        
        private void cmbTestWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTestWords.SelectedIndex == 0)
            {
                txtRecursionDepth.Visible = true;
                txtRecursionDepth.Text = 10.ToString();
                labelRecursionDepth.Visible = true;
            }
            else
            {
                txtRecursionDepth.Visible = false;
                labelRecursionDepth.Visible = false;
                txtRecursionDepth.Text = "";
            }
            UpdateVerificationPanels();
        }

        private void UpdateVerificationPanels()
        {
            string mode = GetSelectedMode();

            formulaPanel.Visible = mode == "Formula";
            regexPanel.Visible = mode == "Regex";
            referenceModelPanel.Visible = mode == "Reference_model";
            testSetPanel.Visible = mode == "Test_cases";
            testWordsPanel.Visible = cmbTestWords.SelectedIndex == 1;
            cmbTestWords.Enabled = true;
            
            if (mode == "Test_cases")
            {
                Height = 695;
                flowLayoutPanel1.Height = testSetPanel.Height + 10;
                cmbTestWords.SelectedIndex = 1;
                cmbTestWords.Enabled = false;
            }
            else if (mode != "Test_cases" && cmbTestWords.SelectedIndex == 1)
            {
                Height = 735;
                flowLayoutPanel1.Height = testSetPanel.Height + 60;
            }
            else
            {
                flowLayoutPanel1.Height = 60;
                Height = 550;
            }
        }

        private void taskSetPathButton_Click(object sender, EventArgs e)
        {
            string tasksDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Tasks");

            Directory.CreateDirectory(tasksDir);
            
            saveFileDialog1.InitialDirectory = tasksDir;

            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtTaskSetPathtxtTaskSetPath.Text = saveFileDialog1.FileName;
            }
        }

        private void referencePathButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                txtReferencePath.Text = openFileDialog1.FileName;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                string mode = GetSelectedMode();
                string verification = "";

                if (mode == "Formula")
                    verification = txtFormula.Text.Trim().Replace(" ","");
                else if (mode == "Regex")
                    verification = txtRegex.Text.Trim();
                else if (mode == "Reference_model")
                    verification = File.ReadAllText(txtReferencePath.Text.Trim(), Encoding.UTF8);
                else if (mode == "Test_cases")
                    verification = CreateTestCasesXml();
                
                string category = "";
                switch (cmbModel.SelectedIndex)
                {
                    case 0:
                        category = "FA";
                        break;
                    case 1:
                        category = "PDA";
                        break;
                    case 2:
                        category = "TM";
                        break;
                }

                if (String.IsNullOrEmpty(txtId.Text))
                {
                    txtId.Text = category + " [" + DateTime.Now.ToString(CultureInfo.InvariantCulture)+ "]";
                }

                string tests = "";
                if (cmbTestWords.SelectedIndex == 0)
                    tests = txtRecursionDepth.Text;
                

                AddTaskToXml(
                    txtTaskSetPathtxtTaskSetPath.Text.Trim(),
                    txtId.Text.Trim(),
                    txtTitle.Text.Trim(),
                    category,
                    mode,
                    cmbDifficulty.Text.Trim(),
                    txtSpecification.Text,
                    verification,
                    tests);

                MessageBox.Show(
                    Resources.AddTaskTitle,
                    Resources.TaskAddedMessage,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Resources.AddTaskError,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private string CreateTestCasesXml()
        {
            XmlDocument doc = new XmlDocument();

            XmlElement testsNode = doc.CreateElement("tests");
            doc.AppendChild(testsNode);

            foreach (var testCase in testCases)
            {
                XmlElement testNode = doc.CreateElement("test");

                string word = testCase.Key;

                if (word == "ε")
                    word = "";

                testNode.SetAttribute("word", word);
                testNode.SetAttribute("expected", testCase.Value ? "accept" : "reject");

                testsNode.AppendChild(testNode);
            }

            return doc.OuterXml;
        }

        private void ValidateForm()
        {
            string category = "";
            switch (cmbModel.SelectedIndex)
            {
                case 0:
                    category = "FA";
                    break;
                case 1:
                    category = "PA";
                    break;
                case 2:
                    category = "TM";
                    break;
            }
            
            string mode = GetSelectedMode();

            if (string.IsNullOrWhiteSpace(txtTaskSetPathtxtTaskSetPath.Text))
                throw new Exception(Resources.ValidationErrorTaskSetPath);

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
                throw new Exception(Resources.ValidationErrorTaskName);

            if (string.IsNullOrWhiteSpace(category))
                throw new Exception(Resources.ValidationErrorModelType);

            if (string.IsNullOrWhiteSpace(mode))
                throw new Exception(Resources.ValidationErrorTaskValidationMethod);

            if (string.IsNullOrWhiteSpace(cmbDifficulty.Text))
                throw new Exception(Resources.ValidationErrorTaskDifficulty);

            if (string.IsNullOrWhiteSpace(txtSpecification.Text))
                throw new Exception(Resources.ValidationErrorTaskSpecification);

            switch (mode)
            {
                case "Formula":
                    if (string.IsNullOrWhiteSpace(txtFormula.Text))
                        throw new Exception(Resources.ValidationErrorVerfication);
                    break;

                case "Regex":
                    if (string.IsNullOrWhiteSpace(txtRegex.Text))
                        throw new Exception(Resources.ValidationErrorVerfication);
                    break;

                case "Reference_model":
                    string path = txtReferencePath.Text.Trim();

                    if (string.IsNullOrWhiteSpace(path))
                        throw new Exception(Resources.ValidationErrorVerfication);

                    if (!File.Exists(path))
                        throw new Exception(Resources.ValidationErrorVerfication);

                    if (!string.Equals(
                            Path.GetExtension(path),
                            "." + category,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        throw new Exception(Resources.ValidationErrorTaskModelMismatchWithReference);
                    }
                    break;

                case "Test_cases":
                    if (testCases.Count == 0)
                        throw new Exception(Resources.ValidationErrorZeroTaskTest);
                    break;

                default:
                    throw new Exception(string.Format(Resources.UnknownModeError, mode));
            }

            int maxLength = 0;
            if (cmbTestWords.SelectedIndex == 0 && !int.TryParse(txtRecursionDepth.Text.Trim(), out maxLength) || maxLength < 0)
                throw new Exception(Resources.ValidationErrorRecursionDepth);
            else if (cmbTestWords.SelectedIndex == 1 && testWords.Count == 0 && mode != "Test_cases")
                throw new Exception(Resources.ValidationErrorZeroTaskTest);
        }

        private void AddTaskToXml(
            string fileName,
            string id,
            string title,
            string category,
            string mode,
            string difficulty,
            string specification,
            string verification,
            string tests)
        {
            XmlDocument doc = new XmlDocument();

            if (File.Exists(fileName))
            {
                doc.Load(fileName);
            }
            else
            {
                XmlDeclaration declaration =
                    doc.CreateXmlDeclaration("1.0", "UTF-8", null);

                doc.AppendChild(declaration);

                XmlElement root = doc.CreateElement("tasks");
                doc.AppendChild(root);
            }

            XmlNode rootNode = doc.SelectSingleNode("/tasks");

            if (rootNode == null)
                throw new Exception(Resources.XmlMissingRootTask);

            XmlElement taskNode = doc.CreateElement("task");

            AddNode(doc, taskNode, "id", id);
            AddNode(doc, taskNode, "title", title);
            AddNode(doc, taskNode, "category", category);
            AddNode(doc, taskNode, "mode", mode);
            AddNode(doc, taskNode, "difficulty", difficulty);
            AddCDataNode(doc, taskNode, "specification", specification);
            if (mode == "Reference_model" || mode == "Test_cases")
                AddCDataNode(doc, taskNode, "verification", verification);
            else
                AddNode(doc, taskNode, "verification", verification);

            XmlElement inputTestingNode = doc.CreateElement("inputTesting");

            if (cmbTestWords.SelectedIndex == 1)
            {
                inputTestingNode.SetAttribute("mode", "Selected_words");

                XmlElement wordsNode = doc.CreateElement("words");

                foreach (string testWord in testWords)
                {
                    XmlElement wordNode = doc.CreateElement("word");
                    wordNode.SetAttribute("value", testWord == "ε" ? "" : testWord);

                    wordsNode.AppendChild(wordNode);
                }

                inputTestingNode.AppendChild(wordsNode);
            }
            else
            {
                inputTestingNode.SetAttribute("mode", "Recursive");
                AddNode(doc, inputTestingNode, "maxLength", tests);
            }
            
            taskNode.AppendChild(inputTestingNode);
            
            rootNode.AppendChild(taskNode);

            doc.Save(fileName);
        }

        private void AddNode(XmlDocument doc, XmlElement parent, string name, string value)
        {
            XmlElement element = doc.CreateElement(name);
            element.InnerText = value ?? "";
            parent.AppendChild(element);
        }

        private void AddCDataNode(XmlDocument doc, XmlElement parent, string name, string value)
        {
            XmlElement element = doc.CreateElement(name);
            XmlCDataSection cdata = doc.CreateCDataSection(value ?? "");
            element.AppendChild(cdata);
            parent.AppendChild(element);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolTipLabel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipFormula,toolTipLabel1);
        }
        
        private void toolTipLabel2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipRegex,toolTipLabel2);
        }
        
        private void toolTipLabel3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipReference,toolTipLabel3);
        }
        
        private void toolTipLabel4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipSpecification,toolTipLabel4);
        }
        private void toolTipLabel5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipTestCases,toolTipLabel5);
        }
        private void toolTipLabel8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(Resources.ToolTipTestWords,toolTipLabel8);
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!testCases.ContainsKey(txtWord.Text))
            {
                if (txtWord.Text.Equals(" "))
                    txtWord.Text = "ε";
                    
                if (checkBoxAccept.Checked)
                {
                    lblTestingCases.Items.Add(txtWord.Text.Trim()+" - "+Resources.Accept);
                    testCases.Add(txtWord.Text.Trim(),true);
                }

                if (checkBoxFail.Checked)
                {
                    lblTestingCases.Items.Add(txtWord.Text.Trim()+" - "+Resources.Reject);
                    testCases.Add(txtWord.Text.Trim(),false);
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lblTestingCases.SelectedIndex >= 0)
            {
                string word = lblTestingCases.Items[lblTestingCases.SelectedIndex].ToString();
                word = word.Substring(0, word.IndexOf('-')-1);
                testCases.Remove(word);
                lblTestingCases.Items.RemoveAt(lblTestingCases.SelectedIndex);
            }
        }

        private void checkBoxAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAccept.Checked == checkBoxFail.Checked)
            {
                checkBoxFail.Checked = !checkBoxAccept.Checked;
            }
        }

        private void checkBoxFail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFail.Checked == checkBoxAccept.Checked)
            {
                checkBoxAccept.Checked = !checkBoxFail.Checked;
            };
        }
        
        private string GetSelectedMode()
        {
            if (cmbMode.Text == "Formula")
                return "Formula";

            if (cmbMode.Text == "Regex")
                return "Regex";

            if (cmbMode.Text == Resources.ReferenceAutomaton)
                return "Reference_model";

            if (cmbMode.Text == Resources.TestCases)
                return "Test_cases";

            return "";
        }
        
        private void btnAddTestWord_Click(object sender, EventArgs e)
        {
            if (!testWords.Contains(txtTestWord.Text))
            {
                if (txtTestWord.Text.Equals(" "))
                    txtTestWord.Text = "ε";
                
                lblTestWords.Items.Add(txtTestWord.Text.Trim());
                testWords.Add(txtTestWord.Text.Trim());
            }
        }

        private void btnRemoveTestWord_Click(object sender, EventArgs e)
        {
            if (lblTestWords.SelectedIndex >= 0)
            {
                string word = lblTestWords.Items[lblTestWords.SelectedIndex].ToString();
                testWords.Remove(word);
                lblTestWords.Items.RemoveAt(lblTestWords.SelectedIndex);
            }
        }
        
    }
}