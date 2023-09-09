using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Positioned : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct196
	{
		private Struct253 struct253_0;

		private long intptr_00;

		private long intptr_0;

		private long intptr_01;

		private long intptr_02;

		private long intptr_03;

		private long intptr_04;

		private long intptr_05;

		private long intptr_06;

		private long intptr_07;

		private long intptr_08;

		private long intptr_09;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		private long intptr_18;

		private long intptr_19;

		private long intptr_20;

		private long intptr_21;

		private long intptr_22;

		private long intptr_23;

		private long intptr_24;

		private long intptr_25;

		private long intptr_26;

		private long intptr_27;

		private long intptr_28;

		private long intptr_29;

		private long intptr_30;

		private long intptr_31;

		private long intptr_32;

		private long intptr_33;

		private long intptr_34;

		private long intptr_35;

		private long intptr_36;

		private long intptr_37;

		private long intptr_38;

		private long intptr_39;

		private long intptr_341;

		private long intptr_342;

		private long intptr_343;

		private long intptr_344;

		private long intptr_345;

		private long intptr_346;

		private long intptr_347;

		private long intptr_348;

		private long intptr_349;

		private long intptr_350;

		private long intptr_351;

		private long intptr_352;

		private long intptr_353;

		private long intptr_354;

		private long intptr_355;

		private long intptr_356;

		private long intptr_090;

		public byte byte_7Reaction;

		public byte byte_6;

		private byte byte_4;

		private byte byte_5;

		private int int_111;

		private long intptr_100;

		private long intptr_110;

		private long intptr_120;

		private long intptr_130;

		private long intptr_140;

		private long intptr_150;

		private long intptr_160;

		private long intptr_170;

		private long intptr_180;

		private long intptr_190;

		private long intptr_200;

		private long intptr_210;

		private long intptr_220;

		private long intptr_230;

		private long intptr_240;

		private long intptr_241;

		private long intptr_242;

		private long intptr_243;

		private long intptr_244;

		private long intptr_245;

		private long intptr_246;

		public Vector2i vector2i_0MapPosition;

		public float floatRotationNew;

		private float float_00;

		private float float_01;

		private float float_02;

		public float float_Size;

		public float float_SizeScale;

		private float float_0;

		public Vector2 vector2_0WorldPosition;
	}

	private PerFrameCachedValue<Struct196> perFrameCachedValue_1;

	public int GridX
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return MapPosition.X;
		}
	}

	public int GridY
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return MapPosition.Y;
		}
	}

	public Vector2i GridPos => MapPosition;

	public float WorldX => WorldPos.X;

	public float WorldY => WorldPos.Y;

	public int CharacterSize => (int)(Struct196_0.float_Size * Struct196_0.float_SizeScale);

	internal Vector2 WorldPos => Struct196_0.vector2_0WorldPosition;

	public Vector2i MapPosition => Struct196_0.vector2i_0MapPosition;

	public float Rotation => Struct196_0.floatRotationNew;

	public byte Reaction => Struct196_0.byte_7Reaction;

	private Struct196 Struct196_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct196>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct196 method_1()
	{
		return base.M.FastIntPtrToStruct196(base.Address);
	}
}
