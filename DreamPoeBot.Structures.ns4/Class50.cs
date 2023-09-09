using System;
using System.IO;

namespace DreamPoeBot.Structures.ns4;

internal class Class50
{
	public uint uint_0;

	public byte[] byte_0;

	public uint uint_1;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	public uint uint_5;

	private uint uint_6;

	private Stream stream_0;

	private bool bool_0;

	public uint uint_7;

	public void method_0()
	{
		uint num = uint_1 + uint_5 - uint_3;
		if (num != 0)
		{
			num--;
		}
		uint num2 = uint_1 + uint_7 - num;
		for (uint num3 = 0u; num3 < num2; num3++)
		{
			byte_0[num3] = byte_0[num + num3];
		}
		uint_1 -= num;
	}

	public virtual void vmethod_0()
	{
		if (bool_0)
		{
			return;
		}
		while (true)
		{
			int num = (int)(0 - uint_1 + uint_0 - uint_7);
			if (num != 0)
			{
				int num2 = stream_0.Read(byte_0, (int)(uint_1 + uint_7), num);
				if (num2 == 0)
				{
					break;
				}
				uint_7 += (uint)num2;
				if (uint_7 >= uint_5 + uint_2)
				{
					uint_6 = uint_7 - uint_2;
				}
				continue;
			}
			return;
		}
		uint_6 = uint_7;
		if (uint_1 + uint_6 > uint_4)
		{
			uint_6 = uint_4 - uint_1;
		}
		bool_0 = true;
	}

	private void method_1()
	{
		byte_0 = null;
	}

	public void method_2(uint uint_8, uint uint_9, uint uint_10)
	{
		uint_3 = uint_8;
		uint_2 = uint_9;
		uint num = uint_8 + uint_9 + uint_10;
		if (byte_0 == null || uint_0 != num)
		{
			method_1();
			uint_0 = num;
			byte_0 = new byte[uint_0];
		}
		uint_4 = uint_0 - uint_9;
	}

	public void method_3(Stream stream_1)
	{
		stream_0 = stream_1;
	}

	public void method_4()
	{
		stream_0 = null;
	}

	public void method_5()
	{
		uint_1 = 0u;
		uint_5 = 0u;
		uint_7 = 0u;
		bool_0 = false;
		vmethod_0();
	}

	public void method_6()
	{
		uint_5++;
		if (uint_5 > uint_6)
		{
			if (uint_1 + uint_5 > uint_4)
			{
				method_0();
			}
			vmethod_0();
		}
	}

	public byte method_7(int int_0)
	{
		checked
		{
			return byte_0[(int)(IntPtr)(long)unchecked((ulong)(uint_1 + uint_5 + int_0))];
		}
	}

	public uint method_8(int int_0, uint uint_8, uint uint_9)
	{
		if (bool_0 && (ulong)(uint_5 + int_0 + uint_9) > (ulong)uint_7)
		{
			uint_9 = uint_7 - (uint)(int)(uint_5 + int_0);
		}
		uint_8++;
		uint num = uint_1 + uint_5 + (uint)int_0;
		uint num2;
		for (num2 = 0u; num2 < uint_9 && byte_0[num + num2] == byte_0[num + num2 - uint_8]; num2++)
		{
		}
		return num2;
	}

	public uint method_9()
	{
		return uint_7 - uint_5;
	}

	public void method_10(int int_0)
	{
		uint_1 += (uint)int_0;
		uint_6 -= (uint)int_0;
		uint_5 -= (uint)int_0;
		uint_7 -= (uint)int_0;
	}
}
