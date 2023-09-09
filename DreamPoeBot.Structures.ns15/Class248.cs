using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Structures.ns15;

internal class Class248 : MemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct132
	{
		private long intptr_0;

		public NativeVector nativeVector_0;
	}

	[Serializable]
	private sealed class Class295
	{
		public static readonly Class295 Class9 = new Class295();

		public static Func<KeyValuePair<StatTypeGGG, int>, StatTypeGGG> Method9__12_0;

		public static Func<KeyValuePair<StatTypeGGG, int>, int> Method9__12_1;

		internal StatTypeGGG method_0(KeyValuePair<StatTypeGGG, int> keyValuePair_0)
		{
			return keyValuePair_0.Key;
		}

		internal int method_1(KeyValuePair<StatTypeGGG, int> keyValuePair_0)
		{
			return keyValuePair_0.Value;
		}
	}

	private readonly Struct132? nullable_0;

	private PerFrameCachedValue<Struct132> perFrameCachedValue_0;

	private Struct132 Struct132_0
	{
		get
		{
			if (perFrameCachedValue_0 == null)
			{
				perFrameCachedValue_0 = new PerFrameCachedValue<Struct132>(method_1);
			}
			return perFrameCachedValue_0;
		}
	}

	private Struct132 Struct132_1 => nullable_0 ?? Struct132_0;

	internal List<KeyValuePair<StatTypeGGG, int>> List_0 => Containers.StdStatType_IntVector<KeyValuePair<StatTypeGGG, int>>(Struct132_1.nativeVector_0);

	internal Dictionary<StatTypeGGG, int> Dictionary_0 => List_0.ToDictionary(Class295.Class9.method_0, Class295.Class9.method_1);

	internal Class248(long ptr)
		: base(ptr)
	{
	}

	internal Class248(Struct132 native)
		: this(1L)
	{
		nullable_0 = native;
	}

	internal int method_0(StatTypeGGG statTypeGGG_0)
	{
		if (Dictionary_0.TryGetValue(statTypeGGG_0, out var value))
		{
			return value;
		}
		return 0;
	}

	private Struct132 method_1()
	{
		return GameController.Instance.Memory.FastIntPtrToStruct<Struct132>(BaseAddress);
	}
}
