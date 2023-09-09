namespace DreamPoeBot.Loki.Components;

public class RenderItem : Component
{
	public string ResourcePath => base.M.ReadNativeString(base.Address + 40L);
}
