using System.Collections.Generic;

namespace DreamPoeBot.Loki.Game.GameData;

public class PantheonGodsWrapper
{
	public PantheonGod Name { get; }

	public bool IsUnlocked { get; }

	public List<PantheonSouls> Souls { get; }

	public PantheonGodsWrapper(PantheonGod name, bool isUnlocked, List<PantheonSouls> souls)
	{
		Name = name;
		IsUnlocked = isUnlocked;
		Souls = souls;
	}
}
