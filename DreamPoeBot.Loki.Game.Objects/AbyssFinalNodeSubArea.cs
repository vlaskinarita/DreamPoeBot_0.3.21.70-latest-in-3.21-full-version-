namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssFinalNodeSubArea : TriggerableBlockage
{
	public override string Name => "AbyssFinalNodeSubArea";

	internal AbyssFinalNodeSubArea(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
