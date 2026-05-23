using System;

namespace FEI.RandomAccessMachine.Simulation {
	public class CompilerException : Exception
    {
        private int lineNumber;
        public int LineNumber
        {
            get => lineNumber;
            set => lineNumber = value;
        }

        public CompilerException(int lineNumber, Exception innerException)
            : base("Error on line " + lineNumber + ". ", innerException)
        {
            this.lineNumber = lineNumber;
        }

        public override string ToString()
        {
            return "Chyba na riadku " + lineNumber + ": " + InnerException.ToString();
        }
    }
}
