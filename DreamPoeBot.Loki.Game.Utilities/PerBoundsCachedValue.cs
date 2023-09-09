using System;
using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Game.Utilities;

public class PerBoundsCachedValue<T> : PerCachedValue<T>
{
	private Vector2i vector2i_0;

	private Vector2i vector2i_1;

	public PerBoundsCachedValue(Func<T> producer, Vector2i size)
		: base(producer)
	{
		vector2i_0 = size;
		vector2i_1 = Vector2i.Zero;
	}

	protected override bool ShouldUpdateCache(bool force = false)
	{
		Vector2i myPosition = LokiPoe.LocalData.MyPosition;
		if (!(vector2i_1 == Vector2i.Zero || myPosition.X < vector2i_1.X - vector2i_0.X || myPosition.X > vector2i_1.X + vector2i_0.X || myPosition.Y < vector2i_1.Y - vector2i_0.Y || myPosition.Y > vector2i_1.Y + vector2i_0.Y || force))
		{
			return false;
		}
		vector2i_1 = myPosition;
		return true;
	}
}
