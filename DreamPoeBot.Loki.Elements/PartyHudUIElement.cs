using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class PartyHudUIElement : Element
{
	public class PartyInfo
	{
		private PartyHudUIElement hud;

		private Element element;

		public string Name => element.Children[0].Text;

		public string Zone
		{
			get
			{
				if (element.ChildCount == 3L)
				{
					return LokiPoe.LocalData.WorldArea.Name;
				}
				if (element.ChildCount != 4L)
				{
					return "";
				}
				if (element.Children[2].Text == null)
				{
					return "";
				}
				return element.Children[2].Text;
			}
		}

		public bool IsInSameZone => element.IsEnable;

		public Vector2i GotoZoneClickPos
		{
			get
			{
				if (element.ChildCount < 3L)
				{
					return Vector2i.Zero;
				}
				return hud.ElementClickLocation(element.Children.LastOrDefault());
			}
		}

		public Vector2i OpenContextMenuClickPos
		{
			get
			{
				if (element.ChildCount < 3L)
				{
					return Vector2i.Zero;
				}
				return hud.ElementClickLocation(element.Children[1]);
			}
		}

		public PartyInfo(Element _ele, PartyHudUIElement _hud)
		{
			element = _ele;
			hud = _hud;
		}
	}

	public List<PartyInfo> PartyList
	{
		get
		{
			List<PartyInfo> list = new List<PartyInfo>();
			foreach (Element child in base.Children[0].Children[0].Children)
			{
				list.Add(new PartyInfo(child, this));
			}
			return list;
		}
	}

	private Vector2i ElementClickLocation(Element element)
	{
		if (element == null)
		{
			return Vector2i.Zero;
		}
		float num = element.X + element.Width / 2f;
		float num2 = element.Y + element.Height / 2f;
		Element parent = element.Parent;
		while (parent.Address != 0L && parent.IdLabel != "root")
		{
			num += parent.X;
			num2 += parent.Y;
			parent = parent.Parent;
		}
		return new Vector2i((int)(num * base.Scale), (int)(num2 * base.Scale));
	}
}
