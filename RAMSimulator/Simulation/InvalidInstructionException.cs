using System;

namespace FEI.RandomAccessMachine.Simulation {
	public class InvalidInstructionException : InvalidOperationException
    {
        private InstructionType type;
        public InstructionType Type
        {
            get { return type; }
            set { type = value; }
        }

        public InvalidInstructionException(InstructionType type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return "Nepovolená inštrukcia " + type.ToString() + ".";
        }
    }
}
