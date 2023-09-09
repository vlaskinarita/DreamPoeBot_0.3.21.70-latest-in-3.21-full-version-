using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Prophecy : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct198
	{
		public Struct253 struct253_0;

		public IntPtr intptr_0;

		public Struct243 struct243_0;
	}

	private PerFrameCachedValue<Struct198> perFrameCachedValue_1;

	public DatPropheciesWrapper DatPropheciesWrapper => Dat.smethod_72(Struct198_0.struct243_0.intptr_1, bool_0: true);

	internal Struct198 Struct198_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct198>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct198 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct198>(base.Address);
	}
}
