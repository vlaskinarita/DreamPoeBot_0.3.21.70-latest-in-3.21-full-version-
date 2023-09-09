using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns15;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class LocalStats : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct172
	{
		internal Struct253 struct253_0;

		public long intptr_0;

		public Class248.Struct132 struct132_0;
	}

	private PerFrameCachedValue<Struct172> perFrameCachedValue_1;

	public Dictionary<StatTypeGGG, int> StatDictionary
	{
		get
		{
			NativeVector nativeVector_ = Struct172_0.struct132_0.nativeVector_0;
			int num = 0;
			int num2 = 0;
			int num3 = (int)(nativeVector_.Last - nativeVector_.First);
			byte[] array = base.M.ReadBytes(nativeVector_.First, num3);
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>(num3 / 8);
			for (int i = 0; i < array.Length; i += 8)
			{
				num = BitConverter.ToInt32(array, i);
				num2 = BitConverter.ToInt32(array, i + 4);
				dictionary[(StatTypeGGG)num] = num2;
			}
			return dictionary;
		}
	}

	public int Type
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address);
		}
	}

	public int Value
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address + 4L);
		}
	}

	public Dictionary<StatTypeGGG, int> Stats => Class248_0.Dictionary_0;

	internal Struct172 Struct172_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct172>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Class248 Class248_0 => new Class248(Struct172_0.struct132_0);

	public LocalStats()
	{
	}

	public LocalStats(long address)
	{
		base.Address = address;
	}

	public int GetStat(StatTypeGGG stat)
	{
		return Class248_0.method_0(stat);
	}

	private Struct172 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct172>(base.Address);
	}
}
