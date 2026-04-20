using System;
using System.Collections.Generic;
using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Registers;

namespace FEI.AbacusMachine.Simulation {
	public class VirtualAbacusMachine
    {        
        public List<Instruction> program = new List<Instruction>();                
        
        public InfiniteRegisters regs = new InfiniteRegisters();
        public int prgPointer=0;

        public bool noNextStep = false;

        public void AddOp(AMOperation Operation, int RegisterIndex)
        {
            program.Add(new Instruction(Operation, RegisterIndex));            
        }

        public void Parse(string Text)
        {
            int start;
            //Zásobník na zapamätanie si vnorených zátvorkových blokov
            Stack<int> BrStack = new Stack<int>();

            this.program.Clear();            

            //Rozdelenie na riadky
            string[] lines = Text.Split('\n');

            for (int l = 0; l < lines.Length; l++)
            {
                string comment = "";
                string line = lines[l].Trim();
                int to = line.IndexOf("//");

                if (to != -1)
                {
                    comment = line.Substring(line.IndexOf("//") + 2);
                    line = line.Substring(0, line.IndexOf("//")).Trim();

                    //Pomenovanie registrov
                    if (comment.StartsWith("#"))
                    {
                        regs.DefineRegister(comment.Substring(1));
                        
                    }
                }
                else
                {
                    comment = "";
                }

                for (int a = 0; a < line.Length; a++)
                {
                    if (line[a] == 'a')
                    {
                        start = a + 1;
                        do a++;
                        while (a < line.Length && Char.IsDigit(line[a]));

                        this.AddOp(AMOperation.Add, Functions.ToValue(line.Substring(start, a - start)));
                        a--;
                    }
                    else if (line[a] == 's')
                    {
                        start = a + 1;
                        do a++;
                        while (a < line.Length && Char.IsDigit(line[a]));

                        this.AddOp(AMOperation.Sub, Functions.ToValue(line.Substring(start, a - start)));
                        a--;
                    }
                    else if (line[a] == '(')
                    {
                        BrStack.Push(program.Count);
                        this.AddOp(AMOperation.CycleStart, 0);
                    }
                    else if (line[a] == ')' && BrStack.Count > 0)
                    {
                        start = a + 1;
                        do a++;
                        while (a < line.Length && Char.IsDigit(line[a]));

                        int v = BrStack.Peek();
                        this.program[v] = new Instruction(this.program[v].operation,
                                (int)(Functions.ToValue(line.Substring(start, a - start))));
                        this.AddOp(AMOperation.CycleEnd, BrStack.Peek());

                        BrStack.Pop();
                        a--;
                    } //Koniec podmienky
                } //Koniec cyklu a
            } //Koniec cyklu l
        } //Koniec metódy

        public void Reset()
        {
            regs.ClearValues();
            prgPointer = 0;
            noNextStep = false;
        }

        //Celá simulácia
        public void Run()
        {
            prgPointer = 0;
            while (!noNextStep)
            {
                Step();
            }
        }

        //Jeden krok simulácie
        public void Step()
        {
            if (prgPointer >= this.program.Count)
            {
                noNextStep = true;
                return;
            }

            switch (this.program[prgPointer].operation)
            {
                case AMOperation.Add:
                    this.regs.IncrementValue(new InfiniteInteger(this.program[prgPointer].register), InfiniteInteger.one);
                    //this.regs[this.Code[Pos].register].Value += 1;
                    break;
                case AMOperation.CycleStart:
                    if (this.regs[this.program[prgPointer].register].Value == InfiniteInteger.zero)
                    {
                        for (int a = prgPointer; a < this.program.Count; a++)
                        {
                            if (this.program[a].operation == AMOperation.CycleEnd && this.program[a].register == prgPointer)
                            {
                                prgPointer = a;
                                break;
                            }
                        }
                    }
                    break;
                case AMOperation.CycleEnd:
                    prgPointer = this.program[prgPointer].register - 1;
                    break;
                case AMOperation.Sub:
                    this.regs.IncrementValue(new InfiniteInteger(this.program[prgPointer].register), InfiniteInteger.negativeOne);
                    //this.regs[this.Code[Pos].register].Value -= 1;
                    if (this.regs[this.program[prgPointer].register].Value < InfiniteInteger.zero) 
                        this.regs[this.program[prgPointer].register].Value = InfiniteInteger.zero;
                    break;
            }

            prgPointer += 1;            
        }

        //Zmazenie kódu
        public void Clear()
        {
            program.Clear();            
        }

        //Zmazzanie registrov
        public void ClearRegs()
        {
            regs.Clear();
        }
        
        public string RegsToString()
        {
            return regs.ToString();            
        }

        public long GetFirstUnusedRegister()
        {
            InfiniteInteger i = InfiniteInteger.zero;
            while(regs.regs.ContainsKey(i))
            {
                i++;
            }
            return i.ToLong();
        }

        public long GetFirstUnusedRegister(long reg1, long reg2)
        {
            InfiniteInteger i = InfiniteInteger.zero;
            InfiniteInteger ireg1 = new InfiniteInteger(reg1);
            InfiniteInteger ireg2 = new InfiniteInteger(reg2);

            while (regs.regs.ContainsKey(i) || ireg1 == i || ireg2 == i)
            {
                i++;
            }
            return i.ToLong();
        }
    }
}
