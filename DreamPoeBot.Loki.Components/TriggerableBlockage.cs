using System;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class TriggerableBlockage : Component
{
	internal struct Struct228
	{
		public Struct253 struct253_0;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public int UnusedInt;

		private IntPtr intptr_0;

		private IntPtr intptr_1;

		private IntPtr intptr_2;

		public byte byte_4IsOpenedIf0;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public byte byte_8;

		public byte byte_9;

		public byte byte_10;

		public byte byte_11;

		public Vector2i vector2i_0BoundsMin;

		public Vector2i vector2i_1BoundsMax;

		public NativeVector nativeVector_0NavData;
	}

	private PerFrameCachedValue<Struct228> perFrameCachedValue_1;

	public int Distance => LokiPoe.LocalData.MyPosition.Distance(new Vector2i(base.Owner.PositionedComponent_0.GridX, base.Owner.PositionedComponent_0.GridY));

	public string Name => base.Owner.Name;

	public string Metadata => base.Owner.Metadata;

	public bool IsTargetable
	{
		get
		{
			if (base.Owner.Components.TargetableComponent == null)
			{
				return false;
			}
			return base.Owner.Components.TargetableComponent.CanTarget;
		}
	}

	public Vector2i BoundsMin => Struct228_0.vector2i_0BoundsMin;

	public Vector2i BoundsMax => Struct228_0.vector2i_1BoundsMax;

	public Vector2i Size => BoundsMax - BoundsMin;

	public bool IsOpened => Struct228_0.byte_4IsOpenedIf0 == 0;

	public byte _19 => Struct228_0.byte_5;

	public byte _1A => Struct228_0.byte_6;

	public byte _1B => Struct228_0.byte_7;

	public byte _1C => Struct228_0.byte_8;

	public byte[] NavData => Containers.StdByteVector<byte>(Struct228_0.nativeVector_0NavData).ToArray();

	internal Struct228 Struct228_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct228>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		Struct228 struct228_ = Struct228_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "TriggerableBlockageComponent"));
		stringBuilder.AppendLine($"IsOpened: {IsOpened}");
		stringBuilder.AppendLine($"BoundsMin: {BoundsMin}");
		stringBuilder.AppendLine($"BoundsMax: {BoundsMax}");
		stringBuilder.AppendLine($"Size: {Size}");
		stringBuilder.AppendLine($"_19: {_19}");
		stringBuilder.AppendLine($"_1A: {_1A}");
		stringBuilder.AppendLine($"_1B: {_1B}");
		stringBuilder.AppendLine($"_1C: {_1C}");
		stringBuilder.AppendLine($"\t[NavData]");
		try
		{
			StringBuilder stringBuilder2 = new StringBuilder();
			byte[] navData = NavData;
			int x = struct228_.vector2i_0BoundsMin.X;
			int num = struct228_.vector2i_1BoundsMax.X;
			if ((num - x) % 2 == 1)
			{
				num++;
			}
			int num2 = (struct228_.vector2i_1BoundsMax.X + 1) / 2 - struct228_.vector2i_0BoundsMin.X / 2;
			for (int i = struct228_.vector2i_0BoundsMin.Y; i < struct228_.vector2i_1BoundsMax.Y; i++)
			{
				stringBuilder2.AppendFormat("\t\t");
				for (int j = x; j < num; j++)
				{
					int num3 = (i - struct228_.vector2i_0BoundsMin.Y) * num2 + (j - x) / 2;
					byte b = ((((uint)j & (true ? 1u : 0u)) != 0) ? ((byte)(navData[num3] >> 4)) : ((byte)(navData[num3] & 0xFu)));
					stringBuilder2.AppendFormat("{0:X1}", b);
				}
				stringBuilder2.AppendLine();
			}
			stringBuilder.AppendLine(stringBuilder2.ToString());
		}
		catch (Exception ex)
		{
			stringBuilder.AppendLine($"\tNavData: {ex.Message}");
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine($"\t[TerrainData]");
		try
		{
			StringBuilder stringBuilder3 = new StringBuilder();
			CachedTerrainData cache = LokiPoe.TerrainData.Cache;
			int x2 = struct228_.vector2i_0BoundsMin.X;
			int num4 = struct228_.vector2i_1BoundsMax.X;
			if ((num4 - x2) % 2 == 1)
			{
				num4++;
			}
			for (int k = struct228_.vector2i_0BoundsMin.Y; k < struct228_.vector2i_1BoundsMax.Y; k++)
			{
				stringBuilder3.AppendFormat("\t\t");
				for (int l = x2; l < num4; l++)
				{
					int num5 = k * cache.BPR + l / 2;
					byte b2 = (((l & 1) == 0) ? ((byte)(cache.Data[num5] & 0xFu)) : ((byte)(cache.Data[num5] >> 4)));
					stringBuilder3.AppendFormat("{0:X1}", b2);
				}
				stringBuilder3.AppendLine();
			}
			stringBuilder.AppendLine(stringBuilder3.ToString());
		}
		catch (Exception ex2)
		{
			stringBuilder.AppendLine($"\tTerrainData: {ex2.Message}");
		}
		return stringBuilder.ToString();
	}

	private Struct228 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct228>(base.Address);
	}
}
