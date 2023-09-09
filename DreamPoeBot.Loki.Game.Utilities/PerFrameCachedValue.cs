using System;
using System.Diagnostics;

namespace DreamPoeBot.Loki.Game.Utilities;

public class PerFrameCachedValue<T> : PerCachedValue<T>
{
	private long _ticker;

	public PerFrameCachedValue(Func<T> producer)
		: base(producer)
	{
		_ticker = long.MinValue;
	}

	protected override bool ShouldUpdateCache(bool force = false)
	{
		long num = smethod_3(LokiPoe.ApplicationRuntime);
		if (_ticker < num - 30L || force)
		{
			_ticker = num;
			return true;
		}
		return false;
	}

	static long smethod_3(Stopwatch stopwatch_0)
	{
		return stopwatch_0.ElapsedMilliseconds;
	}
}
