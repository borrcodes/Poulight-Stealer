namespace Org.BouncyCastle.Crypto
{
	internal class Check
	{
		internal static void DataLength(byte[] buf, int off, int len, string msg)
		{
			if (off > buf.Length - len)
			{
				throw new CryptoException(msg);
			}
		}

		internal static void OutputLength(byte[] buf, int off, int len, string msg)
		{
			if (off > buf.Length - len)
			{
				throw new CryptoException(msg);
			}
		}
	}
}
