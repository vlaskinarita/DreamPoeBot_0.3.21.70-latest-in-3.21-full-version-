namespace DreamPoeBot.Loki.Bot.Pathfinding;

public enum PathfindingError
{
	None,
	StartNotNavigable,
	EndNotNavigable,
	StartAndEndAreSame,
	AreaNotGenerated,
	NoPathAvailable
}
