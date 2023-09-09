using System;

namespace DreamPoeBot.Loki.Common;

[Flags]
public enum ModifierKeys
{
	Alt = 1,
	Control = 2,
	Shift = 4,
	Win = 8,
	NoRepeat = 0x4000
}
