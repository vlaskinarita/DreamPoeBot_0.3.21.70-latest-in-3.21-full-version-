using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Elements;

public class SingleSlotUiElement : Element
{
	public enum SingleSlotType
	{
		inventory,
		Currency,
		Essence,
		Card,
		Fragment,
		Map,
		ExplorationLocker,
		FiveSlotMapDevice,
		BlightTabMap,
		MapDevice,
		RogueMarker
	}

	private SingleSlotType SlotType;

	private static int id_offset = 776;

	private static int item_offset = 880;

	private float SlotSize
	{
		get
		{
			switch (SlotType)
			{
			case SingleSlotType.inventory:
			case SingleSlotType.Currency:
			case SingleSlotType.Essence:
			case SingleSlotType.Card:
			case SingleSlotType.Fragment:
			case SingleSlotType.Map:
			case SingleSlotType.ExplorationLocker:
			case SingleSlotType.FiveSlotMapDevice:
				return 78f;
			case SingleSlotType.BlightTabMap:
				return 70.5f;
			default:
				throw new ArgumentOutOfRangeException();
			case SingleSlotType.RogueMarker:
				return 75f;
			}
		}
	}

	public Item Item
	{
		get
		{
			Vector2i locationTopLeft = new Vector2i(0, 0);
			if (SlotType == SingleSlotType.Card)
			{
				Element element = base.Children[1];
				if ((object)element != null && element.ChildCount < 1L)
				{
					return null;
				}
				Element element2 = base.Children[1];
				if ((object)element2 != null && element2.ChildCount < 2L)
				{
					int num = (int)(base.Children[1].Width / SlotSize);
					int num2 = (int)(base.Children[1].Height / SlotSize);
					Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num - 1, locationTopLeft.Y + num2 - 1);
					int id = base.M.ReadInt(base.Children[1].Address + id_offset);
					return new Item(base.M.ReadLong(base.Children[1].Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
				}
				int num3 = (int)(base.Children[1].Children[1].Width / SlotSize);
				int num4 = (int)(base.Children[1].Children[1].Height / SlotSize);
				Vector2i locationBottomRight2 = new Vector2i(locationTopLeft.X + num3 - 1, locationTopLeft.Y + num4 - 1);
				int id2 = base.M.ReadInt(base.Children[1].Children[1].Address + id_offset);
				return new Item(base.M.ReadLong(base.Children[1].Children[1].Address + item_offset), hasInventoryLocation: true, locationBottomRight2, locationTopLeft, id2);
			}
			if (base.ChildCount >= 1L)
			{
				if (base.ChildCount < 2L)
				{
					int num5 = (int)(base.Width / SlotSize);
					int num6 = (int)(base.Height / SlotSize);
					Vector2i locationBottomRight3 = new Vector2i(locationTopLeft.X + num5 - 1, locationTopLeft.Y + num6 - 1);
					int id3 = base.M.ReadInt(base.Address + id_offset);
					return new Item(base.M.ReadLong(base.Address + item_offset), hasInventoryLocation: true, locationBottomRight3, locationTopLeft, id3);
				}
				int num7 = (int)(base.Children[1].Width / SlotSize);
				int num8 = (int)(base.Children[1].Height / SlotSize);
				Vector2i locationBottomRight4 = new Vector2i(locationTopLeft.X + num7 - 1, locationTopLeft.Y + num8 - 1);
				int id4 = base.M.ReadInt(base.Children[1].Address + id_offset);
				return new Item(base.M.ReadLong(base.Children[1].Address + item_offset), hasInventoryLocation: true, locationBottomRight4, locationTopLeft, id4);
			}
			return null;
		}
	}

	public Element ItemElement
	{
		get
		{
			if (base.ChildCount >= 2L)
			{
				return base.Children[1];
			}
			return null;
		}
	}

	public int SocketCount
	{
		get
		{
			if (base.ChildCount < 2L)
			{
				return 0;
			}
			if (base.Children[1].ChildCount < 1L)
			{
				return 0;
			}
			return (int)base.Children[1].Children[0].ChildCount;
		}
	}

	public Dictionary<int, Vector2i> SocketsLocations
	{
		get
		{
			Dictionary<int, Vector2i> dictionary = new Dictionary<int, Vector2i>();
			if (base.ChildCount < 2L)
			{
				return dictionary;
			}
			if (base.Children[1].ChildCount < 1L)
			{
				return dictionary;
			}
			int num = 0;
			foreach (Element child in base.Children[1].Children[0].Children)
			{
				float num2 = (float)(29 + (int)child.X + (int)base.Children[1].X + (int)base.Children[1].Children[0].X + (int)base.X + (int)base.Parent.X + (int)base.Parent.Parent.X) * base.Scale;
				float num3 = (float)(29 + (int)child.Y + (int)base.Children[1].Y + (int)base.Children[1].Children[0].Y + (int)base.Y + (int)base.Parent.Y + (int)base.Parent.Parent.Y) * base.Scale;
				if (!dictionary.ContainsKey(num))
				{
					dictionary.Add(num, new Vector2i((int)num2, (int)num3));
				}
				num++;
			}
			return dictionary;
		}
	}

	public Vector2i LocationTopLeft
	{
		get
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			if (SlotType == SingleSlotType.FiveSlotMapDevice)
			{
				num3 = base.Scale;
				num = base.X * num3;
				num2 = base.Y * num3;
				Element parent = base.Parent;
				while (parent.Address != 0L && parent.IdLabel != "root")
				{
					num3 = parent.Scale;
					num += parent.X * num3;
					num2 += parent.Y * num3;
					parent = parent.Parent;
				}
			}
			else
			{
				num3 = base.Scale;
				num = base.X * num3;
				num2 = base.Y * num3;
				Element parent2 = base.Parent;
				while (parent2.Address != 0L && parent2.IdLabel != "root")
				{
					num3 = parent2.Scale;
					num += parent2.X * num3;
					num2 += parent2.Y * num3;
					parent2 = parent2.Parent;
				}
			}
			return new Vector2i((int)num, (int)num2);
		}
	}

	public Vector2i Size
	{
		get
		{
			float scale = base.Scale;
			return new Vector2i((int)(base.Width * scale), (int)(base.Height * scale));
		}
	}

	public SingleSlotUiElement()
	{
	}

	public SingleSlotUiElement(Element element, SingleSlotType slotType = SingleSlotType.inventory)
	{
		base.Address = element.Address;
		SlotType = slotType;
	}

	public SingleSlotUiElement(long elementAddress, SingleSlotType slotType = SingleSlotType.inventory)
	{
		base.Address = elementAddress;
		SlotType = slotType;
	}

	public Vector2i SlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)slot.X * SlotSize * base.Scale - 39f * base.Scale);
		int num2 = (int)((float)slot.Y * SlotSize * base.Scale - 39f * base.Scale);
		return new Vector2i(LocationTopLeft.X + num, LocationTopLeft.Y + num2);
	}
}
