using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Models.Enums;

namespace DreamPoeBot.Loki.Elements;

public class InventorySlotUiElement : Element
{
	public readonly int slotsize = 78;

	private readonly int halfslotSize = 41;

	private readonly double socketPos = 29.0;

	private StashType _stashType = StashType.NormalStash;

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private string _heistLockerMetadata = "";

	private static int id_offset = 776;

	private static int item_offset = 880;

	public int ItemsCount => (int)base.ChildCount - 1;

	public Dictionary<Vector2i, Item> PlacementGraph
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				Dictionary<Vector2i, Item> dictionary = new Dictionary<Vector2i, Item>();
				int num = 0;
				foreach (Element child in base.Children)
				{
					if (num == 0)
					{
						num++;
						continue;
					}
					int num2 = 1;
					int num3 = 1;
					if (_stashType == StashType.ExplorationLocker)
					{
						num2 = ((child.X == 0f) ? 1 : ((child.X == 312f) ? 1 : ((int)((child.X - 312f) / (float)slotsize) + 1)));
						num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / (float)slotsize) + 1));
					}
					else if (_stashType == StashType.HeistLooker)
					{
						LokiPoe.InGameState.HeistLockerUi.HeistLockerCategory categoryFromMetadata = LokiPoe.InGameState.HeistLockerUi.GetCategoryFromMetadata(_heistLockerMetadata);
						int num4 = (int)categoryFromMetadata;
						int num5 = ((num4 < 9) ? (slotsize * 11 * num4) : (slotsize * 11 * (num4 - 9)));
						int num6 = ((num4 >= 9) ? (slotsize * 6) : 0);
						num2 = ((child.X == 0f) ? 1 : ((child.X == (float)num5) ? 1 : ((int)((child.X - (float)num5) / (float)slotsize) + 1)));
						num3 = ((child.Y == 0f) ? 1 : ((int)((child.Y - (float)num6) / (float)slotsize) + 1));
					}
					else if (_stashType != StashType.SentinelLocker)
					{
						num2 = ((child.X == 0f) ? 1 : ((int)(child.X / (float)slotsize) + 1));
						num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / (float)slotsize) + 1));
					}
					else
					{
						num2 = ((child.X == 0f) ? 1 : ((int)(child.X / (float)slotsize) + 1));
						num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / (float)slotsize) + 1));
						switch (_sentinelType)
						{
						case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
							num2 -= 12;
							break;
						case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
							num2 -= 24;
							break;
						}
					}
					Vector2i locationTopLeft = new Vector2i(num2, num3);
					int num7 = (int)child.Width / slotsize;
					int num8 = (int)child.Height / slotsize;
					Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num7 - 1, locationTopLeft.Y + num8 - 1);
					int id = base.M.ReadInt(child.Address + id_offset);
					Item item = new Item(base.M.ReadLong(child.Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
					for (int i = 0; i < item.Size.Y; i++)
					{
						for (int j = 0; j < item.Size.X; j++)
						{
							Vector2i key = new Vector2i(locationTopLeft.X + j, locationTopLeft.Y + i);
							if (!dictionary.ContainsKey(key))
							{
								dictionary.Add(key, item);
							}
						}
					}
					num++;
				}
				{
					foreach (Vector2i slot in Slots)
					{
						if (!dictionary.ContainsKey(slot))
						{
							dictionary.Add(slot, null);
						}
					}
					return dictionary;
				}
			}
			return EldrichMavenPlacementGraph;
		}
	}

	private Dictionary<Vector2i, Item> EldrichMavenPlacementGraph
	{
		get
		{
			Dictionary<Vector2i, Item> dictionary = new Dictionary<Vector2i, Item>();
			int num = 0;
			foreach (Element child in base.Children[0].Children)
			{
				int num2 = 0;
				foreach (Element child2 in child.Children)
				{
					if (num2 == 0)
					{
						num2++;
						continue;
					}
					int num3 = 1;
					int y = num + 1;
					num3 = ((child2.X == 0f) ? 1 : ((num == 0) ? ((int)(child2.X / (float)slotsize) + 1) : ((int)(child2.X / (float)slotsize) - 12 * num + 1)));
					Vector2i locationTopLeft = new Vector2i(num3, y);
					int num4 = (int)child2.Width / slotsize;
					int num5 = (int)child2.Height / slotsize;
					Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num4 - 1, locationTopLeft.Y + num5 - 1);
					int id = base.M.ReadInt(child2.Address + id_offset);
					Item item = new Item(base.M.ReadLong(child2.Address + item_offset), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
					for (int i = 0; i < item.Size.Y; i++)
					{
						for (int j = 0; j < item.Size.X; j++)
						{
							Vector2i key = new Vector2i(locationTopLeft.X + j, locationTopLeft.Y + i);
							if (!dictionary.ContainsKey(key))
							{
								dictionary.Add(key, item);
							}
						}
					}
					num2++;
				}
				num++;
			}
			foreach (Vector2i slot in Slots)
			{
				if (!dictionary.ContainsKey(slot))
				{
					dictionary.Add(slot, null);
				}
			}
			return dictionary;
		}
	}

	private List<Vector2i> Slots
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				List<Vector2i> list = new List<Vector2i>();
				int num = 1;
				for (int i = 0; (float)i < base.Height; i += slotsize)
				{
					int num2 = 1;
					for (int j = 0; (float)j < base.Width; j += slotsize)
					{
						list.Add(new Vector2i(num2, num));
						num2++;
					}
					num++;
				}
				return list;
			}
			return EldrichMavenSlots;
		}
	}

	private List<Vector2i> EldrichMavenSlots
	{
		get
		{
			List<Vector2i> list = new List<Vector2i>();
			int num = 1;
			for (int i = 0; i < 6; i++)
			{
				int num2 = 1;
				for (int j = 0; j < 12; j++)
				{
					list.Add(new Vector2i(num2, num));
					num2++;
				}
				num++;
			}
			return list;
		}
	}

	public Dictionary<Vector2i, Dictionary<int, Vector2i>> SocketDictionary
	{
		get
		{
			Dictionary<Vector2i, Dictionary<int, Vector2i>> dictionary = new Dictionary<Vector2i, Dictionary<int, Vector2i>>();
			int num = 0;
			foreach (Element child in base.Children)
			{
				if (num != 0)
				{
					if (child.ChildCount == 0L)
					{
						num++;
						continue;
					}
					if (child.Children[0].ChildCount == 0L)
					{
						num++;
						continue;
					}
					int num2 = 0;
					int num3 = 0;
					num2 = ((child.X == 0f) ? 1 : ((int)(child.X / (float)slotsize) + 1));
					num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / (float)slotsize) + 1));
					Vector2i key = new Vector2i(num2, num3);
					int num4 = 0;
					foreach (Element child2 in child.Children[0].Children)
					{
						if (!dictionary.ContainsKey(key))
						{
							dictionary.Add(key, new Dictionary<int, Vector2i>());
						}
						double num5 = (socketPos + (double)(int)child2.X + (double)(int)child.X + (double)child.Children[0].X) * (double)base.Scale + (double)LocationTopLeft.X;
						double num6 = (socketPos + (double)(int)child2.Y + (double)(int)child.Y + (double)child.Children[0].Y) * (double)base.Scale + (double)LocationTopLeft.Y;
						dictionary[key].Add(num4, new Vector2i((int)num5, (int)num6));
						num4++;
					}
					num++;
				}
				else
				{
					num++;
				}
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
			if (_stashType == StashType.MapDevice)
			{
				num = (base.X + base.DeltaX) * base.Scale;
				num2 = (base.Y + base.DeltaY) * base.Scale;
				Element element = base.Parent;
				if (_stashType == StashType.FragmentEldrich || _stashType == StashType.FragmentMaven)
				{
					element = base.Children[0];
				}
				while (element.Address != 0L && element.IdLabel != "root")
				{
					num += (element.X + element.DeltaX) * element.Scale;
					num2 += (element.Y + element.DeltaY) * element.Scale;
					element = element.Parent;
				}
			}
			else
			{
				num = base.X * base.Scale;
				num2 = base.Y * base.Scale;
				Element element2 = base.Parent;
				if (_stashType == StashType.FragmentEldrich || _stashType == StashType.FragmentMaven)
				{
					element2 = base.Children[0];
				}
				while (element2.Address != 0L && element2.IdLabel != "root")
				{
					num += element2.X * element2.Scale;
					num2 += element2.Y * element2.Scale;
					element2 = element2.Parent;
				}
			}
			return new Vector2i((int)num, (int)num2);
		}
	}

	public Vector2i Size => new Vector2i((int)(base.Width * base.Scale), (int)(base.Height * base.Scale));

	public Dictionary<int, Element> DictionaryIdElements
	{
		get
		{
			if (_stashType != StashType.FragmentEldrich && _stashType != StashType.FragmentMaven)
			{
				Dictionary<int, Element> dictionary = new Dictionary<int, Element>();
				int num = 0;
				{
					foreach (Element child in base.Children)
					{
						if (num != 0)
						{
							int num2 = base.M.ReadInt(child.Address + id_offset);
							if (num2 != 0 && !dictionary.ContainsKey(num2))
							{
								dictionary.Add(num2, child);
							}
							num++;
						}
						else
						{
							num++;
						}
					}
					return dictionary;
				}
			}
			return EldrichMavenDictionaryIdElements;
		}
	}

	private Dictionary<int, Element> EldrichMavenDictionaryIdElements
	{
		get
		{
			Dictionary<int, Element> dictionary = new Dictionary<int, Element>();
			int num = 0;
			foreach (Element child in base.Children[0].Children)
			{
				int num2 = 0;
				foreach (Element child2 in child.Children)
				{
					if (num2 != 0)
					{
						int num3 = base.M.ReadInt(child2.Address + id_offset);
						if (num3 != 0 && !dictionary.ContainsKey(num3))
						{
							dictionary.Add(num3, child2);
						}
						num2++;
					}
					else
					{
						num2++;
					}
				}
				num++;
			}
			return dictionary;
		}
	}

	public Vector2i RewardLocationTopLeft => new Vector2i((int)((base.X + base.Parent.X + base.Parent.Parent.X + base.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.Parent.X) * base.Scale), (int)((base.Y + base.Parent.Y + base.Parent.Parent.Y + base.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Parent.Y) * base.Scale));

	public InventorySlotUiElement()
	{
	}

	public InventorySlotUiElement(long address, StashType stashType, LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown, string heistLockerMetadata = "")
	{
		base.Address = address;
		_stashType = stashType;
		_heistLockerMetadata = heistLockerMetadata;
		if (stashType == StashType.QuadStash)
		{
			slotsize = 39;
			halfslotSize = 21;
			socketPos = 14.5;
		}
		if (stashType == StashType.MapStash)
		{
			slotsize = 71;
			halfslotSize = 36;
			socketPos = 21.0;
		}
		if (stashType == StashType.SentinelLocker)
		{
			_sentinelType = sentinelType;
			slotsize = 65;
			halfslotSize = 33;
			socketPos = 18.0;
		}
		if (stashType == StashType.FragmentEldrich || stashType == StashType.FragmentMaven)
		{
			slotsize = 66;
			halfslotSize = 34;
			socketPos = 18.0;
		}
		if (stashType == StashType.HeistLooker)
		{
			slotsize = 63;
			halfslotSize = 33;
			socketPos = 18.0;
		}
	}

	public void SetStashType(StashType stashType)
	{
		_stashType = stashType;
	}

	public Vector2i ElementLocationTopLeft(Element element)
	{
		float num = element.X;
		float num2 = element.Y;
		Element parent = element.Parent;
		while (parent.Address != 0L && parent.IdLabel != "root")
		{
			num += parent.X;
			num2 += parent.Y;
			parent = parent.Parent;
		}
		return new Vector2i((int)(num * element.Scale), (int)(num2 * element.Scale));
	}

	public Vector2i SlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)(slot.X * slotsize) * base.Scale - (float)halfslotSize * base.Scale);
		int num2 = (int)((float)(slot.Y * slotsize) * base.Scale - (float)halfslotSize * base.Scale);
		return new Vector2i(LocationTopLeft.X + num, LocationTopLeft.Y + num2);
	}

	public Vector2i RewardSlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)slotsize * base.Scale - (float)halfslotSize * base.Scale);
		int num2 = (int)((float)slotsize * base.Scale - (float)halfslotSize * base.Scale);
		return new Vector2i(RewardLocationTopLeft.X + num, RewardLocationTopLeft.Y + num2);
	}
}
