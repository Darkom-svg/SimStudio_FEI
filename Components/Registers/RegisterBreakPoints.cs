using System.Collections.Generic;

namespace DusanRodina.SimStudio.Components.Registers {
	//Body prerušenia
	public class RegisterBreakPointList
    {        
        private List<BreakPoint> breakPoints = new List<BreakPoint>();

        public List<BreakPoint> BreakPoints
        {
            get { return breakPoints; }
            set { breakPoints = value; }
        }

        public bool HasBreakpoint(int registerIndex)
        {
            for (int a = 0; a < breakPoints.Count; a++)
            {
                if (breakPoints[a].RegisterIndex == registerIndex)
                {
                    return true;
                };
            }
            return false;
        }

        public void RemoveBreakpointFor(int registerIndex)
        {
            for (int a = 0; a < breakPoints.Count; a++)
            {
                if (breakPoints[a].RegisterIndex == registerIndex)
                {
                    breakPoints.RemoveAt(a);
                    return;
                };
            }            
        }

        public BreakPoint GetBreakpoint(int registerIndex)
        {
            for (int a = 0; a < breakPoints.Count; a++)
            {
                if (breakPoints[a].RegisterIndex == registerIndex)
                {
                    return breakPoints[a];
                };
            }
            return default(BreakPoint);
        }
    }

}
