using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using DreamPoeBot.WPFLocalizeExtension.Engine;
using DreamPoeBot.WPFLocalizeExtension.Providers;
using DreamPoeBot.WPFLocalizeExtension.TypeConverters;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Extensions;

[ContentProperty("ResourceIdentifierKey")]
internal class LocExtension : NestedMarkupExtension, IDisposable, INotifyPropertyChanged, IDictionaryEventListener
{
	[Serializable]
	private sealed class Class87
	{
		public static readonly Class87 Class9 = new Class87();

		public static Func<TargetPath, DependencyObject> Method9__39_0;

		internal DependencyObject method_0(TargetPath targetPath_0)
		{
			return targetPath_0.EndPoint.TargetObject as DependencyObject;
		}
	}

	private sealed class Class88
	{
		public object object_0;

		public object object_1;

		internal bool method_0(TargetPath targetPath_0)
		{
			if (targetPath_0.EndPoint.TargetObject == object_0)
			{
				return targetPath_0.EndPoint.TargetProperty == object_1;
			}
			return false;
		}
	}

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private static object object_0 = new object();

	private static Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

	private string string_0;

	private IValueConverter ivalueConverter_0;

	private object object_1;

	private SafeTargetInfo safeTargetInfo_0;

	public string Key
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				string_0 = value;
				UpdateNewValue();
				method_2("Key");
			}
		}
	}

	public IValueConverter Converter
	{
		get
		{
			if (ivalueConverter_0 == null)
			{
				ivalueConverter_0 = new DefaultConverter();
			}
			return ivalueConverter_0;
		}
		set
		{
			ivalueConverter_0 = value;
		}
	}

	public object ConverterParameter
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
		}
	}

	public string ForceCulture { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	[ConstructorArgument("key")]
	public string InitializeValue { get; set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	public string ResourceIdentifierKey
	{
		get
		{
			return string_0 ?? "(null)";
		}
		set
		{
			string_0 = value;
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while (propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while (propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	internal void method_2(string string_3)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_3));
		}
	}

	public static void ClearResourceBuffer()
	{
		object obj = object_0;
		lock (obj)
		{
			if (dictionary_1 != null)
			{
				dictionary_1.Clear();
			}
		}
		dictionary_1 = null;
	}

	internal static void smethod_0(string string_3, object object_2)
	{
		object obj = object_0;
		lock (obj)
		{
			if (!LocalizeDictionary.Instance.DisableCache && !dictionary_1.ContainsKey(string_3))
			{
				dictionary_1.Add(string_3, object_2);
			}
		}
	}

	internal static void smethod_1(string string_3)
	{
		object obj = object_0;
		lock (obj)
		{
			if (dictionary_1.ContainsKey(string_3))
			{
				dictionary_1.Remove(string_3);
			}
		}
	}

	public static LocExtension GetBoundExtension(object target, string property, int propertyIndex = -1)
	{
		foreach (LocExtension item in LocalizeDictionary.Class89.smethod_3<LocExtension>())
		{
			SafeTargetInfo safeTargetInfo = item.safeTargetInfo_0;
			if (safeTargetInfo.TargetObjectReference.Target != null)
			{
				string text = smethod_2(safeTargetInfo.TargetProperty);
				if (safeTargetInfo.TargetObjectReference.Target == target && text == property && safeTargetInfo.TargetPropertyIndex == propertyIndex)
				{
					return item;
				}
			}
		}
		return null;
	}

	private static string smethod_2(object object_2)
	{
		string text = "";
		if (object_2 is PropertyInfo)
		{
			text = ((PropertyInfo)object_2).Name;
		}
		else if (object_2 is DependencyProperty)
		{
			text = ((DependencyProperty)object_2).Name;
		}
		if (text.Contains("FrameworkElementWidth5"))
		{
			text = "Height";
		}
		else if (text.Contains("FrameworkElementWidth6"))
		{
			text = "Width";
		}
		else if (text.Contains("FrameworkElementMargin12"))
		{
			text = "Margin";
		}
		return text;
	}

	public LocExtension()
	{
		OnFirstTarget = method_4;
	}

	public LocExtension(string key)
		: this()
	{
		Key = key;
	}

	public new void Dispose()
	{
		base.Dispose();
		LocalizeDictionary.Class89.smethod_2(this);
	}

	~LocExtension()
	{
		Dispose();
	}

	public void ResourceChanged(DependencyObject sender, DictionaryEventArgs e)
	{
		method_3(e);
		if (sender != null)
		{
			foreach (DependencyObject item in GetTargetPropertyPaths().Select(Class87.Class9.method_0))
			{
				if (LocalizeDictionary.Instance.DefaultProvider is InheritingResxLocalizationProvider)
				{
					UpdateNewValue();
					break;
				}
				DependencyObject dependencyObject = item;
				while (dependencyObject != null)
				{
					if (sender == dependencyObject)
					{
						UpdateNewValue();
						break;
					}
					if (!(dependencyObject is Visual) && !(dependencyObject is Visual3D) && !(dependencyObject is FrameworkContentElement))
					{
						UpdateNewValue();
						break;
					}
					try
					{
						DependencyObject dependencyObject2 = ((!(dependencyObject is FrameworkContentElement)) ? VisualTreeHelper.GetParent(dependencyObject) : ((FrameworkContentElement)dependencyObject).Parent);
						if (dependencyObject2 == null && dependencyObject is FrameworkElement)
						{
							dependencyObject2 = ((FrameworkElement)dependencyObject).Parent;
						}
						dependencyObject = dependencyObject2;
					}
					catch
					{
						UpdateNewValue();
						break;
					}
				}
			}
			return;
		}
		UpdateNewValue();
	}

	private void method_3(DictionaryEventArgs dictionaryEventArgs_0)
	{
		if (dictionaryEventArgs_0.Type != DictionaryEventType.ValueChanged || !(dictionaryEventArgs_0.Tag is ValueChangedEventArgs))
		{
			return;
		}
		ValueChangedEventArgs valueChangedEventArgs = (ValueChangedEventArgs)dictionaryEventArgs_0.Tag;
		new List<string>();
		CultureInfo cultureInfo = valueChangedEventArgs.Tag as CultureInfo;
		foreach (string item in dictionary_1.Keys.ToList())
		{
			if (item.EndsWith(valueChangedEventArgs.Key) && (cultureInfo == null || item.StartsWith(cultureInfo.Name)) && dictionary_1[item] != valueChangedEventArgs.Value)
			{
				smethod_1(item);
			}
		}
	}

	protected CultureInfo GetForcedCultureOrDefault()
	{
		if (!string.IsNullOrEmpty(ForceCulture))
		{
			try
			{
				return new CultureInfo(ForceCulture);
			}
			catch (ArgumentException innerException)
			{
				if (!LocalizeDictionary.Instance.GetIsInDesignMode())
				{
					throw new ArgumentException("Cannot create a CultureInfo with '" + ForceCulture + "'", innerException);
				}
				return LocalizeDictionary.Instance.SpecificCulture;
			}
		}
		return LocalizeDictionary.Instance.SpecificCulture;
	}

	public override object FormatOutput(TargetInfo endPoint, TargetInfo info)
	{
		object obj = null;
		if (endPoint == null)
		{
			return null;
		}
		safeTargetInfo_0 = SafeTargetInfo.FromTargetInfo(endPoint);
		DependencyObject target = endPoint.TargetObject as DependencyObject;
		Type type = info.TargetPropertyType;
		if (type.Equals(typeof(ImageSource)))
		{
			type = typeof(BitmapSource);
		}
		if (info.TargetPropertyIndex != -1 && typeof(IList).IsAssignableFrom(info.TargetPropertyType))
		{
			type = info.TargetPropertyType.GetGenericArguments()[0];
		}
		FullyQualifiedResourceKeyBase fullyQualifiedResourceKey = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(Key, target);
		CultureInfo forcedCultureOrDefault = GetForcedCultureOrDefault();
		string text = smethod_2(endPoint.TargetProperty);
		string text2 = "";
		if (endPoint.TargetObject is FrameworkElement)
		{
			text2 = (string)((FrameworkElement)endPoint.TargetObject).GetValue(FrameworkElement.NameProperty);
		}
		else if (endPoint.TargetObject is FrameworkContentElement)
		{
			text2 = (string)((FrameworkContentElement)endPoint.TargetObject).GetValue(FrameworkContentElement.NameProperty);
		}
		string text3 = forcedCultureOrDefault.Name + ":" + type.Name + ":";
		FullyQualifiedResourceKeyBase fullyQualifiedResourceKey2 = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(text2 + LocalizeDictionary.GetSeparation(target) + text, target);
		FullyQualifiedResourceKeyBase fullyQualifiedResourceKey3 = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(text2, target);
		object obj2 = null;
		bool flag = Converter is DefaultConverter;
		if (string.IsNullOrEmpty(fullyQualifiedResourceKey))
		{
			if (flag && dictionary_1.ContainsKey(text3 + fullyQualifiedResourceKey2))
			{
				obj = dictionary_1[text3 + fullyQualifiedResourceKey2];
			}
			else
			{
				obj2 = LocalizeDictionary.Instance.GetLocalizedObject(fullyQualifiedResourceKey2, target, forcedCultureOrDefault);
				if (obj2 == null)
				{
					if (flag && dictionary_1.ContainsKey(text3 + fullyQualifiedResourceKey3))
					{
						obj = dictionary_1[text3 + fullyQualifiedResourceKey3];
					}
					else
					{
						obj2 = LocalizeDictionary.Instance.GetLocalizedObject(fullyQualifiedResourceKey3, target, forcedCultureOrDefault);
						text3 += fullyQualifiedResourceKey3;
					}
				}
				else
				{
					text3 += fullyQualifiedResourceKey2;
				}
			}
		}
		else if (flag && dictionary_1.ContainsKey(text3 + fullyQualifiedResourceKey))
		{
			obj = dictionary_1[text3 + fullyQualifiedResourceKey];
		}
		else
		{
			obj2 = LocalizeDictionary.Instance.GetLocalizedObject(fullyQualifiedResourceKey, target, forcedCultureOrDefault);
			text3 += fullyQualifiedResourceKey;
		}
		if (obj == null)
		{
			if (obj2 != null)
			{
				obj = Converter.Convert(obj2, type, ConverterParameter, forcedCultureOrDefault);
				if (flag)
				{
					smethod_0(text3, obj);
				}
			}
			else
			{
				if (LocalizeDictionary.Instance.method_2(this, string_0))
				{
					UpdateNewValue();
				}
				if (!string.IsNullOrEmpty(string_0) && (type == typeof(string) || type == typeof(object)))
				{
					obj = "Key: " + string_0;
				}
			}
		}
		return obj;
	}

	protected override bool UpdateOnEndpoint(TargetInfo endpoint)
	{
		return true;
	}

	public static TValue GetLocalizedValue<TValue>(string key, IValueConverter converter = null, object converterParameter = null)
	{
		CultureInfo specificCulture = LocalizeDictionary.Instance.SpecificCulture;
		return GetLocalizedValue<TValue>(key, specificCulture, null, converter, converterParameter);
	}

	public static TValue GetLocalizedValue<TValue>(string key, CultureInfo targetCulture, IValueConverter converter = null, object converterParameter = null)
	{
		return GetLocalizedValue<TValue>(key, targetCulture, null, converter, converterParameter);
	}

	public static TValue GetLocalizedValue<TValue>(string key, DependencyObject target, IValueConverter converter = null, object converterParameter = null)
	{
		CultureInfo specificCulture = LocalizeDictionary.Instance.SpecificCulture;
		return GetLocalizedValue<TValue>(key, specificCulture, target, converter, converterParameter);
	}

	public static TValue GetLocalizedValue<TValue>(string key, CultureInfo targetCulture, DependencyObject target, IValueConverter converter = null, object converterParameter = null)
	{
		TValue val = default(TValue);
		FullyQualifiedResourceKeyBase fullyQualifiedResourceKey = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(key, target);
		string text = targetCulture.Name + ":" + typeof(TValue).Name + ":" + fullyQualifiedResourceKey;
		bool flag;
		if ((flag = converter is DefaultConverter) && dictionary_1.ContainsKey(text))
		{
			val = (TValue)dictionary_1[text];
		}
		else
		{
			object localizedObject = LocalizeDictionary.Instance.GetLocalizedObject(fullyQualifiedResourceKey, target, targetCulture);
			if (localizedObject == null)
			{
				return val;
			}
			if (converter == null)
			{
				converter = new DefaultConverter();
			}
			object obj = converter.Convert(localizedObject, typeof(TValue), converterParameter, targetCulture);
			if (obj is TValue)
			{
				val = (TValue)obj;
				if (flag)
				{
					smethod_0(text, val);
				}
			}
		}
		return val;
	}

	public bool ResolveLocalizedValue<TValue>(out TValue resolvedValue)
	{
		return ResolveLocalizedValue<TValue>(out resolvedValue, GetForcedCultureOrDefault(), null);
	}

	public bool ResolveLocalizedValue<TValue>(out TValue resolvedValue, DependencyObject target)
	{
		return ResolveLocalizedValue<TValue>(out resolvedValue, GetForcedCultureOrDefault(), target);
	}

	public bool ResolveLocalizedValue<TValue>(out TValue resolvedValue, CultureInfo targetCulture)
	{
		return ResolveLocalizedValue<TValue>(out resolvedValue, targetCulture, null);
	}

	public bool ResolveLocalizedValue<TValue>(out TValue resolvedValue, CultureInfo targetCulture, DependencyObject target)
	{
		resolvedValue = default(TValue);
		FullyQualifiedResourceKeyBase fullyQualifiedResourceKey = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(Key, target);
		string text = targetCulture.Name + ":" + typeof(TValue).Name + ":" + fullyQualifiedResourceKey;
		bool flag;
		if ((flag = Converter is DefaultConverter) && dictionary_1.ContainsKey(text))
		{
			resolvedValue = (TValue)dictionary_1[text];
		}
		else
		{
			object localizedObject = LocalizeDictionary.Instance.GetLocalizedObject(fullyQualifiedResourceKey, target, targetCulture);
			if (localizedObject == null)
			{
				return false;
			}
			object obj = Converter.Convert(localizedObject, typeof(TValue), ConverterParameter, targetCulture);
			if (obj is TValue)
			{
				resolvedValue = (TValue)obj;
				if (flag)
				{
					smethod_0(text, resolvedValue);
				}
			}
		}
		return resolvedValue != null;
	}

	public bool SetBinding(DependencyObject targetObject, object targetProperty)
	{
		return SetBinding(targetObject, targetProperty, -1);
	}

	public bool SetBinding(object targetObject, object targetProperty)
	{
		return SetBinding(targetObject, targetProperty, -1);
	}

	public bool SetBinding(DependencyObject targetObject, object targetProperty, int targetPropertyIndex)
	{
		return SetBinding(targetObject, targetProperty, targetPropertyIndex);
	}

	public bool SetBinding(object targetObject, object targetProperty, int targetPropertyIndex)
	{
		Class88 @class = new Class88();
		@class.object_0 = targetObject;
		@class.object_1 = targetProperty;
		if (GetTargetPropertyPaths().Where(@class.method_0).FirstOrDefault() == null)
		{
			Type targetPropertyType = null;
			if (!(@class.object_1 is DependencyProperty))
			{
				if (@class.object_1 is PropertyInfo)
				{
					targetPropertyType = ((PropertyInfo)@class.object_1).PropertyType;
				}
			}
			else
			{
				targetPropertyType = ((DependencyProperty)@class.object_1).PropertyType;
			}
			NestedMarkupExtension.SetPropertyValue(ProvideValue(new SimpleProvideValueServiceProvider(@class.object_0, @class.object_1, targetPropertyType, targetPropertyIndex)), new TargetInfo(@class.object_0, @class.object_1, targetPropertyType, targetPropertyIndex), forceNull: false);
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return "Loc:" + string_0;
	}

	private void method_4()
	{
		LocalizeDictionary.Class89.smethod_1(this);
	}
}
