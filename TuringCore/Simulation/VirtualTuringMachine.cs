using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Xml;
using FEI.SimStudio.Components;
using FEI.TuringCore.Diagramming;

namespace FEI.TuringCore.Simulation {

	//Turingov stroj
	public class VirtualTuringMachine
	{
		private List<TuringThread> threads = new List<TuringThread>();
		private int activeThreadIndex = 0;

		#region Properties
		//Bežiace (neukončené) vlákno - prvé v poradí
		public TuringThread RunningThread
		{
			get
			{
				for (int a = 0; a <= threads.Count - 1; a++)
				{
					if (!Thread(a).Terminated)
						return Thread(a);
				}
				return null;
			}
		}

		//Aktívne vlákno
		public TuringThread ActiveThread
		{
			get
			{
				if (activeThreadIndex > ThreadCount)
					return Thread(0);
				else
					return Thread(activeThreadIndex);
			}
		}

		//Počet vlákien turingovho  stroja
		public int ThreadCount
		{
			get { return threads.Count; }
		}

		//Naposledy použitý prechod
		public Transition LastUsedTransition
		{
			get { return ActiveThread.LastUsedTransition; }
			set { ActiveThread.LastUsedTransition = value; }
		}

		//Aktuálny stav
		public string CurrentState
		{
			get { return ActiveThread.CurrentState; }
			set { ActiveThread.CurrentState = value; }
		}

		//Páska aktuálneho vlákna
		public List<InfiniteTape> ActiveTapes
		{
			get { return ActiveThread.Tapes; }
			set { ActiveThread.Tapes = value; }
		}

		//Páska turingovho stroja    
		public List<InfiniteTape> OriginalTapes
		{
			get { return this.originalTapes; }
			set { this.originalTapes = value; }
		}

		//Pozícia na páske
		public List<int> HeadPositions
		{
			get { return ActiveThread.HeadPositions; }
			set { ActiveThread.HeadPositions = value; }
		}

		//Počet prechodových funkcií
		public int TFunctionCount
		{
			get { return this.transitionFunction.Count; }
		}

		//Počet vykonaných krokov
		public int StepCount
		{
			get
			{
				int steps = 0;
				for (int a = 0; a <= this.TFunctionCount - 1; a++)
				{
					steps += this.TFunction(a).UseCount;
				}
				return steps;
			}
		}

		//Index Aktívneho vlákna
		public int ActiveThreadIndex
		{
			get { return activeThreadIndex; }
		}

		//Log aktívneho vlákna
		public TuringMachineLog Log
		{
			get { return ActiveThread.Log; }
		}

		//Metadáta
		private MetaData meta = new MetaData();
		public MetaData Meta
		{
			get { return meta; }
			set { meta = value; }
		}

		//Stavový diagram
		private StateDiagram stateDiagram = new StateDiagram();
		public StateDiagram StateDiagram
		{
			get { return stateDiagram; }
			set { stateDiagram = value; }
		}

		//Nastavenia
		private bool enableNondeterminism = true;
		public bool EnableNondeterminism
		{
			get { return enableNondeterminism; }
			set { enableNondeterminism = value; }
		}

		private bool writeLog = true;
		public bool WriteLog
		{
			get { return writeLog; }
			set { writeLog = value; }
		}

		private bool storeOriginalTape = true;              
		public bool StoreOriginalTape
		{
			get { return storeOriginalTape; }
			set
			{
				storeOriginalTape = value;

				if (value)
				{
					for (int i = 0; i < originalTapes.Count; i++)
					{
						this.originalTapes[i] = this.originalTapes[i].Clone();
					}
				}
			}
		}  

		//Štartovací stav
		private string startState = "q0";        
		public string StartState
		{
			get { return startState; }
			set { startState = value; }
		}

		//Koncové stavy
		private List<string> finalStates = new List<string>();        
		public List<string> FinalStates
		{
			get { return finalStates; }
			set { finalStates = value; }
		}

		private AcceptType acceptType = AcceptType.FinalStateReached;
		public AcceptType AcceptType
		{
			get { return acceptType; }
			set { acceptType = value; }
		}

		//Prechodové funkcie
		private List<Transition> transitionFunction = new List<Transition>();
		public List<Transition> TransitionFunction
		{
			get { return transitionFunction; }
			set { transitionFunction = value; }
		}

		//Zástupné znaky
		private List<WildCard> wildCards = new List<WildCard>();
		public List<WildCard> WildCards
		{
			get { return wildCards; }
			set { wildCards = value; }
		}
	   
		//Ďalší krok neexistuje
		private bool noNextStep = false;        
		public bool NoNextStep
		{
			get { return noNextStep; }
		}
		
		//V aktuálnom kroku bola zmenená páska
		protected bool tapeChanged = false;

		//Bolo vytvorené nové vlákno
		private bool threadCountChanged = false;                
		public bool ThreadCountChanged
		{
			get { return threadCountChanged; }
			set { threadCountChanged = value; }
		}

		//Páska
		private List<InfiniteTape> originalTapes = new List<InfiniteTape>();
		//int startPosition = 0;

		public List<string> CurrentSymbols
		{
			get
			{
				List<string> retval = new List<string>(ActiveThread.Tapes.Count);
				foreach (InfiniteTape tape in ActiveThread.Tapes)
				{
					retval.Add(tape.CurrentSymbol);
				}
				return retval;
			}
			set
			{
				for (int i = 0; i < ActiveThread.Tapes.Count; i++)
				{
					ActiveThread.Tapes[i].CurrentSymbol = value[i];
				}
			}
		}
		#endregion


		public VirtualTuringMachine()
		{
			threads.Add(new TuringThread(this.StartState, new List<InfiniteTape>(),new TuringMachineLog()));
			finalStates.Add("qf");

			originalTapes.Add(new InfiniteTape());

			Reset();
		}

		
		//Aktivuje nasledujúce vlákno
		public void ActivateNextThread()
		{
			activeThreadIndex += 1;
			if (activeThreadIndex > ThreadCount - 1)
			{
				activeThreadIndex = 0;
			}
		}

		//Zmaže neaktívne vlákna
		public void RemoveInactiveThreads()
		{            
			for (int i = ThreadCount - 1; i >= 0; i--)
			{
				if (ActiveThread!=threads[i] && threads[i].Terminated && !IsFinalState(threads[i].CurrentState))
				{
					threads.RemoveAt(i);
					if (activeThreadIndex > i) activeThreadIndex--;
					ThreadCountChanged = true;
				}
			}

			if (ThreadCount > 1 && ActiveThread.Terminated)
			{
				threads.Remove(ActiveThread);
				ThreadCountChanged = true;
			}
			if (activeThreadIndex >= threads.Count) activeThreadIndex = 0;
		}
		

		//Vlákno turingovho  stroja
		public TuringThread Thread(int index)
		{
			if (index <0 || index>threads.Count-1) 
				return threads[0];
			else
				return threads[index];
		}

		//Vlákno turingovho  stroja
		public void SetThread(int index,TuringThread value)
		{
			threads[index] = value;
		}        

		//Aktuálny symbol
		public string GetCurrentSymbol(int tapeIndex)
		{
			return ActiveThread.GetCurrentSymbol(tapeIndex);
		}

		//nasledujúci symbol
		public string GetNextSymbol(int tapeIndex, bool toRight)
		{
			return ActiveThread.GetNextSymbol(tapeIndex, toRight);
		}

		public void SetCurrentSymbol(int tapeIndex, string symbol)
		{
			ActiveThread.SetCurrentSymbol(tapeIndex, symbol);
		}                       

		////Štartovacia pozícia hlavy
		//public int StartPosition
		//{
		//    get { return startPosition; }
		//    set { startPosition = value; }
		//}

		//Pridá prechodovú funkciu
		public void AddTFunction(Transition TFunction)
		{
			this.transitionFunction.Add(TFunction);
		}

		//Odstráni prechodovú funkciu
		public void RemoveTFunction(Transition TFunction)
		{
			this.transitionFunction.Remove(TFunction);
		}

		//Odstráni prechodovú funkciu s daným indexom
		public void RemoveTFunctionAt(int Index)
		{
			this.transitionFunction.RemoveAt(Index);
		}

		//Odstráni všetky prechodové funkcie
		public void RemoveAllTFunctions()
		{
			this.transitionFunction.Clear();
		}

		//Prechodová funckia
		public Transition TFunction(int index)
		{
			return this.transitionFunction[index]; 
		}

		public void SetTFunction(int index, Transition value)
		{
			this.transitionFunction[index] = value;
		}
		

		//Vykoná ďalší krok
		//OnAllThreads = True    :: Ďalší krok na všetkých vláknach
		//OnAllThreads = False   :: Ďalší krok na aktuálnom vlákne
		public void NextStep(bool OnAllThreads)
		{
			//Zapisovanie do logu - zapísanie počiatočného stavu
			if (WriteLog && Log.Count == 0) {                
				Log.AddLogItem(new LogItem(InfiniteTape.DeepCopyTapes(ActiveTapes),
					this.CurrentState, 
					(this.LastUsedTransition == null)? "" : this.LastUsedTransition.ToString(),
					false));
			}

			if (OnAllThreads) //Vykonanie 1 kroku na všetkých paralelných vláknach
			{
				int startIndex = activeThreadIndex;
				do
				{
					//Zapisovanie do logu - zapísanie počiatočného stavu
					if (WriteLog && Log.Count == 0)
						Log.AddLogItem(new LogItem(InfiniteTape.DeepCopyTapes(ActiveTapes),
							this.CurrentState, this.LastUsedTransition.ToString(), 
							false));

					//Vykoná ďalší krok na aktívnom vlákne                    
					ActiveThreadNextStep();                     

					ActivateNextThread();   //Aktivuje ďalšie vlákno v poradí                    
				}
				while (!(startIndex == activeThreadIndex));
				RemoveInactiveThreads();
			}
			else //Vykonanie iba 1 kroku
			{
				//Zapisovanie do logu - zapísanie počiatočného stavu
				if (WriteLog && Log.Count == 0)
					Log.AddLogItem(new LogItem(InfiniteTape.DeepCopyTapes(ActiveTapes), 
						this.CurrentState, this.LastUsedTransition.ToString(),
						false));

				//Vykoná ďalší krok na aktívnom vlákne                
				ActiveThreadNextStep();                 

				ActivateNextThread();   //Aktivuje ďalšie vlákno v poradí
				RemoveInactiveThreads();
			}

			//Skontroluje, či neexistuje prechodová funkcia pre ďalší krok (tzn. zistí, či beží nejaké vlákno)
			noNextStep = true;
			for (int a = 0; a <= ThreadCount - 1; a++)
			{
				if (!Thread(a).Terminated)
					noNextStep = false;
			}
		}

		public virtual bool IsTransitionSatisfied(Transition transition, string curState, string curSymbol)
		{
			return transition.CurrentState == curState && CompareSymbols(transition.ReadSymbol, curSymbol);
		}

		public virtual void TransitionSucceed(Transition transition, TuringThread thread, string curSymbol)
		{
			//Vykonanie prechodovej funkcie         
			if (ExistsWildCard(transition.WriteSymbol)) //Zástupný znak        
			{
				int i = GetWildCardSymbolIndex(transition.ReadSymbol, curSymbol);
				string ws = GetWildCardSymbol(transition.WriteSymbol, i);

				if (thread.GetCurrentSymbol(0) != ws)
				{
					thread.SetCurrentSymbol(0, ws);
					tapeChanged = true;
				}
			}
			else //Znak abecedy
			{
				if (thread.GetCurrentSymbol(0) != transition.WriteSymbol)
				{
					thread.SetCurrentSymbol(0, transition.WriteSymbol);
					tapeChanged = true;
				}
			}

			thread.CurrentState = transition.NewState;
			thread.LastUsedTransition = transition;
			if (transition.Step == Transition.Steps.Right)
			{
				thread.MoveHeadRight(0);
			}
			else if (transition.Step == Transition.Steps.Left)
			{
				thread.MoveHeadLeft(0);
			}
		}

		public void ActiveThreadNextStep()
		{
			//Nájdenie vhodnej funkcie
			Transition tf;
			bool firstHit = true;

			string curState = this.CurrentState;
			string curSymbol = this.GetCurrentSymbol(0); //TODO: Prerobiť!!!
			int curPosition = this.HeadPositions[0];
			List<InfiniteTape> curTapes = InfiniteTape.DeepCopyTapes(ActiveTapes);
			TuringMachineLog curLog = this.Log.Clone();

			tapeChanged = false;

			for (int a = 0; a <= this.transitionFunction.Count - 1; a++)
			{
				tf = this.TFunction(a);
				if (IsTransitionSatisfied(tf, curState, curSymbol))
				{
					//Zaznamenanie použitia prechodovej funkcie
					tf.Use();

					//Nederministická funkcia - vytvorenie paralelného vlákna
					if (!firstHit)
					{
						//Pridanie nového vlakna
						threads.Add(new TuringThread(curState, curTapes, curLog));
						ThreadCountChanged = true;

						//Zapisovanie do logu - zapísanie počiatočného stavu
						if (WriteLog && Log.Count == 0)
							Log.AddLogItem(new LogItem(curTapes, 
								curState, LastUsedTransition.ToString(), false));

						TransitionSucceed(tf, Thread(ThreadCount - 1), curSymbol);

						//Zapisovanie do logu - zapísanie stavu po vykonaní prechodu
						if (WriteLog)
						{
							if (!tapeChanged)
								Thread(ThreadCount - 1).Log.AddLogItem(
									new LogItem(Thread(ThreadCount - 1).Log[Thread(ThreadCount - 1).Log.Count - 1].Itapes,
										Thread(ThreadCount - 1).HeadPositions,
										Thread(ThreadCount - 1).CurrentState,
										Thread(ThreadCount - 1).LastUsedTransition.ToString(), 
										false));
							else
								Thread(ThreadCount - 1).Log.AddLogItem(
									new LogItem(InfiniteTape.DeepCopyTapes(Thread(ThreadCount - 1).Tapes),                                         
										Thread(ThreadCount - 1).CurrentState,
										Thread(ThreadCount - 1).LastUsedTransition.ToString(), 
										true));
						}

					}
					else
					{
						TransitionSucceed(tf, Thread(activeThreadIndex), curSymbol);                        

						//Zapisovanie do logu - zapísanie stavu po vykonaní prechodu
						if (WriteLog)
						{
							if (!tapeChanged)
								Log.AddLogItem(new LogItem(Log[Log.Count - 1].Itapes,
									this.HeadPositions,
									this.CurrentState,                                     
									this.LastUsedTransition.ToString(),
									false));
							else
								Log.AddLogItem(new LogItem(InfiniteTape.DeepCopyTapes(this.ActiveTapes), 
									this.CurrentState, 
									this.LastUsedTransition.ToString(),
									true));
						}

						firstHit = false;
					}
				}
				this.SetTFunction(a,tf);
			}

			//Ukončiť vlákno
			if (firstHit)
				this.ActiveThread.Terminated = true;
		}

		private void MoveHeadLeft(int tapeIndex)
		{
			ActiveTapes[tapeIndex].MoveHeadLeft();
		}

		private void MoveHeadRight(int tapeIndex)
		{
			ActiveTapes[tapeIndex].MoveHeadRight();
		}

		//Vráti symbolu zástupného znaku s daným indexom
		protected string GetWildCardSymbol(string wildcardName, int index)
		{            
			for (int i = 0; i < this.wildCards.Count; i++)
			{
				if (this.wildCards[i].Wildcard == wildcardName)
				{
					return this.wildCards[i].Symbols[index];
				}
			}
			return "";
		}

		//Vráti index symbolu zástupného znaku
		protected int GetWildCardSymbolIndex(string wildcardName,string symbol)
		{
			for (int i = 0; i < this.wildCards.Count; i++)
			{
				if (this.wildCards[i].Wildcard==wildcardName)
				{ 
					return this.wildCards[i].IndexOfSymbol(symbol);                                        
				}
			}
			return -1;
		}

		

		//Reset turingovho stroja
		public virtual void Reset()
		{
			this.threads.Clear();
			this.threads.Add(new TuringThread(this.StartState, new List<InfiniteTape>(),new TuringMachineLog()));
			this.activeThreadIndex = 0;                        

			this.CurrentState = this.StartState;
			//this.ActiveTape = new InfiniteTape();
			//this.Position = 0;

			//Vynulovanie využitia funkcií
			Transition tf;
			for (int a=0;a<this.TFunctionCount;a++){
				tf = this.transitionFunction[a];
				tf.ResetUseCounter();
				this.transitionFunction[a] = tf;
			}

			//Zmaže log
			this.Log.Clear();
		}

		//Vráti pole všetkých použitých stavov
		public string[] GetUsedStates()
		{
			ArrayList states = new ArrayList();
			string state;

			for (int a = 0; a <= this.TFunctionCount - 1; a++)
			{
				state = this.TFunction(a).NewState;
			   
				if (!states.Contains(state))
					states.Add(state);

				state = this.TFunction(a).CurrentState;
				if (!states.Contains(state))
					states.Add(state);
			}

			state = this.StartState;
			if (!states.Contains(state))
				states.Add(state);

			for (int a = 0; a < this.FinalStates.Count; a++)
			{
				state = this.FinalStates[a];
				if (!states.Contains(state))
					states.Add(state);
			}            

			return (string[])states.ToArray(typeof(string));
		}

		//Načítanie súboru turingovho stroja
		public string Load(string FileName)
		{
			string Code="";

			XmlTextReader xr = new XmlTextReader(FileName);
			string curElement = "";
			string subElement = "";
			bool elementCompleted = false;

			int curCellIndex=0;
			Diagramming.State curState = new Diagramming.State();
			Transition curTransition = new Transition();

			InfiniteTape currentTape = new InfiniteTape();

			this.Reset();
			this.ActiveTapes = new List<InfiniteTape>();
			this.OriginalTapes = new List<InfiniteTape>();

			//Zistí, či je typ dokumentu
			while ((xr.Read()))
			{
				if (xr.NodeType == XmlNodeType.Element)
				{
					if (xr.Name.ToLower() != "turingmachine" && xr.Name.ToLower() != "xamff")
					{
						xr.Close();
						return ""; 
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
						if (curElement == ".machine.tapes.tape.cell")
						{
							curCellIndex = int.Parse(xr.GetAttribute("position"));
						}
						else if (curElement == ".machine.tapes.tape.head")
						{
							//Pozícia hlavy
							currentTape.HeadPosition = int.Parse(xr.GetAttribute("position"));                                                                                    
						}
						else if (curElement == ".machine.states.state")
						{
							curState = new Diagramming.State();
						}
						else if (curElement == ".machine.transitions.transition")
						{
							curTransition = new Transition();
						}
						else if (curElement == ".machine.tapes.tape.head")
						{
							currentTape.HeadPosition = int.Parse(xr.GetAttribute("position"));
						}
						else if (curElement == ".machine.states.state.final")
						{
							curState.Type = StateType.Final;
							this.FinalStates.Add(curState.Name);
						}
						else if (curElement == ".machine.states.state.initial")
						{
							curState.Type = StateType.Start;
							this.StartState = curState.Name;
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
							case ".machine.states.state":
								this.stateDiagram.AddState(curState,false);                                
								curCellIndex++;
								break;
							case ".machine.transitions.transition":
								this.AddTFunction(curTransition);                                
								break;
							case ".machine.tapes.tape":
								this.originalTapes.Add(currentTape);
								currentTape = new InfiniteTape();
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
								case "machine.tapes.tape.cell":
									currentTape.SetCell(curCellIndex, xr.Value);                                    
									break;
								case "machine.states.state.name":
									curState.Name = xr.Value;
									break;
								case "machine.states.state.comment":
									curState.Description= xr.Value;
									break;                                
								case "machine.states.state.x":
									curState.Position = new Point(int.Parse(xr.Value), curState.Position.Y);
									break;
								case "machine.states.state.y":
									curState.Position = new Point(curState.Position.X, int.Parse(xr.Value));
									break;
								case "machine.transitions.transition.from":
									curTransition.CurrentState= xr.Value;
									break;
								case "machine.transitions.transition.to":
									curTransition.NewState = xr.Value;
									break;
								case "machine.transitions.transition.read":
									curTransition.ReadSymbol = xr.Value;
									break;
								case "machine.transitions.transition.write":
									curTransition.WriteSymbol = xr.Value;
									break;
								case "machine.transitions.transition.comment":
									curTransition.Comment = xr.Value;
									break;
								case "machine.code":
									Code = xr.Value;
									break;
							}
						}

						break;
				}
			}        

			xr.Close();

			return Code;
		}

		//Uloženie súboru turingovho stroja
		public void Save(string FileName, string Code)
		{
			XmlTextWriter xw = new XmlTextWriter(FileName, System.Text.Encoding.UTF8);
			xw.Formatting = Formatting.Indented;
			xw.Indentation = 1;
			xw.IndentChar = '\t';

			xw.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
			xw.WriteStartElement("turingmachine");

			meta.Modified = DateTime.Now.ToString();
			if (meta.Created == null || meta.Created.Trim()=="") meta.Created = meta.Modified;

			//Metadáta
			xw.WriteStartElement("meta");
				xw.WriteElementString("author",meta.Author);
				xw.WriteElementString("title",meta.Title);
				xw.WriteElementString("description",meta.Description);
				xw.WriteElementString("created",meta.Created);
				xw.WriteElementString("modified",meta.Modified);
			xw.WriteEndElement();

			//Stroj
			xw.WriteStartElement("machine");
				xw.WriteAttributeString("type", "TM");

				//Pásky
				xw.WriteStartElement("tapes");
				foreach (InfiniteTape tape in this.originalTapes)
				{
					//Páska
					xw.WriteStartElement("tape");
					xw.WriteAttributeString("id", "0");

					//Hlava
					xw.WriteStartElement("head");
					xw.WriteAttributeString("id", "0");
					//Pozícia hlavy
					xw.WriteAttributeString("position", tape.HeadPosition.ToString());
					xw.WriteEndElement();

					int[] c = tape.GetNonBlankCellIndices();
					for (int i = 0; i <= c.Length - 1; i++)
					{
						xw.WriteStartElement("cell");
						xw.WriteAttributeString("position", c[i].ToString());

						xw.WriteString(tape.GetCell(c[i]));
						xw.WriteEndElement();
					}
					xw.WriteEndElement();
				}
				xw.WriteEndElement();

				//Stavy
				xw.WriteStartElement("states");
					for (int i = 0; i < this.stateDiagram.states.Count; i++)
					{
						xw.WriteStartElement("state");
							xw.WriteAttributeString("id",this.stateDiagram.states[i].Name);
							xw.WriteElementString("name",this.stateDiagram.states[i].Name);
							xw.WriteElementString("comment",this.stateDiagram.states[i].Description);

							xw.WriteElementString("x", this.stateDiagram.states[i].Position.X.ToString());
							xw.WriteElementString("y", this.stateDiagram.states[i].Position.Y.ToString());

							//Štartovací stav
							if (this.StartState == this.stateDiagram.states[i].Name)
								xw.WriteElementString("initial", "");

							//Koncový stav
							if (this.IsFinalState(this.stateDiagram.states[i].Name))
								xw.WriteElementString("final", "");
						xw.WriteEndElement();
					}
				xw.WriteEndElement();

				//Prechody                
				xw.WriteStartElement("transitions");
				for (int i = 0; i < this.TFunctionCount; i++)
				{
					xw.WriteStartElement("transition");
						xw.WriteElementString("from", this.TFunction(i).CurrentState);
						xw.WriteElementString("to", this.TFunction(i).NewState);

						xw.WriteElementString("read", this.TFunction(i).ReadSymbol);
						xw.WriteElementString("write", this.TFunction(i).WriteSymbol);
						xw.WriteElementString("move", VirtualTuringMachine.StepToString(this.TFunction(i).Step));
						
						xw.WriteElementString("comment", this.TFunction(i).Comment);                        
					xw.WriteEndElement();
				}
				xw.WriteEndElement();         

				//Kód
				xw.WriteStartElement("code");
					xw.WriteString(Code);
				xw.WriteEndElement();

			xw.WriteEndElement();
			xw.Close();
		}

		public static string StepToString(Transition.Steps steps)
		{
			switch (steps)
			{
				case Transition.Steps.Left:
					return "Left";
				case Transition.Steps.Right:
					return "Right";
				case Transition.Steps.NoMove:
					return "NoMove";
			}
			return "";
		}        

		//Pridá zástupný znak
		public void AddWildcard(string wildcard, params string[] symbols)
		{
			WildCard w = new WildCard();
			w.Wildcard = wildcard;
			w.Symbols = symbols;

			wildCards.Add(w);
		}

		//Porovnanie symbolov
		public bool CompareSymbols(string symbol1, string symbol2)
		{
			if (symbol1 == symbol2)
			{
				return true;
			}
			else
			{
				for (int i=0;i<wildCards.Count;i++){
					if (symbol1 == wildCards[i].Wildcard)
					{
						if (wildCards[i].ContainsSymbol(symbol2)) return true;
					}
					else if (symbol2 == wildCards[i].Wildcard)
					{
						if (wildCards[i].ContainsSymbol(symbol1)) return true;
					}
				}
			}
			return false;
		}

		//Zistí, či je definovaný zástupný znak
		public bool ExistsWildCard(string wildcard)
		{
			for (int i = 0; i < wildCards.Count; i++)
			{
				if (wildCards[i].Wildcard == wildcard) return true;
			}
			return false;
		}

		//Zrušenie všetkých paralelných vlákien (okrem hlavného)
		public void RemoveAllThreads()
		{
			List<InfiniteTape> tapes = this.OriginalTapes;
			TuringMachineLog log = this.Log;

			this.threads.Clear();
			this.threads.Add(new TuringThread(this.StartState, tapes, log));
		}        

		//Je koncový stav
		public bool IsFinalState(string state)
		{
			return this.finalStates.Contains(state);
		}

		public bool IsAccepted()
		{
			if (acceptType == AcceptType.FinalStateReached)
			{
				return IsFinalState(this.CurrentState);
			}
			else if (acceptType == AcceptType.FinalStateReachedAndWholeTapeRead)
			{
				return IsFinalState(this.CurrentState) && IsBlank(GetNextSymbol(0, true));
			}
			else
				return false;
		}

		//Vrati zoznam použitých stavov ako reťazec znakov
		public string GetUsedStatesAsString()
		{
			return String.Join(", ", this.GetUsedStates());
		}

		public string GetUsedSymbolsAsString()
		{
			// Symboly na páske
			List<string> retval = new List<string>(GetUsedSymbols());

			// Symboly v prechodových funkciách
			foreach (Transition f in transitionFunction)
			{
				if (!retval.Contains(f.ReadSymbol))
				{
					if (!InfiniteTape.IsBlank(f.ReadSymbol)) retval.Add(f.ReadSymbol);
				}
				if (!retval.Contains(f.WriteSymbol))
				{
					if (!InfiniteTape.IsBlank(f.WriteSymbol)) retval.Add(f.WriteSymbol);
				}
			}            

			return String.Join(", ", retval.ToArray());
		}

		private bool IsBlank(string symbol)
		{
			if (symbol == "" || symbol== InfiniteTape.Blank)
				return true;
			else
				return false;
		}

		private List<string> GetUsedSymbols()
		{
			List<string> retval = new List<string>();
			foreach (InfiniteTape tape in OriginalTapes)
			{
				List<string> symbols = tape.GetUsedSymbols();
				foreach (string symbol in symbols)
				{
					if (!retval.Contains(symbol))
						retval.Add(symbol);
				}
			}

			return retval;
		}

		public List<Transition> GetTFunctions()
		{
			return transitionFunction;
		}

		
		
	}

}