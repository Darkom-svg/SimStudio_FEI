using System;
using System.Windows.Forms;


namespace FEI.SimStudio {
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new MainForm());
        }
    }
}