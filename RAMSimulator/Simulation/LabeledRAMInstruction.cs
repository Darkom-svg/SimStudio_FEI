using FEI.SimStudio.Components;

namespace FEI.RandomAccessMachine.Simulation {
	public class LabeledRAMInstruction : RAMInstruction
    {
        public string Label;
        public string OpLabel;

        public LabeledRAMInstruction(InstructionType command, InfiniteInteger operand, OperationType operandType, string label, string labelOperand)
            : base(command, operand, operandType)
        {
            this.Command = command;
            this.Operand = operand;
            this.OperandType = operandType;
            this.Label = label;
            this.OpLabel = labelOperand;

            this.Stop = false;
            this.Skip = false;
        }
    }
}
