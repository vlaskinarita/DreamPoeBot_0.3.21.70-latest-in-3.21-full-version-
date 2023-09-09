using System.Threading.Tasks;

namespace DreamPoeBot.Loki.Bot;

public interface ITask : IAuthored, ILogicProvider, IMessageHandler, IStartStopEvents, ITickEvents
{
	Task<bool> Run();
}
