using DusanRodina.SimStudio.Components;
using DusanRodina.SimStudio.Components.Registers;

namespace DusanRodina.RandomAccessMachine.Simulation {
	//Inštrukcia RAM Simulátora
	public class RAMInstruction
    {
        public InstructionType Command; 
        public InfiniteInteger Operand; 
        public OperationType OperandType;          

        public bool Stop;   
        public bool Skip;  

        public RAMInstruction(InstructionType Command, InfiniteInteger Operand, OperationType OperandType)
        {
            this.Command = Command;
            this.Operand = Operand;
            this.OperandType = OperandType;            

            this.Stop = false;
            this.Skip = false;
        }

        public InfiniteInteger GetValue(ref InfiniteRegisters Regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Regs[Operand].Value;
                case OperationType.Constant:
                    return Operand;
                case OperationType.Indirect:
                    return Regs[Regs[Operand].Value].Value;
                default:
                    return InfiniteInteger.zero;
            }
        }

        public long GetValue(ref SmallRegisters Regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Regs[Operand.ToLong()].Value;
                case OperationType.Constant:
                    return Operand.ToLong();
                case OperationType.Indirect:
                    return Regs[Regs[Operand.ToLong()].Value].Value;
                default:
                    return 0;
            }
        }

        public InfiniteInteger GetAddress(ref InfiniteRegisters Regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Operand;
                case OperationType.Indirect:
                    return Regs[Operand].Value;
                default:
                    return InfiniteInteger.negativeOne;

            }
        }

        public long GetAddress(ref SmallRegisters Regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Operand.ToLong();
                case OperationType.Indirect:
                    return Regs[Operand.ToLong()].Value;
                default:
                    return -1;

            }
        }

        public long GetOperandCost(ref InfiniteRegisters Regs)
        {
            switch (OperandType)
            {
                case OperationType.Constant:
                    return Simulator.LogCost(this.Operand);
                case OperationType.Address:
                    return Simulator.LogCost(this.Operand) + Simulator.LogCost(Regs[Operand].Value);
                case OperationType.Indirect:
                    return Simulator.LogCost(this.Operand) + Simulator.LogCost(Regs[Operand].Value)
                        + Simulator.LogCost(Regs[Regs[Operand].Value].Value);
                default:
                    return -1;

            }
        }
    }
}
