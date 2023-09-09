using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class HideoutSelectionElement : Element
{
	public IEnumerable<LokiPoe.InGameState.HideoutSelectionUi.HideoutTemplate> HideoutList
	{
		get
		{
			foreach (Element child in base.Children[3].Children[0].Children[0].Children)
			{
				yield return new LokiPoe.InGameState.HideoutSelectionUi.HideoutTemplate(child);
			}
		}
	}
}
