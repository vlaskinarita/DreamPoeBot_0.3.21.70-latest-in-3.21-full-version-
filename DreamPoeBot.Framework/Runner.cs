using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamPoeBot.Framework;

public class Runner
{
	private readonly List<Coroutine> _coroutines = new List<Coroutine>();

	private readonly List<Tuple<string, string, long, DateTime, DateTime>> _finishedCoroutines = new List<Tuple<string, string, long, DateTime, DateTime>>();

	private readonly HashSet<Coroutine> _autorestartCoroutines = new HashSet<Coroutine>();

	public string Name { get; }

	public bool IsRunning => _coroutines.Count > 0;

	public IEnumerable<Tuple<string, string, long, DateTime, DateTime>> FinishedCoroutines => _finishedCoroutines;

	public int FinishedCoroutineCount { get; private set; }

	public IEnumerable<Coroutine> Coroutines => _coroutines;

	public IEnumerable<Coroutine> WorkingCoroutines => _coroutines.Where((Coroutine x) => x.DoWork);

	public IEnumerable<Coroutine> AutorestartCoroutines => _autorestartCoroutines;

	public int CountAddCoroutines { get; private set; }

	public int CountFalseAddCoroutines { get; private set; }

	public int RunPerLoopIter { get; set; } = 1;


	public int Count => _coroutines.Count;

	public Coroutine GetCoroutineByname(string name)
	{
		return _coroutines.FirstOrDefault((Coroutine x) => x.Name.Contains(name));
	}

	public Runner(string name)
	{
		Name = name;
	}

	public Coroutine Run(IEnumerator enumerator, string owner, string name = null)
	{
		Coroutine routine = new Coroutine(enumerator, owner, name);
		Coroutine coroutine = _coroutines.FirstOrDefault((Coroutine x) => x.Name == routine.Name && x.Owner == routine.Owner);
		if (coroutine != null)
		{
			CountFalseAddCoroutines++;
			return coroutine;
		}
		_coroutines.Add(routine);
		CountAddCoroutines++;
		return routine;
	}

	public Coroutine Run(Coroutine routine)
	{
		Coroutine coroutine = _coroutines.FirstOrDefault((Coroutine x) => x.Name == routine.Name && x.Owner == routine.Owner);
		if (coroutine != null)
		{
			CountFalseAddCoroutines++;
			return coroutine;
		}
		_coroutines.Add(routine);
		CountAddCoroutines++;
		return routine;
	}

	public void StopCoroutines(IEnumerable<Coroutine> coroutines)
	{
		foreach (Coroutine coroutine in coroutines)
		{
			coroutine.Pause();
		}
	}

	public void ResumeCoroutines(IEnumerable<Coroutine> coroutines)
	{
		foreach (Coroutine coroutine in coroutines)
		{
			if (coroutine.AutoResume)
			{
				coroutine.Resume();
			}
		}
	}

	public bool HasName(string name)
	{
		return _coroutines.Any((Coroutine x) => x.Name == name);
	}

	public bool Update()
	{
		if (_coroutines.Count > 0)
		{
			for (int i = 0; i < _coroutines.Count; i++)
			{
				if (_coroutines[i] != null && !_coroutines[i].IsDone)
				{
					if (!_coroutines[i].DoWork)
					{
						continue;
					}
					try
					{
						if (!_coroutines[i].MoveNext())
						{
							_coroutines[i].Done();
						}
					}
					catch (Exception)
					{
					}
				}
				else
				{
					if (_coroutines[i] != null)
					{
						_finishedCoroutines.Add(new Tuple<string, string, long, DateTime, DateTime>(_coroutines[i].Name, _coroutines[i].Owner, _coroutines[i].Ticks, _coroutines[i].Started, DateTime.Now));
						FinishedCoroutineCount++;
					}
					_coroutines.RemoveAt(i);
				}
			}
			return true;
		}
		return false;
	}

	public void AddToAutoupdate(Coroutine coroutine)
	{
		_autorestartCoroutines.Add(coroutine.GetCopy(coroutine));
	}
}
