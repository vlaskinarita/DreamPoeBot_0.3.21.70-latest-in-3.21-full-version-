using System.Collections.Generic;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class ArchnemesisEncounterStartPannelElement : Element
{
	internal Element BeginButton => base.Children[2].Children[2].Children[0];

	internal List<Element> Slots => base.Children[2].Children[0].Children;

	public int NrOfEmptySlots => Slots.Count((Element x) => !x.Children[0].IsEnable && !x.Children[0].IsVisible);

	public int NrOfFullSlots => Slots.Count((Element x) => !x.Children[0].IsEnable && x.Children[0].IsVisible);

	public int NrOfAvailableSlots => Slots.Count((Element x) => x.Children[0].IsEnable && !x.Children[0].IsVisible);
}
