using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects.Labyrinth;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class IngameData : RemoteMemoryObject
{
	public class PortalObject : RemoteMemoryObject
	{
		public const int StructSize = 56;

		public NetworkObject NetworkObject => LokiPoe.ObjectManager.GetObjectById(Id);

		public long Id => base.M.ReadInt(base.Address);

		public string OwnerName => GetObject<NativeStringReader>(base.Address + 8L).Value;

		public DatWorldAreaWrapper Area => Dat.LookupWorldAreaByworldAreaId(base.M.ReadUShort(base.Address + 44L));

		public override string ToString()
		{
			return OwnerName + " => " + Area.Name;
		}
	}

	private class Data
	{
		private long Address;

		private Memory M;

		private PerFrameCachedValue<StructInGameData> perFrameCachedStructInGameData;

		private static int _structInGameDataSize = -1;

		private StructInGameData CachedStructInGameData
		{
			get
			{
				if (perFrameCachedStructInGameData == null)
				{
					perFrameCachedStructInGameData = new PerFrameCachedValue<StructInGameData>(method_2);
				}
				return perFrameCachedStructInGameData.Value;
			}
		}

		public AreaTemplate CurrentArea => new AreaTemplate(CachedStructInGameData.intPtr_5CurrentArea);

		public DatWorldAreaWrapper CurrentWorldArea => Dat.GetWorldArea(CachedStructInGameData.intPtr_5CurrentArea);

		public long CurrentWorldAreaAddress => CachedStructInGameData.intPtr_5CurrentArea;

		public int CurrentAreaLevel => CachedStructInGameData.byte_0CurrentAreaLevel;

		public uint CurrentAreaHash => CachedStructInGameData.int_2CurrentAreaHash;

		public EntityWrapper LocalPlayer => LocalPlayerReal2;

		private EntityWrapper LocalPlayerReal2 => new EntityWrapper(LocalPlayerRealArd);

		public long LocalPlayerRealArd => CachedStructInGameData.intPtr_31LocalPlayerReal;

		public long ServerDataAddress => CachedStructInGameData.intPtr_SERVERDATA;

		public NativeMap SmallEntityList => CachedStructInGameData.SmallEntityList;

		public long SmallEntityListIntPtr => Address + 2056L;

		public NativeVector AreaGGGStatsType => CachedStructInGameData.nativeVectorAreaGGGStatType;

		public NativeVector SpecialAreaGGGStatsType => CachedStructInGameData.nativeVectorSpecialAreaGGGStatType;

		public NativeMap FullEntityList => CachedStructInGameData.FullEntityList;

		public long LabDataPtr => CachedStructInGameData.intPtr_3_2LabPtr;

		public LabyrinthData LabyrinthData
		{
			get
			{
				if (LabDataPtr != 0L)
				{
					return new LabyrinthData(LabDataPtr);
				}
				return null;
			}
		}

		public List<PortalObject> TownPortals => M.ReadStructsArray<PortalObject>(CachedStructInGameData.intPtr_47TownPortals.First, CachedStructInGameData.intPtr_47TownPortals.Last, 56, 20);

		public Data(long address, Memory m)
		{
			Address = address;
			M = m;
			_structInGameDataSize = MarshalCache<StructInGameData>.Size;
		}

		private StructInGameData method_2()
		{
			if (_structInGameDataSize == -1)
			{
				_structInGameDataSize = MarshalCache<StructInGameData>.Size;
			}
			return M.FastIntPtrToStruct<StructInGameData>(Address, _structInGameDataSize);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructInGameData
	{
		private long intPtr_vTable;

		private long intPtr_1;

		private long intPtr_2;

		private long intPtr_3;

		private long intPtr_3plus;

		private long intPtr_4plus;

		private byte byte_01;

		private byte byte_02;

		private byte byte_03;

		private byte byte_04;

		private byte byte_05;

		private byte byte_06;

		private byte byte_07;

		private byte byte_08;

		private long intPtr_31;

		private long intPtr_32;

		private long intPtr_3_1;

		public long intPtr_3_2LabPtr;

		private long intPtr_3_3;

		private long intPtr_3_4;

		private long intPtr_3_5;

		private long intPtr_4;

		private long intPtr_4_1;

		private long intPtr_4_2;

		public long intPtr_5CurrentArea;

		private long intPtr_6DatWorldAreas;

		public long intPtr_5CurrentAreaLeagueChances;

		private long intPtr_6DatWorldAreaLeagueChances;

		public byte byte_0CurrentAreaLevel;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int int_0;

		private long intPtr_13;

		private NativeVector nativeVector0;

		private long intPtr_10;

		private long intPtr_11;

		private long intPtr_12;

		private uint int_1Filler;

		public uint int_2CurrentAreaHash;

		private long intPtr_18;

		private long vTable_1;

		public NativeVector nativeVectorAreaGGGStatType;

		private long vTable_2;

		public NativeVector nativeVectorSpecialAreaGGGStatType;

		private long intPtr_0_0;

		private long intPtr_1_0;

		private long intPtr_26LabDataPtrNew;

		private long intPtr_3_0;

		private long intPtr_4_0;

		private long intPtr_5_0;

		private long intPtr_6_0;

		private long intPtr_7_0;

		private long intPtr_8_0;

		private StructInGameDataFiller10Long Filler_2;

		private StructInGameDataFiller10Long Filler_3;

		private StructInGameDataFiller10Long Filler_4;

		private StructInGameDataFiller10Long Filler_5;

		private StructInGameDataFiller10Long Filler_6;

		private StructInGameDataFiller10Long Filler_7;

		private StructInGameDataFiller10Long Filler_8;

		private StructInGameDataFiller10Long Filler_9;

		private StructInGameDataFiller10Long Filler_10;

		private StructInGameDataFiller10Long Filler_11;

		private StructInGameDataFiller10Long Filler_12;

		private StructInGameDataFiller10Long Filler_13;

		private StructInGameDataFiller10Long Filler_14;

		private StructInGameDataFiller10Long Filler_141;

		private StructInGameDataFiller10Long Filler_142;

		private long intPtr_1000;

		private long intPtr_2000;

		private long intPtr_3000;

		private long intPtr_4000;

		private long intPtr_5000;

		private long intPtr_6000;

		private long intPtr_6001;

		private long intPtr_6002;

		private long intPtr_6003;

		private long intPtr_6004;

		private long intPtr_6005;

		private long intPtr_6006;

		private long intPtr_6007;

		private long intPtr_6008;

		private long intPtr_6009;

		private long intPtr_6010;

		private long intPtr_6011;

		private long intPtr_6012;

		private long intPtr_6013;

		private long intPtr_6014;

		private long intPtr_6015;

		private long intPtr_6016;

		private NativeVector nativeVector3;

		private NativeVector nativeVector4;

		private NativeVector nativeVector5;

		public NativeVector nativeVector6_HellscapeAreaMods;

		private long intPtr_6019;

		private long intPtr_6020;

		private long intPtr_6021;

		public long intPtr_SERVERDATA;

		public long intPtr_31LocalPlayerReal;

		private long intPtr_35;

		private StructInGameDataFiller10Long Filler_15;

		private StructInGameDataFiller10Long Filler_16;

		public NativeMap SmallEntityList;

		private int NativeMap_0ender;

		public NativeMap FullEntityList;

		private int NativeMap_1ender;

		private StructInGameDataFiller10Long Filler_17;

		private StructInGameDataFiller10Long Filler_18;

		private long intPtr_44_0;

		private long intPtr_44;

		private long intPtr_45;

		private long intPtr_46;

		private long intPtr_47;

		private long intPtr_48;

		private long intPtr_49;

		private long intPtr_50;

		private long intPtr_51;

		public NativeVector intPtr_47TownPortals;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructInGameDataFiller10Long
	{
		public long intPtr_0;

		public long intPtr_1;

		public long intPtr_2;

		public long intPtr_3;

		public long intPtr_4;

		public long intPtr_5;

		public long intPtr_6;

		public long intPtr_7;

		public long intPtr_8;

		public long intPtr_9;
	}

	private PerFrameCachedValue<Data> perFrameCachedData;

	public AreaTemplate CurrentArea => IngameDataCache.CurrentArea;

	public DatWorldAreaWrapper CurrentWorldArea => IngameDataCache.CurrentWorldArea;

	public long CurrentWorldAreaAddress => IngameDataCache.CurrentWorldAreaAddress;

	public int CurrentAreaLevel => IngameDataCache.CurrentAreaLevel;

	public uint CurrentAreaHash => IngameDataCache.CurrentAreaHash;

	public EntityWrapper LocalPlayer => IngameDataCache.LocalPlayer;

	public long LocalPlayerRealArd => IngameDataCache.LocalPlayerRealArd;

	public long ServerDataAddress => IngameDataCache.ServerDataAddress;

	public NativeMap FullEntityListAdr => IngameDataCache.FullEntityList;

	public NativeMap SmallEntityListAdr => IngameDataCache.SmallEntityList;

	public long SmallEntityListIntPtr => IngameDataCache.SmallEntityListIntPtr;

	public NativeVector AreaGGGStatsType => IngameDataCache.AreaGGGStatsType;

	public NativeVector SpecialAreaGGGStatsType => IngameDataCache.SpecialAreaGGGStatsType;

	internal long LabDataPtr => IngameDataCache.LabDataPtr;

	public LabyrinthData LabyrinthData => IngameDataCache.LabyrinthData;

	public List<PortalObject> TownPortals => IngameDataCache.TownPortals;

	private Data IngameDataCache => new Data(base.Address, base.M);

	private Data method_1()
	{
		return new Data(base.Address, base.M);
	}

	public void UpdateAddress(long l)
	{
		base.Address = l;
	}
}
