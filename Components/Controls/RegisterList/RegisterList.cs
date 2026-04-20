using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FEI.SimStudio.Components.Registers;

namespace FEI.SimStudio.Components.Controls.RegisterList {
	public partial class RegisterList : UserControl
    {        
        //Registre
        InfiniteRegisters regs = new InfiniteRegisters();

        private bool reading = false, writing = false;
        private int readingPos = 0, writingPos = 0;
        private int maximalCount = 10000;

        private int hoverReg = -1;
        private int selReg = -1;

        private RegisterBreakPointList breakPoints = new RegisterBreakPointList();

        public delegate void RegisterChangedEventHandler(object sender, RegisterEventArgs arg);

        public event EventHandler ViewPositionChange;
        public event RegisterChangedEventHandler RegisterChanged;

        public RegisterList()
        {
            InitializeComponent();
        }

        //Registre
        public InfiniteRegisters Regs
        {
            get { return regs; }
            set { regs = value; }
        } 

        //Určuje, či prebieha čítanie z registrov
        public bool Reading
        {
            get { return reading; }
            set { reading = value; }
        }

        //Určuje, či prebieha zapisovanie do registrov
        public bool Writing
        {
            get { return writing; }
            set { writing = value; }
        }

        //Pozícia čítania z registrov
        public int ReadingPos
        {
            get { return readingPos; }
            set { readingPos = value; }
        }

        //Pozícia zapisovania do registrov
        public int WritingPos
        {
            get { return writingPos; }
            set { writingPos = value; }
        }

        //Maximálny počet zobrazovaných registrov
        public int MaximalCount
        {
            get { return maximalCount; }
            set { maximalCount = value; }
        }

        //Pohľad na registre - pozícia posuvníka
        public int ScrollValue
        {
            get { return sbyList.Value; }
            set { sbyList.Value = value; }
        }

        //Vykreslí registre
        private void DrawRegs(Graphics G)
        {
            Font nameFont = new Font(this.Font, FontStyle.Bold);
            int i;

            G.SmoothingMode = SmoothingMode.AntiAlias;

            for (int a = 0; a <= (int)Math.Floor((double)this.Height / 20); a++)
            {
                i = a + sbyList.Value;
                if ((Regs != null) && i < MaximalCount)
                {
                    //Odlíšenie párnych nepárnych riadkov
                    if (i % 2 == 1)
                    {
                        G.FillRectangle(Brushes.LightGray, new Rectangle(0, a * 20, this.Width, 20));
                    }

                    //Hover
                    if (i == hoverReg)
                    {
                        G.FillRectangle(new SolidBrush(Color.FromArgb(100,Color.LightBlue)), new Rectangle(0, a * 20, this.Width, 19));
                        G.DrawRectangle(new Pen(Color.FromArgb(200,Color.LightBlue)), new Rectangle(0, a * 20, this.Width, 19));
                    }

                    //Breakpoint
                    if (breakPoints.HasBreakpoint(i))
                    {
                        GraphicsPath gp = new GraphicsPath();
                        gp.AddEllipse(new Rectangle(3, a * 20 + 3, 14, 14));
                        PathGradientBrush brush = new PathGradientBrush(gp);
                        brush.CenterColor = Color.LightPink;
                        brush.SurroundColors = new Color[] { Color.DarkRed };
                        brush.CenterPoint = new PointF(8, a*20+8);
                        
                        G.FillEllipse(brush, new Rectangle(3, a * 20 + 3, 14, 14));
                        //G.FillEllipse(Brushes.Red, new Rectangle(3, a * 20 + 3, 14, 14));
                        G.DrawEllipse(Pens.DarkRed, new Rectangle(3, a * 20 + 3, 14, 14));                        
                    }
                    
                    //Vizualizácia zapisovania
                    if (Writing && (int)WritingPos == i) 
                    {
                        DrawGRect(G, Color.Red, new Rectangle(0, a * 20, this.Width, 20));
                    }
                    //Vizualizácia čítania
                    if (Reading && (int)ReadingPos == i)
                    {
                        DrawGRect(G, Color.Green, new Rectangle(0, a * 20, this.Width, 20));
                    }

                    //Názov registra
                    G.SetClip(new Rectangle(0, a * 20, 100, 20));                    
                    if (Regs[i].Name == null)
                    {
                        G.DrawString(i.ToString(), nameFont, Brushes.Black, 20, a * 20);
                    }
                    else
                    {
                        G.DrawString(i.ToString() + " (" + Regs[i].Name + ")", nameFont, Brushes.Black, 20, a * 20);
                    }                    
                    G.SetClip(new Rectangle(0, 0, this.Width, this.Height));

                    //Hodnota registra
                    G.DrawString(Regs[i].Value.ToString(), this.Font, Brushes.Black, (float)100, (float)(a * 20));
                }
            }
            //Čiary
            G.DrawLine(Pens.Black, 100, 0, 100, this.Height);
            G.DrawLine(Pens.Black, 20, 0, 20, this.Height);
            G.DrawRectangle(Pens.Black, 0, 0, this.Width - 1, this.Height - 1);
        }

        //Vykreslí označenie
        public void DrawGRect(Graphics G, Color BColor, Rectangle Rect)
        {
            Pen pero = new Pen(Color.Black, 2);

            pero.Alignment = PenAlignment.Inset;
            G.FillRectangle(new LinearGradientBrush(Rect, BColor, Color.White, LinearGradientMode.Vertical), Rect);
            G.FillRectangle(new LinearGradientBrush(new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height / 2), Color.White, Color.FromArgb(100, Color.White), LinearGradientMode.Vertical), new Rectangle(Rect.X, Rect.Y, Rect.Width, Rect.Height / 2));
            G.DrawRectangle(pero, Rect);
            pero.Dispose();
        }

        private void RegisterList_Paint(object sender, PaintEventArgs e)
        {
            DrawRegs(e.Graphics);
        }

        private void sbyList_Scroll(object sender, ScrollEventArgs e)
        {            
            this.Refresh();
            if (ViewPositionChange != null) ViewPositionChange(this, new EventArgs());
        }

        private void sbyList_ValueChanged(object sender, EventArgs e)
        {
            this.Refresh();
            if (ViewPositionChange!=null) ViewPositionChange(this,new EventArgs());
        }

        private void RegisterList_Resize(object sender, EventArgs e)
        {
            SetScrollbars();
            this.Invalidate();
        }

        private void SetScrollbars()
        {
            sbyList.LargeChange = (int)Math.Floor((double)this.Height / 20);
            sbyList.Maximum = (int)MaximalCount;
        }

        private void RegisterList_MouseMove(object sender, MouseEventArgs e)
        {
            this.Invalidate(new Rectangle(0, (hoverReg - sbyList.Value) * 20, this.Width, 22));
            hoverReg = (int)Math.Floor((double)e.Y / 20) + sbyList.Value;
            this.Invalidate(new Rectangle(0, (hoverReg - sbyList.Value) * 20, this.Width, 22));
        }

        private void RegisterList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 20)
            {
                if (!breakPoints.HasBreakpoint(hoverReg))
                {
                    BreakPoint regBP = new BreakPoint();
                    regBP.AtReading = true;
                    regBP.AtWriting = true;
                    regBP.RegisterIndex = hoverReg;

                    breakPoints.BreakPoints.Add(regBP);
                }
                else
                {
                    breakPoints.RemoveBreakpointFor(hoverReg);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                RegisterEditForm dlg = new RegisterEditForm();
                dlg.regName = regs[hoverReg].Name;
                dlg.regValue = regs[hoverReg].Value.ToString();
                dlg.ShowDialog(this.ParentForm);
                if (dlg.DialogResult == DialogResult.OK)
                {
                    if (regs.regs.ContainsKey(new InfiniteInteger(hoverReg)))
                    {
                        regs[hoverReg].Name = dlg.regName;
                        regs[hoverReg].Value = new InfiniteInteger(dlg.regValue);
                    }
                    else
                    {
                        regs[hoverReg] = new RegisterCell(new InfiniteInteger(dlg.regValue),
                                                          dlg.regName);
                    }

                    this.Refresh();
                    if (RegisterChanged != null) RegisterChanged(this, new RegisterEventArgs(regs[hoverReg], hoverReg));
                }
            }
        }

        public class RegisterEventArgs
        {
            public RegisterCell register;
            public int index;

            public RegisterEventArgs(RegisterCell register, int index)
            {
                this.register = register;
                this.index = index;
            }
        }
    }
}
