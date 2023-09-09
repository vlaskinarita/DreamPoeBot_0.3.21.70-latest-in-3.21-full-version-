using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class RoutineBindingWrapper : NotificationObject
{
	private readonly IRoutine iroutine_0;

	public string Version => iroutine_0.Version;

	public string Author => iroutine_0.Author;

	public string Description => iroutine_0.Description;

	public bool IsActive => RoutineManager.Current.Equals(iroutine_0);

	internal RoutineBindingWrapper(IRoutine routine)
	{
		iroutine_0 = routine;
	}
}
