using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class SanctumArchivesElement : Element
{
	public class SanctumRoom : Element
	{
		private StructSanctumRoom StructSanctumRoom_0 => LokiPoe.Memory.FastIntPtrToStruct<StructSanctumRoom>(LokiPoe.Memory.ReadLong(base.Address + 784L));

		private StructSanctumRoom StructSanctumRoom_1 => LokiPoe.Memory.FastIntPtrToStruct<StructSanctumRoom>(LokiPoe.Memory.ReadLong(base.Address + 800L));

		private long SanctumPersistentEffects => LokiPoe.Memory.ReadLong(base.Address + 816L);

		private StructSanctumFloors StructSanctumFloors_0 => LokiPoe.Memory.FastIntPtrToStruct<StructSanctumFloors>(StructSanctumRoom_0.intptrSanctumFloorsData);

		private StructSanctumFloors StructSanctumFloors_1 => LokiPoe.Memory.FastIntPtrToStruct<StructSanctumFloors>(StructSanctumRoom_1.intptrSanctumFloorsData);

		private long DeferRewardAddress1 => LokiPoe.Memory.ReadLong(base.Address + 840L);

		private long DeferRewardAddress2 => LokiPoe.Memory.ReadLong(base.Address + 856L);

		private long DeferRewardAddress3 => LokiPoe.Memory.ReadLong(base.Address + 872L);

		public string DeferReward1 => LokiPoe.Memory.ReadStringU(LokiPoe.Memory.ReadLong(DeferRewardAddress1 + 16L));

		public string DeferReward2 => LokiPoe.Memory.ReadStringU(LokiPoe.Memory.ReadLong(DeferRewardAddress2 + 16L));

		public string DeferReward3 => LokiPoe.Memory.ReadStringU(LokiPoe.Memory.ReadLong(DeferRewardAddress3 + 16L));

		public string PersistentEffectStatType => LokiPoe.Memory.ReadStringU(LokiPoe.Memory.ReadLong(SanctumPersistentEffects));

		public string PersistentEffectName => LokiPoe.Memory.ReadStringU(LokiPoe.Memory.ReadLong(SanctumPersistentEffects + 40L));

		public string Id0 => LokiPoe.Memory.ReadStringU(StructSanctumRoom_0.Id);

		public string Id1 => LokiPoe.Memory.ReadStringU(StructSanctumRoom_1.Id);

		public string Metadata0 => LokiPoe.Memory.ReadStringU(StructSanctumRoom_0.Metadata);

		public string Metadata1 => LokiPoe.Memory.ReadStringU(StructSanctumRoom_0.Metadata);

		public string ContainDescription0 => LokiPoe.Memory.ReadStringU(StructSanctumFloors_0.intptrContainDescription);

		public string ContainDescription1 => LokiPoe.Memory.ReadStringU(StructSanctumFloors_0.intptrContainDescription);
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructSanctumRoom
	{
		public long Id;

		public long Metadata;

		public long intptrSanctumRoomsTypeData;

		public long intptrSanctumRoomsTypeFile;

		public long intptr_4;

		public long intptrSanctumFloorsData;

		public long intptrSanctumFloorsFile;

		public long intptr_7;

		public long intptr_8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructSanctumRoomsType
	{
		public long intptr_ID;

		public byte byte_0;

		public byte byte_1;

		public long intptr_1DataSessionQuestFlagsData;

		public long intptr_2DataSessionQuestFlagsFile;

		public long intptr_3DataSessionQuestFlagsData;

		public long intptr_4DataSessionQuestFlagsFile;

		public int int_0;

		public byte byte_2;

		public long intptr_5;

		public byte byte_3;

		public long intptr_6;

		public int int_1;

		public int int_2;

		public long intptr_7RoomTitle;

		public int int_3;

		public int int_4;

		public long intptr_8Achievements;

		public long intptr_9;

		public byte byte_4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructSanctumFloors
	{
		public long Id;

		public long WorldAreaData;

		public long WorldAreaFile;

		public long ClientStringsData;

		public long ClientStringsFile;

		public long ArtFile1;

		public long ArtFile2;

		public long intptrContainDescription;

		public long ClientStringsData1;

		public long ClientStringsFile1;
	}

	public Element ActualCurrencyPannel => base.Children[1];

	public Element MainPannel => base.Children[0].Children[0];

	public Element RoomsTree => MainPannel.Children[0];

	public Element RoomsColumns => RoomsTree.Children[1];

	public Dictionary<int, List<SanctumRoom>> Rooms
	{
		get
		{
			Dictionary<int, List<SanctumRoom>> dictionary = new Dictionary<int, List<SanctumRoom>>();
			int num = 1;
			foreach (Element child in RoomsColumns.Children)
			{
				if (!dictionary.ContainsKey(num))
				{
					dictionary.Add(num, new List<SanctumRoom>());
				}
				foreach (Element child2 in child.Children)
				{
					dictionary[num].Add(LokiPoe.Memory.GetObject<SanctumRoom>(child2.Address));
				}
				num++;
			}
			return dictionary;
		}
	}

	public Element Resolver => MainPannel.Children[1];

	public Element StoreRoomForLater => MainPannel.Children[2];

	public Element RelicEffects => MainPannel.Children[3];
}
