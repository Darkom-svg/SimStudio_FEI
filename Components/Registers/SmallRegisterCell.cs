namespace DusanRodina.SimStudio.Components.Registers {
	public class SmallRegisterCell 
    {
        private long value = 0;
        private string name = null;
        private long defValue = 0;

        public SmallRegisterCell() { }
        public SmallRegisterCell(long value, string name)
        {                        
            this.value = value;
            this.name = name;
        }
        public SmallRegisterCell(int value, string name)
        {
            this.value = value;
            this.name = name;
        }
        public SmallRegisterCell(long value, string name, long defValue)
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

        public long Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public long DefValue
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
