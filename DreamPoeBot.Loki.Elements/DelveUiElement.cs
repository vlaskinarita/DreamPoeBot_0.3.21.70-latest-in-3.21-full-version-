namespace DreamPoeBot.Loki.Elements;

public class DelveUiElement : Element
{
	internal new Element Root => base.Children[0]?.Children[0];
}
