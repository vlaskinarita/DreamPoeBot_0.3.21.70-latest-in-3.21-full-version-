using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Timer : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct226
	{
		public Struct253 struct253_0;

		public long intptr_0;

		public float float_0;

		public long intptr_2;
	}

	private PerFrameCachedValue<Struct226> perFrameCachedValue_1;

	public float TimeLeft => Struct226_0.float_0;

	internal Struct226 Struct226_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct226>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct226 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct226>(base.Address);
	}
}
