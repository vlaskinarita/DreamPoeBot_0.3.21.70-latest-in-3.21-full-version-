using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal interface ILocalizationProvider
{
	ObservableCollection<CultureInfo> AvailableCultures { get; }

	event ProviderChangedEventHandler ProviderChanged;

	event ProviderErrorEventHandler ProviderError;

	event ValueChangedEventHandler ValueChanged;

	FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target);

	object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture);
}
