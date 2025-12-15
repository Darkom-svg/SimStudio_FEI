using DusanRodina.SimStudio.Components;
using DusanRodina.SimStudio.Components.Registers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DusanRodina.RandomAccessMachine.Simulation {
	public class Compiler
    {
        private List<InstructionType> allowedInstructions = new List<InstructionType>();
        public List<InstructionType> AllowedInstructions
        {
            get { return allowedInstructions; }
            set { allowedInstructions = value; }
        }

        public Compiler(List<InstructionType> allowedInstructions)
        {
            this.allowedInstructions = allowedInstructions;
        }

        //Kompilátor zdrojových kódov RAM simulátora
        public Simulator Compile(string Code,Form ownerForm)
        {
            Simulator newSim = new Simulator(ownerForm);
            return CompileIn(newSim, Code);
        }

        //Kompilátor zdrojových kódov RAM simulátora
        public Simulator CompileIn(Simulator simulator, string Code)
        {
            int lineIndex = 0;
            try
            {
                Simulator newSim = simulator;

                newSim.program.Clear();
                newSim.labeledProgram.Clear();
                newSim.regs.Clear();
                newSim.Labels.Clear();

                string[] Lines = Code.Split('\n');
                int i;
                string[] parts;
                //List<Simulator.sRAMAtom> prg = new List<Simulator.sRAMAtom>();
                string lastLabel = "";

                //Meno nejakého registra bolo zmenené
                bool RegNameChanged = false;

                InstructionType previousInstruction = InstructionType.Nop;

                string tmp;
                string[] tmpF, tmpF2;
                //Zasobnik adries blokov
                Stack<int> blockStack = new Stack<int>();

                newSim.Labels.Clear();

                for (lineIndex = 0; lineIndex <= Lines.GetUpperBound(0); lineIndex++)
                {
                    Lines[lineIndex] = Functions.TrimEnters(Lines[lineIndex]);

                    i = Lines[lineIndex].IndexOf("//");
                    if (i != -1)
                    {

                        //Pomenovanie registru
                        int i2;
                        i2 = Lines[lineIndex].IndexOf("//#");
                        if (i2 != -1)
                        {
                            int i3 = 0;
                            i3 = Lines[lineIndex].IndexOf("//#screen");
                            if (i3 != -1) //Obrazovka
                            {
                                tmp = Functions.TrimEnters(Lines[lineIndex].Substring(i3 + 9));
                                tmpF = tmp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                if (tmpF.Length > 0)
                                {
                                    tmpF2 = tmpF[0].Split(new char[] { 'x' }, StringSplitOptions.RemoveEmptyEntries);
                                    if (tmpF2.Length == 2)
                                    {
                                        newSim.Screen.width = Functions.ToValue(tmpF2[0]);
                                        newSim.Screen.height = Functions.ToValue(tmpF2[1]);
                                    }
                                }
                                if (tmpF.Length >= 2)
                                {
                                    newSim.Screen.startIndex = Functions.ToValue(tmpF[1]);
                                }

                            }
                            else //Označenie registra/registrov
                            {
                                tmp = Functions.TrimEnters(Lines[lineIndex].Substring(i2 + 3));
                                tmpF = tmp.Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                if (tmpF.Length == 2)
                                { //Register
                                    if (Functions.ToValue(tmpF[0]) > 0 && Functions.ToValue(tmpF[0]) <= 1000)
                                    {
                                        int ri = Functions.ToValue(tmpF[0]);
                                        if (newSim.regs[ri].Name != tmpF[1].Trim())
                                        {
                                            newSim.regs[ri] = new RegisterCell(newSim.regs[ri].Value, tmpF[1].Trim());
                                            RegNameChanged = true;
                                        }
                                    }
                                }
                                if (tmpF.Length >= 3) //Rozsah registrov
                                {
                                    int from, to;
                                    from = Functions.ToValue(tmpF[0]);
                                    to = Functions.ToValue(tmpF[1]);
                                    if (to < from) to = from;
                                    if (to > 1000000) to = 1000000;

                                    for (int r = from; r <= to; r++)
                                    {
                                        if (newSim.regs[r].Name != tmpF[2].Trim())
                                        {
                                            newSim.regs[r] = new RegisterCell(newSim.regs[r].Value, tmpF[2].Trim() + (r - from + 1).ToString());
                                            RegNameChanged = true;
                                        }
                                    }
                                }
                            }

                            Lines[lineIndex] = Lines[lineIndex].Substring(0, i2);
                        }
                        else
                        {
                            //Typ rozšírenia simulátora
                            if (Lines[lineIndex].Trim().StartsWith("//$"))
                            {
                                //Konzola
                                if (Lines[lineIndex].Trim().ToLower().StartsWith("//$console"))
                                {
                                    newSim.RamConsole = true;
                                }
                            }

                            Lines[lineIndex] = Lines[lineIndex].Substring(0, i);
                        }
                    }

                    if (Lines[lineIndex] != "")
                    {  //Riadok nie je prázdny
                        parts = ParseLine(Lines[lineIndex]); //Rozparsuje riadok
                        if (parts[0] != "")
                            lastLabel = parts[0];

                        InstructionType instruction = GetCommand(parts[1]);

                        if (instruction == InstructionType.BlockBegin && previousInstruction == InstructionType.If)
                        {
                            blockStack.Push(newSim.labeledProgram.Count - 1);
                            newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                InstructionType.IfBlockBegin, InfiniteInteger.zero, OperationType.Constant, "", " "));
                        }
                        else if (instruction == InstructionType.BlockBegin && previousInstruction == InstructionType.Do)
                        {
                            blockStack.Push(newSim.labeledProgram.Count - 1);
                            newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                InstructionType.DoWhileBlockBegin, InfiniteInteger.zero, OperationType.Constant, "", " "));
                        }
                        else if (instruction == InstructionType.BlockBegin && previousInstruction == InstructionType.While)
                        {
                            blockStack.Push(newSim.labeledProgram.Count - 1);
                            newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                InstructionType.WhileBlockBegin, InfiniteInteger.zero, OperationType.Constant, "", " "));
                        }
                        else if (instruction == InstructionType.BlockEnd && blockStack.Count > 0)
                        {
                            int blockBeginAddress = blockStack.Pop();

                            InstructionType blockEndCmd = InstructionType.BlockEnd;
                            switch (newSim.labeledProgram[blockBeginAddress].Command)
                            {
                                case InstructionType.If:
                                    blockEndCmd = InstructionType.IfBlockEnd;
                                    break;
                                case InstructionType.Do:
                                    blockEndCmd = InstructionType.DoWhileBlockEnd;
                                    break;
                                case InstructionType.While:
                                    blockEndCmd = InstructionType.WhileBlockEnd;
                                    break;
                            }

                            // Vlozi adresu konca bloku aj s adresov zaciatku bloku                        
                            newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                blockEndCmd, new InfiniteInteger(blockBeginAddress), OperationType.Constant, "", "continue"));

                            // Vlozi adresu konca bloku k instrukcii zaciatku bloku
                            newSim.labeledProgram[blockBeginAddress + 1].Operand = new InfiniteInteger(newSim.labeledProgram.Count);
                        }
                        else if (instruction != InstructionType.Nop)
                        {
                            if (lastLabel != "")
                                newSim.Labels.Add(new Label(lastLabel.ToLower(), newSim.labeledProgram.Count));

                            if (!Functions.IsNumber(parts[3])) //Obsahuje návestie alebo podmienku (GZERO) cyklu WHILE
                            {
                                if (instruction == InstructionType.Print)
                                    newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                        instruction, InfiniteInteger.zero, GetOT(parts[2]), lastLabel,
                                            parts[3]));
                                else
                                    newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                        instruction, InfiniteInteger.zero, GetOT(parts[2]), lastLabel,
                                            Utils.StringUtils.RemoveSpaces(parts[3].ToLower())));
                            }
                            else
                            {
                                newSim.labeledProgram.Add(new LabeledRAMInstruction(
                                    instruction, new InfiniteInteger(parts[3]), GetOT(parts[2]), lastLabel, ""));
                            }
                            lastLabel = "";
                        }


                        previousInstruction = instruction;
                    }

                }

                //Nastavenie menoviek
                for (int a = 0; a <= newSim.labeledProgram.Count - 1; a++)
                {
                    LabeledRAMInstruction newInst = newSim.labeledProgram[a];
                    newSim.program.Add(new RAMInstruction(newInst.Command, newInst.Operand, newInst.OperandType));

                    if ((newSim.labeledProgram[a]).OpLabel != "")
                    {
                        for (int l = 0; l <= newSim.Labels.Count - 1; l++)
                        {
                            if (((Label)newSim.Labels[l]).Name == newSim.labeledProgram[a].OpLabel)
                            {
                                //Konvertovanie instrukcie s navestim na instrukciu bez navestia                            
                                newSim.program[a].Operand = new InfiniteInteger(((Label)newSim.Labels[l]).Line);
                                newSim.program[a].OperandType = OperationType.Constant;
                                break;
                            }
                        }
                    }
                }

                return newSim;
            }
            catch (Exception ex)
            {
                throw new CompilerException(lineIndex, ex);
            }
        }

        //Parser riadku zdrojového kódu RAM simulátora
        private string[] ParseLine(string Line)
        {
            string[] Parts = new string[4];
            int i;

            //Label
            i = Line.IndexOf(":");
            if (i != -1)
            {
                Parts[0] = Functions.TrimEnters(Line.Substring(0, i).ToLower());
                Line = Functions.TrimEnters(Line.Substring(i + 1));
            }
            else
            {
                Parts[0] = "";
            }

            //Príkaz
            if (Line.Trim() != "")
            {
                string c = "";
                i = GetIndexOfSep(Line, 0, ref c);
                if (i != -1)
                {
                    Parts[1] = Functions.TrimEnters(Line.Substring(0, i));
                    Parts[2] = c.ToString();
                    if (i + 1 < Line.Length)
                        Parts[3] = Functions.TrimEnters(Line.Substring(i + c.ToString().Length));
                    else
                        Parts[3] = "";
                }
            }

            return Parts;
        }

        //Vráti pozíciu ďalšej oddelenej hodnoty
        private int GetIndexOfSep(string Text)
        {
            string c = "";
            return GetIndexOfSep(Text, 0, ref c);
        }

        //Vráti pozíciu ďalšej oddelenej hodnoty
        private int GetIndexOfSep(string Text, int Start)
        {
            string c = "";
            return GetIndexOfSep(Text, Start, ref c);
        }

        //Vráti pozíciu ďalšej oddelenej hodnoty
        private int GetIndexOfSep(string Text, int Start, ref string Sign)
        {
            bool isSpace = false;
            for (int a = Start; a <= Text.Length - 1; a++)
            {
                if (Text[a] == '=' || Text[a] == '*' )
                {
                    Sign = Text[a].ToString();
                    return a;
                }
                else if (Text[a] == ' ' || Text[a] == '\t')
                {
                    isSpace = true;
                }
                else if (isSpace && (Text[a] != ' ' && Text[a] != '\t'))
                {
                    Sign = " ";
                    return a - 1;
                }
                else if (Text[a] == '(')
                {
                    Sign = "";
                    return a;
                }
            }
            return Text.Length;
        }

        private InstructionType GetCommand(string name)
        {
            if (name == null)
                return InstructionType.Nop;

            name = Functions.TrimEnters(name.ToLower());

            switch (name)
            {
                case "if":
                    if (!allowedInstructions.Contains(InstructionType.If))
                        throw new InvalidInstructionException(InstructionType.If);
                    return InstructionType.If;
                case "do":
                    if (!allowedInstructions.Contains(InstructionType.Do))
                        throw new InvalidInstructionException(InstructionType.Do);
                    return InstructionType.Do;
                case "while":
                    if (!allowedInstructions.Contains(InstructionType.While))
                        throw new InvalidInstructionException(InstructionType.While);
                    return InstructionType.While;
                case "{":                    
                    return InstructionType.BlockBegin;
                case "}":                    
                    return InstructionType.BlockEnd;
                case "push":
                    if (!allowedInstructions.Contains(InstructionType.Push))
                        throw new InvalidInstructionException(InstructionType.Push);
                    return InstructionType.Push;                    
                case "pop":
                    if (!allowedInstructions.Contains(InstructionType.Pop))
                        throw new InvalidInstructionException(InstructionType.Pop);
                    return InstructionType.Pop;
                case "print":
                    if (!allowedInstructions.Contains(InstructionType.Print))
                        throw new InvalidInstructionException(InstructionType.Print);
                    return InstructionType.Print;
                case "read":
                    if (!allowedInstructions.Contains(InstructionType.Read))
                        throw new InvalidInstructionException(InstructionType.Read);
                    return InstructionType.Read;
                case "write":
                    if (!allowedInstructions.Contains(InstructionType.Write))
                        throw new InvalidInstructionException(InstructionType.Write);
                    return InstructionType.Write;
                case "load":
                    if (!allowedInstructions.Contains(InstructionType.Load))
                        throw new InvalidInstructionException(InstructionType.Load);
                    return InstructionType.Load;
                case "store":
                    if (!allowedInstructions.Contains(InstructionType.Store))
                        throw new InvalidInstructionException(InstructionType.Store);
                    return InstructionType.Store;
                case "add":
                    if (!allowedInstructions.Contains(InstructionType.Add))
                        throw new InvalidInstructionException(InstructionType.Add);
                    return InstructionType.Add;
                case "sub":
                    if (!allowedInstructions.Contains(InstructionType.Subs))
                        throw new InvalidInstructionException(InstructionType.Subs);
                    return InstructionType.Subs;
                case "mult":
                case "mul":
                    if (!allowedInstructions.Contains(InstructionType.Mult))
                        throw new InvalidInstructionException(InstructionType.Mult);
                    return InstructionType.Mult;
                case "div":
                    if (!allowedInstructions.Contains(InstructionType.Div))
                        throw new InvalidInstructionException(InstructionType.Div);
                    return InstructionType.Div;
                case "jump":
                    if (!allowedInstructions.Contains(InstructionType.Jump))
                        throw new InvalidInstructionException(InstructionType.Jump);
                    return InstructionType.Jump;
                case "jzero":
                    if (!allowedInstructions.Contains(InstructionType.JZero))
                        throw new InvalidInstructionException(InstructionType.JZero);
                    return InstructionType.JZero;
                case "jgzero": case "jgtz":
                    if (!allowedInstructions.Contains(InstructionType.JGZero))
                        throw new InvalidInstructionException(InstructionType.JGZero);
                    return InstructionType.JGZero;
                case "halt":
                    if (!allowedInstructions.Contains(InstructionType.Halt))
                        throw new InvalidInstructionException(InstructionType.Halt);
                    return InstructionType.Halt;
                case "accept":
                    if (!allowedInstructions.Contains(InstructionType.Accept))
                        throw new InvalidInstructionException(InstructionType.Accept);
                    return InstructionType.Accept;
                case "reject":
                    if (!allowedInstructions.Contains(InstructionType.Reject))
                        throw new InvalidInstructionException(InstructionType.Reject);
                    return InstructionType.Reject;
            }

            return InstructionType.Nop;
        }

        public static string GetCommand(InstructionType Name)
        {
            switch (Name)
            {
                case InstructionType.Do:
                    return "do";
                case InstructionType.If:
                    return "if";
                case  InstructionType.While:
                    return "while";
                case InstructionType.BlockBegin:
                case InstructionType.IfBlockBegin:
                case InstructionType.WhileBlockBegin:
                case InstructionType.DoWhileBlockBegin:
                    return "{";
                case InstructionType.BlockEnd:
                case InstructionType.IfBlockEnd:
                case InstructionType.WhileBlockEnd:
                case InstructionType.DoWhileBlockEnd:
                    return "}";
                case InstructionType.Push:
                    return "push";
                case InstructionType.Pop:
                    return "pop";
                case InstructionType.Read:
                    return "read";
                case  InstructionType.Print:
                    return "print";
                case InstructionType.Write:                    
                    return "write";
                case InstructionType.Load:
                    return "load";
                case InstructionType.Store:
                    return "store";
                case InstructionType.Add:
                    return "add";
                case InstructionType.Subs:
                    return "sub";
                case InstructionType.Mult:
                    return "mult";
                case InstructionType.Div:
                    return "div";
                case InstructionType.Jump:
                    return "jump";
                case InstructionType.JZero:
                    return "jzero";
                case InstructionType.JGZero:
                    return "jgtz";
                case InstructionType.Halt:
                    return "halt";
                case InstructionType.Accept:
                    return "accept";
                case InstructionType.Reject:
                    return "reject";
            }

            return "";
        }

        private OperationType GetOT(string Name)
        {
            if (Name == null)
                return OperationType.Address;
            switch (Name.ToLower().Trim())
            {
                case "=":
                    return OperationType.Constant;
                case " ":
                    return OperationType.Address;
                case "*":
                    return OperationType.Indirect;
                default:
                    return OperationType.Address;
            }
        }

        public static string GetOT(OperationType Name)
        {
            switch (Name)
            {
                case OperationType.Constant:
                    return "=";
                case OperationType.Indirect:
                    return "*";
                default:
                    return " ";
            }
        }


    }
}
