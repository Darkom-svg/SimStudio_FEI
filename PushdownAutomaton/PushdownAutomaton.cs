using System;
using System.Collections.Generic;
using FEI.TuringCore.Simulation;

namespace FEI.PushdownAutomaton {
	public class PushdownAutomaton : VirtualTuringMachine
	{        
		public override void Reset()
		{
			base.Reset();
		}

		public override bool IsTransitionSatisfied(Transition transition, string curState, string curSymbol)
		{
			return CurrentState == curState && CompareSymbols(transition.ReadSymbol, curSymbol) && ActiveThread.Stack.Peek() == transition.StackRead;    
		}

		public override void TransitionSucceed(Transition transition, TuringThread thread, string curSymbol)
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

			foreach (var chr in transition.StackRead)                            
				thread.Stack.Pop();
			for (int j = transition.StackWrite.Length - 1; j >= 0; j--) {
				char c = transition.StackWrite[j];
				thread.Stack.Push(c.ToString());
			}
			//foreach (var chr in transition.StackWrite)
			//    thread.Stack.Push(chr.ToString());
			if (thread.Stack.Count == 0) thread.Stack.Push("Z");

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

		public string GetUsedStackSymbolsAsString()
		{
			// Symboly na páske
			List<string> retval = new List<string>();

			// Symboly v prechodových funkciách
			foreach (Transition f in TransitionFunction)
			{
				foreach (var c in f.StackRead)
				{
					if (!retval.Contains(c.ToString()))
					{
						retval.Add(c.ToString());
					}
				}
				foreach (var c in f.StackWrite)
				{
					if (!retval.Contains(c.ToString()))
					{
						retval.Add(c.ToString());
					}
				}
			}

			return String.Join(", ", retval.ToArray());
		}
	}
}
