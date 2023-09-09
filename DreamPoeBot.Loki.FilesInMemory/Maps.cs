using DreamPoeBot.Loki.FilesInMemory.Base;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class Maps : UniversalFileWrapper<Map>
{
	public Maps(Memory m, long address)
		: base(m, address)
	{
	}

	public Map GetMapByAddress(long address)
	{
		CheckCache();
		if (base.EntriesAddressDictionary.ContainsKey(address))
		{
			return base.EntriesAddressDictionary[address];
		}
		return null;
	}
}
