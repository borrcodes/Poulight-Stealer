namespace Org.BouncyCastle.Crypto.Prng
{
	public interface IRandomGenerator
	{
		void NextBytes(byte[] bytes);
	}
}
