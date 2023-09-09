namespace DreamPoeBot.Loki.Elements;

public class WatchStoneElement : Element
{
	public Element Red => base.Children[0];

	public Element Green => base.Children[1];

	public Element Blue => base.Children[2];

	public Element Yellow => base.Children[3];
}
