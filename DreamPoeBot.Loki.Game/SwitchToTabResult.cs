namespace DreamPoeBot.Loki.Game;

public enum SwitchToTabResult
{
	None,
	ProcessHookManagerNotEnabled,
	Failed,
	UiNotOpen,
	TabListNotOpen,
	TabNotFound,
	FailedToOpenTabList,
	UnableToFindTabInScrollView,
	NoMoreTabs,
	NotSupported
}
