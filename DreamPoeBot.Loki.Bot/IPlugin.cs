namespace DreamPoeBot.Loki.Bot;

public interface IPlugin : IAuthored, IBase, IConfigurable, IEnableable, ILogicProvider, IMessageHandler
{
}
