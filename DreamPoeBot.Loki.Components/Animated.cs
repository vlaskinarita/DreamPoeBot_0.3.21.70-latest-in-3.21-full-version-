using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Components;

public class Animated : Component
{
	public EntityWrapper BaseAnimatedObjectEntity => GetObject<EntityWrapper>(base.M.ReadLong(base.Address + 560L));
}
