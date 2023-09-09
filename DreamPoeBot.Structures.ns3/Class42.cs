using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace DreamPoeBot.Structures.ns3;

internal class Class42
{
	[Serializable]
	[CompilerGenerated]
	private sealed class Class43
	{
		public static readonly Class43 Class9 = new Class43();

		public static Func<byte, string> Method9__2_0;

		public static Func<string, byte, string> Method9__3_0;

		internal string method_0(byte byte_0)
		{
			return byte_0.ToString("x2");
		}

		internal string method_1(string string_0, byte byte_0)
		{
			return string_0 + byte_0.ToString("x2");
		}
	}

	private const string string_0 = "<RSAKeyValue><Modulus>ntODwyoUyuohguy+MRKVhGUy864S5IpTUoy1WNzbl74rIn3h9jo+d++UKGsBBeNw8y+hmtfaiYCr8Nd6M2g7f1RHWuZO7au/Ct6ol6stJG3sS8d59/j7pLABL5ZoIjwQhWdu1kJ5w2uPZHDN8F6qncAq8YFur7Lh7/ZxeNu8B/E=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

	public static byte[] smethod_0(string string_1)
	{
		using RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider(1024);
		rSACryptoServiceProvider.FromXmlString("<RSAKeyValue><Modulus>ntODwyoUyuohguy+MRKVhGUy864S5IpTUoy1WNzbl74rIn3h9jo+d++UKGsBBeNw8y+hmtfaiYCr8Nd6M2g7f1RHWuZO7au/Ct6ol6stJG3sS8d59/j7pLABL5ZoIjwQhWdu1kJ5w2uPZHDN8F6qncAq8YFur7Lh7/ZxeNu8B/E=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
		byte[] result = rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(string_1), fOAEP: true);
		rSACryptoServiceProvider.PersistKeyInCsp = false;
		return result;
	}

	public static string smethod_1(string string_1)
	{
		using SHA256Managed sHA256Managed = new SHA256Managed();
		byte[] source = sHA256Managed.ComputeHash(Encoding.UTF8.GetBytes(string_1));
		return string.Join("", source.Select((byte byte_0) => byte_0.ToString("x2")));
	}

	public static string smethod_2(string string_1)
	{
		using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		return mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(string_1)).Aggregate("", (string string_0, byte byte_0) => string_0 + byte_0.ToString("x2"));
	}

	public static byte[] smethod_3(byte[] byte_0, byte[] byte_1)
	{
		byte[] array = new byte[32];
		byte[] array2 = new byte[16];
		using (SHA512CryptoServiceProvider sHA512CryptoServiceProvider = new SHA512CryptoServiceProvider())
		{
			byte[] src = sHA512CryptoServiceProvider.ComputeHash(byte_1);
			Buffer.BlockCopy(src, 0, array, 0, 32);
			Buffer.BlockCopy(src, 0, array2, 32, 16);
		}
		using MemoryStream memoryStream = new MemoryStream();
		using RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.ISO10126;
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateEncryptor(array, array2), CryptoStreamMode.Write);
		cryptoStream.Write(byte_0, 0, byte_0.Length);
		cryptoStream.FlushFinalBlock();
		return memoryStream.ToArray();
	}

	public static byte[] smethod_4(byte[] byte_0, byte[] byte_1)
	{
		return smethod_5(byte_0, byte_1, byte_1);
	}

	public static byte[] smethod_5(byte[] byte_0, byte[] byte_1, byte[] byte_2)
	{
		if (byte_1.Length != 32)
		{
			byte[] array = new byte[32];
			for (int i = 0; i < 32; i++)
			{
				if (i >= byte_1.Length)
				{
					array[i] = (byte)i;
				}
				else
				{
					array[i] = byte_1[i];
				}
			}
			byte_1 = array;
		}
		if (byte_2.Length != 16)
		{
			byte[] array2 = new byte[16];
			for (int j = 0; j < 16; j++)
			{
				if (j < byte_2.Length)
				{
					array2[j] = byte_2[j];
				}
				else
				{
					array2[j] = (byte)j;
				}
			}
			byte_2 = array2;
		}
		using RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelManaged.Key = byte_1;
		rijndaelManaged.IV = byte_2;
		rijndaelManaged.Mode = CipherMode.ECB;
		rijndaelManaged.Padding = PaddingMode.ISO10126;
		using MemoryStream memoryStream = new MemoryStream();
		using CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndaelManaged.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_0, 0, byte_0.Length);
		cryptoStream.FlushFinalBlock();
		return memoryStream.ToArray();
	}
}
