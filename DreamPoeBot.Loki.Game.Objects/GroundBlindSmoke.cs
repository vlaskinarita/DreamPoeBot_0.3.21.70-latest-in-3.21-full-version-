namespace DreamPoeBot.Loki.Game.Objects;

public class GroundBlindSmoke : NetworkObject
{
	public override string Name => "GroundBlindSmoke";

	internal GroundBlindSmoke(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
