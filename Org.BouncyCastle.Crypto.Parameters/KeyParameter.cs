using System;

namespace Org.BouncyCastle.Crypto.Parameters
{
	public class KeyParameter : ICipherParameters
	{
		private readonly byte[] key;

		public KeyParameter(byte[] key)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			this.key = (byte[])key.Clone();
		}

		public byte[] GetKey()
		{
			return (byte[])key.Clone();
		}
	}
}
