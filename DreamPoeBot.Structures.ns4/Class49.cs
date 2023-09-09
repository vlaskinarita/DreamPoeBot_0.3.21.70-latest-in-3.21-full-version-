namespace DreamPoeBot.Structures.ns4;

internal class Class49
{
	public static readonly uint[] uint_0;

	private uint uint_1 = uint.MaxValue;

	static Class49()
	{
		uint_0 = new uint[256];
		for (uint num = 0u; num < 256; num++)
		{
			uint num2 = num;
			for (int i = 0; i < 8; i++)
			{
				num2 = (((num2 & (true ? 1u : 0u)) != 0) ? ((num2 >> 1) ^ 0xEDB88320u) : (num2 >> 1));
			}
			uint_0[num] = num2;
		}
	}

	public void method_0()
	{
		uint_1 = uint.MaxValue;
	}

	public void method_1(byte byte_0)
	{
		uint_1 = uint_0[(byte)uint_1 ^ byte_0] ^ (uint_1 >> 8);
	}

	public void method_2(byte[] byte_0, uint uint_2, uint uint_3)
	{
		for (uint num = 0u; num < uint_3; num++)
		{
			uint_1 = uint_0[(byte)uint_1 ^ byte_0[uint_2 + num]] ^ (uint_1 >> 8);
		}
	}

	public uint method_3()
	{
		return uint_1 ^ 0xFFFFFFFFu;
	}

	private static uint smethod_0(byte[] byte_0, uint uint_2, uint uint_3)
	{
		Class49 @class = new Class49();
		@class.method_2(byte_0, uint_2, uint_3);
		return @class.method_3();
	}

	private static bool smethod_1(uint uint_2, byte[] byte_0, uint uint_3, uint uint_4)
	{
		return smethod_0(byte_0, uint_3, uint_4) == uint_2;
	}
}
