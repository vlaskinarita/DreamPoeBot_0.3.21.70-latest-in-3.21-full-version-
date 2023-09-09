using System.Collections.Generic;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class MonsterVarieties : UniversalFileWrapper<MonsterVariety>
{
	private readonly Dictionary<string, MonsterVariety> MonsterVarietyMetadataDictionary = new Dictionary<string, MonsterVariety>();

	public MonsterVarieties(Memory m, long address)
		: base(m, address)
	{
	}

	public MonsterVariety TranslateFromMetadata(string path)
	{
		CheckCache();
		MonsterVarietyMetadataDictionary.TryGetValue(path, out var value);
		return value;
	}

	protected override void EntryAdded(long addr, MonsterVariety entry)
	{
		MonsterVarietyMetadataDictionary.Add(entry.VarietyId, entry);
	}
}
