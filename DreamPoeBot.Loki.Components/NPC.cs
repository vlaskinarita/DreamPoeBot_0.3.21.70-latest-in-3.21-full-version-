using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class NPC : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct184
	{
		public Struct253 struct253_0;

		public byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		public long intptr_0;

		public byte byte_4IsIgnoreHidden;

		public byte byte_5IsMinimapLabelVisible;

		private byte byte_6;

		private byte byte_7;

		private int unusedInt1;

		public long intptr_1;

		public long intptr_2;

		public float float_0;

		public byte byte_8;

		public byte byte_9;

		public byte byte_10;

		public byte byte_11;

		public int int_0;

		private int unusedInt2;

		public long intptr_3HasIconOverHead;

		public long intptr_4;

		public byte byte_12;

		public byte byte_13;

		public byte byte_14;

		public byte byte_15;

		private int unusedInt3;

		public long intptr_5;
	}

	private PerFrameCachedValue<Struct184> perFrameCachedValue_1;

	public bool HasIconOverHead => (ulong)Struct184_0.intptr_3HasIconOverHead > 0uL;

	public bool IsIgnoreHidden => Struct184_0.byte_4IsIgnoreHidden == 1;

	public bool IsMinimapLabelVisible => Struct184_0.byte_5IsMinimapLabelVisible == 1;

	internal Struct184 Struct184_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct184>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct184 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct184>(base.Address);
	}
}
