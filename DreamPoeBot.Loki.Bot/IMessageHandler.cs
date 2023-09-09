namespace DreamPoeBot.Loki.Bot;

public interface IMessageHandler
{
	MessageResult Message(Message message);
}
