using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns14;
using JetBrains.Annotations;

namespace DreamPoeBot.Loki.Game.Objects;

public class Item : RemoteMemoryObject
{
	private int? _localId;

	private List<Item[]> list_0;

	private List<SocketColor[]> list_1;

	private byte[] byte_0;

	private SocketColor[] socketColor_0;

	private string string_2FullName;

	private string string_4;

	[CanBeNull]
	private string _metadata;

	private bool? nullable_0;

	private bool? nullable_1;

	private int? nullable_2;

	private int? nullable_3;

	private int? nullable_4;

	private int? nullable_5;

	private int? nullable_6;

	private int? nullable_7;

	private int? nullable_11;

	private int? nullable_12;

	private InventoryTabMapSeries? nullable_13;

	private int? nullable_14;

	private int? nullable_15;

	private int? nullable_16;

	private int? nullable_17;

	private int? nullable_18;

	private int? nullable_19;

	private int? nullable_20;

	private DatPropheciesWrapper datPropheciesWrapper_0;

	private int? nullable_21;

	private int? nullable_22;

	private int? nullable_23;

	private int? nullable_24;

	private int? nullable_25;

	private int? nullable_26;

	private int? nullable_27;

	private int? nullable_28;

	private int? nullable_29;

	private int? nullable_30;

	private int? nullable_31;

	private int? nullable_32;

	private int? nullable_33;

	private int? nullable_34;

	private int? nullable_35;

	private int? nullable_36;

	private int? nullable_37;

	private int? nullable_38;

	private int? nullable_39;

	private int? nullable_40;

	private double? nullable_41;

	private double? nullable_42;

	private double? nullable_43;

	private double? nullable_44;

	private int? nullable_45;

	private int? nullable_46;

	private int? nullable_47;

	private int? nullable_48;

	private bool? nullable_49;

	private int? nullable_50;

	private int? nullable_51;

	private float? nullable_52;

	private float? nullable_53;

	private bool? nullable_54;

	private TimeSpan? nullable_55;

	private bool? nullable_56;

	private int? nullable_57;

	private int? nullable_58;

	private int? nullable_59;

	private double? nullable_60;

	private int? nullable_61;

	private int? nullable_64;

	private SocketColor? nullable_65;

	private int? nullable_66;

	private GemQualityType? nullable_67;

	private DatWorldAreaWrapper datWorldAreaWrapper_0;

	private List<ExpeditionWrapper> expeditions_0;

	private string mapRegion;

	private int? _worldItemId;

	private DatBaseItemTypeWrapper? nullable_BaseItemType;

	private HashSet<MetadataFlags> hashSet_0;

	private CompositeItemType compositeItemType_0;

	private EntityComponentInformation _components;

	public bool HasInventoryLocation { get; internal set; }

	public Vector2i LocationBottomRight { get; internal set; }

	public Vector2i LocationTopLeft { get; internal set; }

	public string Metadata
	{
		get
		{
			if (_metadata == null)
			{
				long num = base.M.ReadLong(base.Address + 8L);
				NativeStringWCustom nativeString = base.M.IntptrToNativeStringWCustom(num + 8L);
				_metadata = Containers.StdStringWCustom(nativeString);
			}
			return _metadata;
		}
	}

	private bool Boolean_0
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				if (!LocalStats.ContainsKey(StatTypeGGG.MapTier16))
				{
					nullable_0 = false;
				}
				else
				{
					nullable_0 = true;
				}
			}
			return nullable_0.Value;
		}
	}

	private bool Boolean_1
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				if (LocalStats.ContainsKey(StatTypeGGG.MapTierPos5))
				{
					nullable_1 = true;
				}
				else
				{
					nullable_1 = false;
				}
			}
			return nullable_1.Value;
		}
	}

	public new bool IsValid => base.M.ReadInt(base.Address + 8L, 8L, 0L) == 6619213;

	public int Id => base.M.ReadInt(base.Address + 80L);

	public int InventoryId => base.M.ReadInt(base.Address + 88L);

	public bool HasCurrentAction
	{
		get
		{
			if (Components.ActorComponent != null)
			{
				return Components.ActorComponent.CurrentAction != null;
			}
			return false;
		}
	}

	public DreamPoeBot.Loki.Components.Actor.ActionWrapper CurrentAction
	{
		get
		{
			if (!(Components.ActorComponent != null))
			{
				return null;
			}
			return Components.ActorComponent.CurrentAction;
		}
	}

	public bool IsDead
	{
		get
		{
			if (Components.LifeComponent != null)
			{
				return Components.LifeComponent.Health == 0;
			}
			return false;
		}
	}

	public int LocalId
	{
		get
		{
			if (!_localId.HasValue)
			{
				return Id;
			}
			return _localId.Value;
		}
	}

	public string Name
	{
		get
		{
			string text = "";
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				text = baseComponent.Name;
			}
			if (string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(BaseItemType?.Name))
			{
				text = BaseItemType.Name;
			}
			if (string.IsNullOrEmpty(text))
			{
				text = Metadata;
			}
			return text;
		}
	}

	public string FullName
	{
		get
		{
			if (string_2FullName == null)
			{
				string_2FullName = Name;
				DreamPoeBot.Loki.Components.Prophecy prophecyComponent = Components.ProphecyComponent;
				if (prophecyComponent != null)
				{
					if (prophecyComponent.DatPropheciesWrapper != null)
					{
						string_2FullName = prophecyComponent.DatPropheciesWrapper.Name;
						return string_2FullName;
					}
					throw new Exception("DatPropheciesWrapper was null!");
				}
				if (!IsIdentified || Rarity == Rarity.Normal)
				{
					if (Quality != 0)
					{
						string_2FullName = "Superior " + string_2FullName;
					}
					return string_2FullName;
				}
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent == null)
				{
					return string_2FullName;
				}
				List<string> list = modsComponent.IEnumerable_0FullName.ToList();
				if (list.Count != 0)
				{
					string_2FullName = string.Join(" ", list).Trim();
					return string_2FullName;
				}
				if (Rarity == Rarity.Magic)
				{
					string_2FullName = Name;
					foreach (ModAffix item in modsComponent.ExplicitAffixes.Where((ModAffix x) => !x.IsHidden))
					{
						if (!item.IsPrefix)
						{
							if (item.IsSuffix)
							{
								string_2FullName = string_2FullName + " " + item.DisplayName;
							}
						}
						else
						{
							string_2FullName = item.DisplayName + " " + string_2FullName;
						}
					}
				}
			}
			return string_2FullName;
		}
	}

	public bool AppliesToCurrentAreaByLevel
	{
		get
		{
			if (!nullable_49.HasValue)
			{
				int monsterLevel = LokiPoe.LocalData.WorldArea.MonsterLevel;
				nullable_49 = monsterLevel >= MinMonsterLevel && monsterLevel <= MaxMonsterLevel;
			}
			return nullable_49.Value;
		}
	}

	public List<string> Tags
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.Tags;
			}
			return new List<string>();
		}
	}

	public int AbsorbedCorruption
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (!(baseComponent != null))
			{
				return 0;
			}
			return baseComponent.AbsorbedCorruption;
		}
	}

	public int ScourgedTier
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (!(baseComponent != null))
			{
				return 0;
			}
			return baseComponent.ScourgedTier;
		}
	}

	public int BaseWeaponType
	{
		get
		{
			if (!nullable_22.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (weaponComponent != null)
				{
					nullable_22 = weaponComponent.BaseWeaponType;
				}
				else
				{
					nullable_22 = -1;
				}
			}
			return nullable_22.Value;
		}
	}

	public int StackCount
	{
		get
		{
			Stack stackComponent = Components.StackComponent;
			if (stackComponent == null)
			{
				return 1;
			}
			return stackComponent.StackCount;
		}
	}

	public int MaxStackCount
	{
		get
		{
			Stack stackComponent = Components.StackComponent;
			if (!(stackComponent == null))
			{
				return stackComponent.MaxStackCount;
			}
			return 1;
		}
	}

	public bool IsStackable => Components.StackComponent != null;

	public int MaxCharges
	{
		get
		{
			if (!nullable_61.HasValue)
			{
				Charges chargesComponent = Components.ChargesComponent;
				if (!(chargesComponent == null))
				{
					nullable_61 = chargesComponent.GetMaxCharges(Components.LocalStatsComponent);
				}
				else
				{
					nullable_61 = 0;
				}
			}
			return nullable_61.Value;
		}
	}

	public double MaxChargesModifier
	{
		get
		{
			if (!nullable_60.HasValue)
			{
				Charges chargesComponent = Components.ChargesComponent;
				if (!(chargesComponent != null))
				{
					nullable_60 = 0.0;
				}
				else
				{
					nullable_60 = chargesComponent.MaxChargesModifier;
				}
			}
			return nullable_60.Value;
		}
	}

	public int MaxQuality
	{
		get
		{
			Quality qualityComponent = Components.QualityComponent;
			if (!(qualityComponent != null))
			{
				return 0;
			}
			return qualityComponent.MaxQuality;
		}
	}

	public int MinMonsterLevel
	{
		get
		{
			if (!nullable_48.HasValue)
			{
				nullable_48 = Math.Max(MinMonsterLevelPrefix, MinMonsterLevelSuffix);
			}
			return nullable_48.Value;
		}
	}

	public int MaxMonsterLevel
	{
		get
		{
			if (!nullable_45.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.LeaguestoneMaximumAreaLevel, out var value))
				{
					if (value == 0)
					{
						nullable_45 = 100;
					}
					else
					{
						nullable_45 = value;
					}
					return nullable_45.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null)
				{
					int stat = localStatsComponent.GetStat(StatTypeGGG.LeaguestoneMaximumAreaLevel);
					if (stat != 0)
					{
						nullable_45 = stat;
						return nullable_45.Value;
					}
				}
				nullable_45 = 100;
			}
			return nullable_45.Value;
		}
	}

	public int MinMonsterLevelPrefix
	{
		get
		{
			if (!nullable_46.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.LeaguestonePrefixMinimumAreaLevel, out var value))
				{
					nullable_46 = value;
					return nullable_46.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (!(localStatsComponent != null))
				{
					nullable_46 = 0;
				}
				else
				{
					nullable_46 = localStatsComponent.GetStat(StatTypeGGG.LeaguestonePrefixMinimumAreaLevel);
				}
			}
			return nullable_46.Value;
		}
	}

	public int MinMonsterLevelSuffix
	{
		get
		{
			if (!nullable_47.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.LeaguestoneSuffixMinimumAreaLevel, out var value))
				{
					nullable_47 = value;
					return nullable_47.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null)
				{
					nullable_47 = localStatsComponent.GetStat(StatTypeGGG.LeaguestoneSuffixMinimumAreaLevel);
				}
				else
				{
					nullable_47 = 0;
				}
			}
			return nullable_47.Value;
		}
	}

	public Dictionary<StatTypeGGG, int> LocalStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> result = new Dictionary<StatTypeGGG, int>();
			LocalStats localStatsComponent = Components.LocalStatsComponent;
			if (!(localStatsComponent != null))
			{
				return result;
			}
			return localStatsComponent.StatDictionary;
		}
	}

	public Positioned PositionedComp => Components.PositionedComponent;

	public bool IsHostile
	{
		get
		{
			if (PositionedComp == null)
			{
				return false;
			}
			return (PositionedComp.Reaction & 0x7F) != 1;
		}
	}

	public EntityComponentInformation Components
	{
		get
		{
			if (_components == null)
			{
				_components = new EntityComponentInformation(this);
			}
			return _components;
		}
	}

	public DatBaseItemTypeWrapper BaseItemType
	{
		get
		{
			if (nullable_BaseItemType == null)
			{
				nullable_BaseItemType = Dat.LookupBaseItemType(Metadata);
			}
			return nullable_BaseItemType;
		}
	}

	public bool FitsEquipRequirements
	{
		get
		{
			Dictionary<StatTypeGGG, int> stats = LokiPoe.ObjectManager.Me.Stats;
			stats.TryGetValue(StatTypeGGG.Strength, out var value);
			stats.TryGetValue(StatTypeGGG.Dexterity, out var value2);
			stats.TryGetValue(StatTypeGGG.Intelligence, out var value3);
			if (RequiredLevel <= LokiPoe.ObjectManager.Me.Level && RequiredStr <= value && RequiredDex <= value2)
			{
				return RequiredInt <= value3;
			}
			return false;
		}
	}

	public int RequiredStr
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevel, Components.SkillGemComponent.AttributeModifiersStr);
			}
			return CalcItemsStatRequirements(0);
		}
	}

	public int RequiredStrForNextLevel
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevelForNextLevel, Components.SkillGemComponent.AttributeModifiersStr);
			}
			return CalcItemsStatRequirements(0);
		}
	}

	public int RequiredDex
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevel, Components.SkillGemComponent.AttributeModifiersDex);
			}
			return CalcItemsStatRequirements(1);
		}
	}

	public int RequiredDexForNextLevel
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevelForNextLevel, Components.SkillGemComponent.AttributeModifiersDex);
			}
			return CalcItemsStatRequirements(1);
		}
	}

	public int RequiredInt
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevel, Components.SkillGemComponent.AttributeModifiersInt);
			}
			return CalcItemsStatRequirements(2);
		}
	}

	public int RequiredIntForNextLevel
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return CalcGemStatReq(Name, RequiredLevelForNextLevel, Components.SkillGemComponent.AttributeModifiersInt);
			}
			return CalcItemsStatRequirements(2);
		}
	}

	public string Class
	{
		get
		{
			if (BaseItemType == null)
			{
				return "";
			}
			return BaseItemType.ItemClass;
		}
	}

	public Rarity Rarity
	{
		get
		{
			if (HasMetadataFlags(MetadataFlags.QuestItems))
			{
				return Rarity.Quest;
			}
			if (!(Components.ModsComponent == null))
			{
				return Components.ModsComponent.Rarity;
			}
			if (Components.SkillGemComponent != null)
			{
				return Rarity.Gem;
			}
			if (!HasMetadataFlags(MetadataFlags.CurrencyItemisedProphecy))
			{
				if (HasMetadataFlags(default(MetadataFlags)))
				{
					return Rarity.Currency;
				}
				return Rarity.Normal;
			}
			return Rarity.Prophecy;
		}
	}

	public int Quality
	{
		get
		{
			Quality qualityComponent = Components.QualityComponent;
			if (!(qualityComponent != null))
			{
				return 0;
			}
			return qualityComponent.ItemQuality;
		}
	}

	public string AlternateQualityType
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.AlternateQualityType;
			}
			return "";
		}
	}

	public int AlternateQualityTypeValue
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.AlternateQualityTypeValue;
			}
			return 0;
		}
	}

	public int ItemLevel
	{
		get
		{
			if (Components.ModsComponent == null)
			{
				return 0;
			}
			return Components.ModsComponent.ItemLevel;
		}
	}

	public bool IsIdentified
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				return true;
			}
			return modsComponent.Identified;
		}
	}

	public Vector2i Size
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return new Vector2i(baseComponent.Size.X, baseComponent.Size.Y);
			}
			if (InventoryId != 0)
			{
				return LocationBottomRight - LocationTopLeft;
			}
			return Vector2i.Zero;
		}
	}

	public Skill Skill
	{
		get
		{
			if (Components.SkillGemComponent == null)
			{
				return null;
			}
			return LokiPoe.ObjectManager.Me.AvailableSkills.FirstOrDefault((Skill skill_0) => skill_0.SkillGem != null && skill_0.SkillGem.Address == base.Address);
		}
	}

	public int SkillGemLevel
	{
		get
		{
			if (!nullable_66.HasValue)
			{
				SkillGem skillGemComponent = Components.SkillGemComponent;
				if (!(skillGemComponent != null))
				{
					nullable_66 = 0;
				}
				else
				{
					nullable_66 = skillGemComponent.GemLevel;
				}
			}
			return nullable_66.Value;
		}
	}

	public GemQualityType SkillGemQualityType
	{
		get
		{
			if (!nullable_67.HasValue)
			{
				SkillGem skillGemComponent = Components.SkillGemComponent;
				if (skillGemComponent != null)
				{
					nullable_67 = skillGemComponent.GemQualityType;
				}
				else
				{
					nullable_67 = GemQualityType.Superior;
				}
			}
			return nullable_67.Value;
		}
	}

	public CompositeItemType CompositeType
	{
		get
		{
			if (compositeItemType_0 == null)
			{
				compositeItemType_0 = (CompositeItemType.dictionary_0.TryGetValue(Class, out compositeItemType_0) ? compositeItemType_0 : CompositeItemType.compositeItemType_0);
			}
			return compositeItemType_0;
		}
	}

	public HashSet<MetadataFlags> Flags
	{
		get
		{
			if (hashSet_0 == null && !BITC.dictionary_0.TryGetValue(Metadata, out hashSet_0))
			{
				hashSet_0 = new HashSet<MetadataFlags>();
			}
			return hashSet_0;
		}
	}

	public string SocketedDisplayString
	{
		get
		{
			if (string_4 == null)
			{
				if (!(Components.SocketsComponent == null))
				{
					string_4 = Components.SocketsComponent.DisplayString;
				}
				else
				{
					string_4 = "";
				}
			}
			return string_4;
		}
	}

	public SocketColor SocketColor
	{
		get
		{
			if (!nullable_65.HasValue)
			{
				SkillGem skillGemComponent = Components.SkillGemComponent;
				if (skillGemComponent != null)
				{
					nullable_65 = skillGemComponent.SocketColor;
				}
				else
				{
					nullable_65 = SocketColor.None;
				}
			}
			return nullable_65.Value;
		}
	}

	public SocketColor[] SocketColors
	{
		get
		{
			if (socketColor_0 == null)
			{
				Sockets socketsComponent = Components.SocketsComponent;
				if (!(socketsComponent == null))
				{
					socketColor_0 = socketsComponent.SocketColors;
				}
				else
				{
					socketColor_0 = new SocketColor[6];
				}
			}
			return socketColor_0;
		}
	}

	public List<SocketColor[]> LinkedSocketColors
	{
		get
		{
			if (list_1 == null)
			{
				list_1 = new List<SocketColor[]>();
				SocketColor[] socketColors = SocketColors;
				if (socketColors.All((SocketColor x) => x == SocketColor.None))
				{
					return list_1;
				}
				byte[] socketLinks = SocketLinks;
				int num = 0;
				byte[] array = socketLinks;
				foreach (byte b in array)
				{
					if (b != 0)
					{
						SocketColor[] array2 = new SocketColor[b];
						for (int j = 0; j < b; j++)
						{
							array2[j] = socketColors[num++];
						}
						list_1.Add(array2);
					}
				}
			}
			return list_1;
		}
	}

	public int SkillSocketIndex
	{
		get
		{
			if (!nullable_64.HasValue)
			{
				if (!(Skill != null))
				{
					nullable_64 = -1;
				}
				else
				{
					nullable_64 = Skill.SocketIndex;
				}
			}
			return nullable_64.Value;
		}
	}

	public string DisplayNote
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.DisplayNote;
			}
			return "";
		}
	}

	public int DroneCurrentCharges
	{
		get
		{
			SentinelDrone sentinelDroneComponent = Components.SentinelDroneComponent;
			if (!(sentinelDroneComponent != null))
			{
				return 0;
			}
			int chargesUsed = sentinelDroneComponent.ChargesUsed;
			return DroneMaxCharges - chargesUsed;
		}
	}

	public int DroneMaxCharges
	{
		get
		{
			SentinelDrone sentinelDroneComponent = Components.SentinelDroneComponent;
			if (!(sentinelDroneComponent != null))
			{
				return 0;
			}
			int num = sentinelDroneComponent.BaseCharges;
			if (Stats.TryGetValue(StatTypeGGG.LocalSentinelDroneChargePos, out var value))
			{
				num += value;
			}
			return num;
		}
	}

	public int SentinelDroneMaxDuration
	{
		get
		{
			SentinelDrone sentinelDroneComponent = Components.SentinelDroneComponent;
			if (sentinelDroneComponent != null)
			{
				int num = sentinelDroneComponent.BaseDuration;
				if (Stats.TryGetValue(StatTypeGGG.LocalSentinelDurationPos, out var value))
				{
					num += value;
				}
				if (Stats.TryGetValue(StatTypeGGG.LocalSentinelDroneDurationPosPct, out var value2))
				{
					int num2 = (int)Math.Round((double)num / 100.0 * (double)value2, 0);
					num += num2;
				}
				return num;
			}
			return 0;
		}
	}

	public int SentinelDroneEmpowerments
	{
		get
		{
			SentinelDrone sentinelDroneComponent = Components.SentinelDroneComponent;
			if (!(sentinelDroneComponent != null))
			{
				return 0;
			}
			int num = sentinelDroneComponent.BaseEmpowerments;
			if (Stats.TryGetValue(StatTypeGGG.LocalSentinelDroneDifficultyPos, out var value))
			{
				num += value;
			}
			if (Stats.TryGetValue(StatTypeGGG.LocalSentinelDroneDifficultyPosPct, out var value2))
			{
				int num2 = (int)Math.Round((double)num / 100.0 * (double)value2, 0);
				num += num2;
			}
			return num;
		}
	}

	public int SentinelDroneEmpowers
	{
		get
		{
			SentinelDrone sentinelDroneComponent = Components.SentinelDroneComponent;
			if (sentinelDroneComponent != null)
			{
				int num = sentinelDroneComponent.BaseEmpowers;
				if (Stats.TryGetValue(StatTypeGGG.LocalSentinelTagLimitPos, out var value))
				{
					num += value;
				}
				if (Stats.TryGetValue(StatTypeGGG.LocalSentinelTagLimitPosPct, out var value2))
				{
					int num2 = (int)Math.Round((double)num / 100.0 * (double)value2, 0);
					num += num2;
				}
				return num;
			}
			return 0;
		}
	}

	public bool IsMirrored
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.IsMirrored;
			}
			return false;
		}
	}

	public bool IsFractured
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				return false;
			}
			return modsComponent.IsFractured;
		}
	}

	public bool IsCorrupted
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (!(baseComponent != null))
			{
				return false;
			}
			return baseComponent.IsCorrupted;
		}
	}

	public bool IsVeiled => Affixes.Any((ModAffix x) => x.Category == "VeiledPrefix" || x.Category == "VeiledSuffix");

	public int MaxCurrencyTabStackCount
	{
		get
		{
			Stack stackComponent = Components.StackComponent;
			if (stackComponent == null)
			{
				return 0;
			}
			return stackComponent.MaxCurrencyTabStackCount;
		}
	}

	public bool HasFullStack => StackCount >= MaxStackCount;

	public Element UiElement => ReadObject<Element>(base.Address + 1512L);

	public string RenderArt
	{
		get
		{
			RenderItem renderItemComponent = Components.RenderItemComponent;
			if (renderItemComponent == null)
			{
				return "";
			}
			return renderItemComponent.ResourcePath;
		}
	}

	public bool HasSkillGemsEquipped
	{
		get
		{
			Sockets socketsComponent = Components.SocketsComponent;
			if (socketsComponent == null)
			{
				return false;
			}
			foreach (Sockets.SocketedGem socketedGem in socketsComponent.SocketedGems)
			{
				if (socketedGem != null)
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool HasMicrotransitionAttachment => false;

	public bool IsUsable
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				return true;
			}
			return modsComponent.IsUsable;
		}
	}

	public int BaseRequiredLevel
	{
		get
		{
			if (Components.ModsComponent == null)
			{
				return 0;
			}
			return Components.ModsComponent.BaseRequiredLevel;
		}
	}

	public int RequiredLevel
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return Components.SkillGemComponent.RequiredLevel;
			}
			return BaseRequiredLevel;
		}
	}

	public int RequiredLevelForNextLevel
	{
		get
		{
			if (Components.SkillGemComponent != null)
			{
				return Components.SkillGemComponent.RequiredLevelForNextLevel;
			}
			return BaseRequiredLevel;
		}
	}

	public bool IsChromatic => LokiPoe.MatchesSocketLayout(this, "R-G-B");

	public byte[] SocketLinks
	{
		get
		{
			if (byte_0 == null)
			{
				Sockets socketsComponent = Components.SocketsComponent;
				if (!(socketsComponent == null))
				{
					byte_0 = socketsComponent.SocketLinks;
				}
				else
				{
					byte_0 = new byte[6];
				}
			}
			return byte_0;
		}
	}

	public int SocketCount
	{
		get
		{
			int? num = 0;
			if (Components.SocketsComponent == null)
			{
				num = 0;
			}
			else
			{
				num = 0;
				SocketColor[] socketColors = SocketColors;
				for (int i = 0; i < 6; i++)
				{
					if (socketColors[i] != 0)
					{
						num++;
					}
				}
			}
			return num.Value;
		}
	}

	public Item[] SocketedGems
	{
		get
		{
			Sockets socketsComponent = Components.SocketsComponent;
			if (socketsComponent == null)
			{
				return new Item[0];
			}
			return socketsComponent.Gems.ToArray();
		}
	}

	public List<Item[]> SocketedSkillGemsByLinks
	{
		get
		{
			if (list_0 == null)
			{
				Sockets socketsComponent = Components.SocketsComponent;
				if (socketsComponent == null)
				{
					list_0 = new List<Item[]>();
				}
				else
				{
					list_0 = socketsComponent.SocketedSkillGemsByLinks;
				}
			}
			return list_0;
		}
	}

	public int MaxLinkCount
	{
		get
		{
			int? num = 0;
			if (!(Components.SocketsComponent == null))
			{
				num = 0;
				for (int i = 0; i < 6; i++)
				{
					byte b = SocketLinks[i];
					if (b > 0 && b > num)
					{
						num = b;
					}
				}
			}
			else
			{
				num = 0;
			}
			return num.Value;
		}
	}

	public int WorldItemId
	{
		get
		{
			if (!_worldItemId.HasValue)
			{
				DreamPoeBot.Loki.Components.WorldItem worldItemComponent = Components.WorldItemComponent;
				if (!(worldItemComponent == null))
				{
					_worldItemId = worldItemComponent.ItemEntity.Id;
				}
				else
				{
					_worldItemId = 0;
				}
			}
			return _worldItemId.Value;
		}
	}

	public bool IsShaperItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.IsShaperItem;
			}
			return false;
		}
	}

	public bool IsElderItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (!(baseComponent != null))
			{
				return false;
			}
			return baseComponent.IsElderItem;
		}
	}

	public bool IsHunterItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.IsHunterItem;
			}
			return false;
		}
	}

	public bool IsWarlordItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (!(baseComponent != null))
			{
				return false;
			}
			return baseComponent.IsWarlordItem;
		}
	}

	public bool IsCrusaderItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.IsCrusaderItem;
			}
			return false;
		}
	}

	public bool IsRedeemerItem
	{
		get
		{
			Base baseComponent = Components.BaseComponent;
			if (baseComponent != null)
			{
				return baseComponent.IsRedeemerItem;
			}
			return false;
		}
	}

	public bool IsRelic
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				return false;
			}
			return modsComponent.IsRelic;
		}
	}

	public Vector2i WorldItemPosition
	{
		get
		{
			Positioned positionedComponent = Components.PositionedComponent;
			if (positionedComponent == null)
			{
				return default(Vector2i);
			}
			return new Vector2i(positionedComponent.GridX, positionedComponent.GridY);
		}
	}

	public Dictionary<StatTypeGGG, int> Stats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				foreach (KeyValuePair<StatTypeGGG, int> mergedStat in modsComponent.MergedStats)
				{
					if (dictionary.ContainsKey(mergedStat.Key))
					{
						dictionary[mergedStat.Key] += mergedStat.Value;
					}
					else
					{
						dictionary.Add(mergedStat.Key, mergedStat.Value);
					}
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public Dictionary<StatTypeGGG, int> ImplicitStats
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.ImplicitStats;
			}
			return new Dictionary<StatTypeGGG, int>();
		}
	}

	public Dictionary<StatTypeGGG, int> ExplicitStats
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.ExplicitStats;
			}
			return new Dictionary<StatTypeGGG, int>();
		}
	}

	public int HighestImplicitValue
	{
		get
		{
			int num = 0;
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent == null)
			{
				return num;
			}
			foreach (ItemMod implicitMod in modsComponent.ImplicitMods)
			{
				if (implicitMod.Value1 > num)
				{
					num = implicitMod.Value1;
				}
				if (implicitMod.Value2 > num)
				{
					num = implicitMod.Value2;
				}
				if (implicitMod.Value3 > num)
				{
					num = implicitMod.Value3;
				}
				if (implicitMod.Value4 > num)
				{
					num = implicitMod.Value4;
				}
			}
			return num;
		}
	}

	public List<string> GemTypes
	{
		get
		{
			List<string> list = new List<string>();
			SkillGem skillGemComponent = Components.SkillGemComponent;
			if (!(skillGemComponent != null))
			{
				return new List<string>();
			}
			return skillGemComponent.GemTypes.ToList();
		}
	}

	public bool IsInstantRecovery
	{
		get
		{
			if (!nullable_54.HasValue)
			{
				Flask flaskComponent = Components.FlaskComponent;
				if (flaskComponent != null)
				{
					nullable_54 = flaskComponent.IsInstantRecovery;
				}
				else
				{
					nullable_54 = false;
				}
			}
			return nullable_54.Value;
		}
	}

	public TimeSpan RecoveryTime
	{
		get
		{
			if (!nullable_55.HasValue)
			{
				Flask flaskComponent = Components.FlaskComponent;
				if (flaskComponent != null)
				{
					nullable_55 = flaskComponent.RecoveryTime;
				}
				else
				{
					nullable_55 = new TimeSpan(0L);
				}
			}
			return nullable_55.Value;
		}
	}

	public bool CanUse
	{
		get
		{
			if (!nullable_56.HasValue)
			{
				nullable_56 = CurrentCharges >= ChargesPerUse;
			}
			return nullable_56.Value;
		}
	}

	public int CurrentCharges
	{
		get
		{
			if (!nullable_57.HasValue)
			{
				Charges chargesComponent = Components.ChargesComponent;
				if (!(chargesComponent == null))
				{
					nullable_57 = chargesComponent.CurrentCharges;
				}
				else
				{
					nullable_57 = 0;
				}
			}
			return nullable_57.Value;
		}
	}

	public int ChargesPerUse
	{
		get
		{
			if (!nullable_59.HasValue)
			{
				if (Components.ChargesComponent != null)
				{
					if (Stats.TryGetValue(StatTypeGGG.LocalChargesUsedPosPct, out var value))
					{
						int chargesPerUseBase = ChargesPerUseBase;
						nullable_59 = (int)((double)chargesPerUseBase + (double)(chargesPerUseBase * value) / 100.0);
					}
					else
					{
						nullable_59 = ChargesPerUseBase;
					}
				}
				else
				{
					nullable_59 = 0;
				}
			}
			return nullable_59.Value;
		}
	}

	public int ChargesPerUseBase
	{
		get
		{
			if (!nullable_58.HasValue)
			{
				Charges chargesComponent = Components.ChargesComponent;
				if (!(chargesComponent != null))
				{
					nullable_58 = 0;
				}
				else
				{
					nullable_58 = chargesComponent.ChargesPerUse;
				}
			}
			return nullable_58.Value;
		}
	}

	public int HealthRecover
	{
		get
		{
			if (!nullable_50.HasValue)
			{
				Flask flaskComponent = Components.FlaskComponent;
				if (flaskComponent != null)
				{
					nullable_50 = flaskComponent.LifeRecover;
				}
				else
				{
					nullable_50 = 0;
				}
			}
			return nullable_50.Value;
		}
	}

	public float HealthRecoveredPerSecond
	{
		get
		{
			if (!nullable_53.HasValue)
			{
				if (Components.FlaskComponent != null)
				{
					if (!IsInstantRecovery && !RecoveryTime.TotalSeconds.Equals(0.0))
					{
						nullable_53 = (float)HealthRecover / (float)RecoveryTime.TotalSeconds;
					}
					else
					{
						nullable_53 = HealthRecover;
					}
				}
				else
				{
					nullable_53 = 0f;
				}
			}
			return nullable_53.Value;
		}
	}

	public int ManaRecover
	{
		get
		{
			if (!nullable_51.HasValue)
			{
				Flask flaskComponent = Components.FlaskComponent;
				if (flaskComponent != null)
				{
					nullable_51 = flaskComponent.ManaRecover;
				}
				else
				{
					nullable_51 = 0;
				}
			}
			return nullable_51.Value;
		}
	}

	public float ManaRecoveredPerSecond
	{
		get
		{
			if (!nullable_52.HasValue)
			{
				if (Components.FlaskComponent != null)
				{
					if (!IsInstantRecovery && !RecoveryTime.TotalSeconds.Equals(0.0))
					{
						nullable_52 = (float)ManaRecover / (float)RecoveryTime.TotalSeconds;
					}
					else
					{
						nullable_52 = ManaRecover;
					}
				}
				else
				{
					nullable_52 = 0f;
				}
			}
			return nullable_52.Value;
		}
	}

	public List<ExpeditionWrapper> Expeditions
	{
		get
		{
			if (expeditions_0 == null)
			{
				ExpeditionSaga expeditionSagaComponent = Components.ExpeditionSagaComponent;
				if (expeditionSagaComponent == null)
				{
					expeditions_0 = new List<ExpeditionWrapper>();
				}
				else
				{
					expeditions_0 = expeditionSagaComponent.Expeditions.ToList();
				}
			}
			return expeditions_0;
		}
	}

	public DatWorldAreaWrapper MapArea
	{
		get
		{
			if (datWorldAreaWrapper_0 == null)
			{
				DreamPoeBot.Loki.Components.Map mapComponent = Components.MapComponent;
				if (!(mapComponent != null))
				{
					datWorldAreaWrapper_0 = null;
				}
				else
				{
					datWorldAreaWrapper_0 = mapComponent.Area;
				}
			}
			return datWorldAreaWrapper_0;
		}
	}

	public string MapRegion => "";

	public int MapItemQuantity
	{
		get
		{
			if (!nullable_17.HasValue)
			{
				nullable_17 = MapRawItemQuantity + Quality;
			}
			return nullable_17.Value;
		}
	}

	public int MapItemRarity
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				if (ExplicitStats.TryGetValue(StatTypeGGG.ModifiersToMapItemDropQuantityAlsoApplyToMapItemDropRarity, out var value) && value != 0)
				{
					nullable_16 = MapRawItemRarity + MapItemQuantity;
					return nullable_16.Value;
				}
				nullable_16 = MapRawItemRarity;
			}
			return nullable_16.Value;
		}
	}

	public int MapLevel
	{
		get
		{
			if (!nullable_11.HasValue)
			{
				nullable_11 = MapTier + 67;
			}
			return nullable_11.Value;
		}
	}

	public int MapMonsterPackSize
	{
		get
		{
			if (!nullable_18.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.MapPackSizePosPct, out var value))
				{
					nullable_18 = value;
					return nullable_18.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (!(localStatsComponent != null))
				{
					nullable_18 = 0;
				}
				else
				{
					nullable_18 = localStatsComponent.GetStat(StatTypeGGG.MapPackSizePosPct);
				}
			}
			return nullable_18.Value;
		}
	}

	public int MapRawItemQuantity
	{
		get
		{
			if (!nullable_14.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.MapItemDropQuantityPosPct, out var value))
				{
					nullable_14 = value;
					return nullable_14.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null)
				{
					nullable_14 = localStatsComponent.GetStat(StatTypeGGG.MapItemDropQuantityPosPct);
				}
				else
				{
					nullable_14 = 0;
				}
			}
			return nullable_14.Value;
		}
	}

	public int MapRawItemRarity
	{
		get
		{
			if (!nullable_15.HasValue)
			{
				Mods modsComponent = Components.ModsComponent;
				if (modsComponent != null && modsComponent.MergedStats.TryGetValue(StatTypeGGG.MapItemDropRarityPosPct, out var value))
				{
					nullable_15 = value;
					return nullable_15.Value;
				}
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null)
				{
					nullable_15 = localStatsComponent.GetStat(StatTypeGGG.MapItemDropRarityPosPct);
				}
				else
				{
					nullable_15 = 0;
				}
			}
			return nullable_15.Value;
		}
	}

	public InventoryTabMapSeries MapSeries
	{
		get
		{
			if (!nullable_13.HasValue)
			{
				DreamPoeBot.Loki.Components.Map mapComponent = Components.MapComponent;
				if (mapComponent != null)
				{
					nullable_13 = mapComponent.MapSeries;
				}
				else
				{
					nullable_13 = InventoryTabMapSeries.None;
				}
			}
			return nullable_13.Value;
		}
	}

	public int MapTier
	{
		get
		{
			if (!nullable_12.HasValue)
			{
				DreamPoeBot.Loki.Components.Map mapComponent = Components.MapComponent;
				if (!(mapComponent != null))
				{
					nullable_12 = 0;
				}
				else
				{
					nullable_12 = mapComponent.MapTier;
					if (Boolean_1)
					{
						nullable_12 += 5;
					}
					if (Boolean_0)
					{
						nullable_12 = 16;
					}
				}
			}
			return nullable_12.Value;
		}
	}

	public IEnumerable<ModAffix> ExplicitAffixes
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				yield break;
			}
			foreach (ModAffix explicitAffix in modsComponent.ExplicitAffixes)
			{
				yield return explicitAffix;
			}
		}
	}

	public IEnumerable<ModAffix> ImplicitAffixes
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				yield break;
			}
			foreach (ModAffix implicitAffix in modsComponent.ImplicitAffixes)
			{
				yield return implicitAffix;
			}
		}
	}

	public bool HasIncubator
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (modsComponent != null)
			{
				return modsComponent.HasIncubator;
			}
			return false;
		}
	}

	public IEnumerable<ModAffix> Affixes
	{
		get
		{
			Mods modsComponent = Components.ModsComponent;
			if (!(modsComponent != null))
			{
				yield break;
			}
			foreach (ModAffix affix in modsComponent.Affixes)
			{
				yield return affix;
			}
		}
	}

	public InventoryType ItemType
	{
		get
		{
			if (Components.ModsComponent == null)
			{
				return InventoryType.Main;
			}
			return Components.ModsComponent.ItemType;
		}
	}

	public int BaseMinPhysicalDamage
	{
		get
		{
			if (!nullable_37.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (weaponComponent != null)
				{
					nullable_37 = weaponComponent.BaseMinPhysicalDamage;
				}
				else
				{
					nullable_37 = 0;
				}
			}
			return nullable_37.Value;
		}
	}

	public int BaseMaxPhysicalDamage
	{
		get
		{
			if (!nullable_39.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (weaponComponent != null)
				{
					nullable_39 = weaponComponent.BaseMaxPhysicalDamage;
				}
				else
				{
					nullable_39 = 0;
				}
			}
			return nullable_39.Value;
		}
	}

	public int MinPhysicalDamage
	{
		get
		{
			if (!nullable_38.HasValue)
			{
				if (Components.WeaponComponent == null)
				{
					nullable_38 = 0;
				}
				else
				{
					int num = BaseMinPhysicalDamage;
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalMinimumAddedPhysicalDamage))
					{
						num += localStats[StatTypeGGG.LocalMinimumAddedPhysicalDamage];
					}
					int num2 = Quality;
					if (localStats.ContainsKey(StatTypeGGG.LocalPhysicalDamagePosPct))
					{
						num2 += localStats[StatTypeGGG.LocalPhysicalDamagePosPct];
					}
					num = (int)Math.Round((double)num * (1.0 + (double)num2 / 100.0), 0);
					nullable_38 = num;
				}
			}
			return nullable_38.Value;
		}
	}

	public int MaxPhysicalDamage
	{
		get
		{
			if (!nullable_40.HasValue)
			{
				if (Components.WeaponComponent == null)
				{
					nullable_40 = 0;
				}
				else
				{
					int num = BaseMaxPhysicalDamage;
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalMaximumAddedPhysicalDamage))
					{
						num += localStats[StatTypeGGG.LocalMaximumAddedPhysicalDamage];
					}
					int num2 = Quality;
					if (localStats.ContainsKey(StatTypeGGG.LocalPhysicalDamagePosPct))
					{
						num2 += localStats[StatTypeGGG.LocalPhysicalDamagePosPct];
					}
					num = (int)Math.Round((double)num * (1.0 + (double)num2 / 100.0), 0);
					nullable_40 = num;
				}
			}
			return nullable_40.Value;
		}
	}

	public double BaseAttacksPerSecond
	{
		get
		{
			if (!nullable_41.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (!(weaponComponent != null))
				{
					nullable_41 = 0.0;
				}
				else
				{
					nullable_41 = Math.Round(weaponComponent.BaseAttacksPerSecond, 2);
				}
			}
			return nullable_41.Value;
		}
	}

	public double AttacksPerSecond
	{
		get
		{
			if (!nullable_42.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (weaponComponent == null)
				{
					nullable_42 = 0.0;
				}
				else
				{
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalAttackSpeedPosPct))
					{
						double baseAttacksPerSecond = weaponComponent.BaseAttacksPerSecond;
						double num = 1.0 + (double)localStats[StatTypeGGG.LocalAttackSpeedPosPct] / 100.0;
						nullable_42 = Math.Round(baseAttacksPerSecond * num, 2);
					}
					else
					{
						nullable_42 = BaseAttacksPerSecond;
					}
				}
			}
			return nullable_42.Value;
		}
	}

	public int MinDamage
	{
		get
		{
			if (!nullable_25.HasValue)
			{
				nullable_25 = MinChaosDamage + MinLightningDamage + MinColdDamage + MinFireDamage + MinPhysicalDamage;
			}
			return nullable_25.Value;
		}
	}

	public int MaxDamage
	{
		get
		{
			if (!nullable_26.HasValue)
			{
				nullable_26 = MaxChaosDamage + MaxLightningDamage + MaxColdDamage + MaxFireDamage + MaxPhysicalDamage;
			}
			return nullable_26.Value;
		}
	}

	public int MinDps
	{
		get
		{
			if (!nullable_23.HasValue)
			{
				nullable_23 = (int)Math.Round((double)MinDamage * AttacksPerSecond, 0);
			}
			return nullable_23.Value;
		}
	}

	public int MaxDps
	{
		get
		{
			if (!nullable_24.HasValue)
			{
				nullable_24 = (int)Math.Round((double)MaxDamage * AttacksPerSecond, 0);
			}
			return nullable_24.Value;
		}
	}

	public int MinChaosDamage
	{
		get
		{
			if (!nullable_29.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (localStats.ContainsKey(StatTypeGGG.LocalMinimumAddedChaosDamage))
				{
					nullable_29 = localStats[StatTypeGGG.LocalMinimumAddedChaosDamage];
				}
				else
				{
					nullable_29 = 0;
				}
			}
			return nullable_29.Value;
		}
	}

	public int MaxChaosDamage
	{
		get
		{
			if (!nullable_30.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (!localStats.ContainsKey(StatTypeGGG.LocalMaximumAddedChaosDamage))
				{
					nullable_30 = 0;
				}
				else
				{
					nullable_30 = localStats[StatTypeGGG.LocalMaximumAddedChaosDamage];
				}
			}
			return nullable_30.Value;
		}
	}

	public int MinFireDamage
	{
		get
		{
			if (!nullable_35.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (localStats.ContainsKey(StatTypeGGG.LocalMinimumAddedFireDamage))
				{
					nullable_35 = localStats[StatTypeGGG.LocalMinimumAddedFireDamage];
				}
				else
				{
					nullable_35 = 0;
				}
			}
			return nullable_35.Value;
		}
	}

	public int MaxFireDamage
	{
		get
		{
			if (!nullable_36.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (localStats.ContainsKey(StatTypeGGG.LocalMaximumAddedFireDamage))
				{
					nullable_36 = localStats[StatTypeGGG.LocalMaximumAddedFireDamage];
				}
				else
				{
					nullable_36 = 0;
				}
			}
			return nullable_36.Value;
		}
	}

	public int MinLightningDamage
	{
		get
		{
			if (!nullable_31.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (!localStats.ContainsKey(StatTypeGGG.LocalMinimumAddedLightningDamage))
				{
					nullable_31 = 0;
				}
				else
				{
					nullable_31 = localStats[StatTypeGGG.LocalMinimumAddedLightningDamage];
				}
			}
			return nullable_31.Value;
		}
	}

	public int MaxLightningDamage
	{
		get
		{
			if (!nullable_32.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (localStats.ContainsKey(StatTypeGGG.LocalMaximumAddedLightningDamage))
				{
					nullable_32 = localStats[StatTypeGGG.LocalMaximumAddedLightningDamage];
				}
				else
				{
					nullable_32 = 0;
				}
			}
			return nullable_32.Value;
		}
	}

	public int MinColdDamage
	{
		get
		{
			if (!nullable_33.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (!localStats.ContainsKey(StatTypeGGG.LocalMinimumAddedColdDamage))
				{
					nullable_33 = 0;
				}
				else
				{
					nullable_33 = localStats[StatTypeGGG.LocalMinimumAddedColdDamage];
				}
			}
			return nullable_33.Value;
		}
	}

	public int MaxColdDamage
	{
		get
		{
			if (!nullable_34.HasValue)
			{
				Dictionary<StatTypeGGG, int> localStats = LocalStats;
				if (localStats.ContainsKey(StatTypeGGG.LocalMaximumAddedColdDamage))
				{
					nullable_34 = localStats[StatTypeGGG.LocalMaximumAddedColdDamage];
				}
				else
				{
					nullable_34 = 0;
				}
			}
			return nullable_34.Value;
		}
	}

	public int MinElementalDamage
	{
		get
		{
			if (!nullable_27.HasValue)
			{
				nullable_27 = MinLightningDamage + MinColdDamage + MinFireDamage;
			}
			return nullable_27.Value;
		}
	}

	public int MaxElementalDamage
	{
		get
		{
			if (!nullable_28.HasValue)
			{
				nullable_28 = MaxLightningDamage + MaxColdDamage + MaxFireDamage;
			}
			return nullable_28.Value;
		}
	}

	public double BaseCritialStrikeChance
	{
		get
		{
			if (!nullable_43.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (weaponComponent != null)
				{
					nullable_43 = Math.Round(weaponComponent.BaseCritialStrikeChance, 2);
				}
				else
				{
					nullable_43 = 0.0;
				}
			}
			return nullable_43.Value;
		}
	}

	public double CritialStrikeChance
	{
		get
		{
			if (!nullable_44.HasValue)
			{
				Weapon weaponComponent = Components.WeaponComponent;
				if (!(weaponComponent == null))
				{
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (!localStats.ContainsKey(StatTypeGGG.LocalCriticalStrikeChancePosPct))
					{
						nullable_44 = BaseCritialStrikeChance;
					}
					else
					{
						int baseCritialStrikeChanceRaw = weaponComponent.BaseCritialStrikeChanceRaw;
						double num = 1.0 + (double)localStats[StatTypeGGG.LocalCriticalStrikeChancePosPct] / 100.0;
						nullable_44 = Math.Round((double)baseCritialStrikeChanceRaw * num / 100.0, 2);
					}
				}
				else
				{
					nullable_44 = 0.0;
				}
			}
			return nullable_44.Value;
		}
	}

	public int BaseArmor
	{
		get
		{
			if (!nullable_4.HasValue)
			{
				Armour armourComponent = Components.ArmourComponent;
				if (!(armourComponent != null))
				{
					nullable_4 = 0;
				}
				else
				{
					nullable_4 = armourComponent.BaseArmor;
				}
			}
			return nullable_4.Value;
		}
	}

	public int ArmorValue
	{
		get
		{
			if (!nullable_5.HasValue)
			{
				if (Components.ArmourComponent == null)
				{
					nullable_5 = 0;
				}
				else
				{
					int num = BaseArmor;
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalBasePhysicalDamageReductionRating))
					{
						num += localStats[StatTypeGGG.LocalBasePhysicalDamageReductionRating];
					}
					int num2 = 0;
					if (localStats.ContainsKey(StatTypeGGG.LocalPhysicalDamageReductionRatingPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalPhysicalDamageReductionRatingPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEnergyShieldPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalArmourAndEnergyShieldPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEvasionPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalArmourAndEvasionPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct];
					}
					num2 += Quality;
					double num3 = (double)num2 / 100.0 + 1.0;
					num = (int)Math.Floor((double)num * num3 + 0.5);
					nullable_5 = num;
				}
			}
			return nullable_5.Value;
		}
	}

	public int BaseEnergyShield
	{
		get
		{
			if (!nullable_6.HasValue)
			{
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null && localStatsComponent.GetStat(StatTypeGGG.LocalUniqueTabulaRasaNoRequirementOrEnergyShield) != 0)
				{
					nullable_6 = 0;
					return nullable_6.Value;
				}
				Armour armourComponent = Components.ArmourComponent;
				if (!(armourComponent != null))
				{
					nullable_6 = 0;
				}
				else
				{
					nullable_6 = armourComponent.BaseEnergyShield;
				}
			}
			return nullable_6.Value;
		}
	}

	public int EnergyShieldValue
	{
		get
		{
			if (!nullable_7.HasValue)
			{
				LocalStats localStatsComponent = Components.LocalStatsComponent;
				if (localStatsComponent != null && localStatsComponent.GetStat(StatTypeGGG.LocalUniqueTabulaRasaNoRequirementOrEnergyShield) != 0)
				{
					nullable_7 = 0;
					return nullable_7.Value;
				}
				if (!(Components.ArmourComponent == null))
				{
					int num = BaseEnergyShield;
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalEnergyShield))
					{
						num += localStats[StatTypeGGG.LocalEnergyShield];
					}
					int num2 = 0;
					if (localStats.ContainsKey(StatTypeGGG.LocalEnergyShieldPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalEnergyShieldPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEnergyShieldPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalArmourAndEnergyShieldPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalEvasionAndEnergyShieldPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalEvasionAndEnergyShieldPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct))
					{
						num2 += localStats[StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct];
					}
					num2 += Quality;
					double num3 = (double)num2 / 100.0 + 1.0;
					num = (int)Math.Floor((double)num * num3 + 0.5);
					nullable_7 = num;
				}
				else
				{
					nullable_7 = 0;
				}
			}
			return nullable_7.Value;
		}
	}

	public int BaseEvasion
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				Armour armourComponent = Components.ArmourComponent;
				if (armourComponent != null)
				{
					nullable_2 = armourComponent.BaseEvasion;
				}
				else
				{
					nullable_2 = 0;
				}
			}
			return nullable_2.Value;
		}
	}

	public int EvasionValue
	{
		get
		{
			if (!nullable_3.HasValue)
			{
				if (!(Components.ArmourComponent == null))
				{
					int num = BaseEvasion;
					Dictionary<StatTypeGGG, int> localStats = LocalStats;
					if (localStats.ContainsKey(StatTypeGGG.LocalBaseEvasionRating))
					{
						num += localStats[StatTypeGGG.LocalBaseEvasionRating];
					}
					int num2 = 0;
					if (localStats.ContainsKey(StatTypeGGG.LocalEvasionRatingPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalEvasionRatingPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEvasionPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalArmourAndEvasionPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalEvasionAndEnergyShieldPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalEvasionAndEnergyShieldPosPct];
					}
					if (localStats.ContainsKey(StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct))
					{
						num2 = localStats[StatTypeGGG.LocalArmourAndEvasionAndEnergyShieldPosPct];
					}
					num2 += Quality;
					double num3 = (double)num2 / 100.0 + 1.0;
					num = (int)Math.Floor((double)num * num3 + 0.5);
					nullable_3 = num;
				}
				else
				{
					nullable_3 = 0;
				}
			}
			return nullable_3.Value;
		}
	}

	public Item()
	{
	}

	public Item(long address, int localId)
		: base(address)
	{
		_localId = localId;
	}

	public Item(long address, int localId, int worldItemId)
		: base(address)
	{
		_localId = localId;
		_worldItemId = worldItemId;
	}

	public Item(long address, bool hasInventoryLocation, Vector2i locationBottomRight, Vector2i locationTopLeft)
		: base(address)
	{
		_localId = base.M.ReadInt(address + 2920L);
		HasInventoryLocation = hasInventoryLocation;
		LocationBottomRight = locationBottomRight;
		LocationTopLeft = locationTopLeft;
	}

	public Item(long address, bool hasInventoryLocation, Vector2i locationBottomRight, Vector2i locationTopLeft, int id)
		: base(address)
	{
		_localId = id;
		HasInventoryLocation = hasInventoryLocation;
		LocationBottomRight = locationBottomRight;
		LocationTopLeft = locationTopLeft;
	}

	internal Item(Class247 ii)
		: base(ii.Struct123_0.intptr_0)
	{
		_localId = ii.LocalId;
		HasInventoryLocation = true;
		LocationTopLeft = ii.LocationTopLeft;
		LocationBottomRight = ii.LocationBottomRight;
	}

	public Item(Item item, bool hasInventoryLocation, Vector2i locationBottomRight, Vector2i locationTopLeft)
		: base(item.Address)
	{
		HasInventoryLocation = hasInventoryLocation;
		LocationBottomRight = locationBottomRight;
		LocationTopLeft = locationTopLeft;
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"BaseAddress: 0x{base.Address:X}");
		stringBuilder.AppendLine($"LocalId: {LocalId}");
		stringBuilder.AppendLine($"Name: {Name}");
		stringBuilder.AppendLine($"FullName: {FullName}");
		stringBuilder.AppendLine($"Metadata: {Metadata}");
		stringBuilder.AppendLine($"Class: {Class}");
		stringBuilder.AppendLine($"Size: {Size}");
		stringBuilder.AppendLine($"Rarity: {Rarity}");
		stringBuilder.AppendLine($"ItemLevel: {ItemLevel}");
		stringBuilder.AppendLine($"ItemType: {ItemType}");
		stringBuilder.AppendLine($"RenderArt: {RenderArt}");
		stringBuilder.AppendLine($"IsRelic: {IsRelic}");
		stringBuilder.AppendLine($"IsIdentified: {IsIdentified}");
		stringBuilder.AppendLine($"IsCorrupted: {IsCorrupted}");
		stringBuilder.AppendLine($"IsVeiled: {IsVeiled}");
		stringBuilder.AppendLine($"IsShaper: {IsShaperItem}");
		stringBuilder.AppendLine($"IsElder: {IsElderItem}");
		stringBuilder.AppendLine($"IsHunter: {IsHunterItem}");
		stringBuilder.AppendLine($"IsWarlord: {IsWarlordItem}");
		stringBuilder.AppendLine($"IsRedeemer: {IsRedeemerItem}");
		stringBuilder.AppendLine($"IsCrusader: {IsCrusaderItem}");
		stringBuilder.AppendLine($"IsMirrored: {IsMirrored}");
		stringBuilder.AppendLine($"IsFractured: {IsFractured}");
		stringBuilder.AppendLine($"HasIncubator: {HasIncubator}");
		stringBuilder.AppendLine($"AbsorbedCorruption: {AbsorbedCorruption}");
		stringBuilder.AppendLine($"ScourgedTier: {ScourgedTier}");
		stringBuilder.AppendLine($"Quality: {Quality}");
		stringBuilder.AppendLine($"MaxQuality: {MaxQuality}");
		stringBuilder.AppendLine($"AlternateQualityType: {AlternateQualityType}");
		stringBuilder.AppendLine($"AlternateQualityTypeValue: {AlternateQualityTypeValue}");
		stringBuilder.AppendLine($"DisplayNote: {DisplayNote}");
		stringBuilder.AppendLine($"\tWorldItemId: {WorldItemId}");
		stringBuilder.AppendLine($"\tWorldItemPosition: {WorldItemPosition}");
		stringBuilder.AppendLine($"HasInventoryLocation: {HasInventoryLocation}");
		stringBuilder.AppendLine($"\tLocationTopLeft: {LocationTopLeft}");
		stringBuilder.AppendLine($"\tLocationBottomRight: {LocationBottomRight}");
		stringBuilder.AppendLine($"FitsEquipRequirements: {FitsEquipRequirements}");
		stringBuilder.AppendLine($"IsUsable: {IsUsable}");
		stringBuilder.AppendLine($"RequiredStr: {RequiredStr}, NextLevel: {RequiredStrForNextLevel}");
		stringBuilder.AppendLine($"RequiredDex: {RequiredDex}, NextLevel: {RequiredDexForNextLevel}");
		stringBuilder.AppendLine($"RequiredInt: {RequiredInt}, NextLevel: {RequiredIntForNextLevel}");
		stringBuilder.AppendLine($"BaseRequiredLevel: {BaseRequiredLevel}");
		stringBuilder.AppendLine($"RequiredLevel: {RequiredLevel}, NextLevel: {RequiredLevelForNextLevel}");
		stringBuilder.AppendLine($"SentinelDroneMaxDuration: {SentinelDroneMaxDuration}");
		stringBuilder.AppendLine($"SentinelDroneEmpowers: {SentinelDroneEmpowers} Enemies");
		stringBuilder.AppendLine($"SentinelDroneEmpowerments: {SentinelDroneEmpowerments}");
		stringBuilder.AppendLine($"DroneCharges: [Current/Max]{DroneCurrentCharges}/{DroneMaxCharges}");
		stringBuilder.AppendLine($"[Affixes]");
		foreach (ModAffix affix in Affixes)
		{
			stringBuilder.AppendLine($"\t{affix}");
		}
		stringBuilder.AppendLine($"[ExplicitAffixes]");
		foreach (ModAffix explicitAffix in ExplicitAffixes)
		{
			stringBuilder.AppendLine($"\t{explicitAffix}");
		}
		stringBuilder.AppendLine($"[ImplicitAffixes]");
		foreach (ModAffix implicitAffix in ImplicitAffixes)
		{
			stringBuilder.AppendLine($"\t{implicitAffix}");
		}
		stringBuilder.AppendLine($"[ImplicitStats]");
		foreach (KeyValuePair<StatTypeGGG, int> implicitStat in ImplicitStats)
		{
			stringBuilder.AppendLine($"\t{implicitStat}");
		}
		stringBuilder.AppendLine($"[ExplicitStats]");
		foreach (KeyValuePair<StatTypeGGG, int> explicitStat in ExplicitStats)
		{
			stringBuilder.AppendLine($"\t{explicitStat}");
		}
		stringBuilder.AppendLine($"[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> keyValuePair3 in Stats)
		{
			DatStatWrapper datStatWrapper = Dat.Stats.FirstOrDefault((DatStatWrapper x) => x.ApiId == keyValuePair3.Key.ToString());
			stringBuilder.AppendLine((datStatWrapper != null) ? $"\t{keyValuePair3} ({datStatWrapper.Description})" : $"\t{keyValuePair3} (No_Description)");
		}
		stringBuilder.AppendLine($"[LocalStats]");
		foreach (KeyValuePair<StatTypeGGG, int> localStat in LocalStats)
		{
			stringBuilder.AppendLine($"\t{localStat}");
		}
		stringBuilder.AppendLine($"IsStackable: {IsStackable}");
		stringBuilder.AppendLine($"HasFullStack: {HasFullStack}");
		stringBuilder.AppendLine($"StackCount: {StackCount}");
		stringBuilder.AppendLine($"MaxStackCount: {MaxStackCount}");
		stringBuilder.AppendLine($"MaxCurrencyTabStackCount: {MaxCurrencyTabStackCount}");
		stringBuilder.AppendLine($"HasMicrotransitionAttachment: {HasMicrotransitionAttachment}");
		stringBuilder.AppendLine(string.Format("Tags: {0}", string.Join(" | ", Tags)));
		stringBuilder.AppendLine($"[Components.ArmorComponent]: {Components.ArmourComponent != null}");
		stringBuilder.AppendLine($"\tBaseEvasion: {BaseEvasion}");
		stringBuilder.AppendLine($"\tEvasionValue: {EvasionValue}");
		stringBuilder.AppendLine($"\tBaseArmor: {BaseArmor}");
		stringBuilder.AppendLine($"\tArmorValue: {ArmorValue}");
		stringBuilder.AppendLine($"\tBaseEnergyShield: {BaseEnergyShield}");
		stringBuilder.AppendLine($"\tEnergyShieldValue: {EnergyShieldValue}");
		stringBuilder.AppendLine($"[Components.SocketsComponent]: {Components.SocketsComponent != null}");
		stringBuilder.AppendLine($"\tHasSkillGemsEquipped: {HasSkillGemsEquipped}");
		stringBuilder.AppendLine($"\tSocketedDisplayString: {SocketedDisplayString}");
		stringBuilder.AppendLine($"[SocketedGems]");
		Item[] socketedGems = SocketedGems;
		foreach (Item item in socketedGems)
		{
			if (item != null)
			{
				stringBuilder.AppendLine($"\t{item.FullName}");
			}
		}
		stringBuilder.AppendLine($"[SocketLinks]");
		byte[] socketLinks = SocketLinks;
		foreach (byte b in socketLinks)
		{
			stringBuilder.AppendLine($"\t{b}");
		}
		stringBuilder.AppendLine($"[SocketColors]");
		SocketColor[] socketColors = SocketColors;
		foreach (SocketColor socketColor in socketColors)
		{
			stringBuilder.AppendLine($"\t{socketColor}");
		}
		stringBuilder.AppendLine($"\tSocketCount: {SocketCount}");
		stringBuilder.AppendLine($"[SocketedSkillGemsByLinks]");
		foreach (Item[] socketedSkillGemsByLink in SocketedSkillGemsByLinks)
		{
			stringBuilder.AppendLine(string.Format("\t{0}", string.Join("-", socketedSkillGemsByLink.Select((Item x) => (!(x == null)) ? x.FullName : "<empty>"))));
		}
		stringBuilder.AppendLine($"[LinkedSocketColors]");
		foreach (SocketColor[] linkedSocketColor in LinkedSocketColors)
		{
			stringBuilder.AppendLine(string.Format("\t{0}", string.Join("-", linkedSocketColor)));
		}
		stringBuilder.AppendLine($"\tIsChromatic: {IsChromatic}");
		stringBuilder.AppendLine($"\tMaxLinkCount: {MaxLinkCount}");
		stringBuilder.AppendLine($"[Components.MapComponent]: {Components.MapComponent != null}");
		stringBuilder.AppendLine(string.Format("\tMapArea: {0}", (MapArea != null) ? MapArea.Name : "Null"));
		stringBuilder.AppendLine(string.Format("\tMapRegion: {0}", (MapRegion != null) ? MapRegion : "Null"));
		stringBuilder.AppendLine($"\tMapLevel: {MapLevel}");
		stringBuilder.AppendLine($"\tMapSeries: {MapSeries}");
		stringBuilder.AppendLine($"\tMapTier: {MapTier}");
		stringBuilder.AppendLine($"\tMapRawItemQuantity: {MapRawItemQuantity}");
		stringBuilder.AppendLine($"\tMapRawItemRarity: {MapRawItemRarity}");
		stringBuilder.AppendLine($"\tMapItemRarity: {MapItemRarity}");
		stringBuilder.AppendLine($"\tMapItemQuantity: {MapItemQuantity}");
		stringBuilder.AppendLine($"\tMapMonsterPackSize: {MapMonsterPackSize}");
		stringBuilder.AppendLine($"[Components.ExpeditionSagaComponent]: {Components.ExpeditionSagaComponent != null}");
		foreach (ExpeditionWrapper expedition in Expeditions)
		{
			if (expedition == null)
			{
				continue;
			}
			stringBuilder.AppendLine($"\tExpedition:");
			stringBuilder.AppendLine($"\t\tAreaName: {expedition.WorldArea.Name}");
			stringBuilder.AppendLine($"\t\tFaction: {expedition.ExpeditionFaction}");
			stringBuilder.AppendLine($"\t\tAreaSpecificModsString:");
			foreach (string item2 in expedition.ExpeditionAreaSpecificModsString)
			{
				stringBuilder.AppendLine($"\t\t\t{item2}");
			}
			stringBuilder.AppendLine($"\t\tAreaSpecificModsStringExtended:");
			foreach (string item3 in expedition.ExpeditionAreaSpecificModsStringExtended)
			{
				stringBuilder.AppendLine($"\t\t\t{item3}");
			}
			stringBuilder.AppendLine($"\t\tGenericMods:");
			foreach (ModAffix expeditionMod in expedition.ExpeditionMods)
			{
				stringBuilder.AppendLine($"\t\t\t{expeditionMod}");
			}
		}
		stringBuilder.AppendLine($"[Components.ShieldComponent]: {Components.ShieldComponent != null}");
		stringBuilder.AppendLine($"[Components.ProphecyComponent]: {Components.ProphecyComponent != null}");
		stringBuilder.AppendLine($"[Components.WeaponComponent]: {Components.WeaponComponent != null}");
		stringBuilder.AppendLine($"\tBaseWeaponType: {BaseWeaponType}");
		stringBuilder.AppendLine($"\tMinDps: {MinDps}");
		stringBuilder.AppendLine($"\tMaxDps: {MaxDps}");
		stringBuilder.AppendLine($"\tMinDamage: {MinDamage}");
		stringBuilder.AppendLine($"\tMaxDamage: {MaxDamage}");
		stringBuilder.AppendLine($"\tMinElementalDamage: {MinElementalDamage}");
		stringBuilder.AppendLine($"\tMaxElementalDamage: {MaxElementalDamage}");
		stringBuilder.AppendLine($"\tMinChaosDamage: {MinChaosDamage}");
		stringBuilder.AppendLine($"\tMaxChaosDamage: {MaxChaosDamage}");
		stringBuilder.AppendLine($"\tMinLightningDamage: {MinLightningDamage}");
		stringBuilder.AppendLine($"\tMaxLightningDamage: {MaxLightningDamage}");
		stringBuilder.AppendLine($"\tMinColdDamage: {MinColdDamage}");
		stringBuilder.AppendLine($"\tMaxColdDamage: {MaxColdDamage}");
		stringBuilder.AppendLine($"\tMinFireDamage: {MinFireDamage}");
		stringBuilder.AppendLine($"\tMaxFireDamage: {MaxFireDamage}");
		stringBuilder.AppendLine($"\tBaseMinPhysicalDamage: {BaseMinPhysicalDamage}");
		stringBuilder.AppendLine($"\tMinPhysicalDamage: {MinPhysicalDamage}");
		stringBuilder.AppendLine($"\tBaseMaxPhysicalDamage: {BaseMaxPhysicalDamage}");
		stringBuilder.AppendLine($"\tMaxPhysicalDamage: {MaxPhysicalDamage}");
		stringBuilder.AppendLine($"\tBaseAttacksPerSecond: {BaseAttacksPerSecond}");
		stringBuilder.AppendLine($"\tAttacksPerSecond: {AttacksPerSecond}");
		stringBuilder.AppendLine($"\tBaseCritialStrikeChance: {BaseCritialStrikeChance}");
		stringBuilder.AppendLine($"\tCritialStrikeChance: {CritialStrikeChance}");
		stringBuilder.AppendLine($"[MetadataFlags.Leaguestones] {HasMetadataFlags(MetadataFlags.Leaguestones)}");
		stringBuilder.AppendLine($"\tMaxMonsterLevel: {MaxMonsterLevel}");
		stringBuilder.AppendLine($"\tMinMonsterLevelPrefix: {MinMonsterLevelPrefix}");
		stringBuilder.AppendLine($"\tMinMonsterLevelSuffix: {MinMonsterLevelSuffix}");
		stringBuilder.AppendLine($"\tMinMonsterLevel: {MinMonsterLevel}");
		stringBuilder.AppendLine($"\tAppliesToCurrentAreaByLevel: {AppliesToCurrentAreaByLevel}");
		stringBuilder.AppendLine($"[Components.FlaskComponent]: {Components.FlaskComponent != null}");
		stringBuilder.AppendLine($"\tHealthRecover: {HealthRecover}");
		stringBuilder.AppendLine($"\tManaRecover: {ManaRecover}");
		stringBuilder.AppendLine($"\tManaRecoveredPerSecond: {ManaRecoveredPerSecond}");
		stringBuilder.AppendLine($"\tHealthRecoveredPerSecond: {HealthRecoveredPerSecond}");
		stringBuilder.AppendLine($"\tIsInstantRecovery: {IsInstantRecovery}");
		stringBuilder.AppendLine($"\tRecoveryTime: {RecoveryTime}");
		stringBuilder.AppendLine($"[Components.ChargesComponent]: {Components.ChargesComponent != null}");
		stringBuilder.AppendLine($"\tCanUse: {CanUse}");
		stringBuilder.AppendLine($"\tCurrentCharges: {CurrentCharges}");
		stringBuilder.AppendLine($"\tChargesPerUseBase: {ChargesPerUseBase}");
		stringBuilder.AppendLine($"\tChargesPerUse: {ChargesPerUse}");
		stringBuilder.AppendLine($"\tMaxChargesModifier: {MaxChargesModifier}");
		stringBuilder.AppendLine($"\tMaxCharges: {MaxCharges}");
		if (Components.ArchnemesisModComponent != null)
		{
			stringBuilder.AppendLine($"[Components.ArchnemesisModComponent]");
			stringBuilder.AppendLine($"\tRewards:");
			foreach (string reward in Components.ArchnemesisModComponent.RewardList)
			{
				stringBuilder.AppendLine($"\t\t{reward}:");
			}
			stringBuilder.AppendLine($"\tMod:");
			stringBuilder.AppendLine($"\t\tDisplayname: {Components.ArchnemesisModComponent.ModWrapper.DisplayName} [Id:{Components.ArchnemesisModComponent.ModWrapper.ModId}]");
		}
		if (Components.HeistContractComponent != null)
		{
			stringBuilder.AppendLine($"[Components.HeistContractComponent]");
			stringBuilder.AppendLine($"\tAreaLevel: {Components.HeistContractComponent.AreaLevel}");
			stringBuilder.AppendLine($"\tClientName: {Components.HeistContractComponent.ClientName}");
			stringBuilder.AppendLine($"\tHeistTarget: {Components.HeistContractComponent.HeistTarget.Name}");
			stringBuilder.AppendLine($"\tJobs Requirements:");
			foreach (KeyValuePair<string, int> jobsRequire in Components.HeistContractComponent.JobsRequires)
			{
				stringBuilder.AppendLine($"\t\t {jobsRequire.Key}(Level {jobsRequire.Value})");
			}
			stringBuilder.AppendLine($"\tNpcs Requirements:");
			foreach (string npcsRequire in Components.HeistContractComponent.NpcsRequires)
			{
				stringBuilder.AppendLine($"\t\t {npcsRequire}");
			}
		}
		if (Components.HeistBlueprintComponent != null)
		{
			stringBuilder.AppendLine($"[Components.HeistBlueprintComponent]");
			stringBuilder.AppendLine($"\tAreaLevel: {Components.HeistBlueprintComponent.AreaLevel}");
			stringBuilder.AppendLine($"\tWings: {Components.HeistBlueprintComponent.RevealedWings}/{Components.HeistBlueprintComponent.RevealedWings + Components.HeistBlueprintComponent.UnRevealedWings}");
			List<HeistBlueprint.Room> source = Components.HeistBlueprintComponent.Rooms.Where((HeistBlueprint.Room x) => x.Id == "EscapeRoom").ToList();
			List<HeistBlueprint.Room> source2 = Components.HeistBlueprintComponent.Rooms.Where((HeistBlueprint.Room x) => x.Id != "EscapeRoom").ToList();
			stringBuilder.AppendLine($"\tEscape Routes: {source.Count()}/{source.Count()}");
			stringBuilder.AppendLine($"\tReward Rooms: {source2.Count((HeistBlueprint.Room x) => x.Revealed > 0)}/{source2.Count()}");
			stringBuilder.AppendLine($"\t[Rewards]");
			foreach (HeistBlueprint.Room item4 in source2.Where((HeistBlueprint.Room x) => x.Revealed > 0))
			{
				stringBuilder.AppendLine($"\t\t{item4.Id}");
			}
		}
		stringBuilder.AppendLine($"[Components.SkillGemComponent]: {Components.SkillGemComponent != null}");
		stringBuilder.AppendLine($"\tSocketColor: {SocketColor}");
		stringBuilder.AppendLine($"\tSkillGemLevel: {SkillGemLevel}");
		stringBuilder.AppendLine($"\tSkillGemQualityType: {SkillGemQualityType}");
		stringBuilder.AppendLine(string.Format("\tGemTypes: {0}", string.Join(" | ", GemTypes)));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine(string.Format("Skill: {0}", (Skill == null) ? "(null)" : Skill.ToString()));
		stringBuilder.AppendLine();
		EntityComponentInformation components = Components;
		foreach (KeyValuePair<string, long> component in components.GetComponents())
		{
			stringBuilder.AppendLine($"{component.Key}: 0x{component.Value:X}");
		}
		return stringBuilder.ToString();
	}

	private int CalcItemsStatRequirements(int int_2)
	{
		LocalStats localStatsComponent = Components.LocalStatsComponent;
		if (localStatsComponent != null && localStatsComponent.GetStat(StatTypeGGG.LocalUniqueTabulaRasaNoRequirementOrEnergyShield) != 0)
		{
			return 0;
		}
		AttributeRequirements attributeRequirementsComponent = Components.AttributeRequirementsComponent;
		if (attributeRequirementsComponent != null)
		{
			int num = 0;
			double num2 = 0.0;
			switch (int_2)
			{
			case 0:
				num2 = attributeRequirementsComponent.Str;
				if (localStatsComponent != null)
				{
					num2 += (double)localStatsComponent.GetStat(StatTypeGGG.LocalStrengthRequirementPos);
					int stat5 = localStatsComponent.GetStat(StatTypeGGG.LocalAttributeRequirementsPosPct);
					int stat6 = localStatsComponent.GetStat(StatTypeGGG.LocalStrengthRequirementPosPct);
					if (stat6 != 0 || stat5 != 0)
					{
						double num5 = (double)(100 + stat6 + stat5 + num) / 100.0;
						num2 *= num5;
					}
				}
				break;
			case 2:
				num2 = attributeRequirementsComponent.Int;
				if (localStatsComponent != null)
				{
					num2 += (double)localStatsComponent.GetStat(StatTypeGGG.LocalIntelligenceRequirementPos);
					int stat3 = localStatsComponent.GetStat(StatTypeGGG.LocalAttributeRequirementsPosPct);
					int stat4 = localStatsComponent.GetStat(StatTypeGGG.LocalIntelligenceRequirementPosPct);
					if (stat4 != 0 || stat3 != 0)
					{
						double num4 = (double)(100 + stat4 + stat3 + num) / 100.0;
						num2 *= num4;
					}
				}
				break;
			case 1:
				num2 = attributeRequirementsComponent.Dex;
				if (localStatsComponent != null)
				{
					num2 += (double)localStatsComponent.GetStat(StatTypeGGG.LocalDexterityRequirementPos);
					int stat = localStatsComponent.GetStat(StatTypeGGG.LocalAttributeRequirementsPosPct);
					int stat2 = localStatsComponent.GetStat(StatTypeGGG.LocalDexterityRequirementPosPct);
					if (stat2 != 0 || stat != 0)
					{
						double num3 = (double)(100 + stat2 + stat + num) / 100.0;
						num2 *= num3;
					}
				}
				break;
			}
			return (int)Math.Floor(num2);
		}
		return 0;
	}

	public static int CalcGemStatReq(string name, int level, int multi)
	{
		double num = 0.0;
		double num2 = 0.0;
		if (!name.Contains("Support"))
		{
			num2 = (double)(8 * multi) / 100.0;
			switch (multi)
			{
			case 75:
				num = 1.619;
				break;
			case 60:
				num = 1.325;
				break;
			default:
				return 0;
			case 40:
				num = 0.924;
				break;
			case 100:
				num = 2.1;
				num2 = 7.75;
				break;
			}
		}
		else
		{
			num2 = (double)(6 * multi) / 100.0;
			switch (multi)
			{
			case 100:
				num = 1.4945;
				break;
			case 40:
				num = 0.6575;
				break;
			default:
				return 0;
			case 60:
				num = 0.9445;
				break;
			}
		}
		double num3 = Math.Round((double)level * num + num2, MidpointRounding.AwayFromZero);
		if (num3 >= 14.0)
		{
			return (int)num3;
		}
		return 0;
	}

	public bool HasMetadataFlags(params MetadataFlags[] flags)
	{
		if (hashSet_0 == null && !BITC.dictionary_0.TryGetValue(Metadata, out hashSet_0))
		{
			return false;
		}
		foreach (MetadataFlags item in flags)
		{
			if (!hashSet_0.Contains(item))
			{
				return false;
			}
		}
		return true;
	}

	public bool AnyMetadataFlags(params MetadataFlags[] flags)
	{
		if (hashSet_0 == null && !BITC.dictionary_0.TryGetValue(Metadata, out hashSet_0))
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < flags.Length)
			{
				MetadataFlags item = flags[num];
				if (hashSet_0.Contains(item))
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public Item GetGemInSocket(int index)
	{
		Sockets socketsComponent = Components.SocketsComponent;
		if (socketsComponent == null)
		{
			return null;
		}
		if (index >= 0 && index <= 5)
		{
			return socketsComponent.Gems[index];
		}
		return null;
	}

	public int GetSocketIndexForSkilGem(Item sg)
	{
		if (sg == null)
		{
			return -1;
		}
		Item[] socketedGems = SocketedGems;
		for (int i = 0; i < socketedGems.Count(); i++)
		{
			if (socketedGems[i] != null && socketedGems[i].Address == sg.Address)
			{
				return i;
			}
		}
		return -1;
	}

	public int GetSocketIndexOfGem(Item gem)
	{
		Sockets socketsComponent = Components.SocketsComponent;
		if (socketsComponent == null)
		{
			return -1;
		}
		if (!(gem.Components.SkillGemComponent == null))
		{
			int num = 0;
			while (true)
			{
				if (num < 6)
				{
					Item item = socketsComponent.Gems[num];
					if (item != null && item.LocalId == gem.LocalId)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}
		return -1;
	}

	public override string ToString()
	{
		return Metadata;
	}
}
