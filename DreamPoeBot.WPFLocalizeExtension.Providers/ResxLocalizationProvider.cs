using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;
using System.Windows;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class ResxLocalizationProvider : ResxLocalizationProviderBase
{
	public static readonly DependencyProperty DefaultDictionaryProperty = DependencyProperty.RegisterAttached("DefaultDictionary", typeof(string), typeof(ResxLocalizationProvider), new PropertyMetadata(null, smethod_1));

	public static readonly DependencyProperty DefaultAssemblyProperty = DependencyProperty.RegisterAttached("DefaultAssembly", typeof(string), typeof(ResxLocalizationProvider), new PropertyMetadata(null, smethod_1));

	private readonly Dictionary<DependencyObject, ParentChangedNotifier> dictionary_1 = new Dictionary<DependencyObject, ParentChangedNotifier>();

	private static ResxLocalizationProvider resxLocalizationProvider_0;

	private static readonly object object_0 = new object();

	public string FallbackAssembly { get; set; }

	public string FallbackDictionary { get; set; }

	public static ResxLocalizationProvider Instance
	{
		get
		{
			if (resxLocalizationProvider_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (resxLocalizationProvider_0 == null)
					{
						resxLocalizationProvider_0 = new ResxLocalizationProvider();
					}
				}
			}
			return resxLocalizationProvider_0;
		}
	}

	private static void smethod_1(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		Instance.OnProviderChanged(dependencyObject_0);
	}

	public static string GetDefaultDictionary(DependencyObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (string)obj.GetValue(DefaultDictionaryProperty);
	}

	public static string GetDefaultAssembly(DependencyObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (string)obj.GetValue(DefaultAssemblyProperty);
	}

	public static void SetDefaultDictionary(DependencyObject obj, string value)
	{
		obj.SetValue(DefaultDictionaryProperty, value);
	}

	public static void SetDefaultAssembly(DependencyObject obj, string value)
	{
		obj.SetValue(DefaultAssemblyProperty, value);
	}

	public static void Reset()
	{
		object obj = object_0;
		lock (obj)
		{
			resxLocalizationProvider_0 = null;
		}
	}

	private ResxLocalizationProvider()
	{
		ResourceManagerList = new Dictionary<string, ResourceManager>();
		base.AvailableCultures = new ObservableCollection<CultureInfo>();
		base.AvailableCultures.Add(CultureInfo.InvariantCulture);
	}

	private void method_2(DependencyObject dependencyObject_0)
	{
		OnProviderChanged(dependencyObject_0);
	}

	protected override string GetAssembly(DependencyObject target)
	{
		if (target == null)
		{
			return FallbackAssembly;
		}
		string valueOrRegisterParentNotifier = target.GetValueOrRegisterParentNotifier<string>(DefaultAssemblyProperty, method_2, dictionary_1);
		if (string.IsNullOrEmpty(valueOrRegisterParentNotifier))
		{
			return FallbackAssembly;
		}
		return valueOrRegisterParentNotifier;
	}

	protected override string GetDictionary(DependencyObject target)
	{
		if (target == null)
		{
			return FallbackDictionary;
		}
		string valueOrRegisterParentNotifier = target.GetValueOrRegisterParentNotifier<string>(DefaultDictionaryProperty, method_2, dictionary_1);
		if (!string.IsNullOrEmpty(valueOrRegisterParentNotifier))
		{
			return valueOrRegisterParentNotifier;
		}
		return FallbackDictionary;
	}
}
