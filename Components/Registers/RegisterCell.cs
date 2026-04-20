namespace FEI.SimStudio.Components.Registers {
	public class RegisterCell 
    {
        private InfiniteInteger value = InfiniteInteger.zero;
        private string name = null;
        private InfiniteInteger defValue = InfiniteInteger.zero;

        public RegisterCell() { }
        public RegisterCell(long value, string name)
        {                        
            this.value = new InfiniteInteger(value);
            this.name = name;
        }
        public RegisterCell(InfiniteInteger value, string name)
        {
            this.value = value;
            this.name = name;
        }
        public RegisterCell(InfiniteInteger value, string name, InfiniteInteger defValue)
        {
            this.value = value;
            this.name = name;
            this.defValue = defValue;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public InfiniteInteger Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public InfiniteInteger DefValue
        {
            get { return this.defValue; }
            set { this.defValue = value; }
        }

        public void Clear()
        {
            this.value = this.defValue;
        }
    }
}
