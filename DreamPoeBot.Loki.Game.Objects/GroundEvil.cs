namespace DreamPoeBot.Loki.Game.Objects;

public class GroundEvil : NetworkObject
{
	public override string Name => "GroundEvil";

	internal GroundEvil(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
