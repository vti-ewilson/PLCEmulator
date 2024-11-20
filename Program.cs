using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PLCEmulator
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if(Environment.OSVersion.Version.Major >= 6)
				SetProcessDPIAware();

			Thread CommunicationThread = new Thread(new ThreadStart(Communication.ExecuteServer));
			CommunicationThread.Start();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new PLCForm());
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool SetProcessDPIAware();
	}
}
