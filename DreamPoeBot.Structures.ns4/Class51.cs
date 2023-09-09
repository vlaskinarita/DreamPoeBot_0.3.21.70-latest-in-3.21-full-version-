using System;
using System.IO;

namespace DreamPoeBot.Structures.ns4;

internal class Class51 : Class50, Interface5, Interface6
{
	private const uint uint_8 = 65536u;

	private const uint uint_9 = 0u;

	private const uint uint_10 = 1024u;

	private const uint uint_11 = 1024u;

	private const uint uint_12 = 65536u;

	private const uint uint_13 = 2147483647u;

	private const uint uint_14 = 1u;

	private uint uint_15 = 255u;

	private uint uint_16;

	private uint uint_17;

	private uint[] uint_18;

	private uint uint_19;

	private uint uint_20;

	private uint uint_21;

	private uint[] uint_22;

	private bool bool_1 = true;

	private uint uint_23 = 66560u;

	private uint uint_24 = 4u;

	private uint uint_25;

	public void imethod_0(Stream stream_1)
	{
		method_3(stream_1);
	}

	public void imethod_2()
	{
		method_4();
	}

	public void imethod_1()
	{
		method_5();
		for (uint num = 0u; num < uint_20; num++)
		{
			uint_18[num] = 0u;
		}
		uint_16 = 0u;
		method_10(-1);
	}

	public byte imethod_3(int int_0)
	{
		return method_7(int_0);
	}

	public uint imethod_4(int int_0, uint uint_26, uint uint_27)
	{
		return method_8(int_0, uint_26, uint_27);
	}

	public uint imethod_5()
	{
		return method_9();
	}

	public void imethod_6(uint uint_26, uint uint_27, uint uint_28, uint uint_29)
	{
		if (uint_26 > 2147483391)
		{
			throw new Exception();
		}
		uint_15 = 16 + (uint_28 >> 1);
		uint num = (uint_26 + uint_27 + uint_28 + uint_29) / 2u + 256;
		method_2(uint_26 + uint_27, uint_28 + uint_29, num);
		uint_21 = uint_28;
		uint num2 = uint_26 + 1;
		if (uint_17 != num2)
		{
			uint_22 = new uint[(uint_17 = num2) * 2];
		}
		uint num3 = 65536u;
		if (bool_1)
		{
			num3 = uint_26 - 1;
			num3 |= num3 >> 1;
			num3 |= num3 >> 2;
			num3 |= num3 >> 4;
			num3 |= num3 >> 8;
			num3 >>= 1;
			num3 |= 0xFFFFu;
			if (num3 > 16777216)
			{
				num3 >>= 1;
			}
			uint_19 = num3;
			num3++;
			num3 += uint_23;
		}
		if (num3 != uint_20)
		{
			uint_18 = new uint[uint_20 = num3];
		}
	}

	public uint imethod_7(uint[] uint_26)
	{
		uint num;
		if (uint_5 + uint_21 <= uint_7)
		{
			num = uint_21;
		}
		else
		{
			num = uint_7 - uint_5;
			if (num < uint_24)
			{
				method_12();
				return 0u;
			}
		}
		uint num2 = 0u;
		uint num3 = ((uint_5 > uint_17) ? (uint_5 - uint_17) : 0u);
		uint num4 = uint_1 + uint_5;
		uint num5 = 1u;
		uint num6 = 0u;
		uint num7 = 0u;
		uint num10;
		if (bool_1)
		{
			uint num8 = Class49.uint_0[byte_0[num4]] ^ byte_0[num4 + 1];
			num6 = num8 & 0x3FFu;
			uint num9 = num8 ^ (uint)(byte_0[num4 + 2] << 8);
			num7 = num9 & 0xFFFFu;
			num10 = (num9 ^ (Class49.uint_0[byte_0[num4 + 3]] << 5)) & uint_19;
		}
		else
		{
			num10 = (uint)(byte_0[num4] ^ (byte_0[num4 + 1] << 8));
		}
		uint num11 = uint_18[uint_23 + num10];
		if (bool_1)
		{
			uint num12 = uint_18[num6];
			uint num13 = uint_18[1024 + num7];
			uint_18[num6] = uint_5;
			uint_18[1024 + num7] = uint_5;
			if (num12 > num3 && byte_0[uint_1 + num12] == byte_0[num4])
			{
				int num14 = (int)num2++;
				num5 = 2u;
				uint_26[num14] = 2u;
				uint_26[num2++] = uint_5 - num12 - 1;
			}
			if (num13 > num3 && byte_0[uint_1 + num13] == byte_0[num4])
			{
				if (num13 == num12)
				{
					num2 -= 2;
				}
				int num15 = (int)num2++;
				num5 = 3u;
				uint_26[num15] = 3u;
				uint_26[num2++] = uint_5 - num13 - 1;
				num12 = num13;
			}
			if (num2 != 0 && num12 == num11)
			{
				num2 -= 2;
				num5 = 1u;
			}
		}
		uint_18[uint_23 + num10] = uint_5;
		uint num16 = (uint_16 << 1) + 1;
		uint num17 = uint_16 << 1;
		uint val;
		uint val2 = (val = uint_25);
		if (uint_25 != 0 && num11 > num3 && byte_0[uint_1 + num11 + uint_25] != byte_0[num4 + uint_25])
		{
			num5 = (uint_26[num2++] = uint_25);
			uint_26[num2++] = uint_5 - num11 - 1;
		}
		uint num18 = uint_15;
		while (num11 > num3 && num18-- != 0)
		{
			uint num19 = uint_5 - num11;
			uint num20 = ((num19 <= uint_16) ? (uint_16 - num19) : (uint_16 - num19 + uint_17)) << 1;
			uint num21 = uint_1 + num11;
			uint num22 = Math.Min(val, val2);
			if (byte_0[num21 + num22] == byte_0[num4 + num22])
			{
				while (++num22 != num && byte_0[num21 + num22] == byte_0[num4 + num22])
				{
				}
				if (num5 < num22)
				{
					num5 = (uint_26[num2++] = num22);
					uint_26[num2++] = num19 - 1;
					if (num22 == num)
					{
						uint_22[num17] = uint_22[num20];
						uint_22[num16] = uint_22[num20 + 1];
						method_12();
						return num2;
					}
				}
			}
			if (byte_0[num21 + num22] < byte_0[num4 + num22])
			{
				uint_22[num17] = num11;
				num17 = num20 + 1;
				num11 = uint_22[num17];
				val2 = num22;
			}
			else
			{
				uint_22[num16] = num11;
				num16 = num20;
				num11 = uint_22[num16];
				val = num22;
			}
		}
		uint[] array = uint_22;
		int num23 = (int)num16;
		uint_22[num17] = 0u;
		array[num23] = 0u;
		method_12();
		return num2;
	}

	public void imethod_8(uint uint_26)
	{
		do
		{
			uint num;
			if (uint_5 + uint_21 <= uint_7)
			{
				num = uint_21;
			}
			else
			{
				num = uint_7 - uint_5;
				if (num < uint_24)
				{
					method_12();
					continue;
				}
			}
			uint num2 = ((uint_5 > uint_17) ? (uint_5 - uint_17) : 0u);
			uint num3 = uint_1 + uint_5;
			uint num4;
			if (!bool_1)
			{
				num4 = (uint)(byte_0[num3] ^ (byte_0[num3 + 1] << 8));
			}
			else
			{
				uint num5 = Class49.uint_0[byte_0[num3]] ^ byte_0[num3 + 1];
				uint num6 = num5 & 0x3FFu;
				uint_18[num6] = uint_5;
				uint num7 = num5 ^ (uint)(byte_0[num3 + 2] << 8);
				uint num8 = num7 & 0xFFFFu;
				uint_18[1024 + num8] = uint_5;
				num4 = (num7 ^ (Class49.uint_0[byte_0[num3 + 3]] << 5)) & uint_19;
			}
			uint num9 = uint_18[uint_23 + num4];
			uint_18[uint_23 + num4] = uint_5;
			uint num10 = (uint_16 << 1) + 1;
			uint num11 = uint_16 << 1;
			uint val;
			uint val2 = (val = uint_25);
			uint num12 = uint_15;
			while (true)
			{
				if (num9 > num2 && num12-- != 0)
				{
					uint num13 = uint_5 - num9;
					uint num14 = ((num13 <= uint_16) ? (uint_16 - num13) : (uint_16 - num13 + uint_17)) << 1;
					uint num15 = uint_1 + num9;
					uint num16 = Math.Min(val, val2);
					if (byte_0[num15 + num16] == byte_0[num3 + num16])
					{
						while (++num16 != num && byte_0[num15 + num16] == byte_0[num3 + num16])
						{
						}
						if (num16 == num)
						{
							uint_22[num11] = uint_22[num14];
							uint_22[num10] = uint_22[num14 + 1];
							method_12();
							break;
						}
					}
					if (byte_0[num15 + num16] < byte_0[num3 + num16])
					{
						uint_22[num11] = num9;
						num11 = num14 + 1;
						num9 = uint_22[num11];
						val2 = num16;
					}
					else
					{
						uint_22[num10] = num9;
						num10 = num14;
						num9 = uint_22[num10];
						val = num16;
					}
					continue;
				}
				uint[] array = uint_22;
				int num17 = (int)num10;
				uint_22[num11] = 0u;
				array[num17] = 0u;
				method_12();
				break;
			}
		}
		while (--uint_26 != 0);
	}

	public void method_11(int int_0)
	{
		bool_1 = int_0 > 2;
		if (!bool_1)
		{
			uint_25 = 2u;
			uint_24 = 3u;
			uint_23 = 0u;
		}
		else
		{
			uint_25 = 0u;
			uint_24 = 4u;
			uint_23 = 66560u;
		}
	}

	public void method_12()
	{
		if (++uint_16 >= uint_17)
		{
			uint_16 = 0u;
		}
		method_6();
		if (uint_5 == int.MaxValue)
		{
			method_14();
		}
	}

	private void method_13(uint[] uint_26, uint uint_27, uint uint_28)
	{
		for (uint num = 0u; num < uint_27; num++)
		{
			uint num2 = uint_26[num];
			num2 = ((num2 > uint_28) ? (num2 - uint_28) : 0u);
			uint_26[num] = num2;
		}
	}

	private void method_14()
	{
		uint num = uint_5 - uint_17;
		method_13(uint_22, uint_17 * 2, num);
		method_13(uint_18, uint_20, num);
		method_10((int)num);
	}

	public void method_15(uint uint_26)
	{
		uint_15 = uint_26;
	}
}
