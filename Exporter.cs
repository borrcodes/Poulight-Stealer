using System;

internal class Exporter
{
	public static string Export(string start, string end, string data)
	{
		try
		{
			if (data != null && data.Contains(start) && data.Contains(end))
			{
				return data.Split(new string[1]
				{
					start
				}, StringSplitOptions.None)[1].Split(new string[1]
				{
					end
				}, StringSplitOptions.None)[0];
			}
			return null;
		}
		catch
		{
			return null;
		}
	}
}
