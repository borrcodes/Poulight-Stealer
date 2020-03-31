using System.IO;

internal class AntiReplaySender
{
	public static bool CheckReplayStart()
	{
		try
		{
			string path = string.Format("{0}{1}", Buffer.path_t, Exporter.Export("<mutex>", "</mutex>", Starter.FileData).ToLower());
			if (File.Exists(path))
			{
				return true;
			}
			File.WriteAllText(path, GetRandom.String());
			return false;
		}
		catch
		{
			return false;
		}
	}
}
