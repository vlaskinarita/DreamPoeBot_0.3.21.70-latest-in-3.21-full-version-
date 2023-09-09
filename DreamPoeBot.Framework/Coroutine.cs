using System;
using System.Collections;
using System.Runtime.CompilerServices;
using DreamPoeBot.Framework.Helpers;

namespace DreamPoeBot.Framework;

public class Coroutine
{
	private readonly IEnumerator _enumerator;

	public bool IsDone { get; private set; }

	public string Name { get; set; }

	public string Owner { get; private set; }

	public bool DoWork { get; private set; }

	public bool AutoResume { get; set; } = true;


	public string TimeoutForAction { get; private set; }

	public long Ticks { get; private set; } = -1L;


	public CoroutinePriority Priority { get; set; }

	public DateTime Started { get; set; }

	public Action Action { get; }

	public YieldBase Condition { get; private set; }

	public bool ThisIsSimple => Action != null;

	public Coroutine(Action action, YieldBase condition, string owner, string name = null, bool autoStart = true)
	{
		DoWork = autoStart;
		Started = DateTime.Now;
		if (!(condition is WaitTime))
		{
			if (!(condition is WaitRender))
			{
				if (condition is WaitFunction)
				{
					TimeoutForAction = "Function -1";
				}
			}
			else
			{
				TimeoutForAction = ((WaitRender)condition).HowManyRenderCountWait.ToString();
			}
		}
		else
		{
			TimeoutForAction = ((WaitTime)condition).Milliseconds.ToString();
		}
		Owner = owner;
		Action = action;
		Condition = condition;
		Name = name ?? MathHepler.GetRandomWord(13);
		_enumerator = method_0(action);
	}

	public Coroutine(Action action, int waitMilliseconds, string owner, string name = null, bool autoStart = true)
		: this(action, new WaitTime(waitMilliseconds), owner, name, autoStart)
	{
	}

	public Coroutine(IEnumerator enumerator, string owner, string name = null, bool autoStart = true)
	{
		DoWork = autoStart;
		Started = DateTime.Now;
		TimeoutForAction = "Not simple -1";
		Name = name ?? MathHepler.GetRandomWord(13);
		Owner = owner;
		_enumerator = enumerator;
	}

	public IEnumerator Wait()
	{
		while (!IsDone)
		{
			yield return null;
		}
	}

	public void UpdateCondtion(YieldBase condition)
	{
		if (!(condition is WaitTime))
		{
			if (!(condition is WaitRender))
			{
				if (condition is WaitFunction)
				{
					TimeoutForAction = "Function";
				}
			}
			else
			{
				TimeoutForAction = ((WaitRender)condition).HowManyRenderCountWait.ToString();
			}
		}
		else
		{
			TimeoutForAction = ((WaitTime)condition).Milliseconds.ToString();
		}
		Condition = condition;
	}

	public Coroutine GetCopy(Coroutine cor)
	{
		if (cor.ThisIsSimple)
		{
			return new Coroutine(cor.Action, cor.Condition, cor.Owner, cor.Name, cor.DoWork)
			{
				Priority = cor.Priority,
				AutoResume = cor.AutoResume,
				DoWork = cor.DoWork
			};
		}
		return new Coroutine(cor.GetEnumerator(), cor.Owner, cor.Name, cor.DoWork)
		{
			Priority = cor.Priority,
			AutoResume = cor.AutoResume,
			DoWork = cor.DoWork
		};
	}

	public IEnumerator GetEnumerator()
	{
		return _enumerator;
	}

	public void UpdateTicks(int tick)
	{
		Ticks = tick;
	}

	public void Resume()
	{
		DoWork = true;
	}

	public void Pause(bool force = false)
	{
		if (Priority != CoroutinePriority.Critical || force)
		{
			DoWork = false;
		}
	}

	public bool Done(bool force = false)
	{
		if (Priority == CoroutinePriority.Critical)
		{
			return false;
		}
		IsDone = true;
		return true;
	}

	public bool MoveNext()
	{
		return MoveNext(_enumerator);
	}

	private bool MoveNext(IEnumerator enumerator)
	{
		if (!IsDone)
		{
			if (enumerator.Current is IEnumerator enumerator2 && MoveNext(enumerator2))
			{
				return true;
			}
			return enumerator.MoveNext();
		}
		return false;
	}

	[CompilerGenerated]
	private IEnumerator method_0(Action a)
	{
		while (true)
		{
			a?.Invoke();
			Ticks++;
			yield return Condition.GetEnumerator();
		}
	}
}
