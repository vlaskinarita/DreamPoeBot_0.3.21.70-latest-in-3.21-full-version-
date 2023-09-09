using System;
using System.Runtime.InteropServices;
using System.Security;

namespace DreamPoeBot.Loki.Common;

public static class OSInfo
{
	private struct Struct332
	{
		public int int_0;

		public readonly int int_1;

		public readonly int int_2;

		public readonly int int_3;

		public readonly int int_4;

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public readonly string string_0;

		public readonly short short_0;

		public readonly short short_1;

		public readonly short short_2;

		public readonly byte byte_0;

		public readonly byte byte_1;
	}

	private static string string_0;

	private static string string_1;

	private const int int_0 = 0;

	private const int int_1 = 1;

	private const int int_2 = 2;

	private const int int_3 = 3;

	private const int int_4 = 4;

	private const int int_5 = 5;

	private const int int_6 = 6;

	private const int int_7 = 7;

	private const int int_8 = 8;

	private const int int_9 = 9;

	private const int int_10 = 10;

	private const int int_11 = 11;

	private const int int_12 = 12;

	private const int int_13 = 13;

	private const int int_14 = 14;

	private const int int_15 = 15;

	private const int int_16 = 16;

	private const int int_17 = 17;

	private const int int_18 = 18;

	private const int int_19 = 19;

	private const int int_20 = 20;

	private const int int_21 = 21;

	private const int int_22 = 22;

	private const int int_23 = 23;

	private const int int_24 = 24;

	private const int int_25 = 25;

	private const int int_26 = 26;

	private const int int_27 = 27;

	private const int int_28 = 28;

	private const int int_29 = 29;

	private const int int_30 = 30;

	private const int int_31 = 31;

	private const int int_32 = 32;

	private const int int_33 = 35;

	private const int int_34 = 36;

	private const int int_35 = 38;

	private const int int_36 = 40;

	private const int int_37 = 41;

	private const int int_38 = 42;

	private const int int_39 = 101;

	private const int int_40 = 98;

	private const int int_41 = 99;

	private const int int_42 = 100;

	private const int int_43 = 48;

	private const int int_44 = 1;

	private const int int_45 = 2;

	private const int int_46 = 3;

	private const int int_47 = 1;

	private const int int_48 = 2;

	private const int int_49 = 16;

	private const int int_50 = 128;

	private const int int_51 = 256;

	private const int int_52 = 512;

	private const int int_53 = 1024;

	public static int Bits
	{
		get
		{
			if (Environment.Is64BitOperatingSystem)
			{
				return 64;
			}
			return 32;
		}
	}

	public static string Edition
	{
		get
		{
			if (string_0 == null)
			{
				uint num = default(uint);
				while (true)
				{
					string result = string.Empty;
					OperatingSystem oSVersion = Environment.OSVersion;
					Struct332 struct332_ = default(Struct332);
					while (true)
					{
						struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
						while (true)
						{
							IL_030e:
							if (GetVersionEx(ref struct332_))
							{
								while (true)
								{
									IL_0300:
									int major = oSVersion.Version.Major;
									while (true)
									{
										IL_02e9:
										int minor = oSVersion.Version.Minor;
										byte byte_ = struct332_.byte_0;
										while (true)
										{
											IL_02df:
											short short_ = struct332_.short_2;
											while (true)
											{
												IL_02d6:
												if (major != 4)
												{
													while (true)
													{
														IL_02d0:
														if (major != 5)
														{
															while (major == 6)
															{
																int int_;
																while (GetProductInfo(major, minor, struct332_.short_0, struct332_.short_1, out int_))
																{
																	while (true)
																	{
																		switch (int_)
																		{
																		case 0:
																			goto IL_03fa;
																		case 1:
																			goto IL_0405;
																		case 2:
																			goto IL_0410;
																		case 3:
																			goto IL_041b;
																		case 4:
																			goto IL_0426;
																		case 5:
																			goto IL_0431;
																		case 6:
																			goto IL_043c;
																		case 7:
																			goto IL_0447;
																		case 8:
																			goto IL_0452;
																		case 9:
																			goto IL_045d;
																		case 10:
																			goto IL_0468;
																		case 11:
																			goto IL_0473;
																		case 12:
																			goto IL_047e;
																		case 13:
																			goto IL_0489;
																		case 14:
																			goto IL_0494;
																		case 15:
																			goto IL_049f;
																		case 16:
																			goto IL_04aa;
																		case 17:
																			goto IL_04b5;
																		case 18:
																			goto IL_04c0;
																		case 20:
																			goto IL_04cb;
																		case 21:
																			goto IL_04d6;
																		case 22:
																			goto IL_04e1;
																		case 23:
																			goto IL_04ec;
																		case 24:
																			goto IL_04f7;
																		case 26:
																			goto IL_0502;
																		case 27:
																			goto IL_050d;
																		case 28:
																			goto IL_0518;
																		case 29:
																			goto IL_0523;
																		case 30:
																			goto IL_052b;
																		case 31:
																			goto IL_0533;
																		case 32:
																			goto IL_053b;
																		case 35:
																			goto IL_0543;
																		case 36:
																			goto IL_054b;
																		case 38:
																			goto IL_0553;
																		case 40:
																			goto IL_055b;
																		case 41:
																			goto IL_0563;
																		case 42:
																			goto IL_056b;
																		case 48:
																			goto IL_0573;
																		case 19:
																		case 25:
																		case 33:
																		case 34:
																		case 37:
																		case 39:
																		case 43:
																		case 44:
																		case 45:
																		case 46:
																		case 47:
																			goto end_IL_01d7;
																		}
																		int num2 = ((int)num * -509823945) ^ 0x3FF516F4;
																		while (true)
																		{
																			switch ((num = (uint)num2 ^ 0xFE8F6676u) % 101u)
																			{
																			case 18u:
																				num2 = ((int)num * -221892444) ^ 0x2BC25409;
																				continue;
																			case 31u:
																				break;
																			case 8u:
																				goto IL_02a7;
																			case 29u:
																				goto IL_02c7;
																			case 10u:
																				goto IL_02d0;
																			case 83u:
																				goto IL_02d6;
																			case 51u:
																				goto IL_02df;
																			case 64u:
																				goto IL_02e9;
																			case 25u:
																				goto IL_0300;
																			case 41u:
																				goto IL_030e;
																			case 22u:
																				goto end_IL_030e;
																			case 95u:
																				goto end_IL_031c;
																			case 12u:
																			case 14u:
																				goto end_IL_0334;
																			case 84u:
																				goto IL_0350;
																			case 55u:
																				goto IL_0355;
																			case 5u:
																				goto IL_035f;
																			case 1u:
																				goto IL_036a;
																			case 96u:
																				goto IL_0375;
																			case 90u:
																				goto IL_037f;
																			case 36u:
																				goto IL_0383;
																			case 66u:
																				goto IL_038d;
																			case 50u:
																				goto IL_0398;
																			case 9u:
																				goto IL_039e;
																			case 40u:
																				goto IL_03a9;
																			case 19u:
																				goto IL_03b4;
																			case 86u:
																				goto IL_03be;
																			case 85u:
																				goto IL_03c9;
																			case 39u:
																				goto IL_03cf;
																			case 7u:
																				goto IL_03da;
																			case 33u:
																				goto IL_03e4;
																			case 17u:
																				goto IL_03ef;
																			case 82u:
																				goto IL_03fa;
																			case 26u:
																				goto IL_0405;
																			case 46u:
																				goto IL_0410;
																			case 75u:
																				goto IL_041b;
																			case 23u:
																				goto IL_0426;
																			case 2u:
																				goto IL_0431;
																			case 38u:
																				goto IL_043c;
																			case 92u:
																				goto IL_0447;
																			case 87u:
																				goto IL_0452;
																			case 69u:
																				goto IL_045d;
																			case 6u:
																				goto IL_0468;
																			case 52u:
																				goto IL_0473;
																			case 89u:
																				goto IL_047e;
																			case 79u:
																				goto IL_0489;
																			case 100u:
																				goto IL_0494;
																			case 27u:
																				goto IL_049f;
																			case 47u:
																				goto IL_04aa;
																			case 98u:
																				goto IL_04b5;
																			case 37u:
																				goto IL_04c0;
																			case 62u:
																				goto IL_04cb;
																			case 43u:
																				goto IL_04d6;
																			case 44u:
																				goto IL_04e1;
																			case 35u:
																				goto IL_04ec;
																			case 61u:
																				goto IL_04f7;
																			case 88u:
																				goto IL_0502;
																			case 59u:
																				goto IL_050d;
																			case 94u:
																				goto IL_0518;
																			case 68u:
																				goto IL_0523;
																			case 48u:
																				goto IL_052b;
																			case 42u:
																				goto IL_0533;
																			case 67u:
																				goto IL_053b;
																			case 11u:
																				goto IL_0543;
																			case 30u:
																				goto IL_054b;
																			case 81u:
																				goto IL_0553;
																			case 4u:
																				goto IL_055b;
																			case 20u:
																				goto IL_0563;
																			case 0u:
																				goto IL_056b;
																			case 34u:
																				goto IL_0573;
																			case 3u:
																				goto IL_057b;
																			case 53u:
																				goto IL_0580;
																			case 77u:
																				goto IL_0588;
																			case 80u:
																				goto IL_058f;
																			case 65u:
																				goto IL_0595;
																			case 60u:
																				goto IL_059d;
																			case 13u:
																			case 15u:
																			case 16u:
																			case 21u:
																			case 24u:
																			case 28u:
																			case 45u:
																			case 49u:
																			case 54u:
																			case 56u:
																			case 57u:
																			case 58u:
																			case 63u:
																			case 70u:
																			case 71u:
																			case 72u:
																			case 73u:
																			case 74u:
																			case 76u:
																			case 78u:
																			case 91u:
																			case 93u:
																			case 97u:
																			case 99u:
																				goto end_IL_01d7;
																			default:
																				goto IL_05a9;
																			}
																			break;
																		}
																		continue;
																		IL_0405:
																		result = "Ultimate";
																		break;
																		IL_03fa:
																		result = "Unknown product";
																		break;
																		IL_0573:
																		result = "Professional";
																		break;
																		IL_056b:
																		result = "Microsoft Hyper-V Server";
																		break;
																		IL_0563:
																		result = "Enterprise Server without Hyper-V (core installation)";
																		break;
																		IL_055b:
																		result = "Standard Server without Hyper-V (core installation)";
																		break;
																		IL_0553:
																		result = "Enterprise Server without Hyper-V";
																		break;
																		IL_054b:
																		result = "Standard Server without Hyper-V";
																		break;
																		IL_0543:
																		result = "Windows Essential Server Solutions without Hyper-V";
																		break;
																		IL_053b:
																		result = "Windows Essential Business Messaging Server";
																		break;
																		IL_0533:
																		result = "Windows Essential Business Security Server";
																		break;
																		IL_052b:
																		result = "Windows Essential Business Management Server";
																		break;
																		IL_0523:
																		result = "Web Server (core installation)";
																		break;
																		IL_0518:
																		result = "Ultimate N";
																		break;
																		IL_050d:
																		result = "Enterprise N";
																		break;
																		IL_0502:
																		result = "Home Premium N";
																		break;
																		IL_04f7:
																		result = "Windows Essential Server Solutions";
																		break;
																		IL_04ec:
																		result = "Enterprise Storage Server";
																		break;
																		IL_04e1:
																		result = "Workgroup Storage Server";
																		break;
																		IL_04d6:
																		result = "Standard Storage Server";
																		break;
																		IL_04cb:
																		result = "Express Storage Server";
																		break;
																		IL_04c0:
																		result = "HPC Edition";
																		break;
																		IL_04b5:
																		result = "Web Server";
																		break;
																		IL_04aa:
																		result = "Business N";
																		break;
																		IL_049f:
																		result = "Enterprise Server for Itanium-based Systems";
																		break;
																		IL_0494:
																		result = "Enterprise Server (core installation)";
																		break;
																		IL_0489:
																		result = "Standard Server (core installation)";
																		break;
																		IL_047e:
																		result = "Datacenter Server (core installation)";
																		break;
																		IL_0473:
																		result = "Starter";
																		break;
																		IL_0468:
																		result = "Enterprise Server";
																		break;
																		IL_045d:
																		result = "Windows Small Business Server";
																		break;
																		IL_0452:
																		result = "Datacenter Server";
																		break;
																		IL_0447:
																		result = "Standard Server";
																		break;
																		IL_043c:
																		result = "Business";
																		break;
																		IL_0431:
																		result = "Home Basic N";
																		break;
																		IL_0426:
																		result = "Enterprise";
																		break;
																		IL_041b:
																		result = "Home Premium";
																		break;
																		IL_0410:
																		result = "Home Basic";
																		break;
																		continue;
																		end_IL_01d7:
																		break;
																	}
																	break;
																	IL_02a7:;
																}
																break;
																IL_02c7:;
															}
															break;
														}
														goto IL_0350;
														IL_03ef:
														result = "Web Edition";
														break;
														IL_0350:
														if (byte_ == 1)
														{
															goto IL_0355;
														}
														goto IL_0375;
														IL_0355:
														if (((uint)short_ & 0x200u) != 0)
														{
															goto IL_035f;
														}
														goto IL_036a;
														IL_035f:
														result = "Home";
														break;
														IL_036a:
														result = "Professional";
														break;
														IL_0375:
														if (byte_ != 3)
														{
															break;
														}
														goto IL_037f;
														IL_037f:
														if (minor == 0)
														{
															goto IL_0383;
														}
														goto IL_03b4;
														IL_0383:
														if (((uint)short_ & 0x80u) != 0)
														{
															goto IL_038d;
														}
														goto IL_0398;
														IL_038d:
														result = "Datacenter Server";
														break;
														IL_0398:
														if (((uint)short_ & 2u) != 0)
														{
															goto IL_039e;
														}
														goto IL_03a9;
														IL_039e:
														result = "Advanced Server";
														break;
														IL_03a9:
														result = "Server";
														break;
														IL_03b4:
														if (((uint)short_ & 0x80u) != 0)
														{
															goto IL_03be;
														}
														goto IL_03c9;
														IL_03be:
														result = "Datacenter";
														break;
														IL_03c9:
														if (((uint)short_ & 2u) != 0)
														{
															goto IL_03cf;
														}
														goto IL_03da;
														IL_03cf:
														result = "Enterprise";
														break;
														IL_03da:
														if ((short_ & 0x400) == 0)
														{
															goto IL_03e4;
														}
														goto IL_03ef;
														IL_03e4:
														result = "Standard";
														break;
													}
													break;
												}
												goto IL_057b;
												IL_059d:
												result = "Standard Server";
												break;
												IL_057b:
												if (byte_ == 1)
												{
													goto IL_0580;
												}
												goto IL_0588;
												IL_0580:
												result = "Workstation";
												break;
												IL_0588:
												if (byte_ != 3)
												{
													break;
												}
												goto IL_058f;
												IL_058f:
												if (((uint)short_ & 2u) != 0)
												{
													goto IL_0595;
												}
												goto IL_059d;
												IL_0595:
												result = "Enterprise Server";
												break;
											}
											break;
										}
										break;
									}
									break;
								}
							}
							string_0 = result;
							goto IL_05a9;
							IL_05a9:
							return result;
							continue;
							end_IL_030e:
							break;
						}
						continue;
						end_IL_031c:
						break;
					}
					continue;
					end_IL_0334:
					break;
				}
			}
			return string_0;
		}
	}

	public static string Name
	{
		get
		{
			if (string_1 == null)
			{
				uint num = default(uint);
				string text = default(string);
				while (true)
				{
					string result = "unknown";
					while (true)
					{
						OperatingSystem oSVersion = Environment.OSVersion;
						Struct332 struct332_ = default(Struct332);
						while (true)
						{
							IL_019e:
							struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
							if (GetVersionEx(ref struct332_))
							{
								while (true)
								{
									IL_017b:
									int major = oSVersion.Version.Major;
									int minor = oSVersion.Version.Minor;
									PlatformID platform = oSVersion.Platform;
									while (true)
									{
										IL_0174:
										if (platform != PlatformID.Win32Windows)
										{
											while (platform == PlatformID.Win32NT)
											{
												while (true)
												{
													byte byte_ = struct332_.byte_0;
													while (true)
													{
														switch (major)
														{
														case 3:
															goto IL_0269;
														case 4:
															goto IL_0274;
														case 5:
															goto IL_0299;
														case 6:
															goto IL_02d9;
														}
														int num2 = (int)(num * 1008945567) ^ -675484803;
														while (true)
														{
															switch ((num = (uint)num2 ^ 0xF2909FC1u) % 64u)
															{
															case 57u:
																num2 = (int)((num * 559091618) ^ 0x122A709A);
																continue;
															case 27u:
																break;
															case 24u:
																goto end_IL_0143;
															case 38u:
																goto end_IL_0160;
															case 10u:
																goto IL_0174;
															case 36u:
																goto IL_017b;
															case 50u:
																goto IL_019e;
															case 17u:
																goto end_IL_019e;
															case 11u:
																goto end_IL_01c2;
															case 3u:
															case 4u:
																goto end_IL_01d2;
															case 26u:
																goto IL_01e0;
															case 25u:
																goto IL_01e9;
															case 18u:
																goto IL_01f1;
															case 35u:
																goto IL_01f5;
															case 47u:
																goto IL_0205;
															case 21u:
																goto IL_020d;
															case 37u:
																goto IL_0216;
															case 52u:
																goto IL_0221;
															case 22u:
																goto IL_022f;
															case 34u:
																goto IL_023a;
															case 54u:
																goto IL_0245;
															case 55u:
																goto IL_0253;
															case 56u:
																goto IL_025e;
															case 58u:
																goto IL_0269;
															case 61u:
																goto IL_0274;
															case 2u:
																goto IL_0279;
															case 42u:
																goto IL_0284;
															case 43u:
																goto IL_028e;
															case 53u:
																goto IL_0299;
															case 13u:
																goto IL_02b1;
															case 1u:
																goto IL_02bc;
															case 7u:
																goto IL_02c4;
															case 44u:
																goto IL_02c9;
															case 59u:
																goto IL_02d1;
															case 60u:
																goto IL_02d9;
															case 39u:
																goto IL_02ee;
															case 6u:
																goto IL_02f3;
															case 48u:
																goto IL_02fa;
															case 0u:
																goto IL_0302;
															case 51u:
																goto IL_030a;
															case 62u:
																goto IL_030f;
															case 5u:
																goto IL_0316;
															case 23u:
																goto IL_031e;
															case 40u:
																goto IL_0326;
															case 45u:
																goto IL_032b;
															case 15u:
																goto IL_0332;
															case 8u:
																goto IL_033a;
															case 9u:
															case 14u:
															case 16u:
															case 19u:
															case 20u:
															case 28u:
															case 29u:
															case 30u:
															case 31u:
															case 32u:
															case 33u:
															case 41u:
															case 46u:
															case 49u:
															case 63u:
																goto end_IL_016a;
															default:
																goto IL_0346;
															}
															break;
														}
														continue;
														IL_028e:
														result = "Windows NT 4.0 Server";
														goto end_IL_016a;
														IL_0269:
														result = "Windows NT 3.51";
														goto end_IL_016a;
														IL_02d9:
														switch (minor)
														{
														case 0:
															break;
														case 1:
															goto IL_030a;
														case 2:
															goto IL_0326;
														default:
															goto end_IL_016a;
														}
														goto IL_02ee;
														IL_0326:
														if (byte_ != 1)
														{
															goto IL_032b;
														}
														goto IL_033a;
														IL_032b:
														if (byte_ != 2)
														{
															goto end_IL_016a;
														}
														goto IL_0332;
														IL_0332:
														result = "Windows Server 2012 R2";
														goto end_IL_016a;
														IL_033a:
														result = "Windows 8";
														goto end_IL_016a;
														IL_030a:
														if (byte_ != 1)
														{
															goto IL_030f;
														}
														goto IL_031e;
														IL_030f:
														if (byte_ != 3)
														{
															goto end_IL_016a;
														}
														goto IL_0316;
														IL_0316:
														result = "Windows Server 2008 R2";
														goto end_IL_016a;
														IL_031e:
														result = "Windows 7";
														goto end_IL_016a;
														IL_02ee:
														if (byte_ != 1)
														{
															goto IL_02f3;
														}
														goto IL_0302;
														IL_02f3:
														if (byte_ != 3)
														{
															goto end_IL_016a;
														}
														goto IL_02fa;
														IL_02fa:
														result = "Windows Server 2008";
														goto end_IL_016a;
														IL_0302:
														result = "Windows Vista";
														goto end_IL_016a;
														IL_0299:
														switch (minor)
														{
														case 0:
															break;
														case 1:
															goto IL_02bc;
														case 2:
															goto IL_02c4;
														default:
															goto end_IL_016a;
														}
														goto IL_02b1;
														IL_02c4:
														if (byte_ != 1)
														{
															goto IL_02c9;
														}
														goto IL_02d1;
														IL_02c9:
														result = "Windows Server 2003";
														goto end_IL_016a;
														IL_02d1:
														result = "Windows XP";
														goto end_IL_016a;
														IL_02bc:
														result = "Windows XP";
														goto end_IL_016a;
														IL_02b1:
														result = "Windows 2000";
														goto end_IL_016a;
														IL_0274:
														if (byte_ == 1)
														{
															goto IL_0279;
														}
														goto IL_0284;
														IL_0279:
														result = "Windows NT 4.0";
														goto end_IL_016a;
														IL_0284:
														if (byte_ != 3)
														{
															goto end_IL_016a;
														}
														goto IL_028e;
														continue;
														end_IL_0143:
														break;
													}
													continue;
													end_IL_0160:
													break;
												}
												continue;
												end_IL_016a:
												break;
											}
											break;
										}
										goto IL_01e0;
										IL_0216:
										result = "Windows Me";
										break;
										IL_01e0:
										if (major != 4)
										{
											break;
										}
										goto IL_01e9;
										IL_01e9:
										text = struct332_.string_0;
										goto IL_01f1;
										IL_01f1:
										if (minor == 0)
										{
											goto IL_01f5;
										}
										goto IL_0205;
										IL_01f5:
										if (!(text == "B"))
										{
											goto IL_0221;
										}
										goto IL_023a;
										IL_0221:
										if (!(text == "C"))
										{
											goto IL_022f;
										}
										goto IL_023a;
										IL_022f:
										result = "Windows 95";
										break;
										IL_023a:
										result = "Windows 95 OSR2";
										break;
										IL_0205:
										if (minor != 10)
										{
											goto IL_020d;
										}
										goto IL_0245;
										IL_0245:
										if (text == "A")
										{
											goto IL_0253;
										}
										goto IL_025e;
										IL_0253:
										result = "Windows 98 Second Edition";
										break;
										IL_025e:
										result = "Windows 98";
										break;
										IL_020d:
										if (minor != 90)
										{
											break;
										}
										goto IL_0216;
									}
									break;
								}
							}
							string_1 = result;
							goto IL_0346;
							IL_0346:
							return result;
							continue;
							end_IL_019e:
							break;
						}
						continue;
						end_IL_01c2:
						break;
					}
					continue;
					end_IL_01d2:
					break;
				}
			}
			return string_1;
		}
	}

	public static string ServicePack
	{
		get
		{
			string empty = string.Empty;
			Struct332 struct332_ = default(Struct332);
			struct332_.int_0 = Marshal.SizeOf(typeof(Struct332));
			if (GetVersionEx(ref struct332_))
			{
				empty = struct332_.string_0;
			}
			return empty;
		}
	}

	public static int BuildVersion => Environment.OSVersion.Version.Build;

	public static string VersionString => Environment.OSVersion.Version.ToString();

	public static Version Version => Environment.OSVersion.Version;

	public static int MajorVersion => Environment.OSVersion.Version.Major;

	public static int MinorVersion => Environment.OSVersion.Version.Minor;

	public static int RevisionVersion => Environment.OSVersion.Version.Revision;

	[DllImport("Kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	internal static extern bool GetProductInfo(int int_54, int int_55, int int_56, int int_57, out int int_58);

	[DllImport("kernel32.dll")]
	[SuppressUnmanagedCodeSecurity]
	private static extern bool GetVersionEx(ref Struct332 struct332_0);
}
