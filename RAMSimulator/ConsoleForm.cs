using System;
using System.Windows.Forms;
using FEI.RandomAccessMachine.Simulation;

namespace FEI.RandomAccessMachine {
	public partial class ConsoleForm : Form
    {
        public Simulator simulator = null;

        public ConsoleForm()
        {
            InitializeComponent();
        }

        public void RefreshConsole()
        {
            int start = consoleText.SelectionStart;
            int length = consoleText.SelectionLength;
            
            consoleText.Text = simulator.ConsoleContent;

            consoleText.SelectionStart = start;
            consoleText.SelectionLength = length;
        }

        private void ConsoleForm_Load(object sender, EventArgs e)
        {
            RefreshConsole();
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputText_KeyDown(object sender, KeyEventArgs e)
        {
            if (simulator.PrgStop)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    simulator.InputTape.Add(inputText.Text);
                    simulator.InputNotTyped = false;
                    simulator.Run();
                    inputText.Text = "";                    
                }
            }
        }

        private void consoleText_TextChanged(object sender, EventArgs e)
        {

        }

        private void consoleText_Enter(object sender, EventArgs e)
        {
            inputText.Focus();
        }

    }
}
