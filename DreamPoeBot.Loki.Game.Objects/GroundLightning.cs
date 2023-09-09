namespace DreamPoeBot.Loki.Game.Objects;

public class GroundLightning : NetworkObject
{
	public override string Name => "GroundLightning";

	internal GroundLightning(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
