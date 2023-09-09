using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class Beam : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructBeamComponent
	{
		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		public int Unknown1;

		public int Unknown2;

		private long intptr_9;

		public Vector3 BeamStar;

		public Vector3 BeamEnd;
	}

	private PerFrameCachedValue<StructBeamComponent> perFrameCachedValue_1;

	public Vector3 BeamStart => structBeamComponent.BeamStar;

	public Vector3 BeamEnd => structBeamComponent.BeamEnd;

	public int Unknown1 => structBeamComponent.Unknown1;

	public int Unknown2 => structBeamComponent.Unknown2;

	internal StructBeamComponent structBeamComponent
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<StructBeamComponent>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private StructBeamComponent method_1()
	{
		return base.M.FastIntPtrToStruct<StructBeamComponent>(base.Address);
	}
}
