namespace FEI.RandomAccessMachine.Simulation {
	//Návestie
	public class Label
    {
        private string name;
        private int line;

        public Label(string name, int line)
        {
            this.Name = name;
            this.Line = line;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Line
        {
            get => line;
            set => line = value;
        }
        
    }
}
