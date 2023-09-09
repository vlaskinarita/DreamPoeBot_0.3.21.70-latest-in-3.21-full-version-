using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Bot;

public interface IItemEvaluator
{
	string Name { get; }

	bool Match(Item item, EvaluationType type);
}
