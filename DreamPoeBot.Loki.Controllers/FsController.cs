using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Controllers;

public class FsController
{
	public readonly struct FileInformation
	{
		public long Ptr { get; }

		public int ChangeCount { get; }

		public FileInformation(long ptr, int changeCount)
		{
			Ptr = ptr;
			ChangeCount = changeCount;
		}
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct FileInformationStruct
	{
		[FieldOffset(8)]
		public long String;

		[FieldOffset(24)]
		public long Size;

		[FieldOffset(32)]
		public long Capacity;

		[FieldOffset(56)]
		public int AreaCount;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct FileRootBlock
	{
		[FieldOffset(16)]
		public long Capacity;

		[FieldOffset(8)]
		public long FileNodesPtr;

		[FieldOffset(32)]
		public long Count;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public BaseItemTypes BaseItemTypes;

	public ModsDat Mods;

	public StatsDat Stats;

	public TagsDat Tags;

	private static FragmentStashTabLayouts _fragmentStashTabLayoutDat;

	private static CurrencyStashTabLayouts _currencyStashTabLayouts;

	private static PantheonSoulsDatFileWrapper _pantheonSoulsDatFileWrapper;

	public PantheonSoulsDatFileWrapper PantheonSoulsDatFileWrapper = ((_pantheonSoulsDatFileWrapper != null) ? _pantheonSoulsDatFileWrapper : new PantheonSoulsDatFileWrapper());

	private static BlightStashTabLayouts _blightStashTabLayouts;

	private static StatDescription _statDescription;

	private GrantedEffectsPerLevelDat grantedEffectsPerLevel;

	private QuestFlagsDat questFlags;

	private WorldAreas worldAreas;

	private PassiveSkills passiveSkills;

	private LabyrinthTrials labyrinthTrials;

	private UniversalFileWrapper<Quest> quests;

	private UniversalFileWrapper<Quest> clientStrings;

	private UniversalFileWrapper<Quest> minimapIcons;

	private long activeSkillsPtr;

	private long _skillGemsPtr;

	private long incursionArchitect;

	private long _delveLevelScaling;

	private long incursionRooms;

	private QuestStates questStates;

	private MonsterVarieties monsterVarieties;

	private PropheciesDat prophecies;

	private UniversalFileWrapper<AtlasNode> atlasNodes;

	private QuestReward questRewards;

	private PerAreaCachedValue<Dictionary<string, long>> _perAreaCached_FileAddressDictionary;

	private bool forceReload;

	private readonly Memory mem;

	public FragmentStashTabLayouts FragmentStashTabLayoutDat => _fragmentStashTabLayoutDat ?? (_fragmentStashTabLayoutDat = new FragmentStashTabLayouts(mem, 0L));

	public CurrencyStashTabLayouts CurrencyStashTabLayoutDat
	{
		get
		{
			if (_currencyStashTabLayouts == null)
			{
				return _currencyStashTabLayouts = new CurrencyStashTabLayouts(mem, 0L);
			}
			return _currencyStashTabLayouts;
		}
	}

	public BlightStashTabLayouts BlightStashTabLayoutDat => _blightStashTabLayouts ?? (_blightStashTabLayouts = new BlightStashTabLayouts());

	public StatDescription StatDescription => _statDescription ?? (_statDescription = new StatDescription());

	public GrantedEffectsPerLevelDat GrantedEffectsPerLevel => grantedEffectsPerLevel ?? (grantedEffectsPerLevel = new GrantedEffectsPerLevelDat(mem, FindFile("Data/GrantedEffectsPerLevel.dat")));

	public QuestFlagsDat QuestFlags => questFlags ?? (questFlags = new QuestFlagsDat(mem, FindFile("Data/QuestFlags.dat")));

	public WorldAreas WorldAreas => worldAreas ?? (worldAreas = new WorldAreas(mem, FindFile("Data/WorldAreas.dat")));

	public PassiveSkills PassiveSkills => passiveSkills ?? (passiveSkills = new PassiveSkills(mem, FindFile("Data/PassiveSkills.dat")));

	public LabyrinthTrials LabyrinthTrials => labyrinthTrials ?? (labyrinthTrials = new LabyrinthTrials(mem, FindFile("Data/LabyrinthTrials.dat")));

	public UniversalFileWrapper<Quest> Quests => quests ?? (quests = new UniversalFileWrapper<Quest>(mem, FindFile("Data/Quest.dat")));

	public UniversalFileWrapper<Quest> ClientStrings => clientStrings ?? (clientStrings = new UniversalFileWrapper<Quest>(mem, FindFile("Data/ClientStrings.dat")));

	public UniversalFileWrapper<Quest> MinimapIcons => minimapIcons ?? (minimapIcons = new UniversalFileWrapper<Quest>(mem, FindFile("Data/MinimapIcons.dat")));

	public long ActiveSkillsPtr
	{
		get
		{
			if (activeSkillsPtr == 0L)
			{
				return FindFile("Data/ActiveSkills.dat");
			}
			return activeSkillsPtr;
		}
	}

	public long SkillGemsPtr
	{
		get
		{
			if (_skillGemsPtr == 0L)
			{
				return FindFile("Data/SkillGems.dat");
			}
			return _skillGemsPtr;
		}
	}

	public long IncursionArchitect
	{
		get
		{
			if (incursionArchitect == 0L)
			{
				return incursionArchitect = FindFile("Data/IncursionArchitect.dat");
			}
			return incursionArchitect;
		}
	}

	public long DelveLevelScaling
	{
		get
		{
			if (_delveLevelScaling == 0L)
			{
				return _delveLevelScaling = FindFile("Data/DelveLevelScaling.dat");
			}
			return _delveLevelScaling;
		}
	}

	public long IncursionRooms
	{
		get
		{
			if (incursionRooms == 0L)
			{
				return incursionRooms = FindFile("Data/IncursionRooms.dat");
			}
			return incursionRooms;
		}
	}

	public QuestStates QuestStates => questStates ?? (questStates = new QuestStates(mem, FindFile("Data/QuestStates.dat")));

	public MonsterVarieties MonsterVarieties => monsterVarieties ?? (monsterVarieties = new MonsterVarieties(mem, FindFile("Data/MonsterVarieties.dat")));

	public PropheciesDat Prophecies => prophecies ?? (prophecies = new PropheciesDat(mem, FindFile("Data/Prophecies.dat")));

	public UniversalFileWrapper<AtlasNode> AtlasNodes => atlasNodes ?? (atlasNodes = new UniversalFileWrapper<AtlasNode>(mem, FindFile("Data/AtlasNode.dat")));

	internal Dictionary<string, long> FileAddressDictionary
	{
		get
		{
			if (forceReload || _perAreaCached_FileAddressDictionary == null)
			{
				_perAreaCached_FileAddressDictionary = new PerAreaCachedValue<Dictionary<string, long>>(GetAllFilesNew);
				if (forceReload)
				{
					forceReload = false;
				}
			}
			return _perAreaCached_FileAddressDictionary.Value;
		}
	}

	public void ReloadQuests()
	{
		quests = new UniversalFileWrapper<Quest>(mem, FindFile("Data/Quest.dat"));
	}

	public void ReloadQuestsState()
	{
		questStates = new QuestStates(mem, FindFile("Data/QuestStates.dat", reload: true));
	}

	public FsController(Memory me)
	{
		mem = me;
	}

	public bool DumpDataFiles()
	{
		IEnumerable<KeyValuePair<string, long>> enumerable = FileAddressDictionary.Where((KeyValuePair<string, long> x) => x.Key != null && x.Key.Contains("Data/"));
		StringBuilder stringBuilder = new StringBuilder();
		int num = 1;
		foreach (KeyValuePair<string, long> item in enumerable)
		{
			stringBuilder.Append(item.Key + $" = {item.Value},");
			stringBuilder.Append(Environment.NewLine);
			num++;
		}
		File.WriteAllText("__DataFiles.txt", stringBuilder.ToString());
		return true;
	}

	public long FindFile(string[] names, bool reload = false)
	{
		long fileAddressNew = GetFileAddressNew(names);
		if (fileAddressNew != 0L)
		{
			return fileAddressNew;
		}
		ilog_0.ErrorFormat("Couldn't find the file in memory:\n", Array.Empty<object>());
		foreach (string text in names)
		{
			ilog_0.ErrorFormat("\t{0}\n", (object)text);
		}
		ilog_0.ErrorFormat("Try to restart the game.\n Closing DPB in 5 seconds.", Array.Empty<object>());
		Thread.Sleep(5000);
		Environment.Exit(1);
		return 0L;
	}

	public long FindFile(string name, bool reload = false)
	{
		Stopwatch stopwatch = Stopwatch.StartNew();
		long num = 0L;
		while (num == 0L && stopwatch.ElapsedMilliseconds <= 5000L)
		{
			num = GetFileAddressNew(name);
			if (num == 0L)
			{
				Thread.Sleep(200);
				forceReload = true;
				continue;
			}
			return num;
		}
		ilog_0.ErrorFormat("Couldn't find the file in memory: {0}\nTry to restart the game.\n Closing DPB in 5 seconds.", (object)name);
		Thread.Sleep(5000);
		Environment.Exit(1);
		return 0L;
	}

	public Dictionary<string, long> GetAllFilesNew()
	{
		int num = 0;
		string fullName = typeof(CustomFileTable).FullName;
		if (!Memory.StructureSizesDictionary.TryGetValue(fullName, out var value))
		{
			num = MarshalCache<CustomFileTable>.Size;
			Memory.StructureSizesDictionary.Add(fullName, num);
		}
		else
		{
			num = value;
		}
		int num2 = 0;
		string fullName2 = typeof(SmallFileTable).FullName;
		if (Memory.StructureSizesDictionary.TryGetValue(fullName2, out var value2))
		{
			num2 = value2;
		}
		else
		{
			num2 = MarshalCache<SmallFileTable>.Size;
			Memory.StructureSizesDictionary.Add(fullName2, num2);
		}
		Dictionary<string, long> dictionary = new Dictionary<string, long>();
		long num3 = mem.AddressOfProcess + mem.offsets.FileRoot;
		int num4 = 0;
		long ptr = num3 + 0L;
		CustomFileTable customFileTable = GameController.Instance.Memory.FastIntPtrToStruct<CustomFileTable>(ptr, num);
		while (customFileTable.header == 0L)
		{
			num4++;
			ptr = num3 + num4 * 40;
			CustomFileTable customFileTable2 = GameController.Instance.Memory.FastIntPtrToStruct<CustomFileTable>(ptr, num);
			long num5 = customFileTable.dataAddress;
			int num6 = 0;
			while (num6 < customFileTable.datalenght)
			{
				SmallFileTable smallFileTable = GameController.Instance.Memory.FastIntPtrToStruct<SmallFileTable>(num5, num2);
				if (smallFileTable.I0 != byte.MaxValue)
				{
					string key = mem.ReadNativeString(smallFileTable.D0.fileAddress + 8L);
					if (!dictionary.ContainsKey(key))
					{
						dictionary.Add(key, smallFileTable.D0.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I1 != byte.MaxValue)
				{
					string key2 = mem.ReadNativeString(smallFileTable.D1.fileAddress + 8L);
					if (!dictionary.ContainsKey(key2))
					{
						dictionary.Add(key2, smallFileTable.D1.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I2 != byte.MaxValue)
				{
					string key3 = mem.ReadNativeString(smallFileTable.D2.fileAddress + 8L);
					if (!dictionary.ContainsKey(key3))
					{
						dictionary.Add(key3, smallFileTable.D2.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I3 != byte.MaxValue)
				{
					string key4 = mem.ReadNativeString(smallFileTable.D3.fileAddress + 8L);
					if (!dictionary.ContainsKey(key4))
					{
						dictionary.Add(key4, smallFileTable.D3.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I4 != byte.MaxValue)
				{
					string key5 = mem.ReadNativeString(smallFileTable.D4.fileAddress + 8L);
					if (!dictionary.ContainsKey(key5))
					{
						dictionary.Add(key5, smallFileTable.D4.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I5 != byte.MaxValue)
				{
					string key6 = mem.ReadNativeString(smallFileTable.D5.fileAddress + 8L);
					if (!dictionary.ContainsKey(key6))
					{
						dictionary.Add(key6, smallFileTable.D5.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I6 != byte.MaxValue)
				{
					string key7 = mem.ReadNativeString(smallFileTable.D6.fileAddress + 8L);
					if (!dictionary.ContainsKey(key7))
					{
						dictionary.Add(key7, smallFileTable.D6.fileAddress);
					}
					num6++;
				}
				if (smallFileTable.I7 != byte.MaxValue)
				{
					string key8 = mem.ReadNativeString(smallFileTable.D7.fileAddress + 8L);
					if (!dictionary.ContainsKey(key8))
					{
						dictionary.Add(key8, smallFileTable.D7.fileAddress);
					}
					num6++;
				}
				num5 += 200L;
			}
			customFileTable = customFileTable2;
		}
		return dictionary;
	}

	private long GetFileAddressNew(string name)
	{
		if (FileAddressDictionary.TryGetValue(name, out var value))
		{
			return value;
		}
		return 0L;
	}

	private long GetFileAddressNew(string[] names)
	{
		foreach (string key in names)
		{
			if (FileAddressDictionary.TryGetValue(key, out var value))
			{
				return value;
			}
		}
		return 0L;
	}

	public void LoadDataFiles()
	{
		BaseItemTypes = new BaseItemTypes(mem, FindFile("Data/BaseItemTypes.dat"));
		Stats = new StatsDat(mem, FindFile("Data/Stats.dat"));
		Tags = new TagsDat(mem, FindFile("Data/Tags.dat"));
		Mods = new ModsDat(mem, FindFile("Data/Mods.dat"), Stats, Tags);
		grantedEffectsPerLevel = new GrantedEffectsPerLevelDat(mem, FindFile("Data/GrantedEffectsPerLevel.dat"));
		questFlags = new QuestFlagsDat(mem, FindFile("Data/QuestFlags.dat"));
	}
}
