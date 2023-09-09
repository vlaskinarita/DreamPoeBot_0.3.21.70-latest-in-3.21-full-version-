using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Bot;

public interface IExplorer : IStartStopEvents, ITickEvents
{
	bool HasLocation { get; }

	Vector2i Location { get; }

	float PercentComplete { get; }

	void Ignore(Vector2i location);

	void Reset();

	void Unload();
}
