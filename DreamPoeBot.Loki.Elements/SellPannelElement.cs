using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class SellPannelElement : Element
{
	private Element MainElement
	{
		get
		{
			if (GameController.Instance.Game.IngameState.IngameUi.SellPanell.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.SellPanell.Children[3];
			}
			if (GameController.Instance.Game.IngameState.IngameUi.SellPanellNew.IsVisible)
			{
				return GameController.Instance.Game.IngameState.IngameUi.SellPanellNew.Children[4];
			}
			return null;
		}
	}

	public string OtherOffertCharName
	{
		get
		{
			if (base.Address == 0L)
			{
				return "";
			}
			if (MainElement.IsVisible)
			{
				return MainElement.Children[2].Text.TrimEnd("'s Offer".ToCharArray());
			}
			return "";
		}
	}

	public Element MyOffertElement
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (!MainElement.IsVisible)
			{
				return null;
			}
			return MainElement.Children[0];
		}
	}

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory MyOffert
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (MainElement.IsVisible)
			{
				return GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(MyOffertElement.Address);
			}
			return null;
		}
	}

	public Element OtherOffertElement
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (MainElement.IsVisible)
			{
				return MainElement.Children[1];
			}
			return null;
		}
	}

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory OtherOffert
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (!MainElement.IsVisible)
			{
				return null;
			}
			return GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(OtherOffertElement.Address);
		}
	}

	public Element AcceptButton
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (MainElement.IsVisible)
			{
				return MainElement.Children[5].Children[0];
			}
			return null;
		}
	}

	public bool IsAcceptButtonEnabled
	{
		get
		{
			if (base.Address == 0L)
			{
				return false;
			}
			if (!MainElement.IsVisible)
			{
				return false;
			}
			return MainElement.Children[5].IsEnable;
		}
	}

	public Element CancelButton
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			if (MainElement.IsVisible)
			{
				return MainElement.Children[6].Children[0];
			}
			return null;
		}
	}

	public Element ConfirmElement => null;

	public Vector2i AceptButtonPosition
	{
		get
		{
			if (AcceptButton == null)
			{
				return default(Vector2i);
			}
			return LokiPoe.ElementClickLocation(AcceptButton);
		}
	}

	public Vector2i CancellButtonPosition
	{
		get
		{
			if (CancelButton == null)
			{
				return default(Vector2i);
			}
			return LokiPoe.ElementClickLocation(CancelButton);
		}
	}
}
