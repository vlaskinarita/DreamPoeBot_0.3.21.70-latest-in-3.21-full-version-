using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class MapDeviceElement : Element
{
	public Element ActivateElement => base.Children[4]?.Children[0];

	public Vector2i ActivateClickPos => LokiPoe.ElementClickLocation(ActivateElement);

	public Element AtlasElement => base.Children[5]?.Children[0];

	public Vector2i AtlasClickPos => LokiPoe.ElementClickLocation(AtlasElement);

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.MapDevicePannel == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.MapDevicePannel.IsVisible)
			{
				return null;
			}
			return GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(base.Children[7].Address);
		}
	}
}
