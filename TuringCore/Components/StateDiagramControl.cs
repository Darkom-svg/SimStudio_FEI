using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using FEI.TuringCore.Components.Dialogs;
using FEI.TuringCore.Simulation;

namespace FEI.TuringCore.Components {
	public partial class StateDiagramControl : UserControl
    {
        private VirtualTuringMachine turingMachine;
        public VirtualTuringMachine TuringMachine
        {
            get { return turingMachine; }
            set { turingMachine = value; }
        }

        //Kontextové ponuky
        ContextMenu contextMenuState;

        //Editor stavov
        Point se_StartCursorPos = new Point(0, 0);
        Point se_StartStatePos = new Point(0, 0);

        //Posledná pozícia myši
        Point lastHoverPos; 

        public delegate void TransitionEventHandler(object sender, TransitionEventArgs e);
        public event TransitionEventHandler TransitionAdded;
        protected void OnTransitionAdded(TransitionEventArgs e)
        {
            if (TransitionAdded != null)
                TransitionAdded(this, e);
        }

        public delegate void DiagramChangedEventHandler(object sender, EventArgs e);
        public event DiagramChangedEventHandler DiagramChanged;
        protected void OnDiagramChanged(EventArgs e)
        {
            if (DiagramChanged != null)
                DiagramChanged(this, e);
        }

        public StateDiagramControl()
        {
            InitializeComponent();
            CreateContextMenus();            
        }

        //Nastaví posuvníky
        private void SetScrollbars()
        {
            if (turingMachine == null) return;
            if (turingMachine.StateDiagram.Bounds().Width - pStates.Width <= 0)
            {
                sbxStates.Visible = false;
                sbxStates.Maximum = 0;
                sbxStates.Value = 0;
            }
            else
            {
                sbxStates.Maximum = turingMachine.StateDiagram.Bounds().Width;
                sbxStates.LargeChange = pStates.Width;
                sbxStates.Value = Math.Min(sbxStates.Value, turingMachine.StateDiagram.Bounds().Width - pStates.Width);
                sbxStates.Visible = true;
            }

            if (turingMachine.StateDiagram.Bounds().Height - pStates.Height <= 0)
            {
                sbyStates.Visible = false;
                sbyStates.Maximum = 0;
                sbyStates.Value = 0;
            }
            else
            {
                sbyStates.Maximum = turingMachine.StateDiagram.Bounds().Height;
                sbyStates.LargeChange = pStates.Height;
                sbyStates.Value = Math.Min(sbyStates.Value, turingMachine.StateDiagram.Bounds().Height - pStates.Height);
                sbyStates.Visible = true;
            }

            if (sbxStates.Visible && !sbyStates.Visible)
            {
                sbxStates.Top = pStates.Top + pStates.Height - sbxStates.Height - 1;
                sbxStates.Width = pStates.Width;
            }
            else if (!sbxStates.Visible && sbyStates.Visible)
            {
                sbyStates.Left = pStates.Left + pStates.Width - sbyStates.Width - 1;
                sbyStates.Height = pStates.Height;
            }
            else
            {
                sbxStates.Top = pStates.Top + pStates.Height - sbxStates.Height - 1;
                sbxStates.Width = pStates.Width - sbyStates.Width;
                sbyStates.Left = pStates.Left + pStates.Width - sbyStates.Width - 1;
                sbyStates.Height = pStates.Height - sbxStates.Height;
            }

        }

        private void pStates_Resize(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        private void sbyStates_Scroll(object sender, ScrollEventArgs e)
        {
            pStates.Invalidate();
        }

        private void sbyStates_ValueChanged(object sender, EventArgs e)
        {
            pStates.Invalidate();
        }

        private void sbxStates_ValueChanged(object sender, EventArgs e)
        {
            pStates.Invalidate();
        }

        private void sbxStates_Scroll(object sender, ScrollEventArgs e)
        {
            pStates.Invalidate();
        }

        private void pStates_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (turingMachine.StateDiagram.selectedState >= 0) //Ak je označený stav
                {
                    if (turingMachine.StateDiagram.insTransition != null)
                    {
                        if (turingMachine.StateDiagram.insTransition.ToState != null) //Vloženie nového prechodu
                        {
                            Transition tf = new Transition();
                            tf.CurrentState = turingMachine.StateDiagram.insTransition.FromState.Name;
                            tf.NewState = turingMachine.StateDiagram.insTransition.ToState.Name;
                            OnTransitionAdded(new TransitionEventArgs(tf));                            
                            //TODO:
                            //UpdateStateDiagram();
                        }

                        turingMachine.StateDiagram.insTransition = null;
                        pStates.Refresh();
                    }
                    else
                    {
                        //int dist = (int)Math.Abs(Math.Sqrt(Math.Pow(TM.stateDiagram.insTransition.toPosition.X - TM.stateDiagram.insTransition.fromState.Position.X, 2)
                        //    + Math.Pow(TM.stateDiagram.insTransition.toPosition.Y - TM.stateDiagram.insTransition.fromState.Position.Y, 2)));
                        //if (dist < 6)
                        //Úprava stavu

                        pStates.ContextMenu = contextMenuState;
                        pStates.ContextMenu.Show(pStates, new Point(e.X, e.Y), LeftRightAlignment.Right);
                    }
                }
            }

            SetScrollbars();
        }

        private void pStates_DoubleClick(object sender, EventArgs e)
        {
            AddNewState(lastHoverPos);
        }

        private void pStates_MouseDown(object sender, MouseEventArgs e)
        {
            turingMachine.StateDiagram.selectedState = turingMachine.StateDiagram.hoverState;
            if (turingMachine.StateDiagram.selectedState != -1)
            {
                se_StartCursorPos = new Point(e.X + sbxStates.Value, e.Y + sbyStates.Value);
                se_StartStatePos = turingMachine.StateDiagram.states[turingMachine.StateDiagram.selectedState].Position;
            }
        }

        private void pStates_MouseMove(object sender, MouseEventArgs e)
        {
            lastHoverPos = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                if (turingMachine.StateDiagram.selectedState >= 0) //Ak je označený stav
                {
                    turingMachine.StateDiagram.states[turingMachine.StateDiagram.selectedState]
                        .Position = new Point(e.X + sbxStates.Value,
                                              e.Y + sbyStates.Value);
                    pStates.Refresh();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (turingMachine.StateDiagram.selectedState >= 0) //Ak je označený stav
                {
                    if (turingMachine.StateDiagram.insTransition == null) turingMachine.StateDiagram.insTransition = new Diagramming.InsertingTransition();
                    turingMachine.StateDiagram.insTransition.FromState = turingMachine.StateDiagram.states[turingMachine.StateDiagram.selectedState];
                    turingMachine.StateDiagram.insTransition.ToPosition = new Point(e.X + sbxStates.Value,
                                                                         e.Y + sbyStates.Value);

                    turingMachine.StateDiagram.hoverState = turingMachine.StateDiagram.GetStateIndexAt(new Point(e.X + sbxStates.Value, e.Y + sbyStates.Value));
                    if (turingMachine.StateDiagram.hoverState == -1)
                        turingMachine.StateDiagram.insTransition.ToState = null;
                    else
                        turingMachine.StateDiagram.insTransition.ToState = turingMachine.StateDiagram.states[turingMachine.StateDiagram.hoverState];

                    pStates.Refresh();
                }
            }
            else if (e.Button == MouseButtons.None)
            {
                turingMachine.StateDiagram.hoverState = turingMachine.StateDiagram.GetStateIndexAt(new Point(e.X + sbxStates.Value, e.Y + sbyStates.Value));
                pStates.Refresh();
            }
        }

        private void pStates_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (TuringMachine != null)
            {                
                g.SmoothingMode = SmoothingMode.AntiAlias;

                turingMachine.StateDiagram.Draw(g, new Rectangle(0, 0, pStates.Width, pStates.Height),
                    new Point(sbxStates.Value, sbyStates.Value));
            }
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, pStates.Width - 1, pStates.Height - 1));
        }

        private void CreateContextMenus()
        {
            CreateContextMenu_State();
        }

        private void CreateContextMenu_State()
        {
            contextMenuState = new ContextMenu();

            MenuItem newMI;

            newMI = new MenuItem("Upraviť", new EventHandler(ContextMenuState_Clicked));
            newMI.Tag = "edit";
            contextMenuState.MenuItems.Add(newMI);

            newMI = new MenuItem("Zmazať", new EventHandler(ContextMenuState_Clicked));
            newMI.Tag = "remove";
            contextMenuState.MenuItems.Add(newMI);
        }

        private void ContextMenuState_Clicked(object sender, EventArgs e)
        {
            MenuItem miClicked = (MenuItem)sender;
            string item = (string)miClicked.Tag;

            switch (item)
            {
                case "edit":

                    break;
                case "remove":
                    if (turingMachine.StateDiagram.selectedState >= 0 && turingMachine.StateDiagram.selectedState <= turingMachine.StateDiagram.states.Count - 1)
                    {
                        turingMachine.StateDiagram.states.RemoveAt(turingMachine.StateDiagram.selectedState);

                        OnDiagramChanged(new EventArgs());
                        pStates.Refresh();
                    }
                    break;
            }
        }

        //Pridá nový stav do diagramu
        public void AddNewState(Point statePosition)
        {
            NewStateForm dlg = new NewStateForm();
            dlg.ShowDialog(this);

            if (dlg.state != null)
            {
                dlg.state.Position = statePosition;
                turingMachine.StateDiagram.AddState(dlg.state, statePosition.IsEmpty);
                pStates.Refresh();

                OnDiagramChanged(new EventArgs());
            }
        }
    }
}
