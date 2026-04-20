namespace FEI.RandomAccessMachine.Conversion {
	//Premenná medzikódu
	public class ICVariable
    {
        public string name;     //Meno premennej
        public int index;       //Index premennej

        public ICVariable(string name, int index)
        {
            this.name = name.Trim();
            this.index = index;
        }

        public override string ToString()
        {
            return name + " (index = " + index + ")";
        }
    }
}
