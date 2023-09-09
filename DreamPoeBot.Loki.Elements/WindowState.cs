namespace DreamPoeBot.Loki.Elements;

public class WindowState : Element
{
	public new bool IsVisibleLocal => base.M.ReadInt(base.Address + 2144L) == 1;
}
