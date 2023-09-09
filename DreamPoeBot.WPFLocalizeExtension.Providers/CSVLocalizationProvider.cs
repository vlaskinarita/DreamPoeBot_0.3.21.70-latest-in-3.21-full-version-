using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal class CSVLocalizationProvider : CSVLocalizationProviderBase
{
	public static readonly DependencyProperty DefaultDictionaryProperty = DependencyProperty.RegisterAttached("DefaultDictionary", typeof(string), typeof(CSVLocalizationProvider), new PropertyMetadata(null, smethod_0));

	private Dictionary<DependencyObject, ParentChangedNotifier> dictionary_0 = new Dictionary<DependencyObject, ParentChangedNotifier>();

	private static CSVLocalizationProvider csvlocalizationProvider_0;

	private static readonly object object_0 = new object();

	private bool bool_0;

	public static CSVLocalizationProvider Instance
	{
		get
		{
			if (csvlocalizationProvider_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (csvlocalizationProvider_0 == null)
					{
						csvlocalizationProvider_0 = new CSVLocalizationProvider();
					}
				}
			}
			return csvlocalizationProvider_0;
		}
	}

	public bool HasHeader
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
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

	public static void SetDefaultDictionary(DependencyObject obj, string value)
	{
		obj.SetValue(DefaultDictionaryProperty, value);
	}

	private CSVLocalizationProvider()
	{
		base.AvailableCultures = new ObservableCollection<CultureInfo>();
		base.AvailableCultures.Add(CultureInfo.InvariantCulture);
	}

	private void method_0(DependencyObject dependencyObject_0)
	{
		OnProviderChanged(dependencyObject_0);
	}

	protected override string GetDictionary(DependencyObject target)
	{
		return target?.GetValueOrRegisterParentNotifier<string>(DefaultDictionaryProperty, method_0, dictionary_0);
	}

	protected override string GetAssembly(DependencyObject target)
	{
		return target?.GetValueOrRegisterParentNotifier<string>(CSVEmbeddedLocalizationProvider.DefaultAssemblyProperty, method_0, dictionary_0);
	}

	public override object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
	{
		string text = null;
		string text2 = "";
		string outAssembly = "";
		string outDict = "";
		CSVLocalizationProviderBase.ParseKey(key, out outAssembly, out outDict, out key);
		if (string.IsNullOrEmpty(outDict))
		{
			outDict = GetDictionary(target);
		}
		string path = "Localization";
		string text3 = "";
		while (culture != CultureInfo.InvariantCulture)
		{
			text3 = Path.Combine(path, outDict + (string.IsNullOrEmpty(culture.Name) ? "" : ("." + culture.Name)) + ".csv");
			if (File.Exists(text3))
			{
				break;
			}
			culture = culture.Parent;
		}
		if (!File.Exists(text3))
		{
			text3 = Path.Combine(path, outDict + ".csv");
			if (!File.Exists(text3))
			{
				OnProviderError(target, key, "A file for the provided culture " + culture.EnglishName + " does not exist at " + text3 + ".");
				return null;
			}
		}
		using (StreamReader streamReader = new StreamReader(text3, Encoding.Default))
		{
			if (HasHeader && !streamReader.EndOfStream)
			{
				streamReader.ReadLine();
			}
			while (!streamReader.EndOfStream)
			{
				string[] array = streamReader.ReadLine().Split(";".ToCharArray());
				if (array.Length >= 2 && !(array[0] != key))
				{
					text = array[1];
					break;
				}
			}
		}
		if (text == null)
		{
			OnProviderError(target, key, "The key does not exist in " + text2 + ".");
		}
		return text;
	}
}
