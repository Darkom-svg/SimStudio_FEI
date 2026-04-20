namespace FEI.RandomAccessMachine.Simulation {
	//Návestie
	public class Label
    {
        private string name;
        private int line;

        public Label(string Name, int Line)
        {
            this.Name = Name;
            this.Line = Line;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Line
        {
            get { return line; }
            set { line = value; }
        }
        
    }
}
