namespace DreamPoeBot.Loki.Bot;

public interface IRoutine : IAuthored, IBase, IConfigurable, ILogicProvider, IMessageHandler, IStartStopEvents, ITickEvents
{
}
