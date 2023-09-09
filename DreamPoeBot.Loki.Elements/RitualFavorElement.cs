using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class RitualFavorElement : Element
{
	public Element DeferItemButtonElement => base.Children[13]?.Children[0];

	public Element RitualRemainingElement => base.Children[4]?.Children[0];

	public Element TitleElement => base.Children[6];

	public Element TributeRemainingElement => base.Children[7]?.Children[0];

	public Element InventoryElement => base.Children[11];

	public Element RerollElement => base.Children[12]?.Children[0];

	public Element DeferElement => base.Children[13];

	public Inventory Inventory => GetObject<Inventory>(InventoryElement.Address);

	public bool IsDeferItemActive
	{
		get
		{
			if (DeferElement.IsVisible && DeferElement.ChildCount > 0L && !string.IsNullOrEmpty(DeferElement.Children[0].Text))
			{
				return DeferElement.Children[0].Text != "defer item";
			}
			return false;
		}
	}
}
