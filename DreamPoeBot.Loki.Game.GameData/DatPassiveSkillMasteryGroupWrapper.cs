using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatPassiveSkillMasteryGroupWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PassiveSkillMasteryGroupStructure
	{
		public long Id;

		public int PassiveSkillMasteryCount;

		private int filled;

		public long PassiveSkillMasteryEffects;
	}

	public string Id { get; private set; }

	public int MasterEffectsCount { get; private set; }

	public List<DatPassiveSkillMasteryEffectsWrapper> PassiveSkillMasteryEffects { get; private set; }

	public DatPassiveSkillMasteryGroupWrapper(long adr)
	{
		PassiveSkillMasteryGroupStructure passiveSkillMasteryGroupStructure = LokiPoe.Memory.FastIntPtrToStruct<PassiveSkillMasteryGroupStructure>(adr);
		Id = LokiPoe.Memory.ReadStringU(passiveSkillMasteryGroupStructure.Id);
		MasterEffectsCount = passiveSkillMasteryGroupStructure.PassiveSkillMasteryCount;
		long num = passiveSkillMasteryGroupStructure.PassiveSkillMasteryEffects;
		PassiveSkillMasteryEffects = new List<DatPassiveSkillMasteryEffectsWrapper>();
		for (int i = 0; i < MasterEffectsCount; i++)
		{
			PassiveSkillMasteryEffects.Add(new DatPassiveSkillMasteryEffectsWrapper(LokiPoe.Memory.ReadLong(num)));
			num += 16L;
		}
	}
}
