namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssNodeLarge : TriggerableBlockage
{
	public override string Name => "AbyssNodeLarge";

	internal AbyssNodeLarge(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
