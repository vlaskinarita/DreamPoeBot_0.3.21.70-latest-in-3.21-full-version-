namespace DreamPoeBot.Loki.Game.Objects;

public class MissionMarker : NetworkObject
{
	public const string TypeMetadata = "Metadata/MiscellaneousObjects/MissionMarker";

	public override string Name => "MissionMarker";

	internal MissionMarker(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
