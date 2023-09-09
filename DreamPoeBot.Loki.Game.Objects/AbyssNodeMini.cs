namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssNodeMini : NetworkObject
{
	public override string Name => "AbyssNodeMini";

	public float TimeLeft => base.Components.Timer.TimeLeft;

	internal AbyssNodeMini(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
