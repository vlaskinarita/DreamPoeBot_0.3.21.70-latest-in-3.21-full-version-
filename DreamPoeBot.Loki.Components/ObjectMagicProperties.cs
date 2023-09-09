using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class ObjectMagicProperties : Component
{
	internal struct Struct185ObgectMagicProperties
	{
		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt_0;

		private long intptr_0;

		private NativeVector nativeVector_0;

		private NativeStringW nativeStringW_0;

		private NativeStringW nativeStringW_1;

		private NativeStringW nativeStringW_2;

		private NativeStringW nativeStringW_3;

		private NativeStringW nativeStringW_4;

		private NativeStringW nativeStringW_5;

		private NativeStringW nativeStringW_6;

		private NativeStringW nativeStringW_7;

		private long unusedIntPtr_0;

		public byte byte_4IsIdentified;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		public Rarity rarity_0;

		private long intptr_22;

		public NativeVector nativeVector_1ImpAfex;

		public NativeVector nativeVector_2ExpAfex;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		private long intptr_7;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		private long intptr_18;

		public NativeVector nativeVector_3StatDict;
	}

	private PerFrameCachedValue<Struct185ObgectMagicProperties> perFrameCachedValue_1;

	private PerFrameCachedValue<List<string>> perFrameCachedValue_ExpMods;

	private PerFrameCachedValue<List<string>> perFrameCachedValue_ImpMods;

	private PerFrameCachedValue<Dictionary<StatTypeGGG, int>> perFrameCachedValue_StatDict;

	public Rarity Rarity => Struct185_0.rarity_0;

	public bool IsIdentified
	{
		get
		{
			if (base.Address != 0L)
			{
				return Struct185_0.byte_4IsIdentified == 1;
			}
			return true;
		}
	}

	public List<string> Mods => ImpMods.Union(ExpMods).ToList();

	public IEnumerable<ModsDat.ModRecord> Affixes => ImplicitAffixes.Union(ExplicitAffixes);

	public List<ModsDat.ModRecord> Affixes2
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			foreach (string mod in Mods)
			{
				if (GameController.Instance.Files.Mods.records.ContainsKey(mod))
				{
					list.Add(GameController.Instance.Files.Mods.records[mod]);
				}
			}
			return list;
		}
	}

	public List<ModsDat.ModRecord> ImplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			foreach (string impMod in ImpMods)
			{
				if (GameController.Instance.Files.Mods.records.ContainsKey(impMod))
				{
					list.Add(GameController.Instance.Files.Mods.records[impMod]);
				}
			}
			return list;
		}
	}

	public List<ModsDat.ModRecord> ExplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			foreach (string expMod in ExpMods)
			{
				if (GameController.Instance.Files.Mods.records.ContainsKey(expMod))
				{
					list.Add(GameController.Instance.Files.Mods.records[expMod]);
				}
			}
			return list;
		}
	}

	internal Dictionary<StatTypeGGG, int> StatDictionary
	{
		get
		{
			if (perFrameCachedValue_StatDict == null)
			{
				perFrameCachedValue_StatDict = new PerFrameCachedValue<Dictionary<StatTypeGGG, int>>(StatDictionary_1);
			}
			return perFrameCachedValue_StatDict;
		}
	}

	internal List<string> ImpMods
	{
		get
		{
			if (perFrameCachedValue_ImpMods == null)
			{
				perFrameCachedValue_ImpMods = new PerFrameCachedValue<List<string>>(ImpMods_1);
			}
			return perFrameCachedValue_ImpMods;
		}
	}

	internal List<string> ExpMods
	{
		get
		{
			if (perFrameCachedValue_ExpMods == null)
			{
				perFrameCachedValue_ExpMods = new PerFrameCachedValue<List<string>>(ExpMods_1);
			}
			return perFrameCachedValue_ExpMods;
		}
	}

	internal Struct185ObgectMagicProperties Struct185_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct185ObgectMagicProperties>(() => base.M.FastIntPtrToStruct<Struct185ObgectMagicProperties>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}

	public Dictionary<StatTypeGGG, int> StatDictionary_1()
	{
		long first = Struct185_0.nativeVector_3StatDict.First;
		long last = Struct185_0.nativeVector_3StatDict.Last;
		int num = (int)(last - first);
		byte[] array = base.M.ReadBytes(first, num);
		if (num <= 0)
		{
			return new Dictionary<StatTypeGGG, int>();
		}
		Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>(num / 8);
		for (int i = 0; i < array.Length; i += 8)
		{
			int key = BitConverter.ToInt32(array, i);
			int value = BitConverter.ToInt32(array, i + 4);
			dictionary[(StatTypeGGG)key] = value;
		}
		return dictionary;
	}

	public List<string> ImpMods_1()
	{
		if (base.Address == 0L)
		{
			return new List<string>();
		}
		long first = Struct185_0.nativeVector_1ImpAfex.First;
		long last = Struct185_0.nativeVector_1ImpAfex.Last;
		List<string> list = new List<string>();
		if (first != 0L && last != 0L)
		{
			for (long num = first; num < last; num += 56L)
			{
				string item = base.M.ReadStringU(base.M.ReadLong(num + 40L, default(long)));
				list.Add(item);
				if (list.Count > 5000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	public List<string> ExpMods_1()
	{
		if (base.Address == 0L)
		{
			return new List<string>();
		}
		long first = Struct185_0.nativeVector_2ExpAfex.First;
		long last = Struct185_0.nativeVector_2ExpAfex.Last;
		List<string> list = new List<string>();
		if (first != 0L && last != 0L)
		{
			for (long num = first; num < last; num += 56L)
			{
				string item = base.M.ReadStringU(base.M.ReadLong(num + 40L, default(long)));
				list.Add(item);
				if (list.Count > 5000)
				{
					break;
				}
			}
			return list;
		}
		return list;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[ObjectMagicPropertiesComponent]");
		stringBuilder.AppendLine($"\tImplicit Mods:");
		foreach (string impMod in ImpMods)
		{
			stringBuilder.AppendLine($"\t\t-{impMod}");
		}
		stringBuilder.AppendLine($"\tExplicit Mods:");
		foreach (string expMod in ExpMods)
		{
			stringBuilder.AppendLine($"\t\t-{expMod}");
		}
		stringBuilder.AppendLine($"\tAffixes:");
		foreach (ModsDat.ModRecord affix in Affixes)
		{
			stringBuilder.AppendLine($"\t\tInternalName: {affix.InternalName}, DisplayName: {affix.DisplayName}");
			StatsDat.StatRecord[] statNames = affix.StatNames;
			foreach (StatsDat.StatRecord statRecord in statNames)
			{
				if (statRecord != null)
				{
					if (!GameController.Instance.Files.StatDescription.Data.TryGetValue(statRecord.StatTypeGGG, out var value))
					{
						stringBuilder.AppendLine(string.Format("\t\t-{0}[{1}]", "", statRecord.StatTypeGGG));
					}
					else
					{
						stringBuilder.AppendLine($"\t\t-{value}[{statRecord.StatTypeGGG}]");
					}
				}
			}
		}
		return stringBuilder.ToString();
	}
}
