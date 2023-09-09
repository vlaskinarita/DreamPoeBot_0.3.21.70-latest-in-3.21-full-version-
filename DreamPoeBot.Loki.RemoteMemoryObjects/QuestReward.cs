using System.Collections.Generic;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class QuestReward : FileInMemory
{
	public List<Dat.NativeQuestStaticReward> list = new List<Dat.NativeQuestStaticReward>();

	public QuestReward(Memory m, long address)
		: base(m, address)
	{
		loadItems();
	}

	private void loadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item2 in enumerable)
		{
			Dat.NativeQuestStaticReward item = base.M.FastIntPtrToStruct<Dat.NativeQuestStaticReward>(item2);
			list.Add(item);
		}
	}
}
