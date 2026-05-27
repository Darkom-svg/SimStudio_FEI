using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FEI.PushdownAutomaton;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Controls;
using FEI.SimStudio.Components.Dialogs;
using FEI.SimStudio.Components.Registers;
using FEI.TuringCore.Simulation;
using AboutForm = FEI.TrainingSimulator.Dialogs.AboutForm;
using System.Xml;
using FEI.PushdownAutomaton.Dialogs;
using FEI.PushdownAutomaton.IO.Jff;

namespace FEI.TrainingSimulator
{
    public partial class PdaTrainingForm : Form
    {
        private MainTrainingForm.TaskDef task;
        private string appTitle;

        private bool codeChanged;        
        //Formát prechodovej funkcie
        private string transitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
        //Formát 
        private string wildCardFormat = "\\a=\\s{\\m,\\n}\\s"; 
        // Vytvorí formálnu špecifikáciu
        private string tmpFormalSpecFileName;
        // Vytvorí špecifikáciu zadania
        private string tmpTaskSpecFileName;
        private string openFileName;
        private PushdownAutomaton.PushdownAutomaton pushdownAutomaton = new PushdownAutomaton.PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };
        private List<ToolStripMenuItem> miTFormatMenuItems;

        public PdaTrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            this.task = task;
            this.Text = "Trenažér (" + this.task.Id + ")";
            appTitle = "Trenažér (" + this.task.Id + ")";
            CreateTaskSpecification();
            miTFormatMenuItems = new List<ToolStripMenuItem>(new[]
            {
                miTFormat1, miTFormat2, miTFormat3,
                miTFormat4, miTFormat5, miTFormat6,
                miTFormat7, miTFormat8, miTFormat9,
                miTFormat10
            });
            int index =	Properties.Settings.Default.TransitionFormatPda;
            miTFormatMenuItems[index].PerformClick();
        }

        private PushdownAutomaton.PushdownAutomaton PushdownAutomaton
        {
            get => pushdownAutomaton;
            set
            {                
                pushdownAutomaton = value;
                stateDiagramControl.TuringMachine = pushdownAutomaton;
            }
        } 
        
        private void frmTuringMachine_Load(object sender, System.EventArgs e)
        {
            if (MdiParent != null) menuStrip1.Visible = false;
            this.Icon = ((System.Drawing.Icon)(new System.ComponentModel.ComponentResourceManager(this.GetType()).GetObject("$this.Icon"))); 

            stateDiagramControl.TuringMachine = PushdownAutomaton;
			
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
            dlg.tm = this.PushdownAutomaton;
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

            //String step = "";
            //switch (tf.Step)
            //{
            //    case Transition.Steps.Left:
            //        step = "L";
            //        break;
            //    case Transition.Steps.Right:
            //        step = "R";
            //        break;
            //    case Transition.Steps.NoMove:
            //        step = "0";
            //        break;
            //}

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
                else if (n == 2) arg = tf.StackRead;
                else if (n == 3) arg = tf.NewState;                
                else if (n == 4) arg = tf.StackWrite;

                res += tFormat.Substring(l, i - l) + arg;

                l = i + 2;
                n++;

            }            

            return res;
        }        
        
        private bool ParseTFunctions(string sourceCodeText)
        {
            PushdownAutomatonParser parser = new PushdownAutomatonParser(PushdownAutomaton, transitionFormat, wildCardFormat);
            bool retval = parser.ParseTFunctions(sourceCodeText);

            codeChanged = false;
            UpdateErrors(parser.Errors);
            Functions_SetScrollbar();

            PushdownAutomaton.StateDiagram.UpdateForPA(PushdownAutomaton);

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
                var max = PushdownAutomaton.FunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
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

            PushdownAutomaton.StateDiagram.UpdateForPA(PushdownAutomaton);
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
				sb.AppendLine("<h1>Formálna špecifikácia</h1>");

				sb.AppendLine("<div>");
				sb.AppendLine("Zásobníkový automat <strong>ZA = (K, Σ, Γ, δ, " + PushdownAutomaton.StartState + ", Z, F)</strong>");
				sb.AppendLine("</div>");

				// Množina stavov
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>K</strong> = {" + PushdownAutomaton.GetUsedStatesAsString() + "}");
				sb.AppendLine("</div>");
				// Vstupná abeceda
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Σ</strong> = {" + PushdownAutomaton.GetUsedSymbolsAsString() + "}");
				sb.AppendLine("</div>");
				// Zásobniková abeceda
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Γ</strong> = {" + PushdownAutomaton.GetUsedStackSymbolsAsString() + "}");
				sb.AppendLine("</div>");
				// Počiatočný stav
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>" + PushdownAutomaton.StartState + "</strong> - počiatočný stav");
				sb.AppendLine("</div>");
				// Symbol na dne zasobnika
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>Z</strong> - symbol na dne zásobníka");
				sb.AppendLine("</div>");            
				// Množina koncových stavov
				sb.AppendLine("<div>");
				sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", PushdownAutomaton.FinalStates.ToArray()) + "}");
				sb.AppendLine("</div>");

				// Prechodové funkcie
				sb.AppendLine("<div>");
				sb.AppendLine("<h2>Prechodová funkcia δ</h2>");
				foreach (Transition f in PushdownAutomaton.GetTFunctions())
				{
					sb.AppendLine("<div>");
					sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol + ", " + f.StackRead + 
						") = (" + f.NewState + ", "  + f.StackWrite + ")");
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
                sb.AppendLine("<h2>Parametre zadania</h2>");
                // Typ zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>Typ zadania:</strong> Zásobníkový automat");
                sb.AppendLine("</div>");

                // ID zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>Id zadania:</strong> " + task.Id);
                sb.AppendLine("</div>");
                // Obtiažnosť zadania
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>Obtiažnosť zadania:</strong> " + task.Difficulty);
                sb.AppendLine("</div>");           
                
                // Popis zadania
                sb.AppendLine("<h2>Popis zadania</h2>");
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
        
        private void miSettings_Click(object sender, EventArgs e)
        {             
            SettingsForm frm = new SettingsForm();
            frm.initialState = PushdownAutomaton.StartState;
            frm.finalStates = new List<string>(PushdownAutomaton.FinalStates);
            frm.ShowDialog(this);
            if (frm.okPressed)
            {
                PushdownAutomaton.StartState = frm.initialState;
                PushdownAutomaton.FinalStates = frm.finalStates;
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
                if (!fileName.EndsWith(".pa")) fileName += ".pa";
                PushdownAutomaton.Save(fileName, txtCode.Text);
				
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
                JffWriter writer = new JffWriter(pushdownAutomaton, fileName);
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
            if (fileName.EndsWith(".pa"))
            {
                PushdownAutomaton = new PushdownAutomaton.PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead }; 
                txtCode.Text = PushdownAutomaton.Load(fileName);
                ParseTFunctions(txtCode.Text);
				
                openFileName = fileName;
                this.Text = openFileName.Substring(openFileName.LastIndexOf("\\") + 1) + " - " + appTitle;
            }
            else if (fileName.EndsWith(".jff"))
            {
                JffReader reader = new JffReader(fileName);
                PushdownAutomaton = reader.Read();
                if (PushdownAutomaton == null)
                {
                    PushdownAutomaton = new PushdownAutomaton.PushdownAutomaton();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var tf in PushdownAutomaton.GetTFunctions())
                    {
                        sb.AppendLine(WriteTransition(tf, transitionFormat));
                    }
                    txtCode.Text = sb.ToString();
                }
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
            CheckResult result = CheckCurrentPdaSolution();

            if (result.IsCorrect)
            {
                MessageBox.Show(
                    "Riešenie je správne.",
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
        
        private PushdownAutomaton.PushdownAutomaton CreateReferencePda()
        {
            if (string.IsNullOrWhiteSpace(task.Verification))
                throw new Exception("Zadanie neobsahuje referenčný model.");

            string tmpFile = Path.Combine(
                Path.GetTempPath(),
                "reference_pda_" + Guid.NewGuid().ToString("N") + ".pa");

            try
            {
                File.WriteAllText(tmpFile, task.Verification, Encoding.UTF8);

                var pda = new PushdownAutomaton.PushdownAutomaton
                {
                    AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
                };

                string code = pda.Load(tmpFile);

                var parser = new PushdownAutomatonParser(pda, transitionFormat, wildCardFormat);

                if (!parser.ParseTFunctions(code))
                    throw new Exception("Referenčný model obsahuje syntaktické chyby.");

                pda.StateDiagram.UpdateForPA(pda);

                return pda;
            }
            finally
            {
                if (File.Exists(tmpFile))
                    File.Delete(tmpFile);
            }
        }
        
        private PushdownAutomaton.PushdownAutomaton CreateStudentPda()
        {
            var pda = new PushdownAutomaton.PushdownAutomaton
            {
                AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead
            };

            var parser = new PushdownAutomatonParser(pda, transitionFormat, wildCardFormat);

            if (!parser.ParseTFunctions(txtCode.Text))
                throw new Exception("Riešenie obsahuje syntaktické chyby.");

            pda.StartState = PushdownAutomaton.StartState;
            pda.FinalStates = new List<string>(PushdownAutomaton.FinalStates);

            pda.StateDiagram.UpdateForPA(pda);

            return pda;
        }
        
        private List<string> GetInputAlphabet(PushdownAutomaton.PushdownAutomaton pda)
        {
            var alphabet = new HashSet<string>();

            for (int i = 0; i < pda.FunctionCount; i++)
            {
                string symbol = pda.Function(i).ReadSymbol;

                if (!string.IsNullOrEmpty(symbol) && symbol != "Blank")
                    alphabet.Add(symbol);
            }

            return alphabet.OrderBy(x => x).ToList();
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
        
        private bool AcceptsByPda(
            PushdownAutomaton.PushdownAutomaton pda,
            string word)
        {
            pda.Reset();
            pda.WriteLog = false;
            pda.Log.Clear();
            pda.RemoveAllThreads();

            pda.OriginalTapes = new List<InfiniteTape>();

            InfiniteTape tape = new InfiniteTape();

            for (int i = 0; i < word.Length; i++)
            {
                tape.SetCell(i, word[i].ToString());
            }

            tape.HeadPosition = 0;

            pda.OriginalTapes.Add(tape);
            pda.ActiveTapes = InfiniteTape.DeepCopyTapes(pda.OriginalTapes);
            pda.CurrentState = pda.StartState;

            int maxSteps = 200;

            for (int step = 0; step < maxSteps; step++)
            {
                if (pda.IsAccepted())
                    return true;

                pda.NextStep(false);

                pda.Log.Clear();

                if (pda.IsAccepted())
                    return true;

                if (pda.NoNextStep)
                    return false;
            }

            return false;
        }
        
        private CheckResult CheckCurrentPdaSolution()
        {
            if (task.Mode.Equals("Test_cases", StringComparison.OrdinalIgnoreCase))
                return CheckPdaByTestCases();

            if (task.Mode.Equals("Reference_model", StringComparison.OrdinalIgnoreCase))
                return CheckPdaByReferenceModel();

            return new CheckResult
            {
                IsCorrect = false,
                Message = "Neznámy režim overovania: " + task.Mode
            };
        }
        
        private CheckResult CheckPdaByReferenceModel()
        {
            if (string.IsNullOrWhiteSpace(task.Verification))
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Zadanie neobsahuje referenčný model."
                };
            }

            PushdownAutomaton.PushdownAutomaton referenceForAlphabet;

            try
            {
                referenceForAlphabet = CreateReferencePda();
            }
            catch (Exception ex)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Nepodarilo sa pripraviť referenčný model: " + ex.Message
                };
            }

            List<string> alphabet = GetInputAlphabet(referenceForAlphabet);

            if (alphabet.Count == 0)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Referenčný model nemá vstupnú abecedu."
                };
            }

            List<string> words = GenerateWords(6, alphabet);

            testedWords.Clear();
            testedStates.Clear();
            Tests_SetScrollbar();
            pTests.Refresh();

            foreach (string word in words)
            {
                PushdownAutomaton.PushdownAutomaton reference;
                PushdownAutomaton.PushdownAutomaton student;

                try
                {
                    reference = CreateReferencePda();
                    student = CreateStudentPda();
                }
                catch (Exception ex)
                {
                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message = ex.Message
                    };
                }

                bool expected = AcceptsByPda(reference, word);
                bool actual = AcceptsByPda(student, word);

                AddTestResult(word, expected, actual);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message =
                            $"Automat nie je správny. Líši sa na slove '{shownWord}'.\n" +
                            $"Referenčný model: {(expected ? "prijať" : "odmietnuť")}.\n" +
                            $"Študentov PA: {(actual ? "prijať" : "odmietnuť")}."
                    };
                }
            }

            return new CheckResult
            {
                IsCorrect = true,
                Message = "Riešenie je správne."
            };
        }
        
        private CheckResult CheckPdaByTestCases()
        {
            Dictionary<string, bool> testCases;

            try
            {
                testCases = ParseTestCases(task.Verification);
            }
            catch (Exception ex)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Zadanie obsahuje neplatné testovacie prípady: " + ex.Message
                };
            }

            testedWords.Clear();
            testedStates.Clear();
            Tests_SetScrollbar();
            pTests.Refresh();

            foreach (var testCase in testCases)
            {
                PushdownAutomaton.PushdownAutomaton student;

                try
                {
                    student = CreateStudentPda();
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
                bool actual = AcceptsByPda(student, word);

                AddTestResult(word, expected, actual);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message =
                            $"Automat nie je správny. Líši sa na slove '{shownWord}'.\n" +
                            $"Očakávané: {(expected ? "prijať" : "odmietnuť")}.\n" +
                            $"Študentov PA: {(actual ? "prijať" : "odmietnuť")}."
                    };
                }
            }

            return new CheckResult
            {
                IsCorrect = true,
                Message = "Riešenie je správne."
            };
        }
        
        private void miTFormat1_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\sf\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s");
        }

        private void miTFormat2_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s");
        }

        private void miTFormat3_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a,\\a,\\a,\\a");
        }

        private void miTFormat4_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s[\\a,\\a,\\a]\\s[\\a,\\a]\\s");
        }

        private void miTFormat5_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a,\\a)\\s(\\a,\\a)\\s");
        }

        private void miTFormat6_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s[\\a,\\a,\\a]\\s->\\s[\\a,\\a]\\s");
        }

        private void miTFormat7_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\s(\\a,\\a,\\a)\\s->\\s(\\a,\\a)\\s");
        }

        private void miTFormat8_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a,\\a->\\a,\\a");
        }

        private void miTFormat9_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\a,\\a,\\a>\\a,\\a");
        }

        private void miTFormat10_Click(object sender, EventArgs e)
        {
            SetTFormat(sender, "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s");
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
            Properties.Settings.Default.TransitionFormatPda =
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
                testedStates.Add("Chyba");
            else if (expected)
                testedStates.Add("Prijať");
            else
                testedStates.Add("Odmietnuť");

            Tests_SetScrollbar();
            pTests.Refresh();
        }
    }
}