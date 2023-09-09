using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Framework;

namespace DreamPoeBot.Loki.FilesInMemory;

public class ModsDat : FileInMemory
{
	public enum ModType
	{
		Prefix = 1,
		Suffix = 2,
		Unique = 3,
		Nemesis = 4,
		Corrupted = 5,
		BloodLines = 6,
		Torment = 7,
		Tempest = 8,
		Talisman = 9,
		Enchantment = 10,
		EssenceMonster = 11,
		Bestiary = 13,
		Delve = 14,
		Synthesis = 15
	}

	public enum ModDomain
	{
		Item = 1,
		Flask = 2,
		Monster = 3,
		Chest = 4,
		Area = 5,
		unknown1 = 6,
		unknown2 = 7,
		unknown3 = 8,
		Crafted = 9,
		Jewel = 10,
		Atlas = 11,
		Leaguestone = 12,
		AbyssJewel = 13,
		MapDevice = 14,
		DelveFossil = 16,
		DelveArea = 17,
		SynthesisArea = 18,
		SynthesisAreaGlobal = 19,
		Synthesis = 20,
		ClusterJewel = 21,
		HeistArea = 22,
		HeistGear = 23,
		Trinket = 24,
		UnveiledModifier = 26
	}

	public class ModRecord
	{
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct Struct23
		{
			public long InternalName;

			public int int_0;

			public long Name;

			public long ModData;

			public int MinLevel;

			public long StatNames1;

			public long StatNamesFile1;

			public long StatNames2;

			public long StatNamesFile2;

			public long StatNames3;

			public long StatNamesFile3;

			public long StatNames4;

			public long StatNamesFile4;

			public int Domain;

			public long DisplayName;

			public int ModType;

			public int int_1;

			public int int_2;

			public long Category;

			public int StatRange1Min;

			public int StatRange1Max;

			public int StatRange2Min;

			public int StatRange2Max;

			public int StatRange3Min;

			public int StatRange3Max;

			public int StatRange4Min;

			public int StatRange4Max;

			public byte byte_0;

			public byte byte_1;

			public byte byte_2;

			public byte byte_3;

			public float float_0;

			public float float_1;

			public float float_2;

			public float float_3;
		}

		private class LevelComparer : IComparer<ModRecord>
		{
			public int Compare(ModRecord x, ModRecord y)
			{
				return -x.MinLevel + y.MinLevel;
			}
		}

		public long Address;

		public const int NumberOfStats = 4;

		public static IComparer<ModRecord> ByLevelComparer = new LevelComparer();

		public readonly string InternalName;

		public ModType ModType;

		public ModDomain Domain;

		public string Category;

		public int MinLevel;

		public StatsDat.StatRecord[] StatNames;

		public IntRange[] StatRange;

		public Dictionary<string, int> TagChances;

		public TagsDat.TagRecord[] Tags;

		public long Hash16;

		public string DisplayName;

		public bool IsEssence;

		public string Tier;

		public ModRecord(Memory m, StatsDat sDat, TagsDat tagsDat, long addr)
		{
			Address = addr;
			InternalName = m.ReadStringU(m.ReadLong(addr));
			Hash16 = m.ReadInt(addr + 8L);
			MinLevel = m.ReadInt(addr + 28L);
			long num = m.ReadLong(addr + 32L);
			long num2 = m.ReadLong(addr + 48L);
			long num3 = m.ReadLong(addr + 64L);
			long num4 = m.ReadLong(addr + 80L);
			StatNames = new StatsDat.StatRecord[4]
			{
				(num == 0L) ? null : sDat.records[m.ReadStringU(m.ReadLong(num))],
				(num2 == 0L) ? null : sDat.records[m.ReadStringU(m.ReadLong(num2))],
				(num3 == 0L) ? null : sDat.records[m.ReadStringU(m.ReadLong(num3))],
				(num4 == 0L) ? null : sDat.records[m.ReadStringU(m.ReadLong(num4))]
			};
			Domain = (ModDomain)m.ReadInt(addr + 96L);
			DisplayName = m.ReadStringU(m.ReadLong(addr + 100L));
			ModType = (ModType)m.ReadInt(addr + 108L);
			Category = m.ReadStringU(m.ReadLong(m.ReadLong(m.ReadLong(addr + 120L))));
			StatRange = new IntRange[4]
			{
				new IntRange(m.ReadInt(addr + 128L), m.ReadInt(addr + 132L)),
				new IntRange(m.ReadInt(addr + 136L), m.ReadInt(addr + 140L)),
				new IntRange(m.ReadInt(addr + 144L), m.ReadInt(addr + 148L)),
				new IntRange(m.ReadInt(addr + 152L), m.ReadInt(addr + 156L))
			};
			Tags = new TagsDat.TagRecord[m.ReadLong(addr + 160L)];
			long num5 = m.ReadLong(addr + 168L);
			for (int i = 0; i < Tags.Length; i++)
			{
				long addr2 = num5 + 16 * i;
				Tags[i] = tagsDat.records[m.ReadStringU(m.ReadLong(addr2, default(long)), 255)];
			}
			TagChances = new Dictionary<string, int>(m.ReadInt(addr + 180L));
			long num6 = m.ReadLong(addr + 184L);
			for (int j = 0; j < Tags.Length; j++)
			{
				TagChances[Tags[j].Key] = m.ReadInt(num6 + 4 * j);
			}
		}

		public override string ToString()
		{
			return $"Name: {DisplayName}, Key: {InternalName}, MinLevel: {MinLevel}";
		}
	}

	public Dictionary<string, ModRecord> records = new Dictionary<string, ModRecord>(StringComparer.OrdinalIgnoreCase);

	public Dictionary<long, ModRecord> DictionaryRecords = new Dictionary<long, ModRecord>();

	public Dictionary<Tuple<string, ModType>, List<ModRecord>> recordsByTier = new Dictionary<Tuple<string, ModType>, List<ModRecord>>();

	public ModsDat(Memory m, long address, StatsDat sDat, TagsDat tagsDat)
		: base(m, address)
	{
		LoadItems(sDat, tagsDat);
	}

	public ModRecord GetModByAddress(long address)
	{
		DictionaryRecords.TryGetValue(address, out var value);
		return value;
	}

	private void LoadItems(StatsDat sDat, TagsDat tagsDat)
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			ModRecord modRecord = new ModRecord(base.M, sDat, tagsDat, item);
			if (records.ContainsKey(modRecord.InternalName))
			{
				continue;
			}
			DictionaryRecords.Add(item, modRecord);
			records.Add(modRecord.InternalName, modRecord);
			if (modRecord.Domain != ModDomain.Monster)
			{
				Tuple<string, ModType> key = Tuple.Create(modRecord.Category, modRecord.ModType);
				if (!recordsByTier.TryGetValue(key, out var value))
				{
					value = new List<ModRecord>();
					recordsByTier[key] = value;
				}
				value.Add(modRecord);
			}
		}
		foreach (List<ModRecord> value2 in recordsByTier.Values)
		{
			value2.Sort(ModRecord.ByLevelComparer);
		}
	}
}
