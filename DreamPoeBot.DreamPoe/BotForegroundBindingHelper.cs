using System.Windows.Data;
using System.Windows.Media;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class BotForegroundBindingHelper : NotificationObject
{
	private readonly IBot ibot_0;

	internal Binding _binding { get; set; }

	public Brush ForegroundColor
	{
		get
		{
			if (!BotManager.Current.Equals(ibot_0))
			{
				return new SolidColorBrush(Color.FromRgb(92, 92, 92));
			}
			return new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
	}

	internal BotForegroundBindingHelper(IBot bot)
	{
		ibot_0 = bot;
	}

	internal void Update()
	{
		NotifyPropertyChanged(() => ForegroundColor);
	}
}
