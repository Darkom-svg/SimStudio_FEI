using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DusanRodina.TuringCore.Simulation;
using System.Text;
using DusanRodina.FiniteAutomaton;
using TrainingSimulator.Dialogs;
using DusanRodina.SimStudio.Components;
using DusanRodina.SimStudio.Components.Dialogs;
using FiniteAutomaton;
using TrainingSimulator.IO.Jff;
using AboutForm = DusanRodina.TrainingSimulator.Dialogs.AboutForm;
using AddTFunctionForm = TrainingSimulator.Dialogs.AddTFunctionForm;

namespace TrainingSimulator
{
    public partial class TrainingForm : Form
    {
        private MainTrainingForm.TaskDef task;
        private string appTitle;
        private VirtualTuringMachine turingMachine = new VirtualTuringMachine() { AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead };
        bool codeChanged = false;        
        //Formát prechodovej funkcie
        string transitionFormat;
        //Formát 
        string wildCardFormat;
        // Vytvorí formálnu špecifikáciu
        private string tmpFormalSpecFileName = null;
        // Vytvorí špecifikáciu zadania
        private string tmpTaskSpecFileName = null;
        string openFileName = null;
        
        public TrainingForm(MainTrainingForm.TaskDef task)
        {
            InitializeComponent();
            this.task = task;
            this.Text = "Trenažér (" + this.task.Id + ")";
            appTitle = "Trenažér (" + this.task.Id + ")";
            TrainerForm_Load(this, null);
            CreateTaskSpecification();
        }

        private void TrainerForm_Load(object sender, EventArgs e)
        {
            
            if (task.Category.Equals("FA"))
            {
                transitionFormat = "\\sδ\\s(\\a,\\a)\\s=\\s(\\a)\\s";
                wildCardFormat = "\\a=\\s{\\m,\\n}\\s";
                this.Text = "FA";
            }
            
            if (task.Category.Equals("PDA"))
            {
                transitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
                wildCardFormat = "\\a=\\s{\\m,\\n}\\s";    
                this.Text = "PDA";
            }
            
            if (task.Category.Equals("TM"))
            {
                transitionFormat = "\\sδ\\s(\\a,\\a)\\s=\\s(\\a,\\a,\\a)\\s";
		        wildCardFormat = "\\a=\\s{\\m,\\n}\\s";
                this.Text = "TM";
            }


        }
        
        //Zdržanie pri vykonávaní programu
        int delay = 10;

        //Vlákno stroja        
        System.Threading.Thread thRealTime;

        System.Timers.Timer timMachine = new System.Timers.Timer();
        bool pause = false;
        bool prgStop = true;

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

        public VirtualTuringMachine TuringMachine
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
            //Todo
            //cmbTape.SelectedIndex = 0;            
            //infiniteTapeControl.Tapes = TuringMachine.OriginalTapes;

            AddSpeedPanel();
        }

        private void AddSpeedPanel()
        {
            ToolStripControlHost host = new ToolStripControlHost(speedPanel);
            host.Alignment = ToolStripItemAlignment.Right;
            host.Width = 200;
            host.AutoSize = false;
            mainToolStrip.Items.Add(host);
        }
        
        
        
        private void bAddTFunction_Click(object sender, EventArgs e)
        {
            AddTransition(new Transition());
        }     
        
        private void AddTransition(Transition def_tf)
        {             
            AddTFunctionForm dlg = new AddTFunctionForm(); // Todo pre vsetky typy
            dlg.TM = this.TuringMachine;
            dlg.tfunction = def_tf;
            dlg.ShowDialog(this);
            if (dlg.OKPressed)
            {
                Transition tf = dlg.tfunction;
                txtCode.Text += Environment.NewLine;
                txtCode.Text += WriteTransition(tf, transitionFormat);
                if (tf.Comment.Trim() != "") txtCode.Text += " //" + tf.Comment;
                txtCode.Text += Environment.NewLine;
                ParseTFunctions(txtCode.Text);
            }
        }
        //Todo only for FA, change to all types
        private string WriteTransition(Transition tf, string transitionFormat)
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
                else if (n == 2) arg = tf.NewState;
                else if (n == 3) arg = tf.WriteSymbol;
                else if (n == 4) arg = step;

                res += transitionFormat.Substring(l, i - l) + arg;

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
                var max = TuringMachine.TFunctionCount; //-(int)Math.Floor((double)pFunctions.Height / 20);
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

            if (task.Category.Equals("FA"))
            {
                TuringMachine.StateDiagram.UpdateForFA(TuringMachine);
            } else if (task.Category.Equals("PDA")) 
            {
                TuringMachine.StateDiagram.UpdateForPA(TuringMachine);
            } else if (task.Category.Equals("TM")) 
            {
                TuringMachine.StateDiagram.UpdateForTM(TuringMachine);
            }
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
            if (task.Category.Equals("FA"))
            {
                sb.AppendLine("<body>");
                //Nadpis
                sb.AppendLine("<h1>Formálna špecifikácia</h1>");

                sb.AppendLine("<div>");
                sb.AppendLine("Konečný stroj <strong>A = (K, Σ, " + TuringMachine.StartState + ", δ, F)</strong>");
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
                sb.AppendLine("<strong>" + TuringMachine.StartState + "</strong>  počiatočný stav");
                sb.AppendLine("</div>");
                // Množina koncových stavov
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", TuringMachine.FinalStates.ToArray()) + "}");
                sb.AppendLine("</div>");

                // Prechodové funkcie
                sb.AppendLine("<div>");
                sb.AppendLine("<h2>Prechodová funkcia δ</h2>");
                foreach (Transition f in TuringMachine.GetTFunctions())
                {
                    sb.AppendLine("<div>");
                    sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol + 
                                  ") = " + f.NewState);
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");                
                
                sb.AppendLine("</body>");
            }
            else if (task.Category.Equals("PDA"))
            {
                // Todo
                // sb.AppendLine("<body>");
                // //Nadpis
                // sb.AppendLine("<h1>Formálna špecifikácia</h1>");
                //
                // sb.AppendLine("<div>");
                // sb.AppendLine("Zásobníkový automat <strong>ZA = (K, Σ, Γ, δ, " + PushdownAutomaton.StartState + ", Z, F)</strong>");
                // sb.AppendLine("</div>");
                //
                // // Množina stavov
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>K</strong> = {" + PushdownAutomaton.GetUsedStatesAsString() + "}");
                // sb.AppendLine("</div>");
                // // Vstupná abeceda
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>Σ</strong> = {" + PushdownAutomaton.GetUsedSymbolsAsString() + "}");
                // sb.AppendLine("</div>");
                // // Zásobniková abeceda
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>Γ</strong> = {" + PushdownAutomaton.GetUsedStackSymbolsAsString() + "}");
                // sb.AppendLine("</div>");
                // // Počiatočný stav
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>" + PushdownAutomaton.StartState + "</strong> - počiatočný stav");
                // sb.AppendLine("</div>");
                // // Symbol na dne zasobnika
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>Z</strong> - symbol na dne zásobníka");
                // sb.AppendLine("</div>");            
                // // Množina koncových stavov
                // sb.AppendLine("<div>");
                // sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", PushdownAutomaton.FinalStates.ToArray()) + "}");
                // sb.AppendLine("</div>");
                //
                // // Prechodové funkcie
                // sb.AppendLine("<div>");
                // sb.AppendLine("<h2>Prechodová funkcia δ</h2>");
                // foreach (Transition f in PushdownAutomaton.GetTFunctions())
                // {
                //     sb.AppendLine("<div>");
                //     sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol + ", " + f.StackRead + 
                //                   ") = (" + f.NewState + ", "  + f.StackWrite + ")");
                //     sb.AppendLine("</div>");
                // }
                // sb.AppendLine("</div>");                
				            //
                // sb.AppendLine("</body>");
            }
            else if (task.Category.Equals("TM"))
            {
                sb.AppendLine("<body>");
                //Nadpis
                sb.AppendLine("<h1>Formálna špecifikácia</h1>");

                sb.AppendLine("<div>");
                sb.AppendLine("Turingov stroj <strong>T = (K, Σ, Γ, δ, " + TuringMachine.StartState + ", F)</strong>");
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
                sb.AppendLine("<strong>" + TuringMachine.StartState + "</strong>  počiatočný stav");
                sb.AppendLine("</div>");
                // Množina koncových stavov
                sb.AppendLine("<div>");
                sb.AppendLine("<strong>F</strong> = {" + String.Join(", ", TuringMachine.FinalStates.ToArray()) + "}");
                sb.AppendLine("</div>");

                // Prechodové funkcie
                sb.AppendLine("<div>");
                sb.AppendLine("<h2>Prechodová funkcia δ</h2>");
                foreach (Transition f in TuringMachine.GetTFunctions()) {
                    sb.AppendLine("<div>");
                    sb.AppendLine("<strong>δ(</strong>" + f.CurrentState + ", " + f.ReadSymbol +
                                  ") = (" + f.NewState + ", " + f.WriteSymbol + ", " + Transition.StepToString(f.Step) + ")");
                    sb.AppendLine("</div>");
                }
                sb.AppendLine("</div>");
                sb.AppendLine("</body>");
            }
            

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
                if (task.Category.Equals("FA"))
                {
                    sb.AppendLine("<strong>Typ zadania:</strong> Konečný automat");
                }
                else if (task.Category.Equals("PDA"))
                {
                    sb.AppendLine("<strong>Typ zadania:</strong> Zásobníkový automat");
                } else if (task.Category.Equals("TM"))
                {
                    sb.AppendLine("<strong>Typ zadania:</strong> Túringov stroj");
                }
                else
                {
                    sb.AppendLine("<strong>Typ zadania:</strong> Neznámy");
                }
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
        
        private void miSettings_Click(object sender, EventArgs e)
        {             
            SettingsForm frm = new SettingsForm();
            frm.initialState = TuringMachine.StartState;
            frm.finalStates = new List<string>(TuringMachine.FinalStates);
            frm.ShowDialog(this);
            if (frm.OKPressed)
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
        
    }
}