using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Framework;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using JetBrains.Annotations;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ServerData : RemoteMemoryObject
{
	public enum PartyAllocation : byte
	{
		FreeForAll,
		ShortAllocation,
		PermanentAllocation,
		None
	}

	private class Data
	{
		private long Address;

		private Memory M;

		internal float ScourgeGauge => M.ReadFloat(Address + 39928L + PatchOffset);

		internal int CrucibileExprience => M.ReadInt(Address + 40760L + PatchOffset);

		public Data(long address, Memory m)
		{
			Address = address;
			M = m;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct AffinitiesStructure
	{
		public long intptr_0;

		public long intptr_1;

		public int SpecializedStash;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructRitualMain
	{
		public long StructRitualData;

		public int AvailableRitualsInZone;

		public int CompletedRitualsInZone;

		private NativeVector UnknownVector;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructRitualData
	{
		public NativeVector DeferedItemsVector;

		public int CurrentTributes;

		private int filler1;

		private int filler2;

		private int filler3;

		private int filler4_PossibleRitualLeft;

		private int filler5;

		private int filler6;

		private int filler7;

		private int filler8;

		private int filler9;

		private int filler10;

		private int filler11;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructServerDataExtra
	{
		private long unused_3;

		private long unused_4;

		private long unused_5;

		private long unused_6;

		private long unused_7;

		private long unused_8;

		private long unused_9;

		private long unused_10;

		private long unused_11;

		private long unused_12;

		private long unused_13;

		private long unused_14;

		private long unused_15;

		private long unused_16;

		private long unused_17;

		private long unused_18;

		private long unused_19;

		private long unused_20;

		private long unused_21;

		private long unused_22;

		private long unused_23;

		private long unused_24;

		private long unused_25;

		private long unused_26;

		private long unused_27;

		private long unused_28;

		private long unused_29;

		private long unused_30;

		private long unused_31;

		private long unused_32;

		private long unused_33;

		private long unused_34;

		private long unused_35;

		private long unused_36;

		private long unused_37;

		private long unused_38;

		private long unused_39;

		private long unused_40;

		private long unused_41;

		private long unused_42;

		private long unused_43;

		private long unused_44;

		private long unused_45;

		private long unused_46;

		private long unused_47;

		private long unused_48;

		private long passiveSkillGraphPSG;

		private long passiveSkillTreesDat;

		private long passiveSkillTreesDatFile;

		private long unused_49;

		public NativeVector Psif;

		public NativeVector jewels;

		public NativeVector UnknownNativeVector0;

		public NativeVector jewelsPassive;

		public NativeVector MasteryPassive;

		public NativeVector UnknownNativeVector2;

		private long unused_700;

		private long unused_800;

		private long unused_701;

		private long unused_801;

		private long unused_802;

		public byte PlayerClass;

		private byte unusedByte_0;

		private byte unusedByte_1;

		private byte unusedByte_2;

		public int PlayerLevel;

		public int Prp;

		public int Qpsp;

		public int Fpspl;

		public int Tap;

		public int Sap;

		private short short1;

		private short short2;

		private int int5;

		private int int6;

		private NativeHashMap nativeHashMap;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructAtlasDataExtra
	{
		private long unused_3;

		private long unused_4;

		private long unused_5;

		private long unused_6;

		private long unused_7;

		private long unused_8;

		private long unused_9;

		private long unused_10;

		private long unused_11;

		private long unused_12;

		private long unused_13;

		private long unused_14;

		private long unused_15;

		private long unused_16;

		private long unused_17;

		private long unused_18;

		private long unused_19;

		private long unused_20;

		private long unused_21;

		private long unused_22;

		private long unused_23;

		private long unused_24;

		private long unused_25;

		private long unused_26;

		private long unused_27;

		private long unused_28;

		private long unused_29;

		private long unused_30;

		private long unused_31;

		private long unused_32;

		private long unused_33;

		private long unused_34;

		private long unused_35;

		private long unused_36;

		private long unused_37;

		private long unused_38;

		private long unused_39;

		private long unused_40;

		private long unused_41;

		private long unused_42;

		private long unused_43;

		private long unused_44;

		private long unused_45;

		private long atlasSkillGraphPSG;

		public NativeVector Apsif;

		private long unused_46;

		private StructAtlasExtraFtructureFiller filler331Longs;

		public int atlasRefoundPointAvailavle;

		public int totalAtlasPassivePoints;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructServerData
	{
		private long unused_vTable;

		private long unused_196;

		private long unused_197;

		private long unused_198;

		private long unused_199;

		private long unused_200;

		private long unused_201;

		private long unused_202;

		private long unused_203;

		public long structServerDataExtra;

		public long structAtlasDataExtra;

		private long unused_2;

		public byte Nst;

		private byte unusedByte_7;

		private byte unusedByte_8;

		private byte unusedByte_9;

		private byte unusedByte_10;

		private byte unusedByte_11;

		private byte unusedByte_12;

		private byte unusedByte_13;

		private long unused_21;

		private long unused_22;

		private long unused_23;

		private long unused_24;

		public NativeStringWCustom Le;

		private Filler10Struct unused_25;

		private short short_876;

		private short short_877;

		private short short_878;

		private short short_879;

		public uint frames;

		private int unusedInt_1;

		public uint frames2;

		private int unusedInt_21;

		private int unusedInt_23;

		private int unusedInt_24;

		private int unusedInt_28;

		private int unusedInt_29;

		public uint latency;

		private int unusedInt_2;

		public NativeVector Pstf;

		public NativeVector Gstf;

		public NativeHashMap AffinityMapNativeHashMap_34;

		public NativeHashMap GuidStashAffinityMapNativeHashMap_34;

		private byte unusedByte_42;

		public byte ExpeditionLockerAffinity;

		private byte unusedByte_44;

		private byte unusedByte_45;

		private int unusedInt_42;

		private long unused_43;

		private long unused_44;

		private long unused_45;

		private long unused_46;

		private long unused_47;

		private long unused_48;

		private long unused_491;

		private long unused_501;

		private NativeHashMap unusedNativeHashMap_35;

		private long unused_511;

		private long unused_521;

		private long unused_541;

		public NativeVector PendingPartyInviteNativeVector;

		private long unused_9041;

		private long unused_9042;

		private long unused_9043;

		private long unused_9044;

		private long unused_9045;

		private NativeStringWCustom PartyDescription;

		private NativeStringWCustom PartyLeaderAccountName;

		private NativeStringWCustom UnknownString;

		public byte byte_PartyStatusType;

		private byte byte_00;

		private byte byte_01;

		private byte byte_02;

		private int int_000;

		public NativeVector PartyMembersNativeVector;

		public byte byte_pat;

		private byte byte_03;

		private byte byte_04;

		private byte byte_05;

		private int int_001;

		private long unused_136;

		public NativeHashMap PartyMembersNativeHashMap;

		private long unused_80;

		private long unused_81;

		private long unused_82;

		public long long_Gu;

		private long BattlePassData;

		public SkillbarStruct SkillbarIds;

		private ushort unusedShort_1;

		private int MouseX;

		private int MouseY;

		private int unusedInt_99;

		private long unused_990;

		private long unused_991;

		private long unused_992;

		private long unused_993;

		private long unused_84;

		private long unused_85;

		private long unused_86;

		private long unused_87;

		private long unused_88;

		private long unused_89;

		private long unused_90;

		private long unused_91;

		private long unused_914;

		public NativeVector minimapIconNativeVector;

		private Filler10Struct unused_800;

		private Filler10Struct unused_900;

		private Filler10Struct unused_901;

		private Filler10Struct unused_902;

		private Filler10Struct unused_903;

		private Filler10Struct unused_904;

		private Filler10Struct unused_905;

		private long unused_95;

		private long unused_96;

		private long unused_97;

		private long unused_98;

		private long unused_99;

		private long unused_100;

		private long unused_101;

		private long unused_102;

		private long unused_103;

		private long unused_104;

		private long unused_105;

		private long unused_106;

		private long unused_107;

		public NativeVector vector_Pif;

		private long unused_1004;

		private NativeVector unknown_vector_99;

		private Filler10Struct unused_1040;

		private Filler10Struct unused_182;

		private Filler10Struct unused_192;

		private Filler10Struct unused_193;

		private Filler10Struct unused_194;

		private Filler10Struct unused_1961;

		private Filler10Struct unused_1971;

		private long unused_2102;

		private long unused_2103;

		private long unused_2104;

		private long unused_2105;

		private long unused_2106;

		private long unused_2107;

		private long unused_2118;

		private long unused_2119;

		private long unused_2120;

		public NativeVector vector_Tif;

		private long unused_2108;

		private NativeVector unknown_vector_991;

		private Filler10Struct unused_391;

		private Filler10Struct unused_3101;

		private Filler10Struct unused_3102;

		private Filler10Struct unused_3103;

		private Filler10Struct unused_3104;

		private Filler10Struct unused_3105;

		private Filler10Struct unused_3106;

		private long unused_981;

		private long unused_982;

		private long unused_983;

		private long unused_984;

		private long unused_985;

		private long unused_986;

		private long unused_987;

		private long unused_988;

		private long unused_989;

		public NativeVector vector_Gif;

		private long unused_591;

		private long unused_492;

		private long unused_493;

		private long unused_4912;

		private byte unused_494;

		public byte byte_weaponSet;

		private byte unused_594;

		private byte unused_694;

		private int unused_794;

		private int int_893;

		private int int_894;

		private byte byte_894;

		private byte byte_895;

		public byte byte_IsCapturedMonstersDataLoaded;

		public byte byte_IsBestiaryActive;

		private byte byte_896;

		private byte byte_897;

		private byte byte_898;

		private byte byte_899;

		private Filler10Struct unused_495;

		private long unused_4105;

		private long unused_4106;

		private long unused_4107;

		private long unused_4108;

		private long unused_4109;

		private long unused_4110;

		private long unused_4111;

		private long unused_890;

		private long unused_891;

		private long unused_892;

		private long unused_894;

		private long unused_895;

		private long unused_896;

		private long unused_897;

		private long unused_898;

		private long unused_899;

		private Filler10Struct Filler18;

		private Filler10Struct Filler29;

		private Filler10Struct Filler281;

		private long unused_880;

		private long unused_881;

		public ushort LastActionId;

		private ushort unusedUShort_07;

		private int unusedInt_10;

		private long unused_59;

		private long unused_60;

		private long unused_61;

		private long unused_62;

		private long unused_63;

		private long unused_64;

		public NativeVector SextantDataVector;

		public NativeHashMap TheMavenHoldaRecreationofthisMap;

		public NativeHashMap ShapedAreasAddress;

		public NativeHashMap BonusCompletedAreasAddress;

		public NativeHashMap AwakeningBonusCompletgedAreasAddress;

		private NativeVector NativeVector_unused_67;

		public NativeVector NativeVector_Memoryes;

		private short AtlasMasterUnused0;

		public short AtlasMasterEinharNormalMissions;

		public short AtlasMasterAlvaNormalMissions;

		private short AtlasMasterUnused1;

		public short AtlasMasterNikoNormalMissions;

		public short AtlasMasterJunNormalMissions;

		public short AtlasMasterZanaNormalMissions;

		private short AtlasMasterUnused2;

		public short AtlasMasterEinharYellowMissions;

		public short AtlasMasterAlvaYellowMissions;

		private short AtlasMasterUnused3;

		public short AtlasMasterNikoYellowMissions;

		public short AtlasMasterJunYellowMissions;

		public short AtlasMasterZanaYellowMissions;

		private short AtlasMasterUnused4;

		public short AtlasMasterEinharRedMissions;

		public short AtlasMasterAlvaRedMissions;

		private short AtlasMasterUnused5;

		public short AtlasMasterNikoRedMissions;

		public short AtlasMasterJunRedMissions;

		public short AtlasMasterZanaRedMissions;

		private byte SocketedWatchstoneRegion1Haewark;

		private byte SocketedWatchstoneRegion7Valdo;

		private byte SocketedWatchstoneRegion6Glennach;

		private byte SocketedWatchstoneRegion8Lira;

		private byte unused100;

		private byte unused101;

		private int unused102;

		public byte NrOfSocketedVoidstones;

		private byte unused_byte103;

		private byte unused_byte104;

		private byte unused_byte105;

		private long WorldAtlasDat0;

		private long unknown_long;

		private long unknown_long1;

		private long unknown_long2;

		private long unknown_long3;

		private NativeVector unknow_vector_96;

		private NativeVector unknow_vector_97;

		private NativeVector unknow_vector_98;

		private NativeVector unknow_vector_99;

		private long filler_0024;

		private long filler_0025;

		private long filler_0026;

		private long filler_0027;

		private long filler_0028;

		private long filler_0029;

		private long filler_0829;

		private long filler_0129;

		private long filler_0229;

		private long filler_0329;

		private long filler_0429;

		private long filler_0529;

		private long filler_0629;

		private long filler_0729;

		public NativeVector Vector_CapturedMonsters;

		public StructUnlockedRecipe struct_unlockedRecipe;

		private NativeVector Vector_unknown;

		private long intptr_unknown1;

		public int int_DialogDepth;

		public byte byte_MonsterLevel;

		public byte byte_MonsterRemaining;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct1000
	{
		public NativeVector Metha;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DelveInfoStruct
	{
		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte ActualFlares;

		public byte ActualExplosives;

		public byte byte_4;

		public byte byte_5;

		public byte byte_11;

		public byte byte_12;

		public int ActualAzurite;

		public byte byte_111;

		public byte byte_121;

		public byte byte_13;

		public byte byte_14;

		public byte byte_15;

		public byte byte_16;

		public byte byte_17;

		public byte byte_18;

		public byte byte_19;

		public byte byte_20;

		public byte byte_21;

		public byte byte_22;

		public short ActualSulfite;

		public short MaxDepth;

		public byte byte_25;

		public byte byte_26;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct SkillbarStruct
	{
		public ushort ushort_0;

		public ushort ushort_1;

		public ushort ushort_2;

		public ushort ushort_3;

		public ushort ushort_4;

		public ushort ushort_5;

		public ushort ushort_6;

		public ushort ushort_7;

		public ushort ushort_8;

		public ushort ushort_9;

		public ushort ushort_10;

		public ushort ushort_11;

		public ushort ushort_12;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct Filler100Struct
	{
		private long unused_80;

		private long unused_81;

		private long unused_82;

		private long unused_83;

		private long unused_84;

		private long unused_85;

		private long unused_86;

		private long unused_87;

		private long unused_88;

		private long unused_89;

		private long unused_90;

		private long unused_91;

		private long unused_92;

		private long unused_93;

		private long unused_94;

		private long unused_95;

		private long unused_96;

		private long unused_97;

		private long unused_98;

		private long unused_99;

		private long unused_100;

		private long unused_101;

		private long unused_102;

		private long unused_103;

		private long unused_104;

		private long unused_105;

		private long unused_106;

		private long unused_107;

		private long unused_108;

		private long unused_109;

		private long unused_110;

		private long unused_111;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct Filler10Struct
	{
		private long unused_80;

		private long unused_81;

		private long unused_82;

		private long unused_83;

		private long unused_84;

		private long unused_85;

		private long unused_86;

		private long unused_87;

		private long unused_88;

		private long unused_89;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct StructUnlockedRecipe
	{
		[FieldOffset(0)]
		public unsafe fixed byte byte_0[112];
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct StructAtlasExtraFtructureFiller
	{
		[FieldOffset(0)]
		public unsafe fixed long long_0[82];
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ArchnemesisModStructure
	{
		public long unused_ArchnemesisModDat;

		public long unused_ArchnemesisModDatFile;

		public int int_ModLevel;

		public short short_0;

		public short short_1;
	}

	private static int _patchOffset = -1;

	private static int _structServerDataSize = -1;

	private static int _structRitualMainSize = -1;

	private static int _structRitualDataSize = -1;

	private static int _delveInfoStructSize = -1;

	private PerFrameCachedValue<StructServerData> perFrame_StructServerData;

	private PerFrameCachedValue<DelveInfoStruct> perFrame_DelveInfoStruct;

	private PerFrameCachedValue<StructRitualMain> perFrameRitualMainStruct;

	private PerFrameCachedValue<StructRitualData> perFrameCachedValue_4;

	private PerFrameCachedValue<StructServerDataExtra> perFrameCachedValue_ServerDataExtra;

	private PerFrameCachedValue<StructAtlasDataExtra> perFrameCachedValue_ServerAtlasDataExtra;

	private PerFrameCachedValue<Struct1000> perFrameCachedValue_2;

	private PerFrameCachedValue<Data> perFrameCachedData;

	internal PerFrameCachedValue<List<ArchnemesisModStructure>> ArchnemesisModInventory_Cache;

	private static int PatchOffset
	{
		get
		{
			if (_patchOffset == -1)
			{
				_patchOffset = WinApi.ex_get_patch_offset();
			}
			return _patchOffset;
		}
	}

	internal float ScourgeGauge => 0f;

	internal int CrucibileExprience => 0;

	public NativeVector CapturedMonsters => StructServerData_0.Vector_CapturedMonsters;

	public byte[] UnlickedRecipes => CopyFixedDoubleArray(StructServerData_0.struct_unlockedRecipe);

	public uint Latency => StructServerData_0.latency;

	public byte IsCapturedMonstersDataLoaded => StructServerData_0.byte_IsCapturedMonstersDataLoaded;

	public byte IsBestiaryActive => StructServerData_0.byte_IsBestiaryActive;

	public NativeVector MinimapIconNativeVector => StructServerData_0.minimapIconNativeVector;

	public uint FrameCount => StructServerData_0.frames;

	public NetworkState NetworkState => (NetworkState)StructServerData_0.Nst;

	public int DialogDepth => StructServerData_0.int_DialogDepth;

	public int SocketedWatchstoneRegion1Haewark => 0;

	public int SocketedWatchstoneRegion2Tirn => 0;

	public int SocketedWatchstoneRegion3Proxima => 0;

	public int SocketedWatchstoneRegion4Ejoris => 0;

	public int SocketedWatchstoneRegion5Vastir => 0;

	public int SocketedWatchstoneRegion6Glennach => 0;

	public int SocketedWatchstoneRegion7Valdo => 0;

	public int SocketedWatchstoneRegion8Lira => 0;

	public int CharacterLevel => ServerDataExtra.PlayerLevel;

	public CharacterClass PlayerClass => (CharacterClass)ServerDataExtra.PlayerClass;

	public int PassiveRefundPointsLeft => ServerDataExtra.Prp;

	public int QuestPassiveSkillPoints => ServerDataExtra.Qpsp;

	public int ScionExtraPassiveSkillPointsLeft => ServerDataExtra.Fpspl;

	public int TotalAscendencyPoints => ServerDataExtra.Tap;

	public int SpentAscendencyPoints => ServerDataExtra.Sap;

	public int AtlasPassiveRefundPointsLeft => ServerAtlasDataExtra.atlasRefoundPointAvailavle;

	public int AtlasPassivePoints => ServerAtlasDataExtra.totalAtlasPassivePoints;

	public List<ushort> PassiveSkillIds
	{
		get
		{
			long first = ServerDataExtra.Psif.First;
			long last = ServerDataExtra.Psif.Last;
			int length = (int)(last - first);
			byte[] array = base.M.ReadBytes(first, length);
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < array.Length; i += 2)
			{
				ushort item = BitConverter.ToUInt16(array, i);
				list.Add(item);
			}
			return list;
		}
	}

	public List<Tuple<ushort, ushort>> PassiveMasterySkillIds
	{
		get
		{
			long first = ServerDataExtra.MasteryPassive.First;
			long last = ServerDataExtra.MasteryPassive.Last;
			int length = (int)(last - first);
			byte[] array = base.M.ReadBytes(first, length);
			List<Tuple<ushort, ushort>> list = new List<Tuple<ushort, ushort>>();
			for (int i = 0; i < array.Length; i += 4)
			{
				ushort item = BitConverter.ToUInt16(array, i);
				ushort item2 = BitConverter.ToUInt16(array, i + 2);
				list.Add(new Tuple<ushort, ushort>(item, item2));
			}
			return list;
		}
	}

	public List<ushort> AtlasPassiveSkillIds
	{
		get
		{
			long first = ServerAtlasDataExtra.Apsif.First;
			long last = ServerAtlasDataExtra.Apsif.Last;
			int length = (int)(last - first);
			byte[] array = base.M.ReadBytes(first, length);
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < array.Length; i += 2)
			{
				ushort item = BitConverter.ToUInt16(array, i);
				list.Add(item);
			}
			return list;
		}
	}

	public List<ushort> JewelPassiveSkillIds
	{
		get
		{
			long first = ServerDataExtra.jewelsPassive.First;
			long last = ServerDataExtra.jewelsPassive.Last;
			int length = (int)(last - first);
			byte[] array = base.M.ReadBytes(first, length);
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < array.Length; i += 2)
			{
				ushort item = BitConverter.ToUInt16(array, i);
				list.Add(item);
			}
			return list;
		}
	}

	public List<ushort> NormalJewelPassiveSkillIds
	{
		get
		{
			long first = ServerDataExtra.jewels.First;
			long last = ServerDataExtra.jewels.Last;
			int length = (int)(last - first);
			byte[] array = base.M.ReadBytes(first, length);
			List<ushort> list = new List<ushort>();
			for (int i = 0; i < array.Length; i += 24)
			{
				ushort item = BitConverter.ToUInt16(array, i + 16);
				list.Add(item);
			}
			return list;
		}
	}

	public IEnumerable<ushort> SkillBarIds
	{
		get
		{
			uint num2 = default(uint);
			SkillbarStruct ids = default(SkillbarStruct);
			while (true)
			{
				ServerData serverData = this;
				int num;
				switch (num)
				{
				default:
					switch ((num2 = (num2 * 3525911051u) ^ 0x51A4169Du ^ 0xBF688EE2u) % 43u)
					{
					default:
						yield break;
					case 17u:
					case 35u:
						break;
					case 16u:
						yield break;
					case 0u:
					case 24u:
						goto IL_012d;
					case 30u:
						goto IL_013e;
					case 26u:
						try
						{
							goto IL_0156;
							IL_0156:
							/*Error near IL_0157: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 9u:
						goto IL_0156;
					case 5u:
						goto IL_0158;
					case 18u:
						try
						{
							goto IL_0177;
							IL_0177:
							/*Error near IL_0178: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=2.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 27u:
						goto IL_0177;
					case 11u:
					case 32u:
						goto IL_0180;
					case 34u:
						/*Error near IL_0199: Unexpected return in MoveNext()*/;
					case 20u:
					case 33u:
						goto IL_01a1;
					case 40u:
						/*Error near IL_01ba: Unexpected return in MoveNext()*/;
					case 12u:
						goto IL_01bb;
					case 28u:
						try
						{
							goto IL_01da;
							IL_01da:
							/*Error near IL_01db: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 4u:
						goto IL_01da;
					case 7u:
					case 36u:
						goto IL_01e3;
					case 14u:
						try
						{
							goto IL_01fb;
							IL_01fb:
							/*Error near IL_01fc: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=6.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 21u:
						goto IL_01fb;
					case 13u:
						goto IL_01fd;
					case 10u:
						try
						{
							goto IL_021c;
							IL_021c:
							/*Error near IL_021d: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=7.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 42u:
						goto IL_021c;
					case 23u:
						goto IL_021e;
					case 41u:
						goto IL_023f;
					case 22u:
						try
						{
							goto IL_025f;
							IL_025f:
							/*Error near IL_0260: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 6u:
						goto IL_025f;
					case 37u:
					case 39u:
						goto IL_0268;
					case 38u:
						/*Error near IL_0282: Unexpected return in MoveNext()*/;
					case 8u:
						goto IL_0283;
					case 15u:
						try
						{
							goto IL_02a3;
							IL_02a3:
							/*Error near IL_02a4: Unexpected return in MoveNext()*/;
						}
						finally
						{
							/*Error: Could not find finallyMethod for state=11.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
						}
					case 31u:
						goto IL_02a3;
					case 25u:
					case 29u:
						goto IL_02ac;
					case 3u:
						/*Error near IL_02c6: Unexpected return in MoveNext()*/;
					case 19u:
						goto end_IL_00e2;
					case 1u:
						/*Error near IL_02e8: Unexpected return in MoveNext()*/;
					}
					continue;
				case 0:
					goto IL_012d;
				case 1:
					goto IL_0158;
				case 2:
					goto IL_0180;
				case 3:
					goto IL_01a1;
				case 4:
					goto IL_01bb;
				case 5:
					goto IL_01e3;
				case 6:
					goto IL_01fd;
				case 7:
					goto IL_021e;
				case 8:
					goto IL_023f;
				case 9:
					goto IL_0268;
				case 10:
					goto IL_0283;
				case 11:
					goto IL_02ac;
				case 12:
					break;
				case 13:
					yield break;
					IL_02ac:
					yield return ids.ushort_11;
					continue;
					IL_0283:
					yield return ids.ushort_10;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_0268:
					yield return ids.ushort_9;
					continue;
					IL_023f:
					yield return ids.ushort_8;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_021e:
					yield return ids.ushort_7;
					continue;
					IL_01fd:
					yield return ids.ushort_6;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_01e3:
					yield return ids.ushort_5;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_01bb:
					yield return ids.ushort_4;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_01a1:
					yield return ids.ushort_3;
					continue;
					IL_0180:
					yield return ids.ushort_2;
					continue;
					IL_0158:
					yield return ids.ushort_1;
					/*Error: Unable to find new state assignment for yield return*/;
					IL_012d:
					ids = serverData.StructServerData_0.SkillbarIds;
					goto IL_013e;
					IL_013e:
					yield return ids.ushort_0;
					/*Error: Unable to find new state assignment for yield return*/;
					end_IL_00e2:
					break;
				}
				yield return ids.ushort_12;
			}
		}
	}

	public byte[] ActiveWaypoints => base.M.ReadWaypointDataMem(base.Address, 24);

	public byte WeaponSet => StructServerData_0.byte_weaponSet;

	public ushort LastActionId => StructServerData_0.LastActionId;

	public string League => Containers.StdStringWCustom(StructServerData_0.Le);

	public PartyAllocation PartyAllocationType => (PartyAllocation)StructServerData_0.byte_pat;

	public NativeVector PartyMembersVector => StructServerData_0.PartyMembersNativeVector;

	public NativeVector PendingPartyInvite => StructServerData_0.PendingPartyInviteNativeVector;

	public PartyStatus PartyStatusType => (PartyStatus)StructServerData_0.byte_PartyStatusType;

	public string Guild => NativeStringReader.ReadString(StructServerData_0.long_Gu);

	public NativeVector PlayerStashTabsVector => StructServerData_0.Pstf;

	public NativeVector GuildStashTabsVector => StructServerData_0.Gstf;

	[CanBeNull]
	public List<InventoryHolder> PlayerInventories
	{
		get
		{
			List<InventoryHolder> list = base.M.ReadStructsArray<InventoryHolder>(StructServerData_0.vector_Pif.First, StructServerData_0.vector_Pif.Last, 32, 1000);
			if (list == null)
			{
				return null;
			}
			if (list.Any())
			{
				return list;
			}
			return null;
		}
	}

	public List<long> PlayerInventoryWrapper
	{
		get
		{
			List<long> list = new List<long>();
			foreach (InventoryHolder playerInventory in PlayerInventories)
			{
				list.Add(playerInventory.Address);
			}
			return list;
		}
	}

	public List<InventoryHolder> TradeInventories
	{
		get
		{
			if (StructServerData_0.vector_Tif.First == 0L)
			{
				return new List<InventoryHolder>();
			}
			return base.M.ReadStructsArray<InventoryHolder>(StructServerData_0.vector_Tif.First, StructServerData_0.vector_Tif.Last, 32, 1000);
		}
	}

	public List<InventoryHolder> NPCInventories => TradeInventories;

	public List<InventoryHolder> GuildInventories
	{
		get
		{
			if (StructServerData_0.vector_Gif.First == 0L)
			{
				return new List<InventoryHolder>();
			}
			return base.M.ReadStructsArray<InventoryHolder>(StructServerData_0.vector_Gif.First, StructServerData_0.vector_Gif.Last, 32, 1000);
		}
	}

	public NativeHashMap TheMavenHoldaRecreationofthisMap => StructServerData_0.TheMavenHoldaRecreationofthisMap;

	public NativeHashMap ShapedAreasAddress => StructServerData_0.ShapedAreasAddress;

	public NativeHashMap BonusCompletedAreasAddress => StructServerData_0.BonusCompletedAreasAddress;

	public NativeVector ActiveMemories => StructServerData_0.NativeVector_Memoryes;

	public NativeHashMap InfluenceAreasAddress => default(NativeHashMap);

	public NativeVector SextantDataVector => StructServerData_0.SextantDataVector;

	public byte MonsterLevel => StructServerData_0.byte_MonsterLevel;

	public byte MonstersRemaining => StructServerData_0.byte_MonsterRemaining;

	public int Dynamite => DelveInfoStruct_0.ActualExplosives;

	public int Flare => DelveInfoStruct_0.ActualFlares;

	public int MaxDepth => DelveInfoStruct_0.MaxDepth;

	public int CurrentAzuriteAmount => DelveInfoStruct_0.ActualAzurite;

	public int CurrentSulphiteAmount => DelveInfoStruct_0.ActualSulfite;

	public List<LokiPoe.StashTabAffinitiesEnum> StashTabAffinitiesList
	{
		get
		{
			List<LokiPoe.StashTabAffinitiesEnum> list = new List<LokiPoe.StashTabAffinitiesEnum>();
			List<int> list2 = Containers.NativeList_ListInt<int>(StructServerData_0.AffinityMapNativeHashMap_34.List);
			foreach (int item in list2)
			{
				list.Add((LokiPoe.StashTabAffinitiesEnum)item);
			}
			return list;
		}
	}

	public byte ExpeditionLockerAffinity => StructServerData_0.ExpeditionLockerAffinity;

	public short EinharNormalMissions => StructServerData_0.AtlasMasterEinharNormalMissions;

	public short AlvaNormalMissions => StructServerData_0.AtlasMasterAlvaNormalMissions;

	public short NikoNormalMissions => StructServerData_0.AtlasMasterNikoNormalMissions;

	public short JunNormalMissions => StructServerData_0.AtlasMasterJunNormalMissions;

	public short ZanaNormalMissions => StructServerData_0.AtlasMasterZanaNormalMissions;

	public short EinharYellowMissions => StructServerData_0.AtlasMasterEinharYellowMissions;

	public short AlvaYellowMissions => StructServerData_0.AtlasMasterAlvaYellowMissions;

	public short NikoYellowMissions => StructServerData_0.AtlasMasterNikoYellowMissions;

	public short JunYellowMissions => StructServerData_0.AtlasMasterJunYellowMissions;

	public short ZanaYellowMissions => StructServerData_0.AtlasMasterZanaYellowMissions;

	public short EinharRedMissions => StructServerData_0.AtlasMasterEinharRedMissions;

	public short AlvaRedMissions => StructServerData_0.AtlasMasterAlvaRedMissions;

	public short NikoRedMissions => StructServerData_0.AtlasMasterNikoRedMissions;

	public short JunRedMissions => StructServerData_0.AtlasMasterJunRedMissions;

	public short ZanaRedMissions => StructServerData_0.AtlasMasterZanaRedMissions;

	public byte NrOfSocketedVoidstones => StructServerData_0.NrOfSocketedVoidstones;

	internal List<ArchnemesisModStructure> ArchnemesisModInventory
	{
		get
		{
			if (ArchnemesisModInventory_Cache == null)
			{
				ArchnemesisModInventory_Cache = new PerFrameCachedValue<List<ArchnemesisModStructure>>(GetArchnemesisModInventory);
			}
			return ArchnemesisModInventory_Cache.Value;
		}
	}

	internal StructRitualMain RitualMain
	{
		get
		{
			if (perFrameRitualMainStruct == null)
			{
				perFrameRitualMainStruct = new PerFrameCachedValue<StructRitualMain>(GetRitualMain);
			}
			return perFrameRitualMainStruct.Value;
		}
	}

	internal StructRitualData RitualData
	{
		get
		{
			if (perFrameCachedValue_4 == null)
			{
				perFrameCachedValue_4 = new PerFrameCachedValue<StructRitualData>(GetRitualData);
			}
			return perFrameCachedValue_4.Value;
		}
	}

	internal StructServerData StructServerData_0 => GetServerData();

	internal DelveInfoStruct DelveInfoStruct_0
	{
		get
		{
			if (perFrame_DelveInfoStruct == null)
			{
				perFrame_DelveInfoStruct = new PerFrameCachedValue<DelveInfoStruct>(GetDelveInfo);
			}
			return perFrame_DelveInfoStruct.Value;
		}
	}

	internal StructServerDataExtra ServerDataExtra => GetServerDataExtraStructure();

	internal StructAtlasDataExtra ServerAtlasDataExtra => GetServerAtlasDataExtraStructure();

	private unsafe static byte[] CopyFixedDoubleArray(StructUnlockedRecipe data)
	{
		byte[] array = new byte[2031];
		byte* ptr = data.byte_0;
		for (int i = 0; i < 2031; i++)
		{
			array[i] = ptr[i];
		}
		return array;
	}

	private List<ServerStashTab> GetStashTabs(int offsetBegin, int offsetEnd)
	{
		long startAddress = base.M.ReadLong(base.Address + offsetBegin);
		long endAddress = base.M.ReadLong(base.Address + offsetEnd);
		List<ServerStashTab> list = base.M.ReadStructsArray<ServerStashTab>(startAddress, endAddress, 64, 5000);
		list.RemoveAll((ServerStashTab x) => (x.inventoryTabFlags & InventoryTabFlags.Hidden) == InventoryTabFlags.Hidden);
		return list;
	}

	public List<DreamPoeBot.Loki.Game.Inventory> GetPlayerInventoryBySlot(InventorySlot slot)
	{
		List<DreamPoeBot.Loki.Game.Inventory> list = new List<DreamPoeBot.Loki.Game.Inventory>();
		List<InventoryHolder> playerInventories = PlayerInventories;
		foreach (InventoryHolder item in playerInventories)
		{
			if (item.Inventory.PageSlot == slot)
			{
				list.Add(item.Inventory);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}

	public List<DreamPoeBot.Loki.Game.Inventory> GetPlayerInventoryByType(InventoryType type)
	{
		List<DreamPoeBot.Loki.Game.Inventory> list = new List<DreamPoeBot.Loki.Game.Inventory>();
		List<InventoryHolder> playerInventories = PlayerInventories;
		foreach (InventoryHolder item in playerInventories)
		{
			if (item.Inventory.PageType == type)
			{
				list.Add(item.Inventory);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}

	public List<DreamPoeBot.Loki.Game.Inventory> GetPlayerInventoryBySlotAndType(InventoryType type, InventorySlot slot)
	{
		List<DreamPoeBot.Loki.Game.Inventory> list = new List<DreamPoeBot.Loki.Game.Inventory>();
		List<InventoryHolder> playerInventories = PlayerInventories;
		foreach (InventoryHolder item in playerInventories)
		{
			if (item.Inventory.PageType == type && item.Inventory.PageSlot == slot)
			{
				list.Add(item.Inventory);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}

	public DreamPoeBot.Loki.Game.Inventory GetPlayerInventoryById(int id)
	{
		List<InventoryHolder> playerInventories = PlayerInventories;
		foreach (InventoryHolder item in playerInventories)
		{
			if (item.Id == id)
			{
				return item.Inventory;
			}
		}
		return null;
	}

	private StructServerData GetServerData()
	{
		if (_structServerDataSize == -1)
		{
			_structServerDataSize = MarshalCache<StructServerData>.Size;
		}
		return base.M.FastIntPtrToStructServerData<StructServerData>(base.Address, _structServerDataSize);
	}

	private StructRitualMain GetRitualMain()
	{
		if (_structRitualMainSize == -1)
		{
			_structRitualMainSize = MarshalCache<StructRitualMain>.Size;
		}
		return base.M.FastIntPtrToStructRitualData<StructRitualMain>(base.Address, _structRitualMainSize);
	}

	private StructRitualData GetRitualData()
	{
		if (_structRitualDataSize == -1)
		{
			_structRitualDataSize = MarshalCache<StructRitualData>.Size;
		}
		return base.M.FastIntPtrToStruct<StructRitualData>(RitualMain.StructRitualData, _structRitualDataSize);
	}

	private DelveInfoStruct GetDelveInfo()
	{
		if (_delveInfoStructSize == -1)
		{
			_delveInfoStructSize = MarshalCache<DelveInfoStruct>.Size;
		}
		return base.M.FastIntPtrToStructDelveData<DelveInfoStruct>(base.Address, _delveInfoStructSize);
	}

	private StructServerDataExtra GetServerDataExtraStructure()
	{
		return base.M.FastIntPtrToStruct<StructServerDataExtra>(StructServerData_0.structServerDataExtra);
	}

	private StructAtlasDataExtra GetServerAtlasDataExtraStructure()
	{
		return base.M.FastIntPtrToStruct<StructAtlasDataExtra>(StructServerData_0.structAtlasDataExtra);
	}

	private unsafe List<ArchnemesisModStructure> GetArchnemesisModInventory()
	{
		List<ArchnemesisModStructure> list = new List<ArchnemesisModStructure>();
		byte[] array = base.M.ReadBytes(base.Address + 41336L, 1536);
		for (int i = 0; i < 1536; i += 24)
		{
			fixed (byte* ptr = &array[i])
			{
				list.Add(*(ArchnemesisModStructure*)ptr);
			}
		}
		return list;
	}

	public void UpdateAddress(long l)
	{
		base.Address = l;
	}
}
