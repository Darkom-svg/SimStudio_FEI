using System.Xml;
using FEI.TuringCore.Simulation;

namespace FEI.PushdownAutomaton.IO.Jff {
	public class JffWriter
    {
        private string fileName;
        public string FileName
        {
            get => fileName;
            set => fileName = value;
        }

        private PushdownAutomaton machine;
        public PushdownAutomaton Machine
        {
            get => machine;
            set => machine = value;
        }

        public JffWriter(PushdownAutomaton machine, string fileName)
        {
            this.fileName = fileName;
            this.machine = machine;
        }

        public void Save()
        {
            XmlTextWriter xw = new XmlTextWriter(FileName, System.Text.Encoding.UTF8);
            xw.Formatting = Formatting.Indented;
            xw.Indentation = 1;
            xw.IndentChar = '\t';

            xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
            xw.WriteStartElement("structure");                        

            //Typ
            xw.WriteStartElement("type");
            xw.WriteString("pda");
            xw.WriteEndElement();            

            //Stavy
            xw.WriteStartElement("automaton");
            xw.WriteComment("The list of states.");
            for (int i = 0; i < machine.StateDiagram.states.Count; i++)
            {
                xw.WriteStartElement("state");
                xw.WriteAttributeString("id", machine.StateDiagram.states[i].Name);                
                xw.WriteElementString("label", machine.StateDiagram.states[i].Description);

                xw.WriteElementString("x", machine.StateDiagram.states[i].Position.X.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
                xw.WriteElementString("y", machine.StateDiagram.states[i].Position.Y.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

                //Štartovací stav
                if (machine.StartState == machine.StateDiagram.states[i].Name)
                    xw.WriteElementString("initial", "");

                //Koncový stav
                if (machine.IsFinalState(machine.StateDiagram.states[i].Name))
                    xw.WriteElementString("final", "");
                xw.WriteEndElement();
            }            

            //Prechody                
            xw.WriteComment("The list of transitions.");            
            for (int i = 0; i < machine.FunctionCount; i++)
            {
                xw.WriteStartElement("transition");
                xw.WriteElementString("from", machine.Function(i).CurrentState);
                xw.WriteElementString("to", machine.Function(i).NewState);

                xw.WriteElementString("read", ConvertSymbol(machine.Function(i).ReadSymbol));
                xw.WriteElementString("pop", ConvertSymbol(machine.Function(i).StackRead));
                xw.WriteElementString("push", ConvertSymbol(machine.Function(i).StackWrite)); 
                
                xw.WriteEndElement();
            }
            xw.WriteEndElement();

            xw.WriteEndElement();
            xw.Close();
        }

        private string StepToString(Transition.Steps step)
        {
            switch (step)
            {
                case Transition.Steps.Left:
                    return "L";
                case Transition.Steps.Right:
                    return "R";
                case Transition.Steps.NoMove:
                    break;
            }
            return "0";
        }

        private string ConvertSymbol(string symbol)
        {
            if (symbol == "Blank")
                return "";
            
            return symbol;
        }
    }
}
