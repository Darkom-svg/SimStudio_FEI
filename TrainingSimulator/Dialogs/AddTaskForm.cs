using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace FEI.TrainingSimulator.Dialogs
{
    public partial class AddTaskForm : Form
    {
        public AddTaskForm()
        {
            InitializeComponent();

            cmbModel.SelectedIndex = 0;
            cmbMode.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            UpdateVerificationPanels();
        }
        
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMode.Items.Clear();

            if (cmbModel.SelectedIndex == 0) 
            {
                cmbMode.Items.Add("Formula");
                cmbMode.Items.Add("Regex");
                cmbMode.Items.Add("Reference_model");
                cmbMode.SelectedIndex = 0;
            }
            else 
            {
                cmbMode.Items.Add("Reference_model");
                cmbMode.SelectedIndex = 0;
            }
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateVerificationPanels();
        }

        private void UpdateVerificationPanels()
        {
            string mode = cmbMode.Text;

            formulaPanel.Visible = mode == "Formula";
            regexPanel.Visible = mode == "Regex";
            referenceModelPanel.Visible = mode == "Reference_model";
        }

        private void taskSetPathButton_Click(object sender, EventArgs e)
        {
            string tasksDir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Tasks");

            Directory.CreateDirectory(tasksDir);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = tasksDir;
            dialog.Filter = "XML súbory (*.xml)|*.xml";
            dialog.DefaultExt = "xml";
            dialog.OverwritePrompt = false;

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtTaskSetPath.Text = dialog.FileName;
            }
        }

        private void referencePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Modely automatov |*.fa;*.pa;*.tm|JFlap Turingov stroj|*.jff|Všetky súbory |*.*";

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                txtReferencePath.Text = dialog.FileName;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateForm();
                string mode = cmbMode.Text;
                string verification = "";

                if (mode == "Formula")
                    verification = txtFormula.Text.Trim();
                else if (mode == "Regex")
                    verification = txtRegex.Text.Trim();
                else if (mode == "Reference_model")
                    verification = File.ReadAllText(txtReferencePath.Text.Trim());
                
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

                AddTaskToXml(
                    txtTaskSetPath.Text.Trim(),
                    txtId.Text.Trim(),
                    txtTitle.Text.Trim(),
                    category,
                    mode,
                    comboBox1.Text.Trim(),
                    txtSpecification.Text,
                    verification);

                MessageBox.Show(
                    "Príklad bol úspešne pridaný.",
                    "Pridanie príkladu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Chyba pri pridávaní príkladu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTaskSetPath.Text))
                throw new Exception("Vyberte alebo zadajte cestu k sade príkladov.");

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
                throw new Exception("Zadajte názov príkladu.");

            if (string.IsNullOrWhiteSpace(cmbModel.Text))
                throw new Exception("Vyberte typ automatu.");

            if (string.IsNullOrWhiteSpace(cmbMode.Text))
                throw new Exception("Vyberte spôsob overovania.");

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
                throw new Exception("Vyberte obtiažnosť príkladu.");

            if (string.IsNullOrWhiteSpace(txtSpecification.Text))
                throw new Exception("Zadajte popis zadania.");

            string verification = "";
            if (cmbMode.Text == "Formula")
                verification = txtFormula.Text.Trim();
            else if (cmbMode.Text == "Regex")
                verification = txtRegex.Text.Trim();
            else if (cmbMode.Text == "Reference_model")
                verification = File.ReadAllText(txtReferencePath.Text.Trim());

            if (string.IsNullOrWhiteSpace(verification))
                throw new Exception("Zadajte hodnotu overovania príkladu.");
        }

        private void AddTaskToXml(
            string fileName,
            string id,
            string title,
            string category,
            string mode,
            string difficulty,
            string specification,
            string verification)
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
                throw new Exception("XML súbor nemá koreňový element <tasks>.");

            XmlElement taskNode = doc.CreateElement("task");

            AddNode(doc, taskNode, "id", id);
            AddNode(doc, taskNode, "title", title);
            AddNode(doc, taskNode, "category", category);
            AddNode(doc, taskNode, "mode", mode);
            AddNode(doc, taskNode, "difficulty", difficulty);
            AddCDataNode(doc, taskNode, "specification", specification);
            if (mode == "Reference_model")
                AddCDataNode(doc, taskNode, "verification", verification);
            else
                AddNode(doc, taskNode, "verification", verification);

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
    }
}