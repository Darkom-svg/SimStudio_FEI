using System;
using System.Collections.Generic;

namespace DusanRodina.RandomAccessMachine.Conversion {
	//Konvertor logických vzorcov do RAM kódu
	public class LogicFormulaConvertor
    {
        public IntermediateCode ic;

        public string formula;
        public List<string> parts = new List<string>();

        public ICVariable resVariable;

        private void Add(string part)
        {
            part = part.Trim();
            if (part != "")
                parts.Add(part);
        }

        private void Add(char sign)
        {
            if (sign != '\0')
                parts.Add(sign.ToString());
        }

        private void SplitFormula()
        {
            if (formula == null) return;

            string z1, z2;
            int last = 0;

            for (int a = 0; a < formula.Length; a++)
            {
                z1 = formula.Substring(a, 1);
                if (a + 2 > formula.Length)
                    z2 = "";
                else
                    z2 = formula.Substring(a, 2);

                if (z2 == "&&" || z2 == "||" || z2 == "<=" || z2 == ">=" || z2 == "==" || z2 == "!=")
                {
                    if (a - last > 0)
                    { //Pridá premennú a znamienko
                        Add(formula.Substring(last, a - last).Trim());
                        Add(z2);

                        last = a + 2;
                    }
                    else
                    {    //Pridá znamienko
                        Add(z2);
                        last = a + 2;
                    }
                }
                else if (z1 == "!" || z1 == "<" || z1 == ">" || z1 == "(" || z1 == ")")
                {
                    if (a - last > 0)
                    { //Pridá premennú a znamienko
                        Add(formula.Substring(last, a - last).Trim());
                        Add(z1);

                        last = a + 1;
                    }
                    else
                    {    //Pridá znamienko
                        Add(z1);
                        last = a + 1;
                    }
                }
                else if (a == formula.Length - 1)
                {
                    Add(formula.Substring(last, a - last + 1).Trim());
                    last = a + 1;
                }
            } //End For

        }

        public string Convert()
        {
            SplitFormula();

            int ParMax = 0;
            int ParLevel = 0;

            string res = "";
            string tmp = "", lbl = "", lbl2 = "";

            //Spočítanie zátvoriek
            for (int a = 0; a < parts.Count; a++)
            {
                if (parts[a] == "(") ParLevel++;
                if (parts[a] == ")") ParLevel--;
                if (ParLevel > ParMax) ParMax = ParLevel;
            }

            //Konverzia
            for (int b = ParMax; b >= 0; b--)
            {
                //Najväčšia priorita
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Negácia NOT
                        if (parts[a] == "!" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            res += "LOAD =1";
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                    }
                }

                //Väčšia priorita                                
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Väčšie >
                        if (parts[a] == ">" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JGZERO " + lbl + Environment.NewLine;
                            res += "LOAD =0" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Menšie <
                        else if (parts[a] == "<" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "JGTZ " + lbl + Environment.NewLine;
                            res += "LOAD =0" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Väčšie rovné >=
                        else if (parts[a] == ">=" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JGTZ " + lbl + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =0" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Menšie rovné <=
                        else if (parts[a] == "<=" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "JGTZ " + lbl + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =0" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Rovné ==
                        else if (parts[a] == "==" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =0" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Nerovné !=
                        else if (parts[a] == "!=" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("true");
                            lbl2 = ic.AddLabel("res");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =1" + Environment.NewLine;
                            res += "JUMP " + lbl2 + Environment.NewLine;
                            res += lbl + ": ";
                            res += "LOAD =0" + Environment.NewLine;
                            res += lbl2 + ": ";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }

                    }
                }

                //Menšia priorita
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Logické AND
                        if (parts[a] == "&&" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("false");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "MULT " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl + ":";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Logické OR
                        else if (parts[a] == "||" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");
                            //Vytvorenie návestia
                            lbl = ic.AddLabel("false");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "ADD " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "JZERO " + lbl + Environment.NewLine;
                            res += "LOAD =1" + Environment.NewLine;
                            res += lbl + ":";
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                    }
                }

                //Zátvorky
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;

                    if (ParLevel == b)
                    {
                        if (parts[a] == "(" || parts[a] == ")")
                        {
                            if (a >= 0 && a <= parts.Count - 1)
                            {
                                if (parts[a] == ")") ParLevel--;
                            }

                            parts.RemoveAt(a);
                            a--;
                        }
                    }
                    else
                    {
                        if (a >= 0 && a <= parts.Count - 1)
                        {
                            if (parts[a] == ")") ParLevel--;
                        }
                    }
                }

            } //End For - Konvertovací cyklus

            this.resVariable = ic.GetVariable(parts[0]);
            return res;
        } //End Function

    }
}
