using System;

namespace Org.BouncyCastle.Crypto.Digests
{
	public abstract class GeneralDigest : IDigest
	{
		private const int BYTE_LENGTH = 64;

		private readonly byte[] xBuf;

		private long byteCount;

		private int xBufOff;

		public abstract string AlgorithmName
		{
			get;
		}

		internal GeneralDigest()
		{
			xBuf = new byte[4];
		}

		public void Update(byte input)
		{
			xBuf[xBufOff++] = input;
			if (xBufOff == xBuf.Length)
			{
				ProcessWord(xBuf, 0);
				xBufOff = 0;
			}
			byteCount++;
		}

		public void BlockUpdate(byte[] input, int inOff, int length)
		{
			length = Math.Max(0, length);
			int i = 0;
			if (xBufOff != 0)
			{
				while (i < length)
				{
					xBuf[xBufOff++] = input[inOff + i++];
					if (xBufOff == 4)
					{
						ProcessWord(xBuf, 0);
						xBufOff = 0;
						break;
					}
				}
			}
			for (int num = ((length - i) & -4) + i; i < num; i += 4)
			{
				ProcessWord(input, inOff + i);
			}
			while (i < length)
			{
				xBuf[xBufOff++] = input[inOff + i++];
			}
			byteCount += length;
		}

		public virtual void Reset()
		{
			byteCount = 0L;
			xBufOff = 0;
			Array.Clear(xBuf, 0, xBuf.Length);
		}

		public int GetByteLength()
		{
			return 64;
		}

		public abstract int GetDigestSize();

		public abstract int DoFinal(byte[] output, int outOff);

		public void Finish()
		{
			long bitLength = byteCount << 3;
			Update(128);
			while (xBufOff != 0)
			{
				Update(0);
			}
			ProcessLength(bitLength);
			ProcessBlock();
		}

		internal abstract void ProcessWord(byte[] input, int inOff);

		internal abstract void ProcessLength(long bitLength);

		internal abstract void ProcessBlock();
	}
}
