using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Stats : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct217StatsD
	{
		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_00;

		private long intptr_01;

		public long intptr_2Struct218;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private NativeVector nativeVector_0;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		private long intptr_18;

		private long intptr_19;

		private long intptr_20;

		private long intptr_21;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_22;

		public NativeVector StatsDictionaryVector;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct Struct218
	{
		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private NativeVector nativeVector_00;

		private NativeVector nativeVector_01;

		private NativeVector nativeVector_0;

		private NativeVector nativeVector_1;

		public NativeVector nativeVector_2;

		private NativeVector nativeVector_3;

		private uint uint_0;

		private uint uint_1;

		private NativeVector nativeVector_4;

		private uint uint_2;

		private int unusedInt0;

		private NativeVector nativeVector_5;

		private NativeVector nativeVector_6;

		private long intptr_3;

		private NativeVector nativeVector_7;

		private long intptr_4;

		private NativeVector nativeVector_8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct219StatsComponent
	{
		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private long intptr_0;

		public long StatsD;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct220
	{
		private IntPtr intptr_0;

		private IntPtr intptr_1;

		private IntPtr intptr_2;

		private IntPtr intptr_3;

		private IntPtr intptr_4;

		private IntPtr intptr_5;

		private IntPtr intptr_6;

		private IntPtr intptr_7;

		private IntPtr intptr_8;

		private IntPtr intptr_9;

		private IntPtr intptr_10;

		private NativeVector nativeVector_0;

		private IntPtr intptr_11;

		private IntPtr intptr_12;

		private IntPtr intptr_13;

		private IntPtr intptr_14;

		private IntPtr intptr_15;

		private IntPtr intptr_16;

		private IntPtr intptr_17;

		private IntPtr intptr_18;

		private IntPtr intptr_19;

		private IntPtr intptr_20;

		private IntPtr intptr_21;

		private IntPtr intptr_22;

		private IntPtr intptr_23;

		private IntPtr intptr_24;

		private IntPtr intptr_25;

		private IntPtr intptr_26;

		private NativeVector nativeVector_1;

		private IntPtr intptr_27;

		private NativeVector nativeVector_2;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct221
	{
		public StatTypeGGG statTypeGGG_0;

		public int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct222
	{
		public StatTypeGGG StatTypeGGG_0;

		private int UnusedInt0;

		public int Value;

		private int int_1;

		private NativeVector nativeVector_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct223
	{
		private int int_0;

		private int int_1;

		private NativeVector nativeVector_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct224
	{
		private int int_0;

		private int int_1;

		private int int_2;
	}

	private PerFrameCachedValue<Struct219StatsComponent> perFrameCachedValue_1;

	private PerFrameCachedValue<Dictionary<StatTypeGGG, int>> perFrameCachedValue_2;

	public Dictionary<StatTypeGGG, int> StatsD
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Dictionary<StatTypeGGG, int>>(GetStatsD);
			}
			return perFrameCachedValue_2;
		}
	}

	internal Struct219StatsComponent Struct219_StatsComponent
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct219StatsComponent>(GetStatComponentStructure);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[StatsComponent]");
		foreach (KeyValuePair<StatTypeGGG, int> item in StatsD)
		{
			stringBuilder.AppendLine($"\t{item.Key.ToString()} : {item.Value}");
		}
		return stringBuilder.ToString();
	}

	public int GetStat(StatTypeGGG stat)
	{
		if (!StatsD.TryGetValue(stat, out var value))
		{
			return 0;
		}
		return value;
	}

	private Struct219StatsComponent GetStatComponentStructure()
	{
		return base.M.FastIntPtrToStruct<Struct219StatsComponent>(base.Address);
	}

	internal static Dictionary<StatTypeGGG, int> GetDictionaryStatTypeGGGInt(Struct217StatsD struct217_0, bool bool_0 = false)
	{
		Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
		NativeVector statsDictionaryVector = struct217_0.StatsDictionaryVector;
		if (statsDictionaryVector.First <= statsDictionaryVector.Last && statsDictionaryVector.Last <= statsDictionaryVector.End)
		{
			if (statsDictionaryVector.First != 0L && statsDictionaryVector.Last != 0L && statsDictionaryVector.End != 0L)
			{
				List<Struct221> list = Containers.StdStruct221Vector<Struct221>(statsDictionaryVector);
				foreach (Struct221 item in list)
				{
					if (!dictionary.ContainsKey(item.statTypeGGG_0))
					{
						dictionary.Add(item.statTypeGGG_0, item.int_0);
					}
				}
				long intptr_2Struct = struct217_0.intptr_2Struct218;
				if (intptr_2Struct == 0L)
				{
					return dictionary;
				}
				if (LokiPoe.Memory.ReadLong(LokiPoe.Memory.ReadLong(intptr_2Struct)) != 0L)
				{
					if (bool_0)
					{
						Struct217StatsD struct217StatsD = LokiPoe.Memory.FastIntPtrToStruct<Struct217StatsD>(intptr_2Struct);
						List<Struct221> list2 = Containers.StdStruct221Vector<Struct221>(struct217StatsD.StatsDictionaryVector);
						foreach (Struct221 item2 in list2)
						{
							if (!dictionary.ContainsKey(item2.statTypeGGG_0))
							{
								dictionary.Add(item2.statTypeGGG_0, item2.int_0);
							}
						}
						{
							foreach (Struct222 item3 in Containers.StdStruct222Vector<Struct222>(LokiPoe.Memory.FastIntPtrToStruct<Struct218>(struct217StatsD.intptr_2Struct218).nativeVector_2))
							{
								if (!dictionary.ContainsKey(item3.StatTypeGGG_0))
								{
									dictionary.Add(item3.StatTypeGGG_0, item3.Value);
								}
							}
							return dictionary;
						}
					}
					return dictionary;
				}
				return dictionary;
			}
			return dictionary;
		}
		return dictionary;
	}

	private Dictionary<StatTypeGGG, int> GetStatsD()
	{
		if (!base.Owner.IsValid)
		{
			return new Dictionary<StatTypeGGG, int>();
		}
		return GetDictionaryStatTypeGGGInt(base.M.FastIntPtrToStruct<Struct217StatsD>(Struct219_StatsComponent.StatsD));
	}
}
