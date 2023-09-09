namespace DreamPoeBot.Loki.Bot;

public interface IMouseHandler
{
	void OnPreMove(string sender, int x, int y, bool isUserCall);
}
