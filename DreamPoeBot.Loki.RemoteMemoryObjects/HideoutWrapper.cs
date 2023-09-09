using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class HideoutWrapper : RemoteMemoryObject
{
	public string Name => base.M.ReadStringU(base.M.ReadLong(base.Address));

	public WorldArea WorldArea1 => GameController.Instance.Files.WorldAreas.GetByAddress(base.M.ReadLong(base.Address + 16L));
}
