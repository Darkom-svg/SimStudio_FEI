using System.Collections.Generic;

namespace FEI.RandomAccessMachine.Conversion {
	//Príkaz medzikódu
	public class ICCommand
    {
        public ICCommandTypes type;     //Typ príkazu
        public List<object> param = new List<object>(); //Parametre príkazu

        //Nový príkaz
        public ICCommand(ICCommandTypes type, params object[] param)
        {
            this.type = type;
            foreach (var par in param)
            {
                this.param.Add(par);
            }
        }
    }
}
