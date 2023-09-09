namespace DreamPoeBot.Loki.Game;

public enum SplitStackResult
{
	None,
	ProcessHookManagerNotEnabled,
	CursorFull,
	IncompatibleItemType,
	ItemNotFound,
	SplitStackUiDidNotOpen,
	InvalidQuantity,
	Failed,
	Unsupported
}
