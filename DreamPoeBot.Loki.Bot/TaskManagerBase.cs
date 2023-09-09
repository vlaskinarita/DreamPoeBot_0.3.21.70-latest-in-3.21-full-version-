using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public abstract class TaskManagerBase<T> where T : IAuthored
{
	public delegate void TaskEvent(T task);

	[CompilerGenerated]
	private sealed class Class464
	{
		public T gparam_0;

		internal bool method_0(T gparam_1)
		{
			return smethod_0(gparam_1.Name, gparam_0.Name, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_0, string string_1, StringComparison stringComparison_0)
		{
			return string_0.Equals(string_1, stringComparison_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class465
	{
		public T gparam_0;

		internal bool method_0(T gparam_1)
		{
			return smethod_0(gparam_1.Name, gparam_0.Name, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_0, string string_1, StringComparison stringComparison_0)
		{
			return string_0.Equals(string_1, stringComparison_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class466
	{
		public T gparam_0;

		internal bool method_0(T gparam_1)
		{
			return smethod_0(gparam_1.Name, gparam_0.Name, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_0, string string_1, StringComparison stringComparison_0)
		{
			return string_0.Equals(string_1, stringComparison_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class467
	{
		public T gparam_0;

		internal bool method_0(T gparam_1)
		{
			return smethod_0(gparam_1.Name, gparam_0.Name, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_0, string string_1, StringComparison stringComparison_0)
		{
			return string_0.Equals(string_1, stringComparison_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class468
	{
		public string string_0;

		internal bool method_0(T gparam_0)
		{
			return smethod_0(gparam_0.Name, string_0, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_1, string string_2, StringComparison stringComparison_0)
		{
			return string_1.Equals(string_2, stringComparison_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class469
	{
		public string string_0;

		internal bool method_0(T gparam_0)
		{
			return smethod_0(gparam_0.Name, string_0, StringComparison.OrdinalIgnoreCase);
		}

		static bool smethod_0(string string_1, string string_2, StringComparison stringComparison_0)
		{
			return string_1.Equals(string_2, stringComparison_0);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForName(smethod_14("TaskManagerBase<", smethod_13((MemberInfo)smethod_12(typeof(T).TypeHandle)), ">"));

	private readonly List<T> list_0 = new List<T>();

	private readonly Dictionary<T, bool> dictionary_0 = new Dictionary<T, bool>();

	[CompilerGenerated]
	private TaskEvent taskEvent_0;

	[CompilerGenerated]
	private TaskEvent taskEvent_1;

	[CompilerGenerated]
	private bool bool_0;

	public bool IsFrozen { get; private set; }

	public ReadOnlyCollection<T> TaskList => list_0.AsReadOnly();

	public event TaskEvent TaskEnabled
	{
		[CompilerGenerated]
		add
		{
			TaskEvent taskEvent = taskEvent_0;
			TaskEvent taskEvent2;
			do
			{
				taskEvent2 = taskEvent;
				TaskEvent value2 = (TaskEvent)smethod_1((Delegate)taskEvent2, (Delegate)value);
				taskEvent = Interlocked.CompareExchange(ref taskEvent_0, value2, taskEvent2);
			}
			while (smethod_2((Delegate)taskEvent, (Delegate)taskEvent2));
		}
		[CompilerGenerated]
		remove
		{
			TaskEvent taskEvent = taskEvent_0;
			TaskEvent taskEvent2;
			do
			{
				taskEvent2 = taskEvent;
				TaskEvent value2 = (TaskEvent)smethod_3((Delegate)taskEvent2, (Delegate)value);
				taskEvent = Interlocked.CompareExchange(ref taskEvent_0, value2, taskEvent2);
			}
			while (smethod_2((Delegate)taskEvent, (Delegate)taskEvent2));
		}
	}

	public event TaskEvent TaskDisabled
	{
		[CompilerGenerated]
		add
		{
			TaskEvent taskEvent = taskEvent_1;
			TaskEvent taskEvent2;
			do
			{
				taskEvent2 = taskEvent;
				TaskEvent value2 = (TaskEvent)smethod_1((Delegate)taskEvent2, (Delegate)value);
				taskEvent = Interlocked.CompareExchange(ref taskEvent_1, value2, taskEvent2);
			}
			while (smethod_2((Delegate)taskEvent, (Delegate)taskEvent2));
		}
		[CompilerGenerated]
		remove
		{
			TaskEvent taskEvent = taskEvent_1;
			TaskEvent taskEvent2;
			do
			{
				taskEvent2 = taskEvent;
				TaskEvent value2 = (TaskEvent)smethod_3((Delegate)taskEvent2, (Delegate)value);
				taskEvent = Interlocked.CompareExchange(ref taskEvent_1, value2, taskEvent2);
			}
			while (smethod_2((Delegate)taskEvent, (Delegate)taskEvent2));
		}
	}

	private void method_0(T gparam_0)
	{
		if (!dictionary_0.TryGetValue(gparam_0, out var _))
		{
			dictionary_0.Add(gparam_0, value: false);
			Enable(gparam_0);
		}
	}

	public bool IsEnabled(T task)
	{
		if (dictionary_0.TryGetValue(task, out var value))
		{
			return value;
		}
		dictionary_0.Add(task, value: false);
		return false;
	}

	public void Enable(T task)
	{
		if (!IsEnabled(task))
		{
			if ((object)task is IEnableable enableable)
			{
				enableable.Enable();
			}
			dictionary_0[task] = true;
			smethod_0(task, taskEvent_0);
		}
	}

	public void Disable(T task)
	{
		if (IsEnabled(task))
		{
			if ((object)task is IEnableable enableable)
			{
				enableable.Disable();
			}
			dictionary_0[task] = false;
			smethod_0(task, taskEvent_1);
		}
	}

	private static void smethod_0(T gparam_0, TaskEvent taskEvent_2)
	{
		if (taskEvent_2 == null)
		{
			return;
		}
		try
		{
			taskEvent_2(gparam_0);
		}
		catch (Exception exception_)
		{
			smethod_4(ilog_0, (object)"[Invoke] Error during execution:", exception_);
		}
	}

	public void Freeze()
	{
		if (IsFrozen)
		{
			smethod_5(ilog_0, "[Freeze] This TaskManagerBase has already been frozen.", Array.Empty<object>());
		}
		IsFrozen = true;
	}

	public bool AddBefore(T task, string name)
	{
		if (task == null)
		{
			throw smethod_6("task");
		}
		if (name != null)
		{
			if (!IsFrozen)
			{
				if (!list_0.Any((T gparam_1) => Class464.smethod_0(gparam_1.Name, task.Name, StringComparison.OrdinalIgnoreCase)))
				{
					int num = 0;
					while (true)
					{
						if (num < list_0.Count)
						{
							if (smethod_9(list_0[num].Name, name, StringComparison.OrdinalIgnoreCase))
							{
								break;
							}
							num++;
							continue;
						}
						return false;
					}
					list_0.Insert(num, task);
					method_0(task);
					return true;
				}
				smethod_8(ilog_0, "[AddBefore] A task with the name of [{0}] has already been added.", (object)task.Name);
				return false;
			}
			smethod_7(ilog_0, "[AddBefore] This TaskManagerBase is frozen.", Array.Empty<object>());
			return false;
		}
		throw smethod_6("name");
	}

	public bool AddAfter(T task, string name)
	{
		if (task == null)
		{
			throw smethod_6("task");
		}
		if (name == null)
		{
			throw smethod_6("name");
		}
		if (!IsFrozen)
		{
			if (!list_0.Any((T gparam_1) => Class465.smethod_0(gparam_1.Name, task.Name, StringComparison.OrdinalIgnoreCase)))
			{
				int num = 0;
				while (true)
				{
					if (num < list_0.Count)
					{
						if (smethod_9(list_0[num].Name, name, StringComparison.OrdinalIgnoreCase))
						{
							break;
						}
						num++;
						continue;
					}
					return false;
				}
				list_0.Insert(num + 1, task);
				method_0(task);
				return true;
			}
			smethod_8(ilog_0, "[AddAfter] A task with the name of {0} has already been added.", (object)task.Name);
			return false;
		}
		smethod_7(ilog_0, "[AddAfter] This TaskManagerBase is frozen.", Array.Empty<object>());
		return false;
	}

	public bool SwapTasks(string name1, string name2)
	{
		if (name1 == null)
		{
			throw smethod_6("name1");
		}
		if (name2 != null)
		{
			if (!IsFrozen)
			{
				int num = -1;
				int num2 = -1;
				for (int i = 0; i < list_0.Count; i++)
				{
					if (num != -1)
					{
						break;
					}
					if (num2 != -1)
					{
						break;
					}
					if (!smethod_9(list_0[i].Name, name1, StringComparison.OrdinalIgnoreCase))
					{
						if (smethod_9(list_0[i].Name, name2, StringComparison.OrdinalIgnoreCase))
						{
							num2 = i;
						}
					}
					else
					{
						num = i;
					}
				}
				if (num != -1 && num2 != -1 && num != num2)
				{
					T value = list_0[num];
					list_0[num] = list_0[num2];
					list_0[num2] = value;
					return true;
				}
				smethod_7(ilog_0, "[SwapTasks] A task could not be found, or both tasks are the same.", Array.Empty<object>());
				return false;
			}
			smethod_7(ilog_0, "[SwapTasks] This TaskManagerBase is frozen.", Array.Empty<object>());
			return false;
		}
		throw smethod_6("name2");
	}

	public bool Add(T task)
	{
		if (task != null)
		{
			if (IsFrozen)
			{
				smethod_7(ilog_0, "[Add] This TaskManagerBase is frozen.", Array.Empty<object>());
				return false;
			}
			if (!list_0.Any((T gparam_1) => Class466.smethod_0(gparam_1.Name, task.Name, StringComparison.OrdinalIgnoreCase)))
			{
				smethod_10(ilog_0, "[Add] Now adding [{0}] {1}.", (object)task.Name, (object)task.Description);
				list_0.Add(task);
				method_0(task);
				return true;
			}
			smethod_8(ilog_0, "[Add] A task with the name of {0} has already been added. This one will be skipped.", (object)task.Name);
			return false;
		}
		throw smethod_6("task");
	}

	public bool AddAtFront(T task)
	{
		if (task == null)
		{
			throw smethod_6("task");
		}
		if (!IsFrozen)
		{
			if (!list_0.Any((T gparam_1) => Class467.smethod_0(gparam_1.Name, task.Name, StringComparison.OrdinalIgnoreCase)))
			{
				smethod_10(ilog_0, "[AddAtFront] Now adding [{0}] {1}.", (object)task.Name, (object)task.Description);
				list_0.Insert(0, task);
				method_0(task);
				return true;
			}
			smethod_8(ilog_0, "[AddAtFront] A task with the name of {0} has already been added. This one will be skipped.", (object)task.Name);
			return false;
		}
		smethod_7(ilog_0, "[AddAtFront] This TaskManagerBase is frozen.", Array.Empty<object>());
		return false;
	}

	public bool Remove(string name)
	{
		if (name != null)
		{
			if (IsFrozen)
			{
				smethod_7(ilog_0, "[Remove] This TaskManagerBase is frozen.", Array.Empty<object>());
				return false;
			}
			T val = list_0.FirstOrDefault((T gparam_0) => Class468.smethod_0(gparam_0.Name, name, StringComparison.OrdinalIgnoreCase));
			if (val == null)
			{
				smethod_8(ilog_0, "[Remove] A task with the name of {0} does not exist.", (object)name);
				return false;
			}
			smethod_11(ilog_0, "[Remove] Now removing [{0}].", (object)val.Name);
			list_0.Remove(val);
			return true;
		}
		throw smethod_6("name");
	}

	public T GetTaskByName(string name)
	{
		return list_0.FirstOrDefault((T gparam_0) => Class469.smethod_0(gparam_0.Name, name, StringComparison.OrdinalIgnoreCase));
	}

	public bool Replace(string name, T task)
	{
		if (task == null)
		{
			throw smethod_6("task");
		}
		if (name != null)
		{
			if (!IsFrozen)
			{
				for (int i = 0; i < list_0.Count; i++)
				{
					if (!smethod_9(list_0[i].Name, name, StringComparison.OrdinalIgnoreCase))
					{
						continue;
					}
					for (int j = 0; j < list_0.Count; j++)
					{
						if (j != i && smethod_9(list_0[j].Name, task.Name, StringComparison.OrdinalIgnoreCase))
						{
							smethod_8(ilog_0, "[Replace] A task with the name of {0} has already been registered.", (object)task.Name);
							return false;
						}
					}
					smethod_10(ilog_0, "[Replace] Now replacing task [{0}] with [{1}].", (object)name, (object)task.Name);
					list_0[i] = task;
					method_0(task);
					return true;
				}
				smethod_8(ilog_0, "[Replace] A task with the name of {0} was not found.", (object)name);
				return false;
			}
			smethod_7(ilog_0, "[Replace] This TaskManagerBase is frozen.", Array.Empty<object>());
			return false;
		}
		throw smethod_6("name");
	}

	public abstract void Start();

	public abstract void Tick();

	public abstract void Stop();

	public void Reset()
	{
		list_0.Clear();
		IsFrozen = false;
		dictionary_0.Clear();
	}

	public abstract MessageResult SendMessage(TaskGroup group, Message message);

	public abstract Task<RunTasksResult> Run(TaskGroup group, RunBehavior behavior);

	public abstract Task<LogicResult> ProvideLogic(TaskGroup group, RunBehavior behavior, Logic logic);

	static Delegate smethod_1(Delegate delegate_0, Delegate delegate_1)
	{
		return Delegate.Combine(delegate_0, delegate_1);
	}

	static bool smethod_2(Delegate delegate_0, Delegate delegate_1)
	{
		return delegate_0 != delegate_1;
	}

	static Delegate smethod_3(Delegate delegate_0, Delegate delegate_1)
	{
		return Delegate.Remove(delegate_0, delegate_1);
	}

	static void smethod_4(ILog ilog_1, object object_0, Exception exception_0)
	{
		ilog_1.Error(object_0, exception_0);
	}

	static void smethod_5(ILog ilog_1, string string_0, object[] object_0)
	{
		ilog_1.WarnFormat(string_0, object_0);
	}

	static ArgumentNullException smethod_6(string string_0)
	{
		return new ArgumentNullException(string_0);
	}

	static void smethod_7(ILog ilog_1, string string_0, object[] object_0)
	{
		ilog_1.ErrorFormat(string_0, object_0);
	}

	static void smethod_8(ILog ilog_1, string string_0, object object_0)
	{
		ilog_1.ErrorFormat(string_0, object_0);
	}

	static bool smethod_9(string string_0, string string_1, StringComparison stringComparison_0)
	{
		return string_0.Equals(string_1, stringComparison_0);
	}

	static void smethod_10(ILog ilog_1, string string_0, object object_0, object object_1)
	{
		ilog_1.DebugFormat(string_0, object_0, object_1);
	}

	static void smethod_11(ILog ilog_1, string string_0, object object_0)
	{
		ilog_1.DebugFormat(string_0, object_0);
	}

	static Type smethod_12(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		return Type.GetTypeFromHandle(runtimeTypeHandle_0);
	}

	static string smethod_13(MemberInfo memberInfo_0)
	{
		return memberInfo_0.Name;
	}

	static string smethod_14(string string_0, string string_1, string string_2)
	{
		return string_0 + string_1 + string_2;
	}
}
