using System.Collections.Generic;

namespace FEI.RandomAccessMachine.Conversion {
	//Blok programu
	public class ICBlock
    {
        public string name; //Názov bloku programu
        public List<ICCommand> program = new List<ICCommand>();     //Program

        public ICBlock(string name)
        {
            this.name = name;
        }
    }
}
