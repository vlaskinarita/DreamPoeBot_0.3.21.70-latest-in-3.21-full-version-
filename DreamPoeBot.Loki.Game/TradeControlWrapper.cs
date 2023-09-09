using System.Threading;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game;

public class TradeControlWrapper : RemoteMemoryObject
{
	private TradeControlType ControlType;

	internal readonly InventoryControlWrapper InventoryControlWrapperOtherOffert = new InventoryControlWrapper(0L);

	internal readonly InventoryControlWrapper InventoryControlWrapperYourOffert = new InventoryControlWrapper(0L);

	private SellPannelElement SellElement;

	public string AcceptButtonText
	{
		get
		{
			string result = "";
			if (ControlType == TradeControlType.Sell && SellElement.IsVisible)
			{
				result = SellElement.AcceptButton.Text;
			}
			if (ControlType == TradeControlType.Trade && GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible)
			{
				result = GameController.Instance.Game.IngameState.IngameUi.TradeUi.AcceptButton.Text;
			}
			return result;
		}
	}

	public string ConfirmLabelText
	{
		get
		{
			string result = "";
			if (ControlType == TradeControlType.Sell)
			{
				return result;
			}
			if (ControlType == TradeControlType.Trade && GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsVisible && !string.IsNullOrEmpty(GameController.Instance.Game.IngameState.IngameUi.TradeUi.ConfirmElement.Text))
			{
				result = GameController.Instance.Game.IngameState.IngameUi.TradeUi.ConfirmElement.Text;
			}
			return result;
		}
	}

	public InventoryControlWrapper InventoryControl_OtherOffer
	{
		get
		{
			if (GameController.Instance.Game.IngameState.ServerData.TradeInventories.Count > 0)
			{
				DreamPoeBot.Loki.RemoteMemoryObjects.Inventory inventory = ((ControlType == TradeControlType.Sell) ? SellElement.OtherOffert : GameController.Instance.Game.IngameState.IngameUi.TradeUi.OtherOffert);
				long address = GameController.Instance.Game.IngameState.ServerData.TradeInventories[0].Address;
				InventoryControlWrapperOtherOffert.UpdatePointer(address);
				InventoryControlWrapperOtherOffert.SetInventorySlotUi((InventorySlotUiElement)inventory.InventoryUiElement);
			}
			return InventoryControlWrapperOtherOffert;
		}
	}

	public InventoryControlWrapper InventoryControl_YourOffer
	{
		get
		{
			if (GameController.Instance.Game.IngameState.ServerData.TradeInventories.Count > 0)
			{
				DreamPoeBot.Loki.RemoteMemoryObjects.Inventory inventory = ((ControlType == TradeControlType.Sell) ? SellElement.MyOffert : GameController.Instance.Game.IngameState.IngameUi.TradeUi.MyOffert);
				long address = GameController.Instance.Game.IngameState.ServerData.TradeInventories[1].Address;
				InventoryControlWrapperYourOffert.UpdatePointer(address);
				InventoryControlWrapperYourOffert.SetInventorySlotUi((InventorySlotUiElement)inventory.InventoryUiElement);
			}
			return InventoryControlWrapperYourOffert;
		}
	}

	public bool IsConfirmLabelVisible
	{
		get
		{
			if (ControlType != 0)
			{
				return GameController.Instance.Game.IngameState.IngameUi.TradeUi.ConfirmElement.IsVisible;
			}
			return false;
		}
	}

	public bool OtherAcceptedTheOffert
	{
		get
		{
			if (ControlType != 0)
			{
				return GameController.Instance.Game.IngameState.IngameUi.TradeUi.OtherAcceptedTheOffert;
			}
			return false;
		}
	}

	public bool MeAcceptedTheOffert
	{
		get
		{
			if (ControlType != 0)
			{
				return GameController.Instance.Game.IngameState.IngameUi.TradeUi.MeAcceptedTheOffert;
			}
			return false;
		}
	}

	public string OtherName
	{
		get
		{
			if (ControlType == TradeControlType.Sell)
			{
				return SellElement.OtherOffertCharName;
			}
			if (ControlType != TradeControlType.Trade)
			{
				return "";
			}
			return GameController.Instance.Game.IngameState.IngameUi.TradeUi.OtherOffertCharName;
		}
	}

	public TradeControlWrapper()
	{
	}

	public TradeControlWrapper(long control, TradeControlType type)
		: base(control)
	{
		ControlType = type;
	}

	public void UpdateElement(SellPannelElement element)
	{
		SellElement = element;
	}

	public TradeResult Accept(bool actuallyAccept = true)
	{
		if (!Hooking.IsInstalled)
		{
			return TradeResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		Element element = ((ControlType == TradeControlType.Sell) ? SellElement.AcceptButton : GameController.Instance.Game.IngameState.IngameUi.TradeUi.AcceptButton);
		if (!(element == null))
		{
			if ((ControlType == TradeControlType.Sell) ? SellElement.IsAcceptButtonEnabled : GameController.Instance.Game.IngameState.IngameUi.TradeUi.IsAcceptButtonEnabled)
			{
				if (ControlType == TradeControlType.Sell)
				{
					MouseManager.SetMousePosition(SellElement.AceptButtonPosition);
				}
				if (ControlType == TradeControlType.Trade)
				{
					MouseManager.SetMousePosition(GameController.Instance.Game.IngameState.IngameUi.TradeUi.AceptButtonPosition);
				}
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				return TradeResult.None;
			}
			return TradeResult.UnableToTrade;
		}
		return TradeResult.UiNotOpen;
	}

	public TradeResult Cancel(bool actuallyCancel = true)
	{
		if (!Hooking.IsInstalled)
		{
			return TradeResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		Element element = ((ControlType == TradeControlType.Sell) ? SellElement.CancelButton : GameController.Instance.Game.IngameState.IngameUi.TradeUi.CancelButton);
		if (element == null)
		{
			return TradeResult.UiNotOpen;
		}
		if (ControlType == TradeControlType.Sell)
		{
			MouseManager.SetMousePosition(SellElement.CancellButtonPosition);
		}
		if (ControlType == TradeControlType.Trade)
		{
			MouseManager.SetMousePosition(GameController.Instance.Game.IngameState.IngameUi.TradeUi.CancellButtonPosition);
		}
		Thread.Sleep(15);
		MouseManager.ClickLMB();
		Thread.Sleep(15);
		return TradeResult.None;
	}
}
