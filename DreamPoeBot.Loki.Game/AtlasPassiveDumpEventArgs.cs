using System;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game;

public class AtlasPassiveDumpEventArgs : EventArgs
{
	public DatPassiveSkillWrapper PassiveSkill { get; private set; }

	internal AtlasPassiveDumpEventArgs(DatPassiveSkillWrapper passiveSkill)
	{
		PassiveSkill = passiveSkill;
	}
}
