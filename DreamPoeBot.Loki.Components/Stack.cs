using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Stack : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct215
	{
		public Struct253 struct253_0;

		public long intptr_Struct216;

		public int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct216
	{
		public long intptr_0;

		public long intptr_1;

		public long intptr_2;

		public long intptr_3;

		public int int_0MaxCurrencyTabStackCount;

		public int int_1;

		public int int_2MaxStackCount;

		public int int_3;

		public NativeStringWCustom nativeStringW_0;
	}

	private PerFrameCachedValue<Struct215> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct216> perFrameCachedValue_2;

	public int MaxCurrencyTabStackCount => Struct216_0.int_0MaxCurrencyTabStackCount;

	public int MaxStackCount => Struct216_0.int_2MaxStackCount;

	public int StackCount => Struct215_0.int_0;

	public string Description => Containers.StdStringWCustom(Struct216_0.nativeStringW_0);

	internal Struct215 Struct215_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct215>(() => base.M.FastIntPtrToStruct<Struct215>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct216 Struct216_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct216>(() => base.M.FastIntPtrToStruct<Struct216>(Struct215_0.intptr_Struct216));
			}
			return perFrameCachedValue_2;
		}
	}

	[CompilerGenerated]
	private Struct215 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct215>(base.Address);
	}

	[CompilerGenerated]
	private Struct216 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct216>(Struct215_0.intptr_Struct216);
	}
}
