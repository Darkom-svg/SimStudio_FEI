using System.Drawing;

namespace FEI.TuringCore.Diagramming {
	//Vkladaný (nedokončený) prechod
	public class InsertingTransition
    {
        private State fromState;
        public State FromState
        {
            get => fromState;
            set => fromState = value;
        }

        private Point toPosition;
        public Point ToPosition
        {
            get => toPosition;
            set => toPosition = value;
        }

        private State toState;
        public State ToState
        {
            get => toState;
            set => toState = value;
        }
    }
}
