namespace DreamPoeBot.Loki.Game.Objects;

public class GroundFireWhite : NetworkObject
{
	public override string Name => "GroundFireWhite";

	internal GroundFireWhite(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
