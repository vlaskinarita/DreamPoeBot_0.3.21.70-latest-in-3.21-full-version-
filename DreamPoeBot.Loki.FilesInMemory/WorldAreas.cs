using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class WorldAreas : UniversalFileWrapper<WorldArea>
{
	private Dictionary<int, WorldArea> AreasIndexDictionary = new Dictionary<int, WorldArea>();

	private int IndexCounter;

	public WorldAreas(Memory m, long address)
		: base(m, address)
	{
	}

	public WorldArea GetAreaByAreaId(int index)
	{
		CheckCache();
		AreasIndexDictionary.TryGetValue(index, out var value);
		return value;
	}

	public WorldArea GetAreaByAreaId(string id)
	{
		CheckCache();
		return AreasIndexDictionary.First((KeyValuePair<int, WorldArea> area) => area.Value.Id == id).Value;
	}

	public WorldArea GetAreaByAddress(long address)
	{
		CheckCache();
		return AreasIndexDictionary.First((KeyValuePair<int, WorldArea> area) => area.Value.Address == address).Value;
	}

	protected override void EntryAdded(long addr, WorldArea entry)
	{
		entry.Index = IndexCounter++;
		AreasIndexDictionary.Add(entry.Index, entry);
	}
}
