using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class MoverForegroundBindingHelper : NotificationObject
{
	private readonly IPlayerMover iplayerMover_0;

	[CompilerGenerated]
	private Binding binding_0;

	internal Binding _binding { get; set; }

	public Brush ForegroundColor
	{
		get
		{
			if (!PlayerMoverManager.Current.Equals(iplayerMover_0))
			{
				return new SolidColorBrush(Color.FromRgb(92, 92, 92));
			}
			return new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
	}

	internal MoverForegroundBindingHelper(IPlayerMover mover)
	{
		iplayerMover_0 = mover;
	}

	internal void Update()
	{
		NotifyPropertyChanged(() => ForegroundColor);
	}
}
