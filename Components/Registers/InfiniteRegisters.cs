using System;
using System.Collections.Generic;

namespace DusanRodina.SimStudio.Components.Registers {
	public class InfiniteRegisters
    {        
        public Dictionary<InfiniteInteger, RegisterCell> regs = new Dictionary<InfiniteInteger, RegisterCell>();        
        

        public RegisterCell this[int index]
        {
            get 
            {
                InfiniteInteger i = new InfiniteInteger(index);
                if (regs.ContainsKey(i))
                {
                    return regs[i];
                }
                else
                {
                    return new RegisterCell(0, null);
                }
            }
            set 
            {
                InfiniteInteger i = new InfiniteInteger(index);
                if (regs.ContainsKey(i))
                {
                    regs[i] = value; 
                }
                else
                {
                    regs.Add(i, value);                    
                }                
            }
        }

        public RegisterCell this[long index]
        {
            get
            {
                InfiniteInteger i = new InfiniteInteger(index);
                if (regs.ContainsKey(i))
                {
                    return regs[i];
                }
                else
                {
                    return new RegisterCell(0, null);
                }
            }
            set
            {
                InfiniteInteger i = new InfiniteInteger(index);
                if (regs.ContainsKey(i))
                {
                    regs[i] = value;
                }
                else
                {
                    regs.Add(i, value);
                }
            }
        }

        public RegisterCell this[InfiniteInteger index]
        {
            get
            {                
                if (regs.ContainsKey(index))
                {
                    return regs[index];
                }
                else
                {
                    return new RegisterCell(0, null);
                }
            }
            set
            {
                if (regs.ContainsKey(index))
                {
                    regs[index] = value;
                }
                else
                {
                    regs.Add(index, value);
                }
            }
        }

        //Zmaže registre aj s ich názvami
        public void Clear()
        {            
            regs.Clear();         
        }

        //Zmaže registre
        public void ClearValues()
        {
            Dictionary<InfiniteInteger, RegisterCell>.Enumerator en = regs.GetEnumerator();
            while (en.MoveNext()) 
            {
                regs[en.Current.Key].Clear();                
            }            
        }

        //Nastaví hodnotu registra
        public void SetValue(InfiniteInteger index, InfiniteInteger value)
        {            
            if (!regs.ContainsKey(index))
            {
                regs.Add(index, new RegisterCell(value, null));
            }
            else
            {
                regs[index].Value = value;
            }
        }

        //Nastaví hodnotu registra
        public void SetValue(long index, long value)
        {
            InfiniteInteger i = new InfiniteInteger(index);
            if (!regs.ContainsKey(i))
            {
                regs.Add(i, new RegisterCell(new InfiniteInteger( value), null));
            }
            else
            {
                regs[i].Value =  new InfiniteInteger(value);
            }
        }

        //Inkrementuje hodnotu registra index o hodnotu value
        public void IncrementValue(InfiniteInteger index, InfiniteInteger value)
        {          
            if (!regs.ContainsKey(index))
            {
                regs.Add(index, new RegisterCell(value, null));
            }
            else
            {
                regs[index].Value += value;
            }
        }

        //Inkrementuje hodnotu registra index o hodnotu value
        public void IncrementValue(int index, int value)
        {
            if (!regs.ContainsKey(new InfiniteInteger(index)))
            {
                regs.Add(new InfiniteInteger(index), new RegisterCell(new InfiniteInteger(value), null));
            }
            else
            {
                regs[new InfiniteInteger(index)].Value += new InfiniteInteger(value);
            }
        }

        //Vynásobí register hodnotou
        public void MultValue(InfiniteInteger index, InfiniteInteger value)
        {
            if (!regs.ContainsKey(index))
            {
                regs.Add(index, new RegisterCell(value, null));
            }
            else
            {
                regs[index].Value *= value;
            }
        }

        public void GetData(SmallRegisters smallRegs)
        {
            foreach (KeyValuePair<long, SmallRegisterCell> r in smallRegs.regs)
            {                
                SetValue(new InfiniteInteger(r.Key), new InfiniteInteger(r.Value.Value));
            }
        }

        public void DefineRegister(string definition)
        {
            string[] parts = definition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                InfiniteInteger regindex = new InfiniteInteger(parts[0]);
                InfiniteInteger defValue = new InfiniteInteger(0);

                // štandardna hodnota
                string part;
                for (int i = 0; i < parts.Length; i++)
                {
                    part = parts[i];
                    if (part.Contains("="))
                    {
                        if (part == "=")
                        {
                            if (parts.Length > i + 1) defValue = new InfiniteInteger(parts[i + 1]);
                        }
                        else
                        {
                            defValue = new InfiniteInteger(part.Substring(part.IndexOf('=') + 1));
                        }
                    }
                }

                // pridanie registra
                if (!regs.ContainsKey(regindex))
                {
                    regs.Add(regindex, new RegisterCell(InfiniteInteger.zero,
                        string.Join(" ", parts, 1, parts.Length - 1), defValue));
                }
                else
                {
                    regs[regindex].Name = string.Join(" ", parts, 1, parts.Length - 1);
                    regs[regindex].DefValue = defValue;
                }
            }
        }        

    }
}
