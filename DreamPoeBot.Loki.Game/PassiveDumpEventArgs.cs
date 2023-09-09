using System;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game;

public class PassiveDumpEventArgs : EventArgs
{
	public DatPassiveSkillWrapper PassiveSkill { get; private set; }

	internal PassiveDumpEventArgs(DatPassiveSkillWrapper passiveSkill)
	{
		PassiveSkill = passiveSkill;
	}
}
