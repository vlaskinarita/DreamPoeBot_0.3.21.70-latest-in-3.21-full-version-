namespace DreamPoeBot.Loki.Elements;

public class AtlasWarningElement : Element
{
	public Element OkButton => base.Children[0].Children[2];

	public string FullText => base.M.ReadNativeString(base.Children[0].Children[1].Address + 744L);
}
