using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Targetable : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct225
	{
		public Struct253 struct253_0;

		public long intptr_0;

		public long intptr_1;

		public long intptr_2;

		public long intptr_3;

		public long intptr_8;

		public long intptr_9;

		public long intptr_10;

		public byte byte_0CanTarget;

		public byte byte_1CanHighlight;

		public byte byte_2IsTargeted;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public long intptr_4;

		public long intptr_5;

		public long intptr_6;

		public long intptr_7;
	}

	private PerFrameCachedValue<Struct225> perFrameCachedValue_1;

	public bool CanTarget => Struct225_0.byte_0CanTarget > 0;

	public bool CanHighlight => Struct225_0.byte_1CanHighlight > 0;

	public bool IsTargeted => Struct225_0.byte_2IsTargeted == 1;

	internal Struct225 Struct225_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct225>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		_ = Struct225_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}] Targetable Component"));
		stringBuilder.AppendLine($"CanTarget: {CanTarget}");
		stringBuilder.AppendLine($"CanHighlight: {CanHighlight}");
		stringBuilder.AppendLine($"isTargeted: {IsTargeted}");
		return stringBuilder.ToString();
	}

	private Struct225 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct225>(base.Address);
	}
}
