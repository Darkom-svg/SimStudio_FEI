using System;
using System.Globalization;
using System.Threading;
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
            CultureInfo cultureInfo = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = cultureInfo;            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            RamSimulatorForm frm = new RamSimulatorForm();
            frm.Show();

            Application.Run();
        }
    }
}