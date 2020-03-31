using System;
using System.Text;

internal class Base64
{
	public static string Encode(string text, Encoding encode = null)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return Convert.ToBase64String(((encode == null) ? Encoding.UTF8 : encode).GetBytes(text));
	}

	public static string Decode(string text, Encoding encode = null)
	{
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		return ((encode == null) ? Encoding.UTF8 : encode).GetString(Convert.FromBase64String(text));
	}
}
