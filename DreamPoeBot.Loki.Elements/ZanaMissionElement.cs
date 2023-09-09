using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements;

public class ZanaMissionElement : Element
{
	internal Element ActivateButtonElement => base.Children[0].Children[2].Children[0];

	internal string ObjectiveDescription => base.Children[0].Children[5].Children[0].Text;

	internal List<Element> ItemsSlots => base.Children[0].Children[3].Children;

	internal List<Element> TiersButtons => base.Children[0].Children[0].Children;

	internal Element TierWhite => TiersButtons[0];

	internal Element TierYellow => TiersButtons[1];

	internal Element TierRed => TiersButtons[2];
}
