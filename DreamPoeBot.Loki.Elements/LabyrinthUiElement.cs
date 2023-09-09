using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class LabyrinthUiElement : Element
{
	public Element ActivateElement => base.Children[3].Children[0].Children[0];

	public Vector2i ActivateClickLocation => LokiPoe.ElementClickLocation(ActivateElement);

	public List<Element> ListDifficulty => base.Children[2].Children[1].Children;

	public Element NormalElement => base.Children[2].Children[1].Children[0].Children[0];

	public Element CruelElement => base.Children[2].Children[1].Children[1].Children[0];

	public Element MercilessElement => base.Children[2].Children[1].Children[2].Children[0];

	public Element EthernalElement => base.Children[2].Children[1].Children[3].Children[0];

	public Vector2i DifficultyClickLocation(int diff)
	{
		return LokiPoe.ElementClickLocation(ListDifficulty[diff].Children[0]);
	}
}
