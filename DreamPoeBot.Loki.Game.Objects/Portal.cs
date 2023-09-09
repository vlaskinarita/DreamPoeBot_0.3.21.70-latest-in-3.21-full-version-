using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Portal : NetworkObject
{
	public DatWorldAreaWrapper Area
	{
		get
		{
			DreamPoeBot.Loki.Components.Portal component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Portal>();
			if (component == null)
			{
				return null;
			}
			return component.Destination;
		}
	}

	public Portal(EntityWrapper entity)
		: base(entity)
	{
	}
}
