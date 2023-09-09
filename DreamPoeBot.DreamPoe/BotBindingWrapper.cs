using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class BotBindingWrapper : NotificationObject
{
	private readonly IBot ibot_0;

	public string Version => ibot_0.Version;

	public string Author => ibot_0.Author;

	public string Description => ibot_0.Description;

	public bool IsActive => BotManager.Current.Equals(ibot_0);

	internal BotBindingWrapper(IBot bot)
	{
		ibot_0 = bot;
	}
}
