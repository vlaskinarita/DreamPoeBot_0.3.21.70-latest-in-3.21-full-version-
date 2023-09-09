using System;
using System.Threading;

namespace DreamPoeBot.Loki.Common;

public class WaitTimer
{
	public sealed class WaitTimerEventArgs : EventArgs
	{
		public DateTime TimeFinished { get; set; }

		public TimeSpan WaitTime { get; set; }

		public DateTime TimeStarted { get; set; }
	}

	private WaitTimerFinishedHandler waitTimerFinishedHandler_0;

	public static WaitTimer OneSecond => new WaitTimer(new TimeSpan(0, 0, 1));

	public static WaitTimer FiveSeconds => new WaitTimer(new TimeSpan(0, 0, 5));

	public static WaitTimer TenSeconds => new WaitTimer(new TimeSpan(0, 0, 10));

	public static WaitTimer ThirtySeconds => new WaitTimer(new TimeSpan(0, 0, 30));

	public TimeSpan WaitTime { get; set; }

	public DateTime EndTime => StartTime + WaitTime;

	public DateTime StartTime { get; private set; }

	public bool IsFinished => DateTime.Now > EndTime;

	public TimeSpan TimeLeft => EndTime - DateTime.Now;

	public event WaitTimerFinishedHandler Finished
	{
		add
		{
			WaitTimerFinishedHandler waitTimerFinishedHandler = waitTimerFinishedHandler_0;
			WaitTimerFinishedHandler waitTimerFinishedHandler2;
			do
			{
				waitTimerFinishedHandler2 = waitTimerFinishedHandler;
				WaitTimerFinishedHandler value2 = (WaitTimerFinishedHandler)Delegate.Combine(waitTimerFinishedHandler2, value);
				waitTimerFinishedHandler = Interlocked.CompareExchange(ref waitTimerFinishedHandler_0, value2, waitTimerFinishedHandler2);
			}
			while (waitTimerFinishedHandler != waitTimerFinishedHandler2);
		}
		remove
		{
			WaitTimerFinishedHandler waitTimerFinishedHandler = waitTimerFinishedHandler_0;
			WaitTimerFinishedHandler waitTimerFinishedHandler2;
			do
			{
				waitTimerFinishedHandler2 = waitTimerFinishedHandler;
				WaitTimerFinishedHandler value2 = (WaitTimerFinishedHandler)Delegate.Remove(waitTimerFinishedHandler2, value);
				waitTimerFinishedHandler = Interlocked.CompareExchange(ref waitTimerFinishedHandler_0, value2, waitTimerFinishedHandler2);
			}
			while (waitTimerFinishedHandler != waitTimerFinishedHandler2);
		}
	}

	public void Reset(TimeSpan newDuration)
	{
		WaitTime = newDuration;
		Reset();
	}

	public WaitTimer(TimeSpan waitTime)
	{
		WaitTime = waitTime;
		Stop();
	}

	public void Reset()
	{
		StartTime = DateTime.Now;
	}

	public void Stop()
	{
		StartTime = DateTime.Now.AddDays(-5.0);
	}

	public void Update()
	{
		if (IsFinished && waitTimerFinishedHandler_0 != null)
		{
			WaitTimerEventArgs waitTimerEventArgs = new WaitTimerEventArgs();
			waitTimerEventArgs.TimeFinished = DateTime.Now;
			waitTimerEventArgs.TimeStarted = StartTime;
			waitTimerEventArgs.WaitTime = WaitTime;
			waitTimerFinishedHandler_0(this, waitTimerEventArgs);
		}
	}
}
