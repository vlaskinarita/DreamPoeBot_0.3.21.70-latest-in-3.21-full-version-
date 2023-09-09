using System.Runtime.CompilerServices;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class DefaultItemEvaluator : IItemEvaluator
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	[CompilerGenerated]
	private static readonly DefaultItemEvaluator defaultItemEvaluator_0;

	public string Name => "DefaultItemEvaluator";

	public static DefaultItemEvaluator Instance { get; } = new DefaultItemEvaluator();


	public bool Match(Item item, EvaluationType type)
	{
		if (type == EvaluationType.PickUp)
		{
			return item.Rarity == Rarity.Quest;
		}
		return false;
	}
}
