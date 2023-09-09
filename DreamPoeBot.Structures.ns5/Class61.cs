using System;
using System.IO;
using DreamPoeBot.Structures.ns4;

namespace DreamPoeBot.Structures.ns5;

internal static class Class61
{
	private const int int_0 = 8388608;

	private static readonly object[] object_0 = new object[8] { 8388608, 2, 3, 0, 2, 128, "bt4", false };

	private static readonly Enum2[] enum2_0 = new Enum2[8]
	{
		Enum2.const_1,
		Enum2.const_5,
		Enum2.const_6,
		Enum2.const_7,
		Enum2.const_12,
		Enum2.const_8,
		Enum2.const_9,
		Enum2.const_14
	};

	public static byte[] smethod_0(byte[] byte_0)
	{
		using MemoryStream stream_ = new MemoryStream(byte_0);
		return smethod_1(stream_);
	}

	public static byte[] smethod_1(Stream stream_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		Class56 @class = new Class56();
		@class.imethod_1(enum2_0, object_0);
		@class.imethod_2(memoryStream);
		long length = stream_0.Length;
		for (int i = 0; i < 8; i++)
		{
			memoryStream.WriteByte((byte)(length >> 8 * i));
		}
		@class.imethod_0(stream_0, memoryStream, -1L, -1L, null);
		return memoryStream.ToArray();
	}

	public static byte[] smethod_2(byte[] byte_0)
	{
		using MemoryStream stream_ = new MemoryStream(byte_0);
		return smethod_3(stream_);
	}

	public static byte[] smethod_3(Stream stream_0)
	{
		Class53 @class = new Class53();
		stream_0.Seek(0L, SeekOrigin.Begin);
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[5];
		if (stream_0.Read(array, 0, 5) == 5)
		{
			long num = 0L;
			for (int i = 0; i < 8; i++)
			{
				int num2 = stream_0.ReadByte();
				if (num2 >= 0)
				{
					num |= (long)((ulong)(byte)num2 << 8 * i);
					continue;
				}
				throw new Exception("Can't Read 1");
			}
			@class.imethod_1(array);
			long long_ = stream_0.Length - stream_0.Position;
			@class.imethod_0(stream_0, memoryStream, long_, num, null);
			return memoryStream.ToArray();
		}
		throw new Exception("input .lzma is too short");
	}
}
