using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Structures.ns14;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game;

public class Inventory : RemoteMemoryObject
{
	public class HashNodeStruct242 : RemoteMemoryObject
	{
		private int _struct242Size = -1;

		private int Struct242Size
		{
			get
			{
				if (_struct242Size == -1)
				{
					_struct242Size = MarshalCache<Struct242>.Size;
				}
				return _struct242Size;
			}
		}

		public HashNodeStruct242 Previous => ReadObject<HashNodeStruct242>(base.Address);

		public HashNodeStruct242 Root => ReadObject<HashNodeStruct242>(base.Address + 8L);

		public HashNodeStruct242 Next => ReadObject<HashNodeStruct242>(base.Address + 16L);

		public bool IsNull => GameController.Instance.Memory.ReadByte(base.Address + 25L) != 0;

		public int Key => GameController.Instance.Memory.ReadInt(base.Address + 32L);

		internal long Value1 => GameController.Instance.Memory.ReadLong(base.Address + 40L);
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass44_0
	{
		public int col;

		public Inventory _003C_003E4__this;

		internal bool _003CGetItemPlacementGraph_003Eb__0(KeyValuePair<int, Item> x)
		{
			return x.Value.LocationTopLeft == new Vector2i(col, (!_003C_003E4__this._isEldrichTab) ? 1 : 2);
		}
	}

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private List<int> _storableBaseItemTypeKeys;

	private string _heisLockerMetadata = "";

	private bool _isEldrichTab;

	private bool _isMavenTab;

	private int _struct244InventorySize = -1;

	public int Id { get; internal set; }

	private int Struct244InventorySize
	{
		get
		{
			if (_struct244InventorySize == -1)
			{
				_struct244InventorySize = MarshalCache<Struct244Inventory>.Size;
			}
			return _struct244InventorySize;
		}
	}

	internal Struct244Inventory Struct244_0 => GameController.Instance.Memory.FastIntPtrToStruct<Struct244Inventory>(base.Address + 320L, Struct244InventorySize);

	public bool IsRequested => Struct244_0.isRequested == 1;

	public InventoryType PageType => Struct244_0.inventoryType_0;

	public InventorySlot PageSlot => Struct244_0.inventorySlot_0;

	public Dictionary<int, Item> ItemMap
	{
		get
		{
			if (string.IsNullOrEmpty(_heisLockerMetadata))
			{
				uint num = default(uint);
				Dictionary<int, Item> result2 = default(Dictionary<int, Item>);
				Dictionary<int, Item> result = default(Dictionary<int, Item>);
				Dictionary<int, Item> source2 = default(Dictionary<int, Item>);
				Dictionary<int, long> source3 = default(Dictionary<int, long>);
				Dictionary<int, long> source5 = default(Dictionary<int, long>);
				Dictionary<int, Item> source6 = default(Dictionary<int, Item>);
				while (true)
				{
					IL_01a7:
					if (!_isEldrichTab)
					{
						while (!_isMavenTab)
						{
							while (true)
							{
								if (base.Address != 0L)
								{
									while (true)
									{
										if (PageType != InventoryType.EspeditionLocker)
										{
											while (true)
											{
												if (PageType == InventoryType.SentinelLocker)
												{
													while (true)
													{
														string metadata;
														string metadata2;
														while (true)
														{
															Dictionary<int, Item> source = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap).ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
															while (true)
															{
																IL_013c:
																metadata = "";
																while (true)
																{
																	IL_010c:
																	metadata2 = "";
																	switch (_sentinelType)
																	{
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
																		goto IL_032e;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
																		goto IL_0348;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
																		goto IL_0362;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
																		goto IL_037a;
																	}
																	int num2 = (int)((num * 819672479) ^ 0xE7F5960);
																	while (true)
																	{
																		switch ((num = (uint)num2 ^ 0xBF8EAED2u) % 31u)
																		{
																		case 29u:
																			break;
																		case 6u:
																			num2 = (int)(num * 1525605085) ^ -336694824;
																			continue;
																		case 19u:
																			goto IL_010c;
																		case 16u:
																			goto IL_013c;
																		case 11u:
																			goto end_IL_0015;
																		case 27u:
																			goto end_IL_0166;
																		case 3u:
																			goto end_IL_0172;
																		case 21u:
																			goto end_IL_017e;
																		case 14u:
																			goto end_IL_018d;
																		case 10u:
																			goto IL_01a7;
																		case 1u:
																			goto IL_01b4;
																		case 5u:
																		case 18u:
																			goto end_IL_01a7;
																		case 0u:
																			goto IL_0223;
																		case 9u:
																			return result2;
																		case 30u:
																			goto IL_027e;
																		default:
																			goto IL_02c3;
																		case 28u:
																			goto IL_032e;
																		case 15u:
																			goto IL_0348;
																		case 22u:
																			goto IL_0354;
																		case 8u:
																			goto IL_0362;
																		case 7u:
																			goto IL_036e;
																		case 2u:
																		case 23u:
																		case 24u:
																			goto IL_037a;
																		case 13u:
																			goto IL_03d2;
																		case 26u:
																			goto IL_0492;
																		case 4u:
																			goto end_IL_019a;
																		case 12u:
																			goto IL_04ab;
																		case 25u:
																			goto IL_04f2;
																		case 20u:
																			return result;
																		}
																		break;
																	}
																	break;
																	IL_032e:
																	metadata = "SentinelA";
																	metadata2 = "SentinelCraftedA";
																	goto IL_037a;
																	IL_037a:
																	return source.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && (x.Value.Metadata.Contains(metadata) || x.Value.Metadata.Contains(metadata2))).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
																	IL_0362:
																	metadata = "SentinelC";
																	goto IL_036e;
																	IL_036e:
																	metadata2 = "SentinelCraftedC";
																	goto IL_037a;
																	IL_0348:
																	metadata = "SentinelB";
																	goto IL_0354;
																	IL_0354:
																	metadata2 = "SentinelCraftedB";
																	goto IL_037a;
																}
																break;
															}
															continue;
															end_IL_0015:
															break;
														}
														continue;
														end_IL_0166:
														break;
													}
													continue;
												}
												goto IL_01b4;
												IL_02c3:
												return source2.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
												IL_01b4:
												source3 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap);
												goto IL_027e;
												IL_027e:
												source2 = source3.ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
												goto IL_02c3;
												continue;
												end_IL_0172:
												break;
											}
											continue;
										}
										goto IL_03d2;
										IL_03d2:
										Dictionary<int, Item> source4 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap).ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
										return source4.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && x.Value.Metadata == "Metadata/Items/Expedition/ExpeditionLogbook").ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
										continue;
										end_IL_017e:
										break;
									}
									continue;
								}
								goto IL_0492;
								IL_0492:
								return new Dictionary<int, Item>();
								continue;
								end_IL_018d:
								break;
							}
							continue;
							end_IL_019a:
							break;
						}
					}
					source5 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap);
					goto IL_04ab;
					IL_04f2:
					return source6.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && IsEldrichMavenBaseItemType(x.Value.BaseItemType.Index)).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
					IL_04ab:
					source6 = source5.ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
					goto IL_04f2;
					continue;
					end_IL_01a7:
					break;
				}
			}
			Dictionary<int, long> source7 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap);
			Dictionary<int, Item> source8 = source7.ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
			goto IL_0223;
			IL_0223:
			return source8.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && x.Value.Metadata == _heisLockerMetadata).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
		}
	}

	public List<Item> Items
	{
		get
		{
			if (base.Address == 0L)
			{
				return new List<Item>();
			}
			return ItemMap.Values.ToList();
		}
	}

	public int Rows
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.rows;
			}
			return 6;
		}
	}

	public int Cols
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Columns;
			}
			return 12;
		}
	}

	public int Columns
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.cols;
			}
			return 12;
		}
	}

	public int InventorySpacePercent
	{
		get
		{
			if (PageType == InventoryType.SentinelLocker)
			{
				return (int)(100.0 * (double)AvailableInventorySquares / 120.0);
			}
			return (int)(100.0 * (double)AvailableInventorySquares / (double)((float)Rows * (float)Columns));
		}
	}

	public int AvailableInventorySquares
	{
		get
		{
			int rows = Rows;
			int num;
			uint num3 = default(uint);
			int num5 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			while (true)
			{
				int columns = Columns;
				bool[,] itemPlacementGraph = GetItemPlacementGraph();
				num = 0;
				if (PageType == InventoryType.SentinelLocker)
				{
					while (true)
					{
						int num2 = 0;
						LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
						while (true)
						{
							switch (sentinelType)
							{
							case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
								goto IL_00fd;
							case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
								goto IL_0102;
							case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
								goto IL_0108;
							case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
								goto IL_010c;
							}
							int num4 = ((int)num3 * -1544333556) ^ -2114213278;
							while (true)
							{
								switch ((num3 = (uint)num4 ^ 0x72DE84ECu) % 30u)
								{
								case 4u:
									num4 = (int)(num3 * 1860062260) ^ -705916006;
									continue;
								case 11u:
									break;
								case 20u:
									goto end_IL_00b8;
								case 3u:
								case 26u:
									goto end_IL_00d4;
								case 19u:
									goto IL_00fd;
								case 25u:
									goto IL_0102;
								case 29u:
									goto IL_0108;
								case 6u:
								case 14u:
								case 24u:
									goto IL_010c;
								case 2u:
									goto IL_0112;
								case 18u:
									goto IL_0117;
								case 16u:
									goto IL_0123;
								case 8u:
									goto IL_0127;
								case 7u:
								case 9u:
									goto IL_012d;
								case 12u:
									goto IL_0132;
								case 22u:
								case 23u:
									goto IL_0138;
								case 0u:
									goto IL_0141;
								case 10u:
									goto IL_0143;
								case 27u:
									goto IL_0148;
								case 21u:
									goto IL_014d;
								case 15u:
									goto IL_0159;
								case 13u:
									goto IL_015d;
								case 17u:
									goto IL_0163;
								case 1u:
									goto IL_0168;
								case 5u:
									goto IL_016e;
								default:
									goto end_IL_00e1;
								}
								break;
							}
							continue;
							IL_0123:
							num++;
							goto IL_0127;
							IL_0127:
							num5++;
							goto IL_012d;
							IL_0108:
							num2 = 24;
							goto IL_010c;
							IL_0102:
							num2 = 12;
							goto IL_010c;
							IL_00fd:
							num2 = 0;
							goto IL_010c;
							IL_010c:
							num6 = num2;
							goto IL_0138;
							IL_0138:
							if (num6 < num2 + 12)
							{
								goto IL_0112;
							}
							goto IL_0141;
							IL_0141:
							return num;
							IL_0112:
							num5 = 0;
							goto IL_012d;
							IL_012d:
							if (num5 < rows)
							{
								goto IL_0117;
							}
							goto IL_0132;
							IL_0132:
							num6++;
							goto IL_0138;
							IL_0117:
							if (!itemPlacementGraph[num5, num6])
							{
								goto IL_0123;
							}
							goto IL_0127;
							continue;
							end_IL_00b8:
							break;
						}
						continue;
						end_IL_00d4:
						break;
					}
					continue;
				}
				goto IL_0143;
				IL_015d:
				num7++;
				goto IL_0163;
				IL_0143:
				num8 = 0;
				goto IL_016e;
				IL_016e:
				if (num8 >= columns)
				{
					break;
				}
				goto IL_0148;
				IL_0148:
				num7 = 0;
				goto IL_0163;
				IL_0163:
				if (num7 < rows)
				{
					goto IL_014d;
				}
				goto IL_0168;
				IL_0168:
				num8++;
				goto IL_016e;
				IL_014d:
				if (!itemPlacementGraph[num7, num8])
				{
					goto IL_0159;
				}
				goto IL_015d;
				IL_0159:
				num++;
				goto IL_015d;
				continue;
				end_IL_00e1:
				break;
			}
			return num;
		}
	}

	internal Inventory(long inventoryPageContents, int id)
		: base(inventoryPageContents)
	{
		Id = id;
	}

	internal Inventory(long inventoryPageContents)
		: base(inventoryPageContents)
	{
		Id = 0;
	}

	internal Inventory(long inventoryPageContents, string heistLockerMetadata)
		: base(inventoryPageContents)
	{
		Id = 0;
		_heisLockerMetadata = heistLockerMetadata;
	}

	internal Inventory(long inventoryPageContents, LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType)
		: base(inventoryPageContents)
	{
		Id = 0;
		_sentinelType = sentinelType;
	}

	internal Inventory(long inventoryPageContents, bool isEldrichTab = false, bool isMavenTab = false, List<int> storableBaseItemTypeKeys = null)
		: base(inventoryPageContents)
	{
		Id = 0;
		_isEldrichTab = isEldrichTab;
		_isMavenTab = isMavenTab;
		_storableBaseItemTypeKeys = storableBaseItemTypeKeys;
	}

	private Dictionary<int, long> ReadHashMapStruct242(long pointer, uint size)
	{
		Dictionary<int, long> dictionary = new Dictionary<int, long>();
		if (size == 0)
		{
			return dictionary;
		}
		Stack<HashNodeStruct242> stack = new Stack<HashNodeStruct242>();
		HashNodeStruct242 @object = GetObject<HashNodeStruct242>(pointer);
		HashNodeStruct242 root = @object.Root;
		stack.Push(root);
		while (stack.Count != 0)
		{
			HashNodeStruct242 hashNodeStruct = stack.Pop();
			if (hashNodeStruct.Address != 0L)
			{
				if (!hashNodeStruct.IsNull && !dictionary.ContainsKey(hashNodeStruct.Key))
				{
					dictionary.Add(hashNodeStruct.Key, hashNodeStruct.Value1);
				}
				HashNodeStruct242 previous = hashNodeStruct.Previous;
				if (!previous.IsNull)
				{
					stack.Push(previous);
				}
				HashNodeStruct242 next = hashNodeStruct.Next;
				if (!next.IsNull)
				{
					stack.Push(next);
				}
			}
		}
		stack.Clear();
		return dictionary;
	}

	private bool IsEldrichMavenBaseItemType(int index)
	{
		return _storableBaseItemTypeKeys.Any((int x) => x == index - 1);
	}

	public Item FindItemByPos(Vector2i pos)
	{
		return GetItemAtLocation(pos);
	}

	public Item GetItemById(int id)
	{
		if (ItemMap.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public bool NextAvailableInventoryPosition(int w, int h, out Vector2i pos)
	{
		pos = Vector2i.Zero;
		int rows = Rows;
		int columns = Columns;
		for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (CanFitItemAt(i, j, w, h, allowOverlap: false, out var _))
				{
					pos = new Vector2i(i, j);
					return true;
				}
			}
		}
		return false;
	}

	public bool[,] GetItemPlacementGraph()
	{
		int rows = Rows;
		int columns = Columns;
		uint num2 = default(uint);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		_003C_003Ec__DisplayClass44_0 _003C_003Ec__DisplayClass44_ = default(_003C_003Ec__DisplayClass44_0);
		while (true)
		{
			bool[,] array = new bool[rows, columns];
			while (true)
			{
				IL_013f:
				if (!_isEldrichTab)
				{
					while (!_isMavenTab)
					{
						while (true)
						{
							List<long> list = Containers.StdLongVector<long>(Struct244_0.nativeVector_ItemPlacementGraph);
							while (true)
							{
								if (PageType == InventoryType.SentinelLocker)
								{
									while (true)
									{
										int num = 0;
										switch (_sentinelType)
										{
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
											goto IL_01b5;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
											goto IL_01ba;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
											goto IL_01c0;
										case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
											goto IL_01c4;
										}
										int num3 = ((int)num2 * -2085459054) ^ -787549410;
										while (true)
										{
											switch ((num2 = (uint)num3 ^ 0xD85A262Eu) % 41u)
											{
											case 10u:
												num3 = ((int)num2 * -2036404814) ^ -140482314;
												continue;
											case 19u:
												break;
											case 14u:
												goto end_IL_00eb;
											case 8u:
												goto end_IL_0112;
											case 35u:
												goto end_IL_0121;
											case 13u:
												goto IL_013f;
											case 7u:
											case 18u:
												goto end_IL_013f;
											case 37u:
												goto end_IL_0135;
											case 17u:
												goto IL_0158;
											case 2u:
												goto IL_015d;
											case 30u:
												goto IL_017b;
											case 39u:
												goto IL_019d;
											case 9u:
											case 32u:
												goto IL_01a3;
											case 16u:
												goto IL_01a8;
											case 11u:
											case 40u:
												goto IL_01ae;
											case 4u:
												goto IL_01b3;
											case 20u:
												goto IL_01b5;
											case 31u:
												goto IL_01ba;
											case 0u:
												goto IL_01c0;
											case 36u:
												goto IL_01c4;
											case 27u:
												goto IL_01ca;
											case 1u:
												goto IL_01cf;
											case 21u:
											case 28u:
												goto IL_01f7;
											case 5u:
												goto IL_01fc;
											case 15u:
											case 29u:
												goto IL_0202;
											case 38u:
												goto IL_020b;
											case 3u:
												goto IL_020d;
											case 22u:
												goto IL_0212;
											case 12u:
												goto IL_0217;
											case 33u:
												goto IL_0239;
											case 24u:
											case 25u:
												goto IL_023f;
											case 26u:
												goto IL_0244;
											case 6u:
											case 34u:
												goto IL_024a;
											default:
												goto IL_024f;
											}
											break;
										}
										continue;
										IL_01fc:
										num4++;
										goto IL_0202;
										IL_01cf:
										array[num5, num4] = (ulong)list[num4 + num5 * columns] > 0uL;
										num5++;
										goto IL_01f7;
										IL_01c0:
										num = 24;
										goto IL_01c4;
										IL_01ba:
										num = 12;
										goto IL_01c4;
										IL_01b5:
										num = 0;
										goto IL_01c4;
										IL_01c4:
										num4 = num;
										goto IL_0202;
										IL_0202:
										if (num4 < num + 12)
										{
											goto IL_01ca;
										}
										goto IL_020b;
										IL_020b:
										return array;
										IL_01ca:
										num5 = 0;
										goto IL_01f7;
										IL_01f7:
										if (num5 < rows)
										{
											goto IL_01cf;
										}
										goto IL_01fc;
										continue;
										end_IL_00eb:
										break;
									}
									continue;
								}
								goto IL_020d;
								IL_0239:
								num6++;
								goto IL_023f;
								IL_020d:
								num7 = 0;
								goto IL_024a;
								IL_024a:
								if (num7 < columns)
								{
									goto IL_0212;
								}
								goto IL_024f;
								IL_024f:
								return array;
								IL_0212:
								num6 = 0;
								goto IL_023f;
								IL_023f:
								if (num6 < rows)
								{
									goto IL_0217;
								}
								goto IL_0244;
								IL_0244:
								num7++;
								goto IL_024a;
								IL_0217:
								array[num6, num7] = (ulong)list[num7 + num6 * columns] > 0uL;
								goto IL_0239;
								continue;
								end_IL_0112:
								break;
							}
							continue;
							end_IL_0121:
							break;
						}
						continue;
						end_IL_0135:
						break;
					}
				}
				num8 = 0;
				goto IL_01ae;
				IL_019d:
				num9++;
				goto IL_01a3;
				IL_017b:
				array[num9, num8] = ItemMap.Any(_003C_003Ec__DisplayClass44_._003CGetItemPlacementGraph_003Eb__0);
				goto IL_019d;
				IL_01ae:
				if (num8 < columns)
				{
					goto IL_0158;
				}
				goto IL_01b3;
				IL_01b3:
				return array;
				IL_0158:
				num9 = 0;
				goto IL_01a3;
				IL_01a3:
				if (num9 < rows)
				{
					goto IL_015d;
				}
				goto IL_01a8;
				IL_01a8:
				num8++;
				goto IL_01ae;
				IL_015d:
				_003C_003Ec__DisplayClass44_ = new _003C_003Ec__DisplayClass44_0();
				_003C_003Ec__DisplayClass44_._003C_003E4__this = this;
				_003C_003Ec__DisplayClass44_.col = num8 + 12 * num9;
				goto IL_017b;
				continue;
				end_IL_013f:
				break;
			}
		}
	}

	public bool CanFitItemAt(int col, int row, int width, int height, bool allowOverlap, out bool overlapped)
	{
		overlapped = false;
		if (col < 0)
		{
			return false;
		}
		if (row < 0)
		{
			return false;
		}
		if (col + width > Columns)
		{
			return false;
		}
		if (row + height > Rows)
		{
			return false;
		}
		List<long> list = new List<long>();
		for (int i = col; i < col + width; i++)
		{
			for (int j = row; j < row + height; j++)
			{
				Item itemAtLocation = GetItemAtLocation(i, j);
				if (itemAtLocation != null)
				{
					if (!allowOverlap)
					{
						overlapped = true;
						return false;
					}
					if (!list.Contains(itemAtLocation.Address))
					{
						list.Add(itemAtLocation.Address);
					}
				}
			}
		}
		overlapped = list.Count > 1;
		return list.Count <= 1;
	}

	public Item GetItemAtLocation(Vector2i pos)
	{
		return GetItemAtLocation(pos.X, pos.Y);
	}

	public Item GetItemAtLocation(int col, int row)
	{
		if (PageType == InventoryType.SentinelLocker)
		{
			uint num = default(uint);
			while (true)
			{
				switch (_sentinelType)
				{
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
					goto IL_0081;
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
					goto IL_0089;
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
					goto end_IL_0062;
				}
				int num2 = (int)((num * 1384501244) ^ 0x112BA81D);
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x2918813Fu) % 8u)
					{
					case 6u:
						num2 = ((int)num * -1039700903) ^ 0x10B45E53;
						continue;
					case 4u:
					case 7u:
						break;
					case 5u:
						goto IL_0081;
					case 0u:
						goto IL_0089;
					case 2u:
						goto end_IL_0062;
					case 3u:
						goto IL_009a;
					default:
						goto IL_0177;
					}
					break;
				}
				continue;
				IL_0089:
				col += 24;
				break;
				IL_0081:
				col += 12;
				break;
				continue;
				end_IL_0062:
				break;
			}
		}
		if (!_isEldrichTab)
		{
			goto IL_009a;
		}
		goto IL_0177;
		IL_009a:
		if (!_isMavenTab)
		{
			foreach (Item item in Items)
			{
				Vector2i locationTopLeft = item.LocationTopLeft;
				Vector2i size = item.Size;
				if ((size.X > 1 || size.Y > 1) && size.X >= 1 && size.Y >= 1)
				{
					if (new Rect(locationTopLeft.X, locationTopLeft.Y, size.X - 1, size.Y - 1).Contains(col, row))
					{
						return item;
					}
				}
				else if (locationTopLeft.X == col && locationTopLeft.Y == row)
				{
					return item;
				}
			}
			return null;
		}
		goto IL_0177;
		IL_0177:
		foreach (Item item2 in Items)
		{
			Vector2i locationTopLeft2 = item2.LocationTopLeft;
			if (locationTopLeft2.X != col + 12 * row || locationTopLeft2.Y != ((!_isEldrichTab) ? 1 : 2))
			{
				continue;
			}
			return item2;
		}
		return null;
	}

	public bool CanFitItem(Item item)
	{
		int col;
		int row;
		return CanFitItem(item, out col, out row);
	}

	internal void SetId(int int_1)
	{
		Id = int_1;
	}

	public bool CanFitItem(Item item, out int col, out int row)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		return CanFitItem(item.Size, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize, out int col, out int row)
	{
		return CanFitItem(itemSize.X, itemSize.Y, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize)
	{
		int fcol;
		int frow;
		return CanFitItem(itemSize.X, itemSize.Y, out fcol, out frow);
	}

	public bool CanFitItem(int itemWidth, int itemHeight, out int fcol, out int frow)
	{
		fcol = -1;
		uint num2 = default(uint);
		int num4 = default(int);
		int num5 = default(int);
		Vector2i vector2i = default(Vector2i);
		Vector2i vector2i2 = default(Vector2i);
		bool flag = default(bool);
		int num6 = default(int);
		int num7 = default(int);
		LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType2 = default(LokiPoe.InGameState.SentinelLockerUi.SentinelType);
		int num8 = default(int);
		int num9 = default(int);
		Vector2i vector2i3 = default(Vector2i);
		Vector2i vector2i4 = default(Vector2i);
		bool flag2 = default(bool);
		int num10 = default(int);
		int num11 = default(int);
		bool result = default(bool);
		while (true)
		{
			frow = -1;
			while (true)
			{
				if (PageType != InventoryType.Cursor)
				{
					while (true)
					{
						bool[,] itemPlacementGraph = GetItemPlacementGraph();
						while (true)
						{
							int columns = Columns;
							while (true)
							{
								int rows = Rows;
								if (PageType == InventoryType.SentinelLocker)
								{
									while (true)
									{
										int num = 0;
										LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
										while (true)
										{
											IL_0270:
											switch (sentinelType)
											{
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
												break;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
												goto IL_024d;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
												goto IL_0251;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
												goto IL_0257;
											default:
												goto IL_025d;
											}
											goto IL_0248;
											IL_025d:
											int num3 = (int)(num2 * 1086136943) ^ -534887476;
											goto IL_0036;
											IL_0248:
											num = 0;
											goto IL_0251;
											IL_0251:
											num4 = num;
											goto IL_0236;
											IL_0236:
											if (num4 < num + 12 - (itemWidth - 1))
											{
												goto IL_022b;
											}
											goto IL_03b1;
											IL_022b:
											num5 = 0;
											goto IL_0220;
											IL_0220:
											if (num5 < rows - (itemHeight - 1))
											{
												goto IL_01fe;
											}
											goto IL_0230;
											IL_01fe:
											vector2i = new Vector2i(num4, num5);
											vector2i2 = new Vector2i(num4 + itemWidth, num5 + itemHeight);
											goto IL_01f9;
											IL_01f9:
											flag = true;
											goto IL_01ee;
											IL_01ee:
											num6 = vector2i.X;
											goto IL_01e1;
											IL_01e1:
											if (num6 >= vector2i2.X)
											{
												goto IL_01a6;
											}
											goto IL_01d0;
											IL_01d0:
											num7 = vector2i.Y;
											goto IL_01c3;
											IL_01c3:
											if (num7 < vector2i2.Y)
											{
												goto IL_01b1;
											}
											goto IL_01db;
											IL_01b1:
											if (itemPlacementGraph[num7, num6])
											{
												goto IL_01ac;
											}
											goto IL_01bd;
											IL_01ac:
											flag = false;
											goto IL_01a6;
											IL_01a6:
											if (flag)
											{
												goto IL_019c;
											}
											goto IL_021a;
											IL_019c:
											sentinelType2 = _sentinelType;
											goto IL_0180;
											IL_0180:
											switch (sentinelType2)
											{
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
												goto IL_0394;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
												goto IL_039a;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
												goto IL_03a3;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
												goto IL_03aa;
											}
											num3 = ((int)num2 * -1816602226) ^ 0x587E2999;
											goto IL_0036;
											IL_03b1:
											return false;
											IL_0036:
											while (true)
											{
												switch ((num2 = (uint)num3 ^ 0x4B0B9583u) % 77u)
												{
												case 73u:
													num3 = ((int)num2 * -1557202596) ^ 0x53B07AF0;
													continue;
												case 6u:
													num3 = (int)(num2 * 952245061) ^ -1840416613;
													continue;
												case 26u:
													break;
												case 31u:
													goto IL_019c;
												case 32u:
												case 60u:
													goto IL_01a6;
												case 38u:
													goto IL_01ac;
												case 2u:
													goto IL_01b1;
												case 55u:
													goto IL_01bd;
												case 22u:
												case 43u:
												case 75u:
													goto IL_01c3;
												case 44u:
													goto IL_01d0;
												case 23u:
													goto IL_01db;
												case 8u:
												case 12u:
													goto IL_01e1;
												case 70u:
													goto IL_01ee;
												case 51u:
													goto IL_01f9;
												case 17u:
													goto IL_01fe;
												case 37u:
													goto IL_021a;
												case 52u:
												case 64u:
													goto IL_0220;
												case 29u:
													goto IL_022b;
												case 34u:
													goto IL_0230;
												case 1u:
												case 48u:
													goto IL_0236;
												case 7u:
													goto IL_0248;
												case 61u:
													goto IL_024d;
												case 25u:
												case 39u:
												case 56u:
													goto IL_0251;
												case 5u:
													goto IL_0257;
												case 69u:
													goto IL_0270;
												case 21u:
													goto end_IL_0270;
												case 15u:
													goto end_IL_0289;
												case 62u:
													goto end_IL_0296;
												case 11u:
													goto end_IL_02a9;
												case 40u:
													goto end_IL_02b2;
												case 42u:
												case 72u:
													goto end_IL_02bb;
												case 4u:
													goto IL_02cd;
												case 41u:
													goto IL_02e1;
												case 63u:
													goto IL_02e6;
												case 0u:
													goto IL_02e9;
												case 46u:
													goto IL_02ed;
												case 30u:
													goto IL_02ef;
												case 10u:
													goto IL_02fb;
												case 33u:
													goto IL_0303;
												case 18u:
													goto IL_0306;
												case 24u:
													goto IL_030a;
												case 67u:
													goto IL_0310;
												case 49u:
													goto IL_0319;
												case 74u:
													goto IL_0321;
												case 9u:
													goto IL_0326;
												case 57u:
													goto IL_0340;
												case 66u:
													goto IL_0343;
												case 47u:
												case 71u:
													goto IL_034c;
												case 50u:
												case 59u:
													goto IL_0359;
												case 53u:
													goto IL_0364;
												case 14u:
													goto IL_036f;
												case 27u:
												case 36u:
												case 76u:
													goto IL_0377;
												default:
													goto IL_0387;
												case 3u:
													goto IL_0389;
												case 58u:
													goto IL_038d;
												case 45u:
													goto IL_0392;
												case 35u:
													goto IL_0394;
												case 68u:
													goto IL_039a;
												case 28u:
													goto IL_03a3;
												case 20u:
												case 54u:
												case 65u:
													goto IL_03aa;
												case 13u:
													goto IL_03af;
												case 16u:
													goto IL_03b1;
												}
												break;
											}
											goto IL_0180;
											IL_03a3:
											fcol = num4 - 24;
											goto IL_03aa;
											IL_039a:
											fcol = num4 - 12;
											goto IL_03aa;
											IL_0394:
											fcol = num4;
											goto IL_03aa;
											IL_03aa:
											frow = num5;
											goto IL_03af;
											IL_03af:
											return true;
											IL_0257:
											num = 24;
											goto IL_0251;
											IL_024d:
											num = 12;
											goto IL_0251;
											IL_0230:
											num4++;
											goto IL_0236;
											IL_021a:
											num5++;
											goto IL_0220;
											IL_01db:
											num6++;
											goto IL_01e1;
											IL_01bd:
											num7++;
											goto IL_01c3;
											continue;
											end_IL_0270:
											break;
										}
										continue;
										end_IL_0289:
										break;
									}
									continue;
								}
								goto IL_02e1;
								IL_0387:
								return false;
								IL_02e1:
								num8 = 0;
								goto IL_0359;
								IL_0359:
								if (num8 < columns - (itemWidth - 1))
								{
									goto IL_0321;
								}
								goto IL_0387;
								IL_0321:
								num9 = 0;
								goto IL_0310;
								IL_0310:
								if (num9 >= rows - (itemHeight - 1))
								{
									goto IL_0319;
								}
								goto IL_0326;
								IL_0319:
								num8++;
								goto IL_0359;
								IL_0326:
								vector2i3 = new Vector2i(num8, num9);
								vector2i4 = new Vector2i(num8 + itemWidth, num9 + itemHeight);
								goto IL_0340;
								IL_0340:
								flag2 = true;
								goto IL_0343;
								IL_0343:
								num10 = vector2i3.X;
								goto IL_034c;
								IL_034c:
								if (num10 >= vector2i4.X)
								{
									goto IL_0306;
								}
								goto IL_0364;
								IL_0364:
								num11 = vector2i3.Y;
								goto IL_0377;
								IL_0377:
								if (num11 < vector2i4.Y)
								{
									goto IL_02ef;
								}
								goto IL_036f;
								IL_036f:
								num10++;
								goto IL_034c;
								IL_02ef:
								if (!itemPlacementGraph[num11, num10])
								{
									goto IL_02fb;
								}
								goto IL_0303;
								IL_02fb:
								num11++;
								goto IL_0377;
								IL_0303:
								flag2 = false;
								goto IL_0306;
								IL_0306:
								if (!flag2)
								{
									goto IL_030a;
								}
								goto IL_0389;
								IL_030a:
								num9++;
								goto IL_0310;
								IL_0389:
								fcol = num8;
								goto IL_038d;
								IL_038d:
								frow = num9;
								goto IL_0392;
								IL_0392:
								return true;
								continue;
								end_IL_0296:
								break;
							}
							continue;
							end_IL_02a9:
							break;
						}
						continue;
						end_IL_02b2:
						break;
					}
					continue;
				}
				goto IL_02cd;
				IL_02ed:
				return result;
				IL_02cd:
				if (result = !Items.Any())
				{
					goto IL_02e6;
				}
				goto IL_02ed;
				IL_02e6:
				fcol = 0;
				goto IL_02e9;
				IL_02e9:
				frow = 0;
				goto IL_02ed;
				continue;
				end_IL_02bb:
				break;
			}
		}
	}

	public bool CanSlideItemUpOrLeft(Item item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (!item.HasInventoryLocation)
		{
			throw new Exception($"The item {item.FullName} does not have an inventory location.");
		}
		bool[,] itemPlacementGraph = GetItemPlacementGraph();
		bool flag = true;
		if (item.LocationTopLeft.Y > 0)
		{
			for (int i = 0; i < item.Size.X; i++)
			{
				if (itemPlacementGraph[item.LocationTopLeft.Y - 1, item.LocationTopLeft.X + i])
				{
					flag = false;
					break;
				}
			}
		}
		else
		{
			flag = false;
		}
		bool flag2 = true;
		if (item.LocationTopLeft.X <= 0)
		{
			flag2 = false;
		}
		else
		{
			for (int j = 0; j < item.Size.Y; j++)
			{
				if (itemPlacementGraph[item.LocationTopLeft.Y + j, item.LocationTopLeft.X - 1])
				{
					flag2 = false;
					break;
				}
			}
		}
		return flag2 || flag;
	}

	public bool CanFitItemSizeAt(int itemWidth, int itemHeight, int col, int row)
	{
		Vector2i vector2i = new Vector2i(col, row);
		Vector2i vector2i2 = new Vector2i(col + itemWidth, row + itemHeight);
		if (vector2i2.X <= Columns && vector2i2.Y <= Rows)
		{
			bool[,] itemPlacementGraph = GetItemPlacementGraph();
			for (int i = vector2i.X; i < vector2i2.X; i++)
			{
				for (int j = vector2i.Y; j < vector2i2.Y; j++)
				{
					if (itemPlacementGraph[j, i])
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public Item FindItemByFullName(string fullName)
	{
		return Items.FirstOrDefault((Item x) => x.FullName == fullName);
	}

	public Item FindItemByName(string name)
	{
		return Items.FirstOrDefault((Item x) => x.Name == name);
	}

	private int GetTotalItemQuantity(IEnumerable<Item> ienumerable_0)
	{
		int num = 0;
		foreach (Item item in ienumerable_0)
		{
			num += item.StackCount;
		}
		return num;
	}

	public int GetTotalItemQuantityByName(string name)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Name == name);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByFullName(string fullName)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.FullName == fullName);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadata(string metadata)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Metadata == metadata);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadataFlags(MetadataFlags flag)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.HasMetadataFlags(flag));
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemStacksByFullName(string fullName)
	{
		return Items.Count((Item x) => x.FullName == fullName);
	}

	public bool NeedsToMerge()
	{
		List<Item> list = (from x in Items
			where x.Rarity == Rarity.Currency && x.Rarity != Rarity.Quest && x.MaxStackCount > 1 && x.StackCount != x.MaxStackCount
			orderby x.FullName
			select x).ToList();
		for (int i = 0; i < list.Count - 1; i++)
		{
			Item item = list[i];
			Item item2 = list[i + 1];
			if (item.FullName == item2.FullName)
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Inventory] {Id}");
		stringBuilder.AppendLine($"\tIsRequested: {IsRequested}");
		stringBuilder.AppendLine($"\tPageType: {PageType}");
		stringBuilder.AppendLine($"\tPageSlot: {PageSlot}");
		stringBuilder.AppendLine($"\tRows: {Rows}");
		stringBuilder.AppendLine($"\tCols: {Cols}");
		stringBuilder.AppendLine($"\t[Items]");
		foreach (Item item in Items)
		{
			stringBuilder.AppendLine($"\t\t{item.StackCount}x {item.FullName}");
		}
		return stringBuilder.ToString();
	}
}
