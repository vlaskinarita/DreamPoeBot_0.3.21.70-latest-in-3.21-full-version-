namespace DreamPoeBot.Loki.Game.Objects;

public class GroundIce : NetworkObject
{
	public override string Name => "GroundIce";

	internal GroundIce(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
