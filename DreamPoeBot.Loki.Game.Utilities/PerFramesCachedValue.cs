using System;
using System.Diagnostics;

namespace DreamPoeBot.Loki.Game.Utilities;

public class PerFramesCachedValue<T> : PerCachedValue<T>
{
	private uint uint_0;

	private readonly int int_0;

	public PerFramesCachedValue(Func<T> producer, int duration)
		: base(producer)
	{
		uint_0 = 0u;
		int_0 = duration;
	}

	protected override bool ShouldUpdateCache(bool force = false)
	{
		uint num = (uint)smethod_3(LokiPoe.ApplicationRuntime);
		if (!(uint_0 < num - 125 || (ulong)(uint_0 + int_0) < (ulong)((long)num - 125L) || force))
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
