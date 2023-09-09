namespace DreamPoeBot.Loki.Bot;

public interface IBot : IAuthored, IBase, IConfigurable, ILogicProvider, IMessageHandler, IStartStopEvents, ITickEvents
{
}
