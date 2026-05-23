using System;
using System.Collections.Generic;

namespace FEI.RandomAccessMachine.Conversion {
	//Konvertor aritmetických vzorcov do RAM kódu
	public class ArithmeticFormulaConvertor
    {
        public IntermediateCode ic;

        public string formula;
        private List<string> parts = new List<string>();

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

            int parMax = 0;
            int parLevel = 0;

            string res = "";
            string tmp;

            //Spočítanie zátvoriek
            foreach (var part in parts)
            {
                if (part == "(") parLevel++;
                if (part == ")") parLevel--;
                if (parLevel > parMax) parMax = parLevel;
            }

            //Konverzia
            for (int b = parMax; b >= 0; b--)
            {
                //Mocnina
                parLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") parLevel++;
                    if (parts[a] == ")") parLevel--;

                    if (parLevel == b && a > 0 && a < parts.Count - 1)
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
                parLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") parLevel++;
                    if (parts[a] == ")") parLevel--;

                    if (parLevel == b && a > 0 && a < parts.Count - 1)
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
                parLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") parLevel++;
                    if (parts[a] == ")") parLevel--;

                    if (parLevel == b && a > 0 && a < parts.Count - 1)
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
                parLevel = 0;
                for (int a = 0; a < parts.Count; a++)
                {
                    if (parts[a] == "(") parLevel++;

                    if (parLevel == b)
                    {
                        if (parts[a] == "(" || parts[a] == ")")
                        {
                            if (a >= 0 && a <= parts.Count - 1)
                            {
                                if (parts[a] == ")") parLevel--;
                            }

                            parts.RemoveAt(a);
                            a--;
                        }
                    }
                    else
                    {
                        if (a >= 0 && a <= parts.Count - 1)
                        {
                            if (parts[a] == ")") parLevel--;
                        }
                    }
                }

            } //End For - Konvertovací cyklus

            this.resVariable = ic.GetVariable(parts[0]);
            return res;
        } 

    }
}
