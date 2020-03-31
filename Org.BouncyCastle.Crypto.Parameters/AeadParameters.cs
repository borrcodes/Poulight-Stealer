namespace Org.BouncyCastle.Crypto.Parameters
{
	public class AeadParameters : ICipherParameters
	{
		private readonly byte[] associatedText;

		private readonly byte[] nonce;

		public virtual KeyParameter Key
		{
			get;
		}

		public virtual int MacSize
		{
			get;
		}

		public AeadParameters(KeyParameter key, int macSize, byte[] nonce, byte[] associatedText)
		{
			Key = key;
			this.nonce = nonce;
			MacSize = macSize;
			this.associatedText = associatedText;
		}

		public virtual byte[] GetAssociatedText()
		{
			return associatedText;
		}

		public virtual byte[] GetNonce()
		{
			return nonce;
		}
	}
}
