using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class RewardElement : Element
{
	public Inventory Offert
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.RewardPannel == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.RewardPannel.IsVisible)
			{
				return GetObject<Inventory>(base.Children[(int)base.ChildCount - 2].Children[0].Children[0].Children[0].Children[0].Address);
			}
			return null;
		}
	}

	public List<Inventory> Inventory
	{
		get
		{
			List<Inventory> list = new List<Inventory>();
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.RewardPannel == null)
			{
				return list;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.RewardPannel.IsVisible)
			{
				return list;
			}
			foreach (Element child in base.Children[(int)base.ChildCount - 2].Children[0].Children)
			{
				foreach (Element child2 in child.Children)
				{
					Inventory @object = GetObject<Inventory>(child2.Children[0].Address);
					list.Add(@object);
				}
			}
			return list;
		}
	}
}
