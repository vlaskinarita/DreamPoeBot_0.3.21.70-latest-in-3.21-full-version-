using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class SplitStackUiElement : Element
{
	private Element AcceptButton => base.Children[0].Children[1];

	public Vector2i AcceptLocation => LokiPoe.ElementClickLocation(AcceptButton);

	private Element SplitBar => base.Children[0].Children[0];

	internal Vector2i SplitBarIncreasePos
	{
		get
		{
			Vector2i vector2i = LokiPoe.ElementClickLocation(SplitBar);
			int x = (int)((float)vector2i.X + SplitBar.Width * base.Scale / 2f - 3f);
			return new Vector2i(x, vector2i.Y);
		}
	}

	internal Vector2i SplitBarDecreasePos
	{
		get
		{
			Vector2i vector2i = LokiPoe.ElementClickLocation(SplitBar);
			int x = (int)((float)vector2i.X - SplitBar.Width * base.Scale / 2f + 3f);
			return new Vector2i(x, vector2i.Y);
		}
	}
}
