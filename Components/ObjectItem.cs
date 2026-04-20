namespace FEI.SimStudio.Components {
	public class ObjectItem 
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private object value;
        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ObjectItem(string name, object value)
        {
            this.name = name;
            this.value = value;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
