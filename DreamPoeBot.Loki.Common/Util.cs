using System;
using System.Security.Cryptography;
using System.Text;

namespace DreamPoeBot.Loki.Common;

public static class Util
{
	public static string CalculateMD5Hash(string input)
	{
		HashAlgorithm hashAlgorithm = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = hashAlgorithm.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString();
	}

	public static string RandomWindowTitle(string title)
	{
		return $"{title} [{CalculateMD5Hash(title + Environment.TickCount + new Random().NextDouble())}]";
	}
}
