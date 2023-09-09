using System;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal class MissingKeyEventArgs : EventArgs
{
	public string Key { get; private set; }

	public bool Reload { get; set; }

	public MissingKeyEventArgs(string key)
	{
		Key = key;
		Reload = false;
	}
}
