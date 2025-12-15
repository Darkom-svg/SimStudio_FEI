using DusanRodina.SimStudio.Components;
using DusanRodina.SimStudio.Components.Registers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DusanRodina.RandomAccessMachine.Simulation {
	public class Simulator
	{
		public Form frm;

		public bool smallRegsUsed = true;        
		public InfiniteRegisters regs = new InfiniteRegisters();
		public SmallRegisters smallRegs = new SmallRegisters();
		public Stack<InfiniteInteger> stack = new Stack<InfiniteInteger>();
		public List<RAMInstruction> program = new List<RAMInstruction>();    //Program počítača RAM
		public List<LabeledRAMInstruction> labeledProgram = new List<LabeledRAMInstruction>();    //Program počítača RAM
		public int prgPointer = 0; //Ukazovateľ programu        

		//### Pásky ###        
		public List<String> InputTape = new List<String>(); //Vstupná páska
		public int InTapePointer;  //Ukazovateľ vstupnej pásky    
		public List<String> OutputTape = new List<String>(); //Výstupná páska

		//Návestia        
		public List<Label> Labels = new List<Label>();

		public int Speed = 50; //Doba zdržania pri vykonávaní programu v milisekundách, 0 - real-time        

		//Vykonávanie programu na oddelenom vlákne         
		System.Threading.Thread PrgThread;
		public bool PrgStop = true;        
		public bool EndOfPrg = true;
		public short PrgStatus = 0;        

		//Špeciálne časti
		public RAMScreen Screen = new RAMScreen();
		
		public bool RamConsole = false;
		public string ConsoleContent = "";
		public bool InputNotTyped = true;

		//Animácia        
		public double LastRP = 0;
		public double LastWP = 0;
		public double LastPP = 0;

		private double readPos = 0;
		private double writePos = 0;
		private double programPos = 0;

		private double curReadPos = 0;
		private double curWritePos = 0;
		private double curProgramPos = 0;

		private bool reading = false;
		private bool writing = false;
		private bool executing = false;

		public long CycleCount = 0;    //Počet vykonaných cyklov                
		public long StartTime;         //Čas spustenia programu

		//Zložitosť
		public long[] instructionCounter = new long[30];
		public long timeUniCounter = 0;
		public long timeLogCounter = 0;
		public long spaceUniCounter = 0;
		public long spaceLogCounter = 0;

		//Udalosti        
		public event EventHandler RefreshAnimation;

		public event EventHandler ReadingPositionChanged;
		public event EventHandler WritingPositionChanged;
		public event EventHandler ReadingStatusChanged;
		public event EventHandler WritingStatusChanged;

		public event EventHandler OutputTapeChanged;

		public event EventHandler ProgramPaused;
		public event EventHandler ProgramFinished;
		public event EventHandler InstructionExecuted;
		public event EventHandler ConsoleChanged;

		public Simulator(Form OwnerForm)
		{
			this.frm = OwnerForm;
		}

		#region Properties
		public double ReadPos
		{
			get { return readPos; }
			set { readPos = value; }
		}

		public double WritePos
		{
			get { return writePos; }
			set { writePos = value; }
		}

		public double ProgramPos
		{
			get { return programPos; }
			set { programPos = value; }
		}

		public double CurReadPos
		{
			get { return curReadPos; }
			set
			{
				curReadPos = value;
				//lstRegs.ReadingPos = (int)readPos;
				if (ReadingPositionChanged!=null)
					ReadingPositionChanged(this,new EventArgs());
			}
		}

		public double CurWritePos
		{
			get { return curWritePos; }
			set
			{
				curWritePos = value;
				//lstRegs.WritingPos = (int)writePos;
				if (WritingPositionChanged!=null)
					WritingPositionChanged(this,new EventArgs());
			}
		}

		public double CurProgramPos
		{
			get { return curProgramPos; }
			set { curProgramPos = value; }
		}

		public bool Reading
		{
			get { return reading; }
			set
			{
				reading = value;
				//lstRegs.Reading = value;
				if (ReadingStatusChanged != null)
					frm.Invoke(ReadingStatusChanged, new object[] { this, new EventArgs() });
			}
		}

		public bool Writing
		{
			get { return writing; }
			set
			{
				writing = value;
				//lstRegs.Writing = value;
				if (WritingStatusChanged != null)
					frm.Invoke(WritingStatusChanged, new object[] { this, new EventArgs() });
			}
		}

		public bool Executing
		{
			get { return executing; }
			set { executing = value; }
		}
		#endregion

		//Vynuluje počítadlá
		public void ClearCounters()
		{
			timeUniCounter = 0;
			timeLogCounter = 0;
			spaceUniCounter = 0;
			spaceLogCounter = 0;
			for (int i = 0; i < instructionCounter.Length; i++)
				instructionCounter[i] = 0;
			CycleCount = 0;
		}

		public void Step()
		{
			if (StartTime==0) StartTime = DateTime.Now.Ticks;

			NextStep();

			if (prgPointer > program.Count - 1) EndOfPrg = true; else EndOfPrg = false;
			if (EndOfPrg)
				ExecutionFinish();
		}

		private void NextStep()
		{
			try
			{
				if (prgPointer > program.Count - 1) {EndOfPrg=true; return;}


				if (!program[prgPointer].Skip)
				{                    
					InfiniteInteger i;
					switch (program[prgPointer].Command)
					{
						case InstructionType.Print:                            
							ConsoleContent += labeledProgram[prgPointer].OpLabel;
							ConsoleContent += Environment.NewLine;

							break;
						case InstructionType.Read: //Čítanie zo vstupnej pásky
							if (ConsoleRead()) return;

							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							if (InTapePointer < InputTape.Count)
							{
								if (program[prgPointer].OperandType == OperationType.Address)
									timeLogCounter += LogCost(int.Parse(InputTape[InTapePointer]))
										+ LogCost(program[prgPointer].Operand);
								else if (program[prgPointer].OperandType == OperationType.Indirect)
									timeLogCounter += LogCost(int.Parse(InputTape[InTapePointer]))
										+ LogCost(program[prgPointer].Operand) + LogCost(program[prgPointer].GetAddress(ref regs));
							}
							else timeLogCounter++;
							instructionCounter[(int)InstructionType.Read]++;
							//------------------------------------------------

							i = program[prgPointer].GetAddress(ref regs);
							if (i != new InfiniteInteger(-1))
							{
								if (InTapePointer > InputTape.Count - 1)
								{
									//Celá páska načítaná
									PrgStatus = 3;
									EndOfPrg = true;
								}
								else
								{
									regs.SetValue(i, new InfiniteInteger(InputTape[InTapePointer]));
									InTapePointer += 1;
								}

								if (Speed > 0)
								{
									if (i >= InfiniteInteger.zero)
									{
										WritePos = i.ToInt();
										Writing = true;
										RunAnimation();                                        
										Writing = false;
										//this.InvokeRefresh(pProc);
										if (RefreshAnimation != null)
											frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
									}
								}
							}

							break;

						case InstructionType.Write: //Zápis na výstupnú pásku
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs);
							instructionCounter[(int)InstructionType.Write]++;
							//------------------------------------------------

							i = program[prgPointer].GetAddress(ref regs);
							if (i != new InfiniteInteger(-1))
							{
								//ftOutputTape.AddRecord(Regs[i].Value.ToString());
								OutputTape.Add(regs[i].Value.ToString());

								// Vypis na konzolu                                
								WriteToConsole(regs[i].Value.ToString());

								if (Speed > 0)
								{
									if (OutputTapeChanged != null)
										frm.Invoke(OutputTapeChanged, new object[] { this, new EventArgs() });

									if (i >= InfiniteInteger.zero)
									{
										ReadPos = i.ToInt();
										Reading = true;
										RunAnimation();                                        
										Reading = false;
										//this.InvokeRefresh(pProc);
										if (RefreshAnimation != null)
											frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
									}
								}
							}

							break;
						case InstructionType.Load: //Načítanie registra do akumulátora
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs);
							instructionCounter[(int)InstructionType.Load]++;
							//------------------------------------------------

							//Načíta hodnotu
							i = program[prgPointer].GetValue(ref regs);

							if (Speed > 0)
							{
								if (program[prgPointer].GetAddress(ref regs) >= InfiniteInteger.zero)
								{
									ReadPos = program[prgPointer].GetAddress(ref regs).ToInt();
									Reading = true;
									//if (RefreshAnimation != null) RefreshAnimation(this, new EventArgs());
									RunAnimation();
									Reading = false;
									if (RefreshAnimation != null)
										frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
								}
							}                            

							//Uloží hodnotu
							regs.SetValue(InfiniteInteger.zero, i);

							if (Speed > 0)
							{
								WritePos = 0;
								Writing = true;
								RunAnimation();
								Writing = false;
								if (RefreshAnimation != null)
									frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
							}

							break;
						case InstructionType.Store: //Uloženie akumulátora do registra
							//Rátanie zložitosti -------------------------------------------
							timeUniCounter++;
							if (program[prgPointer].OperandType == OperationType.Address)
								timeLogCounter += LogCost(regs[0].Value)
									+ LogCost(program[prgPointer].Operand);
							else if (program[prgPointer].OperandType == OperationType.Indirect)
								timeLogCounter += LogCost(regs[0].Value)
									+ LogCost(program[prgPointer].Operand) + LogCost(program[prgPointer].GetAddress(ref regs));
							instructionCounter[(int)InstructionType.Store]++;
							//--------------------------------------------------------------

							i = program[prgPointer].GetAddress(ref regs);
							regs.SetValue(i, regs[0].Value);

							if (Speed > 0)
							{
								if (program[prgPointer].GetAddress(ref regs) >= InfiniteInteger.zero)
								{
									ReadPos = 0;
									Reading = true;
									RunAnimation();                                    
									Reading = false;
									//this.InvokeRefresh(pProc);
									if (RefreshAnimation != null)
										frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });

									WritePos = program[prgPointer].GetAddress(ref regs).ToInt();
									Writing = true;
									RunAnimation();
									Writing = false;
									//this.InvokeRefresh(pProc);
									if (RefreshAnimation != null)
										frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
								}
							}

							break;
						case InstructionType.Push: //Vloží obsah akumulátora do zásobníka
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs);
							instructionCounter[(int)InstructionType.Push]++;
							//------------------------------------------------

							if (Speed > 0)
							{
								if (program[prgPointer].GetAddress(ref regs) >= InfiniteInteger.zero)
								{
									ReadPos = 0;
									Reading = true;                                    
									RunAnimation();
									Reading = false;
									if (RefreshAnimation != null)
										frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
								}
							}

							//Uloží hodnotu
							stack.Push(regs[0].Value);
							break;
						case InstructionType.Pop: //Vloží obsah z vrchu zásobníka do akumulátora
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs);
							instructionCounter[(int)InstructionType.Pop]++;
							//------------------------------------------------                                                        

							//Uloží hodnotu
							i = stack.Pop();
							regs.SetValue(InfiniteInteger.zero, i);

							AnimOp();
							break;
						case InstructionType.Add: //Pripočítanie
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs)
								+ LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.Add]++;
							//------------------------------------------------

							i = program[prgPointer].GetValue(ref regs);
							regs.IncrementValue(InfiniteInteger.zero, i);

							AnimOp();
							break;
						case InstructionType.Subs:  //Odčítanie
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs)
								+ LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.Subs]++;
							//------------------------------------------------

							i = program[prgPointer].GetValue(ref regs);
							regs.IncrementValue(InfiniteInteger.zero, -i);

							AnimOp();
							break;
						case InstructionType.Div: //Delenie
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs)
								+ LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.Div]++;
							//------------------------------------------------

							//long rem;
							i = program[prgPointer].GetValue(ref regs);
							//Regs.SetValue(0, Math.DivRem(Regs[0].Value, i, out rem));
							regs.SetValue(InfiniteInteger.zero, regs[0].Value / i);

							AnimOp();
							break;
						case InstructionType.Mult: //Násobenie
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += program[prgPointer].GetOperandCost(ref regs)
								+ LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.Mult]++;
							//------------------------------------------------

							i = program[prgPointer].GetValue(ref regs);
							regs.MultValue(InfiniteInteger.zero, i);

							AnimOp();
							break;
						case InstructionType.Jump: //Skok
						case InstructionType.WhileBlockEnd: // Koniec bloku WHILE(GZERO)
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter++;
							instructionCounter[(int)InstructionType.Jump]++;
							//------------------------------------------------

							prgPointer = (program[prgPointer].Operand - new InfiniteInteger (1)).ToInt();
							break;
						case InstructionType.JZero: //Skok ak je nula
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.JZero]++;
							//------------------------------------------------

							if (regs[0].Value == InfiniteInteger.zero)
								prgPointer = (program[prgPointer].Operand).ToInt();
						   
							if (Speed > 0)
							{                           
								ReadPos = 0;
								Reading = true;
								RunAnimation();
								Reading = false;
								//this.InvokeRefresh(pProc);
								if (RefreshAnimation != null)
									frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
							}

							if (regs[0].Value == InfiniteInteger.zero)
								prgPointer--;
							break;
						case InstructionType.IfBlockBegin: // Podmienka IF(GZERO)
						case InstructionType.WhileBlockBegin: // Začiatok bloku WHILE(GZERO)
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.JGZero]++;
							//------------------------------------------------

							if (regs[0].Value <= InfiniteInteger.zero)
								prgPointer = (program[prgPointer].Operand - new InfiniteInteger(1)).ToInt();

							if (Speed > 0)
							{
								ReadPos = 0;
								Reading = true;
								RunAnimation();
								Reading = false;
								//this.InvokeRefresh(pProc);
								if (RefreshAnimation != null)
									frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
							}

							break;
						case InstructionType.JGZero: // Skok ak je väčšie ako nula
						case InstructionType.DoWhileBlockEnd: // Koniec bloku DO WHILE(GZERO)
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter += LogCost(regs[0].Value);
							instructionCounter[(int)InstructionType.JGZero]++;
							//------------------------------------------------

							if (regs[0].Value > InfiniteInteger.zero)
								prgPointer = (program[prgPointer].Operand - new InfiniteInteger(1)).ToInt();

							if (Speed > 0)
							{
								ReadPos = 0;
								Reading = true;
								RunAnimation();
								Reading = false;
								//this.InvokeRefresh(pProc);
								if (RefreshAnimation != null)
									frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
							}

							break;
						case InstructionType.Halt: //Ukončenie programu
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter++;
							instructionCounter[(int)InstructionType.Halt]++;
							//------------------------------------------------

							EndOfPrg = true;
							return;
						case InstructionType.Accept: //Akceptovanie
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter++;
							instructionCounter[(int)InstructionType.Accept]++;
							//------------------------------------------------

							PrgStatus = 1;
							EndOfPrg = true;
							return;
						case InstructionType.Reject: //Neakceptovanies
							//Rátanie časovej náročnosti    ------------------                        
							timeUniCounter++;
							timeLogCounter++;
							instructionCounter[(int)InstructionType.Reject]++;
							//------------------------------------------------

							PrgStatus = 2;
							EndOfPrg = true;
							return;
					}

					CycleCount += 1;
				}

				prgPointer += 1;

				if (InstructionExecuted != null)
					frm.Invoke(InstructionExecuted, new object[] { this, new EventArgs() });

				//---- Priestorová zložitosť ------------
				// Jednotková
				if (spaceUniCounter < regs.regs.Count)
					spaceUniCounter = regs.regs.Count;
				// Logaritmická
				long curLogSpace = ComputeLogarithmicSpaceComplexity();
				if (spaceLogCounter < curLogSpace)
					spaceLogCounter = curLogSpace;

				if (Speed > 0)
				{
					Executing = true;
					ProgramPos = prgPointer;
					RunAnimation();
					Executing = false;                    
				}
				
			}
			catch (DivideByZeroException ex)
			{
				MessageBox.Show("Divide by zero.");
				prgPointer = program.Count;
			}
			catch
			{
				MessageBox.Show("Overflow.");
				prgPointer = program.Count;
			}
		}

		private bool ConsoleRead()
		{
			if (RamConsole)
			{
				if (InputNotTyped)
				{
					PrgStop = true;
					return true;
				}
				else
				{
					ConsoleContent += InputTape[InTapePointer];
					ConsoleContent += Environment.NewLine;
				}
			}
			InputNotTyped = true;
			return false;
		}

		private void NextStepAtMaxSpeed()
		{
			if (smallRegsUsed)
				NextStepAtMaxSpeedS();
			else
				NextStepAtMaxSpeedI();
		}

		private void NextStepAtMaxSpeedI()
		{
			//sRAMAtom curInstruction = null;

			try
			{
				if (prgPointer > program.Count - 1) return;

				RAMInstruction curInstruction = program[prgPointer];

				if (!curInstruction.Skip)
				{
					InfiniteInteger i;
					switch (curInstruction.Command)
					{
						case InstructionType.Print:
							WriteToConsole(labeledProgram[prgPointer].OpLabel);                            
							break;
						case InstructionType.Read: //Čítanie zo vstupnej pásky                            
							if (ConsoleRead()) return;
								
							i = curInstruction.GetAddress(ref regs);
							if (i != InfiniteInteger.negativeOne)
							{
								if (InTapePointer > InputTape.Count - 1)
								{
									//Celá páska načítaná
									PrgStatus = 3;
									EndOfPrg = true;
								}
								else
								{
									regs.SetValue(i, new InfiniteInteger(InputTape[InTapePointer]));
									InTapePointer += 1;
								}                                
							}
							break;
						case InstructionType.Write: //Zápis na výstupnú pásku                                                        
							i = curInstruction.GetAddress(ref regs);
							if (i != InfiniteInteger.negativeOne)
							{
								// Vypis na konzolu                                
								WriteToConsole(regs[i].Value.ToString());

								OutputTape.Add(regs[i].Value.ToString());
							}
							break;
						case InstructionType.Load: //Načítanie registra do akumulátora
							//Načíta hodnotu
							i = curInstruction.GetValue(ref regs);

							//Uloží hodnotu
							regs.SetValue(InfiniteInteger.zero, i);
							break;
						case InstructionType.Store: //Uloženie akumulátora do registra
							i = curInstruction.GetAddress(ref regs);
							regs.SetValue(i, regs[0].Value);
							break;
						case InstructionType.Push: //Vloží obsah akumulátora do zásobníka
							stack.Push(regs[0].Value);
							break;
						case InstructionType.Pop: //Vloží obsah z vrchu zásobníka do akumulátora                                                        
							i = stack.Pop();
							regs.SetValue(InfiniteInteger.zero, i);                            
							break;
						case InstructionType.Add: //Pripočítanie
							i = curInstruction.GetValue(ref regs);
							regs.IncrementValue(InfiniteInteger.zero, i);                            
							break;
						case InstructionType.Subs:  //Odčítanie
							i = curInstruction.GetValue(ref regs);
							regs.IncrementValue(InfiniteInteger.zero, -i); 
							break;
						case InstructionType.Div: //Delenie
							//long rem;
							i = curInstruction.GetValue(ref regs);
							regs.SetValue(InfiniteInteger.zero, regs[0].Value / i);
							break;
						case InstructionType.Mult: //Násobenie
							i = curInstruction.GetValue(ref regs);
							regs.MultValue(InfiniteInteger.zero, i);
							break;
						case InstructionType.Jump: //Skok
						case InstructionType.WhileBlockEnd: // Koniec bloku WHILE(GZERO)
							prgPointer = (curInstruction.Operand - InfiniteInteger.one).ToInt();
							break;
						case InstructionType.JZero: //Skok ak je nula
							if (regs[0].Value == InfiniteInteger.zero)
								prgPointer =  curInstruction.Operand.ToInt();

							if (regs[0].Value == InfiniteInteger.zero)
								prgPointer--;
							break;
						case InstructionType.IfBlockBegin: // Podmienka IF(GZERO)
						case InstructionType.WhileBlockBegin: // Začiatok bloku WHILE(GZERO)
							if (regs[0].Value <= InfiniteInteger.zero)
								prgPointer = (program[prgPointer].Operand - new InfiniteInteger(1)).ToInt();
							break;
						case InstructionType.JGZero: //Skok ak je väčšie ako nula
						case InstructionType.DoWhileBlockEnd: // Koniec bloku DO WHILE(GZERO)
							if (regs[0].Value > InfiniteInteger.zero)
								prgPointer = (curInstruction.Operand - InfiniteInteger.one).ToInt();
							break;
						case InstructionType.Halt: //Ukončenie programu
							EndOfPrg = true;
							return;
						case InstructionType.Accept: //Akceptovanie
							PrgStatus = 1;
							EndOfPrg = true;
							return;
						case InstructionType.Reject: //Neakceptovanies
							PrgStatus = 2;
							EndOfPrg = true;
							return;
					}

					CycleCount += 1;
				}

				prgPointer += 1;

			}
			catch
			{
				MessageBox.Show("Overflow.");
				prgPointer = program.Count;
			}
		}

		private void NextStepAtMaxSpeedS()
		{
			//sRAMAtom curInstruction = null;

			checked
			{
				try
				{
					if (prgPointer > program.Count - 1) return;

					RAMInstruction curInstruction = program[prgPointer];

					if (!curInstruction.Skip)
					{
						long i;
						switch (curInstruction.Command)
						{
							case InstructionType.Print:
								WriteToConsole(labeledProgram[prgPointer].OpLabel);
								break;
							case InstructionType.Read: //Čítanie zo vstupnej pásky                            
								if (ConsoleRead()) return;

								i = curInstruction.GetAddress(ref smallRegs);
								if (i != -1)
								{
									if (InTapePointer > InputTape.Count - 1)
									{
										//Celá páska načítaná
										PrgStatus = 3;
										EndOfPrg = true;
									}
									else
									{
										smallRegs.SetValue(i, Functions.ToValue(InputTape[InTapePointer]));
										InTapePointer += 1;
									}
								}
								break;
							case InstructionType.Write: //Zápis na výstupnú pásku                            

								i = curInstruction.GetAddress(ref smallRegs);
								if (i != -1)
								{
									// Vypis na konzolu                                    
									WriteToConsole(smallRegs[i].Value.ToString());

									OutputTape.Add(smallRegs[i].Value.ToString());
								}
								break;
							case InstructionType.Load: //Načítanie registra do akumulátora
								//Načíta hodnotu
								i = curInstruction.GetValue(ref smallRegs);

								//Uloží hodnotu
								smallRegs.SetValue(0, i);
								break;
							case InstructionType.Store: //Uloženie akumulátora do registra
								i = curInstruction.GetAddress(ref smallRegs);
								smallRegs.SetValue(i, smallRegs[0].Value);
								break;
							case InstructionType.Push: //Vloží obsah akumulátora do zásobníka
								stack.Push(new InfiniteInteger(smallRegs[0].Value));
								break;
							case InstructionType.Pop: //Vloží obsah z vrchu zásobníka do akumulátora                                                        
								i = stack.Pop().SmallValue;
								smallRegs.SetValue(0, i);
								break;
							case InstructionType.Add: //Pripočítanie
								i = curInstruction.GetValue(ref smallRegs);
								smallRegs.IncrementValue(0, i);
								break;
							case InstructionType.Subs:  //Odčítanie
								i = curInstruction.GetValue(ref smallRegs);
								smallRegs.IncrementValue(0, -i);
								break;
							case InstructionType.Div: //Delenie
								//long rem;
								i = curInstruction.GetValue(ref smallRegs);
								smallRegs.SetValue(0, smallRegs[0].Value / i);
								break;
							case InstructionType.Mult: //Násobenie
								i = curInstruction.GetValue(ref smallRegs);
								smallRegs.MultValue(0, i);
								break;
							case InstructionType.Jump: //Skok
							case InstructionType.WhileBlockEnd: // Koniec bloku WHILE(GZERO)
								prgPointer = (int)(curInstruction.Operand.ToLong() - 1);
								break;
							case InstructionType.JZero: //Skok ak je nula
								if (smallRegs[0].Value == 0)
									prgPointer = curInstruction.Operand.ToInt();

								if (smallRegs[0].Value == 0)
									prgPointer--;
								break;
							case InstructionType.IfBlockBegin: // Podmienka IF(GZERO)
							case InstructionType.WhileBlockBegin: // Začiatok bloku WHILE(GZERO)
								if (smallRegs[0].Value <= 0)
									prgPointer = (program[prgPointer].Operand.ToInt() - 1);
								break;
							case InstructionType.JGZero: //Skok ak je väčšie ako nula
							case InstructionType.DoWhileBlockEnd: // Koniec bloku DO WHILE(GZERO)
								if (smallRegs[0].Value > 0)
									prgPointer = (int)(curInstruction.Operand.ToLong() - 1);
								break;
							case InstructionType.Halt: //Ukončenie programu
								EndOfPrg = true;
								return;
							case InstructionType.Accept: //Akceptovanie
								PrgStatus = 1;
								EndOfPrg = true;
								return;
							case InstructionType.Reject: //Neakceptovanies
								PrgStatus = 2;
								EndOfPrg = true;
								return;
						}

						CycleCount += 1;
					}

					prgPointer += 1;

				}
				catch
				{
					// Nastalo pretečenie - pouzit nekonecne registry                    
					if (smallRegsUsed) regs.GetData(smallRegs);
					smallRegsUsed = false;
					NextStepAtMaxSpeedI();
				}
			}

		}

		private long ComputeLogarithmicSpaceComplexity()
		{
			long c=0;
			foreach (KeyValuePair<InfiniteInteger,RegisterCell> reg in regs.regs)
			{
				c += LogCost(reg.Value.Value);
				//if (reg.Value.Value == 0)
				//    c++;
				//else                    
				//    c += (long)Math.Ceiling(Math.Log(reg.Value.Value + 1, 10));
			}
			return c;
		}


		private void Execution()
		{
			PrgStatus = 0;
			//sbyProgram.Hide();
			do
			{
				if (EndOfPrg) break;

				NextStep();

				//Breakpoint
				if (prgPointer < program.Count && program[prgPointer].Stop)
				{
					PrgStop = true;
					if (ProgramPaused != null) frm.Invoke(ProgramPaused, new object[] { this, new EventArgs() });
					return;
				}

				//Pauza
				if (PrgStop)
				{
					if (ProgramPaused != null) frm.Invoke(ProgramPaused, new object[] { this, new EventArgs() });
					return;
				}

				if (Speed > 0) System.Threading.Thread.Sleep(Speed);
				//System.Threading.Thread.CurrentThread.Sleep(Speed);
			}

			while (!(prgPointer > program.Count - 1 || EndOfPrg));
			
			ExecutionFinish();         
		}

		public void Run()
		{
			if (PrgStop == false) return;
			if (program == null) return;
			if ((PrgThread != null))
				PrgThread.Interrupt();
			if (EndOfPrg) Reset();

			smallRegsUsed = false;

			PrgStop = false;                                                
			StartTime = DateTime.Now.Ticks;            

			PrgThread = new System.Threading.Thread(Execution);
			PrgThread.Start();
		}

		public void Stop()
		{            
			PrgStop = true;
			EndOfPrg = true;
		}

		public void Reset()
		{
			//Zmaže počítadlá
			ClearCounters();

			// Zmaže zásobník
			stack.Clear();

			CycleCount = 0;
			prgPointer = 0;
			EndOfPrg = false;
			regs.ClearValues();
			smallRegs.ClearValues();
			
			ConsoleContent = "";
			InputNotTyped = true;

			//InputTape.Clear();
			InTapePointer = 0;

			StartTime = 0;            
		}

		private void AnimOp()
		{
			if (Speed > 0)
			{
				if (program[prgPointer].GetAddress(ref regs) >= InfiniteInteger.zero)
				{
					ReadPos = program[prgPointer].GetAddress(ref regs).ToInt();
					Reading = true;
					//DrawAnimation();
					if (RefreshAnimation != null)
						frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					Reading = false;
					//this.InvokeRefresh(pProc);
					if (RefreshAnimation != null)
						frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
				}

				WritePos = 0;
				Writing = true;
				//DrawAnimation();
				if (RefreshAnimation != null)
					frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
				Writing = false;                
				//this.InvokeRefresh(pProc);
				if (RefreshAnimation != null)
					frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
			}
		}

		public void InvertBreakPointAt(int i)
		{
			RAMInstruction a = program[i];
			a.Stop = !a.Stop;
			program[i] = a;
		}

		public void InvertSkipPointAt(int i)
		{
			RAMInstruction a = program[i];
			a.Skip = !a.Skip;
			program[i] = a;
		}

		private void RunAnimation()
		{
			bool tmpR = Reading;
			bool tmpW = Writing;
			bool tmpE = Executing;

			//Čítanie z registrov
			Reading = false;
			Writing = false;
			Executing = false;
			//this.InvokeRefresh(pProc);
			if (RefreshAnimation != null)
				frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });

			if (Math.Abs(ReadPos - LastRP) > 0.9)
			{
				double endPos = ReadPos;
				double startPos = LastRP;
				double step = (endPos - startPos) / 20;
				if (step > 0)
				{
					for (double a = startPos; a <= endPos; a += step)
					{
						CurReadPos = a;
						//this.InvokeRefresh(pProc);
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				else
				{
					for (double a = startPos; a >= endPos; a += step)
					{
						CurReadPos = a;
						//this.InvokeRefresh(pProc);
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				LastRP = CurReadPos;                
			}
			Reading = tmpR;

			//Zapisovanie do registrov
			if (Math.Abs(WritePos - LastWP) > 0.9)
			{
				double endPos = WritePos;
				double startPos = LastWP;
				double step = (endPos - startPos) / 20;
				if (step > 0)
				{
					for (double a = startPos; a <= endPos; a += step)
					{
						CurWritePos = a;
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				else
				{
					for (double a = startPos; a >= endPos; a += step)
					{
						CurWritePos = a;
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				LastWP = CurWritePos;      
			}
			Writing = tmpW;

			//Čítanie programu
			if (Math.Abs(ProgramPos - LastPP) > 0.9)
			{
				double endPos = ProgramPos;
				double startPos = LastPP;
				double step = (endPos - startPos) / 20;
				if (step > 0)
				{
					for (double a = startPos; a <= endPos; a += step)
					{
						CurProgramPos = a;
						//this.InvokeRefresh(pProc);
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				else
				{
					for (double a = startPos; a >= endPos; a += step)
					{
						CurProgramPos = a;
						//this.InvokeRefresh(pProc);
						if (RefreshAnimation != null)
							frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
					}
				}
				LastPP = CurProgramPos;
			}
			Executing = tmpE;                  

			//this.InvokeRefresh(pProc);this.InvokeRefresh(lstRegs);
			if (RefreshAnimation != null)
				frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });

			if (Speed > 0)
				System.Threading.Thread.Sleep(Speed);

			//this.InvokeRefresh(lstRegs);
			if (RefreshAnimation != null)
				frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });
		}

		//Logaritmická zložitosť pre číslo i
		public static int LogCost(InfiniteInteger i)
		{
			if (i != InfiniteInteger.zero)
				return (int)i.AbsoluteValue.ToString().Length + 1;
			else
				return 1;
		}

		//Logaritmická zložitosť pre číslo i
		public static int LogCost(int i)
		{
			if (i != 0)
				return (int)(Math.Floor(Math.Log10(Math.Abs(i)))) + 1;
			else
				return 1;
		}

		//Logaritmická zložitosť pre číslo i
		public static long LogCost(long i)
		{
			if (i != 0)
				return (long)(Math.Floor(Math.Log10(Math.Abs(i)))) + 1;
			else
				return 1;
		}


		public void RunAtMaxSpeed()
		{
			if (PrgStop == false) return;
			if (program == null) return;
			if ((PrgThread != null))
				PrgThread.Interrupt();
			if (EndOfPrg) Reset();

			smallRegsUsed = true;

			PrgStop = false;
			StartTime = DateTime.Now.Ticks;                       

			PrgThread = new System.Threading.Thread(ExecutionAtMaxSpeed);
			PrgThread.Start();
		}

		private void ExecutionAtMaxSpeed()
		{
			PrgStatus = 0;            
			do
			{
				if (EndOfPrg) break;

				NextStepAtMaxSpeed();

				//Breakpoint
				if (prgPointer < program.Count && program[prgPointer].Stop)
				{
					PrgStop = true;
					if (ProgramPaused != null) frm.Invoke(ProgramPaused, new object[] { this, new EventArgs() });
					return;
				}                                                
			}

			while (!(prgPointer > program.Count - 1 || EndOfPrg));

			ExecutionFinish();
		}

		private void ExecutionFinish()
		{
			try
			{
				if (RefreshAnimation != null)
					frm.Invoke(RefreshAnimation, new object[] { this, new EventArgs() });

				// Skonvertovanie na nekonecne registre (iba tie sa zobrazuju v GUI)
				if (smallRegsUsed) regs.GetData(smallRegs);

				//Vypísanie stavu akceptovania
				if (PrgStatus == 1)
				{
					OutputTape.Add("(Accepted)");
					if (OutputTapeChanged != null) frm.Invoke(OutputTapeChanged, new object[] { this, new EventArgs() });
					WriteToConsole("(Accepted)");
				}
				else if (PrgStatus == 2)
				{
					OutputTape.Add("(Rejected)");
					if (OutputTapeChanged != null) frm.Invoke(OutputTapeChanged, new object[] { this, new EventArgs() });
					WriteToConsole("(Rejected)");
				}
				else if (PrgStatus == 3)
				{
					OutputTape.Add("(End of tape)");
					if (OutputTapeChanged != null) frm.Invoke(OutputTapeChanged, new object[] { this, new EventArgs() });
					WriteToConsole("(End of tape))");
				}

				WriteToConsole("(End of program)");

				if (ProgramFinished != null)
					frm.Invoke(ProgramFinished, new object[] { this, new EventArgs() });

				PrgStop = true;
				EndOfPrg = true;
			}
			catch { }
		}

		public void WriteToConsole(string text)
		{
			if (RamConsole)
			{
				ConsoleContent += text;
				ConsoleContent += Environment.NewLine;
				
				if (ConsoleChanged != null)
					frm.Invoke(ConsoleChanged, new object[] { this, new EventArgs() });                
			}
		}
	}
}
