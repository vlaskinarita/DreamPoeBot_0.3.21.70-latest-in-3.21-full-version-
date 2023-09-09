using System.Linq;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;

namespace DreamPoeBot.Loki.Game.Objects;

public class ArchnemesisTrappedMonster : Monster
{
	internal Element ActivationButton
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

	internal ArchnemesisTrappedMonster(Monster entity)
		: base(entity._entity)
	{
	}

	public bool OpenMenu()
	{
		Vector2i pos = ActivationButton.CenterClickLocation();
		MouseManager.SetMousePosition(pos, useRandomPos: false);
		Thread.Sleep(30);
		MouseManager.ClickLMB(pos.X, pos.Y);
		Thread.Sleep(60);
		return false;
	}
}
