using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class InheritingResxLocalizationProvider : ResxLocalizationProviderBase
{
	public static readonly DependencyProperty DefaultDictionaryProperty = DependencyProperty.RegisterAttached("DefaultDictionary", typeof(string), typeof(InheritingResxLocalizationProvider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, smethod_1));

	public static readonly DependencyProperty DefaultAssemblyProperty = DependencyProperty.RegisterAttached("DefaultAssembly", typeof(string), typeof(InheritingResxLocalizationProvider), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, smethod_1));

	private static InheritingResxLocalizationProvider inheritingResxLocalizationProvider_0;

	private static readonly object object_0 = new object();

	public static InheritingResxLocalizationProvider Instance
	{
		get
		{
			if (inheritingResxLocalizationProvider_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (inheritingResxLocalizationProvider_0 == null)
					{
						inheritingResxLocalizationProvider_0 = new InheritingResxLocalizationProvider();
					}
				}
			}
			return inheritingResxLocalizationProvider_0;
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

	private InheritingResxLocalizationProvider()
	{
		ResourceManagerList = new Dictionary<string, ResourceManager>();
		base.AvailableCultures = new ObservableCollection<CultureInfo>();
		base.AvailableCultures.Add(CultureInfo.InvariantCulture);
	}

	protected override string GetAssembly(DependencyObject target)
	{
		if (target == null)
		{
			return null;
		}
		return target.GetValue(DefaultAssemblyProperty) as string;
	}

	protected override string GetDictionary(DependencyObject target)
	{
		if (target == null)
		{
			return null;
		}
		return target.GetValue(DefaultDictionaryProperty) as string;
	}
}
