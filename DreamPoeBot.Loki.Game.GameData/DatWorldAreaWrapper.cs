using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatWorldAreaWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct327
	{
		public long Id;

		public long NamePtr;

		public int Act;

		public byte IsTown;

		public byte HasWaypoint;

		public int ConnectionsIdCount;

		private int unusedInt0;

		public long WorldAreaWrapper;

		public int MonsterLevel;

		public int WorldAreaId;

		private int int_4;

		private int int_5;

		private long LoadingScreenDDSFile;

		private int int_6;

		private int int_7;

		private int unusedInt1;

		private long TopologiesKeys;

		private int int_8;

		private int int_9;

		private int unusedInt2;

		private long intptr_5;

		private long intptr_6;

		private int int_10;

		private int int_11;

		private int int_12;

		private int int_13;

		private int unusedInt3;

		private long intptr_7;

		private int int_14;

		private int unusedInt4;

		private long intptr_8;

		private int int_15;

		private int unusedInt5;

		private long intptr_9;

		private int int_16;

		private int unusedInt6;

		private long intptr_10;

		private int int_199;

		private int int_299;

		private int int_399;

		private int int_499;

		private long long799;

		private long long899;

		private int int_599;

		public byte IsMap;

		private int int_17;

		private int unusedInt7;

		private long intptr_11;

		private int int_18;

		private int int_19;

		private int int_20;

		private int int_21;

		private int int_22;

		private int unusedInt8;

		private int unusedInt9;

		private int unusedInt10;

		private long intptr_12;

		private int int_23;

		private int int_24;

		public int int_25;

		private int unusedInt11;

		public long CorruptedAreas;

		private int int_26;

		private int int_27;

		private int int_28;

		private int int_29;

		private int unusedInt12;

		private long intptr_14;

		private int int_30;

		private byte byte_3;

		private int int_31;

		private int int_32;

		private int unusedInt13;

		private long intptr_15;

		private int int_33;

		private int int_34;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private int int_35;

		private int int_36;

		private int int_37;

		private byte byte_8;

		private long intptr_16;

		private int int_38;

		private int int_39;

		private int int_40;

		private int int_41;

		private int unusedInt14;

		private long intptr_17;

		private byte byte_9;

		private int int_42;

		private int int_43;

		private int int_44;

		private byte byte_10;

		private byte byte_11;

		private int unusedInt15;

		private Struct243 struct243_0;

		private int int_45;

		private int int_46;

		private int int_47;

		private int int_48;

		private int int_49;

		private int unusedInt16;

		private long intptr_18;

		private int int_50;

		private int int_51;

		private int int_52;

		private int int_53;

		private int int_54;

		private int int_55;

		private int unusedInt17;

		private int unusedInt18;

		private int unusedInt19;

		private long intptr_19;

		private int int_56;

		private int int_57;

		private int int_58;

		private byte byte_12;

		private byte byte_13;

		private int unusedInt20;

		private long intptr_20;

		private int int_59;

		private int int_60;

		private int int_61;

		private int int_62;

		private int unusedInt21;

		private int unusedInt22;

		private short unusedInt23;

		private long long998;

		private long long999;

		private long long992;

		private int int_99;

		private long long993;

		private long long994;

		private long long1997;

		private long long1998;
	}

	private List<DatWorldAreaWrapper> list_0;

	private List<DatWorldAreaWrapper> list_1;

	public long IntPtr_0 { get; private set; }

	public int Index { get; private set; }

	public string Id { get; private set; }

	public string Name { get; private set; }

	public int Act { get; private set; }

	public bool IsTown { get; private set; }

	public bool HasWaypoint { get; private set; }

	public bool IsMap { get; private set; }

	public bool IsAtlasMap { get; private set; }

	public bool IsMapWorlds { get; private set; }

	public bool IsCorruptedArea { get; private set; }

	public bool IsMissionArea { get; private set; }

	public bool IsDenArea { get; private set; }

	public bool IsDailyArea { get; private set; }

	public bool IsRelicArea { get; private set; }

	public bool IsHideoutArea { get; private set; }

	public bool IsMyHideoutArea
	{
		get
		{
			if (this != null && IsHideoutArea)
			{
				return GameController.Instance.Game.IngameState.IngameUi.HudUI.HideoutMainControl.IsVisible;
			}
			return false;
		}
	}

	public bool IsLabyrinthArea { get; private set; }

	public bool IsMenagerieArea { get; private set; }

	public bool IsMapRoom { get; private set; }

	public bool IsMapTrialArea { get; private set; }

	public bool IsAbyssArea { get; private set; }

	public bool IsOverworldArea { get; private set; }

	public int WorldAreaId { get; private set; }

	public int MonsterLevel { get; private set; }

	public bool IsCombatArea { get; private set; }

	public bool IsTempleOfAtzoatl { get; private set; }

	private List<DatWorldAreaWrapper> ConnectionsList { get; set; }

	private List<DatWorldAreaWrapper> CorruptedAreaslist { get; set; }

	public DatWorldAreaWrapper GoverningTown { get; set; }

	public List<DatWorldAreaWrapper> Connections
	{
		get
		{
			if (list_1 == null)
			{
				list_1 = new List<DatWorldAreaWrapper>();
				for (int i = 0; i < Struct327_0.ConnectionsIdCount; i++)
				{
					DatWorldAreaWrapper worldArea = Dat.GetWorldArea(ExternalProcessMemory_0.ReadLong(Struct327_0.WorldAreaWrapper + i * 8));
					if (worldArea != null)
					{
						list_1.Add(worldArea);
						continue;
					}
					throw new Exception($"A null connection area was returned for {Id}. Please check for structure changes.");
				}
			}
			return list_1;
		}
	}

	public List<DatWorldAreaWrapper> CorruptedAreas
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = new List<DatWorldAreaWrapper>();
				for (int i = 0; i < Struct327_0.int_25; i++)
				{
					DatWorldAreaWrapper worldArea = Dat.GetWorldArea(ExternalProcessMemory_0.ReadLong(Struct327_0.CorruptedAreas + i * 8));
					if (worldArea != null)
					{
						list_0.Add(worldArea);
						continue;
					}
					throw new Exception($"A null corrupted area was returned for {Id}. Please check for structure changes.");
				}
			}
			return list_0;
		}
	}

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct327 Struct327_0 { get; set; }

	public DatWorldAreaWrapper(string id)
	{
		DatWorldAreaWrapper datWorldAreaWrapper = Dat.LookupWorldArea(id);
		IntPtr_0 = datWorldAreaWrapper.IntPtr_0;
		MonsterLevel = datWorldAreaWrapper.MonsterLevel;
		Id = datWorldAreaWrapper.Id;
		string text = datWorldAreaWrapper.Id.ToLowerInvariant();
		Name = datWorldAreaWrapper.Name;
		Act = datWorldAreaWrapper.Act;
		IsTown = text.Contains("_town");
		HasWaypoint = datWorldAreaWrapper.HasWaypoint;
		IsMap = datWorldAreaWrapper.IsMapWorlds;
		IsAtlasMap = text.StartsWith("mapatlas");
		IsMapWorlds = text.StartsWith("mapworlds");
		IsCorruptedArea = text.Contains("sidearea");
		IsMissionArea = text.Contains("_mission");
		IsDenArea = text.Contains("_den");
		IsDailyArea = text.Contains("_daily");
		IsRelicArea = text.Contains("_relic");
		IsHideoutArea = text.Contains("hideout");
		IsMenagerieArea = text.Contains("menagerie_hub");
		IsMapRoom = Id.Contains("_3_8_4") || Id.Contains("Daily3_1") || Id.Contains("2_11_lab");
		IsMapTrialArea = Id.StartsWith("EndGame_Labyrinth_trials");
		IsLabyrinthArea = !IsMapTrialArea && Id.Contains("Labyrinth") && !Id.Contains("Labyrinth_Airlock");
		IsAbyssArea = Id.Equals("AbyssLeague") || Id.Equals("AbyssLeague2") || Id.Equals("AbyssLeagueBoss") || Id.Equals("AbyssLeagueBoss2") || Id.Equals("AbyssLeagueBoss3");
		IsTempleOfAtzoatl = text.StartsWith("incursion_temple");
		if (IsTempleOfAtzoatl)
		{
			IsMap = false;
		}
		IsCombatArea = !IsTown && !IsHideoutArea && !IsMapRoom;
		IsOverworldArea = false;
		string[] array = Id.Split('_');
		if (array.Length >= 3)
		{
			if (array[0] == "1")
			{
				if ((array[1] == "1" || array[1] == "2" || array[1] == "3" || array[1] == "4" || array[1] == "5") && array[2] != "town")
				{
					IsOverworldArea = true;
				}
			}
			else if (array[0] == "2" && (array[1] == "6" || array[1] == "7" || array[1] == "8" || array[1] == "9" || array[1] == "10" || array[1] == "11") && array[2] != "town")
			{
				IsOverworldArea = true;
			}
		}
		WorldAreaId = datWorldAreaWrapper.WorldAreaId;
		if (Id == "2_11_endgame_town")
		{
			GoverningTown = null;
			return;
		}
		DatWorldAreaWrapper datWorldAreaWrapper2 = datWorldAreaWrapper.Connections.FirstOrDefault((DatWorldAreaWrapper x) => x.IsTown);
		if (datWorldAreaWrapper2 == null)
		{
			GoverningTown = null;
		}
		else
		{
			GoverningTown = new DatWorldAreaWrapper(datWorldAreaWrapper2.Id);
		}
	}

	public int GetMapTierPerVoidstone(int nrOfVoidStone)
	{
		if (!IsMap)
		{
			return MonsterLevel;
		}
		AtlasNode atlasNode = Dat.AtlasNodes.FirstOrDefault((AtlasNode x) => x.WorldArea.Index == Index);
		if (!(atlasNode == null))
		{
			if (nrOfVoidStone >= 0 && nrOfVoidStone <= 4)
			{
				return nrOfVoidStone switch
				{
					0 => atlasNode.Tier0, 
					1 => atlasNode.Tier1, 
					2 => atlasNode.Tier2, 
					3 => atlasNode.Tier3, 
					4 => atlasNode.Tier4, 
					_ => atlasNode.Tier0, 
				};
			}
			return atlasNode.Tier0;
		}
		return MonsterLevel;
	}

	private void method_0(Struct327 struct327_1)
	{
		Struct327_0 = struct327_1;
		MonsterLevel = Struct327_0.MonsterLevel;
		Id = ExternalProcessMemory_0.ReadStringU(Struct327_0.Id);
		string text = Id.ToLowerInvariant();
		Name = ExternalProcessMemory_0.ReadStringU(Struct327_0.NamePtr);
		Act = Struct327_0.Act;
		IsTown = Struct327_0.IsTown == 1;
		HasWaypoint = Struct327_0.HasWaypoint == 1;
		IsMap = Struct327_0.IsMap == 1;
		IsAtlasMap = text.StartsWith("mapatlas");
		IsMapWorlds = text.StartsWith("mapworlds");
		IsCorruptedArea = text.Contains("sidearea");
		IsMissionArea = text.Contains("_mission");
		IsDenArea = text.Contains("_den");
		IsDailyArea = text.Contains("_daily");
		IsRelicArea = text.Contains("_relic");
		IsHideoutArea = text.Contains("hideout");
		IsMenagerieArea = text.Contains("menagerie_hub");
		IsMapRoom = Id.Contains("_3_8_4") || Id.Contains("Daily3_1") || Id.Contains("2_11_lab");
		IsMapTrialArea = Id.StartsWith("EndGame_Labyrinth_trials");
		IsLabyrinthArea = !IsMapTrialArea && Id.Contains("Labyrinth") && !Id.Contains("Labyrinth_Airlock");
		IsAbyssArea = Id.Equals("AbyssLeague") || Id.Equals("AbyssLeague2") || Id.Equals("AbyssLeagueBoss") || Id.Equals("AbyssLeagueBoss2") || Id.Equals("AbyssLeagueBoss3");
		IsTempleOfAtzoatl = text.StartsWith("incursion_temple");
		if (IsTempleOfAtzoatl)
		{
			IsMap = false;
		}
		IsCombatArea = !IsTown && !IsHideoutArea && !IsMapRoom;
		IsOverworldArea = false;
		string[] array = Id.Split('_');
		if (array.Length >= 3)
		{
			if (array[0] == "1")
			{
				if ((array[1] == "1" || array[1] == "2" || array[1] == "3" || array[1] == "4" || array[1] == "5") && array[2] != "town")
				{
					IsOverworldArea = true;
				}
			}
			else if (array[0] == "2" && (array[1] == "6" || array[1] == "7" || array[1] == "8" || array[1] == "9" || array[1] == "10" || array[1] == "11") && array[2] != "town")
			{
				IsOverworldArea = true;
			}
		}
		WorldAreaId = Struct327_0.WorldAreaId;
	}

	internal DatWorldAreaWrapper(long address, Struct327 native, int index)
	{
		IntPtr_0 = address;
		Index = index;
		method_0(native);
	}

	internal DatWorldAreaWrapper(long ptr)
	{
		IntPtr_0 = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct327>(IntPtr_0));
	}

	public override string ToString()
	{
		_ = Struct327_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"WorldArea:");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tId: {Id}");
		stringBuilder.AppendLine($"\tAct: {Act}");
		stringBuilder.AppendLine($"\tHasWaypoint: {HasWaypoint}");
		stringBuilder.AppendLine($"\tBaseMonsterLevel: {MonsterLevel}");
		stringBuilder.AppendLine($"\t");
		stringBuilder.AppendLine($"\tIsTown: {IsTown}");
		stringBuilder.AppendLine($"\tIsHideoutArea: {IsHideoutArea}");
		stringBuilder.AppendLine($"\tIsMyHideoutArea: {IsMyHideoutArea}");
		stringBuilder.AppendLine($"\tIsCombatArea: {IsCombatArea}");
		stringBuilder.AppendLine($"\tIsCorruptedArea: {IsCorruptedArea}");
		stringBuilder.AppendLine($"\tIsDenArea: {IsDenArea}");
		stringBuilder.AppendLine($"\tIsLabyrinthArea: {IsLabyrinthArea}");
		stringBuilder.AppendLine($"\tIsMap: {IsMap}");
		stringBuilder.AppendLine($"\tIsMapRoom: {IsMapRoom}");
		stringBuilder.AppendLine($"\tIsMapTrialArea: {IsMapTrialArea}");
		stringBuilder.AppendLine($"\tIsMapWorlds: {IsMapWorlds}");
		stringBuilder.AppendLine($"\tIsAtlasMap: {IsAtlasMap}");
		stringBuilder.AppendLine($"\tIsMenagerieArea: {IsMenagerieArea}");
		stringBuilder.AppendLine($"\tIsOverworldArea: {IsOverworldArea}");
		stringBuilder.AppendLine($"\tIsRelicArea: {IsRelicArea}");
		stringBuilder.AppendLine($"\tIsTempleOfAtzoatl: {IsTempleOfAtzoatl}");
		stringBuilder.AppendLine($"\tIsDailyArea: {IsDailyArea}");
		stringBuilder.AppendLine($"\tIsAbyssArea: {IsAbyssArea}");
		return stringBuilder.ToString();
	}
}
