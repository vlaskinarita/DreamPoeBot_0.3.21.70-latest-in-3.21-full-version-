using System;

namespace DreamPoeBot.Loki.Bot;

public class PlayerMoverChangedEventArgs : EventArgs
{
	public IPlayerMover Old;

	public IPlayerMover New;

	internal PlayerMoverChangedEventArgs(IPlayerMover old, IPlayerMover @new)
	{
		Old = old;
		New = @new;
	}
}
