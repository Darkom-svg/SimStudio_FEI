using System;
using System.Windows.Forms;

namespace FEI.AbacusMachine {
	static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AbacusMachineForm frm = new AbacusMachineForm();
            frm.Show();

            Application.Run();
        }
    }
}