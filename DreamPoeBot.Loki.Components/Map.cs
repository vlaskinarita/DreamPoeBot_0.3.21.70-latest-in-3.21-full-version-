using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class Map : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct173Main
	{
		private long vTable;

		private long ownerNetworkObject;

		public long struct174Extra;

		public byte tier;

		public byte mapSeries;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private byte byte_4;

		private byte byte_5;

		private long intptr_0;

		private byte byte_6;

		private byte byte_7;

		private byte byte_8;

		private byte byte_9;

		private byte byte_10;

		private byte byte_11;

		private byte byte_12;

		private byte byte_13;

		private long intptr_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct174Extra
	{
		private long vTable;

		private long intptr_1;

		public long DataMapsFileAddress;

		private long DataMapsFileKey;

		public long DatWorldAreaAddress;

		private long DatWorldAreaKey;

		private long intptr_6;

		private long intptr_7;

		public NativeStringWCustom nativeStringW_0;

		private int int_0MapTier;

		private int unusedInt0;

		private int int_1MapSeries;
	}

	private PerFrameCachedValue<Struct173Main> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct174Extra> perFrameCachedValue_2;

	public int MapLevel => Area.MonsterLevel;

	public DatWorldAreaWrapper Area => Dat.GetWorldArea(Struct174_0.DatWorldAreaAddress, bool_0: true);

	internal long WorldAreaAddress => Struct174_0.DatWorldAreaAddress;

	internal long MapsFileAddress => Struct174_0.DataMapsFileAddress;

	public InventoryTabMapSeries MapSeries => (InventoryTabMapSeries)Struct173_0.mapSeries;

	public int MapTier => Struct173_0.tier;

	public string _28 => Containers.StdStringWCustom(Struct174_0.nativeStringW_0);

	internal Struct173Main Struct173_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct173Main>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct174Extra Struct174_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct174Extra>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	private Struct173Main method_1()
	{
		return base.M.FastIntPtrToStruct<Struct173Main>(base.Address);
	}

	private Struct174Extra method_2()
	{
		return base.M.FastIntPtrToStruct<Struct174Extra>(Struct173_0.struct174Extra);
	}
}
