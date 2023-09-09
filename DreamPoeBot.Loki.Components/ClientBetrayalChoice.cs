using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class ClientBetrayalChoice : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct400
	{
		public long intptr_0;

		public long intptr_1;

		public long intptr_2;

		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;
	}

	private PerFrameCachedValue<Struct400> perFrameCachedValue_1;

	internal Struct400 Struct400_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct400>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct400 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct400>(base.Address);
	}
}
