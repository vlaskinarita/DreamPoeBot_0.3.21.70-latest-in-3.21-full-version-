using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.FilesInMemory;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class GrantedEffectsPerLevel : RemoteMemoryObject
{
	public SkillGemWrapper SkillGemWrapper => ReadObject<SkillGemWrapper>(base.Address + 8L);

	public int Level => base.M.ReadInt(base.Address + 16L);

	public int RequiredLevel => base.M.ReadInt(base.Address + 116L);

	public int ManaMultiplier => base.M.ReadInt(base.Address + 120L);

	public int ManaCost => base.M.ReadInt(base.Address + 168L);

	public int EffectivenessOfAddedDamage => base.M.ReadInt(base.Address + 172L);

	public int Cooldown => base.M.ReadInt(base.Address + 180L);

	public List<Tuple<StatsDat.StatRecord, int>> Stats
	{
		get
		{
			List<Tuple<StatsDat.StatRecord, int>> list = new List<Tuple<StatsDat.StatRecord, int>>();
			int num = base.M.ReadInt(base.Address + 20L);
			long num2 = base.M.ReadLong(base.Address + 28L);
			num2 += 8L;
			for (int i = 0; i < num; i++)
			{
				long address = base.M.ReadLong(num2);
				StatsDat.StatRecord statByAddress = GameController.Instance.Files.Stats.GetStatByAddress(address);
				list.Add(new Tuple<StatsDat.StatRecord, int>(statByAddress, ReadStatValue(i)));
				num2 += 16L;
			}
			return list;
		}
	}

	public List<string> Tags
	{
		get
		{
			List<string> list = new List<string>();
			int num = base.M.ReadInt(base.Address + 68L);
			long num2 = base.M.ReadLong(base.Address + 76L);
			num2 += 8L;
			for (int i = 0; i < num; i++)
			{
				long addr = base.M.ReadLong(num2);
				addr = base.M.ReadLong(addr);
				list.Add(base.M.ReadStringU(addr));
				num2 += 16L;
			}
			return list;
		}
	}

	public List<Tuple<StatsDat.StatRecord, int>> QualityStats
	{
		get
		{
			List<Tuple<StatsDat.StatRecord, int>> list = new List<Tuple<StatsDat.StatRecord, int>>();
			int num = base.M.ReadInt(base.Address + 132L);
			long num2 = base.M.ReadLong(base.Address + 140L);
			num2 += 8L;
			for (int i = 0; i < num; i++)
			{
				long address = base.M.ReadLong(num2);
				StatsDat.StatRecord statByAddress = GameController.Instance.Files.Stats.GetStatByAddress(address);
				list.Add(new Tuple<StatsDat.StatRecord, int>(statByAddress, ReadQualityStatValue(i)));
				num2 += 16L;
			}
			return list;
		}
	}

	public List<StatsDat.StatRecord> TypeStats
	{
		get
		{
			List<StatsDat.StatRecord> list = new List<StatsDat.StatRecord>();
			int num = base.M.ReadInt(base.Address + 188L);
			long num2 = base.M.ReadLong(base.Address + 196L);
			num2 += 8L;
			for (int i = 0; i < num; i++)
			{
				long address = base.M.ReadLong(num2);
				StatsDat.StatRecord statByAddress = GameController.Instance.Files.Stats.GetStatByAddress(address);
				list.Add(statByAddress);
				num2 += 16L;
			}
			return list;
		}
	}

	internal int ReadStatValue(int index)
	{
		return base.M.ReadInt(base.Address + 84L + index * 4);
	}

	internal int ReadQualityStatValue(int index)
	{
		return base.M.ReadInt(base.Address + 156L + index * 4);
	}
}
