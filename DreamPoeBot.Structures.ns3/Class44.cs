using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace DreamPoeBot.Structures.ns3;

internal class Class44
{
	[Serializable]
	[CompilerGenerated]
	private sealed class Class45
	{
		public static readonly Class45 Class9 = new Class45();

		public static Func<byte, byte> Method9__0_0;

		public static Func<byte, byte> Method9__0_1;

		public static Func<byte, byte> Method9__1_0;

		public static Func<byte, byte> Method9__1_1;

		internal byte method_0(byte byte_0)
		{
			return (byte)(byte_0 ^ 0x56u);
		}

		internal byte method_1(byte byte_0)
		{
			return (byte)(byte_0 ^ 0x31u);
		}

		internal byte method_2(byte byte_0)
		{
			return (byte)(byte_0 ^ 0x56u);
		}

		internal byte method_3(byte byte_0)
		{
			return (byte)(byte_0 ^ 0x31u);
		}
	}

	public static uint smethod_0()
	{
		Assembly entryAssembly = Assembly.GetEntryAssembly();
		byte[] source = new byte[7] { 17, 51, 34, 24, 55, 59, 51 };
		byte[] source2 = new byte[17]
		{
			118, 84, 69, 97, 68, 83, 93, 88, 82, 122,
			84, 72, 101, 94, 90, 84, 95
		};
		object obj = entryAssembly.GetType().GetMethod(Encoding.ASCII.GetString(source.Select((byte byte_0) => (byte)(byte_0 ^ 0x56u)).ToArray()), new Type[0]).Invoke(entryAssembly, null);
		byte[] array = (byte[])obj.GetType().GetMethod(Encoding.ASCII.GetString(source2.Select((byte byte_0) => (byte)(byte_0 ^ 0x31u)).ToArray())).Invoke(obj, null);
		ulong num = 14695981039346656037uL;
		byte[] array2 = array;
		foreach (byte b in array2)
		{
			num ^= b;
			num *= 1099511628211L;
		}
		return (uint)(num & 0xFFFFFFFFuL);
	}

	private static byte[] smethod_1()
	{
		Assembly entryAssembly = Assembly.GetEntryAssembly();
		byte[] source = new byte[7] { 17, 51, 34, 24, 55, 59, 51 };
		byte[] source2 = new byte[17]
		{
			118, 84, 69, 97, 68, 83, 93, 88, 82, 122,
			84, 72, 101, 94, 90, 84, 95
		};
		object obj = entryAssembly.GetType().GetMethod(Encoding.ASCII.GetString(source.Select((byte byte_0) => (byte)(byte_0 ^ 0x56u)).ToArray()), new Type[0]).Invoke(entryAssembly, null);
		return (byte[])obj.GetType().GetMethod(Encoding.ASCII.GetString(source2.Select((byte byte_0) => (byte)(byte_0 ^ 0x31u)).ToArray())).Invoke(obj, null);
	}
}
