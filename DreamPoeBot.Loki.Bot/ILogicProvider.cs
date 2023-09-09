using System.Threading.Tasks;

namespace DreamPoeBot.Loki.Bot;

public interface ILogicProvider
{
	Task<LogicResult> Logic(Logic logic);
}
