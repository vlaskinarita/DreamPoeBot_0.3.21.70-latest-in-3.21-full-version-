using System;
using System.Collections.Generic;
using System.IO;

namespace DreamPoeBot.Structures.ns16;

internal class Class266
{
	internal class Class267
	{
		private const uint uint_0 = 1540483477u;

		private const int int_0 = 24;

		public unsafe static uint smethod_0(byte[] byte_0, uint uint_1 = 3314489979u)
		{
			//The blocks IL_0121, IL_012b, IL_0131, IL_0134, IL_0175, IL_017c are reachable both inside and outside the pinned region starting at IL_011d. ILSpy has duplicated these blocks in order to place them both within and outside the `fixed` statement.
			int num = byte_0.Length;
			if (num != 0)
			{
				uint num2 = uint_1 ^ (uint)num;
				int num3 = num & 3;
				int num4 = num >> 2;
				uint num5 = default(uint);
				uint num7 = default(uint);
				while (true)
				{
					fixed (byte* ptr = &byte_0[0])
					{
						while (true)
						{
							IL_0109:
							uint* ptr2 = (uint*)ptr;
							while (true)
							{
								IL_0101:
								if (num4 == 0)
								{
									while (true)
									{
										IL_00e8:
										switch (num3)
										{
										case 1:
											goto IL_0136;
										case 2:
											goto IL_0146;
										case 3:
											goto IL_0157;
										}
										int num6 = (int)((num5 * 1496298113) ^ 0x56FB43FE);
										while (true)
										{
											switch ((num5 = (uint)num6 ^ 0x92910BFEu) % 27u)
											{
											case 13u:
												break;
											case 0u:
												goto IL_0009;
											case 22u:
												goto IL_000e;
											case 25u:
												goto IL_0022;
											case 18u:
												goto IL_002c;
											case 16u:
												goto IL_003d;
											case 2u:
												num6 = ((int)num5 * -671081732) ^ 0x7F56AF9B;
												continue;
											case 3u:
												goto IL_00e8;
											case 7u:
											case 9u:
												goto IL_0101;
											case 4u:
											case 6u:
												goto IL_0109;
											case 5u:
												num3 = num & 3;
												num4 = num >> 2;
												break;
											case 23u:
												num2 = uint_1 ^ (uint)num;
												goto case 5u;
											case 11u:
											case 17u:
												if (num != 0)
												{
													goto case 23u;
												}
												goto case 12u;
											case 12u:
												return 0u;
											case 26u:
												goto IL_0136;
											case 19u:
												goto IL_0146;
											case 15u:
												goto IL_014d;
											case 24u:
												goto IL_0157;
											case 1u:
												goto IL_015e;
											case 8u:
												goto IL_0169;
											case 10u:
											case 14u:
												goto end_IL_0116;
											case 20u:
												num2 ^= num2 >> 13;
												goto default;
											default:
												num2 *= 1540483477;
												return num2 ^ (num2 >> 15);
											}
											break;
										}
										break;
										IL_014d:
										num2 *= 1540483477;
										goto end_IL_0116;
										IL_0136:
										num2 ^= *(byte*)ptr2;
										num2 *= 1540483477;
										goto end_IL_0116;
										IL_0157:
										num2 ^= (ushort)(*ptr2);
										goto IL_015e;
										IL_015e:
										num2 ^= (uint)(((byte*)ptr2)[2] << 16);
										goto IL_0169;
										IL_0169:
										num2 *= 1540483477;
										goto end_IL_0116;
										IL_0146:
										num2 ^= (ushort)(*ptr2);
										goto IL_014d;
									}
									break;
								}
								goto IL_0009;
								IL_003d:
								ptr2++;
								continue;
								IL_0009:
								num7 = *ptr2;
								goto IL_000e;
								IL_000e:
								num7 *= 1540483477;
								num7 ^= num7 >> 24;
								goto IL_0022;
								IL_0022:
								num7 *= 1540483477;
								goto IL_002c;
								IL_002c:
								num2 *= 1540483477;
								num2 ^= num7;
								num4--;
								goto IL_003d;
							}
							break;
						}
					}
					continue;
					end_IL_0116:
					break;
				}
				num2 ^= num2 >> 13;
				num2 *= 1540483477;
				return num2 ^ (num2 >> 15);
			}
			return 0u;
		}
	}

	internal Struct124 struct124_0;

	internal Struct125 struct125_0;

	private IntPtr[] intptr_0;

	public const string string_0 = "poe-3.3.1.2-r1 B";

	public const uint uint_0 = 1259488902u;

	public const uint uint_1 = 2672439318u;

	public const string string_1 = "poe_cis-2.2.2.6 B";

	public const uint uint_2 = 2127794603u;

	public const string string_2 = "poe_sg-2.2.2.5 B";

	public const uint uint_3 = 2429995333u;

	public const string string_3 = "poe_tw-2.2.2.4 B";

	public const uint uint_4 = 4195082080u;

	private T[] method_2<T>(ArraySegment<T> arraySegment_0) where T : struct
	{
		List<T> list = new List<T>();
		for (int i = arraySegment_0.Offset; i < arraySegment_0.Offset + arraySegment_0.Count; i++)
		{
			list.Add(arraySegment_0.Array[i]);
		}
		return list.ToArray();
	}

	private static uint smethod_0(uint uint_5, byte byte_0)
	{
		uint num = (uint)((byte_0 << 24) | (byte_0 << 16) | (byte_0 << 8) | byte_0);
		return uint_5 ^ num;
	}

	public void method_3()
	{
		intptr_0 = null;
		struct124_0 = default(Struct124);
		struct125_0 = default(Struct125);
	}

	public static uint smethod_1(string string_4)
	{
		return Class267.smethod_0(File.ReadAllBytes(string_4));
	}

	public void method_4(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 53);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 53, 134);
	}

	public void method_5(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_6(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}

	public void method_7(IntPtr[] intptr_1, out ArraySegment<IntPtr> arraySegment_0, out ArraySegment<IntPtr> arraySegment_1)
	{
		arraySegment_0 = new ArraySegment<IntPtr>(intptr_1, 0, 35);
		arraySegment_1 = new ArraySegment<IntPtr>(intptr_1, 35, 102);
	}
}
