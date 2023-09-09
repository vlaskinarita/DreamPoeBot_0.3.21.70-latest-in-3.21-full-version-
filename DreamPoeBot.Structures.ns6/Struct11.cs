namespace DreamPoeBot.Structures.ns6;

internal struct Struct11
{
	private readonly Struct9[] struct9_0;

	private readonly int int_0;

	public Struct11(int numBitLevels)
	{
		int_0 = numBitLevels;
		struct9_0 = new Struct9[1 << numBitLevels];
	}

	public void method_0()
	{
		for (uint num = 1u; (ulong)num < (ulong)(1L << (int_0 & 0x1F)); num++)
		{
			struct9_0[num].method_1();
		}
	}

	public uint method_1(Class64 class64_0)
	{
		uint num = 1u;
		for (int num2 = int_0; num2 > 0; num2--)
		{
			num = (num << 1) + struct9_0[num].method_2(class64_0);
		}
		return num - (uint)(1 << int_0);
	}

	public uint method_2(Class64 class64_0)
	{
		uint num = 1u;
		uint num2 = 0u;
		for (int i = 0; i < int_0; i++)
		{
			uint num3 = struct9_0[num].method_2(class64_0);
			num <<= 1;
			num += num3;
			num2 |= num3 << i;
		}
		return num2;
	}

	public static uint smethod_0(Struct9[] struct9_1, uint uint_0, Class64 class64_0, int int_1)
	{
		uint num = 1u;
		uint num2 = 0u;
		for (int i = 0; i < int_1; i++)
		{
			uint num3 = struct9_1[uint_0 + num].method_2(class64_0);
			num <<= 1;
			num += num3;
			num2 |= num3 << i;
		}
		return num2;
	}
}
