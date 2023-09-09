using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class MapStashTabElement : Element
{
	private long mapListStartPtr
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0L;
			}
			return base.M.ReadLong(base.Address + 2520L);
		}
	}

	private long mapListEndPtr
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0L;
			}
			return base.M.ReadLong(base.Address + 2520L + 8L);
		}
	}

	public int TotalInventories => (int)((mapListEndPtr - mapListStartPtr) / 16L);

	public Dictionary<MapSubInventoryKey, MapSubInventoryInfo> MapsCount => GetMapsCount();

	private Dictionary<MapSubInventoryKey, MapSubInventoryInfo> GetMapsCount()
	{
		Dictionary<MapSubInventoryKey, MapSubInventoryInfo> dictionary = new Dictionary<MapSubInventoryKey, MapSubInventoryInfo>();
		MapSubInventoryInfo mapSubInventoryInfo = null;
		MapSubInventoryKey mapSubInventoryKey = null;
		for (int i = 0; i < TotalInventories; i++)
		{
			mapSubInventoryInfo = new MapSubInventoryInfo();
			mapSubInventoryKey = new MapSubInventoryKey();
			mapSubInventoryInfo.Tier = SubInventoryMapTier(i);
			mapSubInventoryInfo.Count = SubInventoryMapCount(i);
			mapSubInventoryInfo.MapName = SubInventoryMapName(i);
			if (mapSubInventoryInfo.Count != 0)
			{
				mapSubInventoryKey.Path = SubInventoryMapPath(i);
				mapSubInventoryKey.Type = SubInventoryMapType(i);
				dictionary.Add(mapSubInventoryKey, mapSubInventoryInfo);
			}
		}
		return dictionary;
	}

	private int SubInventoryMapTier(int index)
	{
		return base.M.ReadInt(mapListStartPtr + index * 16, default(long));
	}

	private int SubInventoryMapCount(int index)
	{
		return base.M.ReadInt(mapListStartPtr + index * 16, 8L);
	}

	private MapType SubInventoryMapType(int index)
	{
		return (MapType)base.M.ReadInt(mapListStartPtr + index * 16, 28L);
	}

	private string SubInventoryMapPath(int index)
	{
		return base.M.ReadStringU(base.M.ReadLong(mapListStartPtr + index * 16, 40L, 0L));
	}

	private string SubInventoryMapName(int index)
	{
		return base.M.ReadStringU(base.M.ReadLong(mapListStartPtr + index * 16, 40L, 32L));
	}
}
