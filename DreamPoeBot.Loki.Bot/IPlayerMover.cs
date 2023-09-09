using DreamPoeBot.Common;
using DreamPoeBot.Loki.Bot.Pathfinding;

namespace DreamPoeBot.Loki.Bot;

public interface IPlayerMover : IAuthored, IBase, IConfigurable, ILogicProvider, IMessageHandler, IStartStopEvents, ITickEvents
{
	PathfindingCommand CurrentCommand { get; }

	bool MoveTowards(Vector2i position, params dynamic[] user);
}
