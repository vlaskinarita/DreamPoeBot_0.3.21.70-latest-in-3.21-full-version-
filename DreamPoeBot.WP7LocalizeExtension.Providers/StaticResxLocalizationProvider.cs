using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;
using System.Windows;
using DreamPoeBot.WPFLocalizeExtension.Providers;

namespace DreamPoeBot.WP7LocalizeExtension.Providers;

internal class StaticResxLocalizationProvider : ResxLocalizationProviderBase
{
	public static readonly DependencyProperty DefaultDictionaryProperty = DependencyProperty.RegisterAttached("DefaultDictionary", typeof(string), typeof(StaticResxLocalizationProvider), new PropertyMetadata(null, smethod_1));

	public static readonly DependencyProperty DefaultAssemblyProperty = DependencyProperty.RegisterAttached("DefaultAssembly", typeof(string), typeof(StaticResxLocalizationProvider), new PropertyMetadata(null, smethod_1));

	private static string string_2 = "";

	private static string string_3 = "";

	private static StaticResxLocalizationProvider staticResxLocalizationProvider_0;

	private static readonly object object_0 = new object();

	public static StaticResxLocalizationProvider Instance
	{
		get
		{
			if (staticResxLocalizationProvider_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (staticResxLocalizationProvider_0 == null)
					{
						staticResxLocalizationProvider_0 = new StaticResxLocalizationProvider();
					}
				}
			}
			return staticResxLocalizationProvider_0;
		}
	}

	private static void smethod_1(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		Instance.OnProviderChanged(null);
	}

	public static string GetDefaultDictionary(DependencyObject obj)
	{
		return string_3;
	}

	public static string GetDefaultAssembly(DependencyObject obj)
	{
		return string_2;
	}

	public static void SetDefaultDictionary(DependencyObject obj, string value)
	{
		string_3 = value;
	}

	public static void SetDefaultAssembly(DependencyObject obj, string value)
	{
		string_2 = value;
	}

	private StaticResxLocalizationProvider()
	{
		ResourceManagerList = new Dictionary<string, ResourceManager>();
		base.AvailableCultures = new ObservableCollection<CultureInfo>();
		base.AvailableCultures.Add(CultureInfo.InvariantCulture);
	}

	protected override string GetAssembly(DependencyObject target)
	{
		return string_2;
	}

	protected override string GetDictionary(DependencyObject target)
	{
		return string_3;
	}
}
