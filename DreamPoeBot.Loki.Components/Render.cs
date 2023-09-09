using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Render : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct203
	{
		private Struct253 struct253_0;

		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		public Vector3 vector3_0WorldPosition;

		public Vector3 vector3_1InteractSize;

		private Vector2 vector2_0;

		private Vector2 vector2_1;

		public NativeStringWCustom nativeStringW_0Name;

		public Vector3 vector3_2Rotation;

		private int int_16;

		private int int_17;

		private int int_18;

		private int int_19;

		public float float_0TerrainHeightAt;
	}

	private PerFrameCachedValue<Struct203> perFrameCachedValue_1;

	public Vector3 InteractCenterWorld => WorldPosition - InteractSize / 2f;

	public Vector3 InteractSize => Struct203_0.vector3_1InteractSize;

	public string Name => Containers.StdStringWCustom(Struct203_0.nativeStringW_0Name);

	public Vector3 Rotation => Struct203_0.vector3_2Rotation;

	public float TerrainHeightAt => Struct203_0.float_0TerrainHeightAt;

	public Vector3 WorldPosition => Struct203_0.vector3_0WorldPosition;

	internal Struct203 Struct203_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct203>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct203 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct203>(base.Address);
	}
}
