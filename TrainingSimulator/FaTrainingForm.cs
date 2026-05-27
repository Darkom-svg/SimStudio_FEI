using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEI.FiniteAutomaton;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Dialogs;
using FEI.SimStudio.Components.Registers;
using FEI.TuringCore.Simulation;
using AboutForm = FEI.TrainingSimulator.Dialogs.AboutForm;
using System.Text.RegularExpressions;
using System.Xml;
using FEI.FiniteAutomaton.Dialogs;
using FEI.FiniteAutomaton.IO.Jff;
using FEI.TrainingSimulator.Properties;

namespace FEI.TrainingSimulator
{
    public partial class FaTrainingForm : Form
    {
        private MainTrainingForm.TaskDef task;
        private string appTitle;
        private VirtualTuringMachine turingMachine = new VirtualTuringMachine() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };
        private bool codeChanged;        
        //Formát prechodovej funkcie
        private string transitionFormat;
        //Formát 
        string wildCardFormat;
        // Vytvorí formálnu špecifikáciu
        private string tmpFormalSpecFileName = null;
        // Vytvorí špecifikáciu zadania
        private string tmpTaskSpecFileName = null;
        string openFileName = null;
        private List<ToolStripMenuItem> miTFormatMenuItems;

        public FaTrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            this.task = task;
            appTitle = "Trenažér (" + this.task.Id + ")";
            transitionFormat = "\\sδ\\s(\\a,\\a)\\s=\\s(\\a)\\s";
            wildCardFormat = "\\a=\\s{\\m,\\n}\\s";
            this.Text = "FA";
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
            dlg.tm = this.TuringMachine;
            dlg.tFunction = defTf;
            dlg.ShowDialog(this);
            if (dlg.okPressed)
            {
                Transition tf = dlg.tFunction;
                txtCode.Text += Environment.NewLine;
                txtCode.Text += WriteTransition(tf, transitionFormat);
                if (tf.Comment.Trim() != "") txtCode.Text += " //" + tf.Comment;
                txtCode.Text += Environment.NewLine;
                ParseTFunctions(txtCode.Text);
            }
        }

        private string WriteTransition(Transition tf, string tFormat)
        {
            string res="";
            int pos=0;
            int i = 0, l = 0;
            int n = 0; //Index vstupu
            string arg="";

            String step = "";
            switch (tf.Step)
            {
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

            tFormat=tFormat.Replace("\\s", " ");
            
            while(true) {
                i = tFormat.IndexOf("\\a", l);
                if (i == -1)
                {
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
            FiniteAutomatonParser parser = new FiniteAutomatonParser(TuringMachine, transitionFormat, wildCardFormat);
            bool retval = parser.ParseTFunctions(sourceCodeText);

            codeChanged = false;
            UpdateErrors(parser.Errors);
            Functions_SetScrollbar();

            TuringMachine.StateDiagram.UpdateForFA(TuringMachine);

            return retval;
        }
        
        private void UpdateErrors(List<TMError> errors)
        {
            lstErrors.Items.Clear();
           
            // Zobrazenie chýb
            if (errors.Count > 0)
            {                
                lstErrors.Items.AddRange(errors.ToArray());
                splitContainer1.Panel2Collapsed = false;
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
                var max = TuringMachine.FunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
                if (max < 0)
                    max = 0;

                sbyTests.Maximum = max;
                sbyTests.SmallChange = 1;
                sbyTests.LargeChange = (int)Math.Floor((double)pTests.Height / 20);
                sbyTests.Visible = true;
                sbyTests.Refresh();
            }
        }
        private void UpdateStateDiagram()
        {
            //Načíta prechodové funkcie z kódu
            ParseTFunctions(txtCode.Text);
            TuringMachine.StateDiagram.UpdateForFA(TuringMachine);
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
            else if (tcMain.SelectedTab == taskSpecificationTab)
            {
                //Vytvorí formálnu špecifikáciu
                CreateTaskSpecification();
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
                sb.AppendLine("<title>Formálna špecifikácia</title>");
                
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
                sb.AppendLine(Resources.FinalAutomaton+" <strong>A = (K, Σ, " + TuringMachine.StartState + ", δ, F)</strong>");
                sb.AppendLine("</div>");

                // Množina stavov
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>K</strong> = {" + TuringMachine.GetUsedStatesAsString() + "}");
                sb.AppendLine("</div>");
                // Vstupná abeceda
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>Σ</strong> = {" + TuringMachine.GetUsedSymbolsAsString() + "}");
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
                foreach (Transition f in TuringMachine.GetTFunctions())
                {
                    sb.AppendLine("<div>");
                    sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol + 
                                  ") = " + f.NewState);
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");                
                
                sb.AppendLine("</body>");
            
            sb.AppendLine("</html>");

            TextWriter tw = new StreamWriter(
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
                sb.AppendLine("<strong>" + Resources.TaskType + "</strong> " + Resources.FinalAutomaton);
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

            TextWriter tw = new System.IO.StreamWriter(
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
        
        private void miSettings_Click(object sender, EventArgs e)
        {             
            SettingsForm frm = new SettingsForm();
            frm.initialState = TuringMachine.StartState;
            frm.finalStates = new List<string>(TuringMachine.FinalStates);
            frm.ShowDialog(this);
            if (frm.okPressed)
            {
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
                if (!fileName.EndsWith(".fa")) fileName += ".fa";
                TuringMachine.Save(fileName, txtCode.Text);
                
                openFileName = fileName;
                this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + appTitle;
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
        
        private sealed class FaCheckResult
        {
            public bool IsCorrect { get; set; }
            public string Message { get; set; } = "";
        }

        private void checkToolStripButton_Click(object sender, EventArgs e)
        {
            FaCheckResult result;

            if (task.Mode.Equals("Formula"))
            {
                result = ValidateFaSolution_Formula();
            }
            else if (task.Mode.Equals("Regex"))
            {
                result = ValidateFaSolution_Regex();
            }
            else if (task.Mode.Equals("Reference_model"))
            {
                result = ValidateFaSolution_ReferenceModel();
            }
            else if (task.Mode.Equals("Test_cases"))
            {
                result = ValidateFaSolution_TestCases();
            }
            else
            {
                result = new FaCheckResult
                {
                    IsCorrect = false,
                    Message = string.Format(Resources.UnknownModeError, task.Mode)
                };
            }

            if (result.IsCorrect)
            {
                MessageBox.Show(
                    Resources.Correct,
                    appTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    result.Message,
                    appTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        
        private FaCheckResult ValidateFaSolution(List<char> alphabet)
        {
            bool parsed = ParseTFunctions(txtCode.Text);

            if (!parsed)
            {
                return new FaCheckResult
                {
                    IsCorrect = false,
                    Message = Resources.TransitionSyntaxError
                };
            }

            string formalError = null;

            if (!task.Mode.Equals("Test_cases", StringComparison.OrdinalIgnoreCase))
            {
                formalError = ValidateDeterministicFa(alphabet);
            }

            if (formalError != null)
            {
                return new FaCheckResult
                {
                    IsCorrect = false,
                    Message = formalError
                };
            }

            ParsedFormula formula = null;
            Regex regex = null;
            VirtualTuringMachine reference = null;
            Dictionary<string, bool> testCases = null;
            
            switch (task.Mode)
            {
                case "Formula":
                    formula = ParseFormula(task.Verification);
                    break;

                case "Regex":
                    regex = new Regex("^(" + task.Verification + ")$");
                    break;

                case "Reference_model":
                    reference = CreateReferenceFa();
                    break;
                
                case "Test_cases":
                    testCases = ParseTestCases(task.Verification);
                    break;

                default:
                    return new FaCheckResult
                    {
                        IsCorrect = false,
                        Message = string.Format(Resources.UnknownModeError, task.Mode)
                    };
            }

            testedWords.Clear();
            testedStates.Clear();
            Tests_SetScrollbar();
            pTests.Refresh();

            string[] words;

            if (task.Mode.Equals("Test_cases", StringComparison.OrdinalIgnoreCase))
            {
                words = testCases.Keys.ToArray();
            }
            else
            {
                words = GenerateWords(10, alphabet);
            }

            foreach (string word in words)
            {
                bool expected = false;

                switch (task.Mode)
                {
                    case "Formula":
                        expected = AcceptsByFormula(word, formula);
                        break;

                    case "Regex":
                        expected = regex.IsMatch(word);
                        break;

                    case "Reference_model":
                        expected = AcceptsByAutomaton(reference, word);
                        break;
                    case "Test_cases":
                        expected = testCases[word];
                        break;
                    
                }

                bool actual = AcceptsByAutomaton(TuringMachine, word);

                AddTestResult(word, expected, actual);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new FaCheckResult
                    {
                        IsCorrect = false,
                        Message =string.Format(
                            Resources.AutomatonMismatchError,
                            shownWord,
                            expected,
                            actual)
                    };
                }
            }

            return new FaCheckResult
            {
                IsCorrect = true,
                Message = Resources.Correct
            };
        }
        
        private FaCheckResult ValidateFaSolution_Formula()
        {
            ParsedFormula formula = ParseFormula(task.Verification);
            List<char> alphabet = new List<char>(formula.Coefficients.Keys);

            return ValidateFaSolution(alphabet);
        }
        
        private FaCheckResult ValidateFaSolution_Regex()
        {
            return ValidateFaSolution(ExtractAlphabetFromRegex(task.Verification));
        }
        
        private FaCheckResult ValidateFaSolution_ReferenceModel()
        {
            VirtualTuringMachine reference = CreateReferenceFa();
            return ValidateFaSolution(GetAlphabetFromFa(reference));
        }
        
        private FaCheckResult ValidateFaSolution_TestCases()
        {
            return ValidateFaSolution(new List<char>());
        }
        
        private VirtualTuringMachine CreateReferenceFa()
        {
            if (string.IsNullOrWhiteSpace(task.Verification))
                throw new Exception(Resources.MissingReferenceModel);

            string tmpFile = Path.Combine(
                Path.GetTempPath(),
                "reference_fa_" + Guid.NewGuid().ToString("N") + ".fa");

            try
            {
                File.WriteAllText(tmpFile, task.Verification, Encoding.UTF8);

                var fa = new VirtualTuringMachine
                {
                    AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
                };

                string code = fa.Load(tmpFile);

                var parser = new FiniteAutomatonParser(
                    fa,
                    transitionFormat,
                    wildCardFormat);

                if (!parser.ParseTFunctions(code))
                    throw new Exception(Resources.ReferenceModelSyntaxError);

                fa.StateDiagram.UpdateForFA(fa);

                return fa;
            }
            finally
            {
                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);
            }
        }
        
        private string ValidateDeterministicFa(IEnumerable<char> alphabet)
        {
            var usedStates = TuringMachine.GetUsedStates();

            if (usedStates == null || usedStates.Length == 0)
                return "Automat neobsahuje žiadne stavy.";

            if (string.IsNullOrWhiteSpace(TuringMachine.StartState))
                return "Automat nemá začiatočný stav.";

            bool hasFinal = false;

            foreach (var state in usedStates)
            {
                if (TuringMachine.IsFinalState(state))
                {
                    hasFinal = true;
                    break;
                }
            }

            if (!hasFinal)
                return "Automat nemá žiadny koncový stav.";

            var seen = new HashSet<string>();
            var allowedSymbols = new HashSet<char>(alphabet);

            for (int i = 0; i < TuringMachine.FunctionCount; i++)
            {
                var tf = TuringMachine.Function(i);

                if (string.IsNullOrEmpty(tf.ReadSymbol) || tf.ReadSymbol.Length != 1)
                    return $"Automat používa neplatný symbol '{tf.ReadSymbol}'.";

                char symbol = tf.ReadSymbol[0];

                if (!allowedSymbols.Contains(symbol))
                    return $"Automat používa nepovolený symbol '{tf.ReadSymbol}'.";

                string key = tf.CurrentState + "|" + tf.ReadSymbol;

                if (!seen.Add(key))
                    return $"Automat nie je deterministický. Zo stavu '{tf.CurrentState}' existuje viac prechodov pre symbol '{tf.ReadSymbol}'.";
            }

            return null;
        }
        
        private sealed class ParsedFormula
        {
            public Dictionary<char, int> Coefficients { get; } = new Dictionary<char, int>();
            public int Modulo { get; set; }
            public int Offset { get; set; }
        }
        
        private ParsedFormula ParseFormula(string formulaText)
        {
            var parts = formulaText.Split('=');
            string left = parts[0];
            string right = parts[1];

            var result = new ParsedFormula();

            int i = 0;
            while (i < left.Length)
            {
                int sign = 1;

                if (left[i] == '+')
                {
                    i++;
                }
                else if (left[i] == '-')
                {
                    sign = -1;
                    i++;
                }

                int start = i;
                while (i < left.Length && char.IsDigit(left[i]))
                    i++;

                int coefficient = (start == i)
                    ? 1
                    : int.Parse(left.Substring(start, i - start));

                i++; 

                char symbol = left[i];
                i++;

                if (result.Coefficients.ContainsKey(symbol))
                    result.Coefficients[symbol] += sign * coefficient;
                else
                    result.Coefficients[symbol] = sign * coefficient;
            }

            int nPos = right.IndexOf('n');

            result.Modulo = int.Parse(right.Substring(0, nPos));

            if (nPos == right.Length - 1)
            {
                result.Offset = 0;
            }
            else
            {
                string offsetText = right.Substring(nPos + 1);

                if (offsetText.StartsWith("+"))
                    offsetText = offsetText.Substring(1);

                result.Offset = int.Parse(offsetText);
            }

            return result;
        }
        
        private List<char> ExtractAlphabetFromRegex(string regexPattern)
        {
            var alphabet = new HashSet<char>();

            for (int i = 0; i < regexPattern.Length; i++)
            {
                char ch = regexPattern[i];

                if (ch == '[')
                {
                    int end = regexPattern.IndexOf(']', i);

                    if (end == -1)
                        throw new Exception("Regex obsahuje neuzavretú množinu [].");

                    string content = regexPattern.Substring(i + 1, end - i - 1);

                    for (int j = 0; j < content.Length; j++)
                    {
                        if (j + 2 < content.Length && content[j + 1] == '-')
                        {
                            char from = content[j];
                            char to = content[j + 2];

                            for (char c = from; c <= to; c++)
                            {
                                alphabet.Add(c);
                            }

                            j += 2;
                        }
                        else
                        {
                            if (char.IsLetterOrDigit(content[j]))
                            {
                                alphabet.Add(content[j]);
                            }
                        }
                    }

                    i = end;
                    continue;
                }

                if (ch == '\\' && i + 1 < regexPattern.Length)
                {
                    char escaped = regexPattern[i + 1];

                    if (escaped == 'd')
                    {
                        for (char c = '0'; c <= '9'; c++)
                            alphabet.Add(c);
                    }
                    else if (escaped == 'w')
                    {
                        for (char c = 'a'; c <= 'z'; c++)
                            alphabet.Add(c);

                        for (char c = 'A'; c <= 'Z'; c++)
                            alphabet.Add(c);

                        for (char c = '0'; c <= '9'; c++)
                            alphabet.Add(c);

                        alphabet.Add('_');
                    }
                    else
                    {
                        alphabet.Add(escaped);
                    }

                    i++;
                    continue;
                }

                if (char.IsLetterOrDigit(ch))
                {
                    alphabet.Add(ch);
                }
            }

            if (alphabet.Count == 0)
            {
                throw new Exception("Regex neobsahuje žiadne symboly abecedy.");
            }

            return alphabet.OrderBy(c => c).ToList();
        }
        
        private Dictionary<string, bool> ParseTestCases(string verification)
        {
            if (string.IsNullOrWhiteSpace(verification))
                throw new Exception("Pole verification je prázdne.");

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(verification);

            XmlNodeList nodes = doc.SelectNodes("//test");

            if (nodes == null || nodes.Count == 0)
                throw new Exception("Neboli nájdené žiadne testovacie prípady.");

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
                    throw new Exception("Neplatná očakávaná hodnota pri slove '" + word + "'.");

                result[word] = expected;
            }

            return result;
        }
        
        private List<char> GetAlphabetFromFa(VirtualTuringMachine fa)
        {
            var alphabet = new HashSet<char>();

            for (int i = 0; i < fa.FunctionCount; i++)
            {
                var tf = fa.Function(i);

                if (!string.IsNullOrEmpty(tf.ReadSymbol) && tf.ReadSymbol.Length == 1)
                    alphabet.Add(tf.ReadSymbol[0]);
            }

            return alphabet.OrderBy(c => c).ToList();
        }
        
        private bool AcceptsByFormula(string word, ParsedFormula formula)
        {
            var counts = new Dictionary<char, int>();

            foreach (char symbol in formula.Coefficients.Keys)
                counts[symbol] = 0;

            foreach (char ch in word)
            {
                if (!counts.ContainsKey(ch))
                    return false;

                counts[ch]++;
            }

            int lhs = 0;

            foreach (var pair in formula.Coefficients)
            {
                lhs += pair.Value * counts[pair.Key];
            }

            return (lhs - formula.Offset) % formula.Modulo == 0;
        }
        
        private bool AcceptsByAutomaton(VirtualTuringMachine fa, string word)
        {
            string currentState = fa.StartState;

            foreach (char ch in word)
            {
                string symbol = ch.ToString();
                string nextState = null;

                for (int i = 0; i < fa.FunctionCount; i++)
                {
                    var tf = fa.Function(i);

                    if (tf.CurrentState == currentState && tf.ReadSymbol == symbol)
                    {
                        nextState = tf.NewState;
                        break;
                    }
                }

                if (nextState == null)
                    return false;

                currentState = nextState;
            }

            return fa.IsFinalState(currentState);
        }
        
        private string[] GenerateWords(int maxLength, List<char> alphabet)
        {
            var result = new List<string>();
            GenerateWordsRecursive("", maxLength, result, alphabet);
            return result.ToArray();
        }

        private void GenerateWordsRecursive(string current, int remaining, List<string> result, List<char> alphabet)
        {
            result.Add(current);

            if (remaining == 0)
                return;

            foreach (char symbol in alphabet)
            {
                GenerateWordsRecursive(current + symbol, remaining - 1, result, alphabet);
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
            this.Text = System.IO.Path.GetFileName(fileName) + " - " + appTitle;

            if (fileName.EndsWith(".fa"))
            {
                TuringMachine = new VirtualTuringMachine() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead }; 
                txtCode.Text = TuringMachine.Load(fileName);
                ParseTFunctions(txtCode.Text);
                
                openFileName = fileName;
                this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + appTitle;
            }
            else if (fileName.EndsWith(".jff"))
            {
                JffReader reader = new JffReader(fileName);
                TuringMachine = reader.Read();
                if (TuringMachine == null)
                {
                    TuringMachine = new VirtualTuringMachine();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var tf in TuringMachine.GetTFunctions())
                    {
                        sb.AppendLine(WriteTransition(tf, transitionFormat));
                    }
                    txtCode.Text = sb.ToString();
                }
            }                       
            this.Refresh();            
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
            {
                testedStates.Add(Resources.Error);
            }
            else if (expected)
            {
                testedStates.Add(Resources.Accept);
            }
            else
            {
                testedStates.Add(Resources.Reject);
            }

            Tests_SetScrollbar();
            pTests.Refresh();
        }

        private void miTFormat1_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\sf\\s(\\a,\\a)\\s=\\s(\\a)\\s");
        }

        private void miTFormat2_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a)\\s=\\s(\\a)\\s");
        }

        private void miTFormat3_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a,\\a");
        }

        private void miTFormat4_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s[\\a,\\a]\\s[\\a]\\s");
        }

        private void miTFormat5_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a)\\s(\\a)\\s");
        }

        private void miTFormat6_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s[\\a,\\a]\\s->\\s[\\a]\\s");
        }

        private void miTFormat7_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a)\\s->\\s(\\a)\\s");
        }

        private void miTFormat8_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a->\\a");
        }

        private void miTFormat9_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a>\\a");
        }

        private void miTFormat10_Click(object sender, EventArgs e)
        {            
            SetTFormat(sender, "\\sδ\\s(\\a,\\a)\\s=\\s(\\a)\\s");
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
            Properties.Settings.Default.TransitionFormatFa =
                miTFormatMenuItems.IndexOf(item);

            Properties.Settings.Default.Save();
        }
    }
}