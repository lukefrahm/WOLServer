using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WOLServer
{
	public class WorkerThread
	{
		[STAThread]
		public static void PeriodicWake()
		{
			ThreadStart tc = new ThreadStart(RunWorker);
			Thread t = new Thread(tc);
			t.IsBackground = true;
			while (true)
			{
				Thread.Sleep(1000);
				t.Start();
			}
		}



		private static void RunWorker()
		{
			// gather hosts
			List<string> clients = null;

			// run wake process over these
			foreach (var item in clients)
			{
				WOLService.IndividualWake(item);
			}
		}
	}
}
