namespace DreamPoeBot.Loki.Game;

public enum GetItemCostResult
{
	None,
	GetItemByIdFailed,
	ItemIsDivinationCardType,
	CouldNotFindControlForItem,
	NoTooltip,
	CostTextNotFound,
	InternalError1,
	InternalError2,
	InternalError3,
	InternalError4
}
