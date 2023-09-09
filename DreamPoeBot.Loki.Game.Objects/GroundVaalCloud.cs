namespace DreamPoeBot.Loki.Game.Objects;

public class GroundVaalCloud : NetworkObject
{
	public override string Name => "GroundVaalCloud";

	internal GroundVaalCloud(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
