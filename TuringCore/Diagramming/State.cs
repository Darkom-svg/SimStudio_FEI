using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DusanRodina.TuringCore.Diagramming {
	/*
     * Stav stavového diagramu
     */
	public class State
    {
        private Point position;

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private StateType type = StateType.Normal;
        public StateType Type
        {
            get { return type; }
            set { type = value; }
        }

        //Stavy, do ktorých sa dá dostať z tohto stavu
        private List<Transition> to = new List<Transition>();
        public List<Transition> To
        {
            get { return to; }
            set { to = value; }
        }

#region Constructors
        public State() { }
        public State(string name)
        {
            this.name = name;
        }
        public State(string name, StateType type)
        {
            this.name = name;
            this.type = type;
        }
        public State(string name, Point position)
        {
            this.name = name;
            this.position = position;
        }
        public State(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public State(string name, string description, StateType type)
        {
            this.name = name;
            this.description = description;
            this.type = type;
        }
#endregion

        public Point Position
        {
            get { return position; }
            set
            {
                if (value.X < 0) value.X = 0;
                if (value.Y < 0) value.Y = 0;
                position = value;
            }
        }

        //Vráť prechod do stavu
        public Transition GetTransitionTo(State state)
        {
            for (int i = 0; i < to.Count; i++)
            {
                if (to[i].State.name == state.name)
                {
                    return to[i];
                }
            }
            return null;
        }

        //Pridá prechod z tohto stavu do daného stavu
        public void AddTransitionTo(State state, string tfunction, string comment, bool groupFunctions)
        {
            Transition tr = GetTransitionTo(state);
            if (tr == null)
            {
                to.Add(new Transition(state, tfunction, comment));
            }
            else
            {
                if (groupFunctions)
                {
                    if (tr.Functions.Count == 0)
                        tr.Functions.Add(tfunction);
                    else
                        tr.Functions[0] += ", " + tfunction;
                }
                else
                {
                    if (!tr.Functions.Contains(tfunction))
                    {
                        tr.Functions.Add(tfunction);
                    }
                }
            }
        }

        //Vykreslí prechody
        public void DrawTransitions(Graphics g, Point offset, bool hover, Simulation.Transition activeTransition)
        {
            Font fnt = new Font("Arial", 10, FontStyle.Regular);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            Pen penTo = new Pen(Color.Black, 1);
            Pen penToActive = new Pen(Color.FromArgb(150, Color.DodgerBlue), 5) { LineJoin = LineJoin.Round };

            //Vykreslenie prechodov                
            int xc, yc;
            int x, y;
            float x_middle = 0, y_middle = 0;
            int x1, y1, x_offset, y_offset;
            double angle, d;
            xc = this.position.X - offset.X;
            yc = this.position.Y - offset.Y;

            int direction = 1;
            int textOffset = 0;

            int txtw = 0;
            bool isActive = false;
            GraphicsPath linePath = new GraphicsPath();

            for (int i = 0; i < to.Count; i++)
            {
                if (activeTransition != null && activeTransition.CurrentState == this.name && activeTransition.NewState == to[i].State.name)
                {
                    isActive = true;
                }
                else
                {
                    isActive = false;
                }

                //Rotovanie textu
                Matrix rotateMatrix = new Matrix();

                //Spojenie stavov
                linePath.Reset();
                if (this.to[i].State.Equals(this)) // Slučka
                {
                    angle = Math.PI;
                    x_offset = (int)(Math.Sin(angle - Math.PI / 6) * 25);
                    y_offset = (int)(Math.Cos(angle - Math.PI / 6) * 25);
                    x1 = xc + x_offset; y1 = yc + y_offset;

                    x_offset = (int)(Math.Sin(angle + Math.PI / 6) * 25);
                    y_offset = (int)(Math.Cos(angle + Math.PI / 6) * 25);
                    x = xc + x_offset; y = yc + y_offset;

                    int my;
                    my = y1 - 80;                    
                    linePath.AddBezier (new Point(x, y),
                        new Point(x - 50, my), new Point(x1 + 50, my), new Point(x1, y1));

                    x_middle =  x;
                    y_middle = my;
                    
                    AddArrow(linePath, x1, y1, Math.PI / 3 - Math.PI / 2);

                    // Nastavenia pre text
                    y = my; y1 = my;
                }
                else // Rôzne stavy
                {
                    //Vypočítanie súradníc
                    x1 = this.to[i].State.position.X - offset.X;
                    y1 = this.to[i].State.position.Y - offset.Y;
                    angle = Math.Atan2((x1 - xc), (y1 - yc));

                    d = (Math.Sqrt(Math.Pow(x1 - xc, 2) + Math.Pow(y1 - yc, 2)) - 25);
                    x1 = (int)(Math.Sin(angle) * d) + xc;
                    y1 = (int)(Math.Cos(angle) * d) + yc;

                    x_offset = (int)(Math.Sin(angle) * 25);
                    y_offset = (int)(Math.Cos(angle) * 25);
                    x = xc + x_offset; y = yc + y_offset;

                    // Stred
                    double a1 = angle + Math.PI / 2;
                    x_offset = (int)(Math.Sin(a1) * 40);
                    y_offset = (int)(Math.Cos(a1) * 40);
                    x_middle = x1 + (x - x1) / 2 + x_offset;
                    y_middle = y1 + (y - y1) / 2 + y_offset;

                    //linePath.AddLine( x1, y1, x, y);
                    linePath.StartFigure();
                    linePath.AddBezier(x1, y1, x_middle, y_middle, x_middle, y_middle, x, y);
                    linePath.StartFigure();

                    if (angle > 0)
                    {
                        rotateMatrix.RotateAt(90 - (float)(angle / Math.PI * 180), new PointF(x_middle, y_middle));
                        direction = 1; textOffset = 10;
                    }
                    else
                    {
                        rotateMatrix.RotateAt(-90 - (float)(angle / Math.PI * 180), new PointF(x_middle, y_middle));
                        direction = -1; textOffset = 10;
                    }
                    
                    angle = Math.Atan2((x1 - x_middle), (y1 - y_middle));
                    AddArrow(linePath, x1, y1, angle);
                }

                // Vykreslenie ciary
                if (isActive) g.DrawPath(penToActive, linePath);
                g.DrawPath(penTo, linePath);

                //g.Transform=rotateMatrix;

                //Rotovanie textu
                for (int t = 0; t < this.to[i].Functions.Count; t++)
                {
                    txtw = (int)g.MeasureString(this.to[i].Functions[t], fnt).Width;
                    //g.DrawString(this.to[i].functions[t], fnt, Brushes.Blue, new Point(x1 + (x - x1) / 2 - txtw / 2, y1 + (y - y1) / 2 + t * 20));

                    GraphicsPath textPath = new GraphicsPath();
                    textPath.AddString(this.to[i].Functions[t], fnt.FontFamily,
                        (int)fnt.Style, fnt.Size / 72f * g.DpiY,
                        new Point((int)(x_middle - txtw / 2), (int)(y_middle - textOffset - t * 17 * direction)), new StringFormat());
                    textPath.Transform(rotateMatrix);

                    // Aktivny prechod
                    if (isActive && activeTransition.GetReadWriteStepString() == to[i].Functions[t])
                    {
                        g.DrawPath(penToActive, textPath);
                        g.FillPath(Brushes.Black, textPath);                        
                    }
                    else
                    {
                        g.FillPath(Brushes.Black, textPath);
                    }
                }
                //g.ResetTransform();

            }
        }

        private void DrawArrow(Graphics g, Pen penTo, int x1, int y1, double angle)
        {
            int x_offset, y_offset;
            double a1, a2;
            //Šípka
            a1 = Math.PI / 2 * 3 - (angle + Math.PI / 11);
            a2 = Math.PI / 2 * 3 - (angle - Math.PI / 11);
            y_offset = (int)(Math.Sin(a1) * 10);
            x_offset = (int)(Math.Cos(a1) * 10);
            g.DrawLine(penTo, x1, y1, x1 + x_offset, y1 + y_offset);
            y_offset = (int)(Math.Sin(a2) * 10);
            x_offset = (int)(Math.Cos(a2) * 10);
            g.DrawLine(penTo, x1, y1, x1 + x_offset, y1 + y_offset);
        }

        private void AddArrow(GraphicsPath gp, int x1, int y1, double angle)
        {
            int x_offset, y_offset;
            double a1, a2;
            //Šípka
            a1 = Math.PI / 2 * 3 - (angle + Math.PI / 11);
            a2 = Math.PI / 2 * 3 - (angle - Math.PI / 11);            
            y_offset = (int)(Math.Sin(a1) * 10);
            x_offset = (int)(Math.Cos(a1) * 10);
            gp.AddLine(x1, y1, x1 + x_offset, y1 + y_offset);
            y_offset = (int)(Math.Sin(a2) * 10);
            x_offset = (int)(Math.Cos(a2) * 10);
            gp.AddLine(x1, y1, x1 + x_offset, y1 + y_offset);
        }


        //Vykreslí stav 
        public void DrawState(Graphics g, Point offset, bool hover, bool active)
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle rect;
            Rectangle rect2 ;
            
            //Vykreslenie stavu
            if (this.type == StateType.Start || this.type == StateType.StartFinal)
            {
                rect = new Rectangle(position.X - 25 - offset.X, position.Y - 25 - offset.Y, 75, 50);
                rect2 = new Rectangle(position.X - 25 - offset.X, position.Y - 25 - offset.Y, 50, 50);
                rect2.Offset(24, 0); 
            }
            else
            {
                rect = new Rectangle(position.X - 25 - offset.X, position.Y - 25 - offset.Y, 50, 50);
                rect2 = rect;
                
            }
            
            Font fnt = new Font("Arial", 14);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Pen statePen = Pens.Black;
            SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(80, Color.Black));

            //Aktívny stav
            if (active)
            {
                //Zvýraznenie
                 
                rect2.Inflate(30, 30);
                g.DrawImage(global::TuringCore.Properties.Resources.CurrentState, rect2);

                //LinearGradientBrush stateBrush = null;
                //g.FillEllipse(new SolidBrush(Color.FromArgb(100,Color.Blue)), rect2);
                //rect2 = rect; rect2.Inflate(5, 5);
                //g.DrawEllipse(new Pen(Color.FromArgb(100,Color.Blue),2), rect2); 
            }

            switch (this.type)
            {
                case StateType.Normal:
                    g.DrawImage(global::TuringCore.Properties.Resources.NormalState, rect);
                    break;
                case StateType.Start:
                    g.DrawImage(global::TuringCore.Properties.Resources.InitialState, rect);
                    break;
                case StateType.Final:
                    g.DrawImage(global::TuringCore.Properties.Resources.FinalState, rect);
                    break;
                case StateType.StartFinal:
                    g.DrawImage(global::TuringCore.Properties.Resources.InitialFinalState, rect);
                    break;
            }
            
            g.DrawString(name, fnt, Brushes.Black, rect2, sf);

            //Hover
            if (hover)
            {
                g.DrawEllipse(new Pen(Color.FromArgb(70, Color.Black), 5), rect2);
            }



        }

        public void RemoveAllTransitions()
        {
            to.Clear();
        }        

    }

}
