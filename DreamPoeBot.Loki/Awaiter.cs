using System;
using System.Threading.Tasks;

namespace DreamPoeBot.Loki;

public static class Awaiter
{
	public static bool Await(Task task, int time)
	{
		try
		{
			return task.Wait(time);
		}
		catch (AggregateException)
		{
			task.GetAwaiter().GetResult();
			throw;
		}
	}
}
