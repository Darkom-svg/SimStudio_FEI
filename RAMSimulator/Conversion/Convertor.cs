using System;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.RandomAccessMachine.Conversion {
	public class Convertor
    {
        public string ConvertToRAMCode(IntermediateCode ic)
        {
            string res = "";
            string program = "";

            //Vytvorenie programu
            program = ConvertICBlockToRAM(ic, ic.maincode);

            //Vloženie premenných
            res += "//Pomenovanie registrov";
            res += Environment.NewLine;
            foreach (var var in ic.vars)
            {
                res += "//#" + var.index.ToString() + " ";
                res += var.name;
                res += Environment.NewLine;
            }
            res += Environment.NewLine;

            //Vloženie programu
            res += program;

            //Zastavenie
            res += "HALT" + Environment.NewLine;

            return res;
        }

        private string ConvertICBlockToRAM(IntermediateCode ic, ICBlock block)
        {
            string res = "";

            LogicFormulaConvertor lc;
            ArithmeticFormulaConvertor fc;

            //Vloženie kódu
            foreach (var prog in block.program)
            {
                switch (prog.type)
                {
                    //case ICCommandTypes.Print: //Výpis na pásku ----------------------------------------------------
                    //    {
                    //        res += "//Vypis " + (string)block.program[i].param[0];
                    //        res += Environment.NewLine;

                    //        if (Components.Functions.IsNumber((string)block.program[i].param[1]))
                    //        {
                    //            res += "WRITE " + (string)block.program[i].param[1];
                    //            res += Environment.NewLine;

                    //            if (ic.GetVariable((string)block.program[i].param[0]) == null)
                    //            {
                    //                MessageBox.Show("Premenná " + block.program[i].param[0] + " nie je definovaná.");
                    //                return null;
                    //            }

                    //            res += "STORE " + ic.GetVariable((string)block.program[i].param[0]).index.ToString();
                    //            res += Environment.NewLine;
                    //        }
                    //        else
                    //        {

                    //        }
                    //    }
                    //    break;
                    case ICCommandTypes.Assignment: //Priradenie ----------------------------------------------------
                    {
                        res += "//Priradenie premennej " + (string)prog.param[0];
                        res += Environment.NewLine;

                        if (Functions.IsNumber((string)prog.param[1]))
                        {
                            res += "LOAD =" + (string)prog.param[1];
                            res += Environment.NewLine;

                            if (ic.GetVariable((string)prog.param[0]) == null)
                            {
                                MessageBox.Show("Premenná " + prog.param[0] + " nie je definovaná.");
                                return null;
                            }

                            res += "STORE " + ic.GetVariable((string)prog.param[0]).index.ToString();
                            res += Environment.NewLine;
                        }
                        else
                        {
                            //Vypočítanie
                            fc = new ArithmeticFormulaConvertor();
                            fc.ic = ic;
                            fc.formula = (string)prog.param[1];
                            res += fc.Convert();
                            res += Environment.NewLine;

                            res += "LOAD " + fc.resVariable.index.ToString();
                            res += Environment.NewLine;
                            res += "STORE " + ic.GetVariable((string)prog.param[0]).index.ToString();
                            res += Environment.NewLine;
                        }
                    }
                        break;
                    case ICCommandTypes.If: //Podmienka ------------------------------------------------------------                        
                    {
                        res += "//Podmienka";
                        res += Environment.NewLine;

                        string endlabel = "", elselabel = "";

                        //Vyhodnotenie podmienky
                        lc = new LogicFormulaConvertor();
                        lc.ic = ic;
                        lc.formula = (string)prog.param[0];
                        res += lc.Convert();
                        res += Environment.NewLine;

                        //Načítanie vyhodnotenej podmienky
                        res += "LOAD " + lc.resVariable.index.ToString();
                        res += Environment.NewLine;

                        if (prog.param.Count == 2) //Bez ELSE-vetvy
                        {
                            endlabel = ic.AddLabel("end");

                            res += "JZERO " + endlabel;
                            res += Environment.NewLine;
                            //Blok príkazov THEN
                            res += "//Podmienka splnená" + Environment.NewLine;
                            res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[1]);
                            res += Environment.NewLine;
                            res += endlabel + ":";
                            res += Environment.NewLine;
                        }
                        else //S ELSE-vetvou
                        {
                            elselabel = ic.AddLabel("else");
                            endlabel = ic.AddLabel("end");

                            res += "JZERO " + elselabel;
                            res += Environment.NewLine;
                            //Blok príkazov THEN
                            res += "//Podmienka splnená" + Environment.NewLine;
                            res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[1]);
                            res += Environment.NewLine;
                            res += "JUMP " + endlabel;
                            res += Environment.NewLine;
                            //Blok príkazov ELSE
                            res += "//Podmienka  nesplnená" + Environment.NewLine;
                            res += elselabel + ":";
                            res += Environment.NewLine;
                            res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[2]);
                            res += Environment.NewLine;
                            res += endlabel + ":";
                            res += Environment.NewLine;
                        }
                    }
                        break;
                    case ICCommandTypes.While: //While-cyklus ---------------------------------------------------------
                    {
                        res += "//While-cyklus";
                        res += Environment.NewLine;

                        string startlabel = "", endlabel = "";
                        startlabel = ic.AddLabel("start");
                        endlabel = ic.AddLabel("end");

                        //Vyhodnotenie podmienky
                        lc = new LogicFormulaConvertor();
                        lc.ic = ic;
                        lc.formula = (string)prog.param[0];

                        res += startlabel + ": " + Environment.NewLine; //Štart cyklu
                        res += lc.Convert();
                        res += Environment.NewLine;

                        //Načítanie vyhodnotenej podmienky
                        res += "LOAD " + lc.resVariable.index.ToString();
                        res += Environment.NewLine;

                        res += "JZERO " + endlabel;
                        res += Environment.NewLine;

                        //Príkazy cyklu                        
                        res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[1]);
                        res += Environment.NewLine;
                        res += "JUMP " + startlabel;
                        res += Environment.NewLine;

                        //Koniec cyklu
                        res += endlabel + ":";
                        res += Environment.NewLine;
                    }
                        break;

                    case ICCommandTypes.For: //For-cyklus -----------------------------------------------------------
                    {
                        res += "//For-cyklus";
                        res += Environment.NewLine;

                        string startlabel = "", endlabel = "";
                        startlabel = ic.AddLabel("start");
                        endlabel = ic.AddLabel("end");

                        //Počiatočné nastavenie premennej počítadla
                        res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[0]);
                        res += Environment.NewLine;

                        //Vyhodnotenie podmienky
                        lc = new LogicFormulaConvertor();
                        lc.ic = ic;
                        lc.formula = (string)prog.param[1];

                        res += startlabel + ": " + Environment.NewLine; //Štart cyklu
                        res += lc.Convert();
                        res += Environment.NewLine;

                        //Načítanie vyhodnotenej podmienky
                        res += "LOAD " + lc.resVariable.index.ToString();
                        res += Environment.NewLine;

                        res += "JZERO " + endlabel;
                        res += Environment.NewLine;

                        //Príkazy cyklu                        
                        res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[3]);
                        res += Environment.NewLine;

                        //Inkrementovanie počítadla
                        res += ConvertICBlockToRAM(ic, (ICBlock)prog.param[2]);

                        //Návrat na začiatok
                        res += "JUMP " + startlabel;
                        res += Environment.NewLine;

                        //Koniec cyklu
                        res += endlabel + ":";
                        res += Environment.NewLine;
                    }
                        break;

                } //End Switch
            }

            return res;
        }
    }
}
