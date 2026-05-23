using System.Collections.Generic;

namespace FEI.TuringCore.Simulation {
	//Položka logu
	public class LogItem
    {
        private List<InfiniteTape> itapes;  //Páska
        public List<InfiniteTape> Itapes
        {
            get => itapes;
            set => itapes = value;
        }

        private List<int> positions = null;        //Pozícia v páske
        public List<int> Positions
        {
            get => positions;
            set => positions = value;
        }

        private string state;        //Stav
        public string State
        {
            get => state;
            set => state = value;
        }

        private string transition;   //Prechod
        public string Transition
        {
            get => transition;
            set => transition = value;
        }

        private bool tapeChanged;    //Páska zmenená
        public bool TapeChanged
        {
            get => tapeChanged;
            set => tapeChanged = value;
        }

        public LogItem(List<InfiniteTape> itapes, string state, string transition, bool tapeChanged)
        {
            this.itapes = itapes;
            //this.position = position;
            this.state = state;
            this.transition = transition;
            this.tapeChanged = tapeChanged;
        }

        public LogItem(List<InfiniteTape> itapes, List<int> newPositions, string state, string transition, bool tapeChanged)
        {
            this.itapes = itapes;
            this.positions = newPositions;
            this.state = state;
            this.transition = transition;
            this.tapeChanged = tapeChanged;
        }

        public int GetHeadPosition(int tapeIndex)
        {
            if (positions != null)
            {
                return positions[tapeIndex];
            }
            else
            {
                return itapes[tapeIndex].HeadPosition;
            }
        }
    }
}
