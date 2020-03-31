using Poullight.Properties;

internal class HandlerParams
{
	public static void Start()
	{
		try
		{
			string text = null;
			text = Exporter.Export("<settings>", "</settings>", Resources.String0).Replace("\0", "");
			if (text != null)
			{
				text = Base64.Decode(text);
				string text2 = Exporter.Export("<prog.params>", "</prog.params>", text);
				string[] array = null;
				if (!string.IsNullOrEmpty(text2))
				{
					array = text2.Split('|');
				}
				if (array != null && array.Length != 0)
				{
					Starter.FileData = text;
					Starter.Params = array;
				}
			}
		}
		catch
		{
		}
	}
}
