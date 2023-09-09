using System;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class ContextMenuUiElement : Element
{
	public Element PlayerName => base.Children[0].Children[0];

	public Vector2i CloseClickPos => LokiPoe.ElementClickLocation(base.Children[1]);

	public Vector2i FindPosByText(string txt)
	{
		Element element = FindElementByText(txt);
		if (!(element == null))
		{
			return LokiPoe.ElementClickLocation(element);
		}
		return Vector2i.Zero;
	}

	private Element FindElementByText(string txt)
	{
		foreach (Element child in base.Children[0].Children)
		{
			if (child.ChildCount != 1L || string.IsNullOrEmpty(child.Children[0].Text) || !child.Children[0].Text.Equals(txt, StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			return child;
		}
		return null;
	}
}
