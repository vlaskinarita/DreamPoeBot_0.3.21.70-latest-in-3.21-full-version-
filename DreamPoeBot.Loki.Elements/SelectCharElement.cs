using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

internal class SelectCharElement : Element
{
	private Element Main
	{
		get
		{
			try
			{
				if (base.ChildCount == 1L)
				{
					return base.Children[0];
				}
				if (base.ChildCount < 2L)
				{
					return null;
				}
				return base.Children[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	private List<Element> CharList
	{
		get
		{
			try
			{
				return Main?.Children[1]?.Children[0]?.Children[0]?.Children[1]?.Children[1]?.Children[1]?.Children;
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	internal Element PlayButtonElement
	{
		get
		{
			try
			{
				Element main = Main;
				if ((object)main != null && main.Children[1]?.Children[0]?.Children[0]?.Children[1]?.Children[3]?.Children[1]?.ChildCount <= 0L)
				{
					return null;
				}
				return Main?.Children[1]?.Children[0]?.Children[0]?.Children[1]?.Children[3]?.Children[1]?.Children[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	private Element CreateButtonElement
	{
		get
		{
			try
			{
				Element main = Main;
				if ((object)main != null && main.Children[1]?.Children[0]?.Children[0]?.Children[1]?.Children[3]?.Children[0]?.ChildCount <= 0L)
				{
					return null;
				}
				return Main?.Children[1]?.Children[0]?.Children[0]?.Children[1]?.Children[3]?.Children[0]?.Children[0];
			}
			catch (Exception)
			{
				return null;
			}
		}
	}

	public Vector2i PlayButtonPosition => LokiPoe.ElementClickLocation(PlayButtonElement);

	public Vector2i CreateButtonPosition => LokiPoe.ElementClickLocation(CreateButtonElement);

	private Element FindCharElement(string name)
	{
		if (CharList == null)
		{
			return null;
		}
		foreach (Element @char in CharList)
		{
			if (@char.Children[0].Children[2].Text == name)
			{
				return @char.Children[0].Children[2];
			}
		}
		return null;
	}

	private Vector2i FindPositionForCharElement(Element element)
	{
		float num = element.X + element.Width / 2f;
		float num2 = element.Y + element.Height / 2f;
		float num3 = element.Parent.X + element.Parent.Parent.X + element.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.X;
		float num4 = element.Parent.Y + element.Parent.Parent.Y + element.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Y;
		return new Vector2i((int)((num + num3) * element.Scale), (int)((num2 + num4) * element.Scale));
	}

	private Vector2i FindPositionForPlayButtonElement(Element element)
	{
		float num = element.X + element.Width / 2f;
		float num2 = element.Y + element.Height / 2f;
		float num3 = element.Parent.X + element.Parent.Parent.X + element.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.X + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.X;
		float num4 = element.Parent.Y + element.Parent.Parent.Y + element.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Y + element.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Y;
		return new Vector2i((int)((num + num3) * element.Scale), (int)((num2 + num4) * element.Scale));
	}

	public Vector2i CharPosition(string name)
	{
		if (string.IsNullOrEmpty(name))
		{
			return default(Vector2i);
		}
		Element element = FindCharElement(name);
		if (element == null)
		{
			return default(Vector2i);
		}
		return LokiPoe.ElementClickLocation(element);
	}
}
