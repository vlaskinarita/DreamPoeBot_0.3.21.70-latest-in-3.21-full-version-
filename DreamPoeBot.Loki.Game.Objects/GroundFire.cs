namespace DreamPoeBot.Loki.Game.Objects;

public class GroundFire : NetworkObject
{
	public override string Name => "GroundFire";

	internal GroundFire(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
