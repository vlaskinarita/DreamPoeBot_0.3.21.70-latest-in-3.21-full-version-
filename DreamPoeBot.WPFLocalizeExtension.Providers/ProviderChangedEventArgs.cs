using System;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class ProviderChangedEventArgs : EventArgs
{
	[CompilerGenerated]
	private DependencyObject dependencyObject_0;

	public DependencyObject Object { get; private set; }

	public ProviderChangedEventArgs(DependencyObject obj)
	{
		Object = obj;
	}
}
