using System.Collections.Generic;

namespace DreamPoeBot.Loki.Game.GameData;

public class BestiaryCapturedMonsterMod
{
	public int Id { get; internal set; }

	public List<int> Data { get; internal set; }

	public DatModsWrapper Mod { get; internal set; }
}
