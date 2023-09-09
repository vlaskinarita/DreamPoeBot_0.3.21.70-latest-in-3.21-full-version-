using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class LocalPlayer : Player
{
	[Serializable]
	private sealed class Class291
	{
		public static readonly Class291 Class9 = new Class291();

		internal bool method_0(DatPassiveSkillWrapper datPassiveSkillWrapper_0)
		{
			return datPassiveSkillWrapper_0.Name == "Whispers of Doom";
		}

		internal bool method_1(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[0];
		}

		internal bool method_2(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[1];
		}

		internal bool method_3(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[2];
		}

		internal bool method_4(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[3];
		}

		internal bool method_5(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[4];
		}

		internal bool method_6(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[5];
		}

		internal bool method_7(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[6];
		}

		internal bool method_8(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[7];
		}

		internal bool method_9(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[8];
		}

		internal bool method_10(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[9];
		}

		internal bool method_11(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[10];
		}

		internal bool method_12(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[11];
		}

		internal bool method_13(Skill skill_0)
		{
			return skill_0.Id == LokiPoe.InstanceInfo.SkillBarIds[12];
		}
	}

	private sealed class Class293
	{
		public string string_0;

		internal bool method_0(Skill skill_0)
		{
			if (skill_0 != null)
			{
				return skill_0.Name == string_0;
			}
			return false;
		}
	}

	private static readonly ILog ilog_2 = Logger.GetLoggerInstanceForType();

	private PerFrameCachedValue<int> perFrameCachedValue_9;

	public int BestiaryNetVariation
	{
		get
		{
			if (perFrameCachedValue_9 == null)
			{
				perFrameCachedValue_9 = new PerFrameCachedValue<int>(method_15);
			}
			return perFrameCachedValue_9;
		}
	}

	public Portal TownPortal => LokiPoe.ObjectManager.TownPortal(Name);

	public PartyStatus PartyStatus => LokiPoe.InstanceInfo.PartyStatus;

	public string League => LokiPoe.InstanceInfo.League;

	public List<ushort> SkillBarIds => LokiPoe.InstanceInfo.SkillBarIds;

	public List<Skill> SkillBarSkills => LokiPoe.InstanceInfo.SkillBarSkills;

	public bool IsInHideout => LokiPoe.CurrentWorldArea.IsHideoutArea;

	public bool IsInTown => LokiPoe.CurrentWorldArea.IsTown;

	public bool IsInOverworld => LokiPoe.CurrentWorldArea.IsOverworldArea;

	public bool IsInCorruptedArea => LokiPoe.CurrentWorldArea.IsCorruptedArea;

	public bool IsInMapRoom => LokiPoe.CurrentWorldArea.IsMapRoom;

	private static IEnumerable<Inventory> IEnumerable_0 => new Inventory[12]
	{
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffLeftHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.OffRightHand),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Head),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Chest),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Gloves),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Boots),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Belt),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.LeftRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.RightRing),
		LokiPoe.InstanceInfo.GetPlayerInventoryBySlot(InventorySlot.Neck)
	};

	public IEnumerable<Item> EquippedItems
	{
		get
		{
			new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				if (item2 != null)
				{
					Item item = item2.Items.FirstOrDefault();
					if (item != null)
					{
						yield return item;
					}
				}
			}
		}
	}

	public int NumberOfDeployedBrand
	{
		get
		{
			int num = 0;
			DreamPoeBot.Loki.Components.Actor component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Actor>();
			foreach (Skill item in component.AvailableSkills.Where((Skill x) => x.InternalId.Contains("_brand")))
			{
				num += item.SkillActiveToken;
			}
			return num;
		}
	}

	public int TotalCursesAllowed
	{
		get
		{
			int num = 1;
			foreach (Item equippedItem in EquippedItems)
			{
				if (equippedItem.Stats.TryGetValue(StatTypeGGG.NumberOfAdditionalCursesAllowed, out var value))
				{
					num += value;
				}
			}
			if (LokiPoe.ObjectManager.Me.Passives.Any(Class291.Class9.method_0))
			{
				num++;
			}
			return num;
		}
	}

	public IEnumerable<DatPassiveSkillWrapper> Passives
	{
		get
		{
			Dat.BuildPassinveLookupTable();
			foreach (ushort passiveSkillId in LokiPoe.InstanceInfo.PassiveSkillIds)
			{
				if (!Dat.dictionary_IdToPassiveSkillWrapper.TryGetValue(passiveSkillId, out var value))
				{
					ilog_2.ErrorFormat("[Passives] A passive with id {0} was not found.", (object)passiveSkillId);
				}
				else
				{
					yield return value;
				}
			}
		}
	}

	public List<DatPassiveSkillWrapper> AtlasPassiveSkills => LokiPoe.InstanceInfo.AtlasPassiveSkills;

	public int AtlasPassivePointsAvailable => LokiPoe.InstanceInfo.AtlasPassivePointsAvailable;

	public List<DatPassiveSkillWrapper> PassiveSkills => LokiPoe.InstanceInfo.PassiveSkills;

	public int PassiveSkillPointsAvailable => LokiPoe.InstanceInfo.PassiveSkillPointsAvailable;

	public int AscendencySkillPointsAvailable => LokiPoe.InstanceInfo.AscendencySkillPointsAvailable;

	public List<Item> EquippedSkillGems
	{
		get
		{
			List<Item> list = new List<Item>();
			foreach (Inventory item2 in IEnumerable_0)
			{
				foreach (Item item3 in item2.Items)
				{
					if (item3 == null || item3.Components.SocketsComponent == null)
					{
						continue;
					}
					for (int i = 0; i < item3.SocketedGems.Length; i++)
					{
						Item item = item3.SocketedGems[i];
						if (!(item == null))
						{
							list.Add(item);
						}
					}
				}
			}
			return list;
		}
	}

	internal LocalPlayer(EntityWrapper entry)
		: base(entry)
	{
	}

	public Keys GetKeyForSkill(Skill skill)
	{
		ushort id = skill.Id;
		uint num2 = default(uint);
		while (true)
		{
			List<ushort> skillBarIds = SkillBarIds;
			while (true)
			{
				int num = 0;
				while (true)
				{
					if (num < skillBarIds.Count)
					{
						while (true)
						{
							if (skillBarIds[num] == id)
							{
								while (true)
								{
									switch (num)
									{
									case 0:
										goto IL_00fb;
									case 1:
										goto IL_0101;
									case 2:
										goto IL_0107;
									case 3:
										goto IL_010d;
									case 4:
										goto IL_0113;
									case 5:
										goto IL_0119;
									case 6:
										goto IL_011f;
									case 7:
										goto IL_0125;
									case 8:
										goto IL_012b;
									case 9:
										goto IL_0131;
									case 10:
										goto IL_0137;
									case 11:
										goto IL_013d;
									case 12:
										goto IL_0143;
									}
									int num3 = ((int)num2 * -832756516) ^ 0x38BDE2BF;
									while (true)
									{
										switch ((num2 = (uint)num3 ^ 0x2F614F9u) % 22u)
										{
										case 20u:
											num3 = (int)(num2 * 294746435) ^ -1053675700;
											continue;
										case 21u:
											break;
										case 4u:
											goto end_IL_0092;
										case 13u:
											goto IL_00dd;
										case 17u:
											goto end_IL_00d1;
										case 5u:
											goto end_IL_00e1;
										case 10u:
										case 18u:
											goto end_IL_00ec;
										default:
											goto IL_00f9;
										case 11u:
											goto IL_00fb;
										case 12u:
											goto IL_0101;
										case 3u:
											goto IL_0107;
										case 16u:
											goto IL_010d;
										case 8u:
											goto IL_0113;
										case 19u:
											goto IL_0119;
										case 7u:
											goto IL_011f;
										case 9u:
											goto IL_0125;
										case 2u:
											goto IL_012b;
										case 14u:
											goto IL_0131;
										case 6u:
											goto IL_0137;
										case 1u:
											goto IL_013d;
										case 15u:
											goto IL_0143;
										}
										break;
									}
									continue;
									IL_0101:
									return LokiPoe.Input.Binding.use_bound_skill2;
									IL_00fb:
									return LokiPoe.Input.Binding.use_bound_skill1;
									IL_0143:
									return LokiPoe.Input.Binding.use_bound_skill13;
									IL_013d:
									return LokiPoe.Input.Binding.use_bound_skill12;
									IL_0137:
									return LokiPoe.Input.Binding.use_bound_skill11;
									IL_0131:
									return LokiPoe.Input.Binding.use_bound_skill10;
									IL_012b:
									return LokiPoe.Input.Binding.use_bound_skill9;
									IL_0125:
									return LokiPoe.Input.Binding.use_bound_skill8;
									IL_011f:
									return LokiPoe.Input.Binding.use_bound_skill7;
									IL_0119:
									return LokiPoe.Input.Binding.use_bound_skill6;
									IL_0113:
									return LokiPoe.Input.Binding.use_bound_skill5;
									IL_010d:
									return LokiPoe.Input.Binding.use_bound_skill4;
									IL_0107:
									return LokiPoe.Input.Binding.use_bound_skill3;
									continue;
									end_IL_0092:
									break;
								}
								continue;
							}
							goto IL_00dd;
							IL_00dd:
							num++;
							break;
							continue;
							end_IL_00d1:
							break;
						}
						continue;
					}
					goto IL_00f9;
					IL_00f9:
					return Keys.None;
					continue;
					end_IL_00e1:
					break;
				}
				continue;
				end_IL_00ec:
				break;
			}
		}
	}

	public LokiPoe.Input.KeysCombo GetKeyComboForSkill(Skill skill)
	{
		ushort id = skill.Id;
		List<ushort> skillBarIds = SkillBarIds;
		uint num2 = default(uint);
		while (true)
		{
			int num = 0;
			while (true)
			{
				if (num < skillBarIds.Count)
				{
					while (true)
					{
						if (skillBarIds[num] == id)
						{
							while (true)
							{
								switch (num)
								{
								case 0:
									goto IL_00ff;
								case 1:
									goto IL_0105;
								case 2:
									goto IL_010b;
								case 3:
									goto IL_0111;
								case 4:
									goto IL_0117;
								case 5:
									goto IL_011d;
								case 6:
									goto IL_0123;
								case 7:
									goto IL_0129;
								case 8:
									goto IL_012f;
								case 9:
									goto IL_0135;
								case 10:
									goto IL_013b;
								case 11:
									goto IL_0141;
								case 12:
									goto IL_0147;
								}
								int num3 = ((int)num2 * -199799328) ^ -1145343872;
								while (true)
								{
									switch ((num2 = (uint)num3 ^ 0x4492E910u) % 22u)
									{
									case 8u:
										num3 = (int)(num2 * 1855199937) ^ -1544822660;
										continue;
									case 3u:
										break;
									case 9u:
										goto end_IL_0099;
									case 12u:
										goto IL_00e4;
									case 6u:
									case 20u:
										goto end_IL_00d8;
									case 0u:
									case 1u:
										goto end_IL_00e8;
									default:
										goto IL_00f7;
									case 14u:
										goto IL_00ff;
									case 2u:
										goto IL_0105;
									case 15u:
										goto IL_010b;
									case 17u:
										goto IL_0111;
									case 5u:
										goto IL_0117;
									case 11u:
										goto IL_011d;
									case 19u:
										goto IL_0123;
									case 16u:
										goto IL_0129;
									case 7u:
										goto IL_012f;
									case 18u:
										goto IL_0135;
									case 21u:
										goto IL_013b;
									case 10u:
										goto IL_0141;
									case 13u:
										goto IL_0147;
									}
									break;
								}
								continue;
								IL_0105:
								return LokiPoe.Input.Binding.use_bound_skill2_combo;
								IL_00ff:
								return LokiPoe.Input.Binding.use_bound_skill1_combo;
								IL_0147:
								return LokiPoe.Input.Binding.use_bound_skill13_combo;
								IL_0141:
								return LokiPoe.Input.Binding.use_bound_skill12_combo;
								IL_013b:
								return LokiPoe.Input.Binding.use_bound_skill11_combo;
								IL_0135:
								return LokiPoe.Input.Binding.use_bound_skill10_combo;
								IL_012f:
								return LokiPoe.Input.Binding.use_bound_skill9_combo;
								IL_0129:
								return LokiPoe.Input.Binding.use_bound_skill8_combo;
								IL_0123:
								return LokiPoe.Input.Binding.use_bound_skill7_combo;
								IL_011d:
								return LokiPoe.Input.Binding.use_bound_skill6_combo;
								IL_0117:
								return LokiPoe.Input.Binding.use_bound_skill5_combo;
								IL_0111:
								return LokiPoe.Input.Binding.use_bound_skill4_combo;
								IL_010b:
								return LokiPoe.Input.Binding.use_bound_skill3_combo;
								continue;
								end_IL_0099:
								break;
							}
							continue;
						}
						goto IL_00e4;
						IL_00e4:
						num++;
						break;
						continue;
						end_IL_00d8:
						break;
					}
					continue;
				}
				goto IL_00f7;
				IL_00f7:
				return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				continue;
				end_IL_00e8:
				break;
			}
		}
	}

	public IEnumerable<Keys> GetKeysForSkill(Skill skill)
	{
		uint num = default(uint);
		int num3 = default(int);
		while (true)
		{
			bool flag = false;
			while (true)
			{
				IL_0208:
				ushort id = skill.Id;
				List<ushort> skillBarIds = SkillBarIds;
				int i = 0;
				while (true)
				{
					IL_022c:
					if (i < skillBarIds.Count)
					{
						while (true)
						{
							if (skillBarIds[i] == id)
							{
								while (true)
								{
									flag = true;
									while (true)
									{
										switch (i)
										{
										case 0:
											goto IL_02cd;
										case 1:
											goto IL_02e1;
										case 2:
											goto IL_02f5;
										case 3:
											goto IL_0309;
										case 4:
											goto IL_031d;
										case 5:
											goto IL_0331;
										case 6:
											goto IL_0345;
										case 7:
											goto IL_0359;
										case 8:
											goto IL_036d;
										case 9:
											goto IL_0382;
										case 10:
											goto IL_0397;
										case 11:
											goto IL_03ac;
										case 12:
											goto IL_03c1;
										}
										int num2 = ((int)num * -2097177885) ^ -139686819;
										while (true)
										{
											switch ((num = (uint)num2 ^ 0xD4E9D0E5u) % 65u)
											{
											case 56u:
												num2 = (int)(num * 372034650) ^ -2087152613;
												continue;
											default:
												yield break;
											case 48u:
												break;
											case 10u:
												goto end_IL_018d;
											case 45u:
												goto end_IL_01d3;
											case 36u:
											case 38u:
												goto end_IL_01dc;
											case 47u:
												goto IL_0208;
											case 14u:
												goto IL_022c;
											case 35u:
												goto IL_0244;
											case 3u:
											case 6u:
											case 7u:
											case 8u:
											case 9u:
											case 11u:
											case 12u:
											case 18u:
											case 21u:
											case 24u:
											case 33u:
											case 43u:
											case 44u:
											case 46u:
											case 49u:
											case 54u:
											case 55u:
											case 59u:
											case 60u:
											case 62u:
												goto IL_02b9;
											case 28u:
											case 50u:
												yield break;
											case 41u:
												goto IL_02cd;
											case 52u:
												try
												{
													/*Error near IL_02e0: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=1.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 29u:
												goto IL_02e1;
											case 0u:
												goto IL_02f5;
											case 20u:
												try
												{
													goto IL_0307;
													IL_0307:
													/*Error near IL_0308: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=3.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 17u:
												goto IL_0307;
											case 37u:
												goto IL_0309;
											case 30u:
												try
												{
													/*Error near IL_031c: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=4.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 63u:
												goto IL_031d;
											case 13u:
												try
												{
													/*Error near IL_0330: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 42u:
												goto IL_0331;
											case 1u:
												/*Error near IL_0344: Unexpected return in MoveNext()*/;
											case 5u:
												goto IL_0345;
											case 58u:
												try
												{
													goto IL_0357;
													IL_0357:
													/*Error near IL_0358: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=7.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 15u:
												goto IL_0357;
											case 64u:
												goto IL_0359;
											case 57u:
												/*Error near IL_036c: Unexpected return in MoveNext()*/;
											case 53u:
												goto IL_036d;
											case 25u:
												try
												{
													goto IL_0380;
													IL_0380:
													/*Error near IL_0381: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 22u:
												goto IL_0380;
											case 61u:
												goto IL_0382;
											case 4u:
												try
												{
													goto IL_0395;
													IL_0395:
													/*Error near IL_0396: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=10.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 27u:
												goto IL_0395;
											case 2u:
												goto IL_0397;
											case 34u:
												try
												{
													/*Error near IL_03ab: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=11.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 16u:
												goto IL_03ac;
											case 32u:
												try
												{
													goto IL_03bf;
													IL_03bf:
													/*Error near IL_03c0: Unexpected return in MoveNext()*/;
												}
												finally
												{
													/*Error: Could not find finallyMethod for state=12.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
												}
											case 51u:
												goto IL_03bf;
											case 40u:
												goto IL_03c1;
											case 31u:
												/*Error near IL_03d5: Unexpected return in MoveNext()*/;
											case 19u:
												goto IL_03d6;
											case 23u:
												goto IL_03de;
											case 26u:
												yield break;
											}
											break;
										}
										continue;
										IL_02e1:
										yield return LokiPoe.Input.Binding.use_bound_skill2;
										goto IL_02b9;
										IL_02cd:
										yield return LokiPoe.Input.Binding.use_bound_skill1;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_03c1:
										yield return LokiPoe.Input.Binding.use_bound_skill13;
										goto IL_02b9;
										IL_03ac:
										yield return LokiPoe.Input.Binding.use_bound_skill12;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_0397:
										yield return LokiPoe.Input.Binding.use_bound_skill11;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_0382:
										yield return LokiPoe.Input.Binding.use_bound_skill10;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_036d:
										yield return LokiPoe.Input.Binding.use_bound_skill9;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_0359:
										yield return LokiPoe.Input.Binding.use_bound_skill8;
										goto IL_02b9;
										IL_0345:
										yield return LokiPoe.Input.Binding.use_bound_skill7;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_0331:
										yield return LokiPoe.Input.Binding.use_bound_skill6;
										goto IL_02b9;
										IL_031d:
										yield return LokiPoe.Input.Binding.use_bound_skill5;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_0309:
										yield return LokiPoe.Input.Binding.use_bound_skill4;
										/*Error: Unable to find new state assignment for yield return*/;
										IL_02f5:
										yield return LokiPoe.Input.Binding.use_bound_skill3;
										/*Error: Unable to find new state assignment for yield return*/;
										continue;
										end_IL_018d:
										break;
									}
									continue;
									end_IL_01d3:
									break;
								}
								continue;
							}
							goto IL_02b9;
							IL_0244:
							i = num3 + 1;
							goto IL_022c;
							IL_02b9:
							num3 = i;
							goto IL_0244;
							continue;
							end_IL_01dc:
							break;
						}
						break;
					}
					goto IL_03d6;
					IL_03de:
					yield return Keys.None;
					yield break;
					IL_03d6:
					if (flag)
					{
						yield break;
					}
					goto IL_03de;
				}
				break;
			}
		}
	}

	public IEnumerable<LokiPoe.Input.KeysCombo> GetKeysComboForSkill(Skill skill)
	{
		uint num = default(uint);
		int num3 = default(int);
		while (true)
		{
			bool flag = false;
			ushort id = skill.Id;
			List<ushort> skillBarIds = SkillBarIds;
			int i = 0;
			while (true)
			{
				IL_0244:
				if (i < skillBarIds.Count)
				{
					while (true)
					{
						if (skillBarIds[i] == id)
						{
							while (true)
							{
								flag = true;
								while (true)
								{
									switch (i)
									{
									case 0:
										goto IL_0307;
									case 1:
										goto IL_031b;
									case 2:
										goto IL_032f;
									case 3:
										goto IL_0343;
									case 4:
										goto IL_0357;
									case 5:
										goto IL_036b;
									case 6:
										goto IL_037f;
									case 7:
										goto IL_0393;
									case 8:
										goto IL_03a7;
									case 9:
										goto IL_03bc;
									case 10:
										goto IL_03d1;
									case 11:
										goto IL_03e6;
									case 12:
										goto IL_03fb;
									}
									int num2 = ((int)num * -1667342226) ^ 0x7E9F0E9D;
									while (true)
									{
										switch ((num = (uint)num2 ^ 0x72F931E9u) % 71u)
										{
										case 36u:
											num2 = (int)(num * 1438911243) ^ -1873219365;
											continue;
										default:
											yield break;
										case 59u:
											break;
										case 62u:
											goto end_IL_01a5;
										case 47u:
											goto end_IL_01eb;
										case 23u:
										case 29u:
											goto end_IL_01f4;
										case 34u:
										case 50u:
											goto IL_0244;
										case 4u:
											goto IL_025c;
										case 1u:
										case 3u:
										case 5u:
										case 6u:
										case 7u:
										case 8u:
										case 14u:
										case 17u:
										case 18u:
										case 19u:
										case 27u:
										case 28u:
										case 33u:
										case 38u:
										case 39u:
										case 41u:
										case 51u:
										case 53u:
										case 56u:
										case 57u:
										case 64u:
										case 70u:
											goto IL_02d1;
										case 32u:
										case 63u:
											yield break;
										case 66u:
											goto IL_02e5;
										case 24u:
											goto IL_02f0;
										case 20u:
											/*Error near IL_0306: Unexpected return in MoveNext()*/;
										case 43u:
											goto IL_0307;
										case 12u:
											/*Error near IL_031a: Unexpected return in MoveNext()*/;
										case 52u:
											goto IL_031b;
										case 49u:
											try
											{
												goto IL_032d;
												IL_032d:
												/*Error near IL_032e: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=2.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 31u:
											goto IL_032d;
										case 46u:
											goto IL_032f;
										case 65u:
											try
											{
												/*Error near IL_0342: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=3.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 45u:
											goto IL_0343;
										case 13u:
											/*Error near IL_0356: Unexpected return in MoveNext()*/;
										case 42u:
											goto IL_0357;
										case 35u:
											try
											{
												/*Error near IL_036a: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=5.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 48u:
											goto IL_036b;
										case 54u:
											try
											{
												goto IL_037d;
												IL_037d:
												/*Error near IL_037e: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=6.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 58u:
											goto IL_037d;
										case 10u:
											goto IL_037f;
										case 2u:
											/*Error near IL_0392: Unexpected return in MoveNext()*/;
										case 0u:
											goto IL_0393;
										case 68u:
											try
											{
												/*Error near IL_03a6: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=8.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 9u:
											goto IL_03a7;
										case 30u:
											try
											{
												goto IL_03ba;
												IL_03ba:
												/*Error near IL_03bb: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=9.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 69u:
											goto IL_03ba;
										case 55u:
											goto IL_03bc;
										case 26u:
											try
											{
												goto IL_03cf;
												IL_03cf:
												/*Error near IL_03d0: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=10.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 22u:
											goto IL_03cf;
										case 16u:
											goto IL_03d1;
										case 67u:
											try
											{
												goto IL_03e4;
												IL_03e4:
												/*Error near IL_03e5: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=11.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 61u:
											goto IL_03e4;
										case 60u:
											goto IL_03e6;
										case 40u:
											try
											{
												goto IL_03f9;
												IL_03f9:
												/*Error near IL_03fa: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=12.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 25u:
											goto IL_03f9;
										case 44u:
											goto IL_03fb;
										case 37u:
											try
											{
												goto IL_040e;
												IL_040e:
												/*Error near IL_040f: Unexpected return in MoveNext()*/;
											}
											finally
											{
												/*Error: Could not find finallyMethod for state=13.
Possibly this method is affected by a C# compiler bug that causes the finally body
not to run in case of an exception or early 'break;' out of a loop consuming this iterable.*/;
											}
										case 11u:
											goto IL_040e;
										case 21u:
											yield break;
										}
										break;
									}
									continue;
									IL_031b:
									yield return LokiPoe.Input.Binding.use_bound_skill2_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_0307:
									yield return LokiPoe.Input.Binding.use_bound_skill1_combo;
									goto IL_02d1;
									IL_03fb:
									yield return LokiPoe.Input.Binding.use_bound_skill13_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_03e6:
									yield return LokiPoe.Input.Binding.use_bound_skill12_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_03d1:
									yield return LokiPoe.Input.Binding.use_bound_skill11_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_03bc:
									yield return LokiPoe.Input.Binding.use_bound_skill10_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_03a7:
									yield return LokiPoe.Input.Binding.use_bound_skill9_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_0393:
									yield return LokiPoe.Input.Binding.use_bound_skill8_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_037f:
									yield return LokiPoe.Input.Binding.use_bound_skill7_combo;
									goto IL_02d1;
									IL_036b:
									yield return LokiPoe.Input.Binding.use_bound_skill6_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_0357:
									yield return LokiPoe.Input.Binding.use_bound_skill5_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									IL_0343:
									yield return LokiPoe.Input.Binding.use_bound_skill4_combo;
									goto IL_02d1;
									IL_032f:
									yield return LokiPoe.Input.Binding.use_bound_skill3_combo;
									/*Error: Unable to find new state assignment for yield return*/;
									continue;
									end_IL_01a5:
									break;
								}
								continue;
								end_IL_01eb:
								break;
							}
							continue;
						}
						goto IL_02d1;
						IL_025c:
						i = num3 + 1;
						goto IL_0244;
						IL_02d1:
						num3 = i;
						goto IL_025c;
						continue;
						end_IL_01f4:
						break;
					}
					break;
				}
				goto IL_02e5;
				IL_02f0:
				yield return new LokiPoe.Input.KeysCombo(Keys.None, Keys.None);
				yield break;
				IL_02e5:
				if (flag)
				{
					yield break;
				}
				goto IL_02f0;
			}
		}
	}

	public Skill FromActionKey(ActionKeys key)
	{
		return key switch
		{
			ActionKeys.use_bound_skill1 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_1), 
			ActionKeys.use_bound_skill2 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_2), 
			ActionKeys.use_bound_skill3 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_3), 
			ActionKeys.use_bound_skill4 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_4), 
			ActionKeys.use_bound_skill5 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_5), 
			ActionKeys.use_bound_skill6 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_6), 
			ActionKeys.use_bound_skill7 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_7), 
			ActionKeys.use_bound_skill8 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_8), 
			ActionKeys.use_bound_skill9 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_9), 
			ActionKeys.use_bound_skill10 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_10), 
			ActionKeys.use_bound_skill11 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_11), 
			ActionKeys.use_bound_skill12 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_12), 
			ActionKeys.use_bound_skill13 => base.AvailableSkills.FirstOrDefault(Class291.Class9.method_13), 
			_ => null, 
		};
	}

	public Skill FromKey(Keys key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1 == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2 != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill3 == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill3);
			}
			if (LokiPoe.Input.Binding.use_bound_skill4 == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill4);
			}
			if (LokiPoe.Input.Binding.use_bound_skill5 != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill6 == key)
				{
					return FromActionKey(ActionKeys.use_bound_skill6);
				}
				if (LokiPoe.Input.Binding.use_bound_skill7 == key)
				{
					return FromActionKey(ActionKeys.use_bound_skill7);
				}
				if (LokiPoe.Input.Binding.use_bound_skill8 != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill9 == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill9);
					}
					if (LokiPoe.Input.Binding.use_bound_skill10 == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill10);
					}
					if (LokiPoe.Input.Binding.use_bound_skill11 == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill11);
					}
					if (LokiPoe.Input.Binding.use_bound_skill12 == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill12);
					}
					if (LokiPoe.Input.Binding.use_bound_skill13 == key)
					{
						return FromActionKey(ActionKeys.use_bound_skill13);
					}
					return null;
				}
				return FromActionKey(ActionKeys.use_bound_skill8);
			}
			return FromActionKey(ActionKeys.use_bound_skill5);
		}
		return FromActionKey(ActionKeys.use_bound_skill2);
	}

	public Skill FromKeyCombo(LokiPoe.Input.KeysCombo key)
	{
		if (LokiPoe.Input.Binding.use_bound_skill1_combo == key)
		{
			return FromActionKey(ActionKeys.use_bound_skill1);
		}
		if (LokiPoe.Input.Binding.use_bound_skill2_combo != key)
		{
			if (LokiPoe.Input.Binding.use_bound_skill3_combo == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill3);
			}
			if (LokiPoe.Input.Binding.use_bound_skill4_combo == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill4);
			}
			if (LokiPoe.Input.Binding.use_bound_skill5_combo == key)
			{
				return FromActionKey(ActionKeys.use_bound_skill5);
			}
			if (LokiPoe.Input.Binding.use_bound_skill6_combo != key)
			{
				if (LokiPoe.Input.Binding.use_bound_skill7_combo == key)
				{
					return FromActionKey(ActionKeys.use_bound_skill7);
				}
				if (LokiPoe.Input.Binding.use_bound_skill8_combo == key)
				{
					return FromActionKey(ActionKeys.use_bound_skill8);
				}
				if (LokiPoe.Input.Binding.use_bound_skill9_combo != key)
				{
					if (LokiPoe.Input.Binding.use_bound_skill10_combo != key)
					{
						if (LokiPoe.Input.Binding.use_bound_skill11_combo != key)
						{
							if (LokiPoe.Input.Binding.use_bound_skill12_combo != key)
							{
								if (LokiPoe.Input.Binding.use_bound_skill13_combo != key)
								{
									return null;
								}
								return FromActionKey(ActionKeys.use_bound_skill13);
							}
							return FromActionKey(ActionKeys.use_bound_skill12);
						}
						return FromActionKey(ActionKeys.use_bound_skill11);
					}
					return FromActionKey(ActionKeys.use_bound_skill10);
				}
				return FromActionKey(ActionKeys.use_bound_skill9);
			}
			return FromActionKey(ActionKeys.use_bound_skill6);
		}
		return FromActionKey(ActionKeys.use_bound_skill2);
	}

	public bool HasSkillOnBarByName(string name)
	{
		Class293 @class = new Class293();
		@class.string_0 = name;
		return LokiPoe.InstanceInfo.SkillBarSkills.Any(@class.method_0);
	}

	public bool HasAtlasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasAtlasPassive(value);
	}

	public bool HasPassive(string value)
	{
		return LokiPoe.InstanceInfo.HasPassive(value);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[LocalPlayer]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tClass: {base.Class}");
		stringBuilder.AppendLine($"\tLevel: {base.Level}");
		stringBuilder.AppendLine($"\tExperience: {base.Experience}");
		stringBuilder.AppendLine($"\tPantheonMajor: {base.PantheonMajor}");
		stringBuilder.AppendLine($"\tPantheonMinor: {base.PantheonMinor}");
		DatHideoutWrapper hideout = base.Hideout;
		if (hideout != null)
		{
			stringBuilder.AppendLine($"\tHideout: {hideout.Id}");
			stringBuilder.AppendLine($"\tHideoutLevel: {base.HideoutLevel}");
		}
		Portal townPortal = TownPortal;
		if (townPortal != null)
		{
			stringBuilder.AppendLine($"\tTownPortal: {townPortal.Name}");
		}
		stringBuilder.AppendLine($"\tPartyStatus: {PartyStatus}");
		stringBuilder.AppendLine($"\tLeague: {League}");
		stringBuilder.AppendLine($"\tTotalCursesAllowed: {TotalCursesAllowed}");
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftHandWeaponVisual", base.LeftHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightHandWeaponVisual", base.RightHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "ChestVisual", base.ChestVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "HelmVisual", base.HelmVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "GlovesVisual", base.GlovesVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BootsVisual", base.BootsVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "UnknownVisual", base.UnknownVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftRingVisual", base.LeftRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightRingVisual", base.RightRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BeltVisual", base.BeltVisual));
		stringBuilder.AppendLine($"AscendencyTrialArea");
		string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
		foreach (string text in labyrinthTrialAreaIds)
		{
			stringBuilder.AppendLine($"\t\t{text}: {IsAscendencyTrialCompleted(text)}");
		}
		return stringBuilder.ToString();
	}

	private int method_15()
	{
		return GetStat(StatTypeGGG.BestiaryNetVariation);
	}
}
