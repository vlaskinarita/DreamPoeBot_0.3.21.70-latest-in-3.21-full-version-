namespace DreamPoeBot.Loki.Game.Objects;

public class AbyssCrackSpawner : NetworkObject
{
	public override string Name => "AbyssCrackSpawner";

	internal AbyssCrackSpawner(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
