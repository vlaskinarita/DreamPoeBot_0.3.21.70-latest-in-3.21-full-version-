namespace DreamPoeBot.Loki.Game.Objects;

public class GroundSpike : NetworkObject
{
	public override string Name => "GroundSpike";

	internal GroundSpike(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
