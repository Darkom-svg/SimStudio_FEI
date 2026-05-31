using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Dialogs;
using FEI.SimStudio.Components.Registers;
using FEI.TuringCore.Simulation;
using AboutForm = FEI.TrainingSimulator.Dialogs.AboutForm;
using System.Xml;
using FEI.TrainingSimulator.Properties;
using FEI.TuringMachineSimulator.Dialogs;
using FEI.TuringMachineSimulator.IO.Jff;

namespace FEI.TrainingSimulator
{
    public partial class TmTrainingForm : Form
    {
        private MainTrainingForm.TaskDef task;
        //Zoznam menu položiek pre výber formátu
        List<ToolStripMenuItem> miTFormatMenuItems;

        //Formát prechodovej funkcie
        string transitionFormat = "\\sδ\\s(\\a,\\a)\\s=\\s(\\a,\\a,\\a)\\s";
        //Formát 
        string wildCardFormat = "\\a=\\s{\\m,\\n}\\s"; 
        // Vytvorí formálnu špecifikáciu
        private string tmpFormalSpecFileName;
        // Vytvorí špecifikáciu zadania
        private string tmpTaskSpecFileName;
        string openFileName;
        private VirtualTuringMachine turingMachine =
            new VirtualTuringMachine()
            {
                AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
            };

        public TmTrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            this.task = task;
            this.Text = string.Format(Resources.TrainerWindowText,  this.task.Id);
            CreateTaskSpecification();
            miTFormatMenuItems = new List<ToolStripMenuItem>(new[]
            {
                miTFormat1, miTFormat2, miTFormat3,
                miTFormat4, miTFormat5, miTFormat6,
                miTFormat7, miTFormat8, miTFormat9,
                miTFormat10
            });
            int index = Properties.Settings.Default.TransitionFormatFa;
            miTFormatMenuItems[index].PerformClick();
        }

        private VirtualTuringMachine TuringMachine
        {
            get => turingMachine;
            set
            {
                turingMachine = value;
                stateDiagramControl.TuringMachine = turingMachine;
            }
        }
        
        private void frmTuringMachine_Load(object sender, System.EventArgs e)
        {
            if (MdiParent != null) menuStrip1.Visible = false;
            this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon")));

            stateDiagramControl.TuringMachine = TuringMachine;
			
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("δ", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("f", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("(", Color.Black, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord(")", Color.Black, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord(",", Color.Black, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("=", Color.Black, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("L", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("R", Color.Blue, true));
            txtCode.SyntaxWords.Add(new SyntaxTextBox.SyntaxWord("0", Color.Blue, true));
            txtCode.SyntaxWords.Add(new  SyntaxTextBox.SyntaxWord("Blank", Color.Blue, true));
            txtCode.SyntaxWords.fStrings = new SyntaxTextBox.SyntaxFormat(Color.DarkRed, true);
            txtCode.SyntaxWords.fNumbers = new SyntaxTextBox.SyntaxFormat(Color.DarkBlue, true);
            txtCode.SyntaxWords.fComment = new SyntaxTextBox.SyntaxFormat(Color.DarkGreen);
        }
        
        private void bAddTFunction_Click(object sender, EventArgs e)
        {
            AddTransition(new Transition());
        }     
        
        private void AddTransition(Transition defTf)
        {             
            AddTFunctionForm dlg = new AddTFunctionForm();
            dlg.TM = this.TuringMachine;
            dlg.tFunction = defTf;
            dlg.ShowDialog(this);
            if (dlg.OKPressed)
            {
                Transition tf = dlg.tFunction;
                txtCode.Text += Environment.NewLine;
                txtCode.Text += WriteTransition(tf, transitionFormat);
                if (tf.Comment.Trim() != "") txtCode.Text += " //" + tf.Comment;
                txtCode.Text += Environment.NewLine;
                ParseTFunctions(txtCode.Text);
            }
        }

        private string WriteTransition(Transition tf, string tFormat) {
            string res = "";
            int i = 0, l = 0;
            int n = 0; //Index vstupu
            string arg = "";

            String step = "";
            switch (tf.Step) {
                case Transition.Steps.Left:
                    step = "L";
                    break;
                case Transition.Steps.Right:
                    step = "R";
                    break;
                case Transition.Steps.NoMove:
                    step = "0";
                    break;
            }

            tFormat = tFormat.Replace("\\s", " ");

            while (true) {
                i = tFormat.IndexOf("\\a", l);
                if (i == -1) {
                    res += tFormat.Substring(l);
                    break;
                }

                if (n == 0) arg = tf.CurrentState;
                else if (n == 1) arg = tf.ReadSymbol;
                else if (n == 2) arg = tf.NewState;
                else if (n == 3) arg = tf.WriteSymbol;
                else if (n == 4) arg = step;

                res += tFormat.Substring(l, i - l) + arg;

                l = i + 2;
                n++;

            }

            return res;
        }      
        
        private bool ParseTFunctions(string sourceCodeText)
        {
            TuringMachineParser parser =
                new TuringMachineParser(TuringMachine, transitionFormat, wildCardFormat);

            bool retval = parser.ParseTFunctions(sourceCodeText);

            UpdateErrors(parser.Errors);
            Functions_SetScrollbar();

            TuringMachine.StateDiagram.UpdateForTM(TuringMachine);

            return retval;
        }
        
        private void UpdateErrors(List<TMError> errors)
        {
            lstErrors.Items.Clear();
		   
            // Zobrazenie chýb
            if (errors.Count > 0)
            {                
                lstErrors.Items.AddRange(errors.ToArray());
                splitContainer2.Panel2Collapsed = false;
            }
        }     
        
        private void Functions_SetScrollbar()
        {
            if (this.InvokeRequired)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { Functions_SetScrollbar(); })));
            }
            else
            {
                int max;
                max = turingMachine.FunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
                if (max < 0)
                    max = 0;

                // sbyFunctions.Maximum = max;
                // sbyFunctions.SmallChange = 1;
                // sbyFunctions.LargeChange = (int)Math.Floor((double)pFunctions.Height / 20);
                // sbyFunctions.Visible = true;
                //
                // pFunctions.Refresh();
            }
        }
        
        private void UpdateStateDiagram()
        {
            //Načíta prechodové funkcie z kódu
            ParseTFunctions(txtCode.Text);

            TuringMachine.StateDiagram.UpdateForTM(TuringMachine);
        }          
        
        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tcMain.SelectedTab == statesTab)
			{                                
				UpdateStateDiagram();
			}
			else if (tcMain.SelectedTab == formalSpecificationTab)
			{
				//Načíta prechodové funkcie z kódu
				ParseTFunctions(txtCode.Text);
				//Vytvorí formálnu špecifikáciu
				CreateFormalSpecification();
			}
		}
        

        private void CreateFormalSpecification()
		{
			if (tmpFormalSpecFileName != null)
			{
				File.Delete(tmpFormalSpecFileName);
			}

			string tmpDirPath = new FileInfo(Application.ExecutablePath).Directory.FullName + "\\tmp\\";
			tmpFormalSpecFileName = tmpDirPath + (new Random()).Next(1000000) + ".html";
			StringBuilder sb = new StringBuilder();

			if (!Directory.Exists(tmpDirPath))
			{
				Directory.CreateDirectory(tmpDirPath);
			}

			sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
			sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"sk\" lang=\"sk\">");
			//Hlavicka
			sb.AppendLine("<head>");
                sb.AppendLine("<title>"+Resources.FormalSpecification+"</title>");

			    sb.AppendLine("<style>");
			        sb.AppendLine("body { font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; }");
			        sb.AppendLine("h1 {");
			        sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 30px;");
			        sb.AppendLine("font-weight: bold; border-bottom-style: dotted;");
			        sb.AppendLine("border-bottom-width: 3px; border-bottom-color: #000066;");
			        sb.AppendLine("color: #000066; padding-bottom: 5px; margin-bottom: 10px;");
			        sb.AppendLine("}");
			        sb.AppendLine("h2 {");
			        sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 16px;");
			        sb.AppendLine("font-weight: bold;");
			        sb.AppendLine("color: #000066; margin-bottom: 5px;");
			        sb.AppendLine("}");
			    sb.AppendLine("</style>");
			sb.AppendLine("</head>");

			//Telo
			sb.AppendLine("<body>");
			//Nadpis
            sb.AppendLine("<h1>"+Resources.FormalSpecification+"</h1>");

			sb.AppendLine("<div>");
			sb.AppendLine(Resources.TuringMachine + " <strong>T = (K, Σ, Γ, δ, " + TuringMachine.StartState + ", F)</strong>");
			sb.AppendLine("</div>");

			// Množina stavov
			sb.AppendLine("<div>");
			sb.AppendLine("<strong>K</strong> = {" + TuringMachine.GetUsedStatesAsString() + "}");
			sb.AppendLine("</div>");
			// Vstupná abeceda
			sb.AppendLine("<div>");
			sb.AppendLine("<strong>Σ</strong> = {" + TuringMachine.GetUsedSymbolsAsString() + "}");
			sb.AppendLine("</div>");
			// Páskova abeceda
			sb.AppendLine("<div>");
			sb.AppendLine("<strong>Γ</strong> = {" + TuringMachine.GetUsedSymbolsAsString() + ", Blank}");
			sb.AppendLine("</div>");
			// Počiatočný stav
			sb.AppendLine("<div>");
			sb.AppendLine("<strong>" + TuringMachine.StartState + "</strong>  " + Resources.InitialState);
			sb.AppendLine("</div>");
			// Množina koncových stavov
			sb.AppendLine("<div>");
			sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", TuringMachine.FinalStates.ToArray()) + "}");
			sb.AppendLine("</div>");

			// Prechodové funkcie
			sb.AppendLine("<div>");
            sb.AppendLine("<h2>"+ Resources.TransitionFunction +" δ</h2>");
			foreach (Transition f in TuringMachine.GetTFunctions()) {
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol +
					") = (" + f.NewState + ", " + f.WriteSymbol + ", " + Transition.StepToString(f.Step) + ")");
				sb.AppendLine("</div>");
			}
			sb.AppendLine("</div>");

			sb.AppendLine("</body>");

			sb.AppendLine("</html>");

			System.IO.TextWriter tw = new System.IO.StreamWriter(
				new FileStream(tmpFormalSpecFileName, FileMode.Create, FileAccess.Write), Encoding.UTF8);
			tw.Write(sb.ToString());
			tw.Close();

			formalSpecifiaction.Navigate(tmpFormalSpecFileName);
		}      

        private void CreateTaskSpecification()
        {
            if (tmpTaskSpecFileName != null)
            {
                File.Delete(tmpTaskSpecFileName);
            }

            string tmpDirPath = new FileInfo(Application.ExecutablePath).Directory.FullName + "\\tmp\\";
            tmpTaskSpecFileName = tmpDirPath + (new Random()).Next(1000000) + ".html";
            StringBuilder sb = new StringBuilder();

            if (!Directory.Exists(tmpDirPath))
            {
                Directory.CreateDirectory(tmpDirPath);
            }

            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");

            //Hlavicka
            sb.AppendLine("<head>");
                sb.AppendLine("<meta http-equiv='X-UA-Compatible' content='IE=edge' />");
                sb.AppendLine("<meta charset='utf-8' />");
                sb.AppendLine("<title>" + task.Title + "</title>");
                
                sb.AppendLine("<style>");
                sb.AppendLine("body { font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 14px; }");
                sb.AppendLine("h1 {");
                sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 30px;");
                sb.AppendLine("font-weight: bold; border-bottom-style: dotted;");
                sb.AppendLine("border-bottom-width: 3px; border-bottom-color: #000066;");
                sb.AppendLine("color: #000066; padding-bottom: 5px; margin-bottom: 10px;");
                sb.AppendLine("}");
                sb.AppendLine("h2 {");
                sb.AppendLine("font-family: Arial, Helvetica, sans-serif; font-size: 16px;");
                sb.AppendLine("font-weight: bold;");                
                sb.AppendLine("color: #000066; margin-bottom: 5px;");
                sb.AppendLine("}");
                sb.AppendLine("</style>");
                
                sb.AppendLine("<script type='text/x-mathjax-config'>");
                sb.AppendLine("MathJax.Hub.Config({");
                sb.AppendLine("  tex2jax: {");
                sb.AppendLine("    inlineMath: [['$','$'], ['\\\\(','\\\\)']],");
                sb.AppendLine("    displayMath: [['$$','$$'], ['\\\\[','\\\\]']],");
                sb.AppendLine("    processEscapes: true");
                sb.AppendLine("  },");
                sb.AppendLine("  messageStyle: 'none'");
                sb.AppendLine("});");
                sb.AppendLine("</script>");

                sb.AppendLine("<script type='text/javascript' async ");
                sb.AppendLine("src='https://cdn.jsdelivr.net/npm/mathjax@2.7.9/MathJax.js?config=TeX-AMS-MML_HTMLorMML'>");
                sb.AppendLine("</script>");
                
            sb.AppendLine("</head>");
            
            //Telo
            sb.AppendLine("<body>");
                //Nadpis
                sb.AppendLine("<h1>" + task.Title + "</h1>");
                //Parametre zadania
                sb.AppendLine("<h2>" + Resources.TaskParameters + "</h2>");
                // Typ zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>" + Resources.TaskType + "</strong> " + Resources.PushdownAutomaton);
                sb.AppendLine("</div>");

                // ID zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>Id:</strong> " + task.Id);
                sb.AppendLine("</div>");
                // Obtiažnosť zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>" + Resources.TaskDifficulty + "</strong> " + task.Difficulty);
                sb.AppendLine("</div>");           
                
                // Popis zadania
                sb.AppendLine("<h2>" + Resources.TaskSpecification + "</h2>");
                sb.AppendLine("<div id='math'>");
                sb.AppendLine((task.Specification ?? "")
                    .Replace("&", "&amp;")
                    .Replace("<", "&lt;")
                    .Replace(">", "&gt;")
                    .Replace("\n", "<br>"));
                sb.AppendLine("</div>");
                
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            System.IO.TextWriter tw = new System.IO.StreamWriter(
                new FileStream(tmpTaskSpecFileName, FileMode.Create, FileAccess.Write), Encoding.UTF8);
            tw.Write(sb.ToString());
            tw.Close();

            taskSpecification.Navigate(tmpTaskSpecFileName);            
        }
        
        private void miAbout_Click(object sender, EventArgs e)
        {
            AboutForm dlg = new AboutForm();
            dlg.ShowDialog(this);        
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miCut_Click(object sender, EventArgs e)
        {
            this.txtCode.Cut();
        }

        private void miCopy_Click(object sender, EventArgs e)
        {
            this.txtCode.Copy();
        }

        private void miPaste_Click(object sender, EventArgs e)
        {
            this.txtCode.Paste();
        }

        private void miDelete_Click(object sender, EventArgs e)
        {
            this.txtCode.Delete();
        }

        private void miSelectAll_Click(object sender, EventArgs e)
        {
            this.txtCode.SelectAll();
        }
        
        private void miReplace_Click(object sender, EventArgs e)
        {
            ReplaceForm frm = new ReplaceForm();
            frm.textBox = txtCode;
            frm.Show(this);
        }

        private void miFind_Click(object sender, EventArgs e)
        {
            FindForm frm = new FindForm();
            frm.textBox = txtCode;
            frm.Show(this);
        }

        private void miAddTransition_Click(object sender, EventArgs e)
        {
            AddTransition(new Transition());
        }
        
        private void bAddState_Click(object sender, EventArgs e)
        {
            AddTransition(new Transition());
        }
        
        private void miSettings_Click(object sender, EventArgs e) {
            SettingsForm frm = new SettingsForm();
            frm.initialState = TuringMachine.StartState;
            frm.finalStates = new List<string>(TuringMachine.FinalStates);
            frm.ShowDialog(this);
            if (frm.OKPressed) {
                TuringMachine.StartState = frm.initialState;
                TuringMachine.FinalStates = frm.finalStates;
                UpdateStateDiagram();
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            Save();           
        }

        private void miSaveFile_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void miSaveAsFile_Click(object sender, EventArgs e)
        {
            SaveAs();            
        }        
        private void Save()
        {
            if (openFileName == null) SaveAs();
            else File_Save(openFileName);
        }

        private void SaveAs()
        {
            saveFileDialog1.ShowDialog(this);
        }
        
        private void File_Save(string fileName)
        {                        
            if (!Functions.IsEmpty(fileName))
            {                
                if (!fileName.EndsWith(".tm")) fileName += ".tm";
                TuringMachine.Save(fileName, txtCode.Text);
				
                openFileName = fileName;
                this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + this.Text;
            }
        }
        
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FilterIndex == 1)
                File_Save(saveFileDialog1.FileName);
            else if (saveFileDialog1.FilterIndex == 2)
                File_SaveJff(saveFileDialog1.FileName);
        }
        
        private void File_SaveJff(string fileName)
        {
            if (!Functions.IsEmpty(fileName))
            {
                if (!fileName.EndsWith(".jff")) fileName += ".jff";
                JffWriter writer = new JffWriter(TuringMachine, fileName);
                writer.Save(); 
            }
        }
        

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            File_Open();
        }

        private void miOpenFile_Click(object sender, EventArgs e)
        {
            File_Open();
        }
        
        private void File_Open() {
            if (base.MdiParent == null) {
                this.openFileDialog1.ShowDialog(this);
                this.OpenFile(this.openFileDialog1.FileName);
                return;
            }
            ((IMainForm)base.MdiParent).OpenFile();
        }
        
        public void OpenFile(string fileName)
        {
            if (fileName.EndsWith(".tm", StringComparison.OrdinalIgnoreCase))
            {
                TuringMachine = new VirtualTuringMachine
                {
                    AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
                };

                txtCode.Text = TuringMachine.Load(fileName);
                ParseTFunctions(txtCode.Text);

                openFileName = fileName;
                this.Text = Path.GetFileName(openFileName) + " - " + this.Text;
            }
            else if (fileName.EndsWith(".jff", StringComparison.OrdinalIgnoreCase))
            {
                JffReader reader = new JffReader(fileName);

                TuringMachine = reader.Read();

                if (TuringMachine == null)
                {
                    TuringMachine = new VirtualTuringMachine
                    {
                        AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
                    };
                }
                else
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (var tf in TuringMachine.GetTFunctions())
                    {
                        sb.AppendLine(WriteTransition(tf, transitionFormat));
                    }

                    txtCode.Text = sb.ToString();
                    ParseTFunctions(txtCode.Text);
                }

                openFileName = fileName;
                this.Text = Path.GetFileName(openFileName) + " - " + this.Text;
            }

            this.Refresh();
        }
        
        private sealed class CheckResult
        {
            public bool IsCorrect { get; set; }
            public string Message { get; set; } = "";
        }

        private void checkToolStripButton_Click(object sender, EventArgs e)
        {
            CheckResult result;

            if (task.Mode.Equals("Test_cases", StringComparison.OrdinalIgnoreCase))
            {
                result = CheckTmByTestCases();
            }
            else if (task.Mode.Equals("Reference_model", StringComparison.OrdinalIgnoreCase))
            {
                result = CheckTmByReferenceModel();
            }
            else
            {
                result = new CheckResult
                {
                    IsCorrect = false,
                    Message = string.Format(
                        Resources.UnknownModeError,
                        task.Mode)
                };
            }

            if (result.IsCorrect)
            {
                MessageBox.Show(
                    Resources.Correct,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    this.Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        
        private VirtualTuringMachine CreateReferenceTm()
        {
            if (string.IsNullOrWhiteSpace(task.Verification))
                throw new Exception(Resources.MissingReferenceModel);

            string tmpFile = Path.Combine(
                Path.GetTempPath(),
                "reference_tm_" + Guid.NewGuid().ToString("N") + ".tm");

            try
            {
                File.WriteAllText(tmpFile, task.Verification, Encoding.UTF8);

                var tm = new VirtualTuringMachine
                {
                    AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
                };

                string code = tm.Load(tmpFile);

                var parser = new TuringMachineParser(
                    tm,
                    transitionFormat,
                    wildCardFormat);

                if (!parser.ParseTFunctions(code))
                    throw new Exception(Resources.ReferenceModelSyntaxError);

                tm.StateDiagram.UpdateForTM(tm);

                return tm;
            }
            finally
            {
                try
                {
                    if (File.Exists(tmpFile))
                        File.Delete(tmpFile);
                }
                catch
                {
                    // ignored
                }
            }
        }
        
        private VirtualTuringMachine CreateStudentTm()
        {
            var tm = new VirtualTuringMachine
            {
                AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
            };

            var parser = new TuringMachineParser(
                tm,
                transitionFormat,
                wildCardFormat);

            if (!parser.ParseTFunctions(txtCode.Text))
                throw new Exception(Resources.StudentModelSynatxError);

            tm.StartState = TuringMachine.StartState;
            tm.FinalStates = new List<string>(TuringMachine.FinalStates);

            tm.StateDiagram.UpdateForTM(tm);

            return tm;
        }
        
        private List<string> GetInputAlphabet(VirtualTuringMachine tm)
        {
            var alphabet = new HashSet<string>();

            for (int i = 0; i < tm.FunctionCount; i++)
            {
                string symbol = tm.Function(i).ReadSymbol;

                if (!string.IsNullOrEmpty(symbol) && symbol != "Blank")
                    alphabet.Add(symbol);
            }

            return alphabet.OrderBy(x => x).ToList();
        }
        
        private Dictionary<string, bool> ParseTestCases(string verification)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(verification);

            XmlNodeList nodes = doc.SelectNodes("//test");

            if (nodes == null || nodes.Count == 0)
                throw new Exception(Resources.NoTestCasesFound);

            var result = new Dictionary<string, bool>();

            foreach (XmlNode node in nodes)
            {
                string word = node.Attributes?["word"]?.Value ?? "";
                string expectedText = node.Attributes?["expected"]?.Value ?? "";

                if (word == "ε")
                    word = "";

                bool expected;

                if (expectedText.Equals("accept", StringComparison.OrdinalIgnoreCase))
                    expected = true;
                else if (expectedText.Equals("reject", StringComparison.OrdinalIgnoreCase))
                    expected = false;
                else
                    throw new Exception(string.Format(Resources.InvalidExpectedValue, word));

                result[word] = expected;
            }

            return result;
        }
        
        private List<string> GenerateWords(int maxLength, List<string> alphabet)
        {
            var words = new List<string>();
            GenerateWordsRecursive("", maxLength, alphabet, words);
            return words;
        }

        private void GenerateWordsRecursive(
            string current,
            int remaining,
            List<string> alphabet,
            List<string> words)
        {
            words.Add(current);

            if (remaining == 0)
                return;

            foreach (string symbol in alphabet)
            {
                GenerateWordsRecursive(current + symbol, remaining - 1, alphabet, words);
            }
        }
        
        private bool AcceptsByTm(VirtualTuringMachine tm, string word)
        {
            tm.Reset();
            tm.WriteLog = false;
            tm.Log.Clear();
            tm.RemoveAllThreads();

            tm.OriginalTapes = new List<InfiniteTape>();

            InfiniteTape tape = new InfiniteTape();

            for (int i = 0; i < word.Length; i++)
            {
                tape.SetCell(i, word[i].ToString());
            }

            tape.HeadPosition = 0;

            tm.OriginalTapes.Add(tape);
            tm.ActiveTapes = InfiniteTape.DeepCopyTapes(tm.OriginalTapes);
            tm.CurrentState = tm.StartState;

            int maxSteps = 500;

            for (int step = 0; step < maxSteps; step++)
            {
                if (tm.IsFinalState(tm.CurrentState))
                    return true;

                tm.NextStep(false);

                tm.Log.Clear();

                if (tm.IsFinalState(tm.CurrentState))
                    return true;

                if (tm.NoNextStep)
                    return false;
            }

            return false;
        }
        
        private CheckResult CheckTmByReferenceModel()
        {
            if (string.IsNullOrWhiteSpace(task.Verification))
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = Resources.MissingReferenceModel

                };
            }
            
            VirtualTuringMachine referenceForAlphabet = CreateReferenceTm();
            List<string> alphabet = GetInputAlphabet(referenceForAlphabet);
            List<string> words;
            
            if (task.InputTestingMode == "Selected_words")
            {
                words = task.InputTestingWords.ToList();
            }
            else
            {
                words = GenerateWords(
                    task.InputTestingMaxLength,
                    alphabet);
            }

            testedWords.Clear();
            testedStates.Clear();
            Tests_SetScrollbar();
            pTests.Refresh();

            foreach (string word in words)
            {
                VirtualTuringMachine reference;
                VirtualTuringMachine student;

                try
                {
                    reference = CreateReferenceTm();
                    student = CreateStudentTm();
                }
                catch (Exception ex)
                {
                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message = ex.Message
                    };
                }

                bool expected = AcceptsByTm(reference, word);
                bool actual = AcceptsByTm(student, word);

                AddTestResult(word, expected, actual);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message =string.Format(
                            Resources.AutomatonMismatchError,
                            shownWord,
                            expected ? Resources.Accept : Resources.Reject,
                            actual ? Resources.Accept : Resources.Reject)
                    };
                }
            }

            return new CheckResult
            {
                IsCorrect = true,
                Message = Resources.Correct
            };
        }
        
        private CheckResult CheckTmByTestCases()
        {
            Dictionary<string, bool> testCases = ParseTestCases(task.Verification);

            testedWords.Clear();
            testedStates.Clear();
            Tests_SetScrollbar();
            pTests.Refresh();

            foreach (var testCase in testCases)
            {
                VirtualTuringMachine student;

                try
                {
                    student = CreateStudentTm();
                }
                catch (Exception ex)
                {
                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message = ex.Message
                    };
                }

                string word = testCase.Key;
                bool expected = testCase.Value;
                bool actual = AcceptsByTm(student, word);

                AddTestResult(word, expected, actual);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message =string.Format(
                            Resources.AutomatonMismatchError,
                            shownWord,
                            expected ? Resources.Accept : Resources.Reject,
                            actual ? Resources.Accept : Resources.Reject)
                    };
                }
            }

            return new CheckResult
            {
                IsCorrect = true,
                Message = Resources.Correct
            };
        }
        
        private void miTFormat1_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\sf\\s(\\a,\\a)\\s=\\s(\\a,\\a,\\a)\\s");
        }

        private void miTFormat2_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\s(\\a,\\a)\\s=\\s(\\a,\\a,\\a)\\s");
        }

        private void miTFormat3_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\a,\\a,\\a,\\a,\\a");
        }

        private void miTFormat4_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\s[\\a,\\a]\\s[\\a,\\a,\\a]\\s");
        }

        private void miTFormat5_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\s(\\a,\\a)\\s(\\a,\\a,\\a)\\s");
        }

        private void miTFormat6_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\s[\\a,\\a]\\s->\\s[\\a,\\a,\\a]\\s");
        }

        private void miTFormat7_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\s(\\a,\\a)\\s->\\s(\\a,\\a,\\a)\\s");
        }

        private void miTFormat8_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\a,\\a->\\a,\\a,\\a");
        }

        private void miTFormat9_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\a,\\a>\\a,\\a,\\a");
        }

        private void miTFormat10_Click(object sender, EventArgs e) {
            SetTFormat(sender, "\\sδ\\s(\\a,\\a)\\s=\\s(\\a,\\a,\\a)\\s");
        }
        
        private void SetTFormat(object sender, string format)
        {
            var item = sender as ToolStripMenuItem;

            if (item == null)
                return;

            transitionFormat = format;

            foreach (var menuItem in miTFormatMenuItems)
                menuItem.Checked = false;

            item.Checked = true;
            Properties.Settings.Default.TransitionFormatTm =
                miTFormatMenuItems.IndexOf(item);

            Properties.Settings.Default.Save();
        }
        
        private List<string> testedWords = new List<string>();
        private List<String> testedStates = new List<String>();
        private int testsFirstIndex = 0;
        private void pTests_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(Color.White);

            int rowHeight = 34;
            int y = 6;

            int visibleRows = Math.Max(1, pTests.Height / rowHeight);

            for (int i = testsFirstIndex;
                 i < testedWords.Count && i < testsFirstIndex + visibleRows;
                 i++)
            {
                Rectangle rect = new Rectangle(
                    6,
                    y,
                    pTests.Width - 14,
                    rowHeight - 6);

                Color borderColor;

                if (testedStates[i] == "Chyba")
                    borderColor = Color.Red;
                else
                    borderColor = Color.Green;

                using (Pen pen = new Pen(borderColor, 2))
                {
                    g.DrawRectangle(pen, rect);
                }

                string wordText;

                if (testedWords[i] == "")
                    wordText = "ε";
                else
                    wordText = testedWords[i];

                // ľavý text
                g.DrawString(
                    wordText,
                    Font,
                    Brushes.Black,
                    rect.X + 8,
                    rect.Y + 7);

                // pravý text
                SizeF stateSize = g.MeasureString(testedStates[i], Font);

                g.DrawString(
                    testedStates[i],
                    Font,
                    Brushes.Black,
                    rect.Right - stateSize.Width - 8,
                    rect.Y + 7);

                y += rowHeight;
            }

            g.DrawRectangle(Pens.Black, 0, 0, pTests.Width - 1, pTests.Height - 1);
        }
        
        private void sbyTests_Scroll(object sender, ScrollEventArgs e)
        {
            testsFirstIndex = sbyTests.Value;
            pTests.Refresh();
        }
        private void pTests_Resize(object sender, System.EventArgs e)
        {
            Tests_SetScrollbar();
        }
        
        private void Tests_SetScrollbar()
        {
            int rowHeight = 34;

            int visibleRows = Math.Max(1, pTests.Height / rowHeight);

            int count = testedWords.Count;

            if (count <= visibleRows)
            {
                sbyTests.Visible = false;
                sbyTests.Value = 0;
                testsFirstIndex = 0;
            }
            else
            {
                sbyTests.Visible = true;

                sbyTests.Minimum = 0;
                sbyTests.Maximum = count - 1;

                sbyTests.SmallChange = 1;
                sbyTests.LargeChange = visibleRows;

                if (sbyTests.Value > count - visibleRows)
                    sbyTests.Value = Math.Max(0, count - visibleRows);

                testsFirstIndex = sbyTests.Value;
            }

            pTests.Refresh();
        }
        
        private void AddTestResult(string word, bool expected, bool actual)
        {
            testedWords.Add(word);

            if (expected != actual)
                testedStates.Add(Resources.Error);
            else if (expected)
                testedStates.Add(Resources.Accept);
            else
                testedStates.Add(Resources.Reject);

            Tests_SetScrollbar();
            pTests.Refresh();
        }
    }
}