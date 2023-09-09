using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.FilesInMemory;

public class PassiveSkill : RemoteMemoryObject
{
	private int passiveId = -1;

	private string id;

	private string name;

	private List<Tuple<StatsDat.StatRecord, int>> stats;

	public int PassiveId
	{
		get
		{
			if (passiveId == -1)
			{
				return passiveId = base.M.ReadInt(base.Address + 48L);
			}
			return passiveId;
		}
	}

	public string Id
	{
		get
		{
			if (id == null)
			{
				return id = base.M.ReadStringU(base.M.ReadLong(base.Address), 255);
			}
			return id;
		}
	}

	public string Name
	{
		get
		{
			if (name == null)
			{
				return name = base.M.ReadStringU(base.M.ReadLong(base.Address + 52L), 255);
			}
			return name;
		}
	}

	public string Icon => base.M.ReadStringU(base.M.ReadLong(base.Address + 8L), 255);

	public List<Tuple<StatsDat.StatRecord, int>> Stats
	{
		get
		{
			if (stats == null)
			{
				stats = new List<Tuple<StatsDat.StatRecord, int>>();
				int count = base.M.ReadInt(base.Address + 16L);
				long startAddress = base.M.ReadLong(base.Address + 24L);
				List<long> source = base.M.ReadSecondPointerArray_Count(startAddress, count);
				stats = source.Select((long x, int i) => new Tuple<StatsDat.StatRecord, int>(GameController.Instance.Files.Stats.GetStatByAddress(x), ReadStatValue(i))).ToList();
			}
			return stats;
		}
	}

	internal int ReadStatValue(int index)
	{
		return base.M.ReadInt(base.Address + 32L + index * 4);
	}

	public override string ToString()
	{
		return $"{Name}, Id: {Id}, PassiveId: {PassiveId}";
	}
}
