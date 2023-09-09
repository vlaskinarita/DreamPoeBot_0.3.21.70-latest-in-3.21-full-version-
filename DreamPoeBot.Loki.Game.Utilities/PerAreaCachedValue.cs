using System;

namespace DreamPoeBot.Loki.Game.Utilities;

public class PerAreaCachedValue<T> : PerCachedValue<T>
{
	private uint staredAreaHash = uint.MaxValue;

	public PerAreaCachedValue(Func<T> producer)
		: base(producer)
	{
	}

	protected override bool ShouldUpdateCache(bool force = false)
	{
		uint areaHash = LokiPoe.LocalData.AreaHash;
		if (!(staredAreaHash != areaHash || force))
		{
			return false;
		}
		staredAreaHash = areaHash;
		return true;
	}
}
