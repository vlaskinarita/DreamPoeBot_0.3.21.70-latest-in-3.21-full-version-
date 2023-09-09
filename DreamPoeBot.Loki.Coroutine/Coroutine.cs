using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DreamPoeBot.Loki.Coroutine;

public sealed class Coroutine : IDisposable
{
	private class Class66 : INotifyCompletion
	{
		public bool Boolean_0 { get; set; }

		public bool Boolean_1 => false;

		public Class66 method_0()
		{
			return this;
		}

		public void method_1()
		{
			if (Boolean_0)
			{
				throw smethod_1();
			}
		}

		public void OnCompleted(Action continuation)
		{
			Current.action_0 = continuation;
		}
	}

	private sealed class Class67
	{
		public Func<Task<object>> func_0;

		public Coroutine coroutine_0;

		internal void method_0()
		{
			Task<object> task;
			try
			{
				task = func_0();
			}
			catch (Exception innerException)
			{
				throw coroutine_0.method_1(new CoroutineUnhandledException("Exception was thrown by root coroutine task producer", innerException));
			}
			if (task == null)
			{
				throw coroutine_0.method_1(new CoroutineBehaviorException("The root coroutine task producer returned null"));
			}
			coroutine_0.task_0 = task;
		}
	}

	private struct Struct15 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			int num = int_0;
			try
			{
				Class66 awaiter;
				if (num == 0)
				{
					awaiter = (Class66)object_0;
					object_0 = null;
					num = -1;
					int_0 = -1;
				}
				else
				{
					awaiter = Current.class66_0.method_0();
					if (!awaiter.Boolean_1)
					{
						num = 0;
						int_0 = 0;
						object_0 = awaiter;
						asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
						return;
					}
				}
				awaiter.method_1();
				awaiter = null;
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult();
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private struct Struct16 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public TimeSpan timeSpan_0;

		private Stopwatch stopwatch_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			int num = int_0;
			Class66 awaiter;
			if (num == 0)
			{
				awaiter = (Class66)object_0;
				object_0 = null;
				int_0 = -1;
				goto IL_005b;
			}
			if (num == 1)
			{
				awaiter = (Class66)object_0;
				object_0 = null;
				int_0 = -1;
				goto IL_00c1;
			}
			if (!(timeSpan_0 != Timeout.InfiniteTimeSpan))
			{
				goto IL_007c;
			}
			stopwatch_0 = Stopwatch.StartNew();
			goto IL_00df;
			IL_007c:
			awaiter = Current.class66_0.method_0();
			if (awaiter.Boolean_1)
			{
				goto IL_005b;
			}
			int_0 = 0;
			object_0 = awaiter;
			asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
			return;
			IL_005b:
			try
			{
				awaiter.method_1();
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			goto IL_007c;
			IL_00c1:
			awaiter.method_1();
			if (stopwatch_0.Elapsed >= timeSpan_0)
			{
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetResult();
				return;
			}
			goto IL_00df;
			IL_00df:
			awaiter = Current.class66_0.method_0();
			if (!awaiter.Boolean_1)
			{
				int_0 = 1;
				object_0 = awaiter;
				asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
				return;
			}
			goto IL_00c1;
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private struct Struct17 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder_0;

		public TimeSpan timeSpan_0;

		public Func<bool> func_0;

		private Stopwatch stopwatch_0;

		private object object_0;

		void IAsyncStateMachine.MoveNext()
		{
			bool flag = false;
			int num = int_0;
			Class66 awaiter;
			if (num == 0)
			{
				awaiter = (Class66)object_0;
				object_0 = null;
				num = -1;
				int_0 = -1;
				goto IL_009f;
			}
			if (num != 1)
			{
				if (!(timeSpan_0 != TimeSpan.Zero))
				{
					flag = func_0();
					int_0 = -2;
					asyncTaskMethodBuilder_0.SetResult(flag);
					return;
				}
				if (timeSpan_0 == Timeout.InfiniteTimeSpan)
				{
					goto IL_00c4;
				}
				stopwatch_0 = Stopwatch.StartNew();
				goto IL_0128;
			}
			awaiter = (Class66)object_0;
			object_0 = null;
			num = -1;
			int_0 = -1;
			goto IL_014d;
			IL_014d:
			awaiter.method_1();
			awaiter = null;
			if (!(stopwatch_0.Elapsed >= timeSpan_0))
			{
				goto IL_0128;
			}
			flag = false;
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result: false);
			return;
			IL_0128:
			if (!func_0())
			{
				awaiter = Current.class66_0.method_0();
				if (!awaiter.Boolean_1)
				{
					num = 1;
					int_0 = 1;
					object_0 = awaiter;
					asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_014d;
			}
			flag = true;
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result: true);
			return;
			IL_00c4:
			if (!func_0())
			{
				awaiter = Current.class66_0.method_0();
				if (!awaiter.Boolean_1)
				{
					num = 0;
					int_0 = 0;
					object_0 = awaiter;
					asyncTaskMethodBuilder_0.AwaitOnCompleted(ref awaiter, ref this);
					return;
				}
				goto IL_009f;
			}
			flag = true;
			int_0 = -2;
			asyncTaskMethodBuilder_0.SetResult(result: true);
			return;
			IL_009f:
			try
			{
				awaiter.method_1();
				awaiter = null;
			}
			catch (Exception ex)
			{
				Exception exception = ex;
				int_0 = -2;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			goto IL_00c4;
		}

		[DebuggerHidden]
		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}
	}

	private readonly Class66 class66_0 = new Class66();

	private Task<object> task_0;

	private Action action_0;

	[ThreadStatic]
	private static Coroutine coroutine_0;

	public static Coroutine Current => coroutine_0;

	public CoroutineException FaultingException { get; private set; }

	public bool IsDisposed { get; private set; }

	public bool IsFinished
	{
		get
		{
			if (Status != CoroutineStatus.RanToCompletion && Status != CoroutineStatus.Faulted)
			{
				return Status == CoroutineStatus.Stopped;
			}
			return true;
		}
	}

	public object Result { get; private set; }

	public CoroutineStatus Status { get; private set; }

	public int Ticks { get; private set; }

	public Coroutine(Func<Task> taskProducer)
		: this(smethod_0(taskProducer))
	{
	}

	public Coroutine(Func<Task<object>> taskProducer)
	{
		Coroutine coroutine = this;
		if (taskProducer == null)
		{
			throw new ArgumentNullException("taskProducer");
		}
		action_0 = delegate
		{
			Task<object> task;
			try
			{
				task = taskProducer();
			}
			catch (Exception innerException)
			{
				throw coroutine.method_1(new CoroutineUnhandledException("Exception was thrown by root coroutine task producer", innerException));
			}
			if (task == null)
			{
				throw coroutine.method_1(new CoroutineBehaviorException("The root coroutine task producer returned null"));
			}
			coroutine.task_0 = task;
		};
		Status = CoroutineStatus.Runnable;
	}

	public void Dispose()
	{
		if (IsDisposed)
		{
			return;
		}
		if (Current != this)
		{
			if (Status == CoroutineStatus.Runnable)
			{
				if (task_0 != null)
				{
					class66_0.Boolean_0 = true;
					method_0(bool_1: true);
				}
				else
				{
					action_0 = null;
				}
			}
			IsDisposed = true;
			return;
		}
		IsDisposed = true;
		throw smethod_1();
	}

	public static Task ExternalTask(Func<Task> taskProducer)
	{
		if (taskProducer == null)
		{
			throw new ArgumentNullException("taskProducer");
		}
		Task task = taskProducer();
		if (task == null)
		{
			throw new ArgumentException("The task producer returned null", "taskProducer");
		}
		return ExternalTask(task);
	}

	public static Task ExternalTask(Task externalTask)
	{
		return smethod_6(externalTask, Timeout.InfiniteTimeSpan);
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<bool> ExternalTask(Task externalTask, TimeSpan timeout)
	{
		return smethod_6(externalTask, timeout);
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<bool> ExternalTask(Task externalTask, int millisecondsTimeout)
	{
		if (millisecondsTimeout != -1 && millisecondsTimeout < 0)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeout", "Timeout cannot be negative");
		}
		return smethod_6(externalTask, new TimeSpan(0, 0, 0, 0, millisecondsTimeout));
	}

	public static Task<T> ExternalTask<T>(Func<Task<T>> taskProducer)
	{
		if (taskProducer == null)
		{
			throw new ArgumentNullException("taskProducer");
		}
		Task<T> task = taskProducer();
		if (task == null)
		{
			throw new ArgumentException("The task producer returned null", "taskProducer");
		}
		return ExternalTask(task);
	}

	public static Task<T> ExternalTask<T>(Task<T> externalTask)
	{
		return smethod_8(smethod_9(externalTask, Timeout.InfiniteTimeSpan));
	}

	[Obsolete("Timeouts should be handled in the external task, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<ExternalTaskWaitResult<T>> ExternalTask<T>(Task<T> externalTask, int millisecondsTimeout)
	{
		if (millisecondsTimeout < 0 && millisecondsTimeout != -1)
		{
			throw new ArgumentOutOfRangeException("millisecondsTimeout", "Timeout cannot be negative");
		}
		return smethod_9(externalTask, new TimeSpan(0, 0, 0, 0, millisecondsTimeout));
	}

	[Obsolete("Timeouts should be handled in the external taks, not by this method. Use the overloads with infinite timeouts instead.")]
	public static Task<ExternalTaskWaitResult<T>> ExternalTask<T>(Task<T> externalTask, TimeSpan timeout)
	{
		return smethod_9(externalTask, timeout);
	}

	public void Resume()
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
		if (!IsFinished)
		{
			if (coroutine_0 == this)
			{
				throw new InvalidOperationException("A coroutine cannot resume itself");
			}
			method_0(bool_1: false);
			return;
		}
		throw new InvalidOperationException("This coroutine has finished execution and cannot be resumed.");
	}

	private void method_0(bool bool_1)
	{
		SynchronizationContext current = SynchronizationContext.Current;
		Coroutine coroutine = coroutine_0;
		try
		{
			coroutine_0 = this;
			SynchronizationContext.SetSynchronizationContext(null);
			Action action = action_0;
			action_0 = null;
			action();
			if (!bool_1)
			{
				Ticks++;
			}
			method_2(bool_1);
		}
		finally
		{
			coroutine_0 = coroutine;
			SynchronizationContext.SetSynchronizationContext(current);
		}
	}

	private void method_2(bool bool_1)
	{
		switch (task_0.Status)
		{
		default:
			throw method_1(new CoroutineBehaviorException("Unexpected task status " + task_0.Status));
		case TaskStatus.WaitingForActivation:
			if (!bool_1)
			{
				if (action_0 == null)
				{
					throw method_1(new CoroutineBehaviorException("No continuation was queued and coroutine didn't finish. This is usually an indication that an external task was awaited, which is not supported by coroutines."));
				}
				break;
			}
			throw method_1(new CoroutineBehaviorException("The coroutine could not successfully be disposed of. This is usually an indication that the CoroutineStoppedException was caught."));
		case TaskStatus.WaitingToRun:
		case TaskStatus.Running:
		case TaskStatus.WaitingForChildrenToComplete:
			throw method_1(new CoroutineBehaviorException("Unexpected task status " + task_0.Status));
		case TaskStatus.RanToCompletion:
			if (action_0 == null)
			{
				Status = CoroutineStatus.RanToCompletion;
				Result = task_0.Result;
				break;
			}
			throw method_1(new CoroutineBehaviorException("The coroutine finished with a continuation queued. This is usually an indication that a task was created but not awaited."));
		case TaskStatus.Canceled:
			try
			{
				task_0.Wait(0);
				throw method_1(new CoroutineBehaviorException("Coroutine was canceled without any exceptions"));
			}
			catch (Exception innerException)
			{
				throw method_1(new CoroutineUnhandledException("Exception was thrown by coroutine", innerException));
			}
		case TaskStatus.Faulted:
		{
			Exception ex = task_0.Exception.InnerExceptions.FirstOrDefault();
			if (!(ex is CoroutineStoppedException))
			{
				throw method_1(new CoroutineUnhandledException("Exception was thrown by coroutine", ex));
			}
			Status = CoroutineStatus.Stopped;
			break;
		}
		}
	}

	private Exception method_1(CoroutineException coroutineException_1)
	{
		Status = CoroutineStatus.Faulted;
		FaultingException = coroutineException_1;
		return coroutineException_1;
	}

	public static Task Sleep(TimeSpan timeout)
	{
		if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		smethod_2();
		return smethod_4(timeout);
	}

	public static Task Sleep(int milliseconds)
	{
		if (milliseconds < 0 && milliseconds != -1)
		{
			throw new ArgumentOutOfRangeException("milliseconds");
		}
		return Sleep(new TimeSpan(0, 0, 0, 0, milliseconds));
	}

	private static Func<Task<object>> smethod_0(Func<Task> func_0)
	{
		return async delegate
		{
			await func_0();
			return null;
		};
	}

	internal static Exception smethod_1()
	{
		return new CoroutineStoppedException("Coroutine was stopped");
	}

	private static async Task<ExternalTaskWaitResult<T>> smethod_10<T>(Task<T> task_1, TimeSpan timeSpan_0)
	{
		return (!(await smethod_7(task_1, timeSpan_0))) ? ExternalTaskWaitResult<T>.externalTaskWaitResult_0 : ExternalTaskWaitResult<T>.smethod_0(task_1.Result);
	}

	private static async Task smethod_4(TimeSpan timeSpan_0)
	{
		Struct16 stateMachine = default(Struct16);
		stateMachine.timeSpan_0 = timeSpan_0;
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		await stateMachine.asyncTaskMethodBuilder_0.Task;
	}

	private static async Task<bool> smethod_5(TimeSpan timeSpan_0, Func<bool> func_0)
	{
		Struct17 stateMachine = default(Struct17);
		stateMachine.timeSpan_0 = timeSpan_0;
		stateMachine.func_0 = func_0;
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder<bool>.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		return await stateMachine.asyncTaskMethodBuilder_0.Task;
	}

	private static Task<bool> smethod_6(Task task_1, TimeSpan timeSpan_0)
	{
		if (task_1 == null)
		{
			throw new ArgumentNullException("externalTask");
		}
		if (timeSpan_0 < TimeSpan.Zero && timeSpan_0 != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException("timeout");
		}
		smethod_2();
		return smethod_7(task_1, timeSpan_0);
	}

	private static async Task<bool> smethod_7(Task task, TimeSpan timeSpan)
	{
		bool result;
		if (timeSpan == TimeSpan.Zero)
		{
			result = Awaiter.Await(task, 0);
		}
		else if (!(timeSpan == Timeout.InfiniteTimeSpan))
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			while (Awaiter.Await(task, 0))
			{
				if (!(stopwatch.Elapsed < timeSpan))
				{
					return false;
				}
				await Current.task_0;
			}
			result = true;
		}
		else
		{
			while (Awaiter.Await(task, 0))
			{
				await Current.task_0;
			}
			result = true;
		}
		return result;
	}

	private static async Task<T> smethod_8<T>(Task<ExternalTaskWaitResult<T>> task_1)
	{
		return (await task_1).Result;
	}

	private static Task<ExternalTaskWaitResult<T>> smethod_9<T>(Task<T> task_1, TimeSpan timeSpan_0)
	{
		if (task_1 == null)
		{
			throw new ArgumentNullException("externalTask");
		}
		if (timeSpan_0 < TimeSpan.Zero && timeSpan_0 != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException("timeout", "Timeout cannot be negative");
		}
		smethod_2();
		return smethod_10(task_1, timeSpan_0);
	}

	public override string ToString()
	{
		switch (Status)
		{
		default:
			return "Invalid state";
		case CoroutineStatus.Runnable:
			return "Runnable";
		case CoroutineStatus.RanToCompletion:
			if (Result == null)
			{
				return "Ran to completion";
			}
			return "Ran to completion. Result: " + Result;
		case CoroutineStatus.Stopped:
			return "Stopped";
		case CoroutineStatus.Faulted:
			if (FaultingException != null)
			{
				return "Faulted with exception " + FaultingException.InnerException.GetType();
			}
			return "Faulted";
		}
	}

	public static Task<bool> Wait(TimeSpan maxWaitTimeout, Func<bool> condition)
	{
		if (maxWaitTimeout < TimeSpan.Zero && maxWaitTimeout != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException("maxWaitTimeout", "Cannot wait for a negative timespan");
		}
		if (condition == null)
		{
			throw new ArgumentNullException("condition");
		}
		smethod_2();
		return smethod_5(maxWaitTimeout, condition);
	}

	public static Task<bool> Wait(int maxWaitMs, Func<bool> condition)
	{
		if (maxWaitMs < 0 && maxWaitMs != -1)
		{
			throw new ArgumentOutOfRangeException("maxWaitMs", "Cannot wait for a negative amount of time");
		}
		return Wait(new TimeSpan(0, 0, 0, 0, maxWaitMs), condition);
	}

	public static Task Yield()
	{
		smethod_2();
		return smethod_3();
	}

	private static void smethod_2()
	{
		if (coroutine_0 == null)
		{
			throw new InvalidOperationException("This function can only be used from within a coroutine");
		}
		if (coroutine_0.action_0 != null)
		{
			throw new InvalidOperationException("Cannot obtain multiple coroutine tasks in a single coroutine tick. This is usually an indication that a coroutine task was created but not awaited.");
		}
	}

	private static async Task smethod_3()
	{
		Struct15 stateMachine = default(Struct15);
		stateMachine.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
		stateMachine.int_0 = -1;
		stateMachine.asyncTaskMethodBuilder_0.Start(ref stateMachine);
		await stateMachine.asyncTaskMethodBuilder_0.Task;
	}
}
