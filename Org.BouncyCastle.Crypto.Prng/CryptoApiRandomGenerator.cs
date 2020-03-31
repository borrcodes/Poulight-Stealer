using System.Security.Cryptography;

namespace Org.BouncyCastle.Crypto.Prng
{
	public class CryptoApiRandomGenerator : IRandomGenerator
	{
		private readonly RandomNumberGenerator rndProv;

		public CryptoApiRandomGenerator()
			: this(RandomNumberGenerator.Create())
		{
		}

		public CryptoApiRandomGenerator(RandomNumberGenerator rng)
		{
			rndProv = rng;
		}

		public virtual void NextBytes(byte[] bytes)
		{
			rndProv.GetBytes(bytes);
		}
	}
}
