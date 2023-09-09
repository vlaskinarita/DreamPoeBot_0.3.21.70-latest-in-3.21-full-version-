using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class BreachObject : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct153
	{
		public Struct253 struct253_0;

		public byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		public long intptr_0;

		public NativeStringWCustom nativeStringW_0;

		public Vector2i vector2i_0;

		public float float_0;

		public float float_1;

		public float float_2;

		private int unusedInt1;

		public BreachState breachState_0;

		public byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;
	}

	private PerFrameCachedValue<Struct153> perFrameCachedValue_1;

	public string AttachedEffect => Containers.StdStringWCustom(Struct153_0.nativeStringW_0);

	public Vector2i BreachPosition => Struct153_0.vector2i_0;

	public float Radius => Struct153_0.float_0;

	public BreachState State => Struct153_0.breachState_0;

	internal Struct153 Struct153_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct153>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "BreachObjectComponent"));
		stringBuilder.AppendLine(string.Format("\tBaseAddress: 0x{0:X}", base.Address.ToString("X")));
		stringBuilder.AppendLine($"AttachedEffect: {AttachedEffect}");
		stringBuilder.AppendLine($"BreachPosition: {BreachPosition}");
		stringBuilder.AppendLine($"Radius: {Radius}");
		stringBuilder.AppendLine($"State: {State}");
		return stringBuilder.ToString();
	}

	private Struct153 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct153>(base.Address);
	}
}
