namespace DreamPoeBot.Loki.Game.Objects;

public class StoneAltar : NetworkObject
{
	public const string TypeMetadata = "Metadata/Terrain/StoneCircles/StoneCircleDevice";

	internal StoneAltar(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
