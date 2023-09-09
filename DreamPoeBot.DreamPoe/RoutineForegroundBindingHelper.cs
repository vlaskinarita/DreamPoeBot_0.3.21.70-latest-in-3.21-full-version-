using System.Windows.Data;
using System.Windows.Media;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common.MVVM;

namespace DreamPoeBot.DreamPoe;

public class RoutineForegroundBindingHelper : NotificationObject
{
	private readonly IRoutine iroutine_0;

	internal Binding _binding { get; set; }

	public Brush ForegroundColor
	{
		get
		{
			if (!RoutineManager.Current.Equals(iroutine_0))
			{
				return new SolidColorBrush(Color.FromRgb(92, 92, 92));
			}
			return new SolidColorBrush(Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue));
		}
	}

	internal RoutineForegroundBindingHelper(IRoutine routine)
	{
		iroutine_0 = routine;
	}

	internal void Update()
	{
		NotifyPropertyChanged(() => ForegroundColor);
	}
}
