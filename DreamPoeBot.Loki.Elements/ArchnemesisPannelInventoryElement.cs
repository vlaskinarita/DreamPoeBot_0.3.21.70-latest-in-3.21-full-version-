using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements;

public class ArchnemesisPannelInventoryElement : Element
{
	internal List<Element> InventorySlotElement => base.Children[2].Children[0].Children[0].Children;
}
