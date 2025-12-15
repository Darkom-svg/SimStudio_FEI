using DusanRodina.TuringCore.Simulation;

namespace DusanRodina.TuringCore.Components {
	public class TransitionEventArgs
    {
        private Transition transition;
        public Transition Transition
        {
            get { return transition; }
            set { transition = value; }
        }

        public TransitionEventArgs(Transition transition)
        {
            this.transition = transition;
        }
    }
}
