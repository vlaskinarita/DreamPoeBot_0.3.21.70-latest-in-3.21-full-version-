namespace DreamPoeBot.Loki.Components;

public class InventoryVisual : RemoteMemoryObject
{
	public string Name => base.M.ReadStringU(base.Address);

	public string Texture => base.M.ReadStringU(base.Address + 8L);

	public string Model => base.M.ReadStringU(base.Address + 16L);
}
