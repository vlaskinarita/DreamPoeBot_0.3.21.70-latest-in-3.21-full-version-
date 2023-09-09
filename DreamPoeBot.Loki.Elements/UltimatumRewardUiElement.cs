using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Elements.InventoryElements;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Elements;

public class UltimatumRewardUiElement : Element
{
	internal Element TakeReward => base.Children[1].Children[4].Children[0];

	private int RewardEarned
	{
		get
		{
			string text = base.Children[1].Children[2].Text;
			string text2 = "<ultimatumnumber>{";
			string text3 = "} Rewards earned";
			string value = text.TrimStart(text2.ToCharArray()).TrimEnd(text3.ToCharArray());
			return Convert.ToInt32(value);
		}
	}

	public List<Item> CurrentReward
	{
		get
		{
			List<NormalInventoryItem> list = new List<NormalInventoryItem>();
			foreach (Element child in base.Children[1].Children[1].Children[0].Children)
			{
				if (child.ChildCount != 0L)
				{
					NormalInventoryItem normalInventoryItem = child.AsObject<NormalInventoryItem>();
					if (normalInventoryItem.InventPosX <= 11 && normalInventoryItem.InventPosY <= 4)
					{
						list.Add(normalInventoryItem);
					}
				}
			}
			List<Item> list2 = new List<Item>();
			foreach (NormalInventoryItem item in list)
			{
				list2.Add(new Item(item.InnerItem, hasInventoryLocation: true, new Vector2i(item.InventPosX + item.InnerItem.Size.X - 1, item.InventPosY + item.InnerItem.Size.Y - 1), new Vector2i(item.InventPosX, item.InventPosY)));
			}
			return list2;
		}
	}

	internal Element AcceptTrialButton => base.Children[2].Children[6].Children[0];

	private Element Options => base.Children[2].Children[4];

	public string Title => base.Children[2].Children[2].Children[1].Text;

	internal int SelectedOption => base.M.ReadInt(Options.Address + 592L);

	internal NativeVector OptionsVector => base.M.ReadNativeVector(Options.Address + 568L);

	public List<Item> NextReward
	{
		get
		{
			List<NormalInventoryItem> list = new List<NormalInventoryItem>();
			foreach (Element child in base.Children[2].Children[1].Children[1].Children)
			{
				if (child.ChildCount != 0L)
				{
					NormalInventoryItem normalInventoryItem = child.AsObject<NormalInventoryItem>();
					if (normalInventoryItem.InventPosX <= 11 && normalInventoryItem.InventPosY <= 4)
					{
						list.Add(normalInventoryItem);
					}
				}
			}
			List<Item> list2 = new List<Item>();
			foreach (NormalInventoryItem item in list)
			{
				list2.Add(new Item(item.InnerItem, hasInventoryLocation: true, new Vector2i(item.InventPosX + item.InnerItem.Size.X - 1, item.InventPosY + item.InnerItem.Size.Y - 1), new Vector2i(item.InventPosX, item.InventPosY)));
			}
			return list2;
		}
	}

	internal Dictionary<long, Element> OptionElementsDictionary
	{
		get
		{
			Dictionary<long, Element> dictionary = new Dictionary<long, Element>();
			foreach (Element child in Options.Children[0].Children)
			{
				dictionary.Add(base.M.ReadLong(child.Address + 1008L), child);
			}
			return dictionary;
		}
	}

	public List<Item> RewardPreview
	{
		get
		{
			List<NormalInventoryItem> list = new List<NormalInventoryItem>();
			foreach (Element child in base.Children[5].Children[2].Children)
			{
				if (child.ChildCount != 0L)
				{
					NormalInventoryItem normalInventoryItem = child.AsObject<NormalInventoryItem>();
					if (normalInventoryItem.InventPosX <= 11 && normalInventoryItem.InventPosY <= 4)
					{
						list.Add(normalInventoryItem);
					}
				}
			}
			List<Item> list2 = new List<Item>();
			foreach (NormalInventoryItem item in list)
			{
				list2.Add(new Item(item.InnerItem, hasInventoryLocation: true, new Vector2i(item.InventPosX + item.InnerItem.Size.X - 1, item.InventPosY + item.InnerItem.Size.Y - 1), new Vector2i(item.InventPosX, item.InventPosY)));
			}
			return list2;
		}
	}
}
