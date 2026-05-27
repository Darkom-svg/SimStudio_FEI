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

            if (string.IsNullOrWhiteSpace(language))
                    language = "sk";

            Thread.CurrentThread.CurrentUICulture =
                new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture =
                new CultureInfo(language);
            
            Application.Run(new MainForm());
        }
    }
}