using System;
using System.IO;
using DreamPoeBot.Structures.ns6;

namespace DreamPoeBot.Structures.ns4;

internal class Class53 : Interface1, Interface4
{
	private class Class54
	{
		private Struct9 struct9_0;

		private Struct9 struct9_1;

		private Struct11[] struct11_0 = new Struct11[16];

		private Struct11[] struct11_1 = new Struct11[16];

		private Struct11 struct11_2 = new Struct11(8);

		private uint uint_0;

		public void method_0(uint uint_1)
		{
			for (uint num = uint_0; num < uint_1; num++)
			{
				struct11_0[num] = new Struct11(3);
				struct11_1[num] = new Struct11(3);
			}
			uint_0 = uint_1;
		}

		public void method_1()
		{
			struct9_0.method_1();
			for (uint num = 0u; num < uint_0; num++)
			{
				struct11_0[num].method_0();
				struct11_1[num].method_0();
			}
			struct9_1.method_1();
			struct11_2.method_0();
		}

		public uint method_2(Class64 class64_0, uint uint_1)
		{
			if (struct9_0.method_2(class64_0) == 0)
			{
				return struct11_0[uint_1].method_1(class64_0);
			}
			uint num = 8u;
			if (struct9_1.method_2(class64_0) != 0)
			{
				num += 8;
				return num + struct11_2.method_1(class64_0);
			}
			return num + struct11_1[uint_1].method_1(class64_0);
		}
	}

	internal class Class55
	{
		private struct Struct6
		{
			private Struct9[] struct9_0;

			public void method_0()
			{
				struct9_0 = new Struct9[768];
			}

			public void method_1()
			{
				for (int i = 0; i < 768; i++)
				{
					struct9_0[i].method_1();
				}
			}

			public byte method_2(Class64 class64_0)
			{
				uint num = 1u;
				do
				{
					num = (num << 1) | struct9_0[num].method_2(class64_0);
				}
				while (num < 256);
				return (byte)num;
			}

			public byte method_3(Class64 class64_0, byte byte_0)
			{
				uint num = 1u;
				do
				{
					uint num2 = (uint)(byte_0 >> 7) & 1u;
					byte_0 = (byte)(byte_0 << 1);
					uint num3 = struct9_0[(1 + num2 << 8) + num].method_2(class64_0);
					num = (num << 1) | num3;
					if (num2 != num3)
					{
						while (num < 256)
						{
							num = (num << 1) | struct9_0[num].method_2(class64_0);
						}
						break;
					}
				}
				while (num < 256);
				return (byte)num;
			}
		}

		private Struct6[] struct6_0;

		private int int_0;

		private int int_1;

		private uint uint_0;

		public void method_0(int int_2, int int_3)
		{
			if (struct6_0 == null || int_0 != int_3 || int_1 != int_2)
			{
				int_1 = int_2;
				uint_0 = (uint)((1 << int_2) - 1);
				int_0 = int_3;
				uint num = (uint)(1 << int_0 + int_1);
				struct6_0 = new Struct6[num];
				for (uint num2 = 0u; num2 < num; num2++)
				{
					struct6_0[num2].method_0();
				}
			}
		}

		public void method_1()
		{
			uint num = (uint)(1 << int_0 + int_1);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				struct6_0[num2].method_1();
			}
		}

		private uint method_2(uint uint_1, byte byte_0)
		{
			return ((uint_1 & uint_0) << int_0) + (uint)(byte_0 >> 8 - int_0);
		}

		public byte method_3(Class64 class64_0, uint uint_1, byte byte_0)
		{
			return struct6_0[method_2(uint_1, byte_0)].method_2(class64_0);
		}

		public byte method_4(Class64 class64_0, uint uint_1, byte byte_0, byte byte_1)
		{
			return struct6_0[method_2(uint_1, byte_0)].method_3(class64_0, byte_1);
		}
	}

	private Class62 class62_0 = new Class62();

	private Class64 class64_0 = new Class64();

	private Struct9[] struct9_0 = new Struct9[192];

	private Struct9[] struct9_1 = new Struct9[12];

	private Struct9[] struct9_2 = new Struct9[12];

	private Struct9[] struct9_3 = new Struct9[12];

	private Struct9[] struct9_4 = new Struct9[12];

	private Struct9[] struct9_5 = new Struct9[192];

	private Struct11[] struct11_0 = new Struct11[4];

	private Struct9[] struct9_6 = new Struct9[114];

	private Struct11 struct11_1 = new Struct11(4);

	private Class54 class54_0 = new Class54();

	private Class54 class54_1 = new Class54();

	private Class55 class55_0 = new Class55();

	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	public Class53()
	{
		uint_0 = uint.MaxValue;
		for (int i = 0; i < 4L; i++)
		{
			struct11_0[i] = new Struct11(6);
		}
	}

	private void method_0(uint uint_3)
	{
		if (uint_0 != uint_3)
		{
			uint_0 = uint_3;
			uint_1 = Math.Max(uint_0, 1u);
			uint uint_4 = Math.Max(uint_1, 4096u);
			class62_0.method_0(uint_4);
		}
	}

	private void method_1(int int_0, int int_1)
	{
		if (int_0 > 8)
		{
			throw new Exception1();
		}
		if (int_1 > 8)
		{
			throw new Exception1();
		}
		class55_0.method_0(int_0, int_1);
	}

	private void method_2(int int_0)
	{
		if (int_0 > 4)
		{
			throw new Exception1();
		}
		uint num = (uint)(1 << int_0);
		class54_0.method_0(num);
		class54_1.method_0(num);
		uint_2 = num - 1;
	}

	private void method_3(Stream stream_0, Stream stream_1)
	{
		class64_0.method_0(stream_0);
		class62_0.method_2(stream_1);
		for (uint num = 0u; num < 12; num++)
		{
			for (uint num2 = 0u; num2 <= uint_2; num2++)
			{
				uint num3 = (num << 4) + num2;
				struct9_0[num3].method_1();
				struct9_5[num3].method_1();
			}
			struct9_1[num].method_1();
			struct9_2[num].method_1();
			struct9_3[num].method_1();
			struct9_4[num].method_1();
		}
		class55_0.method_1();
		for (uint num4 = 0u; num4 < 4; num4++)
		{
			struct11_0[num4].method_0();
		}
		for (uint num5 = 0u; num5 < 114; num5++)
		{
			struct9_6[num5].method_1();
		}
		class54_0.method_1();
		class54_1.method_1();
		struct11_1.method_0();
	}

	public void imethod_0(Stream stream_0, Stream stream_1, long long_0, long long_1, Interface0 interface0_0)
	{
		method_3(stream_0, stream_1);
		Class52.Struct5 @struct = default(Class52.Struct5);
		@struct.method_0();
		uint num = 0u;
		uint num2 = 0u;
		uint num3 = 0u;
		uint num4 = 0u;
		ulong num5 = 0uL;
		if (0L < long_1)
		{
			if (struct9_0[@struct.uint_0 << 4].method_2(class64_0) != 0)
			{
				throw new Exception0();
			}
			@struct.method_1();
			byte byte_ = class55_0.method_3(class64_0, 0u, 0);
			class62_0.method_6(byte_);
			num5++;
		}
		while (num5 < (ulong)long_1)
		{
			uint num6 = (uint)(int)num5 & uint_2;
			if (struct9_0[(@struct.uint_0 << 4) + num6].method_2(class64_0) != 0)
			{
				uint num8;
				if (struct9_1[@struct.uint_0].method_2(class64_0) == 1)
				{
					if (struct9_2[@struct.uint_0].method_2(class64_0) == 0)
					{
						if (struct9_5[(@struct.uint_0 << 4) + num6].method_2(class64_0) == 0)
						{
							@struct.method_4();
							class62_0.method_6(class62_0.method_7(num));
							num5++;
							continue;
						}
					}
					else
					{
						uint num7;
						if (struct9_3[@struct.uint_0].method_2(class64_0) == 0)
						{
							num7 = num2;
						}
						else
						{
							if (struct9_4[@struct.uint_0].method_2(class64_0) != 0)
							{
								num7 = num4;
								num4 = num3;
							}
							else
							{
								num7 = num3;
							}
							num3 = num2;
						}
						num2 = num;
						num = num7;
					}
					num8 = class54_1.method_2(class64_0, num6) + 2;
					@struct.method_3();
				}
				else
				{
					num4 = num3;
					num3 = num2;
					num2 = num;
					num8 = 2 + class54_0.method_2(class64_0, num6);
					@struct.method_2();
					uint num9 = struct11_0[Class52.smethod_0(num8)].method_1(class64_0);
					if (num9 < 4)
					{
						num = num9;
					}
					else
					{
						int num10 = (int)((num9 >> 1) - 1);
						num = (2 | (num9 & 1)) << num10;
						if (num9 < 14)
						{
							num += Struct11.smethod_0(struct9_6, num - num9 - 1, class64_0, num10);
						}
						else
						{
							num += class64_0.method_7(num10 - 4) << 4;
							num += struct11_1.method_2(class64_0);
						}
					}
				}
				if (num >= num5 || num >= uint_1)
				{
					if (num == uint.MaxValue)
					{
						class62_0.method_4();
						class62_0.method_3();
						class64_0.method_1();
						return;
					}
					throw new Exception0();
				}
				class62_0.method_5(num, num8);
				num5 += num8;
			}
			else
			{
				byte byte_2 = class62_0.method_7(0u);
				byte byte_3 = (@struct.method_5() ? class55_0.method_3(class64_0, (uint)num5, byte_2) : class55_0.method_4(class64_0, (uint)num5, byte_2, class62_0.method_7(num)));
				class62_0.method_6(byte_3);
				@struct.method_1();
				num5++;
			}
		}
		class62_0.method_4();
		class62_0.method_3();
		class64_0.method_1();
	}

	public void imethod_1(byte[] byte_0)
	{
		if (byte_0.Length < 5)
		{
			throw new Exception1();
		}
		int int_ = (int)byte_0[0] % 9;
		byte b = (byte)((int)byte_0[0] / 9);
		int int_2 = (int)b % 5;
		int num = (int)b / 5;
		if (num <= 4)
		{
			uint num2 = 0u;
			for (int i = 0; i < 4; i++)
			{
				num2 += (uint)(byte_0[1 + i] << i * 8);
			}
			method_0(num2);
			method_1(int_2, int_);
			method_2(num);
			return;
		}
		throw new Exception1();
	}
}
