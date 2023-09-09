using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows;

namespace DreamPoeBot.WPFLocalizeExtension.Providers;

internal abstract class ResxLocalizationProviderBase : DependencyObject, ILocalizationProvider
{
	private sealed class Class78
	{
		public int int_0;

		internal bool method_0(Class69<Process, ManagementObject> class69_0)
		{
			return class69_0.p.Id == int_0;
		}
	}

	[Serializable]
	private sealed class Class79
	{
		public static readonly Class79 Class9 = new Class79();

		internal int method_0(Process process_0)
		{
			return process_0.Id;
		}

		internal int method_1(ManagementObject managementObject_0)
		{
			return (int)(uint)managementObject_0["ProcessId"];
		}

		internal Class69<Process, ManagementObject> method_2(Process process_0, ManagementObject managementObject_0)
		{
			return new Class69<Process, ManagementObject>(process_0, managementObject_0);
		}

		internal Class70<Process, string, string> method_3(Class69<Process, ManagementObject> class69_0)
		{
			return new Class70<Process, string, string>(class69_0.p, (string)class69_0.mo["ExecutablePath"], (string)class69_0.mo["CommandLine"]);
		}

		internal bool method_4(Type type_0)
		{
			return type_0 != null;
		}

		internal string method_5(Type type_0)
		{
			try
			{
				return type_0.Namespace;
			}
			catch (Exception)
			{
				return null;
			}
		}

		internal bool method_6(string string_0)
		{
			return string_0 != null;
		}
	}

	private sealed class Class80
	{
		public string string_0;

		public ResxLocalizationProviderBase resxLocalizationProviderBase_0;

		internal bool method_0(string string_1)
		{
			return resxLocalizationProviderBase_0.method_0(string_1, string_0);
		}
	}

	private sealed class Class81
	{
		public string string_0;

		internal bool method_0(string string_1)
		{
			return string_0.StartsWith(string_1 + ".");
		}
	}

	private sealed class Class82
	{
		public string string_0;

		internal bool method_0(Type type_0)
		{
			try
			{
				return type_0.Name == string_0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}

	private const string string_0 = "ResourceManager";

	private const string string_1 = ".resources";

	private const BindingFlags bindingFlags_0 = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	protected Dictionary<string, ResourceManager> ResourceManagerList;

	protected object ResourceManagerListLock = new object();

	protected object AvailableCultureListLock = new object();

	private static Dictionary<int, string> dictionary_0 = new Dictionary<int, string>();

	private DateTime dateTime_0 = DateTime.MinValue;

	private ProviderChangedEventHandler providerChangedEventHandler_0;

	private ProviderErrorEventHandler providerErrorEventHandler_0;

	private ValueChangedEventHandler valueChangedEventHandler_0;

	private ObservableCollection<CultureInfo> observableCollection_0;

	public ObservableCollection<CultureInfo> AvailableCultures { get; protected set; }

	public event ProviderChangedEventHandler ProviderChanged
	{
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

	protected bool TryGetValue(string thekey, out ResourceManager result)
	{
		object resourceManagerListLock = ResourceManagerListLock;
		lock (resourceManagerListLock)
		{
			return ResourceManagerList.TryGetValue(thekey, out result);
		}
	}

	protected void Add(string thekey, ResourceManager value)
	{
		object resourceManagerListLock = ResourceManagerListLock;
		lock (resourceManagerListLock)
		{
			ResourceManagerList.Add(thekey, value);
		}
	}

	protected void TryRemove(string thekey)
	{
		object resourceManagerListLock = ResourceManagerListLock;
		lock (resourceManagerListLock)
		{
			if (ResourceManagerList.ContainsKey(thekey))
			{
				ResourceManagerList.Remove(thekey);
			}
		}
	}

	public void ClearResourceManagerList()
	{
		object resourceManagerListLock = ResourceManagerListLock;
		lock (resourceManagerListLock)
		{
			ResourceManagerList.Clear();
		}
	}

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

	public bool UpdateCultureList(string resourceAssembly, string resourceDictionary)
	{
		return GetResourceManager(resourceAssembly, resourceDictionary) != null;
	}

	private static string smethod_0(int int_0)
	{
		Class78 @class = new Class78();
		@class.int_0 = int_0;
		if (dictionary_0.ContainsKey(@class.int_0))
		{
			return dictionary_0[@class.int_0];
		}
		using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process"))
		{
			using ManagementObjectCollection source = managementObjectSearcher.Get();
			using IEnumerator<Class70<Process, string, string>> enumerator = Process.GetProcesses().Join(source.Cast<ManagementObject>(), Class79.Class9.method_0, Class79.Class9.method_1, Class79.Class9.method_2).Where(@class.method_0)
				.Select(Class79.Class9.method_3)
				.GetEnumerator();
			if (enumerator.MoveNext())
			{
				Class70<Process, string, string> current = enumerator.Current;
				dictionary_0.Add(@class.int_0, current.Path);
				return current.Path;
			}
		}
		return null;
	}

	private bool method_0(string string_2, string string_3)
	{
		if (!string.IsNullOrEmpty(string_2))
		{
			if (!string_2.EndsWith(".resx", StringComparison.OrdinalIgnoreCase) && !string_2.EndsWith(".resources.dll", StringComparison.OrdinalIgnoreCase) && !string_2.EndsWith(".resources", StringComparison.OrdinalIgnoreCase))
			{
				return string_3.Equals(Path.GetDirectoryName(string_2), StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	protected ResourceManager GetResourceManager(string resourceAssembly, string resourceDictionary)
	{
		Assembly assembly = null;
		string text = null;
		string text2 = "." + resourceDictionary + ".resources";
		string thekey = resourceAssembly + text2;
		DateTime now = DateTime.Now;
		if (AppDomain.CurrentDomain.FriendlyName.Contains("XDesProc") && (now - dateTime_0).TotalSeconds >= 1.0)
		{
			dateTime_0 = now;
			string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "tmp");
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				Class80 @class = new Class80();
				@class.resxLocalizationProviderBase_0 = this;
				if (!process.ProcessName.Contains(".vshost"))
				{
					continue;
				}
				@class.string_0 = Path.GetDirectoryName(smethod_0(process.Id));
				if (string.IsNullOrEmpty(@class.string_0) || Directory.GetFiles(@class.string_0, resourceAssembly + ".*", SearchOption.AllDirectories).Length == 0)
				{
					continue;
				}
				string[] array = Directory.GetFiles(@class.string_0, "*.*", SearchOption.AllDirectories).Where(@class.method_0).ToArray();
				TryRemove(thekey);
				string[] array2 = array;
				foreach (string text3 in array2)
				{
					try
					{
						string text4 = Path.Combine(path, text3.Replace(@class.string_0 + "\\", ""));
						if (File.Exists(text4) && !(Directory.GetLastWriteTime(text4) < Directory.GetLastWriteTime(text3)))
						{
							continue;
						}
						string directoryName = Path.GetDirectoryName(text4);
						if (!string.IsNullOrEmpty(directoryName))
						{
							if (!Directory.Exists(directoryName))
							{
								Directory.CreateDirectory(directoryName);
							}
							File.Copy(text3, text4, overwrite: true);
						}
					}
					catch
					{
					}
				}
				string text5 = Path.Combine(path, resourceAssembly + ".exe");
				if (!File.Exists(text5))
				{
					text5 = Path.Combine(path, resourceAssembly + ".dll");
				}
				assembly = Assembly.LoadFrom(text5);
				break;
			}
		}
		if (!TryGetValue(thekey, out var result))
		{
			if (assembly == null)
			{
				try
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					int num = 0;
					while (true)
					{
						if (num < assemblies.Length)
						{
							Assembly assembly2 = assemblies[num];
							if (!(new AssemblyName(assembly2.FullName).Name == resourceAssembly))
							{
								num++;
								continue;
							}
							assembly = assembly2;
							if (assembly == null)
							{
								assembly = Assembly.Load(new AssemblyName(resourceAssembly));
							}
							break;
						}
						if (assembly == null)
						{
							assembly = Assembly.Load(new AssemblyName(resourceAssembly));
						}
						break;
					}
				}
				catch (Exception innerException)
				{
					throw new Exception($"The Assembly '{resourceAssembly}' cannot be loaded.", innerException);
				}
			}
			string[] manifestResourceNames = assembly.GetManifestResourceNames();
			IEnumerable<Type> source;
			try
			{
				source = assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException ex)
			{
				source = ex.Types.Where(Class79.Class9.method_4);
			}
			Func<Type, string> selector = Class79.Class9.method_5;
			List<string> source2 = source.Select(selector).Where(Class79.Class9.method_6).Distinct()
				.ToList();
			string[] array3 = manifestResourceNames;
			for (int k = 0; k < array3.Length; k++)
			{
				Class81 class2 = new Class81();
				class2.string_0 = array3[k];
				if (!class2.string_0.EndsWith(text2) || !source2.Any(class2.method_0))
				{
					continue;
				}
				text = class2.string_0;
				if (text != null)
				{
					text = text.Substring(0, text.Length - ".resources".Length);
					Type type;
					try
					{
						type = assembly.GetType(text);
					}
					catch (Exception)
					{
						type = null;
					}
					if (type == null)
					{
						Class82 class3 = new Class82();
						class3.string_0 = resourceDictionary.Replace('.', '_');
						Func<Type, bool> predicate = class3.method_0;
						type = source.FirstOrDefault(predicate);
					}
					result = method_1(type);
				}
				else
				{
					result = new ResourceManager(text2, assembly);
				}
				if (result == null)
				{
					throw new ArgumentException(string.Format("No resource manager for dictionary '{0}' in assembly '{1}' found! ({1}.{0})", resourceDictionary, resourceAssembly));
				}
				Add(thekey, result);
				try
				{
					Path.GetDirectoryName(assembly.Location);
					CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
					foreach (CultureInfo cultureInfo in cultures)
					{
						if (result.GetResourceSet(cultureInfo, createIfNotExists: true, tryParents: false) != null)
						{
							AddCulture(cultureInfo);
						}
					}
					return result;
				}
				catch
				{
					return result;
				}
			}
		}
		return result;
	}

	private ResourceManager method_1(Type type_0)
	{
		if (type_0 == null)
		{
			return null;
		}
		try
		{
			return (ResourceManager)type_0.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).GetGetMethod(nonPublic: true).Invoke(null, null);
		}
		catch
		{
			return null;
		}
	}

	public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
	{
		if (string.IsNullOrEmpty(key))
		{
			return null;
		}
		ParseKey(key, out var outAssembly, out var outDict, out key);
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
			string assembly = GetAssembly(target);
			string dictionary = GetDictionary(target);
			if (!string.IsNullOrEmpty(assembly) && !string.IsNullOrEmpty(dictionary))
			{
				GetResourceManager(assembly, dictionary);
			}
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
		ParseKey(key, out var outAssembly, out var outDict, out key);
		if (string.IsNullOrEmpty(outAssembly))
		{
			outAssembly = GetAssembly(target);
		}
		if (string.IsNullOrEmpty(outDict))
		{
			outDict = GetDictionary(target);
		}
		if (!string.IsNullOrEmpty(outAssembly))
		{
			if (!string.IsNullOrEmpty(outDict))
			{
				if (!string.IsNullOrEmpty(key))
				{
					ResourceManager resourceManager;
					try
					{
						resourceManager = GetResourceManager(outAssembly, outDict);
					}
					catch (Exception ex)
					{
						OnProviderError(target, key, "Error retrieving the resource manager\r\n" + ex.Message);
						return null;
					}
					return resourceManager.GetObject(key, culture);
				}
				OnProviderError(target, key, "No key provided.");
				return null;
			}
			OnProviderError(target, key, "No dictionary provided.");
			return null;
		}
		OnProviderError(target, key, "No assembly provided.");
		return null;
	}
}
