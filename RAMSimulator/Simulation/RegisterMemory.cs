using System.Collections.Generic;

namespace FEI.RandomAccessMachine.Simulation {
	//Pamäť registrov
	public class RegisterMemory
    {
        private Dictionary<long, RAMRegister> regs = new Dictionary<long, RAMRegister>();

        public RAMRegister this[long index]
        {
            get
            {
                return regs[index];
            }
            set
            {
                regs[index] = value;
            }
        }
    }
}
