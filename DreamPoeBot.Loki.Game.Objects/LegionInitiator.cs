namespace DreamPoeBot.Loki.Game.Objects;

public class LegionInitiator : NetworkObject
{
	public override string Name => "LegionInitiator";

	internal LegionInitiator(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
