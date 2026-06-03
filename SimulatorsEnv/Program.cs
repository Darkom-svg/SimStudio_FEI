using System;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

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
            
            string language = Properties.Settings.Default.Language;

            if (language == "en")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("sk");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("sk");
            }
            
            Application.Run(new MainForm());
        }
    }
}