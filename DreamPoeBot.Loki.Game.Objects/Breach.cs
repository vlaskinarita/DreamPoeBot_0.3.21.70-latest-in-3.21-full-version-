namespace DreamPoeBot.Loki.Game.Objects;

public class Breach : NetworkObject
{
	public override string Name => "Breach";

	internal Breach(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
