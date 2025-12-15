using System.Drawing;
using System.Drawing.Drawing2D;

namespace DusanRodina.SimStudio.Components {
	public static class Functions
	{
		public static Color OddLineColor = Color.FromArgb(20, Color.Black);

		public static GraphicsPath GetRoundRectPath(RectangleF rect, short RoundWidth)
		{
			System.Drawing.Drawing2D.GraphicsPath myPath = new System.Drawing.Drawing2D.GraphicsPath();
			myPath.AddArc(new RectangleF(rect.Right - RoundWidth, rect.Bottom - RoundWidth, RoundWidth, RoundWidth), 0, 90);
			myPath.AddLine(new PointF(rect.Right - RoundWidth, rect.Bottom), new PointF(rect.Left + RoundWidth, rect.Bottom));
			myPath.AddArc(new RectangleF(rect.Left, rect.Bottom - RoundWidth, RoundWidth, RoundWidth), 90, 90);
			myPath.AddLine(new PointF(rect.Left, rect.Bottom - RoundWidth), new PointF(rect.Left, rect.Top + RoundWidth));
			myPath.AddArc(new RectangleF(rect.Left, rect.Top, RoundWidth, RoundWidth), 180, 90);
			myPath.AddLine(new PointF(rect.Left + RoundWidth, rect.Top), new PointF(rect.Right - RoundWidth, rect.Top));
			myPath.AddArc(new RectangleF(rect.Right - RoundWidth, rect.Top, RoundWidth, RoundWidth), 270, 90);
			myPath.AddLine(new PointF(rect.Right, rect.Top + RoundWidth), new PointF(rect.Right, rect.Bottom - RoundWidth));
			myPath.CloseFigure();
			return myPath;
		}

		public static GraphicsPath GetRoundRectPath(ref Rectangle rect, ref short RoundWidth)
		{
			return GetRoundRectPath((RectangleF)rect, RoundWidth);
		}

		public static void DrawRoundRectangle(Graphics G, Pen pen, Rectangle rect, short RoundWidth)
		{
			DrawRoundRectangle(G, pen, (RectangleF)rect, RoundWidth);
		}

		public static void DrawRoundRectangle(Graphics G, Pen pen, RectangleF rect, short RoundWidth)
		{
			RoundWidth *= 2;

			G.DrawPath(pen, GetRoundRectPath(rect, RoundWidth));
		}

		public static void FillRoundRectangle(Graphics G, Brush brush, Rectangle rect, short RoundWidth)
		{
			FillRoundRectangle(G, brush, (RectangleF)rect, RoundWidth);
		}

		public static void FillRoundRectangle(Graphics G, Brush brush, RectangleF rect, short RoundWidth)
		{
			RoundWidth *= 2;

			G.FillPath(brush, GetRoundRectPath(rect, RoundWidth));
		}

		public static void FillGlossRoundRectangle(Graphics G, Brush brush, RectangleF rect, short RoundWidth)
		{
			RoundWidth *= 2;
			System.Drawing.Drawing2D.GraphicsPath path = GetRoundRectPath(rect, RoundWidth);
			Region rgn = G.Clip;

			G.FillPath(brush, path);
			G.SetClip(path, System.Drawing.Drawing2D.CombineMode.Intersect);

			Rectangle glossRect = new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)(rect.Height / 2));
			G.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(
				glossRect, Color.FromArgb(120, Color.White), Color.FromArgb(40, Color.White), 
				System.Drawing.Drawing2D.LinearGradientMode.Vertical), glossRect);

			G.Clip = rgn;
		}

		//Zistí, či je string prázdny, čiže či je null alebo ""
		public static bool IsEmpty(string str)
		{
			if (str == null || str.Trim() == "")
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//Odstráni medzeri a čisté riadky zo začiatku a konca reťazca
		public static string TrimEnters(string Text)
		{         
			do
			{
				if (Text.Length == 0) break;

				if (Text.Substring(0, 1) == " ")
				{
					Text = Text.Substring(1);
				}
				else if (Text.Length>=2 && Text.Substring(0, 2) == "\r\n")
				{
					Text =Text.Substring(2);
				}
				else
				{
					break; 
				}
			}
			while (true);
			do
			{
				if (Text.Length == 0) break;

				if (Text.Substring(Text.Length-1, 1) == " ")
				{
					Text = Text.Substring(0, Text.Length - 1);
				}
				else if (Text.Length>=2 && Text.Substring(Text.Length-2, 2) == "\r\n")
				{
					Text = Text.Substring(0, Text.Length - 2);
				}
				else
				{
					break; 
				}
			}
			while (true);

			return Text.Trim();
		}

		//Zistí, či je reťazec číslo
		public static bool IsNumber(string text)
		{
			int val = 0;
			if (int.TryParse(text, out val)) return true; else return false;
		}

		//Skonvertuje text na číslo
		public static int ToValue(string Text)
		{
			int val = 0;
			int.TryParse(Text, out val);
			return val;
		}
	}
}
