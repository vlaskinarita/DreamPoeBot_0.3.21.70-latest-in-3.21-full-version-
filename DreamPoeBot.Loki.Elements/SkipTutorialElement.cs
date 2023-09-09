using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class SkipTutorialElement : Element
{
	private Element button => base.Children[0];

	public bool IsButtonVisible => base.Children[0].IsVisible;

	public Vector2i ClickLocation => LokiPoe.ElementClickLocation(button);
}
