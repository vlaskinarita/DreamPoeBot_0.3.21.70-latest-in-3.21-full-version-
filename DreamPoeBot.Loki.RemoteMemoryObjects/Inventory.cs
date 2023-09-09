using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Elements.InventoryElements;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Models.Enums;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Inventory : RemoteMemoryObject
{
	public int Id => (int)base.Address;

	public long ItemsCount => Items.Count;

	public long TotalBoxesInInventoryRow => base.M.ReadInt(base.Address + 1312L);

	public long TotalBoxesInInventoryCol => base.M.ReadInt(base.Address + 1316L);

	public int CurrentPlayerInventoriesId => base.M.ReadInt(base.Address + 1272L);

	private StashType InvType => GetInvType();

	public Element InventoryUiElement => GetInventoryElement();

	public Element MapInvetoryElement => new InventorySlotUiElement(base.Address, StashType.MapStash);

	public List<Item> Items
	{
		get
		{
			Element inventoryUiElement = InventoryUiElement;
			uint num = default(uint);
			while (!(inventoryUiElement == null))
			{
				while (inventoryUiElement.Address != 0L)
				{
					while (true)
					{
						if (inventoryUiElement.IsVisible)
						{
							while (true)
							{
								List<NormalInventoryItem> list = new List<NormalInventoryItem>();
								while (true)
								{
									StashType invType = InvType;
									while (true)
									{
										List<Item> list2;
										switch (invType)
										{
										default:
										{
											int num2 = ((int)num * -105379153) ^ 0x15CDABE;
											while (true)
											{
												switch ((num = (uint)num2 ^ 0x5DAFAB45u) % 12u)
												{
												case 9u:
													break;
												case 10u:
													goto end_IL_0033;
												case 5u:
													goto end_IL_0079;
												case 6u:
													goto end_IL_00f3;
												case 1u:
													goto end_IL_0100;
												case 7u:
													goto end_IL_0108;
												case 3u:
												case 11u:
													goto IL_011f;
												case 2u:
													goto IL_012d;
												default:
													goto IL_03f6;
												case 4u:
													goto IL_057c;
												case 8u:
													goto end_IL_011f;
												}
												if (invType != StashType.RitualFavor)
												{
													num2 = (int)((num * 160547800) ^ 0xDDA1F5D);
													continue;
												}
												goto case StashType.PlayerInventory;
												continue;
												end_IL_0033:
												break;
											}
											break;
										}
										case StashType.NormalStash:
											foreach (Element child in inventoryUiElement.Children)
											{
												if (child.ChildCount != 0L)
												{
													NormalInventoryItem normalInventoryItem3 = child.AsObject<NormalInventoryItem>();
													if (normalInventoryItem3.InventPosX <= 11 && normalInventoryItem3.InventPosY <= 11)
													{
														list.Add(normalInventoryItem3);
													}
												}
											}
											goto IL_057c;
										case StashType.QuadStash:
											foreach (Element child2 in inventoryUiElement.Children)
											{
												if (child2.ChildCount != 0L)
												{
													NormalInventoryItem normalInventoryItem2 = child2.AsObject<NormalInventoryItem>();
													if (normalInventoryItem2.InventPosX <= 23 && normalInventoryItem2.InventPosY <= 23)
													{
														list.Add(normalInventoryItem2);
													}
												}
											}
											goto IL_057c;
										case StashType.CurrencyStash:
											foreach (Element child3 in inventoryUiElement.Children)
											{
												if (child3.ChildCount > 1L)
												{
													list.Add(child3.Children[1].AsObject<CurrencyInventoryItem>());
												}
											}
											goto IL_057c;
										case StashType.EssenceStash:
											foreach (Element child4 in inventoryUiElement.Children)
											{
												if (child4.ChildCount > 1L)
												{
													list.Add(child4.Children[1].AsObject<EssenceInventoryItem>());
												}
											}
											goto IL_057c;
										case StashType.DivinationStash:
											foreach (Element child5 in inventoryUiElement.Children)
											{
												if (child5.ChildCount >= 2L)
												{
													if (child5.Children[1].ChildCount > 1L)
													{
														list.Add(child5.Children[1].Children[1].AsObject<DivinationInventoryItem>());
													}
													continue;
												}
												return null;
											}
											goto IL_057c;
										case StashType.MapStash:
											foreach (Element child6 in inventoryUiElement.Children)
											{
												if (child6.ChildCount != 0L)
												{
													list.Add(child6.AsObject<NormalInventoryItem>());
												}
											}
											goto IL_057c;
										case StashType.FragmentStash:
											foreach (Element child7 in inventoryUiElement.Children)
											{
												if (child7.ChildCount > 1L)
												{
													list.Add(child7.Children[1].AsObject<FragmentInventoryItem>());
												}
											}
											goto IL_057c;
										case StashType.MapDevice:
											goto IL_03f6;
										case StashType.ParchaseStash:
											foreach (Element child8 in inventoryUiElement.Children)
											{
												if (child8.ChildCount != 0L)
												{
													NormalInventoryItem normalInventoryItem = child8.AsObject<NormalInventoryItem>();
													if (normalInventoryItem.InventPosX <= 11 && normalInventoryItem.InventPosY <= 10)
													{
														list.Add(normalInventoryItem);
													}
												}
											}
											goto IL_057c;
										case StashType.PlayerInventory:
										case StashType.SellStash:
										case StashType.TradeStash:
											foreach (Element child9 in inventoryUiElement.Children)
											{
												if (child9.ChildCount != 0L)
												{
													NormalInventoryItem normalInventoryItem5 = child9.AsObject<NormalInventoryItem>();
													if (normalInventoryItem5.InventPosX <= 11 && normalInventoryItem5.InventPosY <= 4)
													{
														list.Add(normalInventoryItem5);
													}
												}
											}
											goto IL_057c;
										case StashType.CardTrade:
										case StashType.BeastCraft:
											foreach (Element child10 in inventoryUiElement.Children)
											{
												if (child10.ChildCount > 1L)
												{
													list.Add(child10.Children[1].AsObject<NormalInventoryItem>());
												}
											}
											goto IL_057c;
										case StashType.PlayerHead:
										case StashType.PlayerNeck:
										case StashType.PlayerChest:
										case StashType.PlayerPrimaryOffHand:
										case StashType.PlayerPrimaryMainHand:
										case StashType.PlayerSecondaryOffHand:
										case StashType.PlayerSecondaryMainHand:
										case StashType.PlayerLeftRing:
										case StashType.PlayerRightRing:
										case StashType.PlayerGloves:
										case StashType.PlayerBelt:
										case StashType.PlayerBoots:
										case StashType.PlayerFlasks:
											goto IL_057c;
											IL_057c:
											list2 = new List<Item>();
											foreach (NormalInventoryItem item in list)
											{
												list2.Add(new Item(item.InnerItem.Address, hasInventoryLocation: true, new Vector2i(item.InventPosX + item.InnerItem.Size.X - 1, item.InventPosY + item.InnerItem.Size.Y - 1), new Vector2i(item.InventPosX, item.InventPosY), item.LocalId));
											}
											return list2;
											IL_03f6:
											foreach (Element child11 in inventoryUiElement.Children)
											{
												if (child11.ChildCount != 0L)
												{
													NormalInventoryItem normalInventoryItem4 = child11.AsObject<NormalInventoryItem>();
													if (normalInventoryItem4.InventPosX <= 11 && normalInventoryItem4.InventPosY <= 4)
													{
														list.Add(normalInventoryItem4);
													}
												}
											}
											goto IL_057c;
										}
										continue;
										end_IL_0079:
										break;
									}
									continue;
									end_IL_00f3:
									break;
								}
								continue;
								end_IL_0100:
								break;
							}
							continue;
						}
						goto IL_012d;
						IL_012d:
						return new List<Item>();
						continue;
						end_IL_0108:
						break;
					}
				}
				break;
				continue;
				end_IL_011f:
				break;
				IL_011f:;
			}
			return new List<Item>();
		}
	}

	private StashType GetInvType()
	{
		if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.PlayerInventory].Address)
		{
			return StashType.PlayerInventory;
		}
		if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Helm].Address)
		{
			if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Amulet].Address)
			{
				if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Belt].Address)
				{
					if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Boots].Address)
					{
						if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Chest].Address)
						{
							return StashType.PlayerChest;
						}
						if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Flask].Address)
						{
							if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.Gloves].Address)
							{
								return StashType.PlayerGloves;
							}
							if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.LRing].Address)
							{
								return StashType.PlayerLeftRing;
							}
							if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.LWeapon].Address)
							{
								if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.LWeaponSwap].Address)
								{
									return StashType.PlayerSecondaryMainHand;
								}
								if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.RRing].Address)
								{
									if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.RWeapon].Address)
									{
										return StashType.PlayerPrimaryOffHand;
									}
									if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel[InventoryIndex.RWeaponSwap].Address)
									{
										if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel.StalkerSentinelInventoryAddress)
										{
											return StashType.SentinelDrone;
										}
										if (base.Address != base.Game.IngameState.IngameUi.InventoryPanel.PandemoniumSentinelInventoryAddress)
										{
											if (base.Address == base.Game.IngameState.IngameUi.InventoryPanel.ApexSentinelInventoryAddress)
											{
												return StashType.SentinelDrone;
											}
											if (base.Address != base.Game.IngameState.IngameUi.BeastCraftingPannel.CraftSlot.Address)
											{
												if (base.Game.IngameState.IngameUi.SellPanell.IsVisible && base.Address == base.Game.IngameState.IngameUi.SellPanell.MyOffertElement.Address)
												{
													return StashType.SellStash;
												}
												if (base.Game.IngameState.IngameUi.SellPanellNew.IsVisible && base.Address == base.Game.IngameState.IngameUi.SellPanellNew.MyOffertElement.Address)
												{
													return StashType.SellStash;
												}
												if (base.Game.IngameState.IngameUi.SellPanell.IsVisible && base.Address == base.Game.IngameState.IngameUi.SellPanell.OtherOffertElement.Address)
												{
													return StashType.SellStash;
												}
												if (base.Game.IngameState.IngameUi.SellPanellNew.IsVisible && base.Address == base.Game.IngameState.IngameUi.SellPanellNew.OtherOffertElement.Address)
												{
													return StashType.SellStash;
												}
												if (base.Game.IngameState.IngameUi.TradeUi.IsVisible && base.Address == base.Game.IngameState.IngameUi.TradeUi.MyOffertElement.Address)
												{
													return StashType.TradeStash;
												}
												if (base.Game.IngameState.IngameUi.TradeUi.IsVisible && base.Address == base.Game.IngameState.IngameUi.TradeUi.OtherOffertElement.Address)
												{
													return StashType.TradeStash;
												}
												if ((base.Game.IngameState.IngameUi.PurchasePanell.IsVisible && base.Game.IngameState.IngameUi.PurchasePanell.StashInventoryPanel.Children.Any((Element x) => x.Children[0].Address == base.Address)) || (base.Game.IngameState.IngameUi.ExpeditionDealerPanell.IsVisible && base.Game.IngameState.IngameUi.ExpeditionDealerPanell.StashInventoryPanel.Children.Any((Element x) => x.Children[0].Address == base.Address)))
												{
													return StashType.ParchaseStash;
												}
												if (base.Game.IngameState.IngameUi.RewardPannel.IsVisible && base.Game.IngameState.IngameUi.RewardPannel.Children[(int)base.Game.IngameState.IngameUi.RewardPannel.ChildCount - 2].Children[0].Children.Any((Element x) => x.Children.Any((Element y) => y.Children[0].Address == base.Address)))
												{
													return StashType.SellStash;
												}
												if (base.Game.IngameState.IngameUi.MapDevicePannel.IsVisible && base.Game.IngameState.IngameUi.MapDevicePannel.Children[7].Address == base.Address)
												{
													return StashType.MapDevice;
												}
												if (base.Game.IngameState.IngameUi.MasterDevicePannel.IsVisible && base.Game.IngameState.IngameUi.MasterDevicePannel.Children[5].Children[7].Address == base.Address)
												{
													return StashType.MapDevice;
												}
												if (base.Game.IngameState.IngameUi.CardTrade.IsVisible && base.Game.IngameState.IngameUi.CardTrade.Children[5].Address == base.Address)
												{
													return StashType.CardTrade;
												}
												if (base.Game.IngameState.IngameUi.RitualFavorUi.IsVisible && base.Game.IngameState.IngameUi.RitualFavorUi.InventoryElement.Address == base.Address)
												{
													return StashType.RitualFavor;
												}
												if (base.Game.IngameState.IngameUi.AnointingUi.IsVisible && base.Game.IngameState.IngameUi.AnointingUi.MainControlElement.ChildCount > 3L && base.Game.IngameState.IngameUi.AnointingUi.MainControlElement?.Children[3]?.Address == base.Address)
												{
													return StashType.AnointMain;
												}
												if (base.Game.IngameState.IngameUi.CraftingBenchUi.IsVisible && base.Game.IngameState.IngameUi.CraftingBenchUi.ItemSlotInventory?.Address == base.Address)
												{
													return StashType.CraftingBenchMain;
												}
												if (base.Game.IngameState.IngameUi.UnveilingUi.IsVisible && base.Game.IngameState.IngameUi.UnveilingUi.Children[3]?.Children[2]?.Address == base.Address)
												{
													return StashType.UnveilMainInventory;
												}
												if (base.Game.IngameState.IngameUi.AnointingUi.IsVisible)
												{
													if (base.Game.IngameState.IngameUi.AnointingUi.MainControlElement.Children[2].Children[0].ChildCount > 0L && base.Game.IngameState.IngameUi.AnointingUi.MainControlElement?.Children[2]?.Children[0]?.Children[0]?.Address == base.Address)
													{
														return StashType.AnointOil;
													}
													if (base.Game.IngameState.IngameUi.AnointingUi.MainControlElement.Children[2].Children[1].ChildCount > 0L && base.Game.IngameState.IngameUi.AnointingUi.MainControlElement?.Children[2]?.Children[1]?.Children[0]?.Address == base.Address)
													{
														return StashType.AnointOil;
													}
													if (base.Game.IngameState.IngameUi.AnointingUi.MainControlElement.Children[2].Children[2].ChildCount > 0L && base.Game.IngameState.IngameUi.AnointingUi.MainControlElement?.Children[2]?.Children[2]?.Children[0]?.Address == base.Address)
													{
														return StashType.AnointOil;
													}
												}
												Element parent = AsObject<Element>().Parent;
												switch (parent.ChildCount)
												{
												case 1L:
													if (TotalBoxesInInventoryRow != 24L)
													{
														return StashType.NormalStash;
													}
													return StashType.QuadStash;
												case 7L:
													if (parent.Children[0].ChildCount == 9L)
													{
														return StashType.MapStash;
													}
													return StashType.DivinationStash;
												case 111L:
													return StashType.EssenceStash;
												default:
												{
													MapsTabElement mapsTabElement = base.Game.IngameState.IngameUi.StashPannel.MapsTabElement;
													if (mapsTabElement != null && mapsTabElement.ChildCount >= 3L)
													{
														Element element = mapsTabElement.Children[3]?.Children?.FirstOrDefault((Element x) => x.IsVisible);
														if (element != null && element.Address == base.Address)
														{
															return StashType.MapStash;
														}
													}
													return StashType.InvalidInventory;
												}
												case 28L:
													return StashType.FragmentStash;
												case 18L:
													return StashType.CurrencyStash;
												}
											}
											return StashType.BeastCraft;
										}
										return StashType.SentinelDrone;
									}
									return StashType.PlayerSecondaryOffHand;
								}
								return StashType.PlayerRightRing;
							}
							return StashType.PlayerPrimaryMainHand;
						}
						return StashType.PlayerFlasks;
					}
					return StashType.PlayerBoots;
				}
				return StashType.PlayerBelt;
			}
			return StashType.PlayerNeck;
		}
		return StashType.PlayerHead;
	}

	private Element GetInventoryElement()
	{
		StashType invType = InvType;
		uint num = default(uint);
		while (true)
		{
			switch (invType)
			{
			default:
			{
				int num2 = ((int)num * -261031057) ^ -1148699007;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x60D9CADCu) % 11u)
					{
					case 2u:
						num2 = ((int)num * -1257638588) ^ 0x1A7150EF;
						continue;
					case 1u:
					case 9u:
						break;
					case 7u:
						goto IL_0107;
					case 4u:
						goto IL_011a;
					case 10u:
						goto IL_014e;
					case 3u:
						goto IL_0161;
					case 6u:
						goto IL_016d;
					case 5u:
						goto IL_0180;
					default:
						goto IL_0187;
					case 8u:
						goto end_IL_0069;
					}
					break;
				}
				continue;
			}
			case StashType.QuadStash:
				goto IL_0107;
			case StashType.DivinationStash:
				goto IL_011a;
			case StashType.MapStash:
				goto IL_014e;
			case StashType.CurrencyStash:
			case StashType.EssenceStash:
			case StashType.FragmentStash:
				goto IL_0161;
			case StashType.NormalStash:
			case StashType.PlayerFlasks:
				goto IL_016d;
			case StashType.PlayerInventory:
			case StashType.SellStash:
			case StashType.MapDevice:
			case StashType.ParchaseStash:
			case StashType.TradeStash:
			case StashType.AnointOil:
			case StashType.RitualFavor:
				goto IL_0180;
			case StashType.ExplorationLocker:
			case StashType.SentinelLocker:
			case StashType.FragmentEldrich:
			case StashType.FragmentMaven:
				goto IL_0187;
			case StashType.PlayerHead:
			case StashType.PlayerNeck:
			case StashType.PlayerChest:
			case StashType.PlayerPrimaryOffHand:
			case StashType.PlayerPrimaryMainHand:
			case StashType.PlayerSecondaryOffHand:
			case StashType.PlayerSecondaryMainHand:
			case StashType.PlayerLeftRing:
			case StashType.PlayerRightRing:
			case StashType.PlayerGloves:
			case StashType.PlayerBelt:
			case StashType.PlayerBoots:
			case StashType.CardTrade:
			case StashType.BeastCraft:
			case StashType.AnointMain:
			case StashType.UnveilMainInventory:
			case StashType.SentinelDrone:
			case StashType.CraftingBenchMain:
				break;
				IL_0107:
				return new InventorySlotUiElement(base.Address, StashType.QuadStash);
				IL_0187:
				return null;
				IL_0180:
				return AsObject<InventorySlotUiElement>();
				IL_016d:
				return new InventorySlotUiElement(base.Address, StashType.NormalStash);
				IL_0161:
				return AsObject<Element>().Parent;
				IL_014e:
				return new InventorySlotUiElement(base.Address, StashType.MapStash);
				IL_011a:
				return GetObject<Element>(base.M.ReadLong(base.Address + 32L, 8L));
				end_IL_0069:
				break;
			}
			break;
		}
		return AsObject<SingleSlotUiElement>();
	}
}
