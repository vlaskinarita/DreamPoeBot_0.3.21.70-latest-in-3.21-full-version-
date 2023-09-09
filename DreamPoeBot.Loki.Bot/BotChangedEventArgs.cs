using System;

namespace DreamPoeBot.Loki.Bot;

public class BotChangedEventArgs : EventArgs
{
	public IBot New;

	public IBot Old;

	internal BotChangedEventArgs(IBot old, IBot @new)
	{
		Old = old;
		New = @new;
	}
}
