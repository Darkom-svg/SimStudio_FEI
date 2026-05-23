using FEI.SimStudio.Components;
using FEI.SimStudio.Components.Registers;

namespace FEI.RandomAccessMachine.Simulation {
	//Inštrukcia RAM Simulátora
	public class RAMInstruction
    {
        public InstructionType Command; 
        public InfiniteInteger Operand; 
        public OperationType OperandType;          

        public bool Stop;   
        public bool Skip;  

        public RAMInstruction(InstructionType command, InfiniteInteger operand, OperationType operandType)
        {
            this.Command = command;
            this.Operand = operand;
            this.OperandType = operandType;            

            this.Stop = false;
            this.Skip = false;
        }

        public InfiniteInteger GetValue(ref InfiniteRegisters regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return regs[Operand].Value;
                case OperationType.Constant:
                    return Operand;
                case OperationType.Indirect:
                    return regs[regs[Operand].Value].Value;
                default:
                    return InfiniteInteger.Zero;
            }
        }

        public long GetValue(ref SmallRegisters regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return regs[Operand.ToLong()].Value;
                case OperationType.Constant:
                    return Operand.ToLong();
                case OperationType.Indirect:
                    return regs[regs[Operand.ToLong()].Value].Value;
                default:
                    return 0;
            }
        }

        public InfiniteInteger GetAddress(ref InfiniteRegisters regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Operand;
                case OperationType.Indirect:
                    return regs[Operand].Value;
                default:
                    return InfiniteInteger.NegativeOne;

            }
        }

        public long GetAddress(ref SmallRegisters regs)
        {
            switch (OperandType)
            {
                case OperationType.Address:
                    return Operand.ToLong();
                case OperationType.Indirect:
                    return regs[Operand.ToLong()].Value;
                default:
                    return -1;

            }
        }

        public long GetOperandCost(ref InfiniteRegisters regs)
        {
            switch (OperandType)
            {
                case OperationType.Constant:
                    return Simulator.LogCost(this.Operand);
                case OperationType.Address:
                    return Simulator.LogCost(this.Operand) + Simulator.LogCost(regs[Operand].Value);
                case OperationType.Indirect:
                    return Simulator.LogCost(this.Operand) + Simulator.LogCost(regs[Operand].Value)
                        + Simulator.LogCost(regs[regs[Operand].Value].Value);
                default:
                    return -1;

            }
        }
    }
}
