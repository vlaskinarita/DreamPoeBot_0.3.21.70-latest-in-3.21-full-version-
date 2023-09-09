namespace DreamPoeBot.Loki.Game.Objects;

public class FireTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/fire/TempestStorm";

	public override string Name => "FireTempestStorm";

	internal FireTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
