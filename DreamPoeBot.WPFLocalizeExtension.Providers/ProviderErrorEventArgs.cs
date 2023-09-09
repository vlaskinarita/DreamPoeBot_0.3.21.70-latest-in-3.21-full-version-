using System;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class ProviderErrorEventArgs : EventArgs
{
	public DependencyObject Object { get; private set; }

	public string Key { get; private set; }

	public string Message { get; private set; }

	public ProviderErrorEventArgs(DependencyObject obj, string key, string message)
	{
		Object = obj;
		Key = key;
		Message = message;
	}
}
