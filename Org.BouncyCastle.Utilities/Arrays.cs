using System;

namespace Org.BouncyCastle.Utilities
{
	public abstract class Arrays
	{
		public static bool AreEqual(byte[] a, byte[] b)
		{
			if (a == b)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return HaveSameContents(a, b);
		}

		public static bool ConstantTimeAreEqual(byte[] a, byte[] b)
		{
			if (a == null || b == null)
			{
				return false;
			}
			if (a == b)
			{
				return true;
			}
			int num = Math.Min(a.Length, b.Length);
			int num2 = a.Length ^ b.Length;
			for (int i = 0; i < num; i++)
			{
				num2 |= (a[i] ^ b[i]);
			}
			for (int j = num; j < b.Length; j++)
			{
				num2 |= (b[j] ^ ~b[j]);
			}
			return num2 == 0;
		}

		public static bool AreEqual(uint[] a, uint[] b)
		{
			if (a == b)
			{
				return true;
			}
			if (a == null || b == null)
			{
				return false;
			}
			return HaveSameContents(a, b);
		}

		private static bool HaveSameContents(byte[] a, byte[] b)
		{
			int num = a.Length;
			if (num != b.Length)
			{
				return false;
			}
			while (num != 0)
			{
				num--;
				if (a[num] != b[num])
				{
					return false;
				}
			}
			return true;
		}

		private static bool HaveSameContents(uint[] a, uint[] b)
		{
			int num = a.Length;
			if (num != b.Length)
			{
				return false;
			}
			while (num != 0)
			{
				num--;
				if (a[num] != b[num])
				{
					return false;
				}
			}
			return true;
		}

		public static byte[] Clone(byte[] data)
		{
			if (data != null)
			{
				return (byte[])data.Clone();
			}
			return null;
		}

		public static uint[] Clone(uint[] data)
		{
			if (data != null)
			{
				return (uint[])data.Clone();
			}
			return null;
		}

		public static void Fill(byte[] buf, byte b)
		{
			int num = buf.Length;
			while (num > 0)
			{
				buf[--num] = b;
			}
		}

		public static byte[] CopyOfRange(byte[] data, int from, int to)
		{
			int length = GetLength(from, to);
			byte[] array = new byte[length];
			Array.Copy(data, from, array, 0, Math.Min(length, data.Length - from));
			return array;
		}

		private static int GetLength(int from, int to)
		{
			int num = to - from;
			if (num < 0)
			{
				throw new ArgumentException(from + " > " + to);
			}
			return num;
		}
	}
}
