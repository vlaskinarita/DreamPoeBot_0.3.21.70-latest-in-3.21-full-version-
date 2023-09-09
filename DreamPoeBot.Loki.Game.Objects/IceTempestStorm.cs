namespace DreamPoeBot.Loki.Game.Objects;

public class IceTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/ice/TempestStorm";

	public override string Name => "IceTempestStorm";

	internal IceTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
