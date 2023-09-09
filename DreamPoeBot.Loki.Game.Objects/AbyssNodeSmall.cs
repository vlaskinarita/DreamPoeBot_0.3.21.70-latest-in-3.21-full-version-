namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssNodeSmall : TriggerableBlockage
{
	public override string Name => "AbyssNodeSmall";

	internal AbyssNodeSmall(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
