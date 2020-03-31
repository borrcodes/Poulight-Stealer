using System;
using System.IO;

internal class CreateDir
{
	public static string create(string dir1, string dir2 = null, string dir3 = null)
	{
		string text = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\" + dir1;
		try
		{
			Sqlite.SqliteFile();
			if (Directory.Exists(text))
			{
				Directory.Delete(text, recursive: true);
			}
			Directory.CreateDirectory(text);
			return text;
		}
		catch
		{
			try
			{
				text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + ((dir2 == null) ? dir1 : dir2);
				if (Directory.Exists(text))
				{
					Directory.Delete(text, recursive: true);
				}
				Directory.CreateDirectory(text);
				return text;
			}
			catch
			{
				try
				{
					text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + ((dir3 == null) ? dir1 : dir3);
					if (Directory.Exists(text))
					{
						Directory.Delete(text, recursive: true);
					}
					Directory.CreateDirectory(text);
					return text;
				}
				catch
				{
					Environment.Exit(0);
					return text;
				}
			}
		}
	}
}
