using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatPassiveSkillMasteryEffectsWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PassiveSkillMasteryEffectsStructure
	{
		public long Id;

		public int MasteryId;

		public int StatsCount;

		private int filler;

		public long Stats;

		public int Stat1;

		public int Stat2;

		public int Stat3;

		private long long1;

		private long long2;
	}

	public string Id { get; private set; }

	public int PassiveSkillMasteryId { get; private set; }

	public int StatsCount { get; private set; }

	public List<KeyValuePair<DatStatWrapper, int>> Stats { get; private set; }

	public int Stat1 { get; private set; }

	public int Stat2 { get; private set; }

	public int Stat3 { get; private set; }

	public DatPassiveSkillMasteryEffectsWrapper(long adr)
	{
		PassiveSkillMasteryEffectsStructure passiveSkillMasteryEffectsStructure = LokiPoe.Memory.FastIntPtrToStruct<PassiveSkillMasteryEffectsStructure>(adr);
		Id = LokiPoe.Memory.ReadStringU(passiveSkillMasteryEffectsStructure.Id);
		PassiveSkillMasteryId = passiveSkillMasteryEffectsStructure.MasteryId;
		StatsCount = passiveSkillMasteryEffectsStructure.StatsCount;
		Stat1 = passiveSkillMasteryEffectsStructure.Stat1;
		Stat2 = passiveSkillMasteryEffectsStructure.Stat2;
		Stat3 = passiveSkillMasteryEffectsStructure.Stat3;
		Stats = new List<KeyValuePair<DatStatWrapper, int>>();
		long num = passiveSkillMasteryEffectsStructure.Stats;
		for (int i = 0; i < StatsCount; i++)
		{
			DatStatWrapper.Struct325 @struct = LokiPoe.Memory.FastIntPtrToStruct<DatStatWrapper.Struct325>(LokiPoe.Memory.ReadLong(num));
			string key = LokiPoe.Memory.ReadStringU(@struct.intptr_0Id);
			int value = 0;
			switch (i)
			{
			case 0:
				value = passiveSkillMasteryEffectsStructure.Stat1;
				break;
			case 1:
				value = passiveSkillMasteryEffectsStructure.Stat2;
				break;
			case 2:
				value = passiveSkillMasteryEffectsStructure.Stat3;
				break;
			}
			Stats.Add(new KeyValuePair<DatStatWrapper, int>(Dat.IdToStatWrapper[key], value));
			num += 16L;
		}
	}

	public DatPassiveSkillMasteryEffectsWrapper(PassiveSkillMasteryEffectsStructure str)
	{
		Id = LokiPoe.Memory.ReadStringU(str.Id);
		PassiveSkillMasteryId = str.MasteryId;
		StatsCount = str.StatsCount;
		Stat1 = str.Stat1;
		Stat2 = str.Stat2;
		Stat3 = str.Stat3;
		Stats = new List<KeyValuePair<DatStatWrapper, int>>();
		long num = str.Stats;
		for (int i = 0; i < StatsCount; i++)
		{
			DatStatWrapper.Struct325 @struct = LokiPoe.Memory.FastIntPtrToStruct<DatStatWrapper.Struct325>(LokiPoe.Memory.ReadLong(num));
			string key = LokiPoe.Memory.ReadStringU(@struct.intptr_0Id);
			int value = 0;
			switch (i)
			{
			case 0:
				value = str.Stat1;
				break;
			case 2:
				value = str.Stat3;
				break;
			case 1:
				value = str.Stat2;
				break;
			}
			Stats.Add(new KeyValuePair<DatStatWrapper, int>(Dat.IdToStatWrapper[key], value));
			num += 16L;
		}
	}
}
