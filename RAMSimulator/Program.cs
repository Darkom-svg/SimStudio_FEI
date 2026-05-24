using System;
using System.Windows.Forms;

namespace FEI.RandomAccessMachine {
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            RamSimulatorForm frm = new RamSimulatorForm();
            frm.Show();

            Application.Run();
        }
    }
}