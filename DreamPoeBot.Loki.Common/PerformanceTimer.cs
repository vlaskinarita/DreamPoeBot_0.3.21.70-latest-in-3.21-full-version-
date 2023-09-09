using System;
using System.Diagnostics;
using log4net;

namespace DreamPoeBot.Loki.Common;

public class PerformanceTimer : IDisposable
{
	private readonly Stopwatch stopwatch_0;

	private readonly string string_0;

	private readonly FinishedMeasuringCallback finishedMeasuringCallback_0;

	private int int_0;

	private readonly bool bool_1;

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public static bool DontPrint { get; set; } = true;


	public TimeSpan Elapsed => stopwatch_0.Elapsed;

	public long ElapsedMilliseconds => stopwatch_0.ElapsedMilliseconds;

	public PerformanceTimer(string debugText, int triggerMs = 0, FinishedMeasuringCallback callback = null, bool? dontPrint = null)
	{
		finishedMeasuringCallback_0 = callback;
		stopwatch_0 = new Stopwatch();
		string_0 = debugText;
		int_0 = triggerMs + 10;
		if (dontPrint.HasValue)
		{
			bool_1 = dontPrint.Value;
		}
		else
		{
			bool_1 = DontPrint;
		}
		method_0();
	}

	public void Start()
	{
		stopwatch_0.Start();
	}

	private void method_0()
	{
		Start();
	}

	private void method_1()
	{
		StopAndPrint();
	}

	public void StopAndPrint()
	{
		if (stopwatch_0.IsRunning)
		{
			stopwatch_0.Stop();
			if (stopwatch_0.Elapsed.TotalMilliseconds >= (double)int_0 && !bool_1)
			{
				ilog_0.DebugFormat($"[{stopwatch_0.Elapsed.TotalMilliseconds} ms] {string_0}", Array.Empty<object>());
			}
			finishedMeasuringCallback_0?.BeginInvoke(ElapsedMilliseconds, null, null);
		}
	}

	public void Dispose()
	{
		method_1();
	}
}
