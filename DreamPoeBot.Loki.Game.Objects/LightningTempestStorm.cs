namespace DreamPoeBot.Loki.Game.Objects;

public class LightningTempestStorm : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Environment/tempest_league/elements/lightning/TempestStorm";

	public override string Name => "LightningTempestStorm";

	internal LightningTempestStorm(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
