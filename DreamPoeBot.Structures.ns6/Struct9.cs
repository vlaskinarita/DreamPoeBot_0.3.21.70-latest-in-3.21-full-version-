namespace DreamPoeBot.Structures.ns6;

internal struct Struct9
{
	public const uint uint_0 = 2048u;

	public const int int_0 = 11;

	private const int int_1 = 5;

	private uint uint_1;

	public void method_0(int int_2, uint uint_2)
	{
		if (uint_2 == 0)
		{
			uint_1 += 2048 - uint_1 >> int_2;
		}
		else
		{
			uint_1 -= uint_1 >> int_2;
		}
	}

	public void method_1()
	{
		uint_1 = 1024u;
	}

	public uint method_2(Class64 class64_0)
	{
		uint num = (class64_0.uint_2 >> 11) * uint_1;
		if (class64_0.uint_1 < num)
		{
			class64_0.uint_2 = num;
			uint_1 += 2048 - uint_1 >> 5;
			if (class64_0.uint_2 < 16777216)
			{
				class64_0.uint_1 = (class64_0.uint_1 << 8) | (byte)class64_0.stream_0.ReadByte();
				class64_0.uint_2 <<= 8;
			}
			return 0u;
		}
		class64_0.uint_2 -= num;
		class64_0.uint_1 -= num;
		uint_1 -= uint_1 >> 5;
		if (class64_0.uint_2 < 16777216)
		{
			class64_0.uint_1 = (class64_0.uint_1 << 8) | (byte)class64_0.stream_0.ReadByte();
			class64_0.uint_2 <<= 8;
		}
		return 1u;
	}
}
