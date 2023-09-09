using System;
using System.Diagnostics;

namespace DreamPoeBot.Loki.Bot;

public abstract class AreaData
{
	private readonly Stopwatch stopwatch_0 = new Stopwatch();

	private readonly Stopwatch stopwatch_1 = new Stopwatch();

	public uint AreaHash { get; }

	public TimeSpan Lifetime => stopwatch_0.Elapsed;

	public TimeSpan Activity => stopwatch_1.Elapsed;

	internal void method_0()
	{
		stopwatch_1.Start();
	}

	internal void method_1()
	{
		stopwatch_1.Restart();
	}

	internal void method_2()
	{
		stopwatch_1.Restart();
	}

	internal void method_3()
	{
		stopwatch_0.Start();
	}

	internal void method_4()
	{
		stopwatch_0.Stop();
	}

	protected AreaData(uint hash)
	{
		AreaHash = hash;
		stopwatch_0.Start();
		stopwatch_1.Start();
	}

	public abstract void Start(bool isActive);

	public abstract void Tick(bool isActive);

	public abstract void Stop(bool isActive);
}
