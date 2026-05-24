using System;
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

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			TuringMachineForm frm = new TuringMachineForm();
			frm.Show();
			
			Application.Run();
		}
				
	}
}