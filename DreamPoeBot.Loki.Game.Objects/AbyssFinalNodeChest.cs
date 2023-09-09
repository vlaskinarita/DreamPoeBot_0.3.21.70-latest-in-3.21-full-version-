namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssFinalNodeChest : TriggerableBlockage
{
	public override string Name => "AbyssFinalNodeChest";

	internal AbyssFinalNodeChest(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
