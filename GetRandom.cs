using System;
using System.Text;

internal class GetRandom
{
	public static string String(string Alphabet = null, int Length = -1)
	{
		Random random = new Random();
		if (Length == -1)
		{
			Length = random.Next(8, 32);
		}
		if (Alphabet == null)
		{
			Alphabet = "qwertyuiopasdfghjklzxcvbnm1234567890-_";
		}
		StringBuilder stringBuilder = new StringBuilder(Length - 1);
		int num = 0;
		for (int i = 0; i < Length; i++)
		{
			num = random.Next(0, Alphabet.Length - 1);
			stringBuilder.Append(Alphabet[num]);
		}
		return stringBuilder.ToString();
	}
}
