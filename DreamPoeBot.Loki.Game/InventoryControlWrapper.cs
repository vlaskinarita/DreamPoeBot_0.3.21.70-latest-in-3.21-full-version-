using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Hooks;
using DreamPoeBot.Loki.Bot;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Models.Enums;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Game;

public class InventoryControlWrapper : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct106
	{
		public readonly Vector2i vector2i_0;

		public readonly Vector2i vector2i_1;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private bool bool_0HasRewardTabOverride;

	private bool bool_1HasTalismanTabOverride;

	private bool bool_2HasLeaguestoneTabOverride;

	private bool bool_3HasDivinationTabOverride;

	private bool bool_4HasEssenceTabOverride;

	private bool bool_5HasCurrencyTabOverride;

	private bool bool_6HasFragmentTabOverride;

	private bool bool_7HasDelveTabOverride;

	private bool bool_8HasExpeditionLockerOverride;

	private bool bool_9HasMetamorphTabOverride;

	private bool bool_10hasSentinelLockerOverride;

	private bool bool_13HasBlightTabOverride;

	private bool bool_14HasHeistLockerOverride;

	private bool bool_15HasRogueMarkerTabOverride;

	private bool hasEldrichTabOverride;

	private bool hasMavenTabOverride;

	private List<int> list_StorableBaseItemTypeKeys;

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private string string_0CustomTabMetadata = "";

	private string _customTabItemName = "";

	private int rows = -1;

	private int cols = -1;

	private bool bool_7HasSingleItemOverride;

	private bool bool_8HasEquippableItemOverride;

	private bool bool_10HasFiveSlotMapDeviceOverride;

	private bool bool_11HasCrucibleItemOverride;

	private bool bool_12HasSentinelDroneItemOverride;

	public SingleSlotUiElement SingleSlotUiElement;

	public InventorySlotUiElement InventorySlotUiElement;

	public string CustomTabMetadata => string_0CustomTabMetadata;

	public string CustomTabItemName => _customTabItemName;

	public bool HasCustomTabOverride
	{
		get
		{
			if (!HasEssenceTabOverride && !HasCurrencyTabOverride && !HasDelveTabOverride && !HasDivinationTabOverride && !HasLeaguestoneTabOverride && !HasTalismanTabOverride && !HasRewardTabOverride && !HasCrucibleItemOverride && !HasFragmentTabOverride && !HasMetamorphTabOverride && !HasSentinelDroneItemOverride && !bool_10HasFiveSlotMapDeviceOverride && !HasBlightTabOverride)
			{
				return HasRogueMarkerTabOverride;
			}
			return true;
		}
	}

	public bool HasSentinelDroneItemOverride => bool_12HasSentinelDroneItemOverride;

	public bool HasCrucibleItemOverride => bool_11HasCrucibleItemOverride;

	public bool HasTalismanTabOverride => bool_1HasTalismanTabOverride;

	public bool HasLeaguestoneTabOverride => bool_2HasLeaguestoneTabOverride;

	public bool HasDivinationTabOverride => bool_3HasDivinationTabOverride;

	public bool HasEssenceTabOverride => bool_4HasEssenceTabOverride;

	public bool HasCurrencyTabOverride => bool_5HasCurrencyTabOverride;

	public bool HasBlightTabOverride => bool_13HasBlightTabOverride;

	public bool HasDelveTabOverride => bool_7HasDelveTabOverride;

	public bool HasExpeditionLockerOverride => bool_8HasExpeditionLockerOverride;

	public bool HasHeistLockerOverride => bool_14HasHeistLockerOverride;

	public bool HasRogueMarkerTabOverride => bool_15HasRogueMarkerTabOverride;

	public bool HasSentinelLockerOverride => bool_10hasSentinelLockerOverride;

	public bool HasFragmentTabOverride => bool_6HasFragmentTabOverride;

	public bool HasEldrichTabOverride => hasEldrichTabOverride;

	public bool HasMavenTabOverride => hasMavenTabOverride;

	public bool HasMetamorphTabOverride => bool_9HasMetamorphTabOverride;

	public bool HasSingleItemOverride => bool_7HasSingleItemOverride;

	public bool HasEquippableItemOverride => bool_8HasEquippableItemOverride;

	public bool HasRewardTabOverride => bool_0HasRewardTabOverride;

	public bool HasFiveSlotMapDeviceOverride => bool_10HasFiveSlotMapDeviceOverride;

	public Item CustomTabItem
	{
		get
		{
			if (!HasCustomTabOverride)
			{
				return null;
			}
			Inventory inventory = Inventory;
			if (HasDivinationTabOverride)
			{
				Item item = SingleSlotUiElement.Item;
				if (item != null)
				{
					return item;
				}
				return null;
			}
			if (!HasRogueMarkerTabOverride)
			{
				if (bool_0HasRewardTabOverride)
				{
					Dictionary<int, long> dictionary_ = Dictionary_0;
					if (dictionary_.Count == 1)
					{
						return inventory.GetItemById(dictionary_.First().Key);
					}
				}
				foreach (KeyValuePair<int, Item> item3 in inventory.ItemMap)
				{
					Vector2i locationTopLeft = item3.Value.LocationTopLeft;
					string metadata = item3.Value.Metadata;
					if (CustomTabMetadata.Contains("Metadata/"))
					{
						if (locationTopLeft.X == rows && CustomTabMetadata == metadata)
						{
							if (cols == -1)
							{
								return item3.Value;
							}
							if (locationTopLeft.Y == cols)
							{
								return item3.Value;
							}
						}
					}
					else if (locationTopLeft.X == rows)
					{
						if (cols == -1)
						{
							return item3.Value;
						}
						if (locationTopLeft.Y == cols)
						{
							return item3.Value;
						}
					}
				}
				return null;
			}
			Item item2 = SingleSlotUiElement.Item;
			if (item2 != null)
			{
				return item2;
			}
			return null;
		}
	}

	internal int Int32_0Id => base.M.ReadInt(base.Address + 448L);

	internal Dictionary<int, long> Dictionary_0 => new Dictionary<int, long>();

	internal Dictionary<long, int> Dictionary_1 => new Dictionary<long, int>();

	public Inventory Inventory
	{
		get
		{
			if (base.Address == 0L)
			{
				return new Inventory(0L);
			}
			if (HasExpeditionLockerOverride)
			{
				inventory_0 = new Inventory(base.Address);
			}
			else if (HasHeistLockerOverride)
			{
				inventory_0 = new Inventory(base.Address, CustomTabMetadata);
			}
			else if (HasSentinelLockerOverride)
			{
				inventory_0 = new Inventory(base.Address, _sentinelType);
			}
			else if (HasEldrichTabOverride)
			{
				inventory_0 = new Inventory(base.M.ReadLong(base.Address + 8L), isEldrichTab: true, isMavenTab: false, list_StorableBaseItemTypeKeys);
			}
			else if (HasMavenTabOverride)
			{
				inventory_0 = new Inventory(base.M.ReadLong(base.Address + 8L), isEldrichTab: false, isMavenTab: true, list_StorableBaseItemTypeKeys);
			}
			else
			{
				inventory_0 = new Inventory(base.M.ReadLong(base.Address + 8L));
			}
			inventory_0.SetId(Int32_0Id);
			return inventory_0;
		}
	}

	private Inventory inventory_0 { get; set; }

	private int Id
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			InventoryHolder inventoryHolder = GameController.Instance.Game.IngameState.ServerData.PlayerInventories?.FirstOrDefault((InventoryHolder x) => x.Address == base.Address);
			if (inventoryHolder == null)
			{
				return 0;
			}
			return inventoryHolder.Id;
		}
	}

	public InventoryControlWrapper()
	{
	}

	public InventoryControlWrapper(bool Emptycurrency)
	{
		if (Emptycurrency)
		{
			base.Address = 0L;
			bool_5HasCurrencyTabOverride = true;
			string_0CustomTabMetadata = "";
			rows = 0;
			if (string_0CustomTabMetadata == null)
			{
				string_0CustomTabMetadata = "";
			}
		}
	}

	public InventoryControlWrapper(long control)
		: base(control)
	{
	}

	internal void SpecialSetMousePosition(Vector2i pos)
	{
		MouseManager.SetMousePosition(pos, useRandomPos: false);
	}

	internal void IsRewardTab()
	{
		bool_0HasRewardTabOverride = true;
		string_0CustomTabMetadata = "";
	}

	internal void IsTalismanTab(int rows)
	{
		bool_1HasTalismanTabOverride = true;
		this.rows = rows;
		string_0CustomTabMetadata = "";
	}

	internal void IsLeaguestoneTab(int rows)
	{
		bool_2HasLeaguestoneTabOverride = true;
		this.rows = rows;
		string_0CustomTabMetadata = "";
	}

	internal void IsDivinationTab(string metadata, string name)
	{
		bool_3HasDivinationTabOverride = true;
		string_0CustomTabMetadata = metadata;
		_customTabItemName = name;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsEssenceTab(string metadata, int rows)
	{
		bool_4HasEssenceTabOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsExpeditionLockerTab(string metadata, int rows)
	{
		bool_8HasExpeditionLockerOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsHeisLockerTab(string metadata)
	{
		bool_14HasHeistLockerOverride = true;
		string_0CustomTabMetadata = metadata;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsRogueMarkerTab(string metadata)
	{
		bool_15HasRogueMarkerTabOverride = true;
		string_0CustomTabMetadata = metadata;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsSentinelLockerTab(LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType)
	{
		bool_10hasSentinelLockerOverride = true;
		_sentinelType = sentinelType;
	}

	internal void IsFragmentTab(string metadata, int rows, bool isEldrich = false, bool IsMaven = false, List<int> storableBaseItemTypeKeys = null)
	{
		if (isEldrich)
		{
			hasEldrichTabOverride = true;
			list_StorableBaseItemTypeKeys = storableBaseItemTypeKeys;
		}
		else if (!IsMaven)
		{
			bool_6HasFragmentTabOverride = true;
			string_0CustomTabMetadata = metadata;
			this.rows = rows;
			if (string_0CustomTabMetadata == null)
			{
				string_0CustomTabMetadata = "";
			}
		}
		else
		{
			hasMavenTabOverride = true;
			list_StorableBaseItemTypeKeys = storableBaseItemTypeKeys;
		}
	}

	internal void IsMetamorphTab(string metadata, int rows)
	{
		bool_9HasMetamorphTabOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsBlightTab(string metadata, int rows)
	{
		bool_13HasBlightTabOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsCurrencyTab(string metadata, int rows)
	{
		bool_5HasCurrencyTabOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsSentinelDrone(int row, int col)
	{
		bool_7HasSingleItemOverride = true;
		bool_12HasSentinelDroneItemOverride = true;
		rows = row;
		cols = col;
	}

	internal void IsDelveTab(string metadata, int rows)
	{
		bool_7HasDelveTabOverride = true;
		string_0CustomTabMetadata = metadata;
		this.rows = rows;
		if (string_0CustomTabMetadata == null)
		{
			string_0CustomTabMetadata = "";
		}
	}

	internal void IsFiveSlotMapDeviceItem(int row, int col)
	{
		bool_7HasSingleItemOverride = true;
		bool_10HasFiveSlotMapDeviceOverride = true;
		rows = row;
		cols = col;
	}

	internal void IsSingleItem()
	{
		bool_7HasSingleItemOverride = true;
	}

	internal void IsCrucibleItem(int row, int col)
	{
		bool_7HasSingleItemOverride = true;
		bool_11HasCrucibleItemOverride = true;
		rows = row;
		cols = col;
	}

	internal void IsEquippable()
	{
		bool_8HasEquippableItemOverride = true;
	}

	public ViewItemsInInventoryResult ViewItemsInInventory(ShouldViewItemDelegate shouldViewItem, Func<bool> isOpened)
	{
		if (!Hooking.IsInstalled)
		{
			return ViewItemsInInventoryResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (isOpened())
		{
			if (HasCustomTabOverride)
			{
				return ViewItemsInInventoryResult.Unsupported;
			}
			if (isOpened())
			{
				if (SingleSlotUiElement != null)
				{
					return ViewItemsInInventoryResult.Unsupported;
				}
				if (InventorySlotUiElement != null)
				{
					int num = -1;
					foreach (KeyValuePair<Vector2i, Item> item in InventorySlotUiElement.PlacementGraph)
					{
						if (!(item.Value == null) && item.Value.LocalId != num)
						{
							num = item.Value.LocalId;
							if (shouldViewItem(Inventory, item.Value))
							{
								Vector2i key = item.Key;
								Vector2i pos = InventorySlotUiElement.SlotClickLocation(key);
								SpecialSetMousePosition(pos);
								Thread.Sleep(0);
							}
						}
					}
					return ViewItemsInInventoryResult.None;
				}
				return ViewItemsInInventoryResult.Unsupported;
			}
			return ViewItemsInInventoryResult.UiNotOpen;
		}
		return ViewItemsInInventoryResult.UiNotOpen;
	}

	public PickupResult Pickup(int id, bool actuallyPickup = true)
	{
		if (!Hooking.IsInstalled)
		{
			return PickupResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (!LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			if (!HasCustomTabOverride)
			{
				if (SingleSlotUiElement != null)
				{
					Item item2 = SingleSlotUiElement.Item;
					if (item2 == null)
					{
						return PickupResult.ItemNotFound;
					}
					Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
					SpecialSetMousePosition(pos);
					Thread.Sleep(5);
					MouseManager.ClickLMB();
					Thread.Sleep(15);
					return PickupResult.None;
				}
				if (!(InventorySlotUiElement != null))
				{
					return PickupResult.Unsupported;
				}
				int num = 0;
				Item item;
				Vector2i key;
				while (true)
				{
					item = Inventory.GetItemById(id);
					if (!(item == null))
					{
						key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == item.LocalId).Key;
						if (!(key == Vector2i.Zero))
						{
							break;
						}
						num++;
						if (num > 5)
						{
							ilog_0.ErrorFormat("[Pickup] Failed to find the item 5 times, this usually indicate a problem with PlacementGraph Structure.", Array.Empty<object>());
							return PickupResult.ItemNotFound;
						}
						continue;
					}
					return PickupResult.ItemNotFound;
				}
				Vector2i pos2 = InventorySlotUiElement.SlotClickLocation(key);
				SpecialSetMousePosition(pos2);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				return PickupResult.None;
			}
			return PickupResult.Unsupported;
		}
		return PickupResult.CursorFull;
	}

	public PickupResult Pickup(bool actuallyPickup = true)
	{
		if (!Hooking.IsInstalled)
		{
			return PickupResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (!LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			if (!HasDivinationTabOverride)
			{
				if (SingleSlotUiElement != null)
				{
					Item item = SingleSlotUiElement.Item;
					if (!(item == null))
					{
						Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
						SpecialSetMousePosition(pos);
						Thread.Sleep(5);
						MouseManager.ClickLMB();
						Thread.Sleep(15);
						return PickupResult.None;
					}
					return PickupResult.ItemNotFound;
				}
				_ = InventorySlotUiElement != null;
				return PickupResult.Unsupported;
			}
			Item item2 = SingleSlotUiElement.Item;
			if (!(item2 == null))
			{
				LokiPoe.InGameState.StashUi.SetHighlightKeyword(item2.Name);
				if (!SingleSlotUiElement.IsVisible)
				{
					return PickupResult.ItemNotFound;
				}
				Vector2i pos2 = SingleSlotUiElement.CenterClickLocation();
				SpecialSetMousePosition(pos2);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				LokiPoe.InGameState.StashUi.SetHighlightKeyword("");
				return PickupResult.None;
			}
			return PickupResult.ItemNotFound;
		}
		return PickupResult.CursorFull;
	}

	public FastMoveResult FastMoveReward(int id, bool actuallyMove = true)
	{
		Vector2i key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null).Key;
		Vector2i pos = InventorySlotUiElement.RewardSlotClickLocation(key);
		SpecialSetMousePosition(pos);
		LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
		Thread.Sleep(25);
		MouseManager.ClickLMB();
		Thread.Sleep(15);
		LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
		return FastMoveResult.None;
	}

	public int GetLevelRequirement(int id)
	{
		int num = 0;
		if (HasCustomTabOverride)
		{
			if (!HasRewardTabOverride)
			{
				num = 0;
				return 0;
			}
			return 0;
		}
		if (!(SingleSlotUiElement != null))
		{
			if (!(InventorySlotUiElement != null))
			{
				return 0;
			}
			Item itemById = Inventory.GetItemById(id);
			if (itemById == null)
			{
				return 0;
			}
			if (InventorySlotUiElement.DictionaryIdElements.TryGetValue(itemById.LocalId, out var value))
			{
				Element tooltip = value.Tooltip;
				if (tooltip.ChildCount == 0L)
				{
					return 0;
				}
				Element element = tooltip.Children[0];
				if (element.ChildCount != 0L)
				{
					Element element2 = element.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
					if (element2 == null)
					{
						return 0;
					}
					if (element2.Text.Contains("Level"))
					{
						string[] source = element2.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
							.Split(',');
						string text = source.FirstOrDefault((string x) => x.Contains("Level"));
						if (text == null)
						{
							return 0;
						}
						return Convert.ToInt32(text.Replace("Level", "").Replace("{", "").Replace("}", ""));
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		Item item = SingleSlotUiElement.Item;
		if (item == null)
		{
			return 0;
		}
		Element tooltip2 = SingleSlotUiElement.ItemElement.Tooltip;
		if (tooltip2.ChildCount == 0L)
		{
			return 0;
		}
		Element element3 = tooltip2.Children[0];
		if (element3.ChildCount == 0L)
		{
			return 0;
		}
		Element element4 = element3.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
		if (!(element4 == null))
		{
			if (element4.Text.Contains("Level"))
			{
				string[] source2 = element4.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
					.Split(',');
				string text2 = source2.FirstOrDefault((string x) => x.Contains("Level"));
				if (text2 != null)
				{
					return Convert.ToInt32(text2.Replace("Level", "").Replace("{", "").Replace("}", ""));
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	public int GetIntRequirement(int id)
	{
		int num = 0;
		if (HasCustomTabOverride)
		{
			if (HasRewardTabOverride)
			{
				return 0;
			}
			num = 0;
			return 0;
		}
		if (SingleSlotUiElement != null)
		{
			Item item = SingleSlotUiElement.Item;
			if (!(item == null))
			{
				Element tooltip = SingleSlotUiElement.ItemElement.Tooltip;
				if (tooltip.ChildCount == 0L)
				{
					return 0;
				}
				Element element = tooltip.Children[0];
				if (element.ChildCount != 0L)
				{
					Element element2 = element.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
					if (element2 == null)
					{
						return 0;
					}
					if (!element2.Text.Contains("Int"))
					{
						return 0;
					}
					string[] source = element2.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
						.Split(',');
					string text = source.FirstOrDefault((string x) => x.Contains("Int"));
					if (text != null)
					{
						return Convert.ToInt32(text.Replace("Int", "").Replace("{", "").Replace("}", ""));
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		if (!(InventorySlotUiElement != null))
		{
			return 0;
		}
		Item itemById = Inventory.GetItemById(id);
		if (!(itemById == null))
		{
			if (InventorySlotUiElement.DictionaryIdElements.TryGetValue(itemById.LocalId, out var value))
			{
				Element tooltip2 = value.Tooltip;
				if (tooltip2.ChildCount != 0L)
				{
					Element element3 = tooltip2.Children[0];
					if (element3.ChildCount != 0L)
					{
						Element element4 = element3.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
						if (element4 == null)
						{
							return 0;
						}
						if (element4.Text.Contains("Int"))
						{
							string[] source2 = element4.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
								.Split(',');
							string text2 = source2.FirstOrDefault((string x) => x.Contains("Int"));
							if (text2 == null)
							{
								return 0;
							}
							return Convert.ToInt32(text2.Replace("Int", "").Replace("{", "").Replace("}", ""));
						}
						return 0;
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	public int GetDexRequirement(int id)
	{
		int num = 0;
		if (HasCustomTabOverride)
		{
			if (HasRewardTabOverride)
			{
				return 0;
			}
			num = 0;
			return 0;
		}
		if (!(SingleSlotUiElement != null))
		{
			if (InventorySlotUiElement != null)
			{
				Item itemById = Inventory.GetItemById(id);
				if (itemById == null)
				{
					return 0;
				}
				if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(itemById.LocalId, out var value))
				{
					return 0;
				}
				Element tooltip = value.Tooltip;
				if (tooltip.ChildCount != 0L)
				{
					Element element = tooltip.Children[0];
					if (element.ChildCount != 0L)
					{
						Element element2 = element.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
						if (!(element2 == null))
						{
							if (element2.Text.Contains("Dex"))
							{
								string[] source = element2.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
									.Split(',');
								string text = source.FirstOrDefault((string x) => x.Contains("Dex"));
								if (text == null)
								{
									return 0;
								}
								return Convert.ToInt32(text.Replace("Dex", "").Replace("{", "").Replace("}", ""));
							}
							return 0;
						}
						return 0;
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		Item item = SingleSlotUiElement.Item;
		if (!(item == null))
		{
			Element tooltip2 = SingleSlotUiElement.ItemElement.Tooltip;
			if (tooltip2.ChildCount == 0L)
			{
				return 0;
			}
			Element element3 = tooltip2.Children[0];
			if (element3.ChildCount != 0L)
			{
				Element element4 = element3.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
				if (element4 == null)
				{
					return 0;
				}
				if (element4.Text.Contains("Dex"))
				{
					string[] source2 = element4.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
						.Split(',');
					string text2 = source2.FirstOrDefault((string x) => x.Contains("Dex"));
					if (text2 != null)
					{
						return Convert.ToInt32(text2.Replace("Dex", "").Replace("{", "").Replace("}", ""));
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	public int GetStrRequirement(int id)
	{
		int num = 0;
		if (HasCustomTabOverride)
		{
			if (!HasRewardTabOverride)
			{
				num = 0;
				return 0;
			}
			return 0;
		}
		if (!(SingleSlotUiElement != null))
		{
			if (InventorySlotUiElement != null)
			{
				Item itemById = Inventory.GetItemById(id);
				if (itemById == null)
				{
					return 0;
				}
				if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(itemById.LocalId, out var value))
				{
					return 0;
				}
				Element tooltip = value.Tooltip;
				if (tooltip.ChildCount != 0L)
				{
					Element element = tooltip.Children[0];
					if (element.ChildCount != 0L)
					{
						Element element2 = element.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
						if (!(element2 == null))
						{
							if (element2.Text.Contains("Str"))
							{
								string[] source = element2.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
									.Split(',');
								string text = source.FirstOrDefault((string x) => x.Contains("Str"));
								if (text == null)
								{
									return 0;
								}
								return Convert.ToInt32(text.Replace("Str", "").Replace("{", "").Replace("}", ""));
							}
							return 0;
						}
						return 0;
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
		Item item = SingleSlotUiElement.Item;
		if (!(item == null))
		{
			Element tooltip2 = SingleSlotUiElement.ItemElement.Tooltip;
			if (tooltip2.ChildCount == 0L)
			{
				return 0;
			}
			Element element3 = tooltip2.Children[0];
			if (element3.ChildCount == 0L)
			{
				return 0;
			}
			Element element4 = element3.Children[1].Children.FirstOrDefault((Element x) => !string.IsNullOrEmpty(x.Text) && x.Text.Contains("Requires"));
			if (!(element4 == null))
			{
				if (!element4.Text.Contains("Str"))
				{
					return 0;
				}
				string[] source2 = element4.Text.Replace("Requires", "").Replace("<valuedefault>", "").Replace("<unmet>", "")
					.Split(',');
				string text2 = source2.FirstOrDefault((string x) => x.Contains("Str"));
				if (text2 != null)
				{
					return Convert.ToInt32(text2.Replace("Str", "").Replace("{", "").Replace("}", ""));
				}
				return 0;
			}
			return 0;
		}
		return 0;
	}

	public FastMoveResult FastMove(int id, bool dontClearKeysState, bool actuallyMove = true, bool ignoreIncubators = true)
	{
		if (!Hooking.IsInstalled)
		{
			return FastMoveResult.ProcessHookManagerNotEnabled;
		}
		if (!dontClearKeysState)
		{
			HookManager.ResetKeyState();
		}
		if (!LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			if (HasCustomTabOverride)
			{
				if (HasRewardTabOverride)
				{
					return FastMoveReward(id, actuallyMove);
				}
				return FastMoveResult.Unsupported;
			}
			if (SingleSlotUiElement != null)
			{
				Item item2 = SingleSlotUiElement.Item;
				if (item2 == null)
				{
					return FastMoveResult.ItemNotFound;
				}
				Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
				Thread.Sleep(5);
				SpecialSetMousePosition(pos);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
				Thread.Sleep(5);
				if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
				{
					Thread.Sleep(5);
					LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
					Thread.Sleep(5);
				}
				return FastMoveResult.None;
			}
			if (!(InventorySlotUiElement != null))
			{
				return FastMoveResult.Unsupported;
			}
			Item item = Inventory.GetItemById(id);
			if (!(item == null))
			{
				Vector2i key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.Address == item.Address).Key;
				Vector2i pos2 = InventorySlotUiElement.SlotClickLocation(key);
				SpecialSetMousePosition(pos2);
				Thread.Sleep(5);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
				if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
				{
					Thread.Sleep(5);
					LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
					Thread.Sleep(5);
				}
				return FastMoveResult.None;
			}
			return FastMoveResult.ItemNotFound;
		}
		return FastMoveResult.CursorFull;
	}

	public FastMoveResult FastMove(int id, bool actuallyMove = true, bool ignoreIncubators = true)
	{
		if (!Hooking.IsInstalled)
		{
			return FastMoveResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			return FastMoveResult.CursorFull;
		}
		if (!HasCustomTabOverride)
		{
			if (SingleSlotUiElement != null)
			{
				Item item2 = SingleSlotUiElement.Item;
				if (!(item2 == null))
				{
					Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
					LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
					Thread.Sleep(5);
					SpecialSetMousePosition(pos);
					Thread.Sleep(5);
					MouseManager.ClickLMB();
					Thread.Sleep(15);
					LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
					Thread.Sleep(5);
					if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
					{
						Thread.Sleep(5);
						LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
						Thread.Sleep(5);
					}
					return FastMoveResult.None;
				}
				return FastMoveResult.ItemNotFound;
			}
			if (!(InventorySlotUiElement != null))
			{
				return FastMoveResult.Unsupported;
			}
			Item item = Inventory.GetItemById(id);
			if (item == null)
			{
				return FastMoveResult.ItemNotFound;
			}
			Vector2i key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.Address == item.Address).Key;
			Vector2i pos2 = InventorySlotUiElement.SlotClickLocation(key);
			SpecialSetMousePosition(pos2);
			Thread.Sleep(5);
			LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
			Thread.Sleep(5);
			MouseManager.ClickLMB();
			Thread.Sleep(15);
			LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
			if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
			{
				Thread.Sleep(5);
				LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
				Thread.Sleep(5);
			}
			return FastMoveResult.None;
		}
		if (!HasRewardTabOverride)
		{
			return FastMoveResult.Unsupported;
		}
		return FastMoveReward(id, actuallyMove);
	}

	public FastMoveResult FastMove(bool actuallyMove = true, bool ignoreIncubators = true, bool IgnoreCursorState = false)
	{
		if (!Hooking.IsInstalled)
		{
			return FastMoveResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.IsOpened && !IgnoreCursorState)
		{
			return FastMoveResult.CursorFull;
		}
		if (!HasDivinationTabOverride)
		{
			if (SingleSlotUiElement != null)
			{
				Item item = SingleSlotUiElement.Item;
				if (item == null)
				{
					return FastMoveResult.ItemNotFound;
				}
				Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
				Thread.Sleep(5);
				SpecialSetMousePosition(pos);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
				if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
				{
					Thread.Sleep(5);
					LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
					Thread.Sleep(5);
				}
				return FastMoveResult.None;
			}
			_ = InventorySlotUiElement != null;
			return FastMoveResult.Unsupported;
		}
		Item item2 = SingleSlotUiElement.Item;
		if (!(item2 == null))
		{
			LokiPoe.InGameState.StashUi.SetHighlightKeyword(item2.Name);
			if (SingleSlotUiElement.IsVisible)
			{
				Vector2i pos2 = SingleSlotUiElement.CenterClickLocation();
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, short.MinValue);
				Thread.Sleep(5);
				SpecialSetMousePosition(pos2);
				Thread.Sleep(5);
				MouseManager.ClickLMB();
				Thread.Sleep(15);
				LokiPoe.ProcessHookManager.SetKeyState(Keys.ControlKey, 0);
				if (LokiPoe.InGameState.GlobalWarningDialog.IsVendoringItemWithIncubatorsOverlayOpen && ignoreIncubators)
				{
					Thread.Sleep(5);
					LokiPoe.InGameState.GlobalWarningDialog.ConfirmDialog();
					Thread.Sleep(5);
				}
				LokiPoe.InGameState.StashUi.SetHighlightKeyword("");
				Thread.Sleep(5);
				return FastMoveResult.None;
			}
			return FastMoveResult.ItemNotFound;
		}
		return FastMoveResult.ItemNotFound;
	}

	public MergeStackResult MergeStack(int id, bool actuallyMerge = true)
	{
		if (!Hooking.IsInstalled)
		{
			return MergeStackResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.PhysicalMove)
		{
			return MergeStackResult.NoPhysicalItem;
		}
		if (HasCustomTabOverride)
		{
			return MergeStackResult.Unsupported;
		}
		if (!(SingleSlotUiElement != null))
		{
			if (InventorySlotUiElement != null)
			{
				Item item = Inventory.GetItemById(id);
				if (!(item == null))
				{
					if (!item.Metadata.Equals(LokiPoe.InGameState.CursorItemOverlay.Item.Metadata, StringComparison.OrdinalIgnoreCase))
					{
						Vector2i key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == item.LocalId).Key;
						Vector2i pos = InventorySlotUiElement.SlotClickLocation(key);
						SpecialSetMousePosition(pos);
						Thread.Sleep(15);
						MouseManager.ClickLMB();
						Thread.Sleep(35);
						return MergeStackResult.None;
					}
					return MergeStackResult.IncompatibleItemType;
				}
				return MergeStackResult.ItemNotFound;
			}
			return MergeStackResult.Unsupported;
		}
		Item item2 = null;
		item2 = ((CustomTabItem != null) ? CustomTabItem : SingleSlotUiElement.Item);
		if (!(item2 == null))
		{
			if (!item2.Metadata.Equals(LokiPoe.InGameState.CursorItemOverlay.Item.Metadata, StringComparison.OrdinalIgnoreCase))
			{
				Vector2i pos2 = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				SpecialSetMousePosition(pos2);
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(35);
				return MergeStackResult.None;
			}
			return MergeStackResult.IncompatibleItemType;
		}
		return MergeStackResult.ItemNotFound;
	}

	public MergeStackResult MergeStack(bool actuallyMerge = true)
	{
		if (!Hooking.IsInstalled)
		{
			return MergeStackResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.PhysicalMove)
		{
			return MergeStackResult.NoPhysicalItem;
		}
		if (!HasDivinationTabOverride)
		{
			long num;
			if (!HasCustomTabOverride)
			{
				if (!bool_7HasSingleItemOverride)
				{
					return MergeStackResult.Unsupported;
				}
				num = Dictionary_0.FirstOrDefault().Value;
			}
			else
			{
				num = base.Address;
			}
			if (num != 0L)
			{
				Item item = null;
				if (HasCustomTabOverride)
				{
					item = CustomTabItem;
				}
				else if (bool_7HasSingleItemOverride)
				{
					item = Inventory.Items.FirstOrDefault();
				}
				if (item == null)
				{
					return MergeStackResult.ItemNotFound;
				}
				if (string_0CustomTabMetadata.Equals(LokiPoe.InGameState.CursorItemOverlay.Item.Metadata, StringComparison.OrdinalIgnoreCase))
				{
					Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
					SpecialSetMousePosition(pos);
					Thread.Sleep(15);
					MouseManager.ClickLMB();
					Thread.Sleep(35);
					return MergeStackResult.None;
				}
				return MergeStackResult.IncompatibleItemType;
			}
			return MergeStackResult.ItemNotFound;
		}
		return MergeStackResult.Unsupported;
	}

	public OpenDisplayNoteResult OpenDisplayNote(bool actuallyUse = true)
	{
		if (!Hooking.IsInstalled)
		{
			return OpenDisplayNoteResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			return OpenDisplayNoteResult.CursorFull;
		}
		if (!HasCustomTabOverride)
		{
			return OpenDisplayNoteResult.Unsupported;
		}
		if (!HasDivinationTabOverride)
		{
			if (!(CustomTabItem == null))
			{
				Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				SpecialSetMousePosition(pos);
				Thread.Sleep(25);
				MouseManager.ClickRMB(pos.X, pos.Y);
				Thread.Sleep(60);
				return OpenDisplayNoteResult.None;
			}
			return OpenDisplayNoteResult.ItemNotFound;
		}
		Item item = SingleSlotUiElement.Item;
		if (item == null)
		{
			return OpenDisplayNoteResult.ItemNotFound;
		}
		LokiPoe.InGameState.StashUi.SetHighlightKeyword(item.Name);
		if (SingleSlotUiElement.IsVisible)
		{
			Vector2i pos2 = SingleSlotUiElement.CenterClickLocation();
			SpecialSetMousePosition(pos2);
			Thread.Sleep(15);
			MouseManager.ClickRMB(pos2.X, pos2.Y);
			Thread.Sleep(15);
			return OpenDisplayNoteResult.None;
		}
		return OpenDisplayNoteResult.ItemNotFound;
	}

	public OpenDisplayNoteResult OpenDisplayNote(int id, bool actuallyUse = true)
	{
		if (!Hooking.IsInstalled)
		{
			return OpenDisplayNoteResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (!LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			if (!bool_7HasSingleItemOverride && !bool_8HasEquippableItemOverride && !HasCustomTabOverride)
			{
				KeyValuePair<Vector2i, Item> keyValuePair = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value.LocalId == id);
				if (!(keyValuePair.Value == null))
				{
					if (!(Inventory.GetItemById(id) == null))
					{
						Vector2i key = keyValuePair.Key;
						Vector2i pos = InventorySlotUiElement.SlotClickLocation(key);
						SpecialSetMousePosition(pos);
						Thread.Sleep(15);
						MouseManager.ClickRMB(pos.X, pos.Y);
						Thread.Sleep(15);
						return OpenDisplayNoteResult.None;
					}
					return OpenDisplayNoteResult.ItemNotFound;
				}
				return OpenDisplayNoteResult.ItemNotFound;
			}
			return OpenDisplayNoteResult.Unsupported;
		}
		return OpenDisplayNoteResult.CursorFull;
	}

	public SplitStackResult SplitStack(int value, bool actuallySplit = true)
	{
		if (value < 1)
		{
			return SplitStackResult.InvalidQuantity;
		}
		if (!Hooking.IsInstalled)
		{
			return SplitStackResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
		{
			return SplitStackResult.CursorFull;
		}
		Item item;
		if (!HasCustomTabOverride)
		{
			if (SingleSlotUiElement == null)
			{
				return SplitStackResult.Unsupported;
			}
			item = SingleSlotUiElement.Item;
		}
		else
		{
			item = CustomTabItem;
		}
		if (item == null)
		{
			return SplitStackResult.ItemNotFound;
		}
		if (value >= item.StackCount)
		{
			return (FastMove() != 0) ? SplitStackResult.InvalidQuantity : SplitStackResult.None;
		}
		if (HasDivinationTabOverride)
		{
			LokiPoe.InGameState.StashUi.SetHighlightKeyword(item.Name);
			if (!SingleSlotUiElement.IsVisible)
			{
				return SplitStackResult.ItemNotFound;
			}
			Vector2i pos = SingleSlotUiElement.CenterClickLocation();
			SpecialSetMousePosition(pos);
			LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, short.MinValue);
			LokiPoe.Input.SimulateKeyEvent(Keys.ShiftKey);
			Thread.Sleep(5);
			MouseManager.ClickLMB();
			Thread.Sleep(15);
			LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, 0);
			Thread.Sleep(5);
			SplitStackResult result;
			if (!LokiPoe.InGameState.SplitStackUi.IsOpened)
			{
				result = SplitStackResult.SplitStackUiDidNotOpen;
			}
			else
			{
				int num = 0;
				int num2 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
				if (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
				{
					char[] array = value.ToString().ToCharArray();
					char[] array2 = array;
					foreach (char ch in array2)
					{
						LokiPoe.Input.SimulateKeyEvent(ch);
						Thread.Sleep(15);
					}
				}
				while (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
				{
					if (LokiPoe.InGameState.SplitStackUi.IsOpened)
					{
						if (LokiPoe.InGameState.SplitStackUi.SplitQuantity < value)
						{
							LokiPoe.InGameState.SplitStackUi.IncreaseSplitQuantity();
							num++;
							int splitQuantity = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
							if (splitQuantity != num2)
							{
								num2 = splitQuantity;
								num = 0;
							}
							if (num > 3)
							{
								break;
							}
						}
						if (LokiPoe.InGameState.SplitStackUi.SplitQuantity > value)
						{
							LokiPoe.InGameState.SplitStackUi.DecreaseSplitQuantity();
							num++;
							int splitQuantity2 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
							if (splitQuantity2 != num2)
							{
								num2 = splitQuantity2;
								num = 0;
							}
							if (num > 3)
							{
								break;
							}
						}
						continue;
					}
					return SplitStackResult.SplitStackUiDidNotOpen;
				}
				if (LokiPoe.InGameState.SplitStackUi.SplitQuantity == value)
				{
					LokiPoe.InGameState.SplitStackUi.Accept(actuallySplit);
					result = SplitStackResult.None;
				}
				else
				{
					LokiPoe.InGameState.SplitStackUi.Cancel();
					result = SplitStackResult.Failed;
				}
			}
			LokiPoe.InGameState.StashUi.SetHighlightKeyword("");
			return result;
		}
		Vector2i pos2 = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
		SpecialSetMousePosition(pos2);
		LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, short.MinValue);
		LokiPoe.Input.SimulateKeyEvent(Keys.ShiftKey);
		Thread.Sleep(5);
		MouseManager.ClickLMB();
		Thread.Sleep(5);
		LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, 0);
		Thread.Sleep(5);
		if (LokiPoe.InGameState.SplitStackUi.IsOpened)
		{
			int num3 = 0;
			int num4 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
			if (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
			{
				char[] array3 = value.ToString().ToCharArray();
				char[] array4 = array3;
				foreach (char ch2 in array4)
				{
					LokiPoe.Input.SimulateKeyEvent(ch2);
					Thread.Sleep(15);
				}
			}
			while (true)
			{
				if (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
				{
					if (!LokiPoe.InGameState.SplitStackUi.IsOpened)
					{
						break;
					}
					if (LokiPoe.InGameState.SplitStackUi.SplitQuantity < value)
					{
						LokiPoe.InGameState.SplitStackUi.IncreaseSplitQuantity();
						num3++;
						int splitQuantity3 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
						if (splitQuantity3 != num4)
						{
							num4 = splitQuantity3;
							num3 = 0;
						}
						if (num3 > 3)
						{
							goto IL_0349;
						}
					}
					if (LokiPoe.InGameState.SplitStackUi.SplitQuantity <= value)
					{
						continue;
					}
					LokiPoe.InGameState.SplitStackUi.DecreaseSplitQuantity();
					num3++;
					int splitQuantity4 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
					if (splitQuantity4 != num4)
					{
						num4 = splitQuantity4;
						num3 = 0;
					}
					if (num3 <= 3)
					{
						continue;
					}
				}
				goto IL_0349;
				IL_0349:
				if (LokiPoe.InGameState.SplitStackUi.SplitQuantity == value)
				{
					LokiPoe.InGameState.SplitStackUi.Accept(actuallySplit);
					return SplitStackResult.None;
				}
				LokiPoe.InGameState.SplitStackUi.Cancel();
				return SplitStackResult.Failed;
			}
			return SplitStackResult.SplitStackUiDidNotOpen;
		}
		return SplitStackResult.SplitStackUiDidNotOpen;
	}

	public SplitStackResult SplitStack(int id, int value, bool actuallySplit = true)
	{
		if (value < 1)
		{
			return SplitStackResult.InvalidQuantity;
		}
		if (Hooking.IsInstalled)
		{
			HookManager.ResetKeyState();
			if (HasCustomTabOverride)
			{
				return SplitStackResult.Unsupported;
			}
			if (!(SingleSlotUiElement != null))
			{
				if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
				{
					return SplitStackResult.CursorFull;
				}
				KeyValuePair<Vector2i, Item> keyValuePair = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value.LocalId == id);
				if (!(keyValuePair.Value == null))
				{
					Item itemById = Inventory.GetItemById(id);
					if (value >= itemById.StackCount)
					{
						return (FastMove(id) != 0) ? SplitStackResult.InvalidQuantity : SplitStackResult.None;
					}
					LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, short.MinValue);
					LokiPoe.Input.SimulateKeyEvent(Keys.ShiftKey);
					Vector2i key = keyValuePair.Key;
					Vector2i pos = InventorySlotUiElement.SlotClickLocation(key);
					SpecialSetMousePosition(pos);
					Thread.Sleep(5);
					MouseManager.ClickLMB(pos.X, pos.Y);
					Thread.Sleep(15);
					LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, 0);
					Thread.Sleep(5);
					if (!LokiPoe.InGameState.SplitStackUi.IsOpened)
					{
						return SplitStackResult.SplitStackUiDidNotOpen;
					}
					int num = 0;
					int num2 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
					if (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
					{
						char[] array = value.ToString().ToCharArray();
						char[] array2 = array;
						foreach (char ch in array2)
						{
							LokiPoe.Input.SimulateKeyEvent(ch);
							Thread.Sleep(15);
						}
					}
					while (LokiPoe.InGameState.SplitStackUi.SplitQuantity != value)
					{
						if (LokiPoe.InGameState.SplitStackUi.IsOpened)
						{
							if (LokiPoe.InGameState.SplitStackUi.SplitQuantity < value)
							{
								LokiPoe.InGameState.SplitStackUi.IncreaseSplitQuantity();
								num++;
								int splitQuantity = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
								if (splitQuantity != num2)
								{
									num2 = splitQuantity;
									num = 0;
								}
								if (num > 3)
								{
									break;
								}
							}
							if (LokiPoe.InGameState.SplitStackUi.SplitQuantity > value)
							{
								LokiPoe.InGameState.SplitStackUi.DecreaseSplitQuantity();
								num++;
								int splitQuantity2 = LokiPoe.InGameState.SplitStackUi.SplitQuantity;
								if (splitQuantity2 != num2)
								{
									num2 = splitQuantity2;
									num = 0;
								}
								if (num > 3)
								{
									break;
								}
							}
							continue;
						}
						return SplitStackResult.SplitStackUiDidNotOpen;
					}
					if (LokiPoe.InGameState.SplitStackUi.SplitQuantity == value)
					{
						LokiPoe.InGameState.SplitStackUi.Accept(actuallySplit);
						return SplitStackResult.None;
					}
					LokiPoe.InGameState.SplitStackUi.Cancel();
					return SplitStackResult.Failed;
				}
				return SplitStackResult.ItemNotFound;
			}
			return SplitStackResult.Unsupported;
		}
		return SplitStackResult.ProcessHookManagerNotEnabled;
	}

	public UseItemResult UseItem(int id, bool actuallyUse = true)
	{
		if (!Hooking.IsInstalled)
		{
			return UseItemResult.ProcessHookManagerNotEnabled;
		}
		if (!HasCustomTabOverride)
		{
			HookManager.ResetKeyState();
			if (!LokiPoe.InGameState.CursorItemOverlay.IsOpened)
			{
				if (SingleSlotUiElement != null)
				{
					Item item2 = null;
					item2 = ((CustomTabItem != null) ? CustomTabItem : SingleSlotUiElement.Item);
					if (item2 == null)
					{
						return UseItemResult.ItemNotFound;
					}
					if (item2.Components.UsableComponent == null && (!item2.HasMetadataFlags(MetadataFlags.Leaguestones) || Inventory.PageType != InventoryType.Leaguestone))
					{
						return UseItemResult.ItemNotUsable;
					}
					Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
					SpecialSetMousePosition(pos);
					Thread.Sleep(15);
					MouseManager.ClickRMB();
					Thread.Sleep(35);
					return UseItemResult.None;
				}
				if (InventorySlotUiElement != null)
				{
					Item item = Inventory.GetItemById(id);
					if (!(item == null))
					{
						if (item.Components.UsableComponent == null && (!item.HasMetadataFlags(MetadataFlags.Leaguestones) || Inventory.PageType != InventoryType.Leaguestone))
						{
							return UseItemResult.ItemNotUsable;
						}
						Vector2i key = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == item.LocalId).Key;
						Vector2i pos2 = InventorySlotUiElement.SlotClickLocation(key);
						SpecialSetMousePosition(pos2);
						Thread.Sleep(17);
						MouseManager.ClickRMB();
						Thread.Sleep(13);
						return UseItemResult.None;
					}
					return UseItemResult.ItemNotFound;
				}
				return UseItemResult.Unsupported;
			}
			return UseItemResult.CursorFull;
		}
		return UseItemResult.Unsupported;
	}

	public UseItemResult UseItem(bool actuallyUse = true)
	{
		if (!Hooking.IsInstalled)
		{
			return UseItemResult.ProcessHookManagerNotEnabled;
		}
		if (!HasDivinationTabOverride)
		{
			HookManager.ResetKeyState();
			if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
			{
				return UseItemResult.CursorFull;
			}
			if (!(SingleSlotUiElement != null))
			{
				_ = InventorySlotUiElement != null;
				return UseItemResult.Unsupported;
			}
			Item item = null;
			item = ((CustomTabItem != null) ? CustomTabItem : SingleSlotUiElement.Item);
			if (item == null)
			{
				return UseItemResult.ItemNotFound;
			}
			if (item.Components.UsableComponent == null && (!item.HasMetadataFlags(MetadataFlags.Leaguestones) || Inventory.PageType != InventoryType.Leaguestone))
			{
				return UseItemResult.ItemNotUsable;
			}
			Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
			SpecialSetMousePosition(pos);
			Thread.Sleep(15);
			MouseManager.ClickRMB();
			Thread.Sleep(35);
			return UseItemResult.None;
		}
		return UseItemResult.Unsupported;
	}

	public static ApplyCursorResult BeginApplyCursor(bool holdShift = false)
	{
		if (!Hooking.IsInstalled)
		{
			return ApplyCursorResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (holdShift)
		{
			LokiPoe.ProcessHookManager.SetKeyState(Keys.ShiftKey, short.MinValue);
		}
		return ApplyCursorResult.None;
	}

	public static ApplyCursorResult EndApplyCursor()
	{
		if (!Hooking.IsInstalled)
		{
			return ApplyCursorResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		return ApplyCursorResult.None;
	}

	public ApplyCursorResult ApplyCursorAt(int col, int row, bool actuallyApply = true)
	{
		if (HasCustomTabOverride)
		{
			return ApplyCursorResult.Unsupported;
		}
		Item itemAtLocation = Inventory.GetItemAtLocation(col, row);
		if (!(itemAtLocation == null))
		{
			return ApplyCursorTo(itemAtLocation.LocalId);
		}
		return ApplyCursorResult.ItemNotFound;
	}

	public ApplyCursorResult ApplyCursorTo(bool actuallyApply = true)
	{
		if (!Hooking.IsInstalled)
		{
			return ApplyCursorResult.ProcessHookManagerNotEnabled;
		}
		if (!HasDivinationTabOverride)
		{
			if (HasCustomTabOverride)
			{
				if (LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.VirtualUse)
				{
					return ApplyCursorResult.NoItemToApply;
				}
				if (SingleSlotUiElement != null)
				{
					Item item = SingleSlotUiElement.Item;
					if (!(item == null))
					{
						if (!item.IsMirrored && !item.IsCorrupted && !item.AnyMetadataFlags(MetadataFlags.Currency, MetadataFlags.QuestItems, MetadataFlags.CurrencyItemisedProphecy))
						{
							Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
							SpecialSetMousePosition(pos);
							Thread.Sleep(15);
							MouseManager.ClickLMB();
							Thread.Sleep(35);
							return ApplyCursorResult.None;
						}
						return ApplyCursorResult.UnsupportedItem;
					}
					return ApplyCursorResult.ItemNotFound;
				}
				_ = InventorySlotUiElement != null;
				return ApplyCursorResult.Unsupported;
			}
			return ApplyCursorResult.Unsupported;
		}
		return ApplyCursorResult.Unsupported;
	}

	public ApplyCursorResult ApplyCursorTo(int id, bool actuallyApply = true)
	{
		if (!Hooking.IsInstalled)
		{
			return ApplyCursorResult.ProcessHookManagerNotEnabled;
		}
		if ((!bool_7HasSingleItemOverride && !HasCustomTabOverride) || (bool_7HasSingleItemOverride && bool_8HasEquippableItemOverride))
		{
			if (LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.VirtualUse)
			{
				return ApplyCursorResult.NoItemToApply;
			}
			Item itemById = Inventory.GetItemById(id);
			if (itemById == null)
			{
				return ApplyCursorResult.ItemNotFound;
			}
			if (!(SingleSlotUiElement != null))
			{
				if (!(InventorySlotUiElement != null))
				{
					return ApplyCursorResult.Unsupported;
				}
				KeyValuePair<Vector2i, Item> keyValuePair = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == itemById.LocalId);
				if (keyValuePair.Value == null)
				{
					return ApplyCursorResult.ItemNotFound;
				}
				Vector2i vector2i = new Vector2i((int)((float)(keyValuePair.Key.X * InventorySlotUiElement.slotsize) * InventorySlotUiElement.Scale + (float)InventorySlotUiElement.LocationTopLeft.X - (float)InventorySlotUiElement.slotsize * InventorySlotUiElement.Scale / 2f), (int)((float)(keyValuePair.Key.Y * InventorySlotUiElement.slotsize) * InventorySlotUiElement.Scale + (float)InventorySlotUiElement.LocationTopLeft.Y - (float)InventorySlotUiElement.slotsize * InventorySlotUiElement.Scale / 2f));
				Vector2i pos = vector2i;
				SpecialSetMousePosition(pos);
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(35);
				return ApplyCursorResult.None;
			}
			Vector2i pos2 = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
			Item item = SingleSlotUiElement.Item;
			if (item != null)
			{
				SpecialSetMousePosition(pos2);
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(35);
				return ApplyCursorResult.None;
			}
		}
		return ApplyCursorResult.Unsupported;
	}

	public PlaceCursorIntoResult PlaceCursorInto(int col, int row, bool allowOverlap = false, bool actuallyPlace = true)
	{
		if (!Hooking.IsInstalled)
		{
			return PlaceCursorIntoResult.ProcessHookManagerNotEnabled;
		}
		HookManager.ResetKeyState();
		if (!bool_7HasSingleItemOverride && !HasCustomTabOverride)
		{
			if (LokiPoe.InGameState.CursorItemOverlay.Mode == LokiPoe.InGameState.CursorItemModes.PhysicalMove || LokiPoe.InGameState.CursorItemOverlay.Mode == LokiPoe.InGameState.CursorItemModes.VirtualMove)
			{
				Vector2i size = LokiPoe.InGameState.CursorItemOverlay.Item.Size;
				Inventory inventory = Inventory;
				if (!inventory.CanFitItemAt(col, row, size.X, size.Y, allowOverlap, out var overlapped))
				{
					if (!overlapped)
					{
						return PlaceCursorIntoResult.ItemWontFit;
					}
					return PlaceCursorIntoResult.OverlapNotAllowed;
				}
				if (!(SingleSlotUiElement != null))
				{
					if (!(InventorySlotUiElement != null))
					{
						return PlaceCursorIntoResult.Unsupported;
					}
					Vector2i slot = new Vector2i(col + 1 + Math.Abs(size.X / 2), row + 1 + Math.Abs(size.Y / 2));
					Item item = InventorySlotUiElement.PlacementGraph[new Vector2i(col + 1, row + 1)];
					if (item == null)
					{
						Vector2i pos = InventorySlotUiElement.SlotClickLocation(slot);
						SpecialSetMousePosition(pos);
						Thread.Sleep(15);
						MouseManager.ClickLMB();
						Thread.Sleep(35);
						return PlaceCursorIntoResult.None;
					}
					if (allowOverlap)
					{
						Vector2i pos2 = InventorySlotUiElement.SlotClickLocation(slot);
						SpecialSetMousePosition(pos2);
						Thread.Sleep(15);
						MouseManager.ClickLMB();
						Thread.Sleep(35);
						return PlaceCursorIntoResult.None;
					}
					return PlaceCursorIntoResult.OverlapNotAllowed;
				}
				Vector2i pos3 = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				Item item2 = SingleSlotUiElement.Item;
				if (item2 == null)
				{
					SpecialSetMousePosition(pos3);
					Thread.Sleep(15);
					MouseManager.ClickLMB();
					Thread.Sleep(35);
					return PlaceCursorIntoResult.None;
				}
				if (!allowOverlap)
				{
					return PlaceCursorIntoResult.OverlapNotAllowed;
				}
				SpecialSetMousePosition(pos3);
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(35);
				return PlaceCursorIntoResult.None;
			}
			return PlaceCursorIntoResult.NoItemToMove;
		}
		return PlaceCursorIntoResult.Unsupported;
	}

	public PlaceCursorIntoResult PlaceCursorInto(bool allowOverlap = false, bool actuallyPlace = true)
	{
		if (!Hooking.IsInstalled)
		{
			return PlaceCursorIntoResult.ProcessHookManagerNotEnabled;
		}
		if (!HasDivinationTabOverride)
		{
			HookManager.ResetKeyState();
			if (LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.PhysicalMove && LokiPoe.InGameState.CursorItemOverlay.Mode != LokiPoe.InGameState.CursorItemModes.VirtualMove)
			{
				return PlaceCursorIntoResult.NoItemToMove;
			}
			_ = base.Address;
			if (SingleSlotUiElement != null)
			{
				Vector2i pos = new Vector2i(SingleSlotUiElement.LocationTopLeft.X + SingleSlotUiElement.Size.X / 2, SingleSlotUiElement.LocationTopLeft.Y + SingleSlotUiElement.Size.Y / 2);
				Item item = null;
				item = ((CustomTabItem != null) ? CustomTabItem : SingleSlotUiElement.Item);
				if (item == null)
				{
					SpecialSetMousePosition(pos);
					Thread.Sleep(15);
					MouseManager.ClickLMB();
					Thread.Sleep(35);
					return PlaceCursorIntoResult.None;
				}
				if (!allowOverlap)
				{
					return PlaceCursorIntoResult.OverlapNotAllowed;
				}
				SpecialSetMousePosition(pos);
				Thread.Sleep(15);
				MouseManager.ClickLMB();
				Thread.Sleep(35);
				return PlaceCursorIntoResult.None;
			}
			if (!(InventorySlotUiElement != null))
			{
				return PlaceCursorIntoResult.Unsupported;
			}
			return PlaceCursorIntoResult.Unsupported;
		}
		return PlaceCursorIntoResult.Unsupported;
	}

	public UnequipSkillGemResult UnequipSkillGem(int index, bool actuallyUnequip = true)
	{
		if (!bool_7HasSingleItemOverride)
		{
			return UnequipSkillGemResult.Unsupported;
		}
		return UnequipSkillGem(SingleSlotUiElement.Item.LocalId, index, actuallyUnequip);
	}

	public UnequipSkillGemResult UnequipSkillGem(int id, int index, bool actuallyUnequip = true)
	{
		if (!Hooking.IsInstalled)
		{
			return UnequipSkillGemResult.ProcessHookManagerNotEnabled;
		}
		if (!HasCustomTabOverride)
		{
			HookManager.ResetKeyState();
			if (LokiPoe.InGameState.CursorItemOverlay.IsOpened)
			{
				return UnequipSkillGemResult.CursorFull;
			}
			Item itemById = Inventory.GetItemById(id);
			if (!(itemById == null))
			{
				if (itemById.GetGemInSocket(index) == null)
				{
					return UnequipSkillGemResult.NoSkillGem;
				}
				if (!(SingleSlotUiElement != null))
				{
					if (!(InventorySlotUiElement != null))
					{
						return UnequipSkillGemResult.ItemNotFound;
					}
					KeyValuePair<Vector2i, Item> keyValuePair = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == itemById.LocalId);
					if (InventorySlotUiElement.SocketDictionary[keyValuePair.Key].TryGetValue(index, out var value))
					{
						Vector2i pos = value;
						SpecialSetMousePosition(pos);
						Thread.Sleep(15);
						MouseManager.ClickRMB();
						Thread.Sleep(35);
						return UnequipSkillGemResult.None;
					}
					return UnequipSkillGemResult.InvalidSocketIndex;
				}
				Vector2i pos2 = SingleSlotUiElement.SocketsLocations[index];
				SpecialSetMousePosition(pos2);
				Thread.Sleep(15);
				MouseManager.ClickRMB();
				Thread.Sleep(35);
				return UnequipSkillGemResult.None;
			}
			return UnequipSkillGemResult.ItemNotFound;
		}
		return UnequipSkillGemResult.Unsupported;
	}

	public EquipSkillGemResult EquipSkillGem(int index, bool actuallyEquip = true)
	{
		if (!bool_7HasSingleItemOverride)
		{
			return EquipSkillGemResult.Unsupported;
		}
		return EquipSkillGem(SingleSlotUiElement.Item.LocalId, index, actuallyEquip);
	}

	public EquipSkillGemResult EquipSkillGem(int id, int index, bool actuallyEquip = true)
	{
		if (HasCustomTabOverride)
		{
			return EquipSkillGemResult.Unsupported;
		}
		if (Hooking.IsInstalled)
		{
			HookManager.ResetKeyState();
			if (LokiPoe.InGameState.CursorItemOverlay.Mode == LokiPoe.InGameState.CursorItemModes.PhysicalMove)
			{
				if (!LokiPoe.InGameState.CursorItemOverlay.Item.AnyMetadataFlags(MetadataFlags.Gems, MetadataFlags.JewelAbyssMelee, MetadataFlags.JewelAbyssRanged, MetadataFlags.JewelAbyssCaster, MetadataFlags.JewelAbyssSummoner))
				{
					return EquipSkillGemResult.CursorNotSkillGem;
				}
				Item itemById = Inventory.GetItemById(id);
				if (!(itemById == null))
				{
					if (itemById.IsIdentified)
					{
						if (!(SingleSlotUiElement != null))
						{
							if (InventorySlotUiElement != null)
							{
								KeyValuePair<Vector2i, Item> keyValuePair = InventorySlotUiElement.PlacementGraph.FirstOrDefault((KeyValuePair<Vector2i, Item> x) => x.Value != null && x.Value.LocalId == itemById.LocalId);
								if (InventorySlotUiElement.SocketDictionary[keyValuePair.Key].TryGetValue(index, out var value))
								{
									SpecialSetMousePosition(value);
									Thread.Sleep(15);
									MouseManager.ClickLMB();
									Thread.Sleep(35);
									return EquipSkillGemResult.None;
								}
								return EquipSkillGemResult.InvalidSocketIndex;
							}
							return EquipSkillGemResult.UnableToSocket;
						}
						if (!SingleSlotUiElement.SocketsLocations.TryGetValue(index, out var value2))
						{
							return EquipSkillGemResult.InvalidSocketIndex;
						}
						SpecialSetMousePosition(value2);
						Thread.Sleep(15);
						MouseManager.ClickLMB();
						Thread.Sleep(35);
						return EquipSkillGemResult.None;
					}
					return EquipSkillGemResult.UnsupportedItem;
				}
				return EquipSkillGemResult.ItemNotFound;
			}
			return EquipSkillGemResult.CursorNotSkillGem;
		}
		return EquipSkillGemResult.ProcessHookManagerNotEnabled;
	}

	public GetItemCostResult GetItemCostAsDouble(int id, out List<KeyValuePair<string, double>> info, out bool canAfford)
	{
		canAfford = false;
		info = null;
		Item itemById = Inventory.GetItemById(id);
		if (itemById == null)
		{
			return GetItemCostResult.GetItemByIdFailed;
		}
		if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(id, out var value))
		{
			return GetItemCostResult.CouldNotFindControlForItem;
		}
		if (value.Tooltip.ChildCount != 0L)
		{
			if (value.Tooltip.Children[0].ChildCount >= 2L)
			{
				if (value.Tooltip.Children[0].Children[1].ChildCount != 0L)
				{
					Element element = value.Tooltip.Children[0].Children[1].Children.LastOrDefault();
					if ((object)element != null && element.ChildCount == 0L)
					{
						return GetItemCostResult.InternalError3;
					}
					Element element2 = value.Tooltip?.Children[0]?.Children[1]?.Children?.LastOrDefault();
					if (!(element2 == null))
					{
						List<Element> list = element2.Children.Where((Element x) => x.ChildCount > 0L).ToList();
						if (list.Count == 0)
						{
							return GetItemCostResult.CostTextNotFound;
						}
						canAfford = true;
						info = new List<KeyValuePair<string, double>>();
						foreach (Element item in list)
						{
							string input = item.Children[0].Text.Replace("x", "").Replace(",", "").Replace(".", "")
								.Replace(" ", "");
							string pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
							string replacement = "";
							Regex regex = new Regex(pattern);
							string text = regex.Replace(input, replacement).Trim();
							if (text.StartsWith("0"))
							{
								text = text.Insert(1, ".");
							}
							if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
							{
								string text2 = item.Children[2].Text;
								info.Add(new KeyValuePair<string, double>(text2, result));
								if (canAfford && base.M.ReadUInt(item.Children[2].Address + 448L) == 4291952640u)
								{
									canAfford = false;
								}
								continue;
							}
							ilog_0.ErrorFormat($"[GetItemCostAsDouble] Error parsing item cost lable: Original: {item}, Parsed: {text}", Array.Empty<object>());
							return GetItemCostResult.CostTextNotFound;
						}
						return GetItemCostResult.None;
					}
					return GetItemCostResult.InternalError4;
				}
				return GetItemCostResult.InternalError2;
			}
			return GetItemCostResult.InternalError1;
		}
		return GetItemCostResult.NoTooltip;
	}

	public GetItemCostResult GetItemCostEx(int id, out List<KeyValuePair<string, int>> info, out bool canAfford)
	{
		canAfford = false;
		info = null;
		Item itemById = Inventory.GetItemById(id);
		if (!(itemById == null))
		{
			if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(id, out var value))
			{
				return GetItemCostResult.CouldNotFindControlForItem;
			}
			if (value.Tooltip.ChildCount == 0L)
			{
				return GetItemCostResult.NoTooltip;
			}
			if (value.Tooltip.Children[0].ChildCount < 2L)
			{
				return GetItemCostResult.InternalError1;
			}
			if (value.Tooltip.Children[0].Children[1].ChildCount != 0L)
			{
				Element element = value.Tooltip.Children[0].Children[1].Children.LastOrDefault();
				if ((object)element != null && element.ChildCount == 0L)
				{
					return GetItemCostResult.InternalError3;
				}
				Element element2 = value.Tooltip?.Children[0]?.Children[1]?.Children?.LastOrDefault();
				if (element2 == null)
				{
					return GetItemCostResult.InternalError4;
				}
				List<Element> list = element2.Children.Where((Element x) => x.ChildCount > 0L).ToList();
				if (list.Count == 0)
				{
					return GetItemCostResult.CostTextNotFound;
				}
				canAfford = true;
				info = new List<KeyValuePair<string, int>>();
				foreach (Element item in list)
				{
					string input = item.Children[0].Text.Replace("x", "").Replace(",", "").Replace(".", "")
						.Replace(" ", "");
					string pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
					string replacement = "";
					Regex regex = new Regex(pattern);
					string text = regex.Replace(input, replacement).Trim();
					if (int.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
					{
						string text2 = item.Children[2].Text;
						info.Add(new KeyValuePair<string, int>(text2, result));
						if (canAfford && base.M.ReadUInt(item.Children[2].Address + 448L) == 4291952640u)
						{
							canAfford = false;
						}
						continue;
					}
					ilog_0.ErrorFormat($"[GetItemCostEx] Error parsing item cost lable: Original: {item}, Parsed: {text}", Array.Empty<object>());
					return GetItemCostResult.CostTextNotFound;
				}
				return GetItemCostResult.None;
			}
			return GetItemCostResult.InternalError2;
		}
		return GetItemCostResult.GetItemByIdFailed;
	}

	public GetItemTributeCostResult GetItemTributeCostEx(int id, out int tributeCost, out bool canAfford)
	{
		canAfford = false;
		tributeCost = int.MaxValue;
		Item itemById = Inventory.GetItemById(id);
		if (!(itemById == null))
		{
			if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(id, out var value))
			{
				return GetItemTributeCostResult.CouldNotFindControlForItem;
			}
			if (value.Tooltip.ChildCount == 0L)
			{
				return GetItemTributeCostResult.NoTooltip;
			}
			if (value.Tooltip.Children[0].ChildCount >= 2L)
			{
				if (value.Tooltip.Children[0].Children[1].ChildCount != 0L)
				{
					Element element = value.Tooltip?.Children[0]?.Children[1];
					if (element == null)
					{
						return GetItemTributeCostResult.InternalError4;
					}
					if (!string.IsNullOrEmpty(element.Children[0].Text) && element.Children[0].Text == "Complete more Rituals in this area to reveal this item")
					{
						return GetItemTributeCostResult.HiddenItem;
					}
					canAfford = true;
					Element element2 = SearchChildrenForString(element.Children, "Cost:");
					if (element2 == null)
					{
						return GetItemTributeCostResult.NoTooltip;
					}
					string text = element2.Parent.Children[1]?.Children[0]?.Text;
					if (text == null)
					{
						return GetItemTributeCostResult.NoTooltip;
					}
					string input = text.Replace("x", "").Replace(".", "").Replace(",", "")
						.Replace(" ", "");
					string pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
					string replacement = "";
					Regex regex = new Regex(pattern);
					string text2 = regex.Replace(input, replacement).Trim();
					if (int.TryParse(text2, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
					{
						tributeCost = result;
						canAfford = tributeCost <= LokiPoe.InstanceInfo.Ritual.Tributes;
						return GetItemTributeCostResult.None;
					}
					ilog_0.ErrorFormat("[GetItemTributeCostEx] Error parsing tribute cost lable: Original: " + text + ", Parsed: " + text2, Array.Empty<object>());
					return GetItemTributeCostResult.CostTextNotFound;
				}
				return GetItemTributeCostResult.InternalError2;
			}
			return GetItemTributeCostResult.InternalError1;
		}
		return GetItemTributeCostResult.GetItemByIdFailed;
	}

	public GetItemDeferalCostResult GetItemDeferalCostEx(int id, out int futureDiscount, out int deferalFee, out int totalDeferalCost)
	{
		futureDiscount = int.MaxValue;
		deferalFee = int.MaxValue;
		totalDeferalCost = int.MaxValue;
		if (!LokiPoe.InGameState.RitualFavorsUi.IsDeferItemActive)
		{
			return GetItemDeferalCostResult.DeferNotActive;
		}
		Item itemById = Inventory.GetItemById(id);
		if (!(itemById == null))
		{
			if (!InventorySlotUiElement.DictionaryIdElements.TryGetValue(id, out var value))
			{
				return GetItemDeferalCostResult.CouldNotFindControlForItem;
			}
			if (value.Tooltip.ChildCount != 0L)
			{
				if (value.Tooltip.Children[0].ChildCount < 2L)
				{
					return GetItemDeferalCostResult.InternalError1;
				}
				if (value.Tooltip.Children[0].Children[1].ChildCount == 0L)
				{
					return GetItemDeferalCostResult.InternalError2;
				}
				Element element = value.Tooltip?.Children[0]?.Children[1];
				if (element == null)
				{
					return GetItemDeferalCostResult.InternalError4;
				}
				if (!string.IsNullOrEmpty(element.Children[0].Text) && element.Children[0].Text == "Complete more Rituals in this area to reveal this item")
				{
					return GetItemDeferalCostResult.HiddenItem;
				}
				Element element2 = SearchChildrenForString(element.Children, "Future Discount:");
				Element element3 = SearchChildrenForString(element.Children, "Deferral Fee:");
				if (!(element2 == null) && !(element3 == null))
				{
					Element parent = element2.Parent;
					Element parent2 = element3.Parent;
					if (parent == null)
					{
						return GetItemDeferalCostResult.NoTooltip;
					}
					string text = parent.Children[1].Children[0].Text;
					if (text == null)
					{
						return GetItemDeferalCostResult.NoTooltip;
					}
					string input = text.Replace("x", "").Replace(".", "").Replace(",", "")
						.Replace(" ", "");
					string pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
					string replacement = "";
					Regex regex = new Regex(pattern);
					string text2 = regex.Replace(input, replacement).Trim();
					if (int.TryParse(text2, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
					{
						futureDiscount = result;
						if (!(parent2 == null))
						{
							string text3 = parent2.Children[1].Children[0].Text;
							if (text3 != null)
							{
								input = text3.Replace("x", "").Replace(".", "").Replace(",", "")
									.Replace(" ", "");
								pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
								replacement = "";
								regex = new Regex(pattern);
								text2 = regex.Replace(input, replacement).Trim();
								if (int.TryParse(text2, NumberStyles.Any, CultureInfo.InvariantCulture, out var result2))
								{
									deferalFee = result2;
									totalDeferalCost = futureDiscount + deferalFee;
									return GetItemDeferalCostResult.None;
								}
								ilog_0.ErrorFormat("[GetItemTributeCostEx] Error parsing Discount cost lable: Original: " + text3 + ", Parsed: " + text2, Array.Empty<object>());
								return GetItemDeferalCostResult.CostTextNotFound;
							}
							return GetItemDeferalCostResult.NoTooltip;
						}
						return GetItemDeferalCostResult.NoTooltip;
					}
					ilog_0.ErrorFormat("[GetItemTributeCostEx] Error parsing Discount cost lable: Original: " + text + ", Parsed: " + text2, Array.Empty<object>());
					return GetItemDeferalCostResult.CostTextNotFound;
				}
				return GetItemDeferalCostResult.NoTooltip;
			}
			return GetItemDeferalCostResult.NoTooltip;
		}
		return GetItemDeferalCostResult.GetItemByIdFailed;
	}

	private static Element SearchChildrenForString(List<Element> childElementChildren, string text)
	{
		if (childElementChildren.Count == 0)
		{
			return null;
		}
		Element element = null;
		foreach (Element childElementChild in childElementChildren)
		{
			if (childElementChild.Text == null || !(childElementChild.Text == text))
			{
				element = SearchChildrenForString(childElementChild.Children, text);
				if (element != null)
				{
					return element;
				}
				continue;
			}
			return childElementChild;
		}
		return element;
	}

	public bool IsItemTransparent(int id)
	{
		if (SingleSlotUiElement != null)
		{
			if (!(SingleSlotUiElement.ItemElement == null))
			{
				if (SingleSlotUiElement.Item.LocalId == id)
				{
					return SingleSlotUiElement.ItemElement.IsItemTransparent;
				}
				return false;
			}
			return false;
		}
		if (InventorySlotUiElement != null)
		{
			Element value = null;
			InventorySlotUiElement.DictionaryIdElements.TryGetValue(id, out value);
			if (value == null)
			{
				return false;
			}
			return value.IsItemTransparent;
		}
		return false;
	}

	public void SetSingleSlotUi(SingleSlotUiElement element)
	{
		SingleSlotUiElement = element;
	}

	public void SetInventorySlotUi(InventorySlotUiElement element, StashType stashType = StashType.NormalStash)
	{
		InventorySlotUiElement = element;
		if (stashType == StashType.MapDevice)
		{
			InventorySlotUiElement.SetStashType(StashType.MapDevice);
		}
	}

	public void SetInventory(Inventory inv)
	{
		inventory_0 = inv;
	}
}
