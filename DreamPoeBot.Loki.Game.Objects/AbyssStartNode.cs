namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssStartNode : NetworkObject
{
	public override string Name => "AbyssStartNode";

	internal AbyssStartNode(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
