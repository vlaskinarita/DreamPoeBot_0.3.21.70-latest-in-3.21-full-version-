using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class TaskManager : TaskManagerBase<ITask>
{
	private static readonly ILog ilog_1 = Logger.GetLoggerInstanceForName("TaskManager");

	public override void Start()
	{
		foreach (ITask item in base.TaskList.ToList())
		{
			item.Start();
		}
	}

	public override void Tick()
	{
		if (!LokiPoe.IsInGame)
		{
			return;
		}
		foreach (ITask item in base.TaskList.ToList())
		{
			item.Tick();
		}
	}

	public override void Stop()
	{
		foreach (ITask item in base.TaskList.ToList())
		{
			item.Stop();
		}
	}

	public override MessageResult SendMessage(TaskGroup group, Message message)
	{
		MessageResult result = MessageResult.Unprocessed;
		foreach (ITask item in base.TaskList.ToList())
		{
			bool flag = IsEnabled(item);
			if (group != TaskGroup.Enabled)
			{
				if (group == TaskGroup.Disabled && flag)
				{
					continue;
				}
			}
			else if (!flag)
			{
				continue;
			}
			if (item.Message(message) == MessageResult.Processed)
			{
				result = MessageResult.Processed;
			}
		}
		return result;
	}

	public override async Task<LogicResult> ProvideLogic(TaskGroup group, RunBehavior behavior, Logic logic)
	{
		StringBuilder stringBuilder = new StringBuilder();
		LogicResult result = LogicResult.Unprovided;
		List<ITask> list = base.TaskList.ToList();
		foreach (ITask item in list)
		{
			bool flag = IsEnabled(item);
			if (group != TaskGroup.Enabled)
			{
				if (group == TaskGroup.Disabled && flag)
				{
					continue;
				}
			}
			else if (!flag)
			{
				continue;
			}
			if (GlobalSettings.Instance.DebugLastTask)
			{
				stringBuilder.AppendFormat("[{0}] -> ", item.Name);
			}
			if (await item.Logic(logic) == LogicResult.Provided)
			{
				result = LogicResult.Provided;
				if (behavior == RunBehavior.UntilHandled)
				{
					break;
				}
			}
		}
		if (GlobalSettings.Instance.DebugLastTask)
		{
			ilog_1.InfoFormat("[ProvideLogic] {0}.", (object)stringBuilder);
		}
		return result;
	}

	public override async Task<RunTasksResult> Run(TaskGroup group, RunBehavior behavior)
	{
		StringBuilder stringBuilder = new StringBuilder();
		RunTasksResult result = RunTasksResult.NoTasksRan;
		List<ITask> list = base.TaskList.ToList();
		foreach (ITask item in list)
		{
			bool flag = IsEnabled(item);
			if (group == TaskGroup.Enabled)
			{
				if (!flag)
				{
					continue;
				}
			}
			else if (group == TaskGroup.Disabled && flag)
			{
				continue;
			}
			if (GlobalSettings.Instance.DebugLastTask)
			{
				stringBuilder.AppendFormat("[{0}: ", item.Name);
			}
			Stopwatch sw = Stopwatch.StartNew();
			bool flag2 = await item.Run();
			sw.Stop();
			if (GlobalSettings.Instance.DebugLastTask)
			{
				stringBuilder.AppendFormat(" {0}] -> ", sw.ElapsedMilliseconds);
			}
			if (flag2)
			{
				result = RunTasksResult.TasksRan;
				if (behavior == RunBehavior.UntilHandled)
				{
					break;
				}
			}
		}
		if (GlobalSettings.Instance.DebugLastTask)
		{
			ilog_1.InfoFormat("[RunTasks] {0}.", (object)stringBuilder);
		}
		return result;
	}
}
