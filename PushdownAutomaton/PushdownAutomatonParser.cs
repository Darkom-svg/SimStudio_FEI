using System;
using System.Collections.Generic;
using FEI.TuringCore.Simulation;

namespace FEI.PushdownAutomaton {
	public class PushdownAutomatonParser
    {
        //Formát prechodovej funkcie
        private string transitionFormat = "\\sδ\\s(\\a,\\a,\\a)\\s=\\s(\\a,\\a)\\s";
        public string TransitionFormat
        {
            get => transitionFormat;
            set => transitionFormat = value;
        }

        //Formát 
        private string wildCardFormat = "\\a=\\s{\\m,\\n}\\s";
        public string WildCardFormat
        {
            get => wildCardFormat;
            set => wildCardFormat = value;
        }

        private VirtualTuringMachine turingMachine;
        public VirtualTuringMachine TuringMachine
        {
            get => turingMachine;
            set => turingMachine = value;
        }


        public PushdownAutomatonParser(VirtualTuringMachine turingMachine)
        {
            this.turingMachine = turingMachine;
        }

        public PushdownAutomatonParser(VirtualTuringMachine turingMachine, string transitionFormat, string wildCardFormat)
        {
            this.turingMachine = turingMachine;
            this.transitionFormat = transitionFormat;
            this.wildCardFormat = wildCardFormat;
        }

        //Chyby
        private List<TMError> errors = new List<TMError>();
        public List<TMError> Errors
        {
            get => errors;
            set => errors = value;
        }

        public bool ParseTFunctions(string code)
        {
            errors = new List<TMError>();
            string[] lines = code.Split('\n');
            string[] parts;
            string part;
            string format = transitionFormat;

            string[] args;
            
            turingMachine.RemoveAllTFunctions(); //Zmaže staré prechodové funkcie
            turingMachine.WildCards.Clear();     //Zmaže staré zástupné znaky

            for (int a = 0; a <= lines.Length - 1; a++)
            {
                lines[a] = lines[a].Trim();
                if (!(lines[a].StartsWith("//") || lines[a] == ""))
                {
                    parts = lines[a].Split(';');
                    for (int p = 0; p <= parts.Length - 1; p++)
                    {
                        part = parts[p].Trim();

                        args = ParsePart(part, format);
                        if (args == null || args.Length < 3)
                        {
                            args = ParsePart(part, wildCardFormat);
                            if (args == null || args.Length == 0)
                            {
                                //Chybná syntax                                
                                errors.Add(new TMError("Chybná syntax prechodu", "", a, p));
                            }
                            else //Wildcards
                            {
                                string[] symbols = new string[args.Length - 1];
                                Array.Copy(args, 1, symbols, 0, args.Length - 1);
                                turingMachine.AddWildcard(args[0], symbols);
                            }
                        }
                        else
                        {
                            turingMachine.AddTFunction(new Transition(args[0], args[1], args[3], args[1], args[2], args[4], Transition.Steps.Right));
                        }
                    }
                }
            }            

            // Chyba pri preklade
            if (errors.Count > 0) return false; else return true;
        }

        private string[] ParsePart(string part, string format)
        {
            int l = 0;

            //Oddelenie komentára od kódu
            string[] strs = part.Split(new string[] { "//" }, StringSplitOptions.None);
            part = strs[0];
            //if (strs.Length>1) comment = strs[1];            

            //Rozloženie formátu na časti
            List<string> f = new List<string>();
            for (int a = 0; a <= format.Length - 1; a++)
            {
                if (format[a] == '\\')
                {
                    f.Add(format.Substring(l, a - l));
                    f.Add(format.Substring(a, 2));
                    l = a + 2;
                    a += 1;
                }
            }
            if (l < format.Length - 1)
            {
                f.Add(format.Substring(l, format.Length - 1 - l));
            }

            //Zmaže prázdne reťazce
            for (int a = f.Count - 1; a >= 0; a--)
            {
                if (f[a] == "") f.RemoveAt(a);
            }

            //Parsovanie časti podľa zvoleného formátu
            List<string> args = new List<string>();
            int n = 0;
            //Aktuálna pozícia vo formáte        
            int j;
            while (part.Length != 0)
            {
                if (n > f.Count - 1)
                    return null;

                switch (f[n])
                {
                    case "\\a":  //Argument
                        if (n + 1 > f.Count - 1)
                        {
                            j = part.Length;
                        }
                        else
                        {
                            j = part.IndexOf(f[n + 1]);
                        }

                        if (j >= 0)
                        {
                            args.Add(part.Substring(0, j).Trim());
                            part = part.Substring(j);
                            n += 1;
                        }
                        else
                        {
                            return null;
                        }

                        break;
                    case "\\n": //Pole argumentov                        
                        n = f.LastIndexOf("\\m", n);
                        break;
                    case "\\m": //Pole argumentov                        
                        bool last = false;
                        int n2 = 0;
                        if (n + 1 > f.Count - 1)
                        {
                            j = part.Length;
                        }
                        else
                        {
                            int j2 = -1;
                            n2 = f.IndexOf("\\n", n);
                            j = part.IndexOf(f[n + 1]);

                            if (n2 != -1) j2 = part.IndexOf(f[n2 + 1]);

                            if (j == -1) { j = j2; last = true; }
                            else if (j2 == -1) ;
                            else
                            {
                                j = Math.Min(j, j2);
                                if (j == j2) last = true;
                            }
                        }

                        if (j >= 0)
                        {
                            args.Add(part.Substring(0, j).Trim());
                            part = part.Substring(j);

                            //Posledný argument
                            if (last)
                            {
                                n = n2 + 1;
                            }
                            else n++;
                        }
                        else
                        {
                            return null;
                        }

                        break;
                    case "\\s": //Voľný priestor - medzery, tabulátory (ľubovoľný počet) 
                        if (char.IsWhiteSpace(part[0]))
                        {
                            part = part.Substring(1);
                        }
                        else
                        {
                            n += 1;
                        }

                        break;
                    default:
                        if (part.StartsWith(f[n]))
                        {
                            part = part.Substring(((string)f[n]).Length).Trim();
                            n += 1;
                        }
                        else
                        {
                            //Nevyhovuje formátu
                            return null;
                        }

                        break;
                }
            }

            return args.ToArray();
        }
    }
}
