namespace DreamPoeBot.Loki.Game.Objects;

public class BeyondPortal : NetworkObject
{
	public override string Name => "BeyondPortal";

	internal BeyondPortal(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
