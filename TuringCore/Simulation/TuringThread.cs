using System;
using System.Collections.Generic;

namespace FEI.TuringCore.Simulation {
	//Vlákno turingovho stroja
	//Nedeterministické stroje budú mať viac vlákien
	public class TuringThread
    {
        #region Fields
        private bool terminated = false;

        private string currentState;
        private Transition lastUsedTransition;        
        //int vPosition;
        private List<InfiniteTape> tapes = new List<InfiniteTape>();
        #endregion

        #region Properties
        //Log
        private TuringMachineLog log = new TuringMachineLog();
        public TuringMachineLog Log
        {
            get => log;
            set => log = value;
        }

        //Vlákno je/nie je ukončené
        public bool Terminated
        {
            get => terminated;
            set => terminated = value;
        }

        //Aktuálny stav
        public string CurrentState
        {
            get => currentState;
            set => currentState = value;
        }

        //Naposledy pouźitý prechod
        public Transition LastUsedTransition
        {
            get => lastUsedTransition;
            set => lastUsedTransition = value;
        }

        private Stack<string> stack = new Stack<string>();
        public Stack<string> Stack
        {
            get => stack;
            set => stack = value;
        }

        //Páska
        public List<InfiniteTape> Tapes
        {
            get => tapes;
            set => tapes = value;
        }        

        public List<int> HeadPositions
        {
            get
            {
                List<int> retval = new List<int>(tapes.Count);
                foreach (InfiniteTape tape in tapes)
                {
                    retval.Add(tape.HeadPosition);
                }
                return retval;
            }
            set
            {
                for (int i = 0; i < Math.Min(value.Count, tapes.Count); i++)
                {
                    tapes[i].HeadPosition = value[i];
                }
            }
        }
        #endregion

        public TuringThread(string currentState, List<InfiniteTape> tapes, TuringMachineLog log)
        {
            this.CurrentState = currentState;            
            this.Tapes = tapes;
            this.log = log;
            this.stack.Push("Z");
        }        

        //Aktuálny symbol
        public string GetCurrentSymbol(int tapeIndex)
        {
            if (tapeIndex >= tapes.Count) return InfiniteTape.Blank;

            if (InfiniteTape.IsBlank(tapes[tapeIndex].CurrentSymbol))
                return InfiniteTape.Blank;
            else
                return tapes[tapeIndex].CurrentSymbol;
        }

        // Nasledujúci symbol
        public string GetNextSymbol(int tapeIndex, bool toRight)
        {
            if (InfiniteTape.IsBlank(tapes[tapeIndex].GetNextSymbol(toRight)))
                return InfiniteTape.Blank;
            else
                return tapes[tapeIndex].GetNextSymbol(toRight);
        }

        public void SetCurrentSymbol(int tapeIndex, string symbol)
        {            
            tapes[tapeIndex].CurrentSymbol =symbol;
        }        

        public void MoveHeadLeft(int tapeIndex)
        {
            Tapes[tapeIndex].MoveHeadLeft();
        }

        public void MoveHeadRight(int tapeIndex)
        {
            Tapes[tapeIndex].MoveHeadRight();
        }

    }
}
