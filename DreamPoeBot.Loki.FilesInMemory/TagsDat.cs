using System;
using System.Collections.Generic;

namespace DreamPoeBot.Loki.FilesInMemory;

public class TagsDat : FileInMemory
{
	public class TagRecord
	{
		public readonly string Key;

		public int Hash;

		public TagRecord(Memory m, long addr)
		{
			Key = m.ReadStringU(m.ReadLong(addr), 255);
			Hash = m.ReadInt(addr + 8L);
		}
	}

	public Dictionary<string, TagRecord> records = new Dictionary<string, TagRecord>(StringComparer.OrdinalIgnoreCase);

	public TagsDat(Memory m, long address)
		: base(m, address)
	{
		LoadItems();
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			TagRecord tagRecord = new TagRecord(base.M, item);
			if (!records.ContainsKey(tagRecord.Key))
			{
				records.Add(tagRecord.Key, tagRecord);
			}
		}
	}
}
