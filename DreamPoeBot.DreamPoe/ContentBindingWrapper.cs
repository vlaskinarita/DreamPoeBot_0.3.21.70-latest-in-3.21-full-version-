using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class ContentBindingWrapper : NotificationObject
{
	private readonly IContent icontent_0;

	public string Version => icontent_0.Version;

	public string Author => icontent_0.Author;

	public string Description => icontent_0.Description;

	internal ContentBindingWrapper(IContent content)
	{
		icontent_0 = content;
	}
}
