using System;
using System.Diagnostics;

namespace DreamPoeBot.Loki.Game.Utilities;

public class SlowCacheValue<T> : PerCachedValue<T>
{
	private uint uint_0;

	public SlowCacheValue(Func<T> producer)
		: base(producer)
	{
		uint_0 = 0u;
	}

	protected override bool ShouldUpdateCache(bool force = false)
	{
		uint num = (uint)smethod_3(LokiPoe.ApplicationRuntime);
		if (!(uint_0 < num - 250 || force))
		{
			return false;
		}
		uint_0 = num;
		return true;
	}

	static long smethod_3(Stopwatch stopwatch_0)
	{
		return stopwatch_0.ElapsedMilliseconds;
	}
}
