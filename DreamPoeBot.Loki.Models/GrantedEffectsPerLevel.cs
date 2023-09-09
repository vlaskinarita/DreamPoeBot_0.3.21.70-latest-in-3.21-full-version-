using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Models;

public class GrantedEffectsPerLevel
{
	public long Address { get; set; }

	public DatGrantedEffectWrapper GrantedEffect { get; set; }

	public int Level { get; set; }

	public int RequiredLevel { get; set; }
}
