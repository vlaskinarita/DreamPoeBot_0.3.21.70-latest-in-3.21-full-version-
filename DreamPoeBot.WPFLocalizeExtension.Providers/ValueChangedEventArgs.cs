using System;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class ValueChangedEventArgs : EventArgs
{
	public object Tag { get; private set; }

	public object Value { get; private set; }

	public string Key { get; private set; }

	public ValueChangedEventArgs(string key, object value, object tag)
	{
		Key = key;
		Value = value;
		Tag = tag;
	}
}
