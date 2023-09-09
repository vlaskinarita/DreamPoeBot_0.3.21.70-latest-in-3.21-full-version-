namespace DreamPoeBot.Loki.Game.Objects;

public class GuildStash : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/GuildStash";

	internal GuildStash(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
