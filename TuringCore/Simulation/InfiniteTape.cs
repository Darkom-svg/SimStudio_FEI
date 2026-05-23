using System;
using System.Collections;
using System.Collections.Generic;

namespace FEI.TuringCore.Simulation {
	//Nekonečná páska
	[Serializable]
	public class InfiniteTape {
		#region Consts
		//Prázdne políčko
		public const string Blank = "Blank";

		//Farebné políčka
		public const string White = "White";
		public const string Black = "Black";
		public const string Blue = "Blue";
		public const string Green = "Green";
		public const string Red = "Red";
		public const string Yellow = "Yellow";
		public const string Orange = "Orange";
		public const string Purple = "Purple";
		public const string Cyan = "Cyan";
		public const string Magenta = "Magenta";
		#endregion

		private Dictionary<int, string> cells = new Dictionary<int, string>();
		private int headPosition = 0;

		#region Properties
		public int HeadPosition {
			get => headPosition;
			set => headPosition = value;
		}

		public string CurrentSymbol {
			get => this[headPosition];
			set => this[headPosition] = value;
		}

		public string this[int index] {
			get => GetCell(index);
			set => SetCell(index, value);
		}
		#endregion

		public string GetCell(int index) {
			if (cells.ContainsKey(index)) {
				return cells[index];
			} else {
				return Blank;
			}
		}

		public void SetCell(int index, string value) {
			if (cells.ContainsKey(index)) {
				if (value == Blank) {
					cells.Remove(index);
				} else {
					cells[index] = value;
				}
			} else {
				if (value != Blank)
					cells.Add(index, value);
			}
		}

		public int GetFirstNonBlankCell() {
			int min = int.MaxValue;
			IDictionaryEnumerator en = this.cells.GetEnumerator();
			en.Reset();
			while (en.MoveNext()) {
				if ((int)en.Key < min) {
					min = (int)en.Key;
				}
			}
			return min;
		}

		public int GetLastNonBlankCell() {
			int max = int.MinValue;
			IDictionaryEnumerator en = this.cells.GetEnumerator();
			en.Reset();
			while (en.MoveNext()) {
				if ((int)en.Key > max) {
					max = (int)en.Key;
				}
			}
			return max;
		}

		public int GetNextNonBlankCell(int from) {
			int min = int.MaxValue;
			IDictionaryEnumerator en = this.cells.GetEnumerator();
			en.Reset();
			while (en.MoveNext()) {
				if ((int)en.Key > from && (int)en.Key < min) {
					min = (int)en.Key;
				}
			}
			return min;
		}

		public int[] GetNonBlankCellIndices() {
			ArrayList indices = new ArrayList();
			IDictionaryEnumerator en = this.cells.GetEnumerator();

			en.Reset();
			while (en.MoveNext()) {
				indices.Add(en.Key);
			}

			indices.Sort();
			return (int[])indices.ToArray(typeof(int));
		}

		//Vytvorí kópiu pásky
		public InfiniteTape Clone() {
			InfiniteTape newInfiniteTape = new InfiniteTape();
			{
				newInfiniteTape.cells = new Dictionary<int, string>(this.cells);
				newInfiniteTape.headPosition = this.headPosition;
			}
			return newInfiniteTape;
		}

		//Komprimuje pásku - vynechá prázdne miesta
		public void Compress() {
			int i = this.GetFirstNonBlankCell();
			int ni = i;
			int li = this.GetLastNonBlankCell();

			while (ni != li) {
				ni = this.GetNextNonBlankCell(i);
				if (ni == int.MaxValue) break;

				if (ni != i + 1) {
					this.cells.Add(i + 1, this.cells[ni]);
					this.cells.Remove(ni);
				}

				i++;
			}
		}

		//Vráti tabuľku s počtom použitých symbolov
		public Dictionary<string, int> GetSymbolCounts() {
			Dictionary<string, int> arr = new Dictionary<string, int>();
			int ni = this.GetFirstNonBlankCell();
			int li = this.GetLastNonBlankCell();;

			while (ni != int.MaxValue) {
				if (arr.ContainsKey(this.cells[ni])) {
					arr[this.cells[ni]] += 1;
				} else {
					arr.Add(this.cells[ni], 1);
				}

				ni = this.GetNextNonBlankCell(ni);
			}

			return arr;
		}

		//Vráti zoznam s použitými symbolmi
		public List<string> GetUsedSymbols() {
			List<string> retval = new List<string>();
			int ni = this.GetFirstNonBlankCell();
			int li = this.GetLastNonBlankCell();

			while (ni != int.MaxValue) {
				if (!retval.Contains(this.cells[ni])) {
					retval.Add(this.cells[ni]);
				}

				ni = this.GetNextNonBlankCell(ni);
			}

			return retval;
		}

		//Vráti počet použitých (neprázdnych) buniek pásky
		public int GetNonBlankCellsCount() {
			return this.cells.Count;
		}

		public static List<InfiniteTape> DeepCopyTapes(List<InfiniteTape> tapes) {
			List<InfiniteTape> retval = new List<InfiniteTape>(tapes.Count);

			foreach (InfiniteTape tape in tapes) {
				retval.Add(tape.Clone());
			}
			return retval;
		}

		public string GetNextSymbol(bool toRight) {
			if (toRight) {
				return this[headPosition + 1];
			} else {
				return this[headPosition - 1];
			}
		}

		public void MoveHeadLeft() {
			headPosition--;
		}

		public void MoveHeadRight() {
			headPosition++;
		}

		public static bool IsBlank(string symbol) {
			if (symbol == "" || symbol == InfiniteTape.Blank)
				return true;
			else
				return false;
		}

	}
}
