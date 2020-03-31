using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections;

namespace Org.BouncyCastle.Security
{
	public sealed class DigestUtilities
	{
		private enum DigestAlgorithm
		{
			SHA_256
		}

		private static readonly IDictionary algorithms;

		static DigestUtilities()
		{
			algorithms = Platform.CreateHashtable();
			algorithms["SHA256"] = "SHA-256";
		}

		private DigestUtilities()
		{
		}

		public static IDigest GetDigest(string algorithm)
		{
			string text = Platform.ToUpperInvariant(algorithm);
			string text2 = (string)algorithms[text];
			if (text2 == null)
			{
				text2 = text;
			}
			try
			{
				if ((DigestAlgorithm)(object)Enums.GetEnumValue(typeof(DigestAlgorithm), text2) == DigestAlgorithm.SHA_256)
				{
					return new Sha256Digest();
				}
			}
			catch (ArgumentException)
			{
			}
			throw new CryptoException("Digest " + text2 + " not recognised.");
		}
	}
}
