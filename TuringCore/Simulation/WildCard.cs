namespace FEI.TuringCore.Simulation {
	//Zástupný znak
	public class WildCard
    {
        private string wildcard;
        public string Wildcard
        {
            get => wildcard;
            set => wildcard = value;
        }

        private string[] symbols;
        public string[] Symbols
        {
            get => symbols;
            set => symbols = value;
        }

        public bool ContainsSymbol(string symbol)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == symbol)
                    return true;
            }
            return false;
        }

        internal int IndexOfSymbol(string symbol)
        {
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == symbol)
                    return i;
            }
            return -1;
        }
    }
}
