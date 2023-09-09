using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Components;

public class HeistRewardDisplay : Component
{
	public Item Item => ReadObjectAt<Item>(32);
}
