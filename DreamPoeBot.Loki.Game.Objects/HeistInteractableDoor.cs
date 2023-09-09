using System.Linq;
using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;

namespace DreamPoeBot.Loki.Game.Objects;

public class HeistInteractableDoor : NetworkObject
{
	public HeistDoorElement Ui
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
				return label.GetObjectAt<HeistDoorElement>(0);
			}
			return null;
		}
	}

	public HeistInteractableDoor(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public bool Activate()
	{
		Vector2i elementClickLocation = Ui.ElementClickLocation;
		MouseManager.SetMousePosition(elementClickLocation, useRandomPos: false);
		Thread.Sleep(30);
		LokiPoe.Input.SimulateKeyEvent(LokiPoe.Input.Binding.generic_league_key);
		Thread.Sleep(30);
		return true;
	}
}
