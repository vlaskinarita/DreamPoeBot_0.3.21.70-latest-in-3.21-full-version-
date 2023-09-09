using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class AnointingElement : Element
{
	internal Element MainControlElement => base.Children[5];

	public Element AnointButton => MainControlElement?.Children[1];

	public string ModTitle
	{
		get
		{
			if (MainControlElement?.Children[0]?.Children[0]?.Text == null)
			{
				return "";
			}
			return MainControlElement?.Children[0]?.Children[0]?.Text;
		}
	}

	public string ModDescription
	{
		get
		{
			if (MainControlElement?.Children[0]?.Children[1]?.Text == null)
			{
				return "";
			}
			return MainControlElement?.Children[0]?.Children[1]?.Text;
		}
	}

	public string ModError
	{
		get
		{
			if (MainControlElement?.Children[0]?.Children[2]?.Text == null)
			{
				return "";
			}
			return MainControlElement?.Children[0]?.Children[2]?.Text;
		}
	}

	public Inventory MainInventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.AnointingUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.AnointingUi.IsVisible)
			{
				return null;
			}
			return GetObject<Inventory>(MainControlElement.Children[3].Address);
		}
	}

	public Inventory Oil1Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.AnointingUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.AnointingUi.IsVisible)
			{
				return null;
			}
			return GetObject<Inventory>(MainControlElement.Children[2].Children[0].Children[0].Address);
		}
	}

	public Inventory Oil2Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.AnointingUi == null)
			{
				return null;
			}
			if (GameController.Instance.Game.IngameState.IngameUi.AnointingUi.IsVisible)
			{
				return GetObject<Inventory>(MainControlElement.Children[2].Children[1].Children[0].Address);
			}
			return null;
		}
	}

	public Inventory Oil3Inventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.AnointingUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.AnointingUi.IsVisible)
			{
				return null;
			}
			return GetObject<Inventory>(MainControlElement.Children[2].Children[2].Children[0].Address);
		}
	}
}
