namespace DreamPoeBot.Loki.Game;

public enum OpenPremiumStashSettingResult
{
	None,
	NotPremiumStash,
	NotSupported,
	ProcessHookManagerNotEnabled,
	Failed,
	TabNotFound,
	UiNotOpen,
	TabListNotOpen,
	FailedToOpenTabList,
	UnableToFindTabInScrollView,
	NoMoreTabs
}
