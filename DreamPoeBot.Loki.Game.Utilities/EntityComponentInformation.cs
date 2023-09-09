using System.Collections.Generic;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Utilities;

public class EntityComponentInformation : RemoteMemoryObject
{
	private Entity _entity;

	private PerFrameCachedValue<Dictionary<string, long>> perFrameComponentsDictionary;

	private Dictionary<string, long> componentsDictionary;

	public DreamPoeBot.Loki.Components.Actor ActorComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Actor>();

	public Animated AnimatedComponent => _entity.GetComponent<Animated>();

	public ArchnemesisMod ArchnemesisModComponent => _entity.GetComponent<ArchnemesisMod>();

	public DreamPoeBot.Loki.Components.AreaTransition AreaTransitionComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.AreaTransition>();

	public Armour ArmourComponent => _entity.GetComponent<Armour>();

	public AttributeRequirements AttributeRequirementsComponent => _entity.GetComponent<AttributeRequirements>();

	public Base BaseComponent => _entity.GetComponent<Base>();

	public BaseEvents BaseEventsComponent => _entity.GetComponent<BaseEvents>();

	public Beam BeamComponent => _entity.GetComponent<Beam>();

	public BlightTower BlightTowerComponent => _entity.GetComponent<BlightTower>();

	public BreachObject BreachObject => _entity.GetComponent<BreachObject>();

	public Buffs BuffsComponent => _entity.GetComponent<Buffs>();

	public Charges ChargesComponent => _entity.GetComponent<Charges>();

	public DreamPoeBot.Loki.Components.Chest ChestComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Chest>();

	public ClientBetrayalChoice ClientBetrayalChoiceComponent => _entity.GetComponent<ClientBetrayalChoice>();

	public Counter CounterComponent => _entity.GetComponent<Counter>();

	public CurrencyInfo CurrencyInfoComponent => _entity.GetComponent<CurrencyInfo>();

	public DelveLight DelveLightComponent => _entity.GetComponent<DelveLight>();

	public DelveNode DelveNodeComponent => _entity.GetComponent<DelveNode>();

	public DiesAfterTime DiesAfterTimeComponent => _entity.GetComponent<DiesAfterTime>();

	public ExpeditionSaga ExpeditionSagaComponent => _entity.GetComponent<ExpeditionSaga>();

	public Flask FlaskComponent => _entity.GetComponent<Flask>();

	public HeistBlueprint HeistBlueprintComponent => _entity.GetComponent<HeistBlueprint>();

	public HeistContract HeistContractComponent => _entity.GetComponent<HeistContract>();

	public HeistRewardDisplay HeistRewardDisplayComponent => _entity.GetComponent<HeistRewardDisplay>();

	public Hull HullComponent => _entity.GetComponent<Hull>();

	public IncursionTemple IncursionTempleComponent => _entity.GetComponent<IncursionTemple>();

	public Inventories InventoriesComponent => _entity.GetComponent<Inventories>();

	public Life LifeComponent => _entity.GetComponent<Life>();

	public LimitedLifespan LimitedLifespanComponent => _entity.GetComponent<LimitedLifespan>();

	public LocalStats LocalStatsComponent => _entity.GetComponent<LocalStats>();

	public Magnetic MagneticComponent => _entity.GetComponent<Magnetic>();

	public Map MapComponent => _entity.GetComponent<Map>();

	public MinimapIcon MinimapIconComponent => _entity.GetComponent<MinimapIcon>();

	public Mods ModsComponent => _entity.GetComponent<Mods>();

	public DreamPoeBot.Loki.Components.Monolith MonolithComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Monolith>();

	public DreamPoeBot.Loki.Components.Monster MonsterComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Monster>();

	public Movement Movement => _entity.GetComponent<Movement>();

	public NPC NpcComponent => _entity.GetComponent<NPC>();

	public ObjectMagicProperties ObjectMagicPropertiesComponent => _entity.GetComponent<ObjectMagicProperties>();

	public ObjectSpawner ObjectSpawnerComponent => _entity.GetComponent<ObjectSpawner>();

	public Pathfinding PathfindingComponent => _entity.GetComponent<Pathfinding>();

	public DreamPoeBot.Loki.Components.Player PlayerComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Player>();

	public PlayerClass PlayerClassComponent => _entity.GetComponent<PlayerClass>();

	public Pointer PointerComponent => _entity.GetComponent<Pointer>();

	public DreamPoeBot.Loki.Components.Portal PortalComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Portal>();

	public Positioned PositionedComponent => _entity.GetComponent<Positioned>();

	public Preload PreloadComponent => _entity.GetComponent<Preload>();

	public DreamPoeBot.Loki.Components.Projectile ProjectileComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Projectile>();

	public DreamPoeBot.Loki.Components.Prophecy ProphecyComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Prophecy>();

	public ProximityTrigger ProximityTrigger => _entity.GetComponent<ProximityTrigger>();

	public Quality QualityComponent => _entity.GetComponent<Quality>();

	public Quest QuestComponent => _entity.GetComponent<Quest>();

	public Render RenderComponent => _entity.GetComponent<Render>();

	public RenderItem RenderItemComponent => _entity.GetComponent<RenderItem>();

	public SentinelDrone SentinelDroneComponent => _entity.GetComponent<SentinelDrone>();

	public Shield ShieldComponent => _entity.GetComponent<Shield>();

	public DreamPoeBot.Loki.Components.Shrine ShrineComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.Shrine>();

	public SkillGem SkillGemComponent => _entity.GetComponent<SkillGem>();

	public Sockets SocketsComponent => _entity.GetComponent<Sockets>();

	public Stack StackComponent => _entity.GetComponent<Stack>();

	public StateMachine StateMachineComponent => _entity.GetComponent<StateMachine>();

	public Stats StatsComponent => _entity.GetComponent<Stats>();

	public Targetable TargetableComponent => _entity.GetComponent<Targetable>();

	public Timer Timer => _entity.GetComponent<Timer>();

	public Transitionable TransitionableComponent => _entity.GetComponent<Transitionable>();

	public DreamPoeBot.Loki.Components.TriggerableBlockage TriggerableBlockageComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.TriggerableBlockage>();

	public Usable UsableComponent => _entity.GetComponent<Usable>();

	public Weapon WeaponComponent => _entity.GetComponent<Weapon>();

	public WorldDescription WorldDescriptionComponent => _entity.GetComponent<WorldDescription>();

	public DreamPoeBot.Loki.Components.WorldItem WorldItemComponent => _entity.GetComponent<DreamPoeBot.Loki.Components.WorldItem>();

	public EntityComponentInformation(EntityWrapper entity)
		: base(entity.Address)
	{
		base.Address = entity.Address;
		_entity = entity;
	}

	public EntityComponentInformation(Entity entity)
		: base(entity.Address)
	{
		base.Address = entity.Address;
		_entity = entity;
	}

	public EntityComponentInformation(Item entity)
		: base(entity.Address)
	{
		base.Address = entity.Address;
		_entity = new EntityWrapper(base.Address);
	}

	public EntityComponentInformation(long address)
		: base(address)
	{
		base.Address = address;
		_entity = new EntityWrapper(base.Address);
	}

	private bool HasComponent<T>(out long addr) where T : Component, new()
	{
		addr = 0L;
		if (componentsDictionary == null)
		{
			componentsDictionary = GetComponents();
		}
		if (!componentsDictionary.TryGetValue(typeof(T).Name, out addr))
		{
			return false;
		}
		return true;
	}

	internal Dictionary<string, long> GetComponents()
	{
		if (perFrameComponentsDictionary == null)
		{
			perFrameComponentsDictionary = new PerFrameCachedValue<Dictionary<string, long>>(() => _entity.ComponentIndices);
		}
		return perFrameComponentsDictionary;
	}
}
