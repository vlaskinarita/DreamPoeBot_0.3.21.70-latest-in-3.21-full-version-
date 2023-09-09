using System;
using System.Windows;

namespace DreamPoeBot.Loki.Common.Controls;

public class TimeSelectedChangedRoutedEventArgs : RoutedEventArgs
{
	public TimeSpan NewTime { get; set; }

	public TimeSpan OldTime { get; set; }

	public TimeSelectedChangedRoutedEventArgs(RoutedEvent routedEvent)
		: base(routedEvent)
	{
	}
}
