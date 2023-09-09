using System;

namespace DreamPoeBot.Loki.Game;

[Flags]
public enum InventoryTabPermissions : short
{
	None = 0,
	View = 1,
	Add = 2,
	Remove = 4
}
