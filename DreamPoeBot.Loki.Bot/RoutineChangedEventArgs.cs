using System;

namespace DreamPoeBot.Loki.Bot;

public class RoutineChangedEventArgs : EventArgs
{
	public IRoutine Old;

	public IRoutine New;

	internal RoutineChangedEventArgs(IRoutine old, IRoutine @new)
	{
		Old = old;
		New = @new;
	}
}
