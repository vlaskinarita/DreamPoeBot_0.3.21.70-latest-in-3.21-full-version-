using System;

namespace DreamPoeBot.Loki.Game;

[Flags]
public enum InventoryTabFlags : byte
{
	RemoveOnly = 1,
	Todo2 = 2,
	Premium = 4,
	Todo8 = 8,
	Todo10 = 0x10,
	Public = 0x20,
	MapSeries = 0x40,
	Hidden = 0x80
}
