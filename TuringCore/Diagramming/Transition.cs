using System.Collections.Generic;

namespace FEI.TuringCore.Diagramming {
	//Prechod
	public class Transition
    {
        private State state = new State();   // Prechod do stavu state
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private string comment;              // Komentar prechodu
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }

        private List<string> functions = new List<string>();
        public List<string> Functions
        {
            get { return functions; }
            set { functions = value; }
        } 

        public Transition(State state, string function, string comment)
        {
            this.state = state;
            this.functions.Add(function);
            this.comment = comment;
        }
    }    
}
