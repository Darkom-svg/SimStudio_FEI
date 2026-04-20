using System.Collections.Generic;

namespace FEI.TuringCore.Simulation {
	public class TuringMachineLog
    {       
        private List<LogItem> items = new List<LogItem>();

        public LogItem this[int index]
        {
            get{return items[index];}
            set{items[index]=value;}
        }

        //Počet záznamov
        public int Count { get { return this.items.Count; } }

        public void AddLogItem(LogItem item)
        {
            this.items.Add(item);
        }

        //Zmaže obsah logu
        public void Clear()
        {
            this.items.Clear();
        }

        public int GetFirstNonBlankCell()
        {
            int first = int.MaxValue;
            for (int i = 0; i < items.Count; i++)
            {
                int pos = items[i].Itapes[0].GetFirstNonBlankCell();
                if (pos < first) first = pos;
            }
            return first;
        }

        public int GetLastNonBlankCell()
        {
            int last = int.MinValue;
            for (int i = 0; i < items.Count; i++)
            {
                int pos = items[i].Itapes[0].GetLastNonBlankCell();
                if (pos > last) last = pos;
            }
            return last;
        }        

        public TuringMachineLog Clone()
        {
            TuringMachineLog newLog = new TuringMachineLog();
            newLog.items = new List<LogItem>(items);
            return newLog;
        }
    }
}
