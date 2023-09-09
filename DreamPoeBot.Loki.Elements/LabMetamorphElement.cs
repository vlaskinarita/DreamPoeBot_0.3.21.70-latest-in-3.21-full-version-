using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class LabMetamorphElement : Element
{
	public Element CreateButtonElement => base.Children[3]?.Children[2];

	private Element IngredientsElement => base.Children[3]?.Children[1];

	public List<LokiPoe.InGameState.MetamorphUi.Category> MissingIngredients
	{
		get
		{
			List<LokiPoe.InGameState.MetamorphUi.Category> list = new List<LokiPoe.InGameState.MetamorphUi.Category>();
			Element element = Brain.Children[0];
			if ((object)element != null && element.ChildCount < 2L)
			{
				list.Add(LokiPoe.InGameState.MetamorphUi.Category.Brains);
			}
			Element element2 = Eye.Children[0];
			if ((object)element2 != null && element2.ChildCount < 2L)
			{
				list.Add(LokiPoe.InGameState.MetamorphUi.Category.Eyes);
			}
			Element element3 = Lung.Children[0];
			if ((object)element3 != null && element3.ChildCount < 2L)
			{
				list.Add(LokiPoe.InGameState.MetamorphUi.Category.Lungs);
			}
			Element element4 = Heart.Children[0];
			if ((object)element4 != null && element4.ChildCount < 2L)
			{
				list.Add(LokiPoe.InGameState.MetamorphUi.Category.Hearts);
			}
			Element element5 = Liver.Children[0];
			if ((object)element5 != null && element5.ChildCount < 2L)
			{
				list.Add(LokiPoe.InGameState.MetamorphUi.Category.Livers);
			}
			return list;
		}
	}

	private Element Brain => IngredientsElement.Children[5];

	private Element Eye => IngredientsElement.Children[1];

	private Element Lung => IngredientsElement.Children[3];

	private Element Heart => IngredientsElement.Children[4];

	private Element Liver => IngredientsElement.Children[2];
}
