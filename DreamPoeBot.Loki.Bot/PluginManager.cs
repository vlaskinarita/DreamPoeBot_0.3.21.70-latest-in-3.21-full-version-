using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class PluginManager
{
	public delegate void PluginEvent(IPlugin plugin);

	[CompilerGenerated]
	private sealed class Class456
	{
		public string string_0;

		internal bool method_0(IPlugin iplugin_0)
		{
			return iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class Class457
	{
		public string string_0;

		internal bool method_0(IPlugin iplugin_0)
		{
			return iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class Class458
	{
		public string string_0;

		internal bool method_0(IPlugin iplugin_0)
		{
			return iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class Class459
	{
		public static readonly Class459 Method9 = new Class459();

		public static Func<IPlugin, bool> Method9__46_0;

		public static Func<IPlugin, string> Method9__47_0;

		internal bool method_0(IPlugin iplugin_0)
		{
			return !IsEnabled(iplugin_0);
		}

		internal string method_1(IPlugin iplugin_0)
		{
			return iplugin_0.Name;
		}
	}

	[CompilerGenerated]
	private sealed class Class460
	{
		public string string_0;

		internal bool method_0(IPlugin iplugin_0)
		{
			return iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_1(IPlugin iplugin_0)
		{
			return iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[CompilerGenerated]
	private sealed class Class461
	{
		public IPlugin iplugin_0;

		internal bool method_0(IPlugin iplugin_1)
		{
			return iplugin_1.Name.Equals(iplugin_0.Name, StringComparison.OrdinalIgnoreCase);
		}
	}

	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForName("PluginManager");

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static List<IPlugin> list_0 = new List<IPlugin>();

	[CompilerGenerated]
	private static PluginEvent pluginEvent_0;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_1;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_2;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_3;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_4;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_5;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_6;

	[CompilerGenerated]
	private static PluginEvent pluginEvent_7;

	private static readonly Dictionary<IPlugin, bool> dictionary_0 = new Dictionary<IPlugin, bool>();

	public static IReadOnlyList<IPlugin> Plugins => list_0;

	public static List<IPlugin> EnabledPlugins => list_0.Where(IsEnabled).ToList();

	public static List<IPlugin> DisabledPlugins => list_0.Where((IPlugin iplugin_0) => !IsEnabled(iplugin_0)).ToList();

	public static event PluginEvent PreStart
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_0;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_0, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_0;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_0, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent PostStart
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_1;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_1, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_1;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_1, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent PreTick
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_2;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_2, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_2;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_2, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent PostTick
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_3;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_3, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_3;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_3, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent PreStop
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_4;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_4, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_4;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_4, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent PostStop
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_5;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_5, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_5;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_5, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent OnPluginEnabled
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_6;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_6, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_6;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_6, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static event PluginEvent OnPluginDisabled
	{
		[CompilerGenerated]
		add
		{
			PluginEvent pluginEvent = pluginEvent_7;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Combine(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_7, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
		[CompilerGenerated]
		remove
		{
			PluginEvent pluginEvent = pluginEvent_7;
			PluginEvent pluginEvent2;
			do
			{
				pluginEvent2 = pluginEvent;
				PluginEvent value2 = (PluginEvent)Delegate.Remove(pluginEvent2, value);
				pluginEvent = Interlocked.CompareExchange(ref pluginEvent_7, value2, pluginEvent2);
			}
			while (pluginEvent != pluginEvent2);
		}
	}

	public static bool IsEnabled(string name)
	{
		return IsEnabled(list_0.FirstOrDefault((IPlugin iplugin_0) => iplugin_0.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
	}

	public static bool IsEnabled(IPlugin plugin)
	{
		Dictionary<IPlugin, bool> dictionary = dictionary_0;
		lock (dictionary)
		{
			if (dictionary_0.TryGetValue(plugin, out var value))
			{
				return value;
			}
			return false;
		}
	}

	public static void Start()
	{
		foreach (IPlugin enabledPlugin in EnabledPlugins)
		{
			smethod_0(enabledPlugin);
		}
	}

	private static void smethod_0(IPlugin iplugin_0)
	{
		ilog_0.InfoFormat("[Start] {0}", (object)iplugin_0.GetType());
		smethod_3(iplugin_0, pluginEvent_0);
		try
		{
			if (iplugin_0 is IStartStopEvents startStopEvents)
			{
				startStopEvents.Start();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception during plugin Start.", ex);
		}
		smethod_3(iplugin_0, pluginEvent_1);
	}

	public static void Tick()
	{
		if (GlobalSettings.Instance.DebugTicks)
		{
			new StringBuilder();
			{
				foreach (IPlugin enabledPlugin in EnabledPlugins)
				{
					Stopwatch stopwatch = Stopwatch.StartNew();
					smethod_1(enabledPlugin);
					stopwatch.Stop();
					ilog_1.InfoFormat($"[PluginManager-Tick] {enabledPlugin.Name} ({stopwatch.ElapsedMilliseconds} ms).", Array.Empty<object>());
				}
				return;
			}
		}
		foreach (IPlugin enabledPlugin2 in EnabledPlugins)
		{
			smethod_1(enabledPlugin2);
		}
	}

	private static void smethod_1(IPlugin iplugin_0)
	{
		smethod_3(iplugin_0, pluginEvent_2);
		try
		{
			if (iplugin_0 is ITickEvents tickEvents)
			{
				tickEvents.Tick();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception during plugin Tick.", ex);
		}
		smethod_3(iplugin_0, pluginEvent_3);
	}

	public static void Stop()
	{
		foreach (IPlugin enabledPlugin in EnabledPlugins)
		{
			smethod_2(enabledPlugin);
		}
	}

	private static void smethod_2(IPlugin iplugin_0)
	{
		ilog_0.InfoFormat("[Stop] {0}", (object)iplugin_0.GetType());
		smethod_3(iplugin_0, pluginEvent_4);
		try
		{
			if (iplugin_0 is IStartStopEvents startStopEvents)
			{
				startStopEvents.Stop();
			}
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception during plugin Stop.", ex);
		}
		smethod_3(iplugin_0, pluginEvent_5);
	}

	public static bool Enable(string name)
	{
		return Enable(list_0.FirstOrDefault((IPlugin iplugin_0) => iplugin_0.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
	}

	public static bool Enable(IPlugin plugin)
	{
		if (plugin == null)
		{
			return false;
		}
		if (BotManager.IsRunning && plugin is IStartStopEvents)
		{
			return false;
		}
		Dictionary<IPlugin, bool> dictionary = dictionary_0;
		lock (dictionary)
		{
			if (!dictionary_0.TryGetValue(plugin, out var value))
			{
				return false;
			}
			if (value)
			{
				return false;
			}
			dictionary_0[plugin] = true;
		}
		ilog_0.InfoFormat("[Enable] {0}", (object)plugin.GetType());
		smethod_3(plugin, pluginEvent_6);
		try
		{
			plugin.Enable();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception during plugin Enable.", ex);
		}
		return true;
	}

	public static bool Disable(string name)
	{
		return Disable(list_0.FirstOrDefault((IPlugin iplugin_0) => iplugin_0.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
	}

	public static bool Disable(IPlugin plugin)
	{
		if (plugin == null)
		{
			return false;
		}
		if (BotManager.IsRunning && plugin is IStartStopEvents)
		{
			return false;
		}
		Dictionary<IPlugin, bool> dictionary = dictionary_0;
		lock (dictionary)
		{
			if (!dictionary_0.TryGetValue(plugin, out var value))
			{
				return false;
			}
			if (!value)
			{
				return false;
			}
			dictionary_0[plugin] = false;
		}
		ilog_0.InfoFormat("[Disable] {0}", (object)plugin.GetType());
		smethod_3(plugin, pluginEvent_7);
		try
		{
			plugin.Disable();
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"Exception during plugin Disable.", ex);
		}
		return true;
	}

	private static void smethod_3(IPlugin iplugin_0, PluginEvent pluginEvent_8)
	{
		if (pluginEvent_8 == null)
		{
			return;
		}
		try
		{
			pluginEvent_8(iplugin_0);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"[Invoke] Error during execution:", ex);
		}
	}

	internal static void AddPlugins(IReadOnlyList<ThirdPartyInstance> ireadOnlyList_0, List<string> list_1, List<string> list_2)
	{
		List<IPlugin> list = new List<IPlugin>();
		list.AddRange(new TypeLoader<IPlugin>());
		List<IPlugin> list2 = new List<IPlugin>();
		foreach (string string_0 in list_2)
		{
			if (!list2.Any((IPlugin iplugin_0) => iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase)))
			{
				IPlugin plugin = list.FirstOrDefault((IPlugin iplugin_0) => iplugin_0.Name.Equals(string_0, StringComparison.OrdinalIgnoreCase));
				if (plugin != null)
				{
					list2.Add(plugin);
				}
			}
		}
		list = list.OrderBy((IPlugin iplugin_0) => iplugin_0.Name).ToList();
		foreach (IPlugin iplugin_2 in list)
		{
			if (!list2.Any((IPlugin iplugin_1) => iplugin_1.Name.Equals(iplugin_2.Name, StringComparison.OrdinalIgnoreCase)))
			{
				list2.Add(iplugin_2);
			}
		}
		list_0 = new List<IPlugin>();
		foreach (IPlugin item in list2)
		{
			if (Utility.smethod_2(ilog_0, item))
			{
				Dictionary<IPlugin, bool> dictionary = dictionary_0;
				lock (dictionary)
				{
					dictionary_0.Add(item, list_1.Contains(item.Name));
				}
				list_0.Add(item);
			}
		}
		foreach (IPlugin enabledPlugin in EnabledPlugins)
		{
			ilog_0.InfoFormat("[Enable] {0}", (object)enabledPlugin.GetType());
			smethod_3(enabledPlugin, pluginEvent_6);
			try
			{
				enabledPlugin.Enable();
			}
			catch (Exception ex)
			{
				ilog_0.Debug((object)("[Initialize] Exception thrown when enabling [" + enabledPlugin.Name + "]. Plugin will not be enabled."), ex);
				Disable(enabledPlugin);
			}
		}
	}

	internal static void smethod_5()
	{
		if (list_0 == null)
		{
			return;
		}
		foreach (IPlugin item in list_0)
		{
			ilog_0.InfoFormat("[PluginManager.Deinitialize] {0}", (object)item.GetType());
			try
			{
				item.Deinitialize();
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat("[PluginManager] An exception occurred in {0}'s Deinitialize function. {1}", (object)item.Name, (object)ex);
			}
		}
		list_0.Clear();
	}
}
