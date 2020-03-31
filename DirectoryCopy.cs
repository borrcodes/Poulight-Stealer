using System.IO;

internal class DirectoryCopy
{
	public DirectoryCopy(string sourceDirectoryName, string destDirectoryName)
	{
		if (sourceDirectoryName.ToLower() == destDirectoryName.ToLower())
		{
			return;
		}
		if (!Directory.Exists(destDirectoryName))
		{
			Directory.CreateDirectory(destDirectoryName);
		}
		string[] directories = Directory.GetDirectories(sourceDirectoryName);
		if (directories.Length != 0)
		{
			string[] array = directories;
			foreach (string text in array)
			{
				new DirectoryCopy(text, destDirectoryName + "\\" + Path.GetFileName(text));
			}
		}
		string[] files = Directory.GetFiles(sourceDirectoryName);
		if (files.Length != 0)
		{
			string[] array = files;
			foreach (string text2 in array)
			{
				File.Copy(text2, destDirectoryName + "\\" + Path.GetFileName(text2));
			}
		}
	}
}
