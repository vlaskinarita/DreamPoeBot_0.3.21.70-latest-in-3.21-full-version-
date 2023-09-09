using System;
using System.Threading;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public static class ItemEvaluator
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private static IItemEvaluator iitemEvaluator_0;

	private static EventHandler<ItemEvaluatorRefreshedEventArgs> eventHandler_0;

	public static IItemEvaluator Instance
	{
		get
		{
			return iitemEvaluator_0;
		}
		set
		{
			iitemEvaluator_0 = value;
			ilog_0.InfoFormat("[ItemEvaluator] Instance = {0}.", (object)iitemEvaluator_0.GetType());
		}
	}

	public static event EventHandler<ItemEvaluatorRefreshedEventArgs> OnRefreshed
	{
		add
		{
			EventHandler<ItemEvaluatorRefreshedEventArgs> eventHandler = eventHandler_0;
			EventHandler<ItemEvaluatorRefreshedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ItemEvaluatorRefreshedEventArgs> value2 = (EventHandler<ItemEvaluatorRefreshedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
		remove
		{
			EventHandler<ItemEvaluatorRefreshedEventArgs> eventHandler = eventHandler_0;
			EventHandler<ItemEvaluatorRefreshedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<ItemEvaluatorRefreshedEventArgs> value2 = (EventHandler<ItemEvaluatorRefreshedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while (eventHandler != eventHandler2);
		}
	}

	public static bool Match(Item item, EvaluationType type)
	{
		if (Instance == null)
		{
			ilog_0.ErrorFormat("[ItemEvaluator] Instance == null", Array.Empty<object>());
			return false;
		}
		return Instance.Match(item, type);
	}

	public static void Refresh()
	{
		if (eventHandler_0 != null)
		{
			LokiPoe.InvokeEvent(eventHandler_0, null, new ItemEvaluatorRefreshedEventArgs());
		}
	}
}
