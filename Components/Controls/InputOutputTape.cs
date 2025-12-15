using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;

namespace DusanRodina.SimStudio.Components {
	[Serializable]
	public partial class InputOutputTape : UserControl
	{
		ResourceManager resMan = new ResourceManager(typeof(InputOutputTape).FullName,
			System.Reflection.Assembly.GetExecutingAssembly());

		public InputOutputTape()
		{
			InitializeComponent();            
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		List<string> vTape = new List<string>();
		int vCellWidth = 80;
		bool vAddRecordButton = true;
		bool vRewritable = true;        

		//Zobrazené položky a ich pozícia na obrazovke
		int FirstItem;
		Rectangle[] ShowedItems;
		int HoverCell = -1;
		int SelectedCell = -1;

		public event EventHandler RecordAdded;
		public event EventHandler RecordChanged;


		//Pridá záznam
		public void AddRecord(string Text)
		{
			vTape.Add(Text);
			SetScrollbars();            
			this.Refresh();

			if (RecordAdded!=null)
				Parent.Invoke(RecordAdded,new object[] {this, new EventArgs()});
		}

		//Zmaže záznam na danej pozícii
		public void RemoveRecordAt(int Index)
		{
			vTape.RemoveAt(Index);
			SetScrollbars();
			this.Refresh();
		}

		//Zmaže pásky
		public void Clear()
		{
			vTape.Clear();
			SetScrollbars();
			this.Refresh();
			txtText.Visible = false;
		}

		//Záznam pásky
		public string this[int index]
		{            
			get { return vTape[index]; }
			set
			{
				if (index >= 0 && index < vTape.Count)
				{
					vTape[index] = value;
					this.Refresh();
				}
			}
		}

		//Všetky záznamy pásky
		public string[] Records
		{            
			get { return vTape.ToArray(); }
			set
			{
				if ((value != null) && value.Length > 0 && !(value[0] == null & value.Length == 1))
				{
					vTape.Clear();
					vTape.AddRange(value);
					this.Refresh();
				}
			}
		}

		//Počet záznamov
		public int RecordCount
		{            
			get { return vTape.Count; }
		}
		
		//Tlačidlo na pridanie záznamu
		public bool AddRecordButton
		{            
			get { return vAddRecordButton; }
			set { vAddRecordButton = value; }
		}

		//Prepisateľné polia
		public bool Rewritable
		{            
			get { return vRewritable; }
			set { vRewritable = value; }
		}
		
		//Šírka bunky pásky
		public int CellWidth
		{            
			get { return vCellWidth; }
			set
			{
				vCellWidth = value;
				SetScrollbars();
				this.Refresh();
			}
		}
		
		//Výška bunky pásky
		public int CellHeight
		{            
			get
			{
				if (this.sbxTape.Visible)
				{
					return this.Height - this.sbxTape.Height - 8;
				}
				else
				{
					return this.Height - 8;
				}
			}
		}

		//Vykreslenie pásky
		private void TapeComponent_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			
			int start = (int)Math.Floor((double)sbxTape.Value / CellWidth);
			int end = (int)Math.Floor((double)(sbxTape.Value + this.Width) / CellWidth);
			int offx = sbxTape.Value % CellWidth;
			Rectangle rect;
			int x;
			int y;
			Font fnt = new Font("Arial", 11);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			sf.LineAlignment = StringAlignment.Center;
						 
			ShowedItems = new Rectangle[end - start+1];
			FirstItem = start;
			
			//Pozadie
			g.Clear(Color.White);
			
			//Bunky pásky
			y = 4;
			for (int a = start; a <= end; a++) {
				x = -offx + (a - start) * CellWidth + 2;
				rect = new Rectangle(x, y, CellWidth - 4, CellHeight);
				
				//Uloženie rozmeru
				ShowedItems[a - start] = rect;
				
				if (a < this.RecordCount) {
					//Bunka pásky
					if (SelectedCell == a) {
						Functions.FillRoundRectangle(g, new LinearGradientBrush(rect, Color.White, Color.LightBlue, LinearGradientMode.BackwardDiagonal), rect, 5);
					}
					else {
						Functions.FillRoundRectangle(g, new LinearGradientBrush(rect, Color.White, Color.LightGray, LinearGradientMode.BackwardDiagonal), rect, 5);
					}
					if (HoverCell == a) {
						Functions.DrawRoundRectangle(g, new Pen(Color.Black, 2), rect, 5);
					}
					else {
						Functions.DrawRoundRectangle(g, new Pen(Color.Gray, 1), rect, 5);
					}
					if (SelectedCell != a | !txtText.Visible) {
						g.DrawString(this[a], fnt, Brushes.Black, (RectangleF)(rect),sf);
					}
				}
				else if (a == this.RecordCount) {
					//Pridanie novej bunky
					if (this.AddRecordButton) {
						Functions.FillRoundRectangle(g, new LinearGradientBrush(rect, Color.White, Color.LightGreen, LinearGradientMode.BackwardDiagonal), rect, 5);
						if (HoverCell == a) {
							Functions.DrawRoundRectangle(g, new Pen(Color.Green, 2), rect, 5);
						}
						else {
							Functions.DrawRoundRectangle(g, new Pen(Color.Green, 1), rect, 5);
						}
						g.DrawString(resMan.GetString("AddItem") ,fnt, Brushes.Black, (RectangleF)(rect),sf);
					}
				}
			}
			
			g.DrawRectangle(Pens.Black, new Rectangle(0, 0, this.Width - 1, this.Height - 1));
		}

		//Nastaví posuvníky
		private void SetScrollbars()
		{
			int max = (vTape.Count + 1) * CellWidth - this.Width;
			if (max > 0)
			{
				sbxTape.Maximum = max + this.Width;
				sbxTape.SmallChange = CellWidth / 2;
				sbxTape.LargeChange = this.Width;
				sbxTape.Visible = true;
			}
			else
			{
				sbxTape.Maximum = 0;
				sbxTape.Visible = false;
			}
		}        

		private void FiniteTape_Resize(object sender, System.EventArgs e)
		{
			SetScrollbars();
			SetTextBoxPosition();
			this.Invalidate();
		}

		private void FiniteTape_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (HoverCell == this.RecordCount)
			{
				if (this.AddRecordButton)
				{
					AddRecord("");

					SelectedCell = this.RecordCount - 1;
					ShowTextBox();
				}
			}
			else if (HoverCell >= 0 && HoverCell < this.RecordCount)
			{
				SelectedCell = HoverCell;
				ShowTextBox();
			}
			else
			{
				SelectedCell = -1;
				txtText.Hide();
			}
		}

		private void ShowTextBox()
		{
			if (SelectedCell >= 0)
			{
				txtText.Text = this[SelectedCell];
				SetTextBoxPosition();
				txtText.Show();
				txtText.Focus();
				txtText.ReadOnly = !Rewritable;
			}
		}

		//Nastaví pozíciu textboxu
		private void SetTextBoxPosition()
		{
			if (ShowedItems == null) return;

			if (SelectedCell - FirstItem >= 0 & SelectedCell - FirstItem <= ShowedItems.Length - 1)
			{
				txtText.SetBounds(ShowedItems[SelectedCell - FirstItem].X + 3, ShowedItems[SelectedCell - FirstItem].Y + (ShowedItems[SelectedCell - FirstItem].Height - txtText.Height) / 2, ShowedItems[SelectedCell-FirstItem].Width - 6, txtText.Height);
			}
			else
			{
				txtText.SetBounds(this.Width +100, 0, 100, txtText.Height);
			}
		}

		private void FiniteTape_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if ((ShowedItems != null))
			{
				for (int a = 0; a <= ShowedItems.Length - 1; a++)
				{
					if (ShowedItems[a].Contains(e.X, e.Y))
					{
						HoverCell = a + FirstItem;
						this.Refresh();
						break; 
					}
				}
			}
		}

		private void FiniteTape_MouseLeave(object sender, System.EventArgs e)
		{
			HoverCell = -1;
		}

		private void FiniteTape_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Delta < 0)
			{
				try
				{
					sbxTape.Value += sbxTape.SmallChange;
				}
				catch { }
			}
			else
			{
				try
				{
					sbxTape.Value -= sbxTape.SmallChange;
				}
				catch { }
			}
			SetTextBoxPosition();
			this.Refresh();
		}

		private void txtText_TextChanged(object sender, System.EventArgs e)
		{
			if (SelectedCell != -1)
			{
				this[SelectedCell] = txtText.Text;
				if (RecordChanged != null) RecordChanged(this, new EventArgs());
			}
			else
			{
				txtText.Hide();
			}
		}

		private void txtText_LostFocus(object sender, System.EventArgs e)
		{
			txtText.Hide();
		}

		private void sbxTape_ValueChanged(object sender, EventArgs e)
		{
			SetTextBoxPosition();
			this.Refresh();            
		}

		private void sbxTape_Scroll(object sender, ScrollEventArgs e)
		{
			SetTextBoxPosition();
			this.Refresh();
		}

		public List<string> Tape
		{
			get { return vTape; }
		}

		public void UpdateScrollbars()
		{
			SetScrollbars();
		}
	}
}
