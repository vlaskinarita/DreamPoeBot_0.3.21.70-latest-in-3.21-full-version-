using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Components;

public class Portal : Component
{
	public WorldArea WorldArea => GameController.Instance.Files.WorldAreas.GetByAddress(base.M.ReadLong(base.Address + 48L));

	public DatWorldAreaWrapper Area
	{
		get
		{
			if (!(WorldArea != null))
			{
				return null;
			}
			return new DatWorldAreaWrapper(WorldArea.Id);
		}
	}

	public DatWorldAreaWrapper Destination => Area;
}
