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
using System.Text.RegularExpressions;
using FEI.PushdownAutomaton.Dialogs;
using FEI.PushdownAutomaton.IO.Jff;

namespace FEI.TrainingSimulator
{
    public partial class PdaTrainingForm : Form
    {
        private MainTrainingForm.TaskDef task;
        private string appTitle;
       
        bool codeChanged = false;        
        //Formát prechodovej funkcie
        string TransitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
        //Formát 
        string WildCardFormat = "\\a=\\s{\\m,\\n}\\s"; 
        // Vytvorí formálnu špecifikáciu
        private string tmpFormalSpecFileName = null;
        // Vytvorí špecifikáciu zadania
        private string tmpTaskSpecFileName = null;
        string openFileName = null;
        private PushdownAutomaton.PushdownAutomaton pushdownAutomaton = new PushdownAutomaton.PushdownAutomaton() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };

        public PdaTrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            this.task = task;
            this.Text = "Trenažér (" + this.task.Id + ")";
            appTitle = "Trenažér (" + this.task.Id + ")";
            CreateTaskSpecification();
        }
        
        //Zdržanie pri vykonávaní programu
        int delay = 10;

        //Vlákno stroja        
        System.Threading.Thread thRealTime;

        System.Timers.Timer timMachine = new System.Timers.Timer();
        bool pause = false;
        bool prgStop = true;
        bool prgReset = true; //Resetovať stroj pri najbližšom štarte

        AcceptanceStatus tapeAcceptance = AcceptanceStatus.None;

        public bool PrgStop {
            get => prgStop;
            set {
                prgStop = value;
                if (prgStop) {
                    //UpdateTapeSettings();
                    //ToDo
                }
            }
        }

        public bool PrgReset { get; set; } = true;

        public PushdownAutomaton.PushdownAutomaton PushdownAutomaton
        {
            get { return pushdownAutomaton; }
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
            //Todo
            //cmbTape.SelectedIndex = 0;            
            //infiniteTapeControl.Tapes = TuringMachine.OriginalTapes;

            //AddSpeedPanel();
        }

        // private void AddSpeedPanel()
        // {
        //     ToolStripControlHost host = new ToolStripControlHost(speedPanel);
        //     host.Alignment = ToolStripItemAlignment.Right;
        //     host.Width = 200;
        //     host.AutoSize = false;
        //     mainToolStrip.Items.Add(host);
        // }
        
        
        
        private void bAddTFunction_Click(object sender, EventArgs e)
        {
            AddTransition(new Transition());
        }     
        
        private void AddTransition(Transition def_tf)
        {             
            AddTFunctionForm dlg = new AddTFunctionForm();
            dlg.TM = this.PushdownAutomaton;
            dlg.tfunction = def_tf;
            dlg.ShowDialog(this);
            if (dlg.OKPressed)
            {
                Transition tf = dlg.tfunction;
                txtCode.Text += Environment.NewLine;
                txtCode.Text += WriteTransition(tf, TransitionFormat);
                if (tf.Comment.Trim() != "") txtCode.Text += " //" + tf.Comment;
                txtCode.Text += Environment.NewLine;
                ParseTFunctions(txtCode.Text);
            }
        }

        private string WriteTransition(Transition tf, string transitionFormat)
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

            transitionFormat=transitionFormat.Replace("\\s", " ");
			
            while(true) {
                i = transitionFormat.IndexOf("\\a", l);
                if (i == -1)
                {
                    res += transitionFormat.Substring(l);
                    break;
                }

                if (n == 0) arg = tf.CurrentState;
                else if (n == 1) arg = tf.ReadSymbol;
                else if (n == 2) arg = tf.StackRead;
                else if (n == 3) arg = tf.NewState;                
                else if (n == 4) arg = tf.StackWrite;

                res += transitionFormat.Substring(l, i - l) + arg;

                l = i + 2;
                n++;

            }            

            return res;
        }        
        
        private bool ParseTFunctions(string sourceCodeText)
        {
            PushdownAutomatonParser parser = new PushdownAutomatonParser(PushdownAutomaton, TransitionFormat, WildCardFormat);
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
                int max;
                max = PushdownAutomaton.TFunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
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
			if (tcMain.SelectedTab == logTab)
			{
				//Log_SetScrollbars();
			}
			else if (tcMain.SelectedTab == statesTab)
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
            if (frm.OKPressed)
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
                        sb.AppendLine(WriteTransition(tf, TransitionFormat));
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
        
        private CheckResult CheckCurrentPdaSolution()
        {
            bool parsed = ParseTFunctions(txtCode.Text);

            if (!parsed)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Riešenie obsahuje syntaktické chyby v prechodových funkciách."
                };
            }

            if (string.IsNullOrWhiteSpace(task.Formula))
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Zadanie neobsahuje regulárny výraz v poli formula."
                };
            }

            List<char> alphabet;

            try
            {
                alphabet = ExtractAlphabetFromRegex(task.Formula);
            }
            catch (Exception ex)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Nepodarilo sa určiť abecedu zo zadania: " + ex.Message
                };
            }

            string structuralError = ValidatePdaStructure(alphabet);

            if (structuralError != null)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = structuralError
                };
            }

            Regex regex;

            try
            {
                regex = new Regex("^(" + task.Formula + ")$");
            }
            catch (Exception ex)
            {
                return new CheckResult
                {
                    IsCorrect = false,
                    Message = "Zadanie obsahuje neplatný regulárny výraz: " + ex.Message
                };
            }

            string[] words = GenerateWords(6, alphabet);

            foreach (string word in words)
            {
                bool expected = regex.IsMatch(word);
                bool actual = AcceptsByPda(word);

                if (expected != actual)
                {
                    string shownWord = word == "" ? "ε" : word;

                    return new CheckResult
                    {
                        IsCorrect = false,
                        Message =
                            $"Automat nie je správny. Líši sa na slove '{shownWord}'.\n" +
                            $"Očakávané: {(expected ? "prijať" : "odmietnuť")}.\n" +
                            $"Študentov PDA: {(actual ? "prijať" : "odmietnuť")}."
                    };
                }
            }

            return new CheckResult
            {
                IsCorrect = true,
                Message = "Riešenie je správne."
            };
        }
        private string ValidatePdaStructure(List<char> alphabet)
        {
            var usedStates = PushdownAutomaton.GetUsedStates();

            if (usedStates == null || usedStates.Length == 0)
            {
                return "PDA neobsahuje žiadne stavy.";
            }

            if (string.IsNullOrWhiteSpace(PushdownAutomaton.StartState))
            {
                return "PDA nemá začiatočný stav.";
            }

            bool hasFinalState = false;

            foreach (string state in usedStates)
            {
                if (PushdownAutomaton.IsFinalState(state))
                {
                    hasFinalState = true;
                    break;
                }
            }

            if (!hasFinalState)
            {
                return "PDA nemá žiadny koncový stav.";
            }

            var allowedInputSymbols = new HashSet<char>(alphabet);

            for (int i = 0; i < PushdownAutomaton.TFunctionCount; i++)
            {
                var tf = PushdownAutomaton.TFunction(i);

                if (string.IsNullOrWhiteSpace(tf.CurrentState))
                {
                    return "Prechod obsahuje prázdny počiatočný stav.";
                }

                if (string.IsNullOrWhiteSpace(tf.NewState))
                {
                    return "Prechod obsahuje prázdny cieľový stav.";
                }

                if (!string.IsNullOrEmpty(tf.ReadSymbol))
                {
                    if (tf.ReadSymbol.Length != 1)
                    {
                        return $"Prechod používa neplatný vstupný symbol '{tf.ReadSymbol}'.";
                    }

                    char inputSymbol = tf.ReadSymbol[0];

                    if (!allowedInputSymbols.Contains(inputSymbol))
                    {
                        return $"PDA používa nepovolený vstupný symbol '{tf.ReadSymbol}'.";
                    }
                }

                if (string.IsNullOrEmpty(tf.StackRead))
                {
                    return "Prechod nemá určený symbol čítaný zo zásobníka.";
                }

                if (tf.StackRead.Length != 1)
                {
                    return $"Prechod používa neplatný symbol čítaný zo zásobníka '{tf.StackRead}'.";
                }

                if (tf.StackWrite == null)
                {
                    return "Prechod nemá určený zápis do zásobníka.";
                }
            }

            return null;
        }
        private bool AcceptsByPda(string word)
        {
            // 1. nastav vstupnú pásku ako pôvodnú pásku
            PushdownAutomaton.OriginalTapes = new List<InfiniteTape>();

            InfiniteTape inputTape = new InfiniteTape();

            for (int i = 0; i < word.Length; i++)
            {
                inputTape.SetCell(i, word[i].ToString());
            }

            inputTape.HeadPosition = 0;

            PushdownAutomaton.OriginalTapes.Add(inputTape);

            // 2. reset automatu podobne ako vo formulári
            PushdownAutomaton.Reset();

            PushdownAutomaton.Log.Clear();
            PushdownAutomaton.CurrentState = PushdownAutomaton.StartState;
            PushdownAutomaton.RemoveAllThreads();

            PushdownAutomaton.ActiveTapes =
                InfiniteTape.DeepCopyTapes(PushdownAutomaton.OriginalTapes);

            // 3. simulácia s limitom krokov
            int maxSteps = 1000;

            for (int step = 0; step < maxSteps; step++)
            {
                if (PushdownAutomaton.IsAccepted())
                {
                    return true;
                }

                PushdownAutomaton.NextStep(true);

                if (PushdownAutomaton.NoNextStep)
                {
                    break;
                }
            }

            return PushdownAutomaton.IsAccepted();
        }
        
        private List<char> ExtractAlphabetFromRegex(string regexText)
        {
            var alphabet = new HashSet<char>();

            foreach (char ch in regexText)
            {
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
        private string[] GenerateWords(int maxLength, List<char> alphabet)
        {
            var result = new List<string>();

            GenerateWordsRecursive("", maxLength, result, alphabet);

            return result.ToArray();
        }

        private void GenerateWordsRecursive(
            string current,
            int remaining,
            List<string> result,
            List<char> alphabet)
        {
            result.Add(current);

            if (remaining == 0)
                return;

            foreach (char symbol in alphabet)
            {
                GenerateWordsRecursive(current + symbol, remaining - 1, result, alphabet);
            }
        }
        

        private void miTFormat1_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\sf\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = true; miTFormat2.Checked = false; miTFormat3.Checked = false; 
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false; 
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat2_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = true; miTFormat3.Checked = false; 
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false; 
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat3_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a,\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = true;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat4_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s[\\a,\\a,\\a]\\s[\\a,\\a]\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = true; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat5_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = true; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat6_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s[\\a,\\a,\\a]\\s->\\s[\\a,\\a]\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = true;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat7_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\s(\\a,\\a,\\a)\\s->\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = true; miTFormat8.Checked = false; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat8_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a->\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = true; miTFormat9.Checked = false;
			miTFormat10.Checked = false;
		}

		private void miTFormat9_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\a,\\a,\\a>\\a,\\a";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = true;
			miTFormat10.Checked = false;
		}

		private void miTFormat10_Click(object sender, EventArgs e)
		{
			TransitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
			miTFormat1.Checked = false; miTFormat2.Checked = false; miTFormat3.Checked = false;
			miTFormat4.Checked = false; miTFormat5.Checked = false; miTFormat6.Checked = false;
			miTFormat7.Checked = false; miTFormat8.Checked = false; miTFormat9.Checked = true;
			miTFormat10.Checked = false;
		}
        
    }
}