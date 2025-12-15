using System.Collections.Generic;

namespace DusanRodina.RandomAccessMachine.Conversion {
	public class CConvertor
    {
        public ICBlock ConvertBlock(IntermediateCode ic, string blockname, string block)
        {
            ICBlock bl = new ICBlock(blockname);

            string[] parts;
            parts = GetCodeParts(block);

            for (int i = 0; i < parts.Length; i++)
            {
                //Vynechanie komentára
                if (parts[i].IndexOf("//") != -1)
                {
                    parts[i] = parts[i].Substring(0, parts[i].IndexOf("//")) + parts[i].Substring(parts[i].IndexOf("/n") + 1);
                }


                if (parts[i].StartsWith("int ")) //Vloženie premennej
                {
                    string[] names;
                    names = parts[i].Substring(4).Split(',');

                    for (int v = 0; v < names.Length; v++)
                    {
                        ic.vars.Add(new ICVariable(names[v].Trim(), ic.GetVarIndex()));
                    }
                }
                else if (parts[i].StartsWith("if") && !char.IsLetterOrDigit(parts[i][2])) //Podmienka
                {
                    string condition = parts[i].Substring(2).Trim();  //podmienka
                    condition = condition.Substring(1, condition.Length - 2); //odstránenie začiatočnej a koncovej zátvorky

                    if (i + 2 < parts.Length && parts[i + 2] == "else")
                    {
                        bl.program.Add(new ICCommand(ICCommandTypes.If, condition,
                                        ConvertBlock(ic, "thenblock", parts[i + 1].Substring(1)),
                                        ConvertBlock(ic, "elseblock", parts[i + 3].Substring(1))
                                    ));

                        i += 3;
                    }
                    else
                    {
                        bl.program.Add(new ICCommand(ICCommandTypes.If, condition,
                                        ConvertBlock(ic, "thenblock", parts[i + 1].Substring(1))
                                    ));
                        i++;
                    }
                }
                else if (parts[i].StartsWith("for") && !char.IsLetterOrDigit(parts[i][3])) //Cyklus
                {
                    string conditions = parts[i].Substring(3).Trim();  //podmienka
                    conditions = conditions.Substring(1, conditions.Length - 2); //odstránenie začiatočnej a koncovej zátvorky
                    string[] cparts = conditions.Split(';');

                    bl.program.Add(new ICCommand(ICCommandTypes.For,
                                        ConvertBlock(ic, "for", cparts[0] + ";"),
                                        cparts[1],
                                        ConvertBlock(ic, "for", cparts[2] + ";"),
                                        ConvertBlock(ic, "forcode", parts[i + 1].Substring(1))
                                    ));
                    i++;
                }
                else if (parts[i].StartsWith("while") && !char.IsLetterOrDigit(parts[i][5])) //While-Cyklus
                {
                    string condition = parts[i].Substring(5).Trim();  //podmienka
                    condition = condition.Substring(1, condition.Length - 2); //odstránenie začiatočnej a koncovej zátvorky

                    bl.program.Add(new ICCommand(ICCommandTypes.While, condition,
                                        ConvertBlock(ic, "while", parts[i + 1].Substring(1))
                                    ));
                    i++;
                }
                else if (parts[i].StartsWith("print") && !char.IsLetterOrDigit(parts[i][5])) //Vypísanie
                {
                    string printvar = parts[i].Substring(5).Trim();  //print
                    printvar = printvar.Substring(1, printvar.Length - 2); //odstránenie začiatočnej a koncovej zátvorky

                    bl.program.Add(new ICCommand(ICCommandTypes.Print, printvar));
                }
                else if (parts[i].StartsWith("{")) //Vnorený blok príkazov
                {
                    ConvertBlock(ic, "nestedblock", parts[i].Substring(1));
                }
                else if (parts[i].IndexOf('=') != -1 && parts[i].IndexOf("==") == -1) //Priradenie
                {
                    string[] aparts;
                    string value;
                    aparts = parts[i].Split('=');  //rozdelí na časti podľa rovná sa
                    value = aparts[aparts.Length - 1];  //posledná z častí je hodnota, napr. pri a=b=2, je to 2
                    for (int a = 0; a < aparts.Length - 1; a++)
                    {
                        bl.program.Add(new ICCommand(ICCommandTypes.Assignment, aparts[a], value));
                    }
                }
            }

            return bl;
        }

        //Rozloží kód jazyka C na príkazy prvej úrovne
        private string[] GetCodeParts(string code)
        {
            List<string> parts = new List<string>();
            int last = 0;
            int blockDepth = 0; //úroveň blokov
            int parDepth = 0;   //úroveň zátvoriek

            for (int i = 0; i < code.Length; i++)
            {
                if (code[i] == ';' && blockDepth == 0 && parDepth == 0)
                {
                    parts.Add(code.Substring(last, i - last).Trim());
                    last = i + 1;
                }
                else if (code[i] == '(')
                {
                    parDepth++;
                }
                else if (code[i] == ')')
                {
                    parDepth--;
                }
                else if (code[i] == '}')
                {
                    blockDepth--;

                    if (blockDepth == 0)
                    {
                        parts.Add("{" + code.Substring(last, i - last).Trim());
                        last = i + 1;
                    }
                }
                else if (code[i] == '{' && blockDepth != 0)
                {
                    blockDepth++;
                }
                else if (code[i] == '{' && blockDepth == 0)
                {
                    parts.Add(code.Substring(last, i - last).Trim());
                    last = i + 1;
                    blockDepth++;
                }
            }

            return parts.ToArray();
        }
    }
}
