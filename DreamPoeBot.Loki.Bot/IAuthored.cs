namespace DreamPoeBot.Loki.Bot;

public interface IAuthored
{
	string Author { get; }

	string Description { get; }

	string Name { get; }

	string Version { get; }
}
