using System.Collections.Generic;
using System.Linq;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class TangleAltar : NetworkObject
{
	public class Option
	{
		private Element _element;

		public List<string> Text
		{
			get
			{
				char[] separator = "\n".ToCharArray();
				return _element.Children[1].Text.Split(separator).ToList();
			}
		}

		public void Activate()
		{
			Vector2i pos = _element.CenterClickLocation();
			MouseManager.SetMousePosition(pos, useRandomPos: false);
			Thread.Sleep(90);
			MouseManager.ClickLMB(pos.X, pos.Y);
			Thread.Sleep(60);
		}

		public Option(Element element)
		{
			_element = element;
		}
	}

	internal Element _menu
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (!(label == null))
			{
				return label.GetObjectAt<Element>(0);
			}
			return null;
		}
	}

	public List<Option> Options
	{
		get
		{
			List<Option> list = new List<Option>();
			if (_menu == null)
			{
				return list;
			}
			if (!_menu.IsVisible)
			{
				return list;
			}
			if (_menu.ChildCount > 0L)
			{
				foreach (Element child in _menu.Children)
				{
					list.Add(new Option(child));
				}
				return list;
			}
			return list;
		}
	}

	public TangleAltar(EntityWrapper entity)
		: base(entity)
	{
	}
}
