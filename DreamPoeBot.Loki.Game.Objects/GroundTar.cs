namespace DreamPoeBot.Loki.Game.Objects;

public class GroundTar : NetworkObject
{
	public override string Name => "GroundTar";

	internal GroundTar(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
