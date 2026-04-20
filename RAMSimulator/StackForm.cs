using System;
using System.Windows.Forms;
using FEI.RandomAccessMachine.Simulation;

namespace FEI.RandomAccessMachine {
	public partial class StackForm : Form
    {
        public Simulator simulator = null;

        public StackForm()
        {
            InitializeComponent();
        }

        public void RefreshStack()
        {
            stackList.Items.Clear();
            stackList.Items.AddRange(simulator.stack.ToArray());
        }

        private void StackForm_Load(object sender, EventArgs e)
        {
            RefreshStack();
        }

    }
}
