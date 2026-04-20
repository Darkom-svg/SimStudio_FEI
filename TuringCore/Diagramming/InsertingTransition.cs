using System.Drawing;

namespace FEI.TuringCore.Diagramming {
	//Vkladaný (nedokončený) prechod
	public class InsertingTransition
    {
        private State fromState;
        public State FromState
        {
            get { return fromState; }
            set { fromState = value; }
        }

        private Point toPosition;
        public Point ToPosition
        {
            get { return toPosition; }
            set { toPosition = value; }
        }

        private State toState;
        public State ToState
        {
            get { return toState; }
            set { toState = value; }
        }
    }
}
