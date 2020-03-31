using System;

namespace Org.BouncyCastle.Utilities
{
	internal abstract class Enums
	{
		internal static Enum GetEnumValue(Type enumType, string s)
		{
			if (!enumType.IsEnum)
			{
				throw new ArgumentException("Not an enumeration type", "enumType");
			}
			if (s.Length > 0 && char.IsLetter(s[0]) && s.IndexOf(',') < 0)
			{
				s = s.Replace('-', '_');
				s = s.Replace('/', '_');
				return (Enum)Enum.Parse(enumType, s, ignoreCase: false);
			}
			throw new ArgumentException();
		}
	}
}
