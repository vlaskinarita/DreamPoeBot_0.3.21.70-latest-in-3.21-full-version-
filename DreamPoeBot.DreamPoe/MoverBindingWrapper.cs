using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class MoverBindingWrapper : NotificationObject
{
	private readonly IPlayerMover iplayerMover_0;

	public string Version => iplayerMover_0.Version;

	public string Author => iplayerMover_0.Author;

	public string Description => iplayerMover_0.Description;

	public bool IsActive => PlayerMoverManager.Current.Equals(iplayerMover_0);

	internal MoverBindingWrapper(IPlayerMover mover)
	{
		iplayerMover_0 = mover;
	}
}
