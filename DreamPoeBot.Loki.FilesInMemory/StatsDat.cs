using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DreamPoeBot.Loki.FilesInMemory;

public class StatsDat : FileInMemory
{
	public enum StatType
	{
		Percents = 1,
		Value2,
		IntValue,
		Boolean,
		Precents5
	}

	public class StatRecord
	{
		public readonly string Key;

		public readonly string StatTypeGGG;

		public readonly long Address;

		public StatType Type;

		public string UserFriendlyName;

		public StatRecord(Memory m, long addr)
		{
			Address = addr;
			Key = m.ReadStringU(m.ReadLong(addr));
			Type = (Key.Contains("%") ? StatType.Percents : ((StatType)m.ReadInt(addr + 11L)));
			UserFriendlyName = m.ReadStringU(m.ReadLong(addr + 15L));
			StatTypeGGG = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Key).Replace("+", "Pos").Replace("-", "Neg")
				.Replace("%", "Pct")
				.Replace("_", "");
		}

		public override string ToString()
		{
			if (!string.IsNullOrWhiteSpace(UserFriendlyName))
			{
				return UserFriendlyName;
			}
			return Key;
		}

		internal string ValueToString(int val)
		{
			StatType type = Type;
			uint num = default(uint);
			while (true)
			{
				switch (type)
				{
				default:
				{
					int num2 = (int)(num * 304446003) ^ -1773450085;
					while (true)
					{
						switch ((num = (uint)num2 ^ 0x833171A1u) % 9u)
						{
						case 0u:
							num2 = ((int)num * -447066143) ^ 0x4C9B2391;
							continue;
						case 3u:
						case 7u:
							break;
						default:
							return "";
						case 6u:
							goto IL_007f;
						case 8u:
							goto IL_008c;
						case 4u:
							goto IL_008f;
						case 5u:
							goto IL_0095;
						case 2u:
							goto end_IL_005e;
						}
						break;
					}
					continue;
				}
				case StatType.Value2:
				case StatType.IntValue:
					goto IL_007f;
				case StatType.Boolean:
					goto IL_008c;
				case StatType.Percents:
				case StatType.Precents5:
					break;
					IL_007f:
					return val.ToString("+#;-#");
					IL_008c:
					if (val != 0)
					{
						goto IL_008f;
					}
					goto IL_0095;
					IL_008f:
					return "True";
					IL_0095:
					return "False";
					end_IL_005e:
					break;
				}
				break;
			}
			return val.ToString("+#;-#") + "%";
		}
	}

	public Dictionary<string, StatRecord> records = new Dictionary<string, StatRecord>(StringComparer.OrdinalIgnoreCase);

	public StatsDat(Memory m, long address)
		: base(m, address)
	{
		LoadItems();
	}

	public StatRecord GetStatByAddress(long address)
	{
		return records.Values.ToList().Find((StatRecord x) => x.Address == address);
	}

	private void LoadItems()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			StatRecord statRecord = new StatRecord(base.M, item);
			if (!records.ContainsKey(statRecord.Key))
			{
				records.Add(statRecord.Key, statRecord);
			}
		}
	}
}
