using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Common.MVVM;
using log4net;

namespace DreamPoeBot.DreamPoe;

public class PluginBindingWrapper : NotificationObject
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly IPlugin iplugin_0;

	public string Version => iplugin_0.Version;

	public string Author => iplugin_0.Author;

	public string Description => iplugin_0.Description;

	public bool IsEnabled
	{
		get
		{
			return PluginManager.IsEnabled(iplugin_0);
		}
		set
		{
			if (BotManager.IsRunning && iplugin_0 is IStartStopEvents)
			{
				return;
			}
			if (PluginManager.IsEnabled(iplugin_0))
			{
				if (value)
				{
					return;
				}
				if (!PluginManager.Disable(iplugin_0))
				{
					ilog_0.ErrorFormat("Could not disable the plugin {0}.", (object)iplugin_0.Name);
				}
			}
			else
			{
				if (!value)
				{
					return;
				}
				if (!PluginManager.Enable(iplugin_0))
				{
					ilog_0.ErrorFormat("Could not enable the plugin {0}.", (object)iplugin_0.Name);
				}
			}
			NotifyPropertyChanged(() => IsEnabled);
		}
	}

	internal PluginBindingWrapper(IPlugin plugin)
	{
		iplugin_0 = plugin;
	}
}
