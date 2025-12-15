using System;
using System.Collections.Generic;

namespace DusanRodina.RandomAccessMachine.Conversion {
	//Konvertor aritmetických vzorcov do RAM kódu
	public class ArithmeticFormulaConvertor
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

            char z;
            int last = 0;

            for (int a = 0; a < formula.Length; a++)
            {
                z = formula[a];

                if (z == '*' || z == '/' || z == '+' || z == '-' || z == '^' || z == '!' || z == '%' || z == '(' || z == ')')
                {
                    if (a - last > 0)
                    { //Pridá premennú a znamienko
                        Add(formula.Substring(last, a - last).Trim());
                        Add(z);

                        last = a + 1;
                    }
                    else
                    {    //Pridá znamienko
                        Add(z);
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
            string tmp = "";

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
                //Mocnina
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Mocnina
                        if (parts[a] == "^" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            if (int.Parse(parts[a - 1]) == 0)
                            {
                                res += "LOAD =1" + Environment.NewLine;
                                res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;
                            }
                            else
                            {
                                res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                                int c = int.Parse(parts[a + 1]);
                                for (int n = 1; n < c; n++)
                                    res += "MULT " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                                res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;
                            }

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                    }
                }

                //Krát a delené
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Krát
                        if (parts[a] == "*" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "MULT " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Delené
                        else if (parts[a] == "/" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "DIV " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                    }
                }

                //Plus a mínus
                ParLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") ParLevel++;
                    if (parts[a] == ")") ParLevel--;

                    if (ParLevel == b && a > 0 && a < parts.Count - 1)
                    {
                        //Plus
                        if (parts[a] == "+" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "ADD " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
                            res += "STORE " + ic.GetVariableRegister(tmp) + Environment.NewLine;

                            parts[a - 1] = tmp;
                            parts.RemoveRange(a, 2);
                            a -= 2;
                        }
                        //Mínus
                        else if (parts[a] == "-" && parts[a - 1] != ")" && parts[a + 1] != "(")
                        {
                            //Vytvorenie dočasnej premennej                            
                            tmp = ic.AddVariable("tmp");

                            res += "LOAD " + ic.GetVariableRegister(parts[a - 1]) + Environment.NewLine;
                            res += "SUB " + ic.GetVariableRegister(parts[a + 1]) + Environment.NewLine;
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
        } 

    }
}
