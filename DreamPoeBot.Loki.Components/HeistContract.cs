using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class HeistContract : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct HeistContractStructure
	{
		public long vTable;

		public long intptr_Owner;

		public long intptr_0;

		public int int_0;

		public byte byte_0AreaLevel;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public long intptr_DataHeistObjectivesDat;

		public long intptr_DataHeistObjectivesFile;

		public NativeVector DataHeistJobsRequirementVector;

		public NativeVector DataHeistNpcsRequirementVector;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DataHeistObjectivesStructure
	{
		public long intptr_DataBaseItemTypeDat;

		public long intptr_DataBaseItemTypeFile;

		private float float_0;

		public long intptr_ClientName;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DataHeistJobsRequirementStructure
	{
		public long intptr_HeistJobsDat;

		public long intptr_HeistJobsFile;

		public byte byte_level;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct HeistJobsStructure
	{
		public long Id;

		public long Name;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DataHeistNpcsRequirementStructure
	{
		public long intptr_DataNpcsDat;

		public long intptr_DataNpcsFile;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct NpcsDatStructure
	{
		public long intptr_DataNpcsDat;

		public long intptr_DataNpcsFile;

		public long intptr_DataMonsterVarietiesDat;

		public long intptr_DataMonsterVarietiesFile;

		public int SkillLevelHeistJobsCount;

		public int int_0;

		public long SkillLevelHeistJobsAddress;

		public long PortraitAddress;

		public int HeistNpcStatsCount;

		public int int_1;

		public long HeistNpcStatsAddress;

		public long long_0;

		public long long_1;

		private float float_0;

		public int int_2;

		public int int_3;

		public long long_2;

		public long long_Name;

		public long long_4;
	}

	private PerFrameCachedValue<HeistContractStructure> perFrameCachedValue_1;

	private PerFrameCachedValue<DataHeistObjectivesStructure> perFrameCachedValue_2;

	public int AreaLevel => HeistContractStructure_0.byte_0AreaLevel;

	public string ClientName => base.M.ReadStringU(DataHeistObjectivesStructure_0.intptr_ClientName);

	public DatBaseItemTypeWrapper HeistTarget => new DatBaseItemTypeWrapper(DataHeistObjectivesStructure_0.intptr_DataBaseItemTypeDat);

	public Dictionary<string, int> JobsRequires
	{
		get
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			NativeVector dataHeistJobsRequirementVector = HeistContractStructure_0.DataHeistJobsRequirementVector;
			if (dataHeistJobsRequirementVector.First != 0L && dataHeistJobsRequirementVector.Last != 0L)
			{
				int size = MarshalCache<DataHeistJobsRequirementStructure>.Size;
				for (long num = dataHeistJobsRequirementVector.First; num < dataHeistJobsRequirementVector.Last; num += size)
				{
					DataHeistJobsRequirementStructure dataHeistJobsRequirementStructure = base.M.FastIntPtrToStruct<DataHeistJobsRequirementStructure>(num, size);
					dictionary.Add(base.M.ReadStringU(base.M.FastIntPtrToStruct<HeistJobsStructure>(dataHeistJobsRequirementStructure.intptr_HeistJobsDat, 16).Name), dataHeistJobsRequirementStructure.byte_level);
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public List<string> NpcsRequires
	{
		get
		{
			List<string> list = new List<string>();
			NativeVector dataHeistNpcsRequirementVector = HeistContractStructure_0.DataHeistNpcsRequirementVector;
			if (dataHeistNpcsRequirementVector.First != 0L && dataHeistNpcsRequirementVector.Last != 0L)
			{
				int size = MarshalCache<DataHeistNpcsRequirementStructure>.Size;
				for (long num = dataHeistNpcsRequirementVector.First; num < dataHeistNpcsRequirementVector.Last; num += size)
				{
					DataHeistNpcsRequirementStructure dataHeistNpcsRequirementStructure = base.M.FastIntPtrToStruct<DataHeistNpcsRequirementStructure>(num, size);
					NpcsDatStructure npcsDatStructure = base.M.FastIntPtrToStruct<NpcsDatStructure>(dataHeistNpcsRequirementStructure.intptr_DataNpcsDat);
					list.Add(base.M.ReadStringU(npcsDatStructure.long_Name));
				}
				return list;
			}
			return list;
		}
	}

	internal HeistContractStructure HeistContractStructure_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<HeistContractStructure>(() => base.M.FastIntPtrToStruct<HeistContractStructure>(base.Address));
			}
			return perFrameCachedValue_1.Value;
		}
	}

	internal DataHeistObjectivesStructure DataHeistObjectivesStructure_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<DataHeistObjectivesStructure>(() => base.M.FastIntPtrToStruct<DataHeistObjectivesStructure>(HeistContractStructure_0.intptr_DataHeistObjectivesDat));
			}
			return perFrameCachedValue_2.Value;
		}
	}
}
