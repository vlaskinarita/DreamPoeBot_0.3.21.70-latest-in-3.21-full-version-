using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup.Primitives;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DreamPoeBot.WPFLocalizeExtension.Engine;
using DreamPoeBot.WPFLocalizeExtension.TypeConverters;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Extensions;

internal class FELoc : FrameworkElement, IDisposable, INotifyPropertyChanged, IDictionaryEventListener
{
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private static object object_0 = new object();

	private static Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

	private ParentChangedNotifier parentChangedNotifier_0;

	private TargetInfo targetInfo_0;

	public static readonly DependencyProperty KeyProperty = DependencyProperty.Register("Key", typeof(string), typeof(FELoc), new PropertyMetadata(null, smethod_2));

	public static readonly DependencyProperty ConverterProperty = DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(FELoc), new PropertyMetadata(new DefaultConverter(), smethod_2));

	public static readonly DependencyProperty ConverterParameterProperty = DependencyProperty.Register("ConverterParameter", typeof(object), typeof(FELoc), new PropertyMetadata(null, smethod_2));

	public static readonly DependencyProperty ForceCultureProperty = DependencyProperty.Register("ForceCulture", typeof(string), typeof(FELoc), new PropertyMetadata(null, smethod_2));

	private object object_1;

	public string Key
	{
		get
		{
			return GetValue(KeyProperty) as string;
		}
		set
		{
			SetValue(KeyProperty, value);
		}
	}

	public IValueConverter Converter
	{
		get
		{
			return GetValue(ConverterProperty) as IValueConverter;
		}
		set
		{
			SetValue(ConverterProperty, value);
		}
	}

	public object ConverterParameter
	{
		get
		{
			return GetValue(ConverterParameterProperty);
		}
		set
		{
			SetValue(ConverterParameterProperty, value);
		}
	}

	public string ForceCulture
	{
		get
		{
			return GetValue(ForceCultureProperty) as string;
		}
		set
		{
			SetValue(ForceCultureProperty, value);
		}
	}

	public object Content
	{
		get
		{
			return object_1;
		}
		set
		{
			object_1 = value;
			method_0("Content");
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

	internal void method_0(string string_0)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
		}
	}

	public static void ClearResourceBuffer()
	{
		object obj = object_0;
		lock (obj)
		{
			if (dictionary_0 != null)
			{
				dictionary_0.Clear();
			}
		}
		dictionary_0 = null;
	}

	internal static void smethod_0(string string_0, object object_2)
	{
		object obj = object_0;
		lock (obj)
		{
			if (!LocalizeDictionary.Instance.DisableCache && !dictionary_0.ContainsKey(string_0))
			{
				dictionary_0.Add(string_0, object_2);
			}
		}
	}

	internal static void smethod_1(string string_0)
	{
		object obj = object_0;
		lock (obj)
		{
			if (dictionary_0.ContainsKey(string_0))
			{
				dictionary_0.Remove(string_0);
			}
		}
	}

	private static void smethod_2(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyObject_0 is FELoc fELoc)
		{
			fELoc.method_4();
		}
	}

	private IList<DependencyProperty> method_1(DependencyObject dependencyObject_0)
	{
		List<DependencyProperty> list = new List<DependencyProperty>();
		foreach (object property in TypeDescriptor.GetProperties(dependencyObject_0, new Attribute[1]
		{
			new PropertyFilterAttribute(PropertyFilterOptions.All)
		}))
		{
			DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty((PropertyDescriptor)property);
			if (dependencyPropertyDescriptor != null && dependencyPropertyDescriptor.IsAttached)
			{
				list.Add(dependencyPropertyDescriptor.DependencyProperty);
			}
		}
		return list;
	}

	private List<DependencyProperty> method_2(object object_2)
	{
		List<DependencyProperty> list = new List<DependencyProperty>();
		MarkupObject markupObjectFor = MarkupWriter.GetMarkupObjectFor(object_2);
		if (markupObjectFor != null)
		{
			foreach (MarkupProperty property in markupObjectFor.Properties)
			{
				if (property.DependencyProperty != null)
				{
					list.Add(property.DependencyProperty);
				}
			}
			return list;
		}
		return list;
	}

	private void method_3()
	{
		parentChangedNotifier_0 = new ParentChangedNotifier(this, method_5);
	}

	public FELoc()
	{
		LocalizeDictionary.Class89.smethod_1(this);
		method_3();
	}

	public FELoc(string key)
		: this()
	{
		Key = key;
	}

	public void Dispose()
	{
		LocalizeDictionary.Class89.smethod_2(this);
	}

	~FELoc()
	{
		Dispose();
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

	public void ResourceChanged(DependencyObject sender, DictionaryEventArgs e)
	{
		method_4();
	}

	private void method_4()
	{
		Content = FormatOutput();
	}

	public object FormatOutput()
	{
		object obj = null;
		if (targetInfo_0 == null)
		{
			return null;
		}
		DependencyObject dependencyObject = targetInfo_0.TargetObject as DependencyObject;
		Type type = targetInfo_0.TargetPropertyType;
		if (type.Equals(typeof(ImageSource)))
		{
			type = typeof(BitmapSource);
		}
		string text = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(Key, dependencyObject);
		CultureInfo forcedCultureOrDefault = GetForcedCultureOrDefault();
		string text2 = "";
		string text3 = "";
		if (dependencyObject is FrameworkElement)
		{
			text2 = (string)((FrameworkElement)dependencyObject).GetValue(FrameworkElement.NameProperty);
		}
		else if (dependencyObject is FrameworkContentElement)
		{
			text2 = (string)((FrameworkContentElement)dependencyObject).GetValue(FrameworkContentElement.NameProperty);
		}
		if (targetInfo_0.TargetProperty is PropertyInfo)
		{
			text3 = ((PropertyInfo)targetInfo_0.TargetProperty).Name;
		}
		else if (targetInfo_0.TargetProperty is DependencyProperty)
		{
			text3 = ((DependencyProperty)targetInfo_0.TargetProperty).Name;
		}
		if (!text3.Contains("FrameworkElementWidth5"))
		{
			if (!text3.Contains("FrameworkElementWidth6"))
			{
				if (text3.Contains("FrameworkElementMargin12"))
				{
					text3 = "Margin";
				}
			}
			else
			{
				text3 = "Width";
			}
		}
		else
		{
			text3 = "Height";
		}
		string text4 = forcedCultureOrDefault.Name + ":" + type.Name + ":";
		string text5 = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(text2 + LocalizeDictionary.GetSeparation(dependencyObject) + text3, dependencyObject);
		string text6 = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(text2, dependencyObject);
		object obj2 = null;
		if (string.IsNullOrEmpty(text))
		{
			if (!dictionary_0.ContainsKey(text4 + text5))
			{
				obj2 = LocalizeDictionary.Instance.GetLocalizedObject(text5, dependencyObject, forcedCultureOrDefault);
				if (obj2 != null)
				{
					text4 += text5;
				}
				else if (dictionary_0.ContainsKey(text4 + text6))
				{
					obj = dictionary_0[text4 + text6];
				}
				else
				{
					obj2 = LocalizeDictionary.Instance.GetLocalizedObject(text6, dependencyObject, forcedCultureOrDefault);
					text4 += text6;
				}
			}
			else
			{
				obj = dictionary_0[text4 + text5];
			}
		}
		else if (!dictionary_0.ContainsKey(text4 + text))
		{
			obj2 = LocalizeDictionary.Instance.GetLocalizedObject(text, dependencyObject, forcedCultureOrDefault);
			text4 += text;
		}
		else
		{
			obj = dictionary_0[text4 + text];
		}
		if (obj == null && obj2 != null)
		{
			obj = Converter.Convert(obj2, type, ConverterParameter, forcedCultureOrDefault);
			smethod_0(text4, obj);
		}
		return obj;
	}

	private void method_5()
	{
		parentChangedNotifier_0.Dispose();
		parentChangedNotifier_0 = null;
		DependencyObject parent = base.Parent;
		if (parent == null)
		{
			return;
		}
		foreach (DependencyProperty item in method_2(parent))
		{
			if (parent.GetValue(item) == this)
			{
				targetInfo_0 = new TargetInfo(parent, item, item.PropertyType, -1);
				BindingOperations.SetBinding(parent, item, new Binding("Content")
				{
					Source = this,
					Converter = Converter,
					ConverterParameter = ConverterParameter,
					Mode = BindingMode.OneWay
				});
				method_4();
			}
		}
	}
}
