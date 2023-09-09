using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using DreamPoeBot.WPFLocalizeExtension.Engine;

namespace DreamPoeBot.WPFLocalizeExtension.Extensions;

internal class BLoc : Binding, IDisposable, INotifyPropertyChanged, IDictionaryEventListener
{
	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private static object object_0 = new object();

	private static Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

	private object object_1;

	private string string_0;

	public object Value
	{
		get
		{
			return object_1;
		}
		set
		{
			if (object_1 != value)
			{
				object_1 = value;
				method_0("Value");
			}
		}
	}

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
				method_1();
				method_0("Key");
			}
		}
	}

	public string ForceCulture { get; set; }

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

	internal void method_0(string string_2)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_2));
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

	internal static void smethod_0(string string_2, object object_2)
	{
		object obj = object_0;
		lock (obj)
		{
			if (!LocalizeDictionary.Instance.DisableCache && !dictionary_0.ContainsKey(string_2))
			{
				dictionary_0.Add(string_2, object_2);
			}
		}
	}

	internal static void smethod_1(string string_2)
	{
		object obj = object_0;
		lock (obj)
		{
			if (dictionary_0.ContainsKey(string_2))
			{
				dictionary_0.Remove(string_2);
			}
		}
	}

	public BLoc()
	{
		LocalizeDictionary.Class89.smethod_1(this);
		base.Path = new PropertyPath("Value");
		base.Source = this;
	}

	public BLoc(string key)
		: this()
	{
		Key = key;
	}

	public void Dispose()
	{
		LocalizeDictionary.Class89.smethod_2(this);
	}

	~BLoc()
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
		method_1();
	}

	private void method_1()
	{
		Value = FormatOutput();
	}

	public object FormatOutput()
	{
		string text = LocalizeDictionary.Instance.GetFullyQualifiedResourceKey(Key, null);
		CultureInfo forcedCultureOrDefault = GetForcedCultureOrDefault();
		string text2 = forcedCultureOrDefault.Name + ":";
		object obj;
		if (!dictionary_0.ContainsKey(text2 + text))
		{
			obj = LocalizeDictionary.Instance.GetLocalizedObject(text, null, forcedCultureOrDefault);
			if (obj == null)
			{
				return null;
			}
			text2 += text;
			smethod_0(text2, obj);
		}
		else
		{
			obj = dictionary_0[text2 + text];
		}
		return obj;
	}
}
