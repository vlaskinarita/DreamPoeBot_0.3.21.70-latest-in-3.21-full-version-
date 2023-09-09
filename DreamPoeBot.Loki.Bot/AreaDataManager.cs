using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class AreaDataManager<T> where T : AreaData
{
	private readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private readonly Dictionary<uint, T> dictionary_0 = new Dictionary<uint, T>();

	private readonly Stopwatch stopwatch_0 = smethod_0();

	private readonly Func<uint, T> func_0;

	public bool DebugLogging { get; set; }

	public int MsBetweenTicks { get; set; } = 250;


	public int DataInactivityExpireTimeMs { get; set; } = 2700000;


	public T Active
	{
		get
		{
			if (!LokiPoe.IsInGame)
			{
				return null;
			}
			uint areaHash = LokiPoe.LocalData.AreaHash;
			if (!dictionary_0.TryGetValue(areaHash, out var value))
			{
				if (DebugLogging)
				{
					smethod_4(ilog_0, "[Active] Now creating a [{0}] for area [{1}].", (object)smethod_3((MemberInfo)smethod_2(typeof(T).TypeHandle)), (object)areaHash);
				}
				value = func_0(areaHash);
				dictionary_0.Add(areaHash, value);
			}
			return value;
		}
	}

	public AreaDataManager(Func<uint, T> allocateFunc)
	{
		if (allocateFunc == null)
		{
			throw smethod_1("allocateFunc");
		}
		func_0 = allocateFunc;
	}

	public void Start()
	{
		uint num = 0u;
		if (LokiPoe.IsInGame)
		{
			num = LokiPoe.LocalData.AreaHash;
		}
		Active?.method_1();
		Exception ex = null;
		foreach (KeyValuePair<uint, T> item in dictionary_0)
		{
			try
			{
				item.Value.method_3();
				item.Value.method_0();
				item.Value.Start(item.Key == num);
			}
			catch (Exception ex2)
			{
				smethod_5(ilog_0, (object)"[Start] An exception occurred: ", ex2);
				if (ex == null)
				{
					ex = ex2;
				}
			}
		}
		smethod_6(stopwatch_0);
		if (ex != null)
		{
			throw ex;
		}
	}

	public void Tick()
	{
		if (!LokiPoe.IsInGame)
		{
			return;
		}
		Active?.method_1();
		if (smethod_7(stopwatch_0) && smethod_8(stopwatch_0) < MsBetweenTicks)
		{
			return;
		}
		method_0();
		uint areaHash = LokiPoe.LocalData.AreaHash;
		Exception ex = null;
		foreach (KeyValuePair<uint, T> item in dictionary_0)
		{
			try
			{
				item.Value.Tick(areaHash == item.Key);
			}
			catch (Exception ex2)
			{
				smethod_5(ilog_0, (object)"[Tick] An exception occurred: ", ex2);
				if (ex == null)
				{
					ex = ex2;
				}
			}
		}
		smethod_9(stopwatch_0);
		if (ex == null)
		{
			return;
		}
		throw ex;
	}

	public void Stop()
	{
		Active?.method_1();
		uint num = 0u;
		if (LokiPoe.IsInGame)
		{
			num = LokiPoe.LocalData.AreaHash;
		}
		Exception ex = null;
		foreach (KeyValuePair<uint, T> item in dictionary_0)
		{
			try
			{
				item.Value.method_4();
				item.Value.method_2();
				item.Value.Stop(item.Key == num);
			}
			catch (Exception ex2)
			{
				smethod_5(ilog_0, (object)"[Stop] An exception occurred: ", ex2);
				if (ex == null)
				{
					ex = ex2;
				}
			}
		}
		smethod_6(stopwatch_0);
		if (ex != null)
		{
			throw ex;
		}
	}

	private void method_0()
	{
		List<uint> list = new List<uint>();
		foreach (KeyValuePair<uint, T> item in dictionary_0)
		{
			if (item.Value.Activity.TotalMilliseconds >= (double)DataInactivityExpireTimeMs)
			{
				if (DebugLogging)
				{
					ilog_0.DebugFormat("[Prune] Data for area [{0}] being removed due to inactivity of [{1}].", (object)item.Key, (object)item.Value.Activity);
				}
				list.Add(item.Key);
			}
		}
		foreach (uint item2 in list)
		{
			dictionary_0.Remove(item2);
		}
	}

	static Stopwatch smethod_0()
	{
		return new Stopwatch();
	}

	static NullReferenceException smethod_1(string string_0)
	{
		return new NullReferenceException(string_0);
	}

	static Type smethod_2(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	static string smethod_3(MemberInfo memberInfo_0)
	{
		return memberInfo_0.Name;
	}

	static void smethod_4(ILog ilog_1, string string_0, object object_0, object object_1)
	{
		ilog_1.DebugFormat(string_0, object_0, object_1);
	}

	static void smethod_5(ILog ilog_1, object object_0, Exception exception_0)
	{
		ilog_1.Error(object_0, exception_0);
	}

	static void smethod_6(Stopwatch stopwatch_1)
	{
		stopwatch_1.Reset();
	}

	static bool smethod_7(Stopwatch stopwatch_1)
	{
		return stopwatch_1.IsRunning;
	}

	static long smethod_8(Stopwatch stopwatch_1)
	{
		return stopwatch_1.ElapsedMilliseconds;
	}

	static void smethod_9(Stopwatch stopwatch_1)
	{
		stopwatch_1.Restart();
	}
}
