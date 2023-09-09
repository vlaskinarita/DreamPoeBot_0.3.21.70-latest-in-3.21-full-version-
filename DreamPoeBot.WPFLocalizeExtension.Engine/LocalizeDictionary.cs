using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using DreamPoeBot.WPFLocalizeExtension.Extensions;
using DreamPoeBot.WPFLocalizeExtension.Providers;
using DreamPoeBot.XAMLMarkupExtensions.Base;

namespace DreamPoeBot.WPFLocalizeExtension.Engine;

internal sealed class LocalizeDictionary : DependencyObject, INotifyPropertyChanged
{
	internal static class Class89
	{
		[CompilerGenerated]
		private sealed class _003Csmethod_3_003Ed__3<T> : IEnumerable<T>, IEnumerator<T>, IDisposable, IEnumerator, IEnumerable
		{
			private int _003C_003E1__state;

			private T _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private object _003C_003E7__wrap1;

			private bool _003C_003E7__wrap2;

			private List<WeakReference>.Enumerator _003C_003E7__wrap3;

			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003Csmethod_3_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				_003C_003El__initialThreadId = smethod_0();
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = _003C_003E1__state;
				if ((uint)(num - -4) > 1u && num != 1)
				{
					return;
				}
				try
				{
					if (num != -4 && num != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						_003C_003Em__Finally2();
					}
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}

			private bool MoveNext()
			{
				try
				{
					switch (_003C_003E1__state)
					{
					case 1:
						_003C_003E1__state = -4;
						break;
					default:
						return false;
					case 0:
						_003C_003E1__state = -1;
						_003C_003E7__wrap1 = object_0;
						_003C_003E7__wrap2 = false;
						_003C_003E1__state = -3;
						smethod_1(_003C_003E7__wrap1, ref _003C_003E7__wrap2);
						_003C_003E7__wrap3 = list_0.ToList().GetEnumerator();
						_003C_003E1__state = -4;
						break;
					}
					while (_003C_003E7__wrap3.MoveNext())
					{
						WeakReference current = _003C_003E7__wrap3.Current;
						object obj = smethod_2(current);
						if (obj == null)
						{
							list_0.Remove(current);
						}
						else if (obj is T)
						{
							_003C_003E2__current = (T)obj;
							_003C_003E1__state = 1;
							return true;
						}
					}
					_003C_003Em__Finally2();
					_003C_003E7__wrap3 = default(List<WeakReference>.Enumerator);
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				if (_003C_003E7__wrap2)
				{
					smethod_3(_003C_003E7__wrap1);
				}
			}

			private void _003C_003Em__Finally2()
			{
				_003C_003E1__state = -3;
				((IDisposable)_003C_003E7__wrap3).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw smethod_4();
			}

			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == smethod_0())
				{
					_003C_003E1__state = 0;
					return this;
				}
				return new _003Csmethod_3_003Ed__3<T>(0);
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<T>)this).GetEnumerator();
			}

			static int smethod_0()
			{
				return Environment.CurrentManagedThreadId;
			}

			static void smethod_1(object object_0, ref bool bool_0)
			{
				Monitor.Enter(object_0, ref bool_0);
			}

			static object smethod_2(WeakReference weakReference_0)
			{
				return weakReference_0.Target;
			}

			static void smethod_3(object object_0)
			{
				Monitor.Exit(object_0);
			}

			static NotSupportedException smethod_4()
			{
				return new NotSupportedException();
			}
		}

		private static List<WeakReference> list_0 = new List<WeakReference>();

		private static object object_0 = new object();

		internal static void smethod_0(DependencyObject dependencyObject_0, DictionaryEventArgs dictionaryEventArgs_0)
		{
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target == null)
					{
						list_0.Remove(item);
					}
					else
					{
						((IDictionaryEventListener)target).ResourceChanged(dependencyObject_0, dictionaryEventArgs_0);
					}
				}
			}
		}

		internal static void smethod_1(IDictionaryEventListener idictionaryEventListener_0)
		{
			if (idictionaryEventListener_0 == null)
			{
				return;
			}
			bool flag = false;
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target != null)
					{
						if (target == idictionaryEventListener_0)
						{
							flag = true;
						}
					}
					else
					{
						list_0.Remove(item);
					}
				}
				if (!flag)
				{
					list_0.Add(new WeakReference(idictionaryEventListener_0));
				}
			}
		}

		internal static void smethod_2(IDictionaryEventListener idictionaryEventListener_0)
		{
			if (idictionaryEventListener_0 == null)
			{
				return;
			}
			object obj = object_0;
			lock (obj)
			{
				foreach (WeakReference item in list_0.ToList())
				{
					object target = item.Target;
					if (target != null)
					{
						if ((IDictionaryEventListener)target == idictionaryEventListener_0)
						{
							list_0.Remove(item);
						}
					}
					else
					{
						list_0.Remove(item);
					}
				}
			}
		}

		internal static IEnumerable<T> smethod_3<T>()
		{
			object obj = object_0;
			bool bool_ = false;
			try
			{
				_003Csmethod_3_003Ed__3<T>.smethod_1(obj, ref bool_);
				foreach (WeakReference item in list_0.ToList())
				{
					object obj2 = _003Csmethod_3_003Ed__3<T>.smethod_2(item);
					if (obj2 == null)
					{
						list_0.Remove(item);
					}
					else if (obj2 is T)
					{
						yield return (T)obj2;
					}
				}
			}
			finally
			{
				if (bool_)
				{
					_003Csmethod_3_003Ed__3<T>.smethod_3(obj);
				}
			}
		}
	}

	internal class Class91 : ICommand
	{
		private readonly Predicate<CultureInfo> predicate_0;

		private readonly Action<CultureInfo> action_0;

		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		public Class91(Action<CultureInfo> execute)
			: this(execute, null)
		{
		}

		public Class91(Action<CultureInfo> execute, Predicate<CultureInfo> canExecute)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			action_0 = execute;
			predicate_0 = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			if (predicate_0 != null)
			{
				return predicate_0((CultureInfo)parameter);
			}
			return true;
		}

		public void Execute(object parameter)
		{
			CultureInfo obj = new CultureInfo((string)parameter);
			action_0(obj);
		}
	}

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	public static readonly DependencyProperty DefaultProviderProperty = DependencyProperty.RegisterAttached("DefaultProvider", typeof(ILocalizationProvider), typeof(LocalizeDictionary), new PropertyMetadata(null, smethod_4));

	public static readonly DependencyProperty ProviderProperty = DependencyProperty.RegisterAttached("Provider", typeof(ILocalizationProvider), typeof(LocalizeDictionary), new PropertyMetadata(null, smethod_1));

	[DesignOnly(true)]
	public static readonly DependencyProperty DesignCultureProperty = DependencyProperty.RegisterAttached("DesignCulture", typeof(string), typeof(LocalizeDictionary), new PropertyMetadata(smethod_0));

	public static readonly DependencyProperty SeparationProperty = DependencyProperty.RegisterAttached("Separation", typeof(string), typeof(LocalizeDictionary), new PropertyMetadata(DefaultSeparation, smethod_5));

	public static readonly DependencyProperty IncludeInvariantCultureProperty = DependencyProperty.RegisterAttached("IncludeInvariantCulture", typeof(bool), typeof(LocalizeDictionary), new PropertyMetadata(true, smethod_6));

	public static readonly DependencyProperty DisableCacheProperty = DependencyProperty.RegisterAttached("DisableCache", typeof(bool), typeof(LocalizeDictionary), new PropertyMetadata(false, smethod_7));

	public static readonly DependencyProperty OutputMissingKeysProperty = DependencyProperty.RegisterAttached("OutputMissingKeys", typeof(bool), typeof(LocalizeDictionary), new PropertyMetadata(false, smethod_8));

	private static readonly object object_0 = new object();

	private static LocalizeDictionary localizeDictionary_0;

	private CultureInfo cultureInfo_0;

	private string string_0 = DefaultSeparation;

	private bool bool_0 = true;

	private bool bool_1 = true;

	private bool bool_2;

	private ILocalizationProvider ilocalizationProvider_0;

	private bool bool_3 = true;

	private Dictionary<DependencyObject, ParentChangedNotifier> dictionary_0 = new Dictionary<DependencyObject, ParentChangedNotifier>();

	private ObservableCollection<CultureInfo> observableCollection_0;

	private ICommand icommand_0;

	private EventHandler<MissingKeyEventArgs> eventHandler_0;

	public static string DefaultSeparation => "_";

	public static LocalizeDictionary Instance
	{
		get
		{
			if (localizeDictionary_0 == null)
			{
				object obj = object_0;
				lock (obj)
				{
					if (localizeDictionary_0 == null)
					{
						localizeDictionary_0 = new LocalizeDictionary();
					}
				}
			}
			return localizeDictionary_0;
		}
	}

	public static CultureInfo CurrentCulture => Instance.Culture;

	public CultureInfo Culture
	{
		get
		{
			if (cultureInfo_0 == null)
			{
				cultureInfo_0 = CultureInfo.InvariantCulture;
			}
			return cultureInfo_0;
		}
		set
		{
			if (value == null)
			{
				value = CultureInfo.InvariantCulture;
			}
			CultureInfo cultureInfo = value;
			if (!GetIsInDesignMode())
			{
				foreach (CultureInfo mergedAvailableCulture in MergedAvailableCultures)
				{
					if (mergedAvailableCulture == CultureInfo.InvariantCulture && !IncludeInvariantCulture)
					{
						continue;
					}
					if (!(mergedAvailableCulture.Name == value.Name))
					{
						if (!(mergedAvailableCulture.Parent.Name == value.Name))
						{
							if (value.Parent.Name == mergedAvailableCulture.Name)
							{
								cultureInfo = value;
							}
						}
						else
						{
							cultureInfo = mergedAvailableCulture;
						}
						continue;
					}
					cultureInfo = mergedAvailableCulture;
					break;
				}
			}
			if (cultureInfo_0 != cultureInfo)
			{
				if (cultureInfo != null && !MergedAvailableCultures.Contains(cultureInfo))
				{
					MergedAvailableCultures.Add(cultureInfo);
				}
				cultureInfo_0 = cultureInfo;
				if (bool_3 && !GetIsInDesignMode())
				{
					Thread.CurrentThread.CurrentCulture = cultureInfo_0;
					Thread.CurrentThread.CurrentUICulture = cultureInfo_0;
				}
				Class89.smethod_0(null, new DictionaryEventArgs(DictionaryEventType.CultureChanged, value));
				method_0("Culture");
			}
		}
	}

	public bool SetCurrentThreadCulture
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (bool_3 != value)
			{
				bool_3 = value;
				method_0("SetCurrentThreadCulture");
			}
		}
	}

	public bool IncludeInvariantCulture
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				CultureInfo invariantCulture = CultureInfo.InvariantCulture;
				bool flag = MergedAvailableCultures.Contains(invariantCulture);
				if (bool_0 && !flag)
				{
					MergedAvailableCultures.Insert(0, invariantCulture);
				}
				else if (!bool_0 && flag && MergedAvailableCultures.Count > 1)
				{
					MergedAvailableCultures.Remove(invariantCulture);
				}
			}
		}
	}

	public bool DisableCache
	{
		get
		{
			return bool_1;
		}
		set
		{
			if (bool_1 != value)
			{
				bool_1 = value;
			}
		}
	}

	public bool OutputMissingKeys
	{
		get
		{
			return bool_2;
		}
		set
		{
			if (bool_2 != value)
			{
				bool_2 = value;
			}
		}
	}

	public string Separation
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			Class89.smethod_0(null, new DictionaryEventArgs(DictionaryEventType.SeparationChanged, value));
		}
	}

	public ILocalizationProvider DefaultProvider
	{
		get
		{
			return ilocalizationProvider_0;
		}
		set
		{
			if (ilocalizationProvider_0 == value)
			{
				return;
			}
			if (ilocalizationProvider_0 != null)
			{
				ilocalizationProvider_0.ProviderChanged -= smethod_2;
				ilocalizationProvider_0.ValueChanged += smethod_3;
				ilocalizationProvider_0.AvailableCultures.CollectionChanged -= method_1;
			}
			ilocalizationProvider_0 = value;
			if (ilocalizationProvider_0 == null)
			{
				return;
			}
			ilocalizationProvider_0.ProviderChanged += smethod_2;
			ilocalizationProvider_0.ValueChanged += smethod_3;
			ilocalizationProvider_0.AvailableCultures.CollectionChanged += method_1;
			foreach (CultureInfo availableCulture in ilocalizationProvider_0.AvailableCultures)
			{
				if (!MergedAvailableCultures.Contains(availableCulture))
				{
					MergedAvailableCultures.Add(availableCulture);
				}
			}
		}
	}

	public ObservableCollection<CultureInfo> MergedAvailableCultures
	{
		get
		{
			if (observableCollection_0 == null)
			{
				observableCollection_0 = new ObservableCollection<CultureInfo>();
				observableCollection_0.Add(CultureInfo.InvariantCulture);
				observableCollection_0.CollectionChanged += observableCollection_0_CollectionChanged;
			}
			return observableCollection_0;
		}
	}

	public ICommand SetCultureCommand { get; private set; }

	public CultureInfo SpecificCulture => CultureInfo.CreateSpecificCulture(Culture.ToString());

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

	public event EventHandler<MissingKeyEventArgs> MissingKeyEvent
	{
		add
		{
			EventHandler<MissingKeyEventArgs> eventHandler = eventHandler_0;
			EventHandler<MissingKeyEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MissingKeyEventArgs> value2 = (EventHandler<MissingKeyEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<MissingKeyEventArgs> eventHandler = eventHandler_0;
			EventHandler<MissingKeyEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<MissingKeyEventArgs> value2 = (EventHandler<MissingKeyEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	internal void method_0(string string_1)
	{
		if (propertyChangedEventHandler_0 != null)
		{
			propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_1));
		}
	}

	[DesignOnly(true)]
	private static void smethod_0(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (!Instance.GetIsInDesignMode())
		{
			return;
		}
		CultureInfo cultureInfo;
		try
		{
			cultureInfo = new CultureInfo((string)dependencyPropertyChangedEventArgs_0.NewValue);
		}
		catch
		{
			if (!Instance.GetIsInDesignMode())
			{
				throw;
			}
			cultureInfo = CultureInfo.InvariantCulture;
		}
		if (cultureInfo != null)
		{
			Instance.Culture = cultureInfo;
		}
	}

	private static void smethod_1(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		Class89.smethod_0(dependencyObject_0, new DictionaryEventArgs(DictionaryEventType.ProviderChanged, dependencyPropertyChangedEventArgs_0.NewValue));
		if (dependencyPropertyChangedEventArgs_0.OldValue is ILocalizationProvider localizationProvider)
		{
			localizationProvider.ProviderChanged -= smethod_2;
			localizationProvider.ValueChanged -= smethod_3;
			localizationProvider.AvailableCultures.CollectionChanged -= Instance.method_1;
		}
		if (!(dependencyPropertyChangedEventArgs_0.NewValue is ILocalizationProvider localizationProvider2))
		{
			return;
		}
		localizationProvider2.ProviderChanged += smethod_2;
		localizationProvider2.ValueChanged += smethod_3;
		localizationProvider2.AvailableCultures.CollectionChanged += Instance.method_1;
		foreach (CultureInfo availableCulture in localizationProvider2.AvailableCultures)
		{
			if (!Instance.MergedAvailableCultures.Contains(availableCulture))
			{
				Instance.MergedAvailableCultures.Add(availableCulture);
			}
		}
	}

	private static void smethod_2(object sender, ProviderChangedEventArgs e)
	{
		Class89.smethod_0(e.Object, new DictionaryEventArgs(DictionaryEventType.ProviderUpdated, sender));
	}

	private static void smethod_3(object sender, ValueChangedEventArgs e)
	{
		Class89.smethod_0(null, new DictionaryEventArgs(DictionaryEventType.ValueChanged, e));
	}

	private static void smethod_4(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyPropertyChangedEventArgs_0.NewValue is ILocalizationProvider)
		{
			Instance.DefaultProvider = (ILocalizationProvider)dependencyPropertyChangedEventArgs_0.NewValue;
		}
	}

	private static void smethod_5(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
	}

	private static void smethod_6(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyPropertyChangedEventArgs_0.NewValue is bool)
		{
			Instance.IncludeInvariantCulture = (bool)dependencyPropertyChangedEventArgs_0.NewValue;
		}
	}

	private static void smethod_7(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyPropertyChangedEventArgs_0.NewValue is bool)
		{
			Instance.DisableCache = (bool)dependencyPropertyChangedEventArgs_0.NewValue;
		}
	}

	private static void smethod_8(DependencyObject dependencyObject_0, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs_0)
	{
		if (dependencyPropertyChangedEventArgs_0.NewValue is bool)
		{
			Instance.OutputMissingKeys = (bool)dependencyPropertyChangedEventArgs_0.NewValue;
		}
	}

	public static ILocalizationProvider GetProvider(DependencyObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		return (ILocalizationProvider)obj.GetValue(ProviderProperty);
	}

	public static ILocalizationProvider GetDefaultProvider(DependencyObject obj)
	{
		return Instance.DefaultProvider;
	}

	public static string GetSeparation(DependencyObject target)
	{
		return Instance.Separation;
	}

	public static bool GetIncludeInvariantCulture(DependencyObject target)
	{
		return Instance.IncludeInvariantCulture;
	}

	public static bool GetDisableCache(DependencyObject target)
	{
		return Instance.DisableCache;
	}

	public static bool GetOutputMissingKeys(DependencyObject target)
	{
		return Instance.OutputMissingKeys;
	}

	[DesignOnly(true)]
	public static string GetDesignCulture(DependencyObject obj)
	{
		if (Instance.GetIsInDesignMode())
		{
			return (string)obj.GetValue(DesignCultureProperty);
		}
		return Instance.Culture.ToString();
	}

	public static void SetProvider(DependencyObject obj, ILocalizationProvider value)
	{
		obj.SetValue(ProviderProperty, value);
	}

	public static void SetDefaultProvider(DependencyObject obj, ILocalizationProvider value)
	{
		Instance.DefaultProvider = value;
	}

	public static void SetSeparation(DependencyObject obj, string value)
	{
		Instance.Separation = value;
	}

	public static void SetIncludeInvariantCulture(DependencyObject obj, bool value)
	{
		Instance.IncludeInvariantCulture = value;
	}

	public static void SetDisableCache(DependencyObject obj, bool value)
	{
		Instance.DisableCache = value;
	}

	public static void SetOutputMissingKeys(DependencyObject obj, bool value)
	{
		Instance.OutputMissingKeys = value;
	}

	[DesignOnly(true)]
	public static void SetDesignCulture(DependencyObject obj, string value)
	{
		if (Instance.GetIsInDesignMode())
		{
			obj.SetValue(DesignCultureProperty, value);
		}
	}

	private LocalizeDictionary()
	{
		DefaultProvider = ResxLocalizationProvider.Instance;
		SetCultureCommand = new Class91(method_3);
	}

	private void method_1(object sender, NotifyCollectionChangedEventArgs e)
	{
		base.Dispatcher.BeginInvoke(new Action<NotifyCollectionChangedEventArgs>(method_4), e);
	}

	~LocalizeDictionary()
	{
		LocExtension.ClearResourceBuffer();
		FELoc.ClearResourceBuffer();
		BLoc.ClearResourceBuffer();
	}

	public object GetLocalizedObject(string source, string dictionary, string key, CultureInfo culture)
	{
		return GetLocalizedObject(source + ":" + dictionary + ":" + key, null, culture, DefaultProvider);
	}

	public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
	{
		if (DefaultProvider is InheritingResxLocalizationProvider)
		{
			return GetLocalizedObject(key, target, culture, DefaultProvider);
		}
		ILocalizationProvider localizationProvider = target?.GetValue(GetProvider);
		if (localizationProvider == null)
		{
			localizationProvider = DefaultProvider;
		}
		return GetLocalizedObject(key, target, culture, localizationProvider);
	}

	public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture, ILocalizationProvider provider)
	{
		if (provider == null)
		{
			throw new InvalidOperationException("No provider found and no default provider given.");
		}
		return provider.GetLocalizedObject(key, target, culture);
	}

	public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
	{
		if (DefaultProvider is InheritingResxLocalizationProvider)
		{
			return GetFullyQualifiedResourceKey(key, target, DefaultProvider);
		}
		ILocalizationProvider localizationProvider = target?.GetValue(GetProvider);
		if (localizationProvider == null)
		{
			localizationProvider = DefaultProvider;
		}
		return GetFullyQualifiedResourceKey(key, target, localizationProvider);
	}

	public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target, ILocalizationProvider provider)
	{
		if (provider == null)
		{
			throw new InvalidOperationException("No provider found and no default provider given.");
		}
		return provider.GetFullyQualifiedResourceKey(key, target);
	}

	public bool ResourceKeyExists(string resourceAssembly, string resourceDictionary, string resourceKey)
	{
		return ResourceKeyExists(resourceAssembly, resourceDictionary, resourceKey, CultureInfo.InvariantCulture);
	}

	public bool ResourceKeyExists(string resourceAssembly, string resourceDictionary, string resourceKey, CultureInfo cultureToUse)
	{
		ResxLocalizationProvider instance = ResxLocalizationProvider.Instance;
		return ResourceKeyExists(resourceAssembly + ":" + resourceDictionary + ":" + resourceKey, cultureToUse, instance);
	}

	public bool ResourceKeyExists(string key, CultureInfo cultureToUse, ILocalizationProvider provider)
	{
		return provider.GetLocalizedObject(key, null, cultureToUse) != null;
	}

	public bool GetIsInDesignMode()
	{
		if (base.Dispatcher != null && base.Dispatcher.Thread != null && base.Dispatcher.Thread.IsAlive)
		{
			if (base.Dispatcher.CheckAccess())
			{
				return DesignerProperties.GetIsInDesignMode(this);
			}
			return base.Dispatcher.Invoke((Func<bool>)GetIsInDesignMode);
		}
		return false;
	}

	internal bool method_2(object object_1, string string_1)
	{
		MissingKeyEventArgs missingKeyEventArgs = new MissingKeyEventArgs(string_1);
		if (eventHandler_0 != null)
		{
			eventHandler_0(object_1, missingKeyEventArgs);
		}
		return missingKeyEventArgs.Reload;
	}

	private void method_3(CultureInfo cultureInfo_1)
	{
		Culture = cultureInfo_1;
	}

	private void method_4(NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_0)
	{
		if (notifyCollectionChangedEventArgs_0.NewItems != null)
		{
			foreach (object newItem in notifyCollectionChangedEventArgs_0.NewItems)
			{
				CultureInfo item = (CultureInfo)newItem;
				if (!MergedAvailableCultures.Contains(item))
				{
					MergedAvailableCultures.Add(item);
				}
			}
		}
		if (notifyCollectionChangedEventArgs_0.OldItems != null)
		{
			foreach (object oldItem in notifyCollectionChangedEventArgs_0.OldItems)
			{
				CultureInfo item2 = (CultureInfo)oldItem;
				if (MergedAvailableCultures.Contains(item2))
				{
					MergedAvailableCultures.Remove(item2);
				}
			}
		}
		if (!bool_0 && MergedAvailableCultures.Count > 1 && MergedAvailableCultures.Contains(CultureInfo.InvariantCulture))
		{
			MergedAvailableCultures.Remove(CultureInfo.InvariantCulture);
		}
	}

	private void observableCollection_0_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		Culture = Culture;
	}
}
