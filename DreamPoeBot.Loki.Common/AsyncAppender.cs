using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace DreamPoeBot.Loki.Common;

public sealed class AsyncAppender : IAppender, IBulkAppender, IOptionHandler, IAppenderAttachable
{
	private class Class396
	{
		internal object object_0;

		internal ConcurrentQueue<object> concurrentQueue_0;

		internal AppenderAttachedImpl appenderAttachedImpl_0;
	}

	private AppenderAttachedImpl appenderAttachedImpl_0;

	private FixFlags fixFlags_0 = (FixFlags)268435455;

	private Func<int> func_0;

	private string string_1 = "";

	private Stopwatch stopwatch_0 = Stopwatch.StartNew();

	private readonly ConcurrentQueue<object> concurrentQueue_0 = new ConcurrentQueue<object>();

	private readonly object object_0 = new object();

	public FixFlags Fix
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return fixFlags_0;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			fixFlags_0 = value;
		}
	}

	public string Name { get; set; }

	public AppenderCollection Appenders
	{
		get
		{
			lock (this)
			{
				if (appenderAttachedImpl_0 == null)
				{
					return AppenderCollection.EmptyCollection;
				}
				return appenderAttachedImpl_0.Appenders;
			}
		}
	}

	public AsyncAppender(Func<int> getDropRepeatMessageDelayMs)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (getDropRepeatMessageDelayMs == null)
		{
			throw new ArgumentNullException("getDropRepeatMessageDelayMs");
		}
		func_0 = getDropRepeatMessageDelayMs;
	}

	public void Close()
	{
		lock (this)
		{
			AppenderAttachedImpl val = appenderAttachedImpl_0;
			if (val != null)
			{
				val.RemoveAllAppenders();
			}
		}
	}

	public void DoAppend(LoggingEvent loggingEvent)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		int num = func_0();
		Class396 @class = new Class396();
		lock (this)
		{
			if (string_1 == loggingEvent.RenderedMessage && num > 0 && stopwatch_0.ElapsedMilliseconds < num)
			{
				return;
			}
			string_1 = loggingEvent.RenderedMessage;
			stopwatch_0.Restart();
			loggingEvent.Fix = fixFlags_0;
			concurrentQueue_0.Enqueue(loggingEvent);
			@class.appenderAttachedImpl_0 = appenderAttachedImpl_0;
			@class.object_0 = object_0;
			@class.concurrentQueue_0 = concurrentQueue_0;
		}
		ThreadPool.QueueUserWorkItem(smethod_0, @class);
	}

	public void AddAppender(IAppender newAppender)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		if (newAppender == null)
		{
			throw new ArgumentNullException("newAppender");
		}
		lock (this)
		{
			if (appenderAttachedImpl_0 == null)
			{
				appenderAttachedImpl_0 = new AppenderAttachedImpl();
			}
			appenderAttachedImpl_0.AddAppender(newAppender);
		}
	}

	public IAppender GetAppender(string name)
	{
		lock (this)
		{
			if (appenderAttachedImpl_0 != null && name != null)
			{
				return appenderAttachedImpl_0.GetAppender(name);
			}
			return null;
		}
	}

	public void RemoveAllAppenders()
	{
		lock (this)
		{
			if (appenderAttachedImpl_0 != null)
			{
				appenderAttachedImpl_0.RemoveAllAppenders();
				appenderAttachedImpl_0 = null;
			}
		}
	}

	public IAppender RemoveAppender(IAppender appender)
	{
		lock (this)
		{
			if (appender != null && appenderAttachedImpl_0 != null)
			{
				return appenderAttachedImpl_0.RemoveAppender(appender);
			}
		}
		return null;
	}

	public IAppender RemoveAppender(string name)
	{
		lock (this)
		{
			if (name != null && appenderAttachedImpl_0 != null)
			{
				return appenderAttachedImpl_0.RemoveAppender(name);
			}
		}
		return null;
	}

	public void DoAppend(LoggingEvent[] loggingEvents)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		int num = func_0();
		Class396 @class = new Class396();
		lock (this)
		{
			foreach (LoggingEvent val in loggingEvents)
			{
				if (!(string_1 == val.RenderedMessage) || num <= 0 || stopwatch_0.ElapsedMilliseconds >= num)
				{
					string_1 = val.RenderedMessage;
					stopwatch_0.Restart();
					val.Fix = fixFlags_0;
					concurrentQueue_0.Enqueue(val);
				}
			}
			@class.appenderAttachedImpl_0 = appenderAttachedImpl_0;
			@class.object_0 = object_0;
			@class.concurrentQueue_0 = concurrentQueue_0;
		}
		ThreadPool.QueueUserWorkItem(smethod_0, @class);
	}

	public void ActivateOptions()
	{
	}

	private static void smethod_0(object object_1)
	{
		if (!(object_1 is Class396 @class) || @class.appenderAttachedImpl_0 == null)
		{
			return;
		}
		object obj = @class.object_0;
		lock (obj)
		{
			object result;
			while (@class.concurrentQueue_0.TryDequeue(out result))
			{
				try
				{
					LoggingEvent val = (LoggingEvent)((result is LoggingEvent) ? result : null);
					if (val != null)
					{
						@class.appenderAttachedImpl_0.AppendLoopOnAppenders(val);
					}
					else if (result is LoggingEvent[] array)
					{
						@class.appenderAttachedImpl_0.AppendLoopOnAppenders(array);
					}
				}
				catch (Exception)
				{
					break;
				}
			}
		}
	}
}
