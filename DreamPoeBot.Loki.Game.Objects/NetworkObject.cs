using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class NetworkObject : IEquatable<NetworkObject>
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct105
	{
		public IntPtr Struct133_intptr_0;

		public NativeVector Struct133_nativeVector_0;

		public NativeVector nativeVector_0;

		public IntPtr intptr_0;

		public int int_0;

		public byte byte_0;

		internal byte byte_1;

		internal byte byte_2;

		internal byte byte_3;

		public uint uint_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;

		public IntPtr intptr_3;

		internal Struct252 struct252_0;

		internal Struct252 struct252_1;

		internal Struct252 struct252_2;
	}

	private bool? nullable_99_ArchnemesisIsTrapped;

	private static readonly ILog ilog_0;

	private int? nullable_0;

	private bool? nullable_1;

	private string name;

	private Positioned positionedComponent_0;

	private string string_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private bool? nullable_4;

	private bool? nullable_5;

	private bool? nullable_6;

	private bool? nullable_7;

	private bool? nullable_8;

	private bool? nullable_9;

	private bool? nullable_10;

	private bool? nullable_11;

	private bool? nullable_12;

	private bool? nullable_13;

	private bool? nullable_14;

	private bool? nullable_15;

	private bool? nullable_16;

	private bool? nullable_17;

	private bool? nullable_18;

	private bool? nullable_19;

	private bool? nullable_20;

	private bool? nullable_21;

	private bool? nullable_22_IsAflictionInitiator;

	private bool? nullable_IsLegionInitiator;

	private PerFrameCachedValue<bool> perFrameCachedValue_1;

	private PerFrameCachedValue<bool> perFrameCachedValue_2;

	private SlowCacheValue<EntityComponentInformation> PFVEntityComponentInformation;

	private PerFrameCachedValue<Reaction> perFrameCachedValue_4;

	public EntityWrapper _entity { get; set; }

	public EntityWrapper Entity => _entity;

	public string AnimatedPropertiesMetadata
	{
		get
		{
			Animated component = _entity.GetComponent<Animated>();
			if (component == null)
			{
				return string.Empty;
			}
			return component.BaseAnimatedObjectEntity.Metadata;
		}
	}

	public bool BaseHashChanged => false;

	public int CharacterSize
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				Positioned positioned = PositionedComponent_0;
				if (!(positioned == null))
				{
					nullable_0 = positioned.CharacterSize;
				}
				else
				{
					nullable_0 = 0;
				}
			}
			return nullable_0.Value;
		}
	}

	public Vector2i Position => new Vector2i(_entity.PositionedComp.GridX, _entity.PositionedComp.GridY);

	public Vector2 WorldPosition => new Vector2(_entity.PositionedComp.WorldX, _entity.PositionedComp.WorldY);

	public float Distance => LokiPoe.LocalData.MyPosition.Distance(Position);

	public float DistanceSqr => LokiPoe.LocalData.MyPosition.DistanceSqr(Position);

	public bool HasNpcFloatingIcon
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (!(component == null))
			{
				return component.HasIconOverHead;
			}
			return false;
		}
	}

	public int Id => _entity.Id;

	public Vector3 InteractCenterWorld
	{
		get
		{
			Render component = _entity.GetComponent<Render>();
			if (!(component == null))
			{
				return component.InteractCenterWorld;
			}
			return Vector3.Zero;
		}
	}

	public bool IsAbyssCrackSpawner
	{
		get
		{
			if (!nullable_17.HasValue)
			{
				nullable_17 = Metadata.Contains("AbyssCrackSpawners");
			}
			return nullable_17.Value;
		}
	}

	public bool IsAbyssFinalNodeChest
	{
		get
		{
			if (!nullable_16.HasValue)
			{
				string type = Type;
				nullable_16 = type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssFinalNodeChest", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssFinalNodeChest2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssFinalNodeChest3", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssFinalNodeChest4", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_16.Value;
		}
	}

	public bool IsAbyssFinalNodeSubArea
	{
		get
		{
			if (!nullable_18.HasValue)
			{
				nullable_18 = Metadata.Contains("AbyssFinalNodeSubArea");
			}
			return nullable_18.Value;
		}
	}

	public bool IsAbyssNodeLarge
	{
		get
		{
			if (!nullable_15.HasValue)
			{
				nullable_15 = Type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssNodeLarge", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_15.Value;
		}
	}

	public bool IsAbyssNodeSmall
	{
		get
		{
			if (!nullable_14.HasValue)
			{
				nullable_14 = Type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssNodeSmall", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_14.Value;
		}
	}

	public bool IsAbyssStartNode
	{
		get
		{
			if (!nullable_12.HasValue)
			{
				nullable_12 = Type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssStartNode", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_12.Value;
		}
	}

	public bool IsAbyssNodeMini
	{
		get
		{
			if (!nullable_13.HasValue)
			{
				nullable_13 = Type.Equals("Metadata/MiscellaneousObjects/Abyss/AbyssNodeMini", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_13.Value;
		}
	}

	public bool IsLegionInitiator
	{
		get
		{
			if (!nullable_IsLegionInitiator.HasValue)
			{
				nullable_IsLegionInitiator = Metadata.Contains("Legion/Objects/LegionInitiator");
			}
			return nullable_IsLegionInitiator.Value;
		}
	}

	public bool IsBeyondPortal
	{
		get
		{
			if (!nullable_10.HasValue)
			{
				nullable_10 = Type.Contains("BeyondPortal");
			}
			return nullable_10.Value;
		}
	}

	public bool IsBlightDefensiveTower
	{
		get
		{
			if (!nullable_20.HasValue)
			{
				nullable_20 = Components.BlightTowerComponent != null;
			}
			return nullable_20.Value;
		}
	}

	public bool IsUltimatumChallengeInteractable
	{
		get
		{
			if (!nullable_21.HasValue)
			{
				nullable_21 = Type.Equals("Metadata/Terrain/Leagues/Ultimatum/Objects/UltimatumChallengeInteractable", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_21.Value;
		}
	}

	public bool ArchnemesisIsTrapped
	{
		get
		{
			if (!nullable_99_ArchnemesisIsTrapped.HasValue)
			{
				nullable_99_ArchnemesisIsTrapped = Components.StatsComponent != null && Components.StatsComponent.GetStat(StatTypeGGG.ArchnemesisIsTrapped) > 0;
			}
			return nullable_99_ArchnemesisIsTrapped.Value;
		}
	}

	public bool IsAflictionInitiator
	{
		get
		{
			if (!nullable_22_IsAflictionInitiator.HasValue)
			{
				nullable_22_IsAflictionInitiator = Type.Contains("Metadata/Terrain/Leagues/Affliction") && Type.Contains("/Objects/Afflictionator");
			}
			return nullable_22_IsAflictionInitiator.Value;
		}
	}

	public bool IsBreach
	{
		get
		{
			if (!nullable_11.HasValue)
			{
				nullable_11 = Type.Equals("Metadata/MiscellaneousObjects/Breach/BreachObject", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_11.Value;
		}
	}

	public bool IsDoor
	{
		get
		{
			if (!nullable_7.HasValue)
			{
				nullable_7 = Metadata.Contains("LabyrinthSmashableDoor") || Name.Equals("Door");
			}
			return nullable_7.Value;
		}
	}

	public bool IsGoldenDoor
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				nullable_2 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/GoldenDoor", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_2.Value;
		}
	}

	public bool IsSilverDoor
	{
		get
		{
			if (!nullable_3.HasValue)
			{
				nullable_3 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/SilverDoor", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_3.Value;
		}
	}

	public bool IsHiddenDoor
	{
		get
		{
			if (!nullable_4.HasValue)
			{
				nullable_4 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/HiddenDoor_Short", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_4.Value;
		}
	}

	public bool IsHiddenDoorSwitch
	{
		get
		{
			if (!nullable_8.HasValue)
			{
				nullable_8 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/HiddenDoor_Switch", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_8.Value;
		}
	}

	public bool IsHighlightable
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<bool>(method_3);
			}
			return perFrameCachedValue_1;
		}
	}

	public bool IsIgnoreHidden
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (!(component == null))
			{
				return component.IsIgnoreHidden;
			}
			return false;
		}
	}

	public bool IsLockedDoor
	{
		get
		{
			if (!nullable_5.HasValue)
			{
				nullable_5 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/Puzzle_Parts/Door_Closed", StringComparison.OrdinalIgnoreCase) || Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/Puzzle_Parts/Door_Open", StringComparison.OrdinalIgnoreCase) || Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/Puzzle_Parts/Door_Counter", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_5.Value;
		}
	}

	public bool IsMaster
	{
		get
		{
			if (!nullable_19.HasValue)
			{
				string type = Type;
				nullable_19 = type.Equals("Metadata/NPC/Missions/Wild/Dex") || type.Equals("Metadata/NPC/Missions/Wild/DexInt") || type.Equals("Metadata/NPC/Missions/Wild/Int") || type.Equals("Metadata/NPC/Missions/Wild/Str") || type.Equals("Metadata/NPC/Missions/Wild/StrDex") || type.Equals("Metadata/NPC/Missions/Wild/StrDexInt") || type.Equals("Metadata/NPC/Missions/Wild/StrInt") || type.Equals("Metadata/NPC/Missions/Hideout/Dex") || type.Equals("Metadata/NPC/Missions/Hideout/DexInt") || type.Equals("Metadata/NPC/Missions/Hideout/Int") || type.Equals("Metadata/NPC/Missions/Hideout/Str") || type.Equals("Metadata/NPC/Missions/Hideout/StrDex") || type.Equals("Metadata/NPC/Missions/Hideout/StrDexInt") || type.Equals("Metadata/NPC/Missions/Hideout/StrInt") || type.Equals("Metadata/NPC/Missions/Hideout/PvP") || type.Equals("Metadata/NPC/Missions/PvP") || type.Equals("Metadata/NPC/Missions/Dex") || type.Equals("Metadata/NPC/Missions/DexInt") || type.Equals("Metadata/NPC/Missions/Int") || type.Equals("Metadata/NPC/Missions/Str") || type.Equals("Metadata/NPC/Missions/StrDex") || type.Equals("Metadata/NPC/Missions/StrDexInt") || type.Equals("Metadata/NPC/Missions/StrInt");
			}
			return nullable_19.Value;
		}
	}

	public bool IsLabyrinthRollerTrap
	{
		get
		{
			if (!nullable_6.HasValue)
			{
				nullable_6 = Metadata.Contains("LabyrinthRollerTrap");
			}
			return nullable_6.Value;
		}
	}

	public bool IsMinimapLabelVisible
	{
		get
		{
			NPC component = _entity.GetComponent<NPC>();
			if (!(component == null))
			{
				return component.IsMinimapLabelVisible;
			}
			return false;
		}
	}

	public bool IsMysteriousDarkshrine
	{
		get
		{
			if (!nullable_9.HasValue)
			{
				nullable_9 = Metadata.Equals("Metadata/Terrain/Labyrinth/Objects/LabyrinthDarkshrineHidden", StringComparison.OrdinalIgnoreCase);
			}
			return nullable_9.Value;
		}
	}

	public bool IsTargetable
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<bool>(method_4);
			}
			return perFrameCachedValue_2;
		}
	}

	public bool IsValid
	{
		get
		{
			if (_entity.Address <= 0L)
			{
				return false;
			}
			if (!LokiPoe.Memory.IsValidAddress(_entity.Address))
			{
				return false;
			}
			return true;
		}
	}

	public bool HasHull
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				Animated component = Entity.GetComponent<Animated>();
				if (component == null)
				{
					nullable_1 = false;
					return nullable_1.Value;
				}
				EntityWrapper baseAnimatedObjectEntity = component.BaseAnimatedObjectEntity;
				if (baseAnimatedObjectEntity == null)
				{
					nullable_1 = false;
					return nullable_1.Value;
				}
				nullable_1 = baseAnimatedObjectEntity.HasComponent<Hull>();
			}
			return nullable_1.Value;
		}
	}

	public Hull Hull
	{
		get
		{
			Animated component = Entity.GetComponent<Animated>();
			if (component == null)
			{
				nullable_1 = false;
				return null;
			}
			EntityWrapper baseAnimatedObjectEntity = component.BaseAnimatedObjectEntity;
			if (!(baseAnimatedObjectEntity == null))
			{
				return baseAnimatedObjectEntity.GetComponent<Hull>();
			}
			nullable_1 = false;
			return null;
		}
	}

	public string Metadata
	{
		get
		{
			if (string_1 == null)
			{
				string_1 = Type;
				int num = string_1.IndexOf("@", StringComparison.Ordinal);
				if (num != -1)
				{
					string_1 = string_1.Substring(0, num);
				}
			}
			return string_1;
		}
	}

	public virtual string Name
	{
		get
		{
			if (!string.IsNullOrWhiteSpace(name))
			{
				return name;
			}
			try
			{
				DreamPoeBot.Loki.Components.Player playerComponent = Components.PlayerComponent;
				if (playerComponent != null)
				{
					name = playerComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				ArchnemesisMod archnemesisModComponent = Components.ArchnemesisModComponent;
				if (archnemesisModComponent != null)
				{
					name = archnemesisModComponent.ModWrapper.DisplayName;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				DreamPoeBot.Loki.Components.WorldItem worldItemComponent = Components.WorldItemComponent;
				if (worldItemComponent != null)
				{
					name = worldItemComponent.ItemEntity.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				DreamPoeBot.Loki.Components.Monster monsterComponent = Components.MonsterComponent;
				if (monsterComponent != null)
				{
					name = monsterComponent.MonsterName;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				Render renderComponent = Components.RenderComponent;
				if (renderComponent != null)
				{
					name = renderComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				Base baseComponent = Components.BaseComponent;
				if (baseComponent != null)
				{
					name = baseComponent.Name;
					if (string.IsNullOrWhiteSpace(name))
					{
						name = Type;
					}
					return name;
				}
				string type = Type;
				if (string.IsNullOrEmpty(type))
				{
					name = "Unknown";
				}
				else
				{
					name = type;
				}
			}
			catch (Exception ex)
			{
				ilog_0.Error((object)"Name", ex);
				name = "Unknown";
			}
			return name;
		}
	}

	public Reaction Reaction
	{
		get
		{
			if (perFrameCachedValue_4 == null)
			{
				perFrameCachedValue_4 = new PerFrameCachedValue<Reaction>(method_7);
			}
			return perFrameCachedValue_4;
		}
	}

	public bool IsFriendly => Reaction == Reaction.Friendly;

	public bool IsHostile => Reaction == Reaction.Enemy;

	public string Type => Entity.Metadata;

	public float WorldDistance => LokiPoe.LocalData.MyWorldPosition.Distance(WorldPosition);

	public float WorldDistanceSqr => LokiPoe.LocalData.MyWorldPosition.DistanceSqr(WorldPosition);

	public EntityComponentInformation Components
	{
		get
		{
			if (PFVEntityComponentInformation == null)
			{
				PFVEntityComponentInformation = new SlowCacheValue<EntityComponentInformation>(CacheComponents);
			}
			return PFVEntityComponentInformation;
		}
	}

	internal Positioned PositionedComponent_0
	{
		get
		{
			if (positionedComponent_0 == null)
			{
				if (Entity.PositionedComp.Address == 0L)
				{
					return null;
				}
				positionedComponent_0 = Entity.PositionedComp;
			}
			positionedComponent_0.UpdatePointer(Entity.PositionedComp.Address);
			if (positionedComponent_0.Address != 0L)
			{
				return positionedComponent_0;
			}
			return null;
		}
	}

	public override int GetHashCode()
	{
		if (!(_entity != null))
		{
			return 0;
		}
		return _entity.GetHashCode();
	}

	static NetworkObject()
	{
		ilog_0 = Logger.GetLoggerInstanceForType();
	}

	public NetworkObject(EntityWrapper entity)
	{
		_entity = entity;
	}

	public NetworkObject(Entity player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		_entity = entity;
	}

	public NetworkObject(long address)
	{
		EntityWrapper entity = new EntityWrapper(address);
		_entity = entity;
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Network Object]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{Entity.Address:X}");
		stringBuilder.AppendLine($"\tID: {Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tMetadata: {Metadata}");
		stringBuilder.AppendLine($"\tPosition: {Position} ({Distance})");
		stringBuilder.AppendLine($"\tType: {Type}");
		stringBuilder.AppendLine($"\tAPI Type: {GetType()}");
		stringBuilder.AppendLine($"\tReaction: {Reaction}");
		if (Components.ActorComponent != null && Components.ActorComponent.HasCurrentAction)
		{
			Skill skill = ((!(Components.ActorComponent.CurrentAction?.Skill != null)) ? null : Components.ActorComponent.CurrentAction?.Skill);
			if (skill != null)
			{
				stringBuilder.AppendLine($"\tCurrentAction: {skill.Name} ({skill.InternalName})");
				stringBuilder.AppendLine($"\t\tCastTime: {skill.CastTime}");
				stringBuilder.AppendLine($"\t\tIsOnCooldown: {skill.IsOnCooldown}");
				stringBuilder.AppendLine($"\t\tDestination: {Components.ActorComponent.CurrentAction.Destination.ToString()}");
				if (Components.ActorComponent.CurrentAction.Target != null)
				{
					stringBuilder.AppendLine($"\tCurrentActionTargetName: {Components.ActorComponent.CurrentAction.Target.Name} [Id: {Components.ActorComponent.CurrentAction.Target.Id}]");
				}
				stringBuilder.AppendLine($"\t\tStats:");
				foreach (KeyValuePair<StatTypeGGG, int> stat in skill.Stats)
				{
					stringBuilder.AppendLine($"\t\t\t{stat.Key.ToString()}: {stat.Value}");
				}
			}
			else
			{
				stringBuilder.AppendLine($"\tCurrentAction: None");
			}
		}
		ObjectMagicProperties objectMagicPropertiesComponent = Components.ObjectMagicPropertiesComponent;
		if (objectMagicPropertiesComponent != null)
		{
			stringBuilder.AppendLine($"\tRarity: {objectMagicPropertiesComponent.Rarity}");
		}
		string arg = (string.IsNullOrEmpty(AnimatedPropertiesMetadata) ? "AnimatedPropertiesMetadata is empty, this item is probably filter in your game filter." : AnimatedPropertiesMetadata);
		stringBuilder.AppendLine($"\tAnimatedPropertiesMetadata: {arg}");
		stringBuilder.AppendLine();
		stringBuilder.AppendLine($"[Components]");
		EntityComponentInformation components = Components;
		foreach (KeyValuePair<string, long> component in components.GetComponents())
		{
			stringBuilder.AppendLine($"\t{component.Key}: 0x{component.Value:X}");
			if (component.Key == "StateMachine")
			{
				foreach (StateMachine.StageState stageState in Components.StateMachineComponent.StageStates)
				{
					stringBuilder.AppendLine($"\t\t-Name: {stageState.Name} [IsActive: {stageState.IsActive}]");
				}
			}
			if (component.Key == "Targetable")
			{
				stringBuilder.AppendLine($"\t\t-CanHighlight: {Components.TargetableComponent.CanHighlight}, CanTarget: {Components.TargetableComponent.CanTarget}, IsTargeted: {Components.TargetableComponent.IsTargeted}");
			}
			if (component.Key == "Transitionable")
			{
				stringBuilder.AppendLine($"\t\t-Flag1: {Components.TransitionableComponent.Flag1}, Flag2: {Components.TransitionableComponent.Flag2}, Flag3: {Components.TransitionableComponent.Flag3}");
			}
			if (component.Key == "AreaTransition")
			{
				stringBuilder.AppendLine($"\t\t-Destination: {Components.AreaTransitionComponent.Destination.Name}, TransitionType: {Components.AreaTransitionComponent.TransitionType.ToString()}");
			}
		}
		stringBuilder.AppendLine();
		if (Components.PlayerComponent != null)
		{
			stringBuilder.AppendLine(Components.PlayerComponent.ToString());
		}
		if (Components.LifeComponent != null)
		{
			stringBuilder.AppendLine(Components.LifeComponent.ToString());
		}
		if (Components.StatsComponent != null)
		{
			stringBuilder.AppendLine(Components.StatsComponent.ToString());
		}
		if (objectMagicPropertiesComponent != null)
		{
			stringBuilder.AppendLine(objectMagicPropertiesComponent.ToString());
		}
		return stringBuilder.ToString();
	}

	private bool method_3()
	{
		Targetable component = Entity.GetComponent<Targetable>();
		if (component != null)
		{
			return component.CanHighlight;
		}
		return false;
	}

	private bool method_4()
	{
		Targetable component = Entity.GetComponent<Targetable>();
		if (component != null)
		{
			return component.CanTarget;
		}
		return false;
	}

	private Reaction method_7()
	{
		if (IsIgnoreHidden)
		{
			return Reaction.Npc;
		}
		if (Components.ActorComponent != null)
		{
			Positioned positioned = PositionedComponent_0;
			if (!(positioned == null))
			{
				int num = LokiPoe.LocalData.MyReaction & 0x7F;
				int num2 = positioned.Reaction & 0x7F;
				if (num != num2)
				{
					return Reaction.Enemy;
				}
				return Reaction.Friendly;
			}
			return Reaction.Unset;
		}
		return Reaction.NonActor;
	}

	private EntityComponentInformation CacheComponents()
	{
		return new EntityComponentInformation(_entity);
	}

	public bool Equals(NetworkObject other)
	{
		if (object.Equals(other, null))
		{
			return false;
		}
		return Entity.Address == other.Entity.Address;
	}

	public override bool Equals(object obj)
	{
		if (obj != null)
		{
			if (this != obj)
			{
				if (!(obj.GetType() != GetType()))
				{
					return Equals((NetworkObject)obj);
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool operator !=(NetworkObject left, NetworkObject right)
	{
		return !object.Equals(left, right);
	}

	internal NetworkObject ConvertNetworkObject()
	{
		if (!(_entity == null) && _entity.Address != 0L)
		{
			if (_entity.Address != LokiPoe.LocalData.MePtr)
			{
				if (IsUltimatumChallengeInteractable)
				{
					return new UltimatumChallengeInteractable(this);
				}
				if (Components.BlightTowerComponent != null)
				{
					return new BlightDefensiveTower(this);
				}
				if (!Metadata.StartsWith("Metadata/Terrain/Leagues/Heist/Objects/Level/Door_NPC"))
				{
					if (!Metadata.StartsWith("Metadata/MiscellaneousObjects/PrimordialBosses/TangleAltar") && !Metadata.StartsWith("Metadata/MiscellaneousObjects/PrimordialBosses/CleansingFireAltar"))
					{
						if (!(Metadata == "Metadata/MiscellaneousObjects/Harvest/Extractor"))
						{
							if (!(Metadata == "Metadata/MiscellaneousObjects/Harvest/Irrigator"))
							{
								if (IsAflictionInitiator)
								{
									return new AflictionInitiator(this);
								}
								if (Components.MonsterComponent != null)
								{
									if (!ArchnemesisIsTrapped)
									{
										return new Monster(_entity);
									}
									return new ArchnemesisTrappedMonster(new Monster(_entity));
								}
								if (!(Components.WorldItemComponent != null))
								{
									if (Components.ChestComponent != null)
									{
										return new Chest(_entity);
									}
									if (!(Components.NpcComponent != null))
									{
										if (!(Components.PlayerComponent != null))
										{
											if (!(Components.AreaTransitionComponent != null))
											{
												if (Components.TriggerableBlockageComponent != null && !IsAbyssNodeSmall && !IsAbyssFinalNodeChest && !IsAbyssFinalNodeSubArea && !IsAbyssNodeLarge)
												{
													return new TriggerableBlockage(_entity);
												}
												if (Components.PortalComponent != null)
												{
													return new Portal(_entity);
												}
												if (!(Components.ActorComponent != null))
												{
													if (!(Components.ShrineComponent != null))
													{
														if (Components.ProjectileComponent != null)
														{
															return new Projectile(this);
														}
														string type = Type;
														if (type.Contains("Expedition/ExpeditionPlacementIndicator"))
														{
															return new ExpeditionPlacementIndicator(this);
														}
														if (!type.Contains("Metadata/Terrain/Missions/CraftingUnlocks/"))
														{
															if (type.Equals("Metadata/Effects/ServerEffect", StringComparison.OrdinalIgnoreCase))
															{
																return new ServerEffect(this);
															}
															if (type.Equals("Metadata/Effects/Effect", StringComparison.OrdinalIgnoreCase))
															{
																return new Effect(this);
															}
															if (!type.Equals("Metadata/Shrines/DarkShrine", StringComparison.OrdinalIgnoreCase))
															{
																if (type.Equals("Metadata/MiscellaneousObjects/Waypoint", StringComparison.OrdinalIgnoreCase))
																{
																	return new Waypoint(_entity);
																}
																if (type.Equals("Metadata/MiscellaneousObjects/Stash", StringComparison.OrdinalIgnoreCase))
																{
																	return new Stash(_entity);
																}
																if (!type.Equals("Metadata/MiscellaneousObjects/GuildStash", StringComparison.OrdinalIgnoreCase))
																{
																	if (!type.Equals("Metadata/Effects/Spells/monsters_effects/brute_death/BruteDeathExplosion", StringComparison.OrdinalIgnoreCase))
																	{
																		if (!IsBeyondPortal)
																		{
																			if (!IsBreach)
																			{
																				if (IsAbyssNodeMini)
																				{
																					return new AbyssNodeMini(this);
																				}
																				if (!IsAbyssStartNode)
																				{
																					if (!IsAbyssNodeSmall)
																					{
																						if (IsAbyssNodeLarge)
																						{
																							return new AbyssNodeLarge(this);
																						}
																						if (!IsAbyssFinalNodeChest)
																						{
																							if (IsAbyssCrackSpawner)
																							{
																								return new AbyssCrackSpawner(this);
																							}
																							if (!IsAbyssFinalNodeSubArea)
																							{
																								if (IsLegionInitiator)
																								{
																									return new LegionInitiator(this);
																								}
																								if (type.Equals("Metadata/MiscellaneousObjects/MissionMarker", StringComparison.OrdinalIgnoreCase))
																								{
																									return new MissionMarker(this);
																								}
																								if (type.Equals("Metadata/MiscellaneousObjects/Monolith", StringComparison.OrdinalIgnoreCase))
																								{
																									return new Monolith(this);
																								}
																								if (!type.Equals("Metadata/MiscellaneousObjects/MiniMonolith", StringComparison.OrdinalIgnoreCase))
																								{
																									if (type.Contains("ground_effects"))
																									{
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/blind_smoke/Smoke1", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/blind_smoke/Smoke2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/blind_smoke/Smoke3", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundBlindSmoke(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/evil/ground_01", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/evil/ground_02", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundEvil(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/evil_red/ground_01", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/evil_red/ground_02", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/evil_red/ground_03", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundEvilRed(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/fire/GroundFire1", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire/GroundFire2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire/GroundFire3", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire/GroundFire4", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundFire(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/fire_white/GroundFire1", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire_white/GroundFire2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire_white/GroundFire3", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/fire_white/GroundFire4", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundFireWhite(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/holy/ground_01", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/holy/ground_02", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/holy/ground_03", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundHoly(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/ice/GroundIce", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundIce(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/lightning/GroundLightning", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundLightning(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/poison/Poison1", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/poison/Poison2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/poison/Poison3", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundPoison(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/spike/spike", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundSpike(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/tar/GroundTar", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundTar(this);
																										}
																										if (type.Equals("Metadata/Effects/Spells/ground_effects/vaal_cloud/VaalCloud1", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/vaal_cloud/VaalCloud2", StringComparison.OrdinalIgnoreCase) || type.Equals("Metadata/Effects/Spells/ground_effects/vaal_cloud/VaalCloud3", StringComparison.OrdinalIgnoreCase))
																										{
																											return new GroundVaalCloud(this);
																										}
																									}
																									if (!type.Equals("Metadata/Effects/Spells/monsters_effects/act1/merveil/water_geyser/WaterGeyser", StringComparison.OrdinalIgnoreCase))
																									{
																										if (!type.Equals("Metadata/Effects/Spells/Masters/Dex/Arrow", StringComparison.OrdinalIgnoreCase))
																										{
																											if (!type.Equals("Metadata/Effects/Spells/Masters/Dex/BloodPool", StringComparison.OrdinalIgnoreCase))
																											{
																												if (!type.Equals("Metadata/Effects/Environment/tempest_league/elements/lightning/TempestStorm", StringComparison.OrdinalIgnoreCase))
																												{
																													if (!type.Equals("Metadata/Effects/Environment/tempest_league/elements/fire/TempestStorm", StringComparison.OrdinalIgnoreCase))
																													{
																														if (!type.Equals("Metadata/Effects/Environment/tempest_league/elements/ice/TempestStorm", StringComparison.OrdinalIgnoreCase))
																														{
																															if (type.Contains("/tempest_league/basic_colour/"))
																															{
																																return new ColoredTempestStorm(this);
																															}
																															if (type.Equals("Metadata/Terrain/StoneCircles/StoneCircleDevice", StringComparison.OrdinalIgnoreCase))
																															{
																																return new StoneAltar(this);
																															}
																															if (type.Equals("Metadata/MiscellaneousObjects/Breach/BreachClientObject", StringComparison.OrdinalIgnoreCase))
																															{
																																return new BreachClientObject(this);
																															}
																															if (type.Equals("Metadata/Terrain/Labyrinth/Objects/LabyrinthReturnPortal", StringComparison.OrdinalIgnoreCase))
																															{
																																return new LabyrinthReturnPortal(this);
																															}
																															return this;
																														}
																														return new IceTempestStorm(this);
																													}
																													return new FireTempestStorm(this);
																												}
																												return new LightningTempestStorm(this);
																											}
																											return new BloodPool(this);
																										}
																										return new Arrow(this);
																									}
																									return new WaterGeyser(this);
																								}
																								return new MiniMonolith(this);
																							}
																							return new AbyssFinalNodeSubArea(this);
																						}
																						return new AbyssFinalNodeChest(this);
																					}
																					return new AbyssNodeSmall(this);
																				}
																				return new AbyssStartNode(this);
																			}
																			return new Breach(this);
																		}
																		return new BeyondPortal(this);
																	}
																	return new BruteDeathExplosion(this);
																}
																return new GuildStash(this);
															}
															return new DarkShrine(this);
														}
														return new CraftingRecipe(_entity);
													}
													return new Shrine(_entity);
												}
												return new Actor(_entity);
											}
											return new AreaTransition(_entity);
										}
										return new Player(_entity);
									}
									return new Npc(_entity);
								}
								return new WorldItem(_entity);
							}
							return new HarvestIrrigator(_entity);
						}
						return new HarvestExtraxtor(_entity);
					}
					return new TangleAltar(_entity);
				}
				return new HeistInteractableDoor(this);
			}
			return new LocalPlayer(_entity);
		}
		return null;
	}
}
