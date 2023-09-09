using System;

namespace DreamPoeBot.Loki.Game.GameData;

[Flags]
public enum ActorFlags
{
	None = 0,
	UsingAbility = 2,
	AbilityCooldownActive = 0x10,
	Dead = 0x40,
	Moving = 0x80,
	WashedUpState = 0x100,
	LocalPlayer = 0x800
}
