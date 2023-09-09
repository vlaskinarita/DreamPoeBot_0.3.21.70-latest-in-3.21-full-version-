using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class CardTradeElement : Element
{
	public Element TradeButton => base.Children[4];

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory Inventory => GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(base.Children[5].Address);

	public Vector2i TradeButtonClickPosition => LokiPoe.ElementClickLocation(TradeButton.Children[0]);
}
