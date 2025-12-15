using System;
using System.Collections.Generic;

namespace DusanRodina.SimStudio.Components.Registers {
	public class SmallRegisters
    {             
        public Dictionary<long, SmallRegisterCell> regs = new Dictionary<long, SmallRegisterCell>();

        public SmallRegisterCell this[int i]
        {
            get
            {                
                if (regs.ContainsKey(i))
                {
                    return regs[i];
                }
                else
                {
                    return new SmallRegisterCell(0, null);
                }
            }
            set
            {                
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

        public SmallRegisterCell this[long i]
        {
            get
            {                
                if (regs.ContainsKey(i))
                {
                    return regs[i];
                }
                else
                {
                    return new SmallRegisterCell(0, null);
                }
            }
            set
            {                
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
        

        //Zmaže registre aj s ich názvami
        public void Clear()
        {
            regs.Clear();
        }

        //Zmaže registre
        public void ClearValues()
        {
            Dictionary<long, SmallRegisterCell>.Enumerator en = regs.GetEnumerator();
            while (en.MoveNext())
            {
                regs[en.Current.Key].Clear();
            }
        }

        //Nastaví hodnotu registra
        public void SetValue(long index, long value)
        {
            checked
            {
                if (!regs.ContainsKey(index))
                {
                    regs.Add(index, new SmallRegisterCell(value, null));
                }
                else
                {
                    regs[index].Value = value;
                }
            }
        }

        //Inkrementuje hodnotu registra index o hodnotu value
        public void IncrementValue(long index, long value)
        {
            checked
            {
                if (!regs.ContainsKey(index))
                {
                    regs.Add(index, new SmallRegisterCell(value, null));
                }
                else
                {
                    regs[index].Value += value;
                }
            }
        }

        //Inkrementuje hodnotu registra index o hodnotu value
        public void IncrementValue(int index, int value)
        {
            checked
            {
                if (!regs.ContainsKey(index))
                {
                    regs.Add(index, new SmallRegisterCell(value, null));
                }
                else
                {
                    regs[index].Value += value;
                }
            }
        }

        //Vynásobí register hodnotou
        public void MultValue(long index, long value)        
        {
            checked
            {
                if (!regs.ContainsKey(index))
                {
                    regs.Add(index, new SmallRegisterCell(value, null));
                }
                else
                {
                    regs[index].Value *= value;
                }
            }
        }

        public void DefineRegister(string definition)
        {
            string[] parts = definition.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
            {
                long regindex = Functions.ToValue(parts[0]);
                long defValue = 0;

                // štandardna hodnota
                string part;
                for (int i = 0; i < parts.Length; i++)
                {
                    part = parts[i];
                    if (part.Contains("="))
                    {
                        if (part == "=")
                        {
                            if (parts.Length > i + 1) defValue = Functions.ToValue(parts[i + 1]);
                        }
                        else
                        {
                            defValue = Functions.ToValue(part.Substring(part.IndexOf('=') + 1));
                        }
                    }
                }

                // pridanie registra
                if (!regs.ContainsKey(regindex))
                {
                    regs.Add(regindex, new SmallRegisterCell(0,
                        string.Join(" ", parts, 1, parts.Length - 1), defValue));
                }
                else
                {
                    regs[regindex].Name = string.Join(" ", parts, 1, parts.Length - 1);
                    regs[regindex].DefValue = defValue;
                }
            }
        }

        public InfiniteRegisters ConvertToInfiniteRegisters()
        {
            InfiniteRegisters retval = new InfiniteRegisters() ;            

            foreach (KeyValuePair<long, SmallRegisterCell> r in regs)
            {
                RegisterCell cell = new RegisterCell();
                cell.Value = new InfiniteInteger(r.Value.Value);
                cell.Name = r.Value.Name;
                cell.DefValue = new InfiniteInteger(r.Value.DefValue);
                retval.regs.Add(new InfiniteInteger(r.Key), cell);
            }

            return retval;            
        }
    }
}
