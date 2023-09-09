using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Game.GameData;

public static class Dat
{
	public class DatQuestRewardWrapper
	{
		internal NativeQuestStaticReward NativeQuestReward_0 { get; set; }

		public CharacterClass Class { get; internal set; }

		public DatQuestWrapper Quest { get; internal set; }

		public DatBaseItemTypeWrapper Item { get; internal set; }

		public Rarity Rarity { get; internal set; }
	}

	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NativeQuestStaticReward
	{
		public int QuestId;

		public int _00;

		public int StatsKeysCount;

		public int _01;

		public long StatsKeysAddress;

		public int StatsValueCount;

		public int _02;

		public long StatsValueAddress;

		public long QuestDatAddress;

		public long QuestDatFile;

		public int _03;

		public long ClientStringAddress;

		public long ClientStringFile;

		public int _04;
	}

	[Serializable]
	private sealed class Class334
	{
		public static readonly Class334 Class9 = new Class334();

		internal string method_1(KeyValuePair<string, DatDivinationCardStashTabLayoutWrapper> keyValuePair_0)
		{
			return keyValuePair_0.Value.BaseItemTypeWrapper.Name;
		}

		internal int method_2(NativeExperienceLevels nativeExperienceLevels_0)
		{
			return nativeExperienceLevels_0.Level;
		}

		internal int method_3(DatBaseItemTypeWrapper datBaseItemTypeWrapper_0)
		{
			return datBaseItemTypeWrapper_0.Index;
		}

		internal int method_4(DatQuestWrapper datQuestWrapper_0)
		{
			return datQuestWrapper_0.Index;
		}

		internal int method_5(DatWordsWrapper datWordsWrapper_0)
		{
			return datWordsWrapper_0.Index;
		}

		internal DatWordsWrapper method_6(DatWordsWrapper datWordsWrapper_0)
		{
			return datWordsWrapper_0;
		}

		internal int method_7(DatBaseItemTypeWrapper datBaseItemTypeWrapper_0)
		{
			return datBaseItemTypeWrapper_0.Index;
		}

		internal int method_8(DatQuestWrapper datQuestWrapper_0)
		{
			return datQuestWrapper_0.Index;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct NativeExperienceLevels
	{
		public int NameIndex;

		public int Level;

		public uint Experience;
	}

	public static class Runtime
	{
		public class DatMonsterVarietyWrapper2
		{
			[StructLayout(LayoutKind.Sequential, Pack = 1)]
			internal struct Struct286
			{
				public readonly long intptr_0Metadata;

				private readonly long intptr_1;

				private readonly long intptr_2;

				private readonly int int_3;

				private readonly int int_4;

				private readonly int int_5;

				private readonly int int_6;

				private readonly long intptr_7;

				private readonly long intptr_8;

				private readonly long intptr_9;

				private readonly long intptr_10;

				private readonly long intptr_11;

				private readonly int int_12;

				private readonly long int_13;

				private readonly long int_14;

				private readonly int int_15;

				private readonly int int_16;

				private readonly int int_17;

				private readonly int int_18;

				private readonly int int_19;

				private readonly int int_20;

				private readonly int int_21;

				private readonly int int_22;

				private readonly long intptr_23;

				private readonly int int_24;

				private readonly long intptr_25;

				private readonly long intptr_26;

				private readonly int int_27;

				private readonly int int_28;

				private readonly int int_29;

				private readonly int int_30;

				private readonly int int_31;

				private readonly int int_32;

				private readonly int int_33;

				private readonly long intptr_34;

				private readonly long intptr_35;

				private readonly int int_36;

				private readonly int int_37;

				private readonly long intptr_38;

				private readonly long intptr_39Name;

				private readonly long intptr_40;

				private readonly long intptr_41;

				private readonly long intptr_410;

				private readonly long intptr_411;

				public readonly long intptr_42NewName;

				private readonly int int_47;

				private readonly long intptr_48;

				private readonly int int_49;

				private readonly int int_50;

				private readonly long intptr_51;

				private readonly long intptr_52;

				private readonly long intptr_53;

				private readonly long intptr_54;

				private readonly long intptr_55;

				private readonly long intptr_56;

				private readonly long intptr_57;

				private readonly long intptr_58;

				private readonly long intptr_59;

				private readonly long intptr_60;

				private readonly long intptr_61;

				private readonly int int_62;

				private readonly int int_63;

				private readonly int byte_0;

				private readonly long intptr_64;

				private readonly long intptr_65;

				private readonly long intptr_66;

				private readonly long intptr_67;

				private readonly long intptr_68;

				private readonly int int_69;

				private readonly int int_0MonsterId;

				private readonly int byte_1;

				private readonly long intptr_70;

				private readonly int int_71;

				private readonly byte byte_73;

				public readonly int int_72NewId;

				private readonly byte byte_74;

				private readonly long intptr_75;

				private readonly long intptr_76;

				private readonly long intptr_77;

				private readonly long intptr_78;

				private readonly long intptr_79;

				private readonly long intptr_80;

				private readonly long intptr_81;

				private readonly long intptr_82;

				private readonly long intptr_83;

				private readonly long intptr_84;

				private readonly long intptr_85;

				private readonly long intptr_86;

				private readonly long intptr_87;

				private readonly long intptr_88;

				private readonly long intptr_89;

				private readonly long intptr_90;

				private readonly long intptr_91;

				private readonly long intptr_92;

				private readonly long intptr_93;

				private readonly long intptr_94;

				private readonly long intptr_95;

				private readonly long intptr_96;

				private readonly long intptr_97;

				private readonly long intptr_98;

				private readonly long intptr_99;

				private readonly long intptr_100;

				private readonly long intptr_101;

				private readonly int int_102;

				private readonly int int_103;

				private readonly int int_104;

				private readonly int int_105;

				private readonly long intptr_106;

				private readonly long intptr_107;

				private readonly long intptr_108;

				private readonly int int_109;

				private readonly int int_110;

				private readonly int int_111;

				private readonly int int_112;

				private readonly int int_113;

				private readonly byte int_114;

				private readonly long intptr_115;

				private readonly byte byte0;

				private readonly byte byte1;
			}

			public int Index { get; private set; }

			public string Metadata { get; private set; }

			public string Name { get; private set; }

			public int MonsterId { get; private set; }

			internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

			internal Struct286 Struct286_0 { get; set; }

			internal DatMonsterVarietyWrapper2(Struct286 native, int index)
			{
				Struct286_0 = native;
				Index = index;
				Struct286 struct286_ = Struct286_0;
				Metadata = ExternalProcessMemory_0.ReadStringU(struct286_.intptr_0Metadata);
				Name = ExternalProcessMemory_0.ReadStringU(struct286_.intptr_42NewName);
				MonsterId = Struct286_0.int_72NewId;
			}
		}

		public static IEnumerable<DatMonsterVarietyWrapper2> MonsterVarieties2
		{
			get
			{
				long num = smethod_0();
				if (num != 0L)
				{
					NativeVector nativeVector = LongToNativeVector(num);
					if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
					{
						throw new Exception("This client version is not supported.");
					}
					List<DatMonsterVarietyWrapper2.Struct286> struct286s = Containers.StdStruct286Vector<DatMonsterVarietyWrapper2.Struct286>(nativeVector);
					for (int i = 0; i < struct286s.Count; i++)
					{
						yield return new DatMonsterVarietyWrapper2(struct286s[i], i + 1);
					}
				}
			}
		}

		internal static long smethod_0()
		{
			return GameController.Instance.Files.MonsterVarieties.Address;
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static readonly Dictionary<long, DatActiveSkillWrapper> dictionary_0 = new Dictionary<long, DatActiveSkillWrapper>();

	private static Dictionary<BaseItemTypeEnum, DatBaseItemTypeWrapper> _dictionaryBaseItemTypeId;

	private static Dictionary<string, BaseItemTypeEnum> _dictionaryBaseItemTypeNamesToEnum;

	private static List<DatSkillGemWrapper> _skillGems = new List<DatSkillGemWrapper>();

	private static readonly Dictionary<long, DatBaseItemTypeWrapper> dictionary_BaseItemTypeWrapper = new Dictionary<long, DatBaseItemTypeWrapper>();

	private static readonly Dictionary<long, DatClientStringWrapper> dictionary_5 = new Dictionary<long, DatClientStringWrapper>();

	private static readonly Dictionary<long, DatIncursionArchitectWrapper> dictionary_8 = new Dictionary<long, DatIncursionArchitectWrapper>();

	private static readonly Dictionary<long, DatMinimapIconWrapper> dictionary_MinimapIconWrapper = new Dictionary<long, DatMinimapIconWrapper>();

	private static readonly Dictionary<long, DatPropheciesWrapper> dictionary_11 = new Dictionary<long, DatPropheciesWrapper>();

	private static Dictionary<int, DatPropheciesWrapper> dictionary_12;

	private static List<DatQuestRewardWrapper> list_1;

	private static readonly Dictionary<string, DatQuestWrapper> dictionary_15 = new Dictionary<string, DatQuestWrapper>();

	private static readonly Dictionary<long, DatStatWrapper> dictionary_StatWrapper = new Dictionary<long, DatStatWrapper>();

	private static Dictionary<string, DatWorldAreaWrapper> dictionary_17;

	private static Dictionary<int, DatWorldAreaWrapper> dictionary_18;

	private static readonly Dictionary<long, DatWorldAreaWrapper> dictionary_WorldAreaWrapper = new Dictionary<long, DatWorldAreaWrapper>();

	private static Dictionary<string, Dictionary<int, DatQuestStateWrapper>> QuestStateDictionary;

	public static readonly Dictionary<int, DatPassiveSkillWrapper> dictionary_IdToPassiveSkillWrapper = new Dictionary<int, DatPassiveSkillWrapper>();

	private static readonly Dictionary<long, DatPassiveSkillMasteryEffectsWrapper> dictionary_PassiveSkillMasteryEffects = new Dictionary<long, DatPassiveSkillMasteryEffectsWrapper>();

	public static readonly Dictionary<string, DatStatWrapper> IdToStatWrapper = new Dictionary<string, DatStatWrapper>();

	private static Dictionary<ClientStringsEnum, DatClientStringWrapper> dictionary_4;

	private static PerFrameCachedValue<Dictionary<string, long>> perFrameCachedValue_0;

	private static long intptr_0;

	private static List<DatWorldAreaWrapper> list_3;

	private static List<DelveLevelScalingWrapper> _delveLevelScaling = new List<DelveLevelScalingWrapper>();

	public static List<short> HellscapeModsDatList = new List<short>
	{
		24298, 24299, 24300, 24301, 24302, 24303, 24304, 24305, 24306, 24307,
		24308, 24309, 24310, 24311, 24312, 24313, 24314, 24315, 24316, 24317,
		24318, 24319, 24320, 24321, 24322, 24323, 24324, 24325, 24326, 24327,
		24328, 24329, 24330, 24331, 24332, 24333, 24334, 24335, 24336, 24337,
		24338, 24339, 24340, 24341, 24342, 24343, 24344, 24345, 24346, 24347,
		24348, 24349, 24350, 24351, 24352, 24353, 24354, 24355, 24356, 24357,
		24358, 24359, 24360, 24361, 24362, 24363, 24364, 24365, 24366, 24367,
		24368, 24369, 24370, 24371, 24372, 24373, 24374, 24375, 24376, 24377,
		24378, 24379, 24380, 24381, 24382, 24383, 24384, 24385, 24386, 24387,
		24388, 24389, 24390, 24391, 24392, 24393, 24394, 24395, 24396, 24397,
		24398, 24399, 24400, 24401, 24402, 24403, 24404, 24405, 24406, 24407,
		24408, 24409, 24410, 24411, 24412, 24413, 24414, 24415, 24416, 24417,
		24418, 24419, 24420, 24421, 24422, 24423, 24424, 24425, 24426, 24427,
		24428, 24429, 24430, 24431, 24432, 24433, 24434, 24435, 24436, 24437,
		24438, 24439, 24440, 24441, 24442, 24443, 24444, 24445, 24446, 24447,
		24448, 24449, 24450, 24451, 24452, 24453, 24454, 24455, 24456, 24457,
		24458, 24459, 24460, 24461, 24462, 24463, 24464, 24465, 24466, 24467,
		24468, 24469, 24470, 24471, 24472, 24473, 24474, 24475, 24476, 24477,
		24478, 24479, 24480, 24481, 24482, 24483, 24484, 24485, 24486, 24487,
		24488, 24489, 24490, 24491, 24492, 24493, 24494, 24495, 24496, 24497,
		24498, 24499, 24500, 24501, 24502, 24503, 24504, 24505, 24506, 24507,
		24508, 24509, 24510, 24511, 24512, 24513, 24514, 24515, 24516, 24517,
		24518, 24519, 24520, 24521, 24522, 24523, 24524, 24525, 24526, 24527,
		24528, 24529, 24530, 24531, 24532, 24533, 24534, 24535, 24536, 24537,
		24538, 24539, 24540, 24541, 24542, 24543, 24544, 24545, 24546, 24547,
		24548, 24549, 24550, 24551, 24552, 24553, 24554, 24555, 24556, 24557,
		24558, 24559, 24560, 24561, 24562, 24563, 24564, 24565, 24566, 24567,
		24568, 24569, 24570, 24571, 24572, 24573, 24574, 24575, 24576, 24577,
		24578, 24579, 24580, 24581, 24582, 24583, 24584, 24585, 24586, 24587,
		24588, 24589, 24590, 24591, 24592, 24593, 24594, 24595, 24596, 24597,
		24598, 24599, 24600, 24601, 24602, 24603, 24604, 24605, 24606, 24607,
		24608, 24609, 24610, 24611, 24612, 24613, 24614, 24615, 24616, 24617,
		24618, 24619, 24620, 24621, 24622, 24623, 24624, 24625, 24626, 24627,
		24628, 24629, 24630, 24631, 24632, 24633, 24634, 24635, 24636, 24637,
		24638, 24639, 24640, 24641, 24642, 24643, 24644, 24645, 24646, 24647,
		24648, 24649, 24650, 24651, 24652, 24653, 24654, 24655, 24656, 24657,
		24658, 24659, 24660, 24661, 24662, 24663, 24664, 24665, 24666, 24667,
		24668, 24669, 24670, 24671, 24672, 24673, 24674, 24675, 24676, 24677,
		24678, 24679, 24680, 24681, 24682, 24683, 24684, 24685, 24686, 24687,
		24688, 24689, 24690, 24691, 24692, 24693, 24694, 24695, 24696, 24697,
		24698, 24699, 24700, 24701, 24702, 24703, 24704, 24705, 24706, 24707,
		24708, 24709, 24710, 24711, 24712, 24713, 24714, 24715, 24716, 24717,
		24718, 24719, 24720, 24721, 24722, 24723, 24724, 24725, 24726, 24727,
		24728, 24729, 24730, 24731, 24732, 24733, 24734, 24735, 24736, 24737,
		24738, 24739, 24740, 24741, 24742, 24743, 24744, 24745, 24746, 24747,
		24748, 24749, 24750, 24751, 24752, 24753, 24754, 24755, 24756, 24757,
		24758, 24759, 24760, 24761, 24762, 24763, 24764, 24765, 24766, 24767,
		24768, 24769, 24770, 24771, 24772, 24773, 24774, 24775, 24776, 24777,
		24778, 24779, 24780, 24781, 24782, 24783, 24784, 24785, 24786, 24787,
		24788, 24789, 24790, 24791, 24792, 24793, 24794, 24795, 24796, 24797,
		24798, 24799, 24800, 24801, 24802, 24803, 24804, 24805, 24806, 24807,
		24808, 24809, 24810, 24811, 24812, 24813, 24814, 24815, 24816, 24817,
		24818, 24819, 24820, 24821, 24822, 24823, 24824, 24825, 24826, 24827,
		24828, 24829, 24830, 24831, 24832, 24833, 24834, 24835, 24836, 24837,
		24838, 24839, 24840, 24841, 24842, 24843, 24844, 24845, 24846, 24847,
		24848, 24849, 24850, 24851, 24852, 24853, 24854, 24855, 24856, 24857,
		24858, 24859, 24860, 24861, 24862, 24863, 24864, 24865, 24866, 24867,
		24868, 24869, 24870, 24871, 24872, 24873, 24874, 24875, 24876, 24877,
		24878, 24879, 24880, 24881, 24882, 24883, 24884, 24885, 24886, 24887,
		24888, 24889, 24890, 24891, 24892, 24893, 24894, 24895, 24896, 24897,
		24898, 24899, 24900, 24901, 24902, 24903, 24904, 24905, 24906, 24907,
		24908, 24909, 24910, 24911, 24912, 24913, 24914, 24915, 24916, 24917,
		24918, 24919, 24920, 24921, 24922, 24923, 24924, 24925, 24926, 24927,
		24928, 24929, 24930, 24931, 24932, 24933, 24934, 24935, 24936, 24937,
		24938, 24939, 24940, 24941, 24942, 24943, 24944, 24945, 24946, 24947,
		24948, 24949, 24950, 24951, 24952, 24953, 24954, 24955, 24956, 24957,
		24958, 24959, 24960, 24961, 24962, 24963, 24964, 24965, 24966, 24967,
		24968, 24969, 24970, 24971, 24972, 24973, 24974, 24975, 24976, 24977,
		24978, 24979, 24980, 24981, 24982, 24983, 24984, 24985, 24986, 24987,
		24988, 24989, 24990, 24991, 24992, 24993, 24994, 24995, 24996, 24997,
		24998, 24999, 25000, 25001, 25002, 25003, 25004, 25005, 25006, 25007,
		25008, 25009, 25010, 25011, 25012, 25013, 25014, 25015, 25016, 25017,
		25018, 25019, 25020, 25021, 25022, 25023, 25024, 25025, 25026, 25027,
		25028, 25029, 25030, 25031, 25032, 25033, 25034, 25035, 25036, 25037,
		25038, 25039, 25040, 25041, 25042, 25043, 25044, 25045, 25046, 25047,
		25048, 25049, 25050, 25051, 25052, 25053, 25054, 25055, 25056, 25057,
		25058, 25059, 25060, 25061, 25062, 25063, 25064, 25065, 25066, 25067,
		25068, 25069, 25070, 25071, 25072, 25073, 25074, 25075, 25076, 25077,
		25078, 25079, 25080, 25081, 25082, 25083, 25084, 25085, 25086, 25087,
		25088, 25089, 25090, 25091, 25092, 25093, 25094, 25095, 25096, 25097,
		25098, 25099, 25100, 25101, 25102, 25103, 25104, 25105, 25106, 25107,
		25108, 25109, 25110, 25111, 25112, 25113, 25114, 25115, 25116, 25117,
		25118, 25119, 25120, 25121, 25122, 25123, 25124, 25125, 25126, 25127,
		25128, 25129, 25130, 25131, 25132, 25133, 25134, 25135, 25136, 25137,
		25138, 25139, 25140, 25141, 25142, 25143, 25144, 25145, 25146, 25147,
		25148, 25149, 25150, 25151, 25152, 25153, 25154, 25155, 25156, 25157,
		25158, 25159, 25160, 25161, 25162, 25163, 25164, 25165, 25166, 25167,
		25168, 25169, 25170, 25171, 25172, 25173, 25174, 25175, 25176, 25177,
		25178, 25179, 25180, 25181, 25182, 25183, 25184, 25185, 25186, 25187,
		25188, 25189, 25190, 25191, 25192, 25193, 25194, 25195, 25196, 25197,
		25198, 25199, 25200, 25201, 25202, 25203, 25204, 25205, 25206, 25207,
		25208, 25209, 25215, 25216, 25217, 25218, 25219, 25220, 25221, 25222,
		25223, 25224, 25225, 25226, 25227, 25228, 25229, 25230, 25231, 25232,
		25233, 25234, 25235, 25236, 25237, 25238, 25239, 25240, 25241, 25242,
		25243, 25244, 25245, 25246, 25247, 25248, 25249, 25250, 25251, 25252,
		25253, 25254, 25255, 25256, 25257, 25258, 25259, 25260, 25261, 25262,
		25263, 25264, 25265, 25266, 25267, 25268, 25269, 25270, 25271, 25272,
		25273, 25274, 25275, 25276, 25277, 25278, 25279, 25280, 25281, 25282,
		25283, 25284, 25285, 25286, 25287, 25288, 25289, 25290, 25291, 25292,
		25293, 25294, 25295, 25296, 25297, 25298, 25299, 25300, 25301, 25302,
		25303, 25304, 25305, 25306, 25307, 25308, 25309, 25310, 25311, 25312,
		25313, 25314, 25315, 25316, 25317, 25318, 25319, 25320, 25321, 25322,
		25323, 25324, 25325, 25326, 25327, 25328, 25329, 25330, 25331, 25332,
		25333, 25334, 25335, 25336, 25337, 25338, 25339, 25340, 25341, 25342,
		25343, 25344, 25345, 25346, 25347, 25348, 25349, 25350, 25351, 25352,
		25353, 25354, 25355, 25356, 25357, 25358, 25359, 25360, 25361, 25362,
		25363, 25364, 25365, 25366, 25367, 25368, 25369, 25370, 25371, 25372,
		25373, 25374, 25375, 25376, 25377, 25378, 25379, 25380, 25381, 25382,
		25383, 25384, 25385, 25386, 25387, 25388, 25389, 25390, 25391, 25392,
		25393, 25394, 25395, 25396, 25397, 25398, 25399, 25400, 25401, 25402,
		25403, 25404, 25405, 25406, 25407, 25408, 25409, 25410, 25411, 25412,
		25413, 25414, 25415, 25416, 25417, 25418, 25419, 25420, 25421, 25422,
		25423, 25424, 25425, 25426, 25427, 25428, 25429, 25430, 25431, 25432,
		25433, 25434, 25435, 25436, 25437, 25438, 25439, 25440, 25441, 25442,
		25443, 25444, 25445, 25446, 25447, 25448, 25449, 25450, 25451, 25452,
		25453, 25454, 25455, 25456, 25457, 25458, 25459, 25460, 25461, 25462,
		25463, 25464, 25465, 25466, 25467, 25468, 25469, 25470, 25471, 25472,
		25473, 25474, 25475, 25476, 25477, 25478, 25479, 25480, 25481, 25482,
		25483, 25484, 25485, 25486, 25487, 25488, 25489, 25490, 25491, 25492,
		25493, 25494, 25495, 25496, 25497, 25498, 25499, 25500, 25501, 25502,
		25503, 25504, 25505, 25506, 25507, 25508, 25509, 25510, 25511, 25512,
		25513, 25514, 25515, 25516, 25517, 25518, 25519, 25520, 25521, 25522,
		25523, 25524, 25525, 25526, 25527, 25528, 25529, 25530, 25531, 25532,
		25533, 25534, 25535, 25536, 25537, 25538, 25539, 25540, 25541, 25542,
		25543, 25544, 25545, 25546, 25547, 25548, 25549, 25550, 25551, 25552,
		25553, 25554, 25555, 25556, 25557, 25558, 25559, 25560, 25561, 25562,
		25563, 25564, 25565, 25566, 25567, 25568, 25569, 25570, 25576, 25577,
		25578, 25579, 25580, 25581, 25582, 25583, 25584, 25585, 25586, 25587,
		25588, 25589, 25210, 25211, 25212, 25213, 25214, 25571, 25572, 25573,
		25574, 25575
	};

	public static IEnumerable<DatBaseItemTypeWrapper> BaseItemTypes
	{
		get
		{
			if (!dictionary_BaseItemTypeWrapper.Any())
			{
				BaseItemTypes baseItemTypes = GameController.Instance.Files.BaseItemTypes;
				int num = 0;
				using (Dictionary<string, BaseItemType>.Enumerator enumerator = baseItemTypes.contents.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						KeyValuePair<string, BaseItemType> current = enumerator.Current;
						yield return new DatBaseItemTypeWrapper(current.Value.Address, current.Value, current.Key, num + 1);
						/*Error: Unable to find new state assignment for yield return*/;
					}
				}
				yield break;
			}
			foreach (KeyValuePair<long, DatBaseItemTypeWrapper> item in dictionary_BaseItemTypeWrapper)
			{
				yield return item.Value;
			}
		}
	}

	public static List<AtlasNode> AtlasNodes => GameController.Instance.Files.AtlasNodes.EntriesList;

	public static List<DatWorldAreaWrapper> WaypointAreas
	{
		get
		{
			List<DatWorldAreaWrapper> list = new List<DatWorldAreaWrapper>();
			List<WorldArea> entriesList = GameController.Instance.Files.WorldAreas.EntriesList;
			foreach (WorldArea item in entriesList)
			{
				if (item.HasWaypoint)
				{
					list.Add(new DatWorldAreaWrapper(item.Id));
				}
			}
			return list;
		}
	}

	public static IEnumerable<DatWorldAreaWrapper> WorldAreas
	{
		get
		{
			if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
			{
				throw new Exception("This client version is not supported.");
			}
			if (dictionary_WorldAreaWrapper.Any())
			{
				foreach (KeyValuePair<long, DatWorldAreaWrapper> item in dictionary_WorldAreaWrapper)
				{
					yield return item.Value;
				}
				yield break;
			}
			long address = GameController.Instance.Files.WorldAreas.Address;
			if (address == 0L)
			{
				ilog_0.WarnFormat("[WorldAreas] manager is not loaded yet!", Array.Empty<object>());
				yield break;
			}
			NativeVector nativeVector = LongToNativeVector(address);
			if (nativeVector.First != 0L && nativeVector.End != 0L && nativeVector.Last != 0L)
			{
				List<Tuple<DatWorldAreaWrapper.Struct327, long>> tuples = Containers.StdVectorExStruct327<DatWorldAreaWrapper.Struct327>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					DatWorldAreaWrapper datWorldAreaWrapper = new DatWorldAreaWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
					if (!string.IsNullOrEmpty(datWorldAreaWrapper.Id))
					{
						yield return new DatWorldAreaWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
					}
				}
			}
			else
			{
				ilog_0.WarnFormat("[WorldAreas] manager memory corrupted!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatQuestWrapper> Quests
	{
		get
		{
			List<DatQuestWrapper> list = new List<DatQuestWrapper>();
			List<Quest> entriesList = GameController.Instance.Files.Quests.EntriesList;
			int num = 1;
			foreach (Quest item in entriesList)
			{
				list.Add(new DatQuestWrapper(item.Id, item.Name, item.Icon, item.Act, num));
				num++;
			}
			return list;
		}
	}

	public static IEnumerable<DatQuestStateWrapper> QuestStates
	{
		get
		{
			List<DatQuestStateWrapper> list = new List<DatQuestStateWrapper>();
			List<Tuple<Quest, int>> getCompletedQuests = GameController.Instance.Game.IngameState.IngameUi.GetCompletedQuests;
			foreach (Tuple<Quest, int> item in getCompletedQuests)
			{
				if (!(item?.Item1 == null))
				{
					QuestState questState = GameController.Instance.Files.QuestStates.GetQuestState(item.Item1.Id, 0);
					if (!(questState == null))
					{
						list.Add(new DatQuestStateWrapper(item.Item1.Id, questState.QuestStateText, questState.QuestProgressText, questState.TestOffset, 0));
					}
				}
			}
			Dictionary<string, KeyValuePair<Quest, QuestState>>.ValueCollection values = GameController.Instance.Game.IngameState.IngameUi.GetQuestStates.Values;
			foreach (KeyValuePair<Quest, QuestState> queststate in values)
			{
				DatQuestStateWrapper datQuestStateWrapper = list.FirstOrDefault((DatQuestStateWrapper x) => x.Quest.Id == queststate.Key.Id);
				if (datQuestStateWrapper == null)
				{
					list.Add(new DatQuestStateWrapper(queststate.Key.Id, queststate.Value.QuestStateText, queststate.Value.QuestProgressText, queststate.Value.TestOffset, queststate.Value.QuestStateId));
				}
			}
			return list;
		}
	}

	public static IEnumerable<DatClientStringWrapper> ClientStrings
	{
		get
		{
			long num2 = smethod_27();
			if (num2 == 0L)
			{
				ilog_0.WarnFormat("[ClientStrings] manager is not loaded yet!", Array.Empty<object>());
				yield break;
			}
			NativeVector nativeVector = LongToNativeVector(num2);
			if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
			{
				throw new Exception("This client version is not supported.");
			}
			List<Tuple<DatClientStringWrapper.Struct302, long>> list = Containers.StdVectorExStruct302<DatClientStringWrapper.Struct302>(nativeVector);
			int num = 0;
			while (num < list.Count)
			{
				yield return new DatClientStringWrapper(list[num].Item2, list[num].Item1, num + 1);
				int num3 = num + 1;
				num = num3;
			}
		}
	}

	public static IEnumerable<DatPropheciesWrapper> Prophecies
	{
		get
		{
			long num = smethod_70();
			if (num == 0L)
			{
				ilog_0.WarnFormat("[Prophecies] manager is not loaded yet!", Array.Empty<object>());
				yield break;
			}
			NativeVector nativeVector = LongToNativeVector(num);
			if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
			{
				throw new Exception("This client version is not supported.");
			}
			List<Tuple<DatPropheciesWrapper.Struct321, long>> tuples = Containers.StdVectorExStruct321<DatPropheciesWrapper.Struct321>(nativeVector);
			for (int i = 0; i < tuples.Count; i++)
			{
				yield return new DatPropheciesWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
			}
		}
	}

	public static IEnumerable<DatLabyrinthTrialWrapper> LabyrinthTrials
	{
		get
		{
			long address = GameController.Instance.Files.LabyrinthTrials.Address;
			if (address != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(address);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<DatLabyrinthTrialWrapper.Struct313> struct313s = Containers.StdStruct313Vector<DatLabyrinthTrialWrapper.Struct313>(nativeVector);
				for (int i = 0; i < struct313s.Count; i++)
				{
					yield return new DatLabyrinthTrialWrapper(struct313s[i], i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[LabyrinthTrials] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static List<DatWorldAreaWrapper> AtlasAreas
	{
		get
		{
			if (list_3 == null)
			{
				List<DatWorldAreaWrapper> list = WorldAreas.ToList();
				if (!list.Any())
				{
					return new List<DatWorldAreaWrapper>();
				}
				list_3 = new List<DatWorldAreaWrapper>();
				foreach (DatWorldAreaWrapper item in list)
				{
					if (item.IsMapWorlds)
					{
						list_3.Add(item);
					}
				}
			}
			return list_3;
		}
	}

	public static IEnumerable<DatActiveSkillWrapper> ActiveSkills
	{
		get
		{
			long activeSkillsPtr = GameController.Instance.Files.ActiveSkillsPtr;
			if (activeSkillsPtr != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(activeSkillsPtr);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<Tuple<DatActiveSkillWrapper.ActiveSkills, long>> tuples = Containers.StdVectorExStruct289<DatActiveSkillWrapper.ActiveSkills>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					yield return new DatActiveSkillWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[ActiveSkills] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatModsWrapper> Mods
	{
		get
		{
			long num = smethod_61ModsPointer();
			if (num == 0L)
			{
				ilog_0.WarnFormat("[Mods] manager is not loaded yet!", Array.Empty<object>());
				yield break;
			}
			NativeVector nativeVector = LongToNativeVector(num);
			if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
			{
				throw new Exception("This client version is not supported.");
			}
			List<DatModsWrapper.Struct316> struct316s = Containers.StdVectorStruct316<DatModsWrapper.Struct316>(nativeVector);
			for (int i = 0; i < struct316s.Count; i++)
			{
				yield return new DatModsWrapper(struct316s[i], i + 1);
			}
		}
	}

	public static IEnumerable<DatWordsWrapper> Words
	{
		get
		{
			long num = smethod_82WordsPointer();
			if (num != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(num);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<DatWordsWrapper.Struct326> struct326s = Containers.StdVectorStruct326<DatWordsWrapper.Struct326>(nativeVector);
				for (int i = 0; i < struct326s.Count; i++)
				{
					yield return new DatWordsWrapper(struct326s[i], i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[Words] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static GrantedEffectsPerLevelDat GrantedEffectsPerLevel => GameController.Instance.Files.GrantedEffectsPerLevel;

	public static QuestFlagsDat QuestFlags => GameController.Instance.Files.QuestFlags;

	public static List<DatSkillGemWrapper> SkillGems
	{
		get
		{
			if (!_skillGems.Any())
			{
				_skillGems = GetSkillGemsList.ToList();
			}
			return _skillGems;
		}
	}

	public static IEnumerable<DatSkillGemWrapper> GetSkillGemsList
	{
		get
		{
			long skillGemsPtr = GameController.Instance.Files.SkillGemsPtr;
			if (skillGemsPtr != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(skillGemsPtr);
				List<Tuple<DatSkillGemWrapper.Struct324, long>> tuples = Containers.StdVectorExStructDatSkillGems<DatSkillGemWrapper.Struct324>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					yield return new DatSkillGemWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[SkillGems] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static List<DelveLevelScalingWrapper> DelveLevelScaling
	{
		get
		{
			if (_delveLevelScaling.Any())
			{
				return _delveLevelScaling;
			}
			long delveLevelScaling = GameController.Instance.Files.DelveLevelScaling;
			if (delveLevelScaling != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(delveLevelScaling);
				int size = MarshalCache<DelveLevelScalingWrapper.DelveLevelScalingStruct>.Size;
				int num = 0;
				for (long num2 = nativeVector.First; num2 < nativeVector.Last; num2 += size)
				{
					_delveLevelScaling.Add(new DelveLevelScalingWrapper(num2, LokiPoe.Memory.FastIntPtrToStruct<DelveLevelScalingWrapper.DelveLevelScalingStruct>(num2), num));
					num++;
				}
				return _delveLevelScaling;
			}
			ilog_0.WarnFormat("[SkillGems] manager is not loaded yet!", Array.Empty<object>());
			return _delveLevelScaling;
		}
	}

	public static IEnumerable<DatBestiaryRecipesWrapper> BestiaryRecipes
	{
		get
		{
			long num = smethod_24();
			if (num != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(num);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<Tuple<DatBestiaryRecipesWrapper.Struct299, long>> tuples = Containers.StdVectorExStruct299<DatBestiaryRecipesWrapper.Struct299>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					yield return new DatBestiaryRecipesWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[BestiaryRecipes] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatIncursionArchitectWrapper> IncursionArchitect
	{
		get
		{
			long num = smethod_51IncursionArchitectPointer();
			if (num != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(num);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<Tuple<DatIncursionArchitectWrapper.Struct311, long>> tuples = Containers.StdListStruct311VectorEx<DatIncursionArchitectWrapper.Struct311>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					yield return new DatIncursionArchitectWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[IncursionArchitect] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatIncursionRoomsWrapper> IncursionRooms
	{
		get
		{
			long num = smethod_54IncursionRoomsPointer();
			if (num != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(num);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<DatIncursionRoomsWrapper.Struct104> struct104s = Containers.StdStruct104Vector<DatIncursionRoomsWrapper.Struct104>(nativeVector);
				for (int i = 0; i < struct104s.Count; i++)
				{
					yield return new DatIncursionRoomsWrapper(struct104s[i], i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[IncursionRooms] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatMinimapIconWrapper> MinimapIcons
	{
		get
		{
			if (dictionary_MinimapIconWrapper.Any())
			{
				foreach (KeyValuePair<long, DatMinimapIconWrapper> item in dictionary_MinimapIconWrapper)
				{
					yield return item.Value;
				}
				yield break;
			}
			long num = smethod_58MinimapIconsPointer();
			if (num != 0L)
			{
				NativeVector nativeVector = LongToNativeVector(num);
				if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
				{
					throw new Exception("This client version is not supported.");
				}
				List<Tuple<DatMinimapIconWrapper.Struct315, long>> tuples = Containers.StdVectorExStruct315<DatMinimapIconWrapper.Struct315>(nativeVector);
				for (int i = 0; i < tuples.Count; i++)
				{
					yield return new DatMinimapIconWrapper(tuples[i].Item2, tuples[i].Item1, i + 1);
				}
			}
			else
			{
				ilog_0.WarnFormat("[MinimapIcons] manager is not loaded yet!", Array.Empty<object>());
			}
		}
	}

	public static IEnumerable<DatPassiveSkillWrapper> PassiveSkills
	{
		get
		{
			if (!dictionary_IdToPassiveSkillWrapper.Any())
			{
				long num = smethod_69();
				if (num != 0L)
				{
					NativeVector nativeVector = LongToNativeVector(num);
					if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
					{
						throw new Exception("This client version is not supported.");
					}
					List<DatPassiveSkillWrapper.Struct131> struct131s = Containers.StdStruct131Vector<DatPassiveSkillWrapper.Struct131>(nativeVector);
					int i = 0;
					if (i < struct131s.Count)
					{
						yield return new DatPassiveSkillWrapper(struct131s[i], i + 1);
						/*Error: Unable to find new state assignment for yield return*/;
					}
				}
				else
				{
					ilog_0.WarnFormat("[PassiveSkills] manager is not loaded yet!", Array.Empty<object>());
				}
				yield break;
			}
			using Dictionary<int, DatPassiveSkillWrapper>.Enumerator enumerator = dictionary_IdToPassiveSkillWrapper.GetEnumerator();
			if (enumerator.MoveNext())
			{
				yield return enumerator.Current.Value;
				/*Error: Unable to find new state assignment for yield return*/;
			}
		}
	}

	public static IEnumerable<DatStatWrapper> Stats
	{
		get
		{
			if (dictionary_StatWrapper != null && dictionary_StatWrapper.Count > 0)
			{
				foreach (KeyValuePair<long, DatStatWrapper> item in dictionary_StatWrapper)
				{
					yield return item.Value;
				}
				yield break;
			}
			long num2 = smethod_79();
			if (num2 == 0L)
			{
				ilog_0.WarnFormat("[Stats] manager is not loaded yet!", Array.Empty<object>());
				yield break;
			}
			NativeVector nativeVector = LongToNativeVector(num2);
			if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
			{
				throw new Exception("This client version is not supported.");
			}
			List<Tuple<DatStatWrapper.Struct325, long>> list = Containers.StdVectorExStruct325<DatStatWrapper.Struct325>(nativeVector);
			int num = 0;
			while (num < list.Count)
			{
				yield return new DatStatWrapper(list[num].Item2, list[num].Item1, num + 1);
				int num3 = num + 1;
				num = num3;
			}
		}
	}

	public static string PathToQuestRewardsDat => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "GGPK", "QuestRewards.dat");

	public static string PathToQuestRewardsDat2 => Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "GGPK", "QuestRewards2.dat");

	public static List<DatQuestRewardWrapper> QuestRewards
	{
		get
		{
			if (list_1 == null)
			{
				List<DatQuestRewardWrapper> list = new List<DatQuestRewardWrapper>();
				Dictionary<int, DatBaseItemTypeWrapper> dictionary = BaseItemTypes.ToDictionary(Class334.Class9.method_7);
				Dictionary<int, DatQuestWrapper> dictionary2 = Quests.ToDictionary(Class334.Class9.method_8);
				int size = MarshalCache<NativeQuestStaticReward>.Size;
				FieldInfo[] fields = typeof(NativeQuestStaticReward).GetFields(BindingFlags.Instance | BindingFlags.Public);
				List<NativeQuestStaticReward> list2 = new List<NativeQuestStaticReward>();
				using (FileStream input = new FileStream(PathToQuestRewardsDat, FileMode.Open, FileAccess.Read))
				{
					using BinaryReader binaryReader = new BinaryReader(input);
					int num = binaryReader.ReadInt32();
					for (int i = 0; i < num; i++)
					{
						list2.Add(smethod_73(binaryReader.ReadBytes(size)));
					}
					if (binaryReader.ReadUInt64() != 13527612320720337851uL)
					{
						throw new Exception("Error: The data format has changed.");
					}
					binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position));
				}
				uint num3 = default(uint);
				int num5 = default(int);
				foreach (NativeQuestStaticReward item in list2)
				{
					try
					{
						DatQuestRewardWrapper datQuestRewardWrapper = new DatQuestRewardWrapper
						{
							NativeQuestReward_0 = item
						};
						while (true)
						{
							IL_03c1:
							FieldInfo[] array = fields;
							int num2 = 0;
							while (true)
							{
								IL_03b4:
								if (num2 < array.Length)
								{
									while (true)
									{
										IL_02e5:
										FieldInfo fieldInfo = array[num2];
										object value = fieldInfo.GetValue(item);
										while (true)
										{
											IL_02d0:
											if (!(fieldInfo.Name == "ItemId"))
											{
												while (true)
												{
													IL_02bb:
													if (!(fieldInfo.Name == "QuestId"))
													{
														while (true)
														{
															IL_02a3:
															if (fieldInfo.Name == "Rarity")
															{
																goto IL_0150;
															}
															goto IL_028b;
															IL_028b:
															if (!(fieldInfo.Name == "CharacterClass"))
															{
																break;
															}
															goto IL_025a;
															IL_025a:
															switch ((int)value)
															{
															case 0:
																goto IL_036a;
															case 1:
																goto IL_0374;
															case 2:
																goto IL_037e;
															case 3:
																goto IL_0388;
															case 4:
																goto IL_0392;
															case 5:
																goto IL_039c;
															case 6:
																goto IL_03a6;
															}
															int num4 = ((int)num3 * -224808891) ^ 0x6F496921;
															goto IL_018c;
															IL_034c:
															datQuestRewardWrapper.Rarity = Rarity.Normal;
															break;
															IL_018c:
															while (true)
															{
																switch ((num3 = (uint)num4 ^ 0xD0F7640Bu) % 46u)
																{
																case 45u:
																	num4 = (int)(num3 * 11629176) ^ -1098672402;
																	continue;
																case 44u:
																	break;
																case 32u:
																	goto IL_0159;
																case 40u:
																	num4 = ((int)num3 * -1814664933) ^ 0x2EEB91C0;
																	continue;
																default:
																	goto end_IL_02d0;
																case 33u:
																	goto IL_025a;
																case 39u:
																	goto IL_028b;
																case 6u:
																	goto IL_02a3;
																case 37u:
																	goto IL_02bb;
																case 19u:
																	goto IL_02d0;
																case 24u:
																	goto IL_02e5;
																case 17u:
																	datQuestRewardWrapper.Rarity = Rarity.Quest;
																	goto end_IL_02a3;
																case 21u:
																	goto IL_030b;
																case 35u:
																	datQuestRewardWrapper.Class = CharacterClass.None;
																	goto end_IL_02a3;
																case 38u:
																	goto IL_0334;
																case 7u:
																	goto IL_034c;
																case 8u:
																	goto IL_0356;
																case 4u:
																	goto IL_0360;
																case 43u:
																	goto IL_036a;
																case 28u:
																	goto IL_0374;
																case 36u:
																	goto IL_037e;
																case 0u:
																	goto IL_0388;
																case 1u:
																	goto IL_0392;
																case 20u:
																	goto IL_039c;
																case 27u:
																	goto IL_03a6;
																case 2u:
																case 5u:
																case 11u:
																case 15u:
																case 22u:
																case 31u:
																case 34u:
																case 41u:
																case 42u:
																	goto end_IL_02a3;
																case 3u:
																	goto IL_03b4;
																case 18u:
																case 26u:
																	goto IL_03c1;
																case 16u:
																	goto IL_03ca;
																case 29u:
																	goto IL_03d6;
																case 14u:
																	goto IL_03ee;
																case 25u:
																	goto IL_0406;
																case 13u:
																	goto IL_041e;
																case 9u:
																	goto IL_0428;
																case 30u:
																	goto IL_0432;
																case 10u:
																	goto IL_044a;
																case 23u:
																	goto IL_0452;
																case 12u:
																	goto end_IL_02d0;
																}
																break;
															}
															goto IL_0150;
															IL_03a6:
															datQuestRewardWrapper.Class = CharacterClass.Templar;
															break;
															IL_039c:
															datQuestRewardWrapper.Class = CharacterClass.Shadow;
															break;
															IL_0392:
															datQuestRewardWrapper.Class = CharacterClass.Duelist;
															break;
															IL_0388:
															datQuestRewardWrapper.Class = CharacterClass.Ranger;
															break;
															IL_037e:
															datQuestRewardWrapper.Class = CharacterClass.Scion;
															break;
															IL_0374:
															datQuestRewardWrapper.Class = CharacterClass.Witch;
															break;
															IL_036a:
															datQuestRewardWrapper.Class = CharacterClass.Marauder;
															break;
															IL_0150:
															num5 = (int)value;
															goto IL_0159;
															IL_0159:
															switch (num5)
															{
															case 1:
																goto IL_034c;
															case 2:
																goto IL_0356;
															case 3:
																goto IL_0360;
															}
															num4 = ((int)num3 * -928565094) ^ 0x10275069;
															goto IL_018c;
															IL_0360:
															datQuestRewardWrapper.Rarity = Rarity.Rare;
															break;
															IL_0356:
															datQuestRewardWrapper.Rarity = Rarity.Magic;
															break;
															continue;
															end_IL_02a3:
															break;
														}
														break;
													}
													goto IL_0334;
													IL_0334:
													datQuestRewardWrapper.Quest = dictionary2[(int)value + 1];
													break;
												}
												goto IL_03ae;
											}
											goto IL_030b;
											IL_03ae:
											num2++;
											goto IL_03b4;
											IL_030b:
											datQuestRewardWrapper.Item = dictionary[(int)value + 1];
											goto IL_03ae;
											continue;
											end_IL_02d0:
											break;
										}
										break;
									}
									break;
								}
								goto IL_03ca;
								IL_0452:
								list.Add(datQuestRewardWrapper);
								break;
								IL_03ca:
								if (datQuestRewardWrapper.Rarity == Rarity.Quest)
								{
									goto IL_03d6;
								}
								goto IL_0452;
								IL_03d6:
								if (!datQuestRewardWrapper.Item.ItemClass.Equals("Active Skill Gem"))
								{
									goto IL_03ee;
								}
								goto IL_0428;
								IL_03ee:
								if (!datQuestRewardWrapper.Item.ItemClass.Equals("Support Skill Gem"))
								{
									goto IL_0406;
								}
								goto IL_0428;
								IL_0406:
								if (datQuestRewardWrapper.Item.ItemClass.Equals("StackableCurrency"))
								{
									goto IL_041e;
								}
								goto IL_0432;
								IL_041e:
								datQuestRewardWrapper.Rarity = Rarity.Currency;
								goto IL_0452;
								IL_0432:
								if (datQuestRewardWrapper.Item.ItemClass.Equals("Jewel"))
								{
									goto IL_044a;
								}
								goto IL_0452;
								IL_044a:
								datQuestRewardWrapper.Rarity = Rarity.Unique;
								goto IL_0452;
								IL_0428:
								datQuestRewardWrapper.Rarity = Rarity.Gem;
								goto IL_0452;
							}
							break;
						}
					}
					catch (Exception)
					{
					}
				}
				list_1 = list;
			}
			return list_1;
		}
	}

	public static DatBaseItemTypeWrapper LookupBaseItemType(string metadata)
	{
		if (Enum.TryParse<BaseItemTypeEnum>(LokiPoe.CleanifyMetadataString(metadata), ignoreCase: true, out var result))
		{
			return LookupBaseItemType(result);
		}
		return null;
	}

	private static DatBaseItemTypeWrapper LookupBaseItemType(BaseItemTypeEnum @enum)
	{
		smethod_14();
		if (_dictionaryBaseItemTypeId != null && _dictionaryBaseItemTypeId.TryGetValue(@enum, out var value))
		{
			return value;
		}
		return null;
	}

	public static DatBaseItemTypeWrapper LookupBaseItemTypeByName(string name)
	{
		smethod_14();
		if (_dictionaryBaseItemTypeNamesToEnum != null && _dictionaryBaseItemTypeNamesToEnum.TryGetValue(name, out var value))
		{
			return LookupBaseItemType(value);
		}
		return null;
	}

	public static DatWorldAreaWrapper LookupWorldArea(string worldAreaId)
	{
		if (dictionary_17 == null)
		{
			List<DatWorldAreaWrapper> list = WorldAreas.ToList();
			if (!list.Any())
			{
				return null;
			}
			dictionary_17 = new Dictionary<string, DatWorldAreaWrapper>();
			try
			{
				foreach (DatWorldAreaWrapper item in list)
				{
					dictionary_17.Add(item.Id.ToLowerInvariant(), item);
				}
			}
			catch (Exception)
			{
				dictionary_17 = null;
				throw;
			}
		}
		if (worldAreaId == null)
		{
			return null;
		}
		if (dictionary_17.TryGetValue(worldAreaId.ToLowerInvariant(), out var value))
		{
			return value;
		}
		return null;
	}

	public static DatWorldAreaWrapper LookupWorldArea(int areaIndex)
	{
		if (dictionary_17 == null)
		{
			List<DatWorldAreaWrapper> list = WorldAreas.ToList();
			if (!list.Any())
			{
				return null;
			}
			dictionary_17 = new Dictionary<string, DatWorldAreaWrapper>();
			try
			{
				foreach (DatWorldAreaWrapper item in list)
				{
					dictionary_17.Add(item.Id.ToLowerInvariant(), item);
				}
			}
			catch (Exception)
			{
				dictionary_17 = null;
				throw;
			}
		}
		foreach (KeyValuePair<string, DatWorldAreaWrapper> item2 in dictionary_17)
		{
			if (item2.Value.Index == areaIndex)
			{
				return item2.Value;
			}
		}
		return null;
	}

	public static DatWorldAreaWrapper LookupWorldAreaByworldAreaId(ushort worldAreaId)
	{
		if (dictionary_17 == null)
		{
			List<DatWorldAreaWrapper> list = WorldAreas.ToList();
			if (!list.Any())
			{
				return null;
			}
			dictionary_17 = new Dictionary<string, DatWorldAreaWrapper>();
			try
			{
				foreach (DatWorldAreaWrapper item in list)
				{
					dictionary_17.Add(item.Id.ToLowerInvariant(), item);
				}
			}
			catch (Exception)
			{
				dictionary_17 = null;
				throw;
			}
		}
		foreach (KeyValuePair<string, DatWorldAreaWrapper> item2 in dictionary_17)
		{
			if (item2.Value.WorldAreaId == worldAreaId)
			{
				return item2.Value;
			}
		}
		return null;
	}

	public static DatQuestStateWrapper LookupQuestState(DatQuestWrapper quest, int stateId)
	{
		return LookupQuestState(quest.Id, stateId);
	}

	public static DatQuestStateWrapper LookupQuestState(string questId, int stateId)
	{
		Dictionary<int, DatQuestStateWrapper> value;
		if (QuestStateDictionary == null)
		{
			List<DatQuestStateWrapper> list = QuestStates.ToList();
			if (!list.Any())
			{
				return null;
			}
			QuestStateDictionary = new Dictionary<string, Dictionary<int, DatQuestStateWrapper>>();
			try
			{
				foreach (DatQuestStateWrapper item in list)
				{
					if (!QuestStateDictionary.TryGetValue(item.Quest.Id, out value))
					{
						value = new Dictionary<int, DatQuestStateWrapper>();
						QuestStateDictionary.Add(item.Quest.Id.ToLowerInvariant(), value);
					}
					value.Add(item.Id, item);
				}
			}
			catch (Exception)
			{
				QuestStateDictionary = null;
				throw;
			}
		}
		if (QuestStateDictionary.TryGetValue(questId.ToLowerInvariant(), out value) && value.TryGetValue(stateId, out var value2))
		{
			return value2;
		}
		return null;
	}

	public static DatClientStringWrapper LookupClientString(ClientStringsEnum @enum)
	{
		smethod_28();
		if (dictionary_4 != null && dictionary_4.TryGetValue(@enum, out var value))
		{
			return value;
		}
		return null;
	}

	public static DatPropheciesWrapper LookupProphecy(int value)
	{
		if (dictionary_12 == null)
		{
			List<DatPropheciesWrapper> list = Prophecies.ToList();
			if (!list.Any())
			{
				return null;
			}
			dictionary_12 = new Dictionary<int, DatPropheciesWrapper>();
			try
			{
				foreach (DatPropheciesWrapper item in list)
				{
					dictionary_12.Add(item.ProphecyId, item);
				}
			}
			catch (Exception)
			{
				dictionary_12 = null;
				throw;
			}
		}
		if (dictionary_12.TryGetValue(value, out var value2))
		{
			return value2;
		}
		return null;
	}

	public static DatWorldAreaWrapper LookupWorldAreaByIdHash(int worldAreaId)
	{
		if (dictionary_18 == null)
		{
			List<DatWorldAreaWrapper> list = WorldAreas.ToList();
			if (!list.Any())
			{
				return null;
			}
			dictionary_18 = new Dictionary<int, DatWorldAreaWrapper>();
			try
			{
				foreach (DatWorldAreaWrapper item in list)
				{
					dictionary_18.Add(item.WorldAreaId, item);
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"Could not add an area: ", ex);
				dictionary_18 = null;
				throw;
			}
		}
		if (dictionary_18.TryGetValue(worldAreaId, out var value))
		{
			return value;
		}
		return null;
	}

	internal static void smethod_2(string string_0, long intptr_1)
	{
	}

	internal static NativeVector LongToNativeVector(long intptr_1)
	{
		long num = LokiPoe.Memory.ReadLong(intptr_1 + 48L);
		if (num == 0L)
		{
			return default(NativeVector);
		}
		return LokiPoe.Memory.ReadNativeVector(num);
	}

	internal static void BuildStatLookupTable()
	{
		if (IdToStatWrapper.Any())
		{
			return;
		}
		ilog_0.InfoFormat("[Dat] Now building the Stat lookup table.", Array.Empty<object>());
		foreach (DatStatWrapper item in Stats.ToList())
		{
			IdToStatWrapper.Add(item.Id, item);
		}
		ilog_0.InfoFormat("[Dat] The Stat lookup table has been built.", Array.Empty<object>());
	}

	internal static void BuildPassinveLookupTable()
	{
		if (dictionary_IdToPassiveSkillWrapper.Any() || !GameStateController.IsInGameState)
		{
			return;
		}
		ilog_0.InfoFormat("[Dat] Now building the Passive Skills lookup table.", Array.Empty<object>());
		foreach (DatPassiveSkillWrapper item in PassiveSkills.ToList())
		{
			dictionary_IdToPassiveSkillWrapper.Add(item.PassiveId, item);
		}
		ilog_0.InfoFormat("[Dat] The Passive Skills lookup table has been built.", Array.Empty<object>());
	}

	internal static void CreateActiveSkillCache()
	{
		ilog_0.InfoFormat("Now creating the ActiveSkills cache.", Array.Empty<object>());
		dictionary_0.Clear();
		foreach (DatActiveSkillWrapper activeSkill in ActiveSkills)
		{
			dictionary_0.Add(activeSkill.BaseAddress, activeSkill);
		}
	}

	internal static DatActiveSkillWrapper smethod_11(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_0.Any())
		{
			CreateActiveSkillCache();
		}
		if (!dictionary_0.TryGetValue(intptr_1, out var value))
		{
			if (bool_0)
			{
				smethod_2("GetActiveSkillFromCache", intptr_1);
				return new DatActiveSkillWrapper(intptr_1);
			}
			return null;
		}
		return value;
	}

	internal static void smethod_14()
	{
		if (_dictionaryBaseItemTypeId != null && _dictionaryBaseItemTypeId.Count > 0)
		{
			return;
		}
		Dictionary<string, BaseItemType> contents = GameController.Instance.Files.BaseItemTypes.contents;
		if (!contents.Any())
		{
			return;
		}
		_dictionaryBaseItemTypeId = new Dictionary<BaseItemTypeEnum, DatBaseItemTypeWrapper>();
		_dictionaryBaseItemTypeNamesToEnum = new Dictionary<string, BaseItemTypeEnum>();
		int num = 0;
		foreach (KeyValuePair<string, BaseItemType> item in contents)
		{
			try
			{
				string text = LokiPoe.CleanifyMetadataString(item.Key);
				if (Enum.TryParse<BaseItemTypeEnum>(text, out var result))
				{
					_dictionaryBaseItemTypeId.Add(result, new DatBaseItemTypeWrapper(item.Value.Address, item.Value, item.Key, num + 1));
					if (!string.IsNullOrEmpty(item.Value.BaseName) && !_dictionaryBaseItemTypeNamesToEnum.ContainsKey(item.Value.BaseName))
					{
						_dictionaryBaseItemTypeNamesToEnum.Add(item.Value.BaseName, result);
					}
				}
				else if (text == null)
				{
					ilog_0.ErrorFormat("[PreloadBaseItemTypes-Missing]  {0}", (object)item.Key);
				}
				else if (!text.Contains("_Microtransaction") && !text.Contains("_Pets_") && !text.Contains("_Hideout_") && !text.Contains("_Heist_") && !text.Contains("Royale") && !text.Contains("_Currency_RandomFossilOutcome"))
				{
					ilog_0.ErrorFormat("[PreloadBaseItemTypes-Missing]  {0}", (object)text);
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"[PreloadBaseItemTypes] A BaseItemTypeEnum was not found!", ex);
			}
			num++;
		}
	}

	internal static void smethod_16()
	{
		ilog_0.InfoFormat("Now reloading the BaseItemTypes cache.", Array.Empty<object>());
		dictionary_BaseItemTypeWrapper.Clear();
		foreach (DatBaseItemTypeWrapper baseItemType in BaseItemTypes)
		{
			dictionary_BaseItemTypeWrapper.Add(baseItemType.BaseAddress, baseItemType);
		}
		ilog_0.InfoFormat("The BaseItemTypes cache has been reloaded.", Array.Empty<object>());
	}

	internal static DatBaseItemTypeWrapper GetBaseItemTypeWrapperByAddress(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_BaseItemTypeWrapper.Any())
		{
			smethod_16();
		}
		if (!dictionary_BaseItemTypeWrapper.TryGetValue(intptr_1, out var value))
		{
			if (!bool_0)
			{
				return null;
			}
			smethod_2("GetBaseItemTypeFromCache", intptr_1);
			return new DatBaseItemTypeWrapper(intptr_1);
		}
		return value;
	}

	internal static long smethod_27()
	{
		return GameController.Instance.Files.ClientStrings.Address;
	}

	internal static void smethod_28()
	{
		if (dictionary_4 != null)
		{
			return;
		}
		List<DatClientStringWrapper> list = ClientStrings.ToList();
		if (!list.Any())
		{
			return;
		}
		dictionary_4 = new Dictionary<ClientStringsEnum, DatClientStringWrapper>();
		foreach (DatClientStringWrapper item in list)
		{
			try
			{
				string value = LokiPoe.CleanifyClientString(item.Key);
				if (Enum.TryParse<ClientStringsEnum>(value, ignoreCase: true, out var result))
				{
					dictionary_4.Add(result, item);
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"[PreloadClientStrings] A ClientStringsEnum was not found!", ex);
			}
		}
	}

	internal static void smethod_29()
	{
		ilog_0.InfoFormat("Now reloading the ClientStrings cache.", Array.Empty<object>());
		dictionary_5.Clear();
		foreach (DatClientStringWrapper clientString in ClientStrings)
		{
			dictionary_5.Add(clientString.BaseAddress, clientString);
		}
		ilog_0.InfoFormat("The ClientStrings cache has been reloaded.", Array.Empty<object>());
	}

	internal static DatClientStringWrapper smethod_30(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_5.Any())
		{
			smethod_29();
		}
		if (!dictionary_5.TryGetValue(intptr_1, out var value))
		{
			if (!bool_0)
			{
				return null;
			}
			smethod_2("GetClientStringFromCache", intptr_1);
			return new DatClientStringWrapper(intptr_1);
		}
		return value;
	}

	internal static long smethod_61ModsPointer()
	{
		return GameController.Instance.Files.FindFile("Data/Mods.dat");
	}

	internal static long smethod_82WordsPointer()
	{
		return GameController.Instance.Files.FindFile("Data/Words.dat");
	}

	internal static long smethod_24()
	{
		return GameController.Instance.Files.FindFile("Data/BestiaryRecipes.dat");
	}

	internal static long smethod_51IncursionArchitectPointer()
	{
		return GameController.Instance.Files.IncursionArchitect;
	}

	internal static long smethod_54IncursionRoomsPointer()
	{
		return GameController.Instance.Files.IncursionRooms;
	}

	internal static void smethod_52()
	{
		ilog_0.InfoFormat("Now creating the IncursionArchitect cache.", Array.Empty<object>());
		dictionary_8.Clear();
		foreach (DatIncursionArchitectWrapper item in IncursionArchitect)
		{
			dictionary_8.Add(item.BaseAddress, item);
		}
	}

	internal static DatIncursionArchitectWrapper smethod_53(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_8.Any())
		{
			smethod_52();
		}
		if (dictionary_8.TryGetValue(intptr_1, out var value))
		{
			return value;
		}
		if (bool_0)
		{
			smethod_2("GetIncursionArchitectFromCache", intptr_1);
			return new DatIncursionArchitectWrapper(intptr_1);
		}
		return null;
	}

	internal static long smethod_58MinimapIconsPointer()
	{
		return GameController.Instance.Files.MinimapIcons.Address;
	}

	internal static void smethod_59()
	{
		ilog_0.InfoFormat("Now creating the MinimapIcons cache.", Array.Empty<object>());
		dictionary_MinimapIconWrapper.Clear();
		foreach (DatMinimapIconWrapper minimapIcon in MinimapIcons)
		{
			dictionary_MinimapIconWrapper.Add(minimapIcon.BaseAddress, minimapIcon);
		}
	}

	internal static DatMinimapIconWrapper smethod_60(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_MinimapIconWrapper.Any())
		{
			smethod_59();
		}
		if (!dictionary_MinimapIconWrapper.TryGetValue(intptr_1, out var value))
		{
			if (!bool_0)
			{
				return null;
			}
			smethod_2("GetMinimapIconFromCache", intptr_1);
			return new DatMinimapIconWrapper(intptr_1);
		}
		return value;
	}

	internal static long smethod_69()
	{
		return GameController.Instance.Files.PassiveSkills.Address;
	}

	internal static long smethod_70()
	{
		return GameController.Instance.Files.Prophecies.Address;
	}

	private static void smethod_71()
	{
		ilog_0.InfoFormat("Now creating the Prophecies cache.", Array.Empty<object>());
		dictionary_11.Clear();
		foreach (DatPropheciesWrapper prophecy in Prophecies)
		{
			dictionary_11.Add(prophecy.BaseAddress, prophecy);
		}
	}

	internal static DatPropheciesWrapper smethod_72(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_11.Any())
		{
			smethod_71();
		}
		if (!dictionary_11.TryGetValue(intptr_1, out var value))
		{
			if (!bool_0)
			{
				return null;
			}
			smethod_2("GetProphecyFromCache", intptr_1);
			return new DatPropheciesWrapper(intptr_1);
		}
		return value;
	}

	private static long smethod_79()
	{
		return GameController.Instance.Files.Stats.Address;
	}

	private static void BuildStatDictionary()
	{
		ilog_0.InfoFormat("Now creating the Stats cache.", Array.Empty<object>());
		dictionary_StatWrapper.Clear();
		foreach (DatStatWrapper stat in Stats)
		{
			dictionary_StatWrapper.Add(stat.BaseAddress, stat);
		}
	}

	internal static DatStatWrapper GetStatWrapperByAddress(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_StatWrapper.Any())
		{
			BuildStatDictionary();
		}
		if (!dictionary_StatWrapper.TryGetValue(intptr_1, out var value))
		{
			if (bool_0)
			{
				smethod_2("GetStatFromCache", intptr_1);
				return new DatStatWrapper(intptr_1);
			}
			return null;
		}
		return value;
	}

	internal static void LoadWorldAreaCache()
	{
		ilog_0.InfoFormat("Now reloading the WorldArea cache.", Array.Empty<object>());
		dictionary_WorldAreaWrapper.Clear();
		foreach (DatWorldAreaWrapper worldArea in WorldAreas)
		{
			dictionary_WorldAreaWrapper.Add(worldArea.IntPtr_0, worldArea);
		}
		ilog_0.InfoFormat("The WorldArea cache has been reloaded.", Array.Empty<object>());
	}

	internal static DatWorldAreaWrapper GetWorldArea(long intptr_1, bool bool_0 = false)
	{
		if (intptr_1 == 0L)
		{
			return null;
		}
		if (!dictionary_WorldAreaWrapper.Any())
		{
			LoadWorldAreaCache();
		}
		if (!dictionary_WorldAreaWrapper.TryGetValue(intptr_1, out var value))
		{
			if (!bool_0)
			{
				return null;
			}
			smethod_2("GetWorldAreaFromCache", intptr_1);
			return new DatWorldAreaWrapper(intptr_1);
		}
		return value;
	}

	public static void DumpStats()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("None = 0,");
		foreach (DatStatWrapper stat in Stats)
		{
			stringBuilder.AppendLine($"{stat.ApiId} = {stat.Index},");
		}
		StreamWriter streamWriter = new StreamWriter("\\DreamPoeBotDumps\\Stats.txt");
		streamWriter.WriteLine(stringBuilder.ToString());
	}

	internal unsafe static NativeQuestStaticReward smethod_73(byte[] byte_0)
	{
		fixed (byte* ptr = &byte_0[0])
		{
			return *(NativeQuestStaticReward*)ptr;
		}
	}
}
