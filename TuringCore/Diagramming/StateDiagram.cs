using DusanRodina.TuringCore.Simulation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DusanRodina.TuringCore.Diagramming {
	public class StateDiagram
    {                     
        //Ohraničenie diagramu
        public Rectangle DefaultBounds = new Rectangle(0, 0, 800, 600);        

        //Zoznam stavov
        public List<State> states = new List<State>();

        public int hoverState = -1;
        public int selectedState = -1;        

        //Aktívny stav počas simulácie
        public string activeState = "";
        //Aktívny prechod počas simulácie
        public Simulation.Transition activeTransition = null;        

        //Aktuálna pozícia, na ktorú sa vloží ďalší stav
        public Point StartInsertPos = new Point(40, 40);
        public Point CurInsertPos = new Point(40, 40);

        //Aktuálne vkladaný prechod
        public InsertingTransition insTransition = null;

        private DiagramStyle style = DiagramStyle.TuringMachine;
        public DiagramStyle Style
        {
            get { return style; }
            set { style = value; }
        }


        //Ohraničenie použitých stavov diagramu
        public Rectangle Bounds()
        {            
            int maxX,maxY;            
            maxX=0;maxY=0;

            for (int a = 0; a<states.Count; a++)
            {
                if (states[a].Position.X > maxX)
                {
                    maxX = states[a].Position.X;
                }
                if (states[a].Position.Y > maxY)
                {
                    maxY = states[a].Position.Y;
                }
            }
            return new Rectangle(0, 0, maxX + 60, maxY + 60);
        }

        //Vykreslí stavový diagram
        public void Draw(Graphics g, Rectangle rectangle, Point offset)
        {
            for (int i = 0; i < states.Count; i++)
            {                
                states[i].DrawTransitions(g, offset, hoverState == i, activeTransition);
            }

            DrawInsertingTransition(g, insTransition, offset); 

            for (int i = 0; i < states.Count; i++)
            {
                states[i].DrawState(g, offset, hoverState == i, activeState == states[i].Name);
            }
        }

        //Vykreslí práve vkladaný prechod
        public void DrawInsertingTransition(Graphics g, InsertingTransition trans, Point offset)
        {
            if (trans == null) return;

            Font fnt = new Font("Arial", 12, FontStyle.Regular);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            Pen penTo = new Pen(Color.FromArgb(180,Color.DarkBlue), 2);
            penTo.DashStyle = DashStyle.Dash;
            Pen penToArrow = new Pen(Color.FromArgb(180, Color.DarkBlue), 2);            
            Pen penToB = new Pen(Color.FromArgb(45, Color.Blue), 8);            

            int xc, yc;
            int x, y;
            int x1, y1, x_offset, y_offset;
            double angle, d, a1, a2;
            

            //Začiatočná pozícia odsadená podľa aktuálneho nastavenia posuvníkov (offset)
            xc = trans.FromState.Position.X - offset.X;
            yc = trans.FromState.Position.Y - offset.Y;            

            //Koncová pozícia odsadená podľa aktuálneho nastavenia posuvníkov (offset)
            if (trans.ToState == null)
            {
                x1 = trans.ToPosition.X - offset.X;
                y1 = trans.ToPosition.Y - offset.Y;
            }
            else
            {
                x1 = trans.ToState.Position.X - offset.X;
                y1 = trans.ToState.Position.Y - offset.Y;
            }
            angle = Math.Atan2((x1 - xc), (y1 - yc)); //uhol čiary prechodu

            if (trans.ToState == null)
                d = (Math.Sqrt(Math.Pow(x1 - xc, 2) + Math.Pow(y1 - yc, 2)));
            else
                d = (Math.Sqrt(Math.Pow(x1 - xc, 2) + Math.Pow(y1 - yc, 2))-25);

            x1 = (int)(Math.Sin(angle) * d) + xc;
            y1 = (int)(Math.Cos(angle) * d) + yc;

            x_offset = (int)(Math.Sin(angle) * 25);
            y_offset = (int)(Math.Cos(angle) * 25);
            x = xc + x_offset; y = yc + y_offset;

            //Čiara
            g.DrawLine(penToB, x1, y1, x, y);
            g.DrawLine(penTo, x1, y1, x, y);
            
            //Šípka
            a1 = Math.PI / 2 * 3 - (angle + Math.PI / 11);
            a2 = Math.PI / 2 * 3 - (angle - Math.PI / 11);
            y_offset = (int)(Math.Sin(a1) * 15);
            x_offset = (int)(Math.Cos(a1) * 15);
            g.DrawLine(penToArrow, x1, y1, x1 + x_offset, y1 + y_offset);            

            y_offset = (int)(Math.Sin(a2) * 15);
            x_offset = (int)(Math.Cos(a2) * 15);
            g.DrawLine(penToArrow, x1, y1, x1 + x_offset, y1 + y_offset);            

            penTo.Dispose(); penToArrow.Dispose(); penToB.Dispose();
        }

        //Vráti index stavu na súradniciach
        public int GetStateIndexAt(Point pt)
        {
            for (int a = 0; a < states.Count; a++)
            {
                if (Math.Sqrt(Math.Pow(states[a].Position.X - pt.X, 2) + Math.Pow(states[a].Position.Y - pt.Y, 2)) <= 25)
                {
                    return a;
                }
            }
            return -1;
        }

        //Pridá stav
        public void AddState(State state, bool autoPosition)
        {
            if (autoPosition) state.Position = CurInsertPos;

            states.Add(state);
            
            if (autoPosition)
            {
                //Nastavenie nových vkladacích súradnic
                CurInsertPos.X += 150;
                if (CurInsertPos.X + 30 > DefaultBounds.Right)
                {
                    CurInsertPos.X = 40;
                    CurInsertPos.Y += 150;
                }
            }
        }

        //Pridá stav iba ak neexistuje stav s rovnakým menom
        public void AddStateIfNotExists(State state)
        {
            for (int i = 0; i < states.Count; i++)
            {
                //Stav existuje - aktualizujeme jeho hodnoty
                if (states[i].Name == state.Name) 
                {
                    states[i].Description = state.Description;
                    states[i].Type = state.Type;
                    return;
                }
            }
            
            //Pridanie nového stavu
            AddState(state,true);
        }

        //Vráti stav s daným menom
        public State GetState(string name)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].Name == name)
                {
                    return states[i];
                }
            }
            return null;
        }

        //Vytvorí stavový diagram pre daný turingov stroj
        public void CreateForTM(VirtualTuringMachine tm)
        {                     
            //Vynuluje
            this.CurInsertPos = this.StartInsertPos;
            this.states.Clear();

            UpdateForTM(tm);

        }

        //Obnoví stavový diagram pre daný turingov stroj
        public void UpdateForTM(VirtualTuringMachine tm)
        {            
            State state;
            State toState;
            string[] usedStates = tm.GetUsedStates();

            //Obnoví vložené stavy
            for (int i = 0; i < this.states.Count; i++)
            {
                states[i].RemoveAllTransitions();

                if (tm.StartState == states[i].Name)
                {
                    if (tm.IsFinalState(states[i].Name))
                        states[i].Type = StateType.StartFinal;
                    else
                        states[i].Type = StateType.Start;
                }
                else if (tm.IsFinalState(states[i].Name))
                {
                    states[i].Type = StateType.Final;
                }
                else
                {
                    states[i].Type = StateType.Normal;
                }                
            }

            //Vytvorí všetky stavy
            for (int i = 0; i < usedStates.Length; i++)
            {                
                if (tm.StartState == usedStates[i])
                {
                    if (tm.IsFinalState(usedStates[i]))
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.StartFinal));
                    else
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.Start));
                }
                else if (tm.IsFinalState(usedStates[i]))
                {
                    this.AddStateIfNotExists(new State(usedStates[i], StateType.Final));
                }
                else
                {
                    this.AddStateIfNotExists(new State(usedStates[i]));
                }                
            }

            //Vytvorí prechody medzi stavmi
            for (int t = 0; t < tm.TFunctionCount; t++)
            {
                //Prechod ZO stavu
                state = this.GetState(tm.TFunction(t).CurrentState);
                //Prechod DO stavu
                toState = this.GetState(tm.TFunction(t).NewState);                

                if (state != null && toState != null)
                {
                    state.AddTransitionTo(toState,
                        tm.TFunction(t).GetReadWriteStepString(),
                        tm.TFunction(t).Comment, false);
                    //state.to.Add(toState);
                }
            }
        }

        //Obnoví stavový diagram pre daný turingov stroj
        public void UpdateForPA(VirtualTuringMachine fa)
        {
            State state;
            State toState;
            string[] usedStates = fa.GetUsedStates();

            //Obnoví vložené stavy
            for (int i = 0; i < this.states.Count; i++)
            {
                states[i].RemoveAllTransitions();

                if (fa.StartState == states[i].Name)
                {
                    if (fa.IsFinalState(states[i].Name))
                        states[i].Type = StateType.StartFinal;
                    else
                        states[i].Type = StateType.Start;
                }
                else if (fa.IsFinalState(states[i].Name))
                {
                    states[i].Type = StateType.Final;
                }
                else
                {
                    states[i].Type = StateType.Normal;
                }
            }

            //Vytvorí všetky stavy
            for (int i = 0; i < usedStates.Length; i++)
            {
                if (fa.StartState == usedStates[i])
                {
                    if (fa.IsFinalState(usedStates[i]))
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.StartFinal));
                    else
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.Start));
                }
                else if (fa.IsFinalState(usedStates[i]))
                {
                    this.AddStateIfNotExists(new State(usedStates[i], StateType.Final));
                }
                else
                {
                    this.AddStateIfNotExists(new State(usedStates[i]));
                }
            }

            //Vytvorí prechody medzi stavmi
            for (int t = 0; t < fa.TFunctionCount; t++)
            {
                //Prechod ZO stavu
                state = this.GetState(fa.TFunction(t).CurrentState);
                //Prechod DO stavu
                toState = this.GetState(fa.TFunction(t).NewState);

                if (state != null && toState != null)
                {
                    state.AddTransitionTo(toState,
                        fa.TFunction(t).ReadSymbol + "," + fa.TFunction(t).StackRead + "," + fa.TFunction(t).StackWrite,
                        fa.TFunction(t).Comment, true);
                    //state.to.Add(toState);
                }
            }

        }

        //Obnoví stavový diagram pre daný turingov stroj
        public void UpdateForFA(VirtualTuringMachine fa)
        {
            State state;
            State toState;
            string[] usedStates = fa.GetUsedStates();

            //Obnoví vložené stavy
            for (int i = 0; i < this.states.Count; i++)
            {
                states[i].RemoveAllTransitions();

                if (fa.StartState == states[i].Name)
                {
                    if (fa.IsFinalState(states[i].Name))
                        states[i].Type = StateType.StartFinal;
                    else
                        states[i].Type = StateType.Start;
                }
                else if (fa.IsFinalState(states[i].Name))
                {
                    states[i].Type = StateType.Final;
                }
                else
                {
                    states[i].Type = StateType.Normal;
                }
            }

            //Vytvorí všetky stavy
            for (int i = 0; i < usedStates.Length; i++)
            {
                if (fa.StartState == usedStates[i])
                {
                    if (fa.IsFinalState(usedStates[i]))
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.StartFinal));
                    else
                        this.AddStateIfNotExists(new State(usedStates[i], StateType.Start));
                }
                else if (fa.IsFinalState(usedStates[i]))
                {
                    this.AddStateIfNotExists(new State(usedStates[i], StateType.Final));
                }
                else
                {
                    this.AddStateIfNotExists(new State(usedStates[i]));
                }
            }

            //Vytvorí prechody medzi stavmi
            for (int t = 0; t < fa.TFunctionCount; t++)
            {
                //Prechod ZO stavu
                state = this.GetState(fa.TFunction(t).CurrentState);
                //Prechod DO stavu
                toState = this.GetState(fa.TFunction(t).NewState);

                if (state != null && toState != null)
                {
                    state.AddTransitionTo(toState,
                        fa.TFunction(t).ReadSymbol,
                        fa.TFunction(t).Comment, true);
                    //state.to.Add(toState);
                }
            }
        }

    }    
}
