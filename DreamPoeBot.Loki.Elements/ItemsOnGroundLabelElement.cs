using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Elements;

public class ItemsOnGroundLabelElement : Element
{
	private readonly Lazy<long> labelInfo;

	public Element Label => ReadObjectAt<Element>(16);

	public Entity ItemOnGround => ReadObjectAt<EntityWrapper>(24);

	public bool CanPickUp => labelInfo.Value == 0L;

	public TimeSpan TimeLeft
	{
		get
		{
			if (!CanPickUp)
			{
				int num = base.M.ReadInt(labelInfo.Value + 56L);
				return TimeSpan.FromMilliseconds(num - Environment.TickCount);
			}
			return default(TimeSpan);
		}
	}

	public TimeSpan MaxTimeForPickUp
	{
		get
		{
			if (CanPickUp)
			{
				return default(TimeSpan);
			}
			return TimeSpan.FromMilliseconds(base.M.ReadInt(labelInfo.Value + 52L));
		}
	}

	public new bool IsVisible => Label.IsVisible;

	public new IEnumerable<ItemsOnGroundLabelElement> Children
	{
		get
		{
			long address = base.M.ReadLong(base.Address + 672L);
			if (address == 0L)
			{
				yield return null;
				/*Error: Unable to find new state assignment for yield return*/;
			}
			int count = 0;
			long nextAddress = base.M.ReadLong(address);
			while (nextAddress != address && nextAddress != 0L)
			{
				count++;
				if (count <= 50000)
				{
					yield return GetObject<ItemsOnGroundLabelElement>(nextAddress);
					nextAddress = base.M.ReadLong(nextAddress);
					continue;
				}
				break;
			}
		}
	}

	public ItemsOnGroundLabelElement()
	{
		labelInfo = new Lazy<long>(GetLabelInfo);
	}

	private long GetLabelInfo()
	{
		if (Label.Address == 0L)
		{
			return 0L;
		}
		return base.M.ReadLong(Label.Address + 1064L);
	}
}
