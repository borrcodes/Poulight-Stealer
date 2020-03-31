using System.Security.Cryptography;

internal class Encrypter
{
	public static byte[] key = new byte[8]
	{
		66,
		59,
		131,
		42,
		23,
		164,
		0,
		4
	};

	public static byte[] AES_Decryptor(byte[] input)
	{
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		rijndaelManaged.Key = mD5CryptoServiceProvider.ComputeHash(key);
		rijndaelManaged.Mode = CipherMode.ECB;
		return rijndaelManaged.CreateDecryptor().TransformFinalBlock(input, 0, input.Length);
	}
}
