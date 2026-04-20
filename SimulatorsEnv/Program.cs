using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace FEI.SimStudio {
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            CultureInfo culture_info = new CultureInfo("sk");
            Thread.CurrentThread.CurrentUICulture = culture_info;            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);           
            Application.Run(new MainForm());
        }
    }
}