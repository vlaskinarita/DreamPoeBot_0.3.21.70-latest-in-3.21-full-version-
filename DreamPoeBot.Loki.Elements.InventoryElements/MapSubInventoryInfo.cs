namespace DreamPoeBot.Loki.Elements.InventoryElements;

public class MapSubInventoryInfo
{
	public int Tier;

	public int Count;

	public string MapName;

	public override string ToString()
	{
		return "Tier:" + Tier + " Count:" + Count + " MapName:" + MapName;
	}
}
