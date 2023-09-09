using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal abstract class CSVLocalizationProviderBase : DependencyObject, ILocalizationProvider
{
	private const string string_0 = "ResourceManager";

	private const string string_1 = ".resources";

	private const BindingFlags bindingFlags_0 = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	protected Dictionary<string, ResourceManager> ResourceManagerList;

	protected object ResourceManagerListLock = new object();

	protected object AvailableCultureListLock = new object();

	[CompilerGenerated]
	private ProviderChangedEventHandler providerChangedEventHandler_0;

	[CompilerGenerated]
	private ProviderErrorEventHandler providerErrorEventHandler_0;

	[CompilerGenerated]
	private ValueChangedEventHandler valueChangedEventHandler_0;

	[CompilerGenerated]
	private ObservableCollection<CultureInfo> observableCollection_0;

	public ObservableCollection<CultureInfo> AvailableCultures { get; protected set; }

	public event ProviderChangedEventHandler ProviderChanged
	{
		[CompilerGenerated]
		add
		{
			ProviderChangedEventHandler providerChangedEventHandler = providerChangedEventHandler_0;
			ProviderChangedEventHandler providerChangedEventHandler2;
			do
			{
				providerChangedEventHandler2 = providerChangedEventHandler;
				ProviderChangedEventHandler value2 = (ProviderChangedEventHandler)Delegate.Combine(providerChangedEventHandler2, value);
				providerChangedEventHandler = Interlocked.CompareExchange(ref providerChangedEventHandler_0, value2, providerChangedEventHandler2);
			}
			while (providerChangedEventHandler != providerChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ProviderChangedEventHandler providerChangedEventHandler = providerChangedEventHandler_0;
			ProviderChangedEventHandler providerChangedEventHandler2;
			do
			{
				providerChangedEventHandler2 = providerChangedEventHandler;
				ProviderChangedEventHandler value2 = (ProviderChangedEventHandler)Delegate.Remove(providerChangedEventHandler2, value);
				providerChangedEventHandler = Interlocked.CompareExchange(ref providerChangedEventHandler_0, value2, providerChangedEventHandler2);
			}
			while (providerChangedEventHandler != providerChangedEventHandler2);
		}
	}

	public event ProviderErrorEventHandler ProviderError
	{
		[CompilerGenerated]
		add
		{
			ProviderErrorEventHandler providerErrorEventHandler = providerErrorEventHandler_0;
			ProviderErrorEventHandler providerErrorEventHandler2;
			do
			{
				providerErrorEventHandler2 = providerErrorEventHandler;
				ProviderErrorEventHandler value2 = (ProviderErrorEventHandler)Delegate.Combine(providerErrorEventHandler2, value);
				providerErrorEventHandler = Interlocked.CompareExchange(ref providerErrorEventHandler_0, value2, providerErrorEventHandler2);
			}
			while (providerErrorEventHandler != providerErrorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ProviderErrorEventHandler providerErrorEventHandler = providerErrorEventHandler_0;
			ProviderErrorEventHandler providerErrorEventHandler2;
			do
			{
				providerErrorEventHandler2 = providerErrorEventHandler;
				ProviderErrorEventHandler value2 = (ProviderErrorEventHandler)Delegate.Remove(providerErrorEventHandler2, value);
				providerErrorEventHandler = Interlocked.CompareExchange(ref providerErrorEventHandler_0, value2, providerErrorEventHandler2);
			}
			while (providerErrorEventHandler != providerErrorEventHandler2);
		}
	}

	public event ValueChangedEventHandler ValueChanged
	{
		[CompilerGenerated]
		add
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Combine(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while (valueChangedEventHandler != valueChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValueChangedEventHandler valueChangedEventHandler = valueChangedEventHandler_0;
			ValueChangedEventHandler valueChangedEventHandler2;
			do
			{
				valueChangedEventHandler2 = valueChangedEventHandler;
				ValueChangedEventHandler value2 = (ValueChangedEventHandler)Delegate.Remove(valueChangedEventHandler2, value);
				valueChangedEventHandler = Interlocked.CompareExchange(ref valueChangedEventHandler_0, value2, valueChangedEventHandler2);
			}
			while (valueChangedEventHandler != valueChangedEventHandler2);
		}
	}

	protected string GetAssemblyName(Assembly assembly)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		if (assembly.FullName == null)
		{
			throw new NullReferenceException("assembly.FullName is null");
		}
		return assembly.FullName.Split(',')[0];
	}

	public static void ParseKey(string inKey, out string outAssembly, out string outDict, out string outKey)
	{
		outAssembly = null;
		outDict = null;
		outKey = null;
		if (!string.IsNullOrEmpty(inKey))
		{
			string[] array = inKey.Trim().Split(":".ToCharArray());
			if (array.Length == 3)
			{
				outAssembly = ((!string.IsNullOrEmpty(array[0])) ? array[0] : null);
				outDict = ((!string.IsNullOrEmpty(array[1])) ? array[1] : null);
				outKey = array[2];
			}
			if (array.Length == 2)
			{
				outDict = ((!string.IsNullOrEmpty(array[0])) ? array[0] : null);
				outKey = array[1];
			}
			if (array.Length == 1)
			{
				outKey = array[0];
			}
		}
	}

	protected abstract string GetAssembly(DependencyObject target);

	protected abstract string GetDictionary(DependencyObject target);

	protected void AddCulture(CultureInfo c)
	{
		object availableCultureListLock = AvailableCultureListLock;
		lock (availableCultureListLock)
		{
			if (!AvailableCultures.Contains(c))
			{
				AvailableCultures.Add(c);
			}
		}
	}

	public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		ParseKey(key, out var outAssembly, out var outDict, out key);
		if (target == null)
		{
			return new FQAssemblyDictionaryKey(key, outAssembly, outDict);
		}
		if (string.IsNullOrEmpty(outAssembly))
		{
			outAssembly = GetAssembly(target);
		}
		if (string.IsNullOrEmpty(outDict))
		{
			outDict = GetDictionary(target);
		}
		return new FQAssemblyDictionaryKey(key, outAssembly, outDict);
	}

	protected virtual void OnProviderChanged(DependencyObject target)
	{
		try
		{
			GetAssembly(target);
			GetDictionary(target);
		}
		catch
		{
		}
		if (providerChangedEventHandler_0 != null)
		{
			providerChangedEventHandler_0(this, new ProviderChangedEventArgs(target));
		}
	}

	protected virtual void OnProviderError(DependencyObject target, string key, string message)
	{
		if (providerErrorEventHandler_0 != null)
		{
			providerErrorEventHandler_0(this, new ProviderErrorEventArgs(target, key, message));
		}
	}

	protected virtual void OnValueChanged(string key, object value, object tag)
	{
		if (valueChangedEventHandler_0 != null)
		{
			valueChangedEventHandler_0(this, new ValueChangedEventArgs(key, value, tag));
		}
	}

	public virtual object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
	{
		throw new InvalidOperationException("GetLocalizedObject needs to be overriden");
	}
}
