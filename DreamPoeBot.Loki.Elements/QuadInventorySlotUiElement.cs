using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Objects;

namespace DreamPoeBot.Loki.Elements;

internal class QuadInventorySlotUiElement : Element
{
	public int ItemsCount => (int)base.ChildCount - 1;

	public Dictionary<Vector2i, Item> PlacementGraph
	{
		get
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
				int num2 = 0;
				int num3 = 0;
				num2 = ((child.X == 0f) ? 1 : ((int)(child.X / 39f) + 1));
				num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / 38f) + 1));
				Vector2i locationTopLeft = new Vector2i(num2, num3);
				int num4 = (int)child.Width / 39;
				int num5 = (int)child.Height / 39;
				Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num4 - 1, locationTopLeft.Y + num5 - 1);
				int id = base.M.ReadInt(child.Address + 2920L);
				Item item = new Item(base.M.ReadLong(child.Address + 2928L), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
				for (int i = 0; i < item.Size.Y; i++)
				{
					for (int j = 0; j < item.Size.X; j++)
					{
						dictionary.Add(new Vector2i(locationTopLeft.X + j, locationTopLeft.Y + i), item);
					}
				}
				num++;
			}
			foreach (Vector2i slot in slots)
			{
				if (!dictionary.ContainsKey(slot))
				{
					dictionary.Add(slot, null);
				}
			}
			return dictionary;
		}
	}

	private List<Vector2i> slots
	{
		get
		{
			List<Vector2i> list = new List<Vector2i>();
			int num = 1;
			for (int i = 0; (float)i < base.Height; i += 39)
			{
				int num2 = 1;
				for (int j = 0; (float)j < base.Width; j += 39)
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
					if (child.Children[0].ChildCount != 0L)
					{
						int num2 = 0;
						int num3 = 0;
						num2 = ((child.X == 0f) ? 1 : ((int)(child.X / 39f) + 1));
						num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / 39f) + 1));
						Vector2i key = new Vector2i(num2, num3);
						int num4 = 0;
						foreach (Element child2 in child.Children[0].Children)
						{
							if (!dictionary.ContainsKey(key))
							{
								dictionary.Add(key, new Dictionary<int, Vector2i>());
							}
							float num5 = ((float)(14 + (int)child2.X + (int)child.X) + child.Children[0].X + (float)(int)base.X + (float)(int)base.Parent.X + (float)(int)base.Parent.Parent.X) * base.Scale;
							float num6 = ((float)(14 + (int)child2.Y + (int)child.Y) + child.Children[0].Y + (float)(int)base.Y + (float)(int)base.Parent.Y + (float)(int)base.Parent.Parent.Y) * base.Scale;
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
			float num = base.X;
			float num2 = base.Y;
			Element parent = base.Parent;
			while (parent.Address != 0L && parent.IdLabel != "root")
			{
				num += parent.X;
				num2 += parent.Y;
				parent = parent.Parent;
			}
			return new Vector2i((int)(num * base.Scale), (int)(num2 * base.Scale));
		}
	}

	public Vector2i Size => new Vector2i((int)(base.Width * base.Scale), (int)(base.Height * base.Scale));

	public Dictionary<int, Element> DictionaryIdElements
	{
		get
		{
			Dictionary<int, Element> dictionary = new Dictionary<int, Element>();
			int num = 0;
			foreach (Element child in base.Children)
			{
				if (num != 0)
				{
					int num2 = 0;
					int num3 = 0;
					num2 = ((child.X == 0f) ? 1 : ((int)(child.X / 39f) + 1));
					num3 = ((child.Y == 0f) ? 1 : ((int)(child.Y / 39f) + 1));
					Vector2i locationTopLeft = new Vector2i(num2, num3);
					int num4 = (int)child.Width / 39;
					int num5 = (int)child.Height / 39;
					Vector2i locationBottomRight = new Vector2i(locationTopLeft.X + num4 - 1, locationTopLeft.Y + num5 - 1);
					int id = base.M.ReadInt(child.Address + 2920L);
					Item item = new Item(base.M.ReadLong(child.Address + 2928L), hasInventoryLocation: true, locationBottomRight, locationTopLeft, id);
					if (item.LocalId != 0)
					{
						dictionary.Add(item.LocalId, child);
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

	public Vector2i RewardLocationTopLeft => new Vector2i((int)((base.X + base.Parent.X + base.Parent.Parent.X + base.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.X + base.Parent.Parent.Parent.Parent.Parent.X) * base.Scale), (int)((base.Y + base.Parent.Y + base.Parent.Parent.Y + base.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Y + base.Parent.Parent.Parent.Parent.Parent.Y) * base.Scale));

	public Vector2i SlotClickLocation(Vector2i slot)
	{
		int num = (int)((float)(slot.X * 39) * base.Scale - 18f * base.Scale);
		int num2 = (int)((float)(slot.Y * 39) * base.Scale - 18f * base.Scale);
		return new Vector2i(LocationTopLeft.X + num, LocationTopLeft.Y + num2);
	}

	public Vector2i RewardSlotClickLocation(Vector2i slot)
	{
		int num = (int)(39f * base.Scale - 18f * base.Scale);
		int num2 = (int)(39f * base.Scale - 18f * base.Scale);
		return new Vector2i(RewardLocationTopLeft.X + num, RewardLocationTopLeft.Y + num2);
	}
}
