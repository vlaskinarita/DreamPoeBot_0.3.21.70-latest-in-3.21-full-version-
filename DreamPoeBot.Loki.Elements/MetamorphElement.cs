using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class MetamorphElement : Element
{
	public Element CreateButtonElement => base.Children[3]?.Children[2];

	private Element IngredientsElement => base.Children[3]?.Children[0]?.Children[0]?.Children[2];

	public List<LokiPoe.InGameState.MetamorphUi.Ingredient> Ingredients
	{
		get
		{
			List<LokiPoe.InGameState.MetamorphUi.Ingredient> list = new List<LokiPoe.InGameState.MetamorphUi.Ingredient>();
			foreach (Element child in IngredientsElement.Children)
			{
				if (child == null || child.ChildCount < 2L)
				{
					continue;
				}
				LokiPoe.InGameState.MetamorphUi.Category category = GetCategory(child);
				foreach (Element child2 in child.Children[0].Children)
				{
					list.Add(new LokiPoe.InGameState.MetamorphUi.Ingredient(child2, category));
				}
			}
			return list;
		}
	}

	private LokiPoe.InGameState.MetamorphUi.Category GetCategory(Element element)
	{
		if (element.Children[1]?.Children[0] == null)
		{
			return LokiPoe.InGameState.MetamorphUi.Category.none;
		}
		return element.Children[1].Children[0].Text switch
		{
			"Brains" => LokiPoe.InGameState.MetamorphUi.Category.Brains, 
			"Lungs" => LokiPoe.InGameState.MetamorphUi.Category.Lungs, 
			"Livers" => LokiPoe.InGameState.MetamorphUi.Category.Livers, 
			"Hearts" => LokiPoe.InGameState.MetamorphUi.Category.Hearts, 
			"Eyes" => LokiPoe.InGameState.MetamorphUi.Category.Eyes, 
			_ => LokiPoe.InGameState.MetamorphUi.Category.none, 
		};
	}
}
