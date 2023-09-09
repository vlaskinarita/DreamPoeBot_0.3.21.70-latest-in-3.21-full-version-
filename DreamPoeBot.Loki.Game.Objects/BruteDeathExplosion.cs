namespace DreamPoeBot.Loki.Game.Objects;

public class BruteDeathExplosion : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/monsters_effects/brute_death/BruteDeathExplosion";

	public override string Name => "BruteDeathExplosion";

	internal BruteDeathExplosion(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
