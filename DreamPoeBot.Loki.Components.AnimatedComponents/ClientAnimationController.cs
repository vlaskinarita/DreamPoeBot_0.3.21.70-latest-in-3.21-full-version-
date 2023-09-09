namespace DreamPoeBot.Loki.Components.AnimatedComponents;

public class ClientAnimationController : Component
{
	public int AnimKey => base.M.ReadInt(base.Address + 156L);
}
