namespace DusanRodina.SimStudio.Components.Registers {
	//Bod prerušenia
	public class BreakPoint
    {
        int registerIndex = 0;

        int value = 0;
        bool atValue = false;
        bool atReading = false;
        bool atWriting = false;

        public int RegisterIndex
        {
            get { return registerIndex; }
            set { registerIndex = value; }
        }

        public bool AtWriting
        {
            get { return atWriting; }
            set { atWriting = value; }
        }

        public bool AtReading
        {
            get { return atReading; }
            set { atReading = value; }
        }

        public bool AtValue
        {
            get { return atValue; }
            set { atValue = value; }
        }

        public int Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
