using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Models.Enums;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Elements;

public class InventoryElement : Element
{
	internal static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private InventoryList AllInventories => GetObjectAt<InventoryList>(872);

	public Inventory this[InventoryIndex k] => AllInventories[k];

	internal List<Element> ListOfSkillElements
	{
		get
		{
			try
			{
				List<Element> list = new List<Element>();
				if (base.ChildCount < 4L)
				{
					return list;
				}
				Element element = base.Children[3];
				if ((object)element != null && element.ChildCount < 1L)
				{
					return list;
				}
				Element element2 = base.Children[3];
				if ((object)element2 != null && element2.Children[0]?.ChildCount < 1L)
				{
					return list;
				}
				List<Element> list2 = base.Children[3]?.Children[0]?.Children[0]?.Children;
				if (list2 != null)
				{
					foreach (Element item in list2)
					{
						list.Add(item);
					}
					return list;
				}
				return list;
			}
			catch (Exception arg)
			{
				ilog_0.ErrorFormat($"{arg}", Array.Empty<object>());
				return new List<Element>();
			}
		}
	}

	public Inventory PlayerInventory => this[InventoryIndex.PlayerInventory];

	public Inventory PlayerHead => this[InventoryIndex.Helm];

	public Inventory PlayerNeck => this[InventoryIndex.Amulet];

	public Inventory PlayerChest => this[InventoryIndex.Chest];

	public Inventory PlayerPrimaryOffHand => this[InventoryIndex.RWeapon];

	public Inventory PlayerPrimaryMainHand => this[InventoryIndex.LWeapon];

	public Inventory PlayerSecondaryOffHand => this[InventoryIndex.RWeaponSwap];

	public Inventory PlayerSecondaryMainHand => this[InventoryIndex.LWeaponSwap];

	public Inventory PlayerLeftRing => this[InventoryIndex.LRing];

	public Inventory PlayerRightRing => this[InventoryIndex.RRing];

	public Inventory PlayerGloves => this[InventoryIndex.Gloves];

	public Inventory PlayerBelt => this[InventoryIndex.Belt];

	public Inventory PlayerBoots => this[InventoryIndex.Boots];

	public Inventory PlayerFlasks => this[InventoryIndex.Flask];

	internal Element SentinelElement => base.Children[3]?.Children[2];

	internal Element StalkerSentinelElement => null;

	internal long StalkerSentinelInventoryAddress
	{
		get
		{
			if (!(StalkerSentinelElement == null))
			{
				return StalkerSentinelElement.Children[1].Address;
			}
			return 0L;
		}
	}

	internal Inventory StalkerSentinelInventory => CreateObject<Inventory>(StalkerSentinelInventoryAddress);

	internal Element PandemoniumSentinelElement => null;

	internal long PandemoniumSentinelInventoryAddress
	{
		get
		{
			if (!(PandemoniumSentinelElement == null))
			{
				return PandemoniumSentinelElement.Children[1].Address;
			}
			return 0L;
		}
	}

	internal Inventory PandemoniumSentinelInventory => CreateObject<Inventory>(PandemoniumSentinelInventoryAddress);

	internal Element ApexSentinelElement => null;

	internal long ApexSentinelInventoryAddress
	{
		get
		{
			if (!(ApexSentinelElement == null))
			{
				return ApexSentinelElement.Children[1].Address;
			}
			return 0L;
		}
	}

	internal Inventory ApexSentinelInventory => CreateObject<Inventory>(ApexSentinelInventoryAddress);

	internal Element SentinelControllerElement => base.Children[3]?.Children[2]?.Children[3];
}
