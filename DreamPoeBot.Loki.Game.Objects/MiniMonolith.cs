namespace DreamPoeBot.Loki.Game.Objects;

public class MiniMonolith : Monolith
{
	public new const string TypeMetadata = "Metadata/MiscellaneousObjects/MiniMonolith";

	public override bool IsMini => true;

	internal MiniMonolith(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
