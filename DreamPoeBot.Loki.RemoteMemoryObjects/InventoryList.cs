using DreamPoeBot.Loki.Models.Enums;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class InventoryList : RemoteMemoryObject
{
	public static int InventoryCount => 15;

	public Inventory this[InventoryIndex inv]
	{
		get
		{
			if (inv >= InventoryIndex.None && (int)inv < InventoryCount)
			{
				return ReadObjectAt<Inventory>((int)inv * 8);
			}
			return null;
		}
	}
}
