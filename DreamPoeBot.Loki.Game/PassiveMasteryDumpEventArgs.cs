using System;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game;

public class PassiveMasteryDumpEventArgs : EventArgs
{
	public DatPassiveSkillMasteryWrapper PassiveSkill { get; private set; }

	internal PassiveMasteryDumpEventArgs(DatPassiveSkillMasteryWrapper passiveSkill)
	{
		PassiveSkill = passiveSkill;
	}
}
