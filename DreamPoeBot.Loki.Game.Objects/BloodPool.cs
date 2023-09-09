namespace DreamPoeBot.Loki.Game.Objects;

public class BloodPool : NetworkObject
{
	public const string TypeMetadata = "Metadata/Effects/Spells/Masters/Dex/BloodPool";

	public override string Name => "BloodPool";

	internal BloodPool(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
