using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki;

public abstract class Component : RemoteMemoryObject
{
	protected NetworkObject Owner => new NetworkObject(base.Address + 8L);
}
