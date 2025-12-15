using DusanRodina.SimStudio.Components;
using DusanRodina.TuringCore.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DusanRodina.TuringCore.Components {
	[Serializable]
	public partial class InfiniteTapeControl : UserControl
	{
		private AcceptanceStatus acceptStatus = AcceptanceStatus.None;
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		private List<InfiniteTape> tapes = new List<InfiniteTape>();        

		private bool changesAllowed = true;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		private List<List<Rectangle>> Cells = new List<List<Rectangle>>();
		private int FirstIndex;
		private int HoverCell = int.MinValue;
		private int HoverTape = -1;

		private int editedCell = int.MinValue;
		private int editedTape = -1;

		//Udalosti        
		public event EventHandler TapeChanged;
		public event EventHandler HeadPositionChanged;
		public event EventHandler TapeCannotBeChanged;

		public InfiniteTapeControl()
		{
			InitializeComponent();

			tapes.Add(new InfiniteTape());
			Cells.Add(new List<Rectangle>());
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<InfiniteTape> Tapes
		{
			get { return tapes; }
			set 
			{ 
				tapes = value;
				pTape.Refresh();
			}
		}

		private bool allowBlanks = true;
		public bool AllowBlanks
		{
			get { return allowBlanks; }
			set { allowBlanks = value; }
		}

		private bool isInfinite = true;
		public bool IsInfinite
		{
			get { return isInfinite; }
			set { isInfinite = value; }
		}

		public bool ChangesAllowed
		{
			get { return changesAllowed; }
			set
			{
				changesAllowed = value;
				pTape.Refresh();
			}
		}

		public AcceptanceStatus AcceptStatus
		{
			get { return acceptStatus; }
			set 
			{ 
				acceptStatus = value;
				pTape.Refresh();
			}
		}

		public void SetHeadPosition(int tapeIndex, int position)
		{
			tapes[tapeIndex].HeadPosition = position;            
			pTape.Refresh();            
		}

		public List<string> CurrentSymbols
		{
			get
			{
				List<string> retval = new List<string>(tapes.Count);
				foreach (InfiniteTape tape in tapes)
				{
					retval.Add(tape.CurrentSymbol);
				}
				return retval;
			}
			set
			{
				for (int i = 0; i < tapes.Count; i++)
				{
					tapes[i].CurrentSymbol = value[i];
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public List<int> HeadPositions
		{
			get
			{
				List<int> retval = new List<int>(tapes.Count);
				foreach (InfiniteTape tape in tapes)
				{
					retval.Add(tape.HeadPosition);
				}
				return retval;
			}
			set
			{
				for (int i = 0; i < tapes.Count; i++)
				{
					tapes[i].HeadPosition = value[i];
				}
			}
		}


		public int GetHeadPosition(int tapeIndex)
		{
			return tapes[tapeIndex].HeadPosition;
		}

		private void pTape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{            
			Graphics g = e.Graphics;

			DrawTapes(g, new Rectangle(0, 0, pTape.Width, pTape.Height), acceptStatus);

			g.DrawRectangle(Pens.Black, 0, 0, pTape.Width - 1, pTape.Height - 1);

			if (EditedTape >= 0 && editedCell - FirstIndex >= 0 && editedCell - FirstIndex < Cells[EditedTape].Count)
			{
				txtSymbol.Left = Cells[EditedTape][editedCell - FirstIndex].Left;
				txtSymbol.Width = Cells[EditedTape][editedCell - FirstIndex].Width;
				txtSymbol.Top = Cells[EditedTape][editedCell - FirstIndex].Top +
					(Cells[EditedTape][editedCell - FirstIndex].Height - txtSymbol.Height) / 2;
			}
			else
				txtSymbol.Left = pTape.Width + 200;            
		}

		private void DrawTapes(Graphics g, Rectangle bounds, AcceptanceStatus acceptStatus)
		{
			List<Rectangle> newCells;
			Cells.Clear();

			int h = bounds.Height / tapes.Count;
			for (int i = 0; i < tapes.Count; i++)
			{
				Rectangle tapeBounds = new Rectangle(bounds.X, bounds.Y + h * i, bounds.Width, h);
				newCells = InfiniteTapeControl.DrawTape(g, tapeBounds, tapes[i], 
					acceptStatus, sbxTape.Value, HoverCell, isInfinite, 
					out FirstIndex);

				Cells.Add(newCells);
			}
		}

		public static List<Rectangle> DrawTape(Graphics g, Rectangle bounds, InfiniteTape tape,
			AcceptanceStatus acceptStatus, int scrollX, int HoverCell, bool isInfinite,
			out int firstIndex)
		{
			if (tape == null)
			{
				firstIndex = 0;
				return new List<Rectangle>();
			}

			// Zoznam umiestneni jednotlivych buniek pasky na obrazovke
			List<Rectangle> retval = new List<Rectangle>();

			Rectangle rect;                        

			g.SmoothingMode = SmoothingMode.AntiAlias;

			//Akceptácia
			if (acceptStatus == AcceptanceStatus.None)
			{
				g.FillRectangle(Brushes.White, bounds);
			}
			else if (acceptStatus == AcceptanceStatus.Accept)
			{
				g.FillRectangle(Brushes.LightGreen, bounds);
			}
			else if (acceptStatus == AcceptanceStatus.Reject)
			{
				g.FillRectangle(Brushes.LightPink, bounds);
			}

			int pos = scrollX;
			if (isInfinite) pos -= (int)Math.Floor((double)bounds.Width / 2); else pos -= 40;
			int posPlus = (pos < 0) ? -1 : 0;
			int startI = (int)Math.Floor((double)(pos + posPlus) / 40);
			int startX = 0;
			startX = 40 - (-pos % 40);
			if (pos < 0)
			{
				startI++;
			}
			
			bool firstIndexAssigned = false;
			firstIndex = 0;
			retval.Clear();
			for (int a = -1; a <= (int)Math.Floor((double)bounds.Width / 40) + 1; a++)
			{
				int index = a + startI;
				if (!isInfinite && index < 0) continue;
				if (!isInfinite && index > tape.GetNonBlankCellsCount()) break;
				if (!firstIndexAssigned)
				{
					firstIndexAssigned = true;
					firstIndex = index;
				}

				int x = a * 40 - startX;
				int y = (int)Math.Floor((double)(bounds.Height - 35) / 2) + bounds.Top;
				rect = new Rectangle(x, y, 35, 35);

				//Aktuálna pozícia
				if (tape.HeadPosition == index)
				{
					Rectangle headBounds = new Rectangle(x - 2, bounds.Top+3, 39, bounds.Height-6);

					Functions.FillGlossRoundRectangle(g,
						Brushes.Orange,
						headBounds, 5);
					Functions.DrawRoundRectangle(g, new Pen(Color.FromArgb(90, Color.White), 3), headBounds, 5);
					Functions.DrawRoundRectangle(g, Pens.Black, headBounds, 5);                                        

					// Horná šípka
					GraphicsPath arrow1 = new GraphicsPath();
					arrow1.AddPolygon(new Point[]{
						new Point(headBounds.X + headBounds.Width / 2 - 5, headBounds.Y + 2), 
						new Point(headBounds.X + headBounds.Width / 2 + 5, headBounds.Y + 2), 
						new Point(headBounds.X + headBounds.Width / 2, headBounds.Y + 8)});
					g.DrawPath(new Pen(Color.FromArgb(90, Color.White), 3), arrow1);
					g.FillPath(Brushes.Black, arrow1);

					// Spodná šípka
					GraphicsPath arrow2 = new GraphicsPath();
					arrow2.AddPolygon(new Point[]{
						new Point(headBounds.X + headBounds.Width / 2 - 5, headBounds.Bottom - 2), 
						new Point(headBounds.X + headBounds.Width / 2 + 5, headBounds.Bottom - 2), 
						new Point(headBounds.X + headBounds.Width / 2, headBounds.Bottom - 8)});
					g.DrawPath(new Pen(Color.FromArgb(90, Color.White), 3), arrow2);
					g.FillPath(Brushes.Black, arrow2);

					if (HoverCell == index)
					{
						Functions.DrawRoundRectangle(g, new Pen(Color.FromArgb(80, Color.Black), 3),
							headBounds, 5);
					}
				}
				else if (HoverCell == index)
				{
					g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Orange)), new Rectangle(x - 2, bounds.Top, 39, bounds.Height));
				}
				
				DrawTapeSymbol(g, tape[index], rect, tape.HeadPosition == index);                

				//Zapamätanie si umiestnení zobrazených buniek
				retval.Add(rect);
			}

			//Akceptácia            
			if (acceptStatus == AcceptanceStatus.Accept)
			{
				g.DrawString("Akceptované", new Font("Arial", 12, FontStyle.Bold), Brushes.Black,
					new RectangleF(bounds.Width - 130, bounds.Height - 20, 130, 20));
			}
			else if (acceptStatus == AcceptanceStatus.Reject)
			{
				g.DrawString("Neakceptované", new Font("Arial", 12, FontStyle.Bold), Brushes.Black,
					new RectangleF(bounds.Width - 130, bounds.Height - 20, 130, 20));
			}

			return retval;
		}

		public static void DrawTapeSymbol(Graphics g, string symbol, Rectangle rect)
		{
			DrawTapeSymbol(g, symbol, rect, Color.Transparent, false);
		}

		public static void DrawTapeSymbol(Graphics g, string symbol, Rectangle rect, bool underHead)
		{
			DrawTapeSymbol(g, symbol, rect, Color.Transparent, underHead);
		}

		public static void DrawTapeSymbol(Graphics g, string symbol, Rectangle rect, Color highlightColor, bool underHead)
		{
			Font fnt = new Font("Arial", 10);
			Font ufnt = new Font("Arial", 10, FontStyle.Underline);

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;

			Pen blankPen = new Pen(Color.DarkGreen, 4);
			LinearGradientBrush blankBrush;

			//Zvýraznenie
			if (!underHead)
			{
				if (highlightColor.A != 0)
				{
					Functions.DrawRoundRectangle(g, new Pen(highlightColor, 6), rect, 5);
				}
			}
			else
			{
				Functions.DrawRoundRectangle(g, new Pen(Color.FromArgb(80,Color.Black), 2), rect, 5);
			}

			if (InfiniteTape.IsBlank(symbol))
			{
				//Prázdny symbol
				//Pozadie políčka
				if (!underHead)                
					blankBrush = new LinearGradientBrush(rect, Color.LightGreen, Color.White, LinearGradientMode.Vertical);                
				else
					blankBrush = new LinearGradientBrush(rect, Color.LightGreen, Color.Transparent, LinearGradientMode.Vertical);
				Functions.FillRoundRectangle(g, blankBrush, rect, 5);                
				//Krížik
				g.DrawLine(blankPen, rect.X + 8, rect.Y + 8, rect.Right - 8, rect.Bottom - 8);
				g.DrawLine(blankPen, rect.Right - 8, rect.Y + 8, rect.X + 8, rect.Bottom - 8);
			}
			else
			{
				//Symbol
				//Pozadie políčka
				if (!underHead)
				{
					blankBrush = new LinearGradientBrush(rect, Color.LightGray, Color.White, LinearGradientMode.Vertical);
					Functions.FillRoundRectangle(g, blankBrush, rect, 5);
				}

				//Špeciálny obdĺžnik - na farby
				RectangleF irect = rect;
				irect.Inflate(-5, -5);

				//Symbol
				switch (symbol)
				{
					case InfiniteTape.White:
						Functions.FillGlossRoundRectangle(g, Brushes.White, irect, 5);
						break;
					case InfiniteTape.Black:
						Functions.FillGlossRoundRectangle(g, Brushes.Black, irect, 5);
						break;
					case InfiniteTape.Blue:
						Functions.FillGlossRoundRectangle(g, Brushes.Blue, irect, 5);
						break;
					case InfiniteTape.Green:
						Functions.FillGlossRoundRectangle(g, Brushes.Green, irect, 5);
						break;
					case InfiniteTape.Orange:
						Functions.FillGlossRoundRectangle(g, Brushes.Orange, irect, 5);
						break;
					case InfiniteTape.Purple:
						Functions.FillGlossRoundRectangle(g, Brushes.Purple, irect, 5);
						break;
					case InfiniteTape.Red:
						Functions.FillGlossRoundRectangle(g, Brushes.Red, irect, 5);
						break;
					case InfiniteTape.Yellow:
						Functions.FillGlossRoundRectangle(g, Brushes.Yellow, irect, 5);
						break;
					case InfiniteTape.Cyan:
						Functions.FillGlossRoundRectangle(g, Brushes.Cyan, irect, 5);
						break;
					case InfiniteTape.Magenta:
						Functions.FillGlossRoundRectangle(g, Brushes.Magenta, irect, 5);
						break;
					default:
						string txt = symbol;
						if (txt.Contains("@"))
						{
							g.DrawEllipse(new Pen(Color.Black, 2), irect);
							txt = txt.Replace("@", "");
						}

						if (txt.EndsWith("_") || txt.StartsWith("_"))
						{
							int eu = 0, su = 0; // eu - podčiarknutia, su - nadčiarknutia

							for (int a = txt.Length - 1; a > 0; a--)
								if (txt[a] == '_') eu++; else break;

							for (int a = 0; a < txt.Length - eu; a++)
								if (txt[a] == '_') su++; else break;

							string symb = txt.Substring(su, txt.Length - su - eu);
							if (symb.Length == 0) symb = " "; //Neplatný vstup (iba podčiarknutia)

							g.DrawString(symb, fnt, Brushes.Black, (RectangleF)(rect), sf);
							sf.SetMeasurableCharacterRanges(new CharacterRange[] { new CharacterRange(0, symb.Length) });
							Region[] reg = g.MeasureCharacterRanges(symb, fnt, (RectangleF)rect, sf);
							RectangleF srect = reg[0].GetBounds(g);

							for (int a = 0; a < eu; a++)
							{
								g.DrawLine(Pens.Black, new PointF(srect.X, srect.Bottom + a * 3),
													   new PointF(srect.Right, srect.Bottom + a * 3));
							}
							for (int a = 0; a < su; a++)
							{
								g.DrawLine(Pens.Black, new PointF(srect.X, srect.Y - a * 3),
													   new PointF(srect.Right, srect.Y - a * 3));
							}
						}
						else
						{
							g.DrawString(txt, fnt, Brushes.Black, (RectangleF)(rect), sf);
						}
						break;
				}
			}

			//Zvýraznenie
			if (highlightColor.A != 0)
			{
				Functions.FillRoundRectangle(g, new SolidBrush(Color.FromArgb(50, highlightColor)), rect, 5);
			}

			//Okraj políčka            
			if (!underHead)
			{
				Functions.DrawRoundRectangle(g, new Pen(Color.FromArgb(90, Color.Black), 2), Rectangle.Inflate(rect, -1, -1), 5);
				Functions.DrawRoundRectangle(g, Pens.Black, rect, 5);
			}
		}
		

		private void pTape_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			for (int tapeIndex = 0; tapeIndex <= Tapes.Count - 1; tapeIndex++)
			{
				for (int cellIndex = 0; cellIndex <= Cells[tapeIndex].Count - 1; cellIndex++)
				{
					{
						if (((Rectangle)Cells[tapeIndex][cellIndex]).Contains(e.X, e.Y))
						{
							HoverCell = FirstIndex + cellIndex;
							HoverTape = tapeIndex;

							pTape.Invalidate();
							pTape.Update();
							pTape.Cursor = Cursors.Default;
							return;
						}
					}
				}
			}

			pTape.Cursor = Cursors.VSplit;
			HoverCell = int.MinValue;
			pTape.Invalidate();
			pTape.Update();
		}

		private void pTape_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (HoverCell != int.MinValue)
			{
				EditedTape = HoverTape;

				if (changesAllowed)
				{
					Tapes[HoverTape].HeadPosition = HoverCell;
					if (HeadPositionChanged != null) HeadPositionChanged(this, new EventArgs());

					txtSymbol.Visible = false;
				}
				else
				{
					if (TapeCannotBeChanged != null) TapeCannotBeChanged(this, new EventArgs());
				}

				if (e.Button == MouseButtons.Right || e.Clicks == 2)
				{

					editedCell = HoverCell;
					editedTape = HoverTape;
					txtSymbol.Text = Tapes[HoverTape][HoverCell];
					txtSymbol.Bounds = Cells[HoverTape][HoverCell - FirstIndex];
					txtSymbol.SelectionStart = 0;
					txtSymbol.SelectionLength = txtSymbol.Text.Length + 1;
					txtSymbol.Visible = true;
					txtSymbol.Focus();

				}
			}
		}

		private void txtSymbol_TextChanged(object sender, System.EventArgs e)
		{
			if (changesAllowed)
			{
				string symbol = (txtSymbol.Text.Trim() == "") ? "Blank" : txtSymbol.Text;

				if (!isInfinite && editedCell <= tapes[editedTape].GetLastNonBlankCell() && symbol == "Blank") 
					MessageBox.Show("Vstup nemôže obsahovať Blank-symbol.", "Chybný vstup", MessageBoxButtons.OK, MessageBoxIcon.Information);
				else
				{
					Tapes[editedTape][editedCell] = symbol;
					if (TapeChanged != null) TapeChanged(this, new EventArgs());
				}
			}
			else
			{
				if (TapeCannotBeChanged != null) TapeCannotBeChanged(this, new EventArgs());
			}
			
		}

		private void txtSymbol_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				EditNextSymbol();
				SetScrollbars();
			}
			else if (e.KeyCode == Keys.Left)
			{
				if (txtSymbol.SelectionStart == 0 && txtSymbol.SelectionLength == 0)
				{
					EditPreviousSymbol();
				}
			}
			else if (e.KeyCode == Keys.Right)
			{
				if (txtSymbol.SelectionStart == txtSymbol.Text.Length && txtSymbol.SelectionLength == 0)
				{
					EditNextSymbol();
				}
			}
		}

		private void EditPreviousSymbol()
		{            
			editedCell--;
			txtSymbol.Text = Tapes[editedTape][editedCell];

			if (editedCell - FirstIndex >= 0 && editedCell - FirstIndex < Cells.Count)
				txtSymbol.Bounds = Cells[editedTape][editedCell - FirstIndex];
			txtSymbol.SelectionStart = 0;
			txtSymbol.SelectionLength = txtSymbol.Text.Length + 1;
			txtSymbol.Visible = true;
			txtSymbol.Focus();

			pTape.Invalidate();
		}

		private void EditNextSymbol()
		{
			editedCell++;
			txtSymbol.Text = Tapes[editedTape][editedCell];

			if (editedCell - FirstIndex >= 0 && editedCell - FirstIndex < Cells.Count)
				txtSymbol.Bounds = Cells[editedTape][editedCell - FirstIndex];
			txtSymbol.SelectionStart = 0;
			txtSymbol.SelectionLength = txtSymbol.Text.Length + 1;
			txtSymbol.Visible = true;
			txtSymbol.Focus();

			pTape.Invalidate();
		}

		private void txtSymbol_LostFocus(object sender, System.EventArgs e)
		{
			txtSymbol.Visible = false;
			SetScrollbars();
		}

		private void SetScrollbars()
		{
			int firstCell = int.MaxValue;
			int lastCell = int.MinValue;

			for (int i = 0; i < tapes.Count; i++)
			{
				int first = tapes[i].GetFirstNonBlankCell();
				int last = tapes[i].GetLastNonBlankCell();
				if (first < firstCell) firstCell = first;
				if (last > lastCell) lastCell = last;
			}
			if (!isInfinite) firstCell = 0;

			sbxTape.LargeChange = (int)Math.Floor((double)pTape.Width / 2);
			if (isInfinite)
				sbxTape.Minimum = (firstCell - 20) * 40;
			else
				sbxTape.Minimum = 0;
			sbxTape.Maximum = (lastCell + 20) * 40;
		}

		private void sbxTape_ValueChanged(object sender, EventArgs e)
		{
			pTape.Invalidate();            
		}

		private void sbxTape_Scroll(object sender, ScrollEventArgs e)
		{
			sbxTape_ValueChanged(sender, new EventArgs());
		}

		private void pTape_Resize(object sender, EventArgs e)
		{
			SetScrollbars();
			pTape.Invalidate();
		}

		//Upravenie pohľadu na pásku tak, aby bola čítacia hlava viditeľná
		public void AdjustTapeView(int position)
		{
			/*Rectangle bounds = new Rectangle(0, 0, pTape.Width, pTape.Height);
			int pos = (sbxTape.Value - (int)Math.Floor((double)bounds.Width / 2));            
			int x,startX;
			startX = (20 + pos + 1) % 40;
			x = position * 40 - startX;*/

			//if (position * 40 < sbxTape.Minimum)
			//	sbxTape.Minimum = position * 40;

			sbxTape.Value = Math.Max(sbxTape.Minimum, Math.Min(sbxTape.Maximum, position * 40));
			pTape.Refresh();

		}        

		public void UpdateScrollbars()
		{
			if (this.InvokeRequired)
			{
				this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { UpdateScrollbars(); })));
			}
			else
			{
				SetScrollbars();
			}
		}

		public int EditedTape
		{
			get { return editedTape; }
			set { editedTape = value; }
		}

		public int EditedCell
		{
			get { return editedCell; }
			set { editedCell = value; }
		}
	}
}
