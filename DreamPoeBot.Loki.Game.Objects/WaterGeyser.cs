namespace DreamPoeBot.Loki.Game.Objects;

public class WaterGeyser : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/monsters_effects/act1/merveil/water_geyser/WaterGeyser";

	public override string Name => "WaterGeyser";

	internal WaterGeyser(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
