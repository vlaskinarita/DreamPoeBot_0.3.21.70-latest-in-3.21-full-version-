using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.FilesInMemory.Base;

namespace DreamPoeBot.Loki.FilesInMemory;

public class PassiveSkills : UniversalFileWrapper<PassiveSkill>
{
	public Dictionary<int, PassiveSkill> PassiveSkillsDictionary = new Dictionary<int, PassiveSkill>();

	public PassiveSkills(Memory m, long address)
		: base(m, address)
	{
	}

	public PassiveSkill GetPassiveSkillByPassiveId(int index)
	{
		CheckCache();
		PassiveSkillsDictionary.TryGetValue(index, out var value);
		return value;
	}

	public PassiveSkill GetPassiveSkillById(string id)
	{
		return base.EntriesList.FirstOrDefault((PassiveSkill x) => x.Id == id);
	}

	protected override void EntryAdded(long addr, PassiveSkill entry)
	{
		PassiveSkillsDictionary.Add(entry.PassiveId, entry);
	}
}
