namespace DreamPoeBot.Loki.Game;

public enum PlaceCursorIntoResult
{
	None,
	ProcessHookManagerNotEnabled,
	NoItemToMove,
	InvalidPosition,
	ItemWontFit,
	Failed,
	ItemNotAllowed,
	OverlapNotAllowed,
	Unsupported
}
