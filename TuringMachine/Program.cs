using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace FEI.TuringMachineSimulator {
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			CultureInfo culture_info = new CultureInfo("sk");
			Thread.CurrentThread.CurrentUICulture = culture_info;            

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			TuringMachineForm frm = new TuringMachineForm();
			frm.Show();
			
			Application.Run();
		}
				
	}
}