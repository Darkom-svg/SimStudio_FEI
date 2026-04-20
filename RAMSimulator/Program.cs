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
        static void Main()
        {
            CultureInfo culture_info = new CultureInfo("en");
            Thread.CurrentThread.CurrentUICulture = culture_info;            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            RAMSimulatorForm frm = new RAMSimulatorForm();
            frm.Show();

            Application.Run();
        }
    }
}