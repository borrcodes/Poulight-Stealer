using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Prng;
using System;
using System.Threading;

namespace Org.BouncyCastle.Security
{
	public class SecureRandom : Random
	{
		private static long counter = DateTime.UtcNow.Ticks * 100;

		private static readonly double DoubleScale = Math.Pow(2.0, 64.0);

		protected readonly IRandomGenerator generator;

		private static SecureRandom Master
		{
			get;
		} = new SecureRandom(new CryptoApiRandomGenerator());


		public SecureRandom()
			: this(CreatePrng("SHA256", autoSeed: true))
		{
		}

		public SecureRandom(IRandomGenerator generator)
			: base(0)
		{
			this.generator = generator;
		}

		private static long NextCounterValue()
		{
			return Interlocked.Increment(ref counter);
		}

		private static DigestRandomGenerator CreatePrng(string digestName, bool autoSeed)
		{
			IDigest digest = DigestUtilities.GetDigest(digestName);
			if (digest == null)
			{
				return null;
			}
			DigestRandomGenerator digestRandomGenerator = new DigestRandomGenerator(digest);
			if (autoSeed)
			{
				digestRandomGenerator.AddSeedMaterial(NextCounterValue());
				digestRandomGenerator.AddSeedMaterial(GetNextBytes(Master, digest.GetDigestSize()));
			}
			return digestRandomGenerator;
		}

		public static byte[] GetNextBytes(SecureRandom secureRandom, int length)
		{
			byte[] array = new byte[length];
			secureRandom.NextBytes(array);
			return array;
		}

		public override int Next()
		{
			return NextInt() & int.MaxValue;
		}

		public override int Next(int maxValue)
		{
			if (maxValue < 2)
			{
				if (maxValue < 0)
				{
					throw new ArgumentOutOfRangeException("maxValue", "cannot be negative");
				}
				return 0;
			}
			int num;
			if ((maxValue & (maxValue - 1)) == 0)
			{
				num = (NextInt() & int.MaxValue);
				return (int)((long)num * (long)maxValue >> 31);
			}
			int num2;
			do
			{
				num = (NextInt() & int.MaxValue);
				num2 = num % maxValue;
			}
			while (num - num2 + (maxValue - 1) < 0);
			return num2;
		}

		public override int Next(int minValue, int maxValue)
		{
			if (maxValue <= minValue)
			{
				if (maxValue == minValue)
				{
					return minValue;
				}
				throw new ArgumentException("maxValue cannot be less than minValue");
			}
			int num = maxValue - minValue;
			if (num > 0)
			{
				return minValue + Next(num);
			}
			int num2;
			do
			{
				num2 = NextInt();
			}
			while (num2 < minValue || num2 >= maxValue);
			return num2;
		}

		public override void NextBytes(byte[] buf)
		{
			generator.NextBytes(buf);
		}

		public override double NextDouble()
		{
			return Convert.ToDouble((ulong)NextLong()) / DoubleScale;
		}

		public virtual int NextInt()
		{
			byte[] array = new byte[4];
			NextBytes(array);
			return (((((array[0] << 8) | array[1]) << 8) | array[2]) << 8) | array[3];
		}

		public virtual long NextLong()
		{
			return (long)(((ulong)(uint)NextInt() << 32) | (uint)NextInt());
		}
	}
}
