namespace FEI.TuringCore.Simulation {
	//Prechodová funkcia
	public class Transition
    {
        public enum Steps : byte
        {
            Left = 0,
            Right = 1,
            NoMove = 2
        }

        #region Properties
        //Aktuálny stav stroja
        private string currentState;
        public string CurrentState
        {
            get => currentState;
            set => currentState = value;
        }

        //Prečítaný znak
        private string readSymbol = InfiniteTape.Blank;
        public string ReadSymbol
        {
            get => readSymbol;
            set => readSymbol = value;
        }

        //Nový stav
        private string newState;
        public string NewState
        {
            get => newState;
            set => newState = value;
        }
        //Znak, ktorý sa zapíše po prechode funkcie
        private string writeSymbol = InfiniteTape.Blank;
        public string WriteSymbol
        {
            get => writeSymbol;
            set => writeSymbol = value;
        }

        //Krok - vľavo alebo vpravo
        private Steps step;
        public Steps Step
        {
            get => step;
            set => step = value;
        }

        //Počet použití funkcie
        private int useCount;
        public int UseCount
        {
            get => useCount;
            set => useCount = value;
        }

        //Komentár
        private string comment;
        public string Comment
        {
            get => comment;
            set => comment = value;
        }

        private string stackRead;
        public string StackRead
        {
            get => stackRead;
            set => stackRead = value;
        }

        private string stackWrite;
        public string StackWrite
        {
            get => stackWrite;
            set => stackWrite = value;
        }
        #endregion

        #region Constructors
        public Transition()
        {
        }

        public Transition(string currentState, string readSymbol, string newState, string writeSymbol, Steps step)
        {
            this.currentState = currentState;
            this.readSymbol = readSymbol;
            this.newState = newState;
            this.writeSymbol = writeSymbol;
            this.step = step;
            this.useCount = 0;
            this.comment = "";
        }

        public Transition(string currentState, string readSymbol, string newState, string writeSymbol, string stackRead, string stackWrite, Steps step)
        {
            this.currentState = currentState;
            this.readSymbol = readSymbol;
            this.newState = newState;
            this.writeSymbol = writeSymbol;
            this.step = step;
            this.useCount = 0;
            this.comment = "";
            this.stackRead = stackRead;
            this.stackWrite = stackWrite;
        }
        #endregion

        public void Use()
        {
            useCount += 1;
        }

        public void ResetUseCounter()
        {
            useCount = 0;
        }

        public static string StepToString(Transition.Steps step)
        {
            switch (step)
            {
                case Steps.Left:
                    return "L";
                case Steps.Right:
                    return "R";
                case Steps.NoMove:
                    return "0";
                default:
                    return "";
            }
        }

        public string GetReadWriteStepString()
        {
            return readSymbol + ", " + writeSymbol + ", " + StepToString(step);
        }

        public string GetReadWriteStackStepString()
        {
            return "(" + readSymbol + ", " + stackRead + ") (" + writeSymbol + "," + stackWrite + ", " + StepToString(step) + ")";
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(stackRead))
            {
                return "\u03b4 (" + currentState + "," + readSymbol + ") = (" + newState +
                    "," + writeSymbol + "," + StepToString(step) + ")";
            }
            else
            {
                return "\u03b4 (" + currentState + "," + readSymbol + "," + stackRead + ") = (" + newState +
                    "," + writeSymbol + "," + StepToString(step) + "," + stackWrite + ")";
            }
        }
    }    


}
