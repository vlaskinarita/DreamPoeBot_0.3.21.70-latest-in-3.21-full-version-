namespace DreamPoeBot.Loki.Game.Objects;

public class LabyrinthReturnPortal : Portal
{
	public override string Name => "Return To Town";

	internal LabyrinthReturnPortal(NetworkObject entry)
		: base(entry._entity)
	{
	}
}
