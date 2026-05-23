using System.Collections.Generic;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Registers;

namespace FEI.RandomAccessMachine.Conversion {
	//Prechodný kód
	public class IntermediateCode
    {
        private int varcounter = 0;
        public List<ICVariable> vars = new List<ICVariable>();      //Premenné
        private List<string> labels = new List<string>();            //Návestia

        public ICBlock maincode = new ICBlock("main");   //Kód

        //Vráti index premennej, po použití metódy sa inkrementuje počítadlo
        public int GetVarIndex()
        {
            varcounter++;
            return varcounter;
        }

        //Vráti premennú s daným menom
        public ICVariable GetVariable(string name)
        {
            name = name.Trim();
            foreach (var variable in vars)
            {
                if (variable.name == name) return variable;
            }
            return null;
        }

        //Vráti premennú s daným menom alebo číslo
        public string GetVariableRegister(string name)
        {
            if (Functions.IsNumber(name)) return "=" + name;

            foreach (var variable in vars)
            {
                if (variable.name == name) return variable.index.ToString();
            }
            return null;
        }

        //Vráti voľný názov návestia (názov obsahuje zadaný reťazec)
        internal string GetLabel(string name)
        {
            string namebase = name;
            int index = 1;

            while (labels.Contains(name))
            {
                name = namebase + index.ToString();
                index++;
            }
            return name;
        }

        //Pridá návestie (použie nepoužitý názov odvodený od name alebo name)
        internal string AddLabel(string name)
        {
            string namebase = name;
            int index = 1;

            while (labels.Contains(name))
            {
                name = namebase + index.ToString();
                index++;
            }
            labels.Add(name);
            return name;
        }

        //Pridá premennú a vráti názov pridanej premennej (názov sa automaticky zmení na nepoužitý názov)
        internal string AddVariable(string name)
        {
            string namebase = name;
            int index = 1;

            //Nájdenie voľného názvu
            while (ExistsVariable(name))
            {
                name = namebase + index.ToString();
                index++;
            }
            //Pridanie
            vars.Add(new ICVariable(name, GetVarIndex()));

            return name;
        }

        private bool ExistsVariable(string name)
        {
            foreach (var variable in this.vars)
            {
                if (variable.name == name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
