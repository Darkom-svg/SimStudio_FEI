using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using FEI.RandomAccessMachine.Simulation;

namespace FEI.RandomAccessMachine {
	public partial class ScreenForm : Form
	{
		public Simulator simulator = null;
		private Bitmap screen = null;

		ResourceManager resMan = new ResourceManager(typeof(ScreenForm).FullName,
			System.Reflection.Assembly.GetExecutingAssembly());

		private Color[] stdColors = new Color[] {Color.Black,Color.White,Color.LightGray,
			Color.Gray, Color.DarkGray,Color.Green,Color.Blue,Color.Yellow,Color.Orange,
			Color.Cyan,Color.Magenta};

		public ScreenForm()
		{
			InitializeComponent();
		}        

		public void RefreshScreen()
		{
			long maxIndex=simulator.Screen.startIndex + simulator.Screen.width * simulator.Screen.height;
			string txt = resMan.GetString("GraphicalScreen") + " - ";
			txt += simulator.Screen.width.ToString() + "x" + simulator.Screen.height.ToString();
			txt += " (" + simulator.Screen.startIndex.ToString()
				+ "-" + maxIndex.ToString() + ")";
			this.Text = txt;

			if (simulator.Screen.width <= 0 || simulator.Screen.height <= 0) return;

			if (screen == null)
			{
				screen = new Bitmap(simulator.Screen.width, simulator.Screen.height);
			}
			else
			{
				if (screen.Width != simulator.Screen.width || screen.Height != simulator.Screen.height)
				{
					screen.Dispose();
					screen = null;
					screen = new Bitmap(simulator.Screen.width, simulator.Screen.height);
				}
			}

			int x = 0, y = 0;
			for (long i=simulator.Screen.startIndex;i<maxIndex;i++)
			{                
				//Vykreslí bod na obrazovku
				if (simulator.smallRegsUsed)
					screen.SetPixel(x, y, stdColors[(int)simulator.smallRegs[i].Value]);                
				else
					screen.SetPixel(x, y, stdColors[simulator.regs[i].Value.ToInt()]);                

				x++;
				if (x >= simulator.Screen.width)
				{
					x = 0;
					y++;
				}
			}

			pScreen.Refresh();
		}

		private void frmScreen_Load(object sender, EventArgs e)
		{
			RefreshScreen();
		}

		private void pScreen_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (screen != null)
			{
				g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
				g.CompositingQuality= System.Drawing.Drawing2D.CompositingQuality.GammaCorrected;
				g.DrawImage(screen, new Rectangle(0, 0, pScreen.Width, pScreen.Height));
			}
		}

		private void pScreen_Resize(object sender, EventArgs e)
		{
			pScreen.Invalidate();
		}
		
	}
}