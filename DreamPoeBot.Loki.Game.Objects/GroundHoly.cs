namespace DreamPoeBot.Loki.Game.Objects;

public class GroundHoly : NetworkObject
{
	public override string Name => "GroundHoly";

	internal GroundHoly(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
