using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Threading;
using DreamPoeBot.DreamPoe;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;
using log4net.Core;

namespace DreamPoeBot.Loki.Bot;

public static class BotManager
{
	public delegate void BotEvent(IBot bot);

	private static Stopwatch TickDeleyCheckSW;

	public static List<IBot> _bots;

	public static int TotalExceptionRuntime;

	private static readonly ILog ilog_0;

	private static BotEvent botEvent_PreStart;

	private static BotEvent botEvent_PostStart;

	private static BotEvent botEvent_PreTick;

	private static BotEvent botEvent_PostTick;

	private static BotEvent botEvent_PreStop;

	private static BotEvent botEvent_PostStop;

	private static readonly object object_0;

	private static readonly ManualResetEvent manualResetEvent_0;

	private static DateTime dateTime_0;

	private static StopReasonData stopReasonData_0;

	private static bool bool_0;

	private static bool bool_1;

	private static bool bool_2;

	private static int exception_This_Tick;

	private static IBot ibot_0;

	private static EventHandler<BotChangedEventArgs> eventHandler_0;

	private static EventHandler<ClientFrozenEventArgs> eventHandler_1;

	private static EventHandler<BotTickExceptionEventArgs> eventHandler_2;

	private static bool bool_3;

	private static readonly Stopwatch stopwatch_0;

	private static int int_3;

	private static readonly List<Tuple<Exception, DateTime>> list_0;

	private static int int_4;

	public static IReadOnlyList<IBot> Bots => _bots;

	public static StopReasonData StopReason
	{
		get
		{
			object obj = object_0;
			lock (obj)
			{
				return stopReasonData_0;
			}
		}
	}

	public static DateTime TimeOfLastTick => dateTime_0;

	public static int StopBotAfterXExceptionsBeforeTickCompletes { get; set; }

	public static IBot Current
	{
		get
		{
			return ibot_0;
		}
		set
		{
			object obj = object_0;
			lock (obj)
			{
				if (IsRunning)
				{
					throw new InvalidOperationException("The current IBot cannot change while the bot is running. Please Stop it first.");
				}
				if (value != null)
				{
					if (ibot_0 != value)
					{
						IBot old = ibot_0;
						ibot_0 = value;
						LokiPoe.InvokeEvent(eventHandler_0, null, new BotChangedEventArgs(old, ibot_0));
					}
					return;
				}
				throw new InvalidOperationException("The current IBot cannot be set to null.");
			}
		}
	}

	public static Thread BotThread { get; private set; }

	public static int ExceptionCount => list_0.Count;

	public static IReadOnlyList<Tuple<Exception, DateTime>> Exceptions => list_0.ToList();

	public static bool ClientFrozen => bool_3;

	public static int MsBeforeNextTick
	{
		get
		{
			return int_4;
		}
		set
		{
			int_4 = value;
			if (int_4 < 0)
			{
				int_4 = 0;
			}
		}
	}

	public static int MsBetweenTicks
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
			if (int_3 < 0)
			{
				int_3 = 0;
			}
			ilog_0.InfoFormat("[BotManager] MsBetweenTicks = {0}", (object)int_3);
		}
	}

	public static bool IsStopping
	{
		get
		{
			object obj = object_0;
			lock (obj)
			{
				return manualResetEvent_0.WaitOne(0);
			}
		}
	}

	public static bool IsRunning
	{
		get
		{
			object obj = object_0;
			lock (obj)
			{
				return BotThread != null;
			}
		}
	}

	public static event BotEvent PreStart
	{
		add
		{
			BotEvent botEvent = botEvent_PreStart;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreStart, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PreStart;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreStart, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event BotEvent PostStart
	{
		add
		{
			BotEvent botEvent = botEvent_PostStart;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostStart, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PostStart;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostStart, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event BotEvent PreTick
	{
		add
		{
			BotEvent botEvent = botEvent_PreTick;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreTick, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PreTick;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreTick, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event BotEvent PostTick
	{
		add
		{
			BotEvent botEvent = botEvent_PostTick;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostTick, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PostTick;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostTick, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event BotEvent PreStop
	{
		add
		{
			BotEvent botEvent = botEvent_PreStop;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreStop, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PreStop;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PreStop, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event BotEvent PostStop
	{
		add
		{
			BotEvent botEvent = botEvent_PostStop;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Combine(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostStop, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
		remove
		{
			BotEvent botEvent = botEvent_PostStop;
			BotEvent botEvent2;
			do
			{
				botEvent2 = botEvent;
				BotEvent value2 = (BotEvent)Delegate.Remove(botEvent2, value);
				botEvent = Interlocked.CompareExchange(ref botEvent_PostStop, value2, botEvent2);
			}
			while (botEvent != botEvent2);
		}
	}

	public static event EventHandler<BotChangedEventArgs> OnBotChanged
	{
		add
		{
			EventHandler<BotChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<BotChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BotChangedEventArgs> value2 = (EventHandler<BotChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<BotChangedEventArgs> eventHandler = eventHandler_0;
			EventHandler<BotChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BotChangedEventArgs> value2 = (EventHandler<BotChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<ClientFrozenEventArgs> OnClientFrozen
	{
		add
		{
			EventHandler<ClientFrozenEventArgs> eventHandler = eventHandler_1;
			EventHandler<ClientFrozenEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ClientFrozenEventArgs> value2 = (EventHandler<ClientFrozenEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<ClientFrozenEventArgs> eventHandler = eventHandler_1;
			EventHandler<ClientFrozenEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ClientFrozenEventArgs> value2 = (EventHandler<ClientFrozenEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static event EventHandler<BotTickExceptionEventArgs> OnBotTickException
	{
		add
		{
			EventHandler<BotTickExceptionEventArgs> eventHandler = eventHandler_2;
			EventHandler<BotTickExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BotTickExceptionEventArgs> value2 = (EventHandler<BotTickExceptionEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<BotTickExceptionEventArgs> eventHandler = eventHandler_2;
			EventHandler<BotTickExceptionEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<BotTickExceptionEventArgs> value2 = (EventHandler<BotTickExceptionEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	static BotManager()
	{
		TickDeleyCheckSW = Stopwatch.StartNew();
		_bots = new List<IBot>();
		TotalExceptionRuntime = 0;
		ilog_0 = Logger.GetLoggerInstanceForName("BotManager");
		manualResetEvent_0 = new ManualResetEvent(initialState: false);
		dateTime_0 = DateTime.MinValue;
		stopwatch_0 = Stopwatch.StartNew();
		list_0 = new List<Tuple<Exception, DateTime>>();
		ilog_0 = Logger.GetLoggerInstanceForName("BotManager");
		_bots = new List<IBot>();
		manualResetEvent_0 = new ManualResetEvent(initialState: false);
		dateTime_0 = DateTime.MinValue;
		StopBotAfterXExceptionsBeforeTickCompletes = 100;
		stopwatch_0 = Stopwatch.StartNew();
		list_0 = new List<Tuple<Exception, DateTime>>();
		object_0 = new object();
		MsBetweenTicks = 80;
		LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion = (LokiPoe.ProcessHookManager.HookDisabledByIngecionEventHandler)Delegate.Combine(LokiPoe.ProcessHookManager.OnInjectionDisabledByIngecion, new LokiPoe.ProcessHookManager.HookDisabledByIngecionEventHandler(StopBecounseOfInjectionDisabledByIngecion));
	}

	private static void StopBecounseOfInjectionDisabledByIngecion(object sender, LokiPoe.ProcessHookManager.HookDisabledByIngecionEventArgs e)
	{
		if (BotThread != null)
		{
			Stop(new StopReasonData("7475", e.GetInfo()), force: true);
		}
	}

	internal static void smethod_StartEvents(IBot ibot_1)
	{
		try
		{
			lock (object_0)
			{
				if (bool_0)
				{
					return;
				}
				bool_0 = true;
				exception_This_Tick = 0;
			}
			ilog_0.InfoFormat("[Start] {0}", (object)ibot_1.GetType());
			smethod_EventsExecuter(ibot_1, botEvent_PreStart);
			try
			{
				ibot_1.Start();
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"[Start] Exception during execution:", ex);
				throw;
			}
			smethod_EventsExecuter(ibot_1, botEvent_PostStart);
		}
		finally
		{
			lock (object_0)
			{
				bool_0 = false;
			}
		}
	}

	internal static void smethod_TickEvents(IBot ibot_1)
	{
		try
		{
			lock (object_0)
			{
				if (bool_1)
				{
					return;
				}
				bool_1 = true;
			}
			smethod_EventsExecuter(ibot_1, botEvent_PreTick);
			try
			{
				ibot_1.Tick();
			}
			catch (Exception ex)
			{
				TotalExceptionRuntime++;
				if (StopBotAfterXExceptionsBeforeTickCompletes > 0)
				{
					exception_This_Tick++;
					ilog_0.Error((object)$"[Tick] Exception #{TotalExceptionRuntime} during execution, #{exception_This_Tick} this tick: ", ex);
					if (exception_This_Tick > StopBotAfterXExceptionsBeforeTickCompletes)
					{
						exception_This_Tick = 0;
						HookManager.ResetKeyState();
						HookManager.RemoveHook();
						Dispatcher.CurrentDispatcher.BeginInvoke((Action)delegate
						{
							Stop(new StopReasonData("botmanager_excess_exceptions", "Now stopping the bot to prevent excess exceptions in Tick."));
						});
						return;
					}
					if (exception_This_Tick > 1)
					{
						MsBeforeNextTick = 100;
					}
				}
			}
			smethod_EventsExecuter(ibot_1, botEvent_PostTick);
			exception_This_Tick = 0;
		}
		finally
		{
			lock (object_0)
			{
				bool_1 = false;
			}
		}
	}

	internal static void smethod_StopEvents(IBot ibot_1)
	{
		try
		{
			lock (object_0)
			{
				if (bool_2)
				{
					return;
				}
				bool_2 = true;
			}
			ilog_0.InfoFormat("[Stop] {0}", (object)ibot_1.GetType());
			smethod_EventsExecuter(ibot_1, botEvent_PreStop);
			try
			{
				ibot_1.Stop();
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"[Stop] Exception during execution:", ex);
				throw;
			}
			smethod_EventsExecuter(ibot_1, botEvent_PostStop);
		}
		finally
		{
			lock (object_0)
			{
				bool_2 = false;
			}
		}
	}

	private static void smethod_EventsExecuter(IBot ibot_1, BotEvent botEvent)
	{
		if (botEvent == null)
		{
			return;
		}
		try
		{
			botEvent(ibot_1);
		}
		catch (Exception ex)
		{
			ilog_0.Error((object)"[Invoke] Error during execution:", ex);
			throw;
		}
	}

	public static bool Start()
	{
		object obj = object_0;
		bool flag;
		lock (obj)
		{
			if (!IsRunning)
			{
				if (LokiPoe.Initialized)
				{
					if (Current == null)
					{
						ilog_0.ErrorFormat("[Start] There is no bot to run. Please select a bot first.", Array.Empty<object>());
						flag = false;
					}
					else
					{
						ilog_0.InfoFormat("[Start] Now creating the BotThread.", Array.Empty<object>());
						LokiPoe.ClearClipboard();
						stopReasonData_0 = null;
						dateTime_0 = DateTime.Now;
						bool_3 = false;
						manualResetEvent_0.Reset();
						LokiPoe.Input.Binding.Update();
						switch (DreamPoeBot.DreamPoe.GuiSettings.Instance.LogLevel)
						{
						case "Warn":
							Logger.ChangeLogFilterLevel(Level.Warn, Level.Error);
							break;
						case "None":
							Logger.ChangeLogFilterLevel(Level.Off, Level.Off);
							break;
						default:
							Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
							break;
						case "Full":
							Logger.ChangeLogFilterLevel(Level.Verbose, Level.Emergency);
							break;
						}
						BotThread = new Thread(BotThreadFunction);
						BotThread.Start();
						flag = true;
					}
				}
				else
				{
					ilog_0.ErrorFormat("[Start] LokiPoe is not initialized yet.", Array.Empty<object>());
					flag = false;
				}
			}
			else
			{
				ilog_0.ErrorFormat("[Start] The BotThread is already running. Please use BotManager.Stop first.", Array.Empty<object>());
				flag = false;
			}
		}
		if (flag)
		{
			LokiPoe.ClientFunctions.SetBackgroundFps(GlobalSettings.Instance.BackgroundFps);
		}
		return flag;
	}

	public static bool Stop(bool force = false)
	{
		return Stop(null, force);
	}

	public static bool Stop(StopReasonData reason, bool force = false)
	{
		object obj = object_0;
		bool flag;
		lock (obj)
		{
			if (BotThread == null)
			{
				ilog_0.ErrorFormat("[Stop] The BotThread is not running. Please use BotManager.Start first.", Array.Empty<object>());
				flag = false;
			}
			else if (force)
			{
				ilog_0.InfoFormat("[Stop] Now force stopping the BotThread. This will result in an unexpected program state.", Array.Empty<object>());
				try
				{
					BotThread.Abort();
				}
				catch (Exception ex)
				{
					ilog_0.Error((object)"[Stop] BotThread.Abort() failed. Now requesting the BotThread to stop instead.", ex);
					stopReasonData_0 = reason;
					manualResetEvent_0.Set();
					LokiPoe.ClientFunctions.SetBackgroundFps(20);
					return true;
				}
				BotThread = null;
				manualResetEvent_0.Reset();
				flag = true;
			}
			else if (manualResetEvent_0.WaitOne(0))
			{
				ilog_0.ErrorFormat("[Stop] The BotThread is in the process of stopping already.", Array.Empty<object>());
				flag = false;
			}
			else
			{
				ilog_0.InfoFormat("[Stop] Now requesting the BotThread to stop.", Array.Empty<object>());
				stopReasonData_0 = reason;
				manualResetEvent_0.Set();
				flag = true;
			}
		}
		if (flag)
		{
			LokiPoe.ClientFunctions.SetBackgroundFps(20);
		}
		return flag;
	}

	private static void BotThreadFunction()
	{
		object obj = object_0;
		lock (obj)
		{
			Thread.Sleep(1);
		}
		try
		{
			smethod_StartEvents(Current);
		}
		catch (Exception)
		{
			ilog_0.DebugFormat("[BotThreadFunction] An InjectionDesyncException was detected.", Array.Empty<object>());
			bool_3 = true;
			LokiPoe.InvokeEvent(eventHandler_1, null, new ClientFrozenEventArgs());
			manualResetEvent_0.Set();
		}
		while (!manualResetEvent_0.WaitOne(0))
		{
			try
			{
				stopwatch_0.Stop();
				if (MsBeforeNextTick != 0)
				{
					Thread.Sleep(MsBeforeNextTick);
					MsBeforeNextTick = 0;
				}
				stopwatch_0.Start();
				if (stopwatch_0.ElapsedMilliseconds > 60000L)
				{
					stopwatch_0.Restart();
					list_0.Clear();
				}
				dateTime_0 = DateTime.Now;
				smethod_TickEvents(Current);
				if (MsBetweenTicks != 0)
				{
					Thread.Sleep(MsBetweenTicks);
				}
				bool_3 = false;
			}
			catch (Exception item)
			{
				ilog_0.DebugFormat("[BotThreadFunction] An Exception was detected.", Array.Empty<object>());
				list_0.Add(new Tuple<Exception, DateTime>(item, DateTime.Now));
				LokiPoe.InvokeEvent(eventHandler_2, null, new BotTickExceptionEventArgs());
			}
		}
		try
		{
			smethod_StopEvents(Current);
		}
		catch (Exception ex2)
		{
			ilog_0.DebugFormat("[BotThreadFunction] An InjectionDesyncException was detected. {0}", (object)ex2);
			bool_3 = true;
			LokiPoe.InvokeEvent(eventHandler_1, null, new ClientFrozenEventArgs());
		}
		StopReasonData stopReason = StopReason;
		if (stopReason != null)
		{
			ilog_0.DebugFormat("[StopReason] {0} => {1}", (object)stopReason.Id, (object)stopReason.Reason);
		}
		if (Hooking.IsInstalled)
		{
			if (Hooking.IsInstalled)
			{
				HookManager.RemoveHook();
			}
			while (Hooking.IsInstalled)
			{
				Thread.Sleep(1);
			}
		}
		BotThread = null;
		manualResetEvent_0.Reset();
	}

	internal static void smethod_5LoadBots(IReadOnlyList<ThirdPartyInstance> ireadOnlyList_0)
	{
		List<IBot> list = new List<IBot>();
		list.AddRange(new TypeLoader<IBot>());
		_bots = new List<IBot>();
		foreach (IBot item in list)
		{
			if (Utility.smethod_4(ilog_0, item))
			{
				_bots.Add(item);
			}
		}
	}

	internal static void smethod_6Deinitializer()
	{
		if (_bots == null)
		{
			return;
		}
		foreach (IBot bot in _bots)
		{
			try
			{
				ilog_0.InfoFormat("[BotManager.Deinitialize] {0}", (object)bot.GetType());
				bot.Deinitialize();
			}
			catch (Exception ex)
			{
				ilog_0.ErrorFormat("[BotManager] An exception occurred in {0}'s Deinitialize function. {1}", (object)bot.Name, (object)ex);
			}
		}
		_bots.Clear();
	}
}
