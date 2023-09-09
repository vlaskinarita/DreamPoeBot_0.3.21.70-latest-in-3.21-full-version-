using System.Collections.Generic;
using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class PropheciesDat : UniversalFileWrapper<ProphecyDat>
{
	private Dictionary<int, ProphecyDat> ProphecyIndexDictionary = new Dictionary<int, ProphecyDat>();

	private int IndexCounter;

	public PropheciesDat(Memory m, long address)
		: base(m, address)
	{
	}

	public ProphecyDat GetProphecyById(int index)
	{
		CheckCache();
		ProphecyIndexDictionary.TryGetValue(index, out var value);
		return value;
	}

	protected override void EntryAdded(long addr, ProphecyDat entry)
	{
		entry.Index = IndexCounter++;
		ProphecyIndexDictionary.Add(entry.ProphecyId, entry);
	}
}
