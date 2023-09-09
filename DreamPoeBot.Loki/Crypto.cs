using System;
using System.IO;
using System.Security.Cryptography;

namespace DreamPoeBot.Loki;

public class Crypto
{
	private readonly byte[] byte_0;

	private byte[] Byte_0 => byte_0;

	public Crypto(byte[] salt)
	{
		byte_0 = new byte[salt.Length];
		for (int i = 0; i < salt.Length; i++)
		{
			byte_0[i] = salt[i];
		}
	}

	public string EncryptStringAes(string plainText, string sharedSecret)
	{
		if (string.IsNullOrEmpty(plainText))
		{
			throw new ArgumentNullException("plainText");
		}
		if (!string.IsNullOrEmpty(sharedSecret))
		{
			RijndaelManaged rijndaelManaged = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedSecret, Byte_0);
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
				ICryptoTransform transform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(BitConverter.GetBytes(rijndaelManaged.IV.Length), 0, 4);
				memoryStream.Write(rijndaelManaged.IV, 0, rijndaelManaged.IV.Length);
				using (CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					using StreamWriter streamWriter = new StreamWriter(stream);
					streamWriter.Write(plainText);
				}
				return Convert.ToBase64String(memoryStream.ToArray());
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
		}
		throw new ArgumentNullException("sharedSecret");
	}

	public string DecryptStringAes(string cipherText, string sharedSecret)
	{
		if (string.IsNullOrEmpty(cipherText))
		{
			throw new ArgumentNullException("cipherText");
		}
		if (!string.IsNullOrEmpty(sharedSecret))
		{
			RijndaelManaged rijndaelManaged = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedSecret, Byte_0);
				using MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText));
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
				rijndaelManaged.IV = smethod_0(memoryStream);
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using CryptoStream stream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream);
				return streamReader.ReadToEnd();
			}
			finally
			{
				rijndaelManaged?.Clear();
			}
		}
		throw new ArgumentNullException("sharedSecret");
	}

	private static byte[] smethod_0(Stream stream_0)
	{
		byte[] array = new byte[4];
		if (stream_0.Read(array, 0, array.Length) != array.Length)
		{
			throw new SystemException("Stream did not contain properly formatted byte array");
		}
		byte[] array2 = new byte[BitConverter.ToInt32(array, 0)];
		if (stream_0.Read(array2, 0, array2.Length) != array2.Length)
		{
			throw new SystemException("Did not read byte array properly");
		}
		return array2;
	}
}
