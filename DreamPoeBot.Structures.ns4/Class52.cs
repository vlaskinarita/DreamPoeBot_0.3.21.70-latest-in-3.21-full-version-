namespace DreamPoeBot.Structures.ns4;

internal abstract class Class52
{
	internal struct Struct5
	{
		public uint uint_0;

		public void method_0()
		{
			uint_0 = 0u;
		}

		public void method_1()
		{
			if (uint_0 < 4)
			{
				uint_0 = 0u;
			}
			else if (uint_0 < 10)
			{
				uint_0 -= 3u;
			}
			else
			{
				uint_0 -= 6u;
			}
		}

		public void method_2()
		{
			uint_0 = ((uint_0 < 7) ? 7u : 10u);
		}

		public void method_3()
		{
			uint_0 = ((uint_0 < 7) ? 8u : 11u);
		}

		public void method_4()
		{
			uint_0 = ((uint_0 < 7) ? 9u : 11u);
		}

		public bool method_5()
		{
			return uint_0 < 7;
		}
	}

	public const uint uint_0 = 15u;

	public const uint uint_1 = 16u;

	public const int int_0 = 0;

	public const uint uint_2 = 14u;

	public const uint uint_3 = 273u;

	public const uint uint_4 = 2u;

	public const int int_1 = 4;

	public const uint uint_5 = 128u;

	public const int int_2 = 8;

	public const uint uint_6 = 272u;

	public const uint uint_7 = 4u;

	public const int int_3 = 2;

	public const uint uint_8 = 8u;

	public const uint uint_9 = 4u;

	public const int int_4 = 3;

	public const uint uint_10 = 8u;

	public const int int_5 = 3;

	public const uint uint_11 = 8u;

	public const uint uint_12 = 10u;

	public const int int_6 = 6;

	public const int int_7 = 4;

	public const int int_8 = 4;

	public const uint uint_13 = 16u;

	public const uint uint_14 = 16u;

	public const uint uint_15 = 4u;

	public const uint uint_16 = 12u;

	public const uint uint_17 = 4u;

	public static uint smethod_0(uint uint_18)
	{
		uint_18 -= 2;
		if (uint_18 < 4)
		{
			return uint_18;
		}
		return 3u;
	}
}
