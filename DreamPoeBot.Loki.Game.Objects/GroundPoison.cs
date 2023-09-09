namespace DreamPoeBot.Loki.Game.Objects;

public class GroundPoison : NetworkObject
{
	public override string Name => "GroundPoison";

	internal GroundPoison(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
