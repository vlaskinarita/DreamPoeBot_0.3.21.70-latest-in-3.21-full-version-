namespace DreamPoeBot.Structures.ns6;

internal struct Struct10
{
	private readonly Struct8[] struct8_0;

	private readonly int int_0;

	public Struct10(int numBitLevels)
	{
		int_0 = numBitLevels;
		struct8_0 = new Struct8[1 << numBitLevels];
	}

	public void method_0()
	{
		for (uint num = 1u; (ulong)num < (ulong)(1L << (int_0 & 0x1F)); num++)
		{
			struct8_0[num].method_0();
		}
	}

	public void method_1(Class63 class63_0, uint uint_0)
	{
		uint num = 1u;
		int num2 = int_0;
		while (num2 > 0)
		{
			num2--;
			uint num3 = (uint_0 >> num2) & 1u;
			struct8_0[num].method_2(class63_0, num3);
			num = (num << 1) | num3;
		}
	}

	public void method_2(Class63 class63_0, uint uint_0)
	{
		uint num = 1u;
		for (uint num2 = 0u; (ulong)num2 < (ulong)int_0; num2++)
		{
			uint num3 = uint_0 & 1u;
			struct8_0[num].method_2(class63_0, num3);
			num = (num << 1) | num3;
			uint_0 >>= 1;
		}
	}

	public uint method_3(uint uint_0)
	{
		uint num = 0u;
		uint num2 = 1u;
		int num3 = int_0;
		while (num3 > 0)
		{
			num3--;
			uint num4 = (uint_0 >> num3) & 1u;
			num += struct8_0[num2].method_3(num4);
			num2 = (num2 << 1) + num4;
		}
		return num;
	}

	public uint method_4(uint uint_0)
	{
		uint num = 0u;
		uint num2 = 1u;
		for (int num3 = int_0; num3 > 0; num3--)
		{
			uint num4 = uint_0 & 1u;
			uint_0 >>= 1;
			num += struct8_0[num2].method_3(num4);
			num2 = (num2 << 1) | num4;
		}
		return num;
	}

	public static uint smethod_0(Struct8[] struct8_1, uint uint_0, int int_1, uint uint_1)
	{
		uint num = 0u;
		uint num2 = 1u;
		for (int num3 = int_1; num3 > 0; num3--)
		{
			uint num4 = uint_1 & 1u;
			uint_1 >>= 1;
			num += struct8_1[uint_0 + num2].method_3(num4);
			num2 = (num2 << 1) | num4;
		}
		return num;
	}

	public static void smethod_1(Struct8[] struct8_1, uint uint_0, Class63 class63_0, int int_1, uint uint_1)
	{
		uint num = 1u;
		for (int i = 0; i < int_1; i++)
		{
			uint num2 = uint_1 & 1u;
			struct8_1[uint_0 + num].method_2(class63_0, num2);
			num = (num << 1) | num2;
			uint_1 >>= 1;
		}
	}
}
