using System.Collections;
using System.Globalization;

namespace Org.BouncyCastle.Utilities
{
	internal abstract class Platform
	{
		internal static IList CreateArrayList(int capacity)
		{
			return new ArrayList(capacity);
		}

		internal static IDictionary CreateHashtable()
		{
			return new Hashtable();
		}

		internal static string ToUpperInvariant(string s)
		{
			return s.ToUpper(CultureInfo.InvariantCulture);
		}

		internal static string GetTypeName(object obj)
		{
			return obj.GetType().FullName;
		}
	}
}
