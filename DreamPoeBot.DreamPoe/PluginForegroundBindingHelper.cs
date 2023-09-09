using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class PluginForegroundBindingHelper : NotificationObject
{
	private readonly IPlugin iplugin_0;

	[CompilerGenerated]
	private Binding binding_0;

	internal Binding _binding { get; set; }

	public Brush ForegroundColor
	{
		get
		{
			if (!PluginManager.IsEnabled(iplugin_0))
			{
				return new SolidColorBrush(Color.FromRgb(92, 92, 92));
			}
			return new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
	}

	internal PluginForegroundBindingHelper(IPlugin plugin)
	{
		iplugin_0 = plugin;
	}

	internal void Update()
	{
		NotifyPropertyChanged(() => ForegroundColor);
	}
}
