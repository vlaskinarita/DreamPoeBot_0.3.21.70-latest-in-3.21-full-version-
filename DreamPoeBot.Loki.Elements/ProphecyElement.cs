namespace DreamPoeBot.Loki.Elements;

public class ProphecyElement : Element
{
	public Element sealButtonElement => base.Children[0]?.Children[0];

	public string name => base.Children[0]?.Children[1]?.Text;
}
