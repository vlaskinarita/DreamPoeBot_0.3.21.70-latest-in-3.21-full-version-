using System.IO;

namespace DreamPoeBot.Structures.ns4;

internal class Class62
{
	private byte[] byte_0;

	private uint uint_0;

	private Stream stream_0;

	private uint uint_1;

	private uint uint_2;

	public void method_0(uint uint_3)
	{
		if (uint_2 != uint_3)
		{
			byte_0 = new byte[uint_3];
		}
		uint_2 = uint_3;
		uint_0 = 0u;
		uint_1 = 0u;
	}

	public void method_1(Stream stream_1, bool bool_0)
	{
		method_3();
		stream_0 = stream_1;
		if (!bool_0)
		{
			uint_1 = 0u;
			uint_0 = 0u;
		}
	}

	public void method_2(Stream stream_1)
	{
		method_1(stream_1, bool_0: false);
	}

	public void method_3()
	{
		method_4();
		stream_0 = null;
	}

	public void method_4()
	{
		uint num = uint_0 - uint_1;
		if (num != 0)
		{
			stream_0.Write(byte_0, (int)uint_1, (int)num);
			if (uint_0 >= uint_2)
			{
				uint_0 = 0u;
			}
			uint_1 = uint_0;
		}
	}

	public void method_5(uint uint_3, uint uint_4)
	{
		uint num = uint_0 - uint_3 - 1;
		if (num >= uint_2)
		{
			num += uint_2;
		}
		while (uint_4 != 0)
		{
			if (num >= uint_2)
			{
				num = 0u;
			}
			byte[] array = byte_0;
			array[uint_0++] = byte_0[num++];
			if (uint_0 >= uint_2)
			{
				method_4();
			}
			uint_4--;
		}
	}

	public void method_6(byte byte_1)
	{
		byte[] array = byte_0;
		array[uint_0++] = byte_1;
		if (uint_0 >= uint_2)
		{
			method_4();
		}
	}

	public byte method_7(uint uint_3)
	{
		uint num = uint_0 - uint_3 - 1;
		if (num >= uint_2)
		{
			num += uint_2;
		}
		return byte_0[num];
	}
}
