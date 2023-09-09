using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Waypoint : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/Waypoint";

	internal Waypoint(EntityWrapper entity)
		: base(entity)
	{
	}
}
