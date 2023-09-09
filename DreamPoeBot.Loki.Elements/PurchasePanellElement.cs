using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class PurchasePanellElement : Element
{
	private const long tabContainerOffset = 560L;

	public long TotalStashes => StashInventoryPanel.ChildCount;

	public Element ViewAllStashPanel
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			return GetObject<Element>(base.M.ReadLong(base.Address + 560L, 2408L));
		}
	}

	public Element StashInventoryPanel
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			return GetObject<Element>(base.M.ReadLong(base.Address + 560L, 2424L));
		}
	}

	public int IndexVisibleStash => base.M.ReadInt(base.Address + 560L, 2528L);

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory VisibleStash => GetVisibleStash();

	public string VisibleStashName
	{
		get
		{
			if (IndexVisibleStash < 0)
			{
				return string.Empty;
			}
			List<string> allStashNames = AllStashNames;
			if (IndexVisibleStash < allStashNames.Count)
			{
				return AllStashNames[IndexVisibleStash];
			}
			return string.Empty;
		}
	}

	public List<string> AllStashNames => GetAllStashNames();

	public DreamPoeBot.Loki.Game.Inventory VisibleStashInventory
	{
		get
		{
			long address = VisibleStash.Address;
			return new DreamPoeBot.Loki.Game.Inventory(address + 560L);
		}
	}

	private DreamPoeBot.Loki.RemoteMemoryObjects.Inventory GetVisibleStash()
	{
		return GetStashInventoryByIndex(IndexVisibleStash);
	}

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory GetStashInventoryByIndex(int index)
	{
		if (index < 0)
		{
			return null;
		}
		if (index >= TotalStashes)
		{
			return null;
		}
		if (StashInventoryPanel.Children[index].ChildCount == 0L)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (StashInventoryPanel.Children[index].ChildCount == 0L)
			{
				if (stopwatch.ElapsedMilliseconds < 5000L)
				{
					Thread.Sleep(200);
					continue;
				}
				return null;
			}
		}
		return StashInventoryPanel.Children[index].Children[0].AsObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>();
	}

	private List<string> GetAllStashNames()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < TotalStashes; i++)
		{
			list.Add(GetStashName(i));
		}
		return list;
	}

	public string GetStashName(int index)
	{
		if (index < TotalStashes && index >= 0)
		{
			List<Element> list = ViewAllStashPanel.Children.Where((Element X) => X.ChildCount == 1L).ToList();
			if (list[index].Children[0].ChildCount != 1L)
			{
				return list[index].Children[0].Children[1].AsObject<EntityLabel>().Text;
			}
			return list[index].Children[0].Children[0].AsObject<EntityLabel>().Text;
		}
		return string.Empty;
	}
}
