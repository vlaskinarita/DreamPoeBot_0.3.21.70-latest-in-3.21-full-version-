using System;

namespace DreamPoeBot.Structures.ns6;

internal struct Struct8
{
	public const uint uint_0 = 2048u;

	public const int int_0 = 11;

	public const int int_1 = 6;

	private const int int_2 = 5;

	private const int int_3 = 2;

	private static readonly uint[] uint_1;

	private uint uint_2;

	static Struct8()
	{
		uint_1 = new uint[512];
		for (int num = 8; num >= 0; num--)
		{
			uint num2 = (uint)(1 << 9 - num - 1);
			uint num3 = (uint)(1 << 9 - num);
			for (uint num4 = num2; num4 < num3; num4++)
			{
				uint_1[num4] = (uint)(num << 6) + (num3 - num4 << 6 >> 9 - num - 1);
			}
		}
	}

	public void method_0()
	{
		uint_2 = 1024u;
	}

	public void method_1(uint uint_3)
	{
		if (uint_3 == 0)
		{
			uint_2 += 2048 - uint_2 >> 5;
		}
		else
		{
			uint_2 -= uint_2 >> 5;
		}
	}

	public void method_2(Class63 class63_0, uint uint_3)
	{
		uint num = (class63_0.uint_2 >> 11) * uint_2;
		if (uint_3 == 0)
		{
			class63_0.uint_2 = num;
			uint_2 += 2048 - uint_2 >> 5;
		}
		else
		{
			class63_0.ulong_0 += num;
			class63_0.uint_2 -= num;
			uint_2 -= uint_2 >> 5;
		}
		if (class63_0.uint_2 < 16777216)
		{
			class63_0.uint_2 <<= 8;
			class63_0.method_7();
		}
	}

	public uint method_3(uint uint_3)
	{
		checked
		{
			return uint_1[(int)(IntPtr)(long)(unchecked((ulong)(((uint_2 - uint_3) ^ (0L - (long)uint_3)) & 0x7FFL)) >> 2)];
		}
	}

	public uint method_4()
	{
		return uint_1[uint_2 >> 2];
	}

	public uint method_5()
	{
		return uint_1[2048 - uint_2 >> 2];
	}
}
