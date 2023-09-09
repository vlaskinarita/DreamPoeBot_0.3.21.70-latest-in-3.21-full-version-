namespace DreamPoeBot.Loki.Game.Objects;

public class GroundEvilRed : NetworkObject
{
	public override string Name => "GroundEvilRed";

	internal GroundEvilRed(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
