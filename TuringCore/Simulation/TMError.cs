namespace FEI.TuringCore.Simulation {
	public class TMError
    {
        private string name;         // Nazov chyby
        public string Name
        {
            get => name;
            set => name = value;
        }

        private string description;  // Popis chyby
        public string Description
        {
            get => description;
            set => description = value;
        }

        private int line;        // Riadok v zdrojovom texte
        public int Line
        {
            get => line;
            set => line = value;
        }

        private int function;    // Funkcia v ramci riadku
        public int Function
        {
            get => function;
            set => function = value;
        }

        public TMError(string name, string description, int line, int function)
        {
            this.name = name;
            this.description = description;
            this.line = line;
            this.function = function;
        }

        public override string ToString()
        {
            return "Riadok " + (line + 1) + ", funkcia " + (function + 1) + ": " + name + "   " + description;
        }
    }
}
