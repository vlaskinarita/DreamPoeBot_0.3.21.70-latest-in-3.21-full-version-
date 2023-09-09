using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Stash : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/Stash";

	internal Stash(EntityWrapper entity)
		: base(entity)
	{
	}
}
