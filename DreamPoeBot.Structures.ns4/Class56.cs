using System;
using System.IO;
using DreamPoeBot.Structures.ns5;
using DreamPoeBot.Structures.ns6;

namespace DreamPoeBot.Structures.ns4;

internal class Class56 : Interface1, Interface2, Interface3
{
	private enum Enum3
	{
		const_0,
		const_1
	}

	internal class Class57
	{
		private readonly Struct10[] struct10_0 = new Struct10[16];

		private readonly Struct10[] struct10_1 = new Struct10[16];

		private Struct8 struct8_0;

		private Struct8 struct8_1;

		private Struct10 struct10_2 = new Struct10(8);

		public Class57()
		{
			for (uint num = 0u; num < 16; num++)
			{
				struct10_0[num] = new Struct10(3);
				struct10_1[num] = new Struct10(3);
			}
		}

		public void method_0(uint uint_0)
		{
			struct8_0.method_0();
			struct8_1.method_0();
			for (uint num = 0u; num < uint_0; num++)
			{
				struct10_0[num].method_0();
				struct10_1[num].method_0();
			}
			struct10_2.method_0();
		}

		public void method_1(Class63 class63_0, uint uint_0, uint uint_1)
		{
			if (uint_0 < 8)
			{
				struct8_0.method_2(class63_0, 0u);
				struct10_0[uint_1].method_1(class63_0, uint_0);
				return;
			}
			uint_0 -= 8;
			struct8_0.method_2(class63_0, 1u);
			if (uint_0 < 8)
			{
				struct8_1.method_2(class63_0, 0u);
				struct10_1[uint_1].method_1(class63_0, uint_0);
			}
			else
			{
				struct8_1.method_2(class63_0, 1u);
				struct10_2.method_1(class63_0, uint_0 - 8);
			}
		}

		public void method_2(uint uint_0, uint uint_1, uint[] uint_2, uint uint_3)
		{
			uint num = struct8_0.method_4();
			uint num2 = struct8_0.method_5();
			uint num3 = num2 + struct8_1.method_4();
			uint num4 = num2 + struct8_1.method_5();
			uint num5 = 0u;
			while (true)
			{
				if (num5 < 8)
				{
					if (num5 < uint_1)
					{
						uint_2[uint_3 + num5] = num + struct10_0[uint_0].method_3(num5);
						num5++;
						continue;
					}
					break;
				}
				while (true)
				{
					if (num5 < 16)
					{
						if (num5 < uint_1)
						{
							uint_2[uint_3 + num5] = num3 + struct10_1[uint_0].method_3(num5 - 8);
							num5++;
							continue;
						}
						break;
					}
					for (; num5 < uint_1; num5++)
					{
						uint_2[uint_3 + num5] = num4 + struct10_2.method_3(num5 - 8 - 8);
					}
					break;
				}
				break;
			}
		}
	}

	internal class Class58 : Class57
	{
		private readonly uint[] uint_0 = new uint[16];

		private readonly uint[] uint_1 = new uint[4352];

		private uint uint_2;

		public void method_3(uint uint_3)
		{
			uint_2 = uint_3;
		}

		public uint method_4(uint uint_3, uint uint_4)
		{
			return uint_1[uint_4 * 272 + uint_3];
		}

		private void method_5(uint uint_3)
		{
			method_2(uint_3, uint_2, uint_1, uint_3 * 272);
			uint_0[uint_3] = uint_2;
		}

		public void method_6(uint uint_3)
		{
			for (uint num = 0u; num < uint_3; num++)
			{
				method_5(num);
			}
		}

		public void method_7(Class63 class63_0, uint uint_3, uint uint_4)
		{
			method_1(class63_0, uint_3, uint_4);
			uint[] array = uint_0;
			if (--array[uint_4] == 0)
			{
				method_5(uint_4);
			}
		}
	}

	internal class Class59
	{
		public struct Struct7
		{
			private Struct8[] struct8_0;

			public void method_0()
			{
				struct8_0 = new Struct8[768];
			}

			public void method_1()
			{
				for (int i = 0; i < 768; i++)
				{
					struct8_0[i].method_0();
				}
			}

			public void method_2(Class63 class63_0, byte byte_0)
			{
				uint num = 1u;
				for (int num2 = 7; num2 >= 0; num2--)
				{
					uint num3 = (uint)(byte_0 >> num2) & 1u;
					struct8_0[num].method_2(class63_0, num3);
					num = (num << 1) | num3;
				}
			}

			public void method_3(Class63 class63_0, byte byte_0, byte byte_1)
			{
				uint num = 1u;
				bool flag = true;
				for (int num2 = 7; num2 >= 0; num2--)
				{
					uint num3 = (uint)(byte_1 >> num2) & 1u;
					uint num4 = num;
					if (flag)
					{
						uint num5 = (uint)(byte_0 >> num2) & 1u;
						num4 += 1 + num5 << 8;
						flag = num5 == num3;
					}
					struct8_0[num4].method_2(class63_0, num3);
					num = (num << 1) | num3;
				}
			}

			public uint method_4(bool bool_0, byte byte_0, byte byte_1)
			{
				uint num = 0u;
				uint num2 = 1u;
				int num3 = 7;
				if (bool_0)
				{
					while (num3 >= 0)
					{
						uint num4 = (uint)(byte_0 >> num3) & 1u;
						uint num5 = (uint)(byte_1 >> num3) & 1u;
						num += struct8_0[(1 + num4 << 8) + num2].method_3(num5);
						num2 = (num2 << 1) | num5;
						if (num4 == num5)
						{
							num3--;
							continue;
						}
						num3--;
						break;
					}
				}
				while (num3 >= 0)
				{
					uint num6 = (uint)(byte_1 >> num3) & 1u;
					num += struct8_0[num2].method_3(num6);
					num2 = (num2 << 1) | num6;
					num3--;
				}
				return num;
			}
		}

		private Struct7[] struct7_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		public void method_0(int int_2, int int_3)
		{
			if (struct7_0 == null || int_1 != int_3 || int_0 != int_2)
			{
				int_0 = int_2;
				uint_0 = (uint)((1 << int_2) - 1);
				int_1 = int_3;
				uint num = (uint)(1 << int_1 + int_0);
				struct7_0 = new Struct7[num];
				for (uint num2 = 0u; num2 < num; num2++)
				{
					struct7_0[num2].method_0();
				}
			}
		}

		public void method_1()
		{
			uint num = (uint)(1 << int_1 + int_0);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				struct7_0[num2].method_1();
			}
		}

		public Struct7 method_2(uint uint_1, byte byte_0)
		{
			return struct7_0[(int)((uint_1 & uint_0) << int_1) + (byte_0 >> 8 - int_1)];
		}
	}

	internal class Class60
	{
		public uint uint_0;

		public uint uint_1;

		public uint uint_2;

		public uint uint_3;

		public uint uint_4;

		public uint uint_5;

		public uint uint_6;

		public uint uint_7;

		public bool bool_0;

		public bool bool_1;

		public uint uint_8;

		public Class52.Struct5 struct5_0;

		public void method_0()
		{
			uint_0 = uint.MaxValue;
			bool_0 = false;
		}

		public void method_1()
		{
			uint_0 = 0u;
			bool_0 = false;
		}

		public bool method_2()
		{
			return uint_0 == 0;
		}
	}

	private const int int_0 = 22;

	private const uint uint_0 = 268435455u;

	private const uint uint_1 = 32u;

	private const uint uint_2 = 16u;

	private const uint uint_3 = 4096u;

	private const int int_1 = 5;

	private static readonly byte[] byte_0;

	private static readonly string[] string_0;

	private readonly uint[] uint_4 = new uint[16];

	private readonly uint[] uint_5 = new uint[512];

	private readonly Struct8[] struct8_0 = new Struct8[192];

	private readonly Struct8[] struct8_1 = new Struct8[12];

	private readonly Struct8[] struct8_2 = new Struct8[192];

	private readonly Struct8[] struct8_3 = new Struct8[12];

	private readonly Struct8[] struct8_4 = new Struct8[12];

	private readonly Struct8[] struct8_5 = new Struct8[12];

	private readonly Class58 class58_0 = new Class58();

	private readonly Class59 class59_0 = new Class59();

	private readonly uint[] uint_6 = new uint[548];

	private readonly Class60[] class60_0 = new Class60[4096];

	private readonly Struct8[] struct8_6 = new Struct8[114];

	private readonly Struct10[] struct10_0 = new Struct10[4];

	private readonly uint[] uint_7 = new uint[256];

	private readonly Class63 class63_0 = new Class63();

	private readonly uint[] uint_8 = new uint[4];

	private readonly Class58 class58_1 = new Class58();

	private readonly byte[] byte_1 = new byte[5];

	private readonly uint[] uint_9 = new uint[4];

	private readonly uint[] uint_10 = new uint[4];

	private readonly uint[] uint_11 = new uint[128];

	private uint uint_12;

	private uint uint_13;

	private uint uint_14 = 4194304u;

	private uint uint_15 = uint.MaxValue;

	private uint uint_16 = 44u;

	private bool bool_0;

	private Stream stream_0;

	private uint uint_17;

	private bool bool_1;

	private Interface6 interface6_0;

	private Enum3 enum3_0 = Enum3.const_1;

	private uint uint_18;

	private bool bool_2;

	private uint uint_19;

	private uint uint_20 = 32u;

	private uint uint_21 = uint.MaxValue;

	private int int_2 = 3;

	private int int_3;

	private uint uint_22;

	private uint uint_23;

	private Struct10 struct10_1 = new Struct10(4);

	private int int_4 = 2;

	private uint uint_24 = 3u;

	private byte byte_2;

	private Class52.Struct5 struct5_0;

	private bool bool_3;

	private long long_0;

	static Class56()
	{
		byte_0 = new byte[2048];
		string_0 = new string[2] { "BT2", "BT4" };
		int num = 2;
		byte_0[0] = 0;
		byte_0[1] = 1;
		for (byte b = 2; b < 22; b = (byte)(b + 1))
		{
			uint num2 = (uint)(1 << (b >> 1) - 1);
			uint num3 = 0u;
			while (num3 < num2)
			{
				byte_0[num] = b;
				num3++;
				num++;
			}
		}
	}

	public Class56()
	{
		for (int i = 0; i < 4096L; i++)
		{
			class60_0[i] = new Class60();
		}
		for (int j = 0; j < 4L; j++)
		{
			struct10_0[j] = new Struct10(6);
		}
	}

	public void imethod_0(Stream stream_1, Stream stream_2, long long_1, long long_2, Interface0 interface0_0)
	{
		bool_2 = false;
		try
		{
			method_20(stream_1, stream_2, long_1, long_2);
			while (true)
			{
				method_15(out var long_3, out var long_4, out var bool_);
				if (!bool_)
				{
					interface0_0?.imethod_0(long_3, long_4);
					continue;
				}
				break;
			}
		}
		finally
		{
			method_19();
		}
	}

	public void imethod_1(Enum2[] enum2_0, object[] object_0)
	{
		uint num = 0u;
		uint num2 = default(uint);
		Enum3 @enum = default(Enum3);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
		while ((ulong)num < (ulong)object_0.Length)
		{
			while (true)
			{
				object obj = object_0[num];
				while (true)
				{
					switch (enum2_0[num])
					{
					case Enum2.const_1:
						goto IL_0186;
					case Enum2.const_5:
						goto IL_01fd;
					case Enum2.const_6:
						goto IL_0249;
					case Enum2.const_7:
						goto IL_0282;
					case Enum2.const_8:
						goto IL_02bb;
					case Enum2.const_9:
						goto IL_02f1;
					case Enum2.const_14:
						goto IL_0348;
					case Enum2.const_12:
						goto IL_035c;
					case Enum2.const_2:
					case Enum2.const_3:
					case Enum2.const_4:
					case Enum2.const_10:
					case Enum2.const_11:
					case Enum2.const_13:
						goto IL_03b5;
					}
					int num3 = ((int)num2 * -1250379684) ^ 0x69D63FDC;
					while (true)
					{
						switch ((num2 = (uint)num3 ^ 0x30E5705Fu) % 63u)
						{
						case 39u:
							num3 = ((int)num2 * -1499313207) ^ -282887687;
							continue;
						default:
							return;
						case 59u:
							break;
						case 33u:
						case 51u:
							goto end_IL_0137;
						case 9u:
							goto IL_0186;
						case 52u:
							goto IL_0191;
						case 45u:
							goto IL_01a8;
						case 35u:
							goto IL_01b8;
						case 28u:
							goto IL_01bf;
						case 41u:
							goto IL_01c4;
						case 49u:
							goto IL_01da;
						case 3u:
						case 13u:
							goto IL_01e0;
						case 31u:
							goto IL_01ee;
						case 55u:
							goto IL_01fd;
						case 29u:
							goto IL_0208;
						case 43u:
							goto IL_0210;
						case 17u:
							goto IL_0218;
						case 27u:
							goto IL_0229;
						case 38u:
							goto IL_0231;
						case 12u:
							goto IL_0249;
						case 61u:
							goto IL_0254;
						case 16u:
							goto IL_0264;
						case 18u:
							goto IL_0275;
						case 47u:
							goto IL_0282;
						case 36u:
							goto IL_028d;
						case 21u:
							goto IL_029d;
						case 57u:
							goto IL_02ae;
						case 10u:
							goto IL_02bb;
						case 22u:
							goto IL_02c6;
						case 1u:
							goto IL_02ce;
						case 32u:
							goto IL_02d6;
						case 46u:
							goto IL_02e7;
						case 15u:
							goto IL_02f1;
						case 6u:
							goto IL_02fc;
						case 58u:
							goto IL_0304;
						case 14u:
							goto IL_031e;
						case 4u:
							goto IL_0326;
						case 30u:
							goto IL_032e;
						case 48u:
							goto IL_0338;
						case 50u:
							goto IL_033f;
						case 60u:
							goto IL_0348;
						case 54u:
							goto IL_0350;
						case 8u:
						case 11u:
						case 20u:
							goto IL_035c;
						case 2u:
						case 56u:
							goto end_IL_0180;
						case 19u:
							goto IL_036d;
						case 5u:
							goto IL_0373;
						case 42u:
							goto IL_0379;
						case 40u:
							goto IL_037f;
						case 23u:
							goto IL_0385;
						case 37u:
							goto IL_038b;
						case 7u:
							goto IL_0391;
						case 24u:
							goto IL_0397;
						case 44u:
							goto IL_039d;
						case 0u:
							goto IL_03a3;
						case 53u:
							goto IL_03a9;
						case 34u:
							goto IL_03af;
						case 25u:
							goto IL_03b5;
						case 62u:
							goto IL_03bb;
						case 26u:
							return;
						}
						break;
					}
					continue;
					IL_036d:
					throw new Exception1();
					IL_0373:
					throw new Exception1();
					IL_03b5:
					throw new Exception1();
					IL_0348:
					if (obj is bool)
					{
						goto IL_0350;
					}
					goto IL_03bb;
					IL_0350:
					method_2((bool)obj);
					goto IL_035c;
					IL_03bb:
					throw new Exception1();
					IL_02f1:
					if (obj is string)
					{
						goto IL_02fc;
					}
					goto IL_03af;
					IL_02fc:
					@enum = enum3_0;
					goto IL_0304;
					IL_0304:
					num4 = smethod_2(((string)obj).ToUpper());
					if (num4 >= 0)
					{
						goto IL_031e;
					}
					goto IL_03a9;
					IL_031e:
					enum3_0 = (Enum3)num4;
					goto IL_0326;
					IL_0326:
					if (interface6_0 != null)
					{
						goto IL_032e;
					}
					goto IL_035c;
					IL_032e:
					if (@enum != enum3_0)
					{
						goto IL_0338;
					}
					goto IL_035c;
					IL_0338:
					uint_15 = uint.MaxValue;
					goto IL_033f;
					IL_033f:
					interface6_0 = null;
					goto IL_035c;
					IL_03a9:
					throw new Exception1();
					IL_03af:
					throw new Exception1();
					IL_02bb:
					if (obj is int)
					{
						goto IL_02c6;
					}
					goto IL_03a3;
					IL_02c6:
					num5 = (int)obj;
					goto IL_02ce;
					IL_02ce:
					if (num5 >= 5)
					{
						goto IL_02d6;
					}
					goto IL_039d;
					IL_02d6:
					if (num5 <= 273L)
					{
						goto IL_02e7;
					}
					goto IL_039d;
					IL_02e7:
					uint_20 = (uint)num5;
					goto IL_035c;
					IL_039d:
					throw new Exception1();
					IL_03a3:
					throw new Exception1();
					IL_0282:
					if (obj is int)
					{
						goto IL_028d;
					}
					goto IL_0397;
					IL_028d:
					num6 = (int)obj;
					if (num6 >= 0)
					{
						goto IL_029d;
					}
					goto IL_0391;
					IL_029d:
					if (num6 <= 4L)
					{
						goto IL_02ae;
					}
					goto IL_0391;
					IL_02ae:
					int_3 = num6;
					goto IL_035c;
					IL_0391:
					throw new Exception1();
					IL_0397:
					throw new Exception1();
					IL_0249:
					if (obj is int)
					{
						goto IL_0254;
					}
					goto IL_038b;
					IL_0254:
					num7 = (int)obj;
					if (num7 >= 0)
					{
						goto IL_0264;
					}
					goto IL_0385;
					IL_0264:
					if (num7 <= 8L)
					{
						goto IL_0275;
					}
					goto IL_0385;
					IL_0275:
					int_2 = num7;
					goto IL_035c;
					IL_0385:
					throw new Exception1();
					IL_038b:
					throw new Exception1();
					IL_01fd:
					if (obj is int)
					{
						goto IL_0208;
					}
					goto IL_037f;
					IL_0208:
					num8 = (int)obj;
					goto IL_0210;
					IL_0210:
					if (num8 >= 0)
					{
						goto IL_0218;
					}
					goto IL_0379;
					IL_0218:
					if (num8 <= 4L)
					{
						goto IL_0229;
					}
					goto IL_0379;
					IL_0229:
					int_4 = num8;
					goto IL_0231;
					IL_0231:
					uint_24 = (uint)((1 << int_4) - 1);
					goto IL_035c;
					IL_0379:
					throw new Exception1();
					IL_037f:
					throw new Exception1();
					IL_0186:
					if (obj is int)
					{
						goto IL_0191;
					}
					goto IL_0373;
					IL_0191:
					num9 = (int)obj;
					if (num9 >= 1L)
					{
						goto IL_01a8;
					}
					goto IL_036d;
					IL_01a8:
					if (num9 <= 1073741824L)
					{
						goto IL_01b8;
					}
					goto IL_036d;
					IL_01b8:
					uint_14 = (uint)num9;
					goto IL_01bf;
					IL_01bf:
					num10 = 0;
					goto IL_01e0;
					IL_01e0:
					if (num10 < 30L)
					{
						goto IL_01c4;
					}
					goto IL_01ee;
					IL_01c4:
					if (num9 > 1L << (num10 & 0x1F))
					{
						goto IL_01da;
					}
					goto IL_01ee;
					IL_01da:
					num10++;
					goto IL_01e0;
					IL_01ee:
					uint_16 = (uint)(num10 * 2);
					goto IL_035c;
					IL_035c:
					num++;
					goto end_IL_0180;
					continue;
					end_IL_0137:
					break;
				}
				continue;
				end_IL_0180:
				break;
			}
		}
	}

	public void imethod_2(Stream stream_1)
	{
		byte_1[0] = (byte)((int_4 * 5 + int_3) * 9 + int_2);
		for (int i = 0; i < 4; i++)
		{
			byte_1[1 + i] = (byte)(uint_14 >> 8 * i);
		}
		stream_1.Write(byte_1, 0, 5);
	}

	private static uint smethod_0(uint uint_25)
	{
		if (uint_25 < 2048)
		{
			return byte_0[uint_25];
		}
		if (uint_25 < 2097152)
		{
			return (uint)(byte_0[uint_25 >> 10] + 20);
		}
		return (uint)(byte_0[uint_25 >> 20] + 40);
	}

	private static uint smethod_1(uint uint_25)
	{
		if (uint_25 < 131072)
		{
			return (uint)(byte_0[uint_25 >> 6] + 12);
		}
		if (uint_25 < 134217728)
		{
			return (uint)(byte_0[uint_25 >> 16] + 32);
		}
		return (uint)(byte_0[uint_25 >> 26] + 52);
	}

	private void method_0()
	{
		struct5_0.method_0();
		byte_2 = 0;
		for (uint num = 0u; num < 4; num++)
		{
			uint_8[num] = 0u;
		}
	}

	private void method_1()
	{
		if (interface6_0 == null)
		{
			Class51 @class = new Class51();
			int num = 4;
			if (enum3_0 == Enum3.const_0)
			{
				num = 2;
			}
			@class.method_11(num);
			interface6_0 = @class;
		}
		class59_0.method_0(int_3, int_2);
		if (uint_14 != uint_15 || uint_21 != uint_20)
		{
			interface6_0.imethod_6(uint_14, 4096u, uint_20, 274u);
			uint_15 = uint_14;
			uint_21 = uint_20;
		}
	}

	private void method_2(bool bool_4)
	{
		bool_3 = bool_4;
	}

	private void method_3()
	{
		method_0();
		class63_0.method_2();
		for (uint num = 0u; num < 12; num++)
		{
			for (uint num2 = 0u; num2 <= uint_24; num2++)
			{
				uint num3 = (num << 4) + num2;
				struct8_0[num3].method_0();
				struct8_2[num3].method_0();
			}
			struct8_1[num].method_0();
			struct8_3[num].method_0();
			struct8_4[num].method_0();
			struct8_5[num].method_0();
		}
		class59_0.method_1();
		for (uint num4 = 0u; num4 < 4; num4++)
		{
			struct10_0[num4].method_0();
		}
		for (uint num5 = 0u; num5 < 114; num5++)
		{
			struct8_6[num5].method_0();
		}
		class58_0.method_0((uint)(1 << int_4));
		class58_1.method_0((uint)(1 << int_4));
		struct10_1.method_0();
		bool_1 = false;
		uint_23 = 0u;
		uint_22 = 0u;
		uint_12 = 0u;
	}

	private void method_4(out uint uint_25, out uint uint_26)
	{
		uint_25 = 0u;
		uint_26 = interface6_0.imethod_7(uint_6);
		if (uint_26 != 0)
		{
			uint_25 = uint_6[uint_26 - 2];
			if (uint_25 == uint_20)
			{
				uint_25 += interface6_0.imethod_4((int)(uint_25 - 1), uint_6[uint_26 - 1], 273 - uint_25);
			}
		}
		uint_12++;
	}

	private void method_5(uint uint_25)
	{
		if (uint_25 != 0)
		{
			interface6_0.imethod_8(uint_25);
			uint_12 += uint_25;
		}
	}

	private uint method_6(Class52.Struct5 struct5_1, uint uint_25)
	{
		return struct8_3[struct5_1.uint_0].method_4() + struct8_2[(struct5_1.uint_0 << 4) + uint_25].method_4();
	}

	private uint method_7(uint uint_25, Class52.Struct5 struct5_1, uint uint_26)
	{
		uint num;
		if (uint_25 == 0)
		{
			num = struct8_3[struct5_1.uint_0].method_4();
			return num + struct8_2[(struct5_1.uint_0 << 4) + uint_26].method_5();
		}
		num = struct8_3[struct5_1.uint_0].method_5();
		if (uint_25 == 1)
		{
			return num + struct8_4[struct5_1.uint_0].method_4();
		}
		num += struct8_4[struct5_1.uint_0].method_5();
		return num + struct8_5[struct5_1.uint_0].method_3(uint_25 - 2);
	}

	private uint method_8(uint uint_25, uint uint_26, Class52.Struct5 struct5_1, uint uint_27)
	{
		return class58_1.method_4(uint_26 - 2, uint_27) + method_7(uint_25, struct5_1, uint_27);
	}

	private uint method_9(uint uint_25, uint uint_26, uint uint_27)
	{
		uint num = Class52.smethod_0(uint_26);
		uint num2 = ((uint_25 >= 128) ? (uint_7[(num << 6) + smethod_1(uint_25)] + uint_4[uint_25 & 0xF]) : uint_5[num * 128 + uint_25]);
		return num2 + class58_0.method_4(uint_26 - 2, uint_27);
	}

	private uint method_10(out uint uint_25, uint uint_26)
	{
		uint_23 = uint_26;
		uint num = class60_0[uint_26].uint_6;
		uint num2 = class60_0[uint_26].uint_0;
		do
		{
			if (class60_0[uint_26].bool_0)
			{
				class60_0[num].method_0();
				class60_0[num].uint_6 = num - 1;
				if (class60_0[uint_26].bool_1)
				{
					class60_0[num - 1].bool_0 = false;
					class60_0[num - 1].uint_6 = class60_0[uint_26].uint_7;
					class60_0[num - 1].uint_0 = class60_0[uint_26].uint_1;
				}
			}
			uint num3 = num;
			uint num4 = num2;
			num2 = class60_0[num3].uint_0;
			num = class60_0[num3].uint_6;
			class60_0[num3].uint_0 = num4;
			class60_0[num3].uint_6 = uint_26;
			uint_26 = num3;
		}
		while (uint_26 != 0);
		uint_25 = class60_0[0].uint_0;
		uint_22 = class60_0[0].uint_6;
		return uint_22;
	}

	private uint method_11(uint uint_25, out uint uint_26)
	{
		if (uint_23 != uint_22)
		{
			uint result = class60_0[uint_22].uint_6 - uint_22;
			uint_26 = class60_0[uint_22].uint_0;
			uint_22 = class60_0[uint_22].uint_6;
			return result;
		}
		uint_23 = 0u;
		uint_22 = 0u;
		uint uint_27;
		uint uint_28;
		if (!bool_1)
		{
			method_4(out uint_27, out uint_28);
		}
		else
		{
			uint_27 = uint_17;
			uint_28 = uint_19;
			bool_1 = false;
		}
		uint num = interface6_0.imethod_5() + 1;
		if (num >= 2)
		{
			uint num2 = 0u;
			for (uint num3 = 0u; num3 < 4; num3++)
			{
				uint_10[num3] = uint_8[num3];
				uint_9[num3] = interface6_0.imethod_4(-1, uint_10[num3], 273u);
				if (uint_9[num3] > uint_9[num2])
				{
					num2 = num3;
				}
			}
			if (uint_9[num2] >= uint_20)
			{
				uint_26 = num2;
				uint num4 = uint_9[num2];
				method_5(num4 - 1);
				return num4;
			}
			if (uint_27 >= uint_20)
			{
				uint_26 = uint_6[uint_28 - 1] + 4;
				method_5(uint_27 - 1);
				return uint_27;
			}
			byte b = interface6_0.imethod_3(-1);
			byte b2 = interface6_0.imethod_3((int)(0 - uint_8[0] - 1 - 1));
			if (uint_27 < 2 && b != b2 && uint_9[num2] < 2)
			{
				uint_26 = uint.MaxValue;
				return 1u;
			}
			class60_0[0].struct5_0 = struct5_0;
			uint num5 = uint_25 & uint_24;
			class60_0[1].uint_8 = struct8_0[(struct5_0.uint_0 << 4) + num5].method_4() + class59_0.method_2(uint_25, byte_2).method_4(!struct5_0.method_5(), b2, b);
			class60_0[1].method_0();
			uint num6 = struct8_0[(struct5_0.uint_0 << 4) + num5].method_5();
			uint num7 = num6 + struct8_1[struct5_0.uint_0].method_5();
			if (b2 == b)
			{
				uint num8 = num7 + method_6(struct5_0, num5);
				if (num8 < class60_0[1].uint_8)
				{
					class60_0[1].uint_8 = num8;
					class60_0[1].method_1();
				}
			}
			uint num9 = ((uint_27 >= uint_9[num2]) ? uint_27 : uint_9[num2]);
			if (num9 >= 2)
			{
				class60_0[1].uint_6 = 0u;
				class60_0[0].uint_2 = uint_10[0];
				class60_0[0].uint_3 = uint_10[1];
				class60_0[0].uint_4 = uint_10[2];
				class60_0[0].uint_5 = uint_10[3];
				uint num10 = num9;
				do
				{
					class60_0[num10--].uint_8 = 268435455u;
				}
				while (num10 >= 2);
				for (uint num11 = 0u; num11 < 4; num11++)
				{
					uint num12 = uint_9[num11];
					if (num12 < 2)
					{
						continue;
					}
					uint num13 = num7 + method_7(num11, struct5_0, num5);
					do
					{
						uint num14 = num13 + class58_1.method_4(num12 - 2, num5);
						Class60 @class = class60_0[num12];
						if (num14 < @class.uint_8)
						{
							@class.uint_8 = num14;
							@class.uint_6 = 0u;
							@class.uint_0 = num11;
							@class.bool_0 = false;
						}
					}
					while (--num12 >= 2);
				}
				uint num15 = num6 + struct8_1[struct5_0.uint_0].method_4();
				num10 = ((uint_9[0] >= 2) ? (uint_9[0] + 1) : 2u);
				if (num10 <= uint_27)
				{
					uint num16;
					for (num16 = 0u; num10 > uint_6[num16]; num16 += 2)
					{
					}
					while (true)
					{
						uint num17 = uint_6[num16 + 1];
						uint num18 = num15 + method_9(num17, num10, num5);
						Class60 class2 = class60_0[num10];
						if (num18 < class2.uint_8)
						{
							class2.uint_8 = num18;
							class2.uint_6 = 0u;
							class2.uint_0 = num17 + 4;
							class2.bool_0 = false;
						}
						if (num10 == uint_6[num16])
						{
							num16 += 2;
							if (num16 == uint_28)
							{
								break;
							}
						}
						num10++;
					}
				}
				uint num19 = 0u;
				while (true)
				{
					num19++;
					if (num19 == num9)
					{
						break;
					}
					method_4(out var uint_29, out uint_28);
					if (uint_29 < uint_20)
					{
						uint_25++;
						uint num20 = class60_0[num19].uint_6;
						Class52.Struct5 @struct;
						if (class60_0[num19].bool_0)
						{
							num20--;
							if (class60_0[num19].bool_1)
							{
								@struct = class60_0[class60_0[num19].uint_7].struct5_0;
								if (class60_0[num19].uint_1 >= 4)
								{
									@struct.method_2();
								}
								else
								{
									@struct.method_3();
								}
							}
							else
							{
								@struct = class60_0[num20].struct5_0;
							}
							@struct.method_1();
						}
						else
						{
							@struct = class60_0[num20].struct5_0;
						}
						if (num20 != num19 - 1)
						{
							uint num21;
							if (class60_0[num19].bool_0 && class60_0[num19].bool_1)
							{
								num20 = class60_0[num19].uint_7;
								num21 = class60_0[num19].uint_1;
								@struct.method_3();
							}
							else
							{
								num21 = class60_0[num19].uint_0;
								if (num21 < 4)
								{
									@struct.method_3();
								}
								else
								{
									@struct.method_2();
								}
							}
							Class60 class3 = class60_0[num20];
							switch (num21)
							{
							case 1u:
								uint_10[0] = class3.uint_3;
								uint_10[1] = class3.uint_2;
								uint_10[2] = class3.uint_4;
								uint_10[3] = class3.uint_5;
								break;
							case 2u:
								uint_10[0] = class3.uint_4;
								uint_10[1] = class3.uint_2;
								uint_10[2] = class3.uint_3;
								uint_10[3] = class3.uint_5;
								break;
							case 3u:
								uint_10[0] = class3.uint_5;
								uint_10[1] = class3.uint_2;
								uint_10[2] = class3.uint_3;
								uint_10[3] = class3.uint_4;
								break;
							case 0u:
								uint_10[0] = class3.uint_2;
								uint_10[1] = class3.uint_3;
								uint_10[2] = class3.uint_4;
								uint_10[3] = class3.uint_5;
								break;
							default:
								uint_10[0] = num21 - 4;
								uint_10[1] = class3.uint_2;
								uint_10[2] = class3.uint_3;
								uint_10[3] = class3.uint_4;
								break;
							}
						}
						else if (class60_0[num19].method_2())
						{
							@struct.method_4();
						}
						else
						{
							@struct.method_1();
						}
						class60_0[num19].struct5_0 = @struct;
						class60_0[num19].uint_2 = uint_10[0];
						class60_0[num19].uint_3 = uint_10[1];
						class60_0[num19].uint_4 = uint_10[2];
						class60_0[num19].uint_5 = uint_10[3];
						uint num22 = class60_0[num19].uint_8;
						b = interface6_0.imethod_3(-1);
						b2 = interface6_0.imethod_3((int)(0 - uint_10[0] - 1 - 1));
						num5 = uint_25 & uint_24;
						uint num23 = num22 + struct8_0[(@struct.uint_0 << 4) + num5].method_4() + class59_0.method_2(uint_25, interface6_0.imethod_3(-2)).method_4(!@struct.method_5(), b2, b);
						Class60 class4 = class60_0[num19 + 1];
						bool flag = false;
						if (num23 < class4.uint_8)
						{
							class4.uint_8 = num23;
							class4.uint_6 = num19;
							class4.method_0();
							flag = true;
						}
						num6 = num22 + struct8_0[(@struct.uint_0 << 4) + num5].method_5();
						num7 = num6 + struct8_1[@struct.uint_0].method_5();
						if (b2 == b && (class4.uint_6 >= num19 || class4.uint_0 != 0))
						{
							uint num24 = num7 + method_6(@struct, num5);
							if (num24 <= class4.uint_8)
							{
								class4.uint_8 = num24;
								class4.uint_6 = num19;
								class4.method_1();
								flag = true;
							}
						}
						uint val = interface6_0.imethod_5() + 1;
						val = Math.Min(4095 - num19, val);
						num = val;
						if (num < 2)
						{
							continue;
						}
						if (num > uint_20)
						{
							num = uint_20;
						}
						if (!flag && b2 != b)
						{
							uint num25 = Math.Min(val - 1, uint_20);
							uint num26 = interface6_0.imethod_4(0, uint_10[0], num25);
							if (num26 >= 2)
							{
								Class52.Struct5 struct5_ = @struct;
								struct5_.method_1();
								uint num27 = (uint_25 + 1) & uint_24;
								uint num28 = num23 + struct8_0[(struct5_.uint_0 << 4) + num27].method_5() + struct8_1[struct5_.uint_0].method_5();
								uint num29 = num19 + 1 + num26;
								while (num9 < num29)
								{
									class60_0[++num9].uint_8 = 268435455u;
								}
								uint num30 = num28 + method_8(0u, num26, struct5_, num27);
								Class60 class5 = class60_0[num29];
								if (num30 < class5.uint_8)
								{
									class5.uint_8 = num30;
									class5.uint_6 = num19 + 1;
									class5.uint_0 = 0u;
									class5.bool_0 = true;
									class5.bool_1 = false;
								}
							}
						}
						uint num31 = 2u;
						for (uint num32 = 0u; num32 < 4; num32++)
						{
							uint num33 = interface6_0.imethod_4(-1, uint_10[num32], num);
							if (num33 < 2)
							{
								continue;
							}
							uint num34 = num33;
							while (true)
							{
								if (num9 >= num19 + num33)
								{
									uint num35 = num7 + method_8(num32, num33, @struct, num5);
									Class60 class6 = class60_0[num19 + num33];
									if (num35 < class6.uint_8)
									{
										class6.uint_8 = num35;
										class6.uint_6 = num19;
										class6.uint_0 = num32;
										class6.bool_0 = false;
									}
									if (--num33 < 2)
									{
										break;
									}
								}
								else
								{
									class60_0[++num9].uint_8 = 268435455u;
								}
							}
							num33 = num34;
							if (num32 == 0)
							{
								num31 = num33 + 1;
							}
							if (num33 >= val)
							{
								continue;
							}
							uint num36 = Math.Min(val - 1 - num33, uint_20);
							uint num37 = interface6_0.imethod_4((int)num33, uint_10[num32], num36);
							if (num37 >= 2)
							{
								Class52.Struct5 struct5_2 = @struct;
								struct5_2.method_3();
								uint num38 = (uint_25 + num33) & uint_24;
								uint num39 = num7 + method_8(num32, num33, @struct, num5) + struct8_0[(struct5_2.uint_0 << 4) + num38].method_4() + class59_0.method_2(uint_25 + num33, interface6_0.imethod_3((int)(num33 - 1 - 1))).method_4(bool_0: true, interface6_0.imethod_3((int)(num33 - 1 - (uint_10[num32] + 1))), interface6_0.imethod_3((int)(num33 - 1)));
								struct5_2.method_1();
								num38 = (uint_25 + num33 + 1) & uint_24;
								uint num40 = num39 + struct8_0[(struct5_2.uint_0 << 4) + num38].method_5() + struct8_1[struct5_2.uint_0].method_5();
								uint num41 = num33 + 1 + num37;
								while (num9 < num19 + num41)
								{
									class60_0[++num9].uint_8 = 268435455u;
								}
								uint num42 = num40 + method_8(0u, num37, struct5_2, num38);
								Class60 class7 = class60_0[num19 + num41];
								if (num42 < class7.uint_8)
								{
									class7.uint_8 = num42;
									class7.uint_6 = num19 + num33 + 1;
									class7.uint_0 = 0u;
									class7.bool_0 = true;
									class7.bool_1 = true;
									class7.uint_7 = num19;
									class7.uint_1 = num32;
								}
							}
						}
						if (uint_29 > num)
						{
							uint_29 = num;
							for (uint_28 = 0u; uint_29 > uint_6[uint_28]; uint_28 += 2)
							{
							}
							uint_6[uint_28] = uint_29;
							uint_28 += 2;
						}
						if (uint_29 < num31)
						{
							continue;
						}
						num15 = num6 + struct8_1[@struct.uint_0].method_4();
						while (num9 < num19 + uint_29)
						{
							class60_0[++num9].uint_8 = 268435455u;
						}
						uint num43;
						for (num43 = 0u; num31 > uint_6[num43]; num43 += 2)
						{
						}
						uint num44 = num31;
						while (true)
						{
							uint num45 = uint_6[num43 + 1];
							uint num46 = num15 + method_9(num45, num44, num5);
							Class60 class8 = class60_0[num19 + num44];
							if (num46 < class8.uint_8)
							{
								class8.uint_8 = num46;
								class8.uint_6 = num19;
								class8.uint_0 = num45 + 4;
								class8.bool_0 = false;
							}
							if (num44 == uint_6[num43])
							{
								if (num44 < val)
								{
									uint num47 = Math.Min(val - 1 - num44, uint_20);
									uint num48 = interface6_0.imethod_4((int)num44, num45, num47);
									if (num48 >= 2)
									{
										Class52.Struct5 struct5_3 = @struct;
										struct5_3.method_2();
										uint num49 = (uint_25 + num44) & uint_24;
										uint num50 = num46 + struct8_0[(struct5_3.uint_0 << 4) + num49].method_4() + class59_0.method_2(uint_25 + num44, interface6_0.imethod_3((int)(num44 - 1 - 1))).method_4(bool_0: true, interface6_0.imethod_3((int)(num44 - (num45 + 1) - 1)), interface6_0.imethod_3((int)(num44 - 1)));
										struct5_3.method_1();
										num49 = (uint_25 + num44 + 1) & uint_24;
										uint num51 = num50 + struct8_0[(struct5_3.uint_0 << 4) + num49].method_5() + struct8_1[struct5_3.uint_0].method_5();
										uint num52 = num44 + 1 + num48;
										while (num9 < num19 + num52)
										{
											class60_0[++num9].uint_8 = 268435455u;
										}
										num46 = num51 + method_8(0u, num48, struct5_3, num49);
										class8 = class60_0[num19 + num52];
										if (num46 < class8.uint_8)
										{
											class8.uint_8 = num46;
											class8.uint_6 = num19 + num44 + 1;
											class8.uint_0 = 0u;
											class8.bool_0 = true;
											class8.bool_1 = true;
											class8.uint_7 = num19;
											class8.uint_1 = num45 + 4;
										}
									}
								}
								num43 += 2;
								if (num43 == uint_28)
								{
									break;
								}
							}
							num44++;
						}
						continue;
					}
					uint_19 = uint_28;
					uint_17 = uint_29;
					bool_1 = true;
					return method_10(out uint_26, num19);
				}
				return method_10(out uint_26, num19);
			}
			uint_26 = class60_0[1].uint_0;
			return 1u;
		}
		uint_26 = uint.MaxValue;
		return 1u;
	}

	private bool method_12(uint uint_25, uint uint_26)
	{
		if (uint_25 < 33554432)
		{
			return uint_26 >= uint_25 << 7;
		}
		return false;
	}

	private void method_13(uint uint_25)
	{
		if (bool_3)
		{
			struct8_0[(struct5_0.uint_0 << 4) + uint_25].method_2(class63_0, 1u);
			struct8_1[struct5_0.uint_0].method_2(class63_0, 0u);
			struct5_0.method_2();
			class58_0.method_7(class63_0, 0u, uint_25);
			uint num = Class52.smethod_0(2u);
			struct10_0[num].method_1(class63_0, 63u);
			class63_0.method_8(67108863u, 26);
			struct10_1.method_2(class63_0, 15u);
		}
	}

	private void method_14(uint uint_25)
	{
		method_16();
		method_13(uint_25 & uint_24);
		class63_0.method_3();
		class63_0.method_4();
	}

	public void method_15(out long long_1, out long long_2, out bool bool_4)
	{
		long_1 = 0L;
		long_2 = 0L;
		bool_4 = true;
		if (stream_0 != null)
		{
			interface6_0.imethod_0(stream_0);
			interface6_0.imethod_1();
			bool_2 = true;
			stream_0 = null;
		}
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		long num = long_0;
		if (long_0 == 0L)
		{
			if (interface6_0.imethod_5() == 0)
			{
				method_14((uint)long_0);
				return;
			}
			method_4(out var _, out var _);
			uint num2 = (uint)(int)long_0 & uint_24;
			struct8_0[(struct5_0.uint_0 << 4) + num2].method_2(class63_0, 0u);
			struct5_0.method_1();
			byte b = interface6_0.imethod_3((int)(0 - uint_12));
			class59_0.method_2((uint)long_0, byte_2).method_2(class63_0, b);
			byte_2 = b;
			uint_12--;
			long_0++;
		}
		if (interface6_0.imethod_5() == 0)
		{
			method_14((uint)long_0);
			return;
		}
		while (true)
		{
			uint uint_3;
			uint num3 = method_11((uint)long_0, out uint_3);
			uint num4 = (uint)(int)long_0 & uint_24;
			uint num5 = (struct5_0.uint_0 << 4) + num4;
			if (num3 != 1 || uint_3 != uint.MaxValue)
			{
				struct8_0[num5].method_2(class63_0, 1u);
				if (uint_3 < 4)
				{
					struct8_1[struct5_0.uint_0].method_2(class63_0, 1u);
					if (uint_3 != 0)
					{
						struct8_3[struct5_0.uint_0].method_2(class63_0, 1u);
						if (uint_3 == 1)
						{
							struct8_4[struct5_0.uint_0].method_2(class63_0, 0u);
						}
						else
						{
							struct8_4[struct5_0.uint_0].method_2(class63_0, 1u);
							struct8_5[struct5_0.uint_0].method_2(class63_0, uint_3 - 2);
						}
					}
					else
					{
						struct8_3[struct5_0.uint_0].method_2(class63_0, 0u);
						if (num3 == 1)
						{
							struct8_2[num5].method_2(class63_0, 0u);
						}
						else
						{
							struct8_2[num5].method_2(class63_0, 1u);
						}
					}
					if (num3 != 1)
					{
						class58_1.method_7(class63_0, num3 - 2, num4);
						struct5_0.method_3();
					}
					else
					{
						struct5_0.method_4();
					}
					uint num6 = uint_8[uint_3];
					if (uint_3 != 0)
					{
						for (uint num7 = uint_3; num7 >= 1; num7--)
						{
							uint_8[num7] = uint_8[num7 - 1];
						}
						uint_8[0] = num6;
					}
				}
				else
				{
					struct8_1[struct5_0.uint_0].method_2(class63_0, 0u);
					struct5_0.method_2();
					class58_0.method_7(class63_0, num3 - 2, num4);
					uint_3 -= 4;
					uint num8 = smethod_0(uint_3);
					uint num9 = Class52.smethod_0(num3);
					struct10_0[num9].method_1(class63_0, num8);
					if (num8 >= 4)
					{
						int num10 = (int)((num8 >> 1) - 1);
						uint num11 = (2 | (num8 & 1)) << num10;
						uint num12 = uint_3 - num11;
						if (num8 >= 14)
						{
							class63_0.method_8(num12 >> 4, num10 - 4);
							struct10_1.method_2(class63_0, num12 & 0xFu);
							uint_13++;
						}
						else
						{
							Struct10.smethod_1(struct8_6, num11 - num8 - 1, class63_0, num10, num12);
						}
					}
					uint num13 = uint_3;
					for (uint num14 = 3u; num14 >= 1; num14--)
					{
						uint_8[num14] = uint_8[num14 - 1];
					}
					uint_8[0] = num13;
					uint_18++;
				}
				byte_2 = interface6_0.imethod_3((int)(num3 - 1 - uint_12));
			}
			else
			{
				struct8_0[num5].method_2(class63_0, 0u);
				byte b2 = interface6_0.imethod_3((int)(0 - uint_12));
				Class59.Struct7 @struct = class59_0.method_2((uint)long_0, byte_2);
				if (!struct5_0.method_5())
				{
					byte b3 = interface6_0.imethod_3((int)(0 - uint_8[0] - 1 - uint_12));
					@struct.method_3(class63_0, b3, b2);
				}
				else
				{
					@struct.method_2(class63_0, b2);
				}
				byte_2 = b2;
				struct5_0.method_1();
			}
			uint_12 -= num3;
			long_0 += num3;
			if (uint_12 == 0)
			{
				if (uint_18 >= 128)
				{
					method_21();
				}
				if (uint_13 >= 16)
				{
					method_22();
				}
				long_1 = long_0;
				long_2 = class63_0.method_10();
				if (interface6_0.imethod_5() == 0)
				{
					break;
				}
				if (long_0 - num >= 4096L)
				{
					bool_0 = false;
					bool_4 = false;
					return;
				}
			}
		}
		method_14((uint)long_0);
	}

	private void method_16()
	{
		if (interface6_0 != null && bool_2)
		{
			interface6_0.imethod_2();
			bool_2 = false;
		}
	}

	private void method_17(Stream stream_1)
	{
		class63_0.method_0(stream_1);
	}

	private void method_18()
	{
		class63_0.method_1();
	}

	private void method_19()
	{
		method_16();
		method_18();
	}

	private void method_20(Stream stream_1, Stream stream_2, long long_1, long long_2)
	{
		stream_0 = stream_1;
		bool_0 = false;
		method_1();
		method_17(stream_2);
		method_3();
		method_21();
		method_22();
		class58_0.method_3(uint_20 + 1 - 2);
		class58_0.method_6((uint)(1 << int_4));
		class58_1.method_3(uint_20 + 1 - 2);
		class58_1.method_6((uint)(1 << int_4));
		long_0 = 0L;
	}

	private void method_21()
	{
		for (uint num = 4u; num < 128; num++)
		{
			uint num2 = smethod_0(num);
			int num3 = (int)((num2 >> 1) - 1);
			uint num4 = (2 | (num2 & 1)) << num3;
			uint_11[num] = Struct10.smethod_0(struct8_6, num4 - num2 - 1, num3, num - num4);
		}
		for (uint num5 = 0u; num5 < 4; num5++)
		{
			Struct10 @struct = struct10_0[num5];
			uint num6 = num5 << 6;
			for (uint num7 = 0u; num7 < uint_16; num7++)
			{
				uint_7[num6 + num7] = @struct.method_3(num7);
			}
			for (uint num8 = 14u; num8 < uint_16; num8++)
			{
				uint_7[num6 + num8] += (num8 >> 1) - 1 - 4 << 6;
			}
			uint num9 = num5 * 128;
			uint num10;
			for (num10 = 0u; num10 < 4; num10++)
			{
				uint_5[num9 + num10] = uint_7[num6 + num10];
			}
			for (; num10 < 128; num10++)
			{
				uint_5[num9 + num10] = uint_7[num6 + smethod_0(num10)] + uint_11[num10];
			}
		}
		uint_18 = 0u;
	}

	private void method_22()
	{
		for (uint num = 0u; num < 16; num++)
		{
			uint_4[num] = struct10_1.method_4(num);
		}
		uint_13 = 0u;
	}

	private static int smethod_2(string string_1)
	{
		int num = 0;
		while (true)
		{
			if (num < string_0.Length)
			{
				if (string_1 == string_0[num])
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}
}
