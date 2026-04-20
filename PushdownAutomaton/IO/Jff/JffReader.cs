using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using FEI.TuringCore.Diagramming;
using FEI.TuringCore.Simulation;
using Transition = FEI.TuringCore.Simulation.Transition;

namespace FEI.PushdownAutomaton.IO.Jff {
	public class JffReader
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public JffReader(string filename)
        {
            this.fileName = filename;
        }

        public PushdownAutomaton Read()
        {
            try
            {
                using (XmlTextReader xr = new XmlTextReader(FileName))
                {
                    PushdownAutomaton result = new PushdownAutomaton();
                    result.AcceptType = AcceptType.FinalStateReachedAndWholeTapeRead;

                    string curElement = "";
                    string subElement = "";
                    bool elementCompleted = false;
                    
                    State curState = new State();
                    var curTransition = new Transition();
                    InfiniteTape currentTape = new InfiniteTape();

                    result.Reset();
                    result.ActiveTapes = new List<InfiniteTape>();
                    result.OriginalTapes = new List<InfiniteTape>();
                    result.OriginalTapes.Add(new InfiniteTape());
                    result.FinalStates.Clear();

                    //Zistí, či je typ dokumentu
                    while ((xr.Read()))
                    {
                        if (xr.NodeType == XmlNodeType.Element)
                        {
                            if (xr.Name.ToLower() != "structure")
                            {
                                xr.Close();
                                return null;
                            }
                            break;
                        }
                    }

                    while ((xr.Read()))
                    {
                        switch (xr.NodeType)
                        {
                            case XmlNodeType.Element:
                                curElement += "." + xr.Name.ToLower().Trim();

                                elementCompleted = false;
                                if (curElement == ".state" || curElement == ".automaton.state")
                                {
                                    string id = xr.GetAttribute("id");
                                    curState = new State(id);
                                }
                                else if (curElement == ".transition" || curElement == ".automaton.transition")
                                {
                                    curTransition = new Transition();
                                }
                                else if (curElement == ".state.final" || curElement == ".automaton.state.final")
                                {
                                    curState.Type = StateType.Final;
                                    result.FinalStates.Add(curState.Name);
                                }
                                else if (curElement == ".state.initial" || curElement == ".automaton.state.initial")
                                {
                                    curState.Type = StateType.Start;
                                    result.StartState = curState.Name;
                                }


                                //Prázdny element - zmazanie posledného názvu z akt. elementu
                                if (xr.IsEmptyElement | elementCompleted)
                                {
                                    curElement = curElement.Substring(0, curElement.LastIndexOf('.'));
                                }

                                break;

                            case XmlNodeType.EndElement:
                                switch (curElement)
                                {
                                    case ".state":
                                    case ".automaton.state":
                                        result.StateDiagram.AddState(curState, false);
                                        //curCellIndex++;
                                        break;
                                    case ".transition":
                                    case ".automaton.transition":
                                        result.AddTFunction(curTransition);
                                        break;
                                }

                                if (curElement.EndsWith("." + xr.Name.ToLower().Trim()))
                                {
                                    curElement = curElement.Substring(0, curElement.LastIndexOf('.'));
                                }

                                break;

                            case XmlNodeType.Text:
                                if (curElement.StartsWith("."))
                                {
                                    subElement = curElement.Substring(1);
                                    switch (subElement)
                                    {
                                        case "type":
                                            if (xr.Value.Trim() != "pda") return null;
                                            break;
                                        case "state.label":
                                        case "automaton.state.label":
                                            curState.Description = xr.Value;
                                            break;
                                        case "state.x":
                                        case "automaton.state.x":
                                            curState.Position = new Point((int)double.Parse(xr.Value, System.Globalization.NumberFormatInfo.InvariantInfo), 
                                                curState.Position.Y);
                                            break;
                                        case "state.y":
                                        case "automaton.state.y":
                                            curState.Position = new Point(curState.Position.X,
                                                (int)double.Parse(xr.Value, System.Globalization.NumberFormatInfo.InvariantInfo));
                                            break;
                                        case "transition.from":
                                        case "automaton.transition.from":
                                            curTransition.CurrentState = xr.Value;
                                            break;
                                        case "transition.to":
                                        case "automaton.transition.to":
                                            curTransition.NewState = xr.Value;
                                            break;
                                        case "transition.read":
                                        case "automaton.transition.read":
                                            if (xr.Value.Trim() == "")
                                                curTransition.ReadSymbol = InfiniteTape.Blank;
                                            else
                                                curTransition.ReadSymbol = xr.Value;
                                            break;
                                        case "transition.pop":
                                        case "automaton.transition.pop":                                            
                                            curTransition.StackRead = xr.Value;
                                            break;
                                        case "transition.push":
                                        case "automaton.transition.push":
                                            curTransition.StackWrite = xr.Value;
                                            break;
                                    }
                                }

                                break;
                        }
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Pri načítavaní súboru nastala chyba.", "Chyba", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
