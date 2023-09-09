using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class IncursionUiElement : Element
{
	public Element OpenTempleElement
	{
		get
		{
			if (base.ChildCount < 7L)
			{
				return null;
			}
			if (base.Children[6].ChildCount >= 1L)
			{
				return base.Children[6].Children[0];
			}
			return null;
		}
	}

	public Element TakeTempleChronicleElement
	{
		get
		{
			if (base.ChildCount < 8L)
			{
				return null;
			}
			if (base.Children[7].ChildCount >= 1L)
			{
				return base.Children[7].Children[0].Children[0];
			}
			return null;
		}
	}

	public Vector2i OpenTempleElementClickLocation
	{
		get
		{
			Element openTempleElement = OpenTempleElement;
			if (!(openTempleElement == null) && openTempleElement.IsVisible)
			{
				return LokiPoe.ElementClickLocation(openTempleElement);
			}
			return Vector2i.Zero;
		}
	}

	public Vector2i TakeTempleChronicleElementClickLocation
	{
		get
		{
			Element takeTempleChronicleElement = TakeTempleChronicleElement;
			if (!(takeTempleChronicleElement == null) && takeTempleChronicleElement.IsVisible)
			{
				return LokiPoe.ElementClickLocation(takeTempleChronicleElement);
			}
			return Vector2i.Zero;
		}
	}
}
