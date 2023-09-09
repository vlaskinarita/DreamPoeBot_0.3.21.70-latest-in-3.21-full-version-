using System.Collections.Generic;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.FilesInMemory;

public class QuestFlagsDat : FileInMemory
{
	public readonly Dictionary<long, QuestFlags> contents = new Dictionary<long, QuestFlags>();

	public QuestFlagsDat(Memory m, long address)
		: base(m, address)
	{
		LoadItemTypes(m);
	}

	private void LoadItemTypes(Memory m)
	{
		IEnumerable<long> enumerable = RecordAddresses();
		int num = 0;
		foreach (long item in enumerable)
		{
			QuestFlags.QuestFlagsStructure questFlagsStructure = m.FastIntPtrToStruct<QuestFlags.QuestFlagsStructure>(item);
			QuestFlags value = new QuestFlags
			{
				Address = item,
				Id = m.ReadStringU(questFlagsStructure.Id),
				Hash32 = questFlagsStructure.Hash32,
				index = num
			};
			if (!contents.ContainsKey(item))
			{
				contents.Add(item, value);
			}
			num++;
		}
	}
}
