using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class IngameUIElements : RemoteMemoryObject
{
	public static LokiPoe.PoeVersion UIClientVersion;

	private int PatchOffset
	{
		get
		{
			if (UIClientVersion == LokiPoe.PoeVersion.Official)
			{
				return 0;
			}
			return 8;
		}
	}

	public long ThisAddress => base.Address;

	public Element RootUI => GetObject<Element>(ThisAddress);

	public MainUiElement MainUi => ReadObjectAt<MainUiElement>(0);

	public HudUIElement HudUI => ReadObjectAt<HudUIElement>(88 + PatchOffset);

	public ContextMenuUiElement ContextMenuUi => ReadObjectAt<ContextMenuUiElement>(288 + PatchOffset);

	public Element QuickFlaskHud => ReadObjectAt<Element>(712 + PatchOffset);

	public SkipTutorialElement SkipTutorialPannel => ReadObjectAt<SkipTutorialElement>(944 + PatchOffset);

	public Element ChatToggle => ReadObjectAt<Element>(968 + PatchOffset);

	public CursorElement CursorOverlay => ReadObjectAt<CursorElement>(984 + PatchOffset);

	public SkillBarElement SkillBar => ReadObjectAt<SkillBarElement>(992 + PatchOffset);

	public HiddenSkillBarElement HiddenSkillBar => ReadObjectAt<HiddenSkillBarElement>(1000 + PatchOffset);

	public PartyHudUIElement PartyHudUI => ReadObjectAt<PartyHudUIElement>(1008 + PatchOffset);

	public TimersPannelElement TimersPannel => ReadObjectAt<TimersPannelElement>(1072 + PatchOffset);

	public Element BanditsPannel => ReadObjectAt<Element>(1080 + PatchOffset);

	public PoeChatElement ChatBox => ReadObjectAt<PoeChatElement>(1160 + PatchOffset);

	public Element HideoutUnlocked => ReadObjectAt<Element>(1272 + PatchOffset);

	public Element OpenLeftPanel => ReadObjectAt<Element>(1352 + PatchOffset);

	public Element OpenRightPanel => ReadObjectAt<Element>(1360 + PatchOffset);

	public Element ShopPannel => ReadObjectAt<Element>(1384 + PatchOffset);

	public InventoryElement InventoryPanel => ReadObjectAt<InventoryElement>(1392 + PatchOffset);

	public StashElement StashPannel => ReadObjectAt<StashElement>(1400 + PatchOffset); 

    public StashElement GuildStashPannel => ReadObjectAt<StashElement>(1408 + PatchOffset);

	public SoclialPannelElement SocialPannel => ReadObjectAt<SoclialPannelElement>(1424 + PatchOffset);

	public PassiveTreeElement TreePanel => GetObject<PassiveTreeElement>(RootUI.Children[24].Address);

	public AtlasElement AtlasPanel => ReadObjectAt<AtlasElement>(1448 + PatchOffset);

	public AtlasSkillElement AtlasSkillPanel => ReadObjectAt<AtlasSkillElement>(1456 + PatchOffset);

	public Element CharacterPannel => ReadObjectAt<Element>(1464 + PatchOffset);

	public OptionsElement OptionsPannel => ReadObjectAt<OptionsElement>(1472 + PatchOffset);

	public ChallengesPannelElement ChallengesPannel => ReadObjectAt<ChallengesPannelElement>(1480 + PatchOffset);

	public ThePantheonElement ThePantheonPannel => ReadObjectAt<ThePantheonElement>(1488 + PatchOffset);

	public WorldElement WorldPannel => ReadObjectAt<WorldElement>(1504 + PatchOffset);

	public Element MicrotransactionPannel => ReadObjectAt<Element>(1512 + PatchOffset);

	public Element DecorationPannel => ReadObjectAt<Element>(1520 + PatchOffset);

	public Element HelpPannel => ReadObjectAt<Element>(1528 + PatchOffset);

	public Element SentinelAssembly => ReadObjectAt<Element>(1536 + PatchOffset);

	public Element RelicAltar1 => ReadObjectAt<Element>(1544 + PatchOffset);

	public Element RelicAltar2 => ReadObjectAt<Element>(1552 + PatchOffset);

	public Element RelicLocker => ReadObjectAt<Element>(1560 + PatchOffset);

	public MapElement MapPannel => ReadObjectAt<MapElement>(1568 + PatchOffset);

	public Element BlightTowers => ReadObjectAt<Element>(1584 + PatchOffset);

	public Element NpcDialogUi => ReadObjectAt<Element>(1720 + PatchOffset);

	public Element NewNpcDialogUi => ReadObjectAt<Element>(1728 + PatchOffset);

	public RewardElement RewardPannel => ReadObjectAt<RewardElement>(1744 + PatchOffset);

	public PurchasePanellElement PurchasePanell => ReadObjectAt<PurchasePanellElement>(1752 + PatchOffset);

	public ExpeditionDealerElement ExpeditionDealerPanell => ReadObjectAt<ExpeditionDealerElement>(1760 + PatchOffset);

	public SellPannelElement SellPanell => ReadObjectAt<SellPannelElement>(1768 + PatchOffset);

	public SellPannelElement SellPanellNew => ReadObjectAt<SellPannelElement>(1776 + PatchOffset);

	public TradeUiElement TradeUi => ReadObjectAt<TradeUiElement>(1784 + PatchOffset);

	public MapDeviceElement MapDevicePannel => ReadObjectAt<MapDeviceElement>(1792 + PatchOffset);

	public DivineFontUiElement DivineFontUi => ReadObjectAt<DivineFontUiElement>(1800 + PatchOffset);

	public Element TrialPlaqueUI => ReadObjectAt<Element>(1808 + PatchOffset);

	public AscendUIElement AscendUI => ReadObjectAt<AscendUIElement>(1816 + PatchOffset);

	public MasterDeviceElement MasterDevicePannel => ReadObjectAt<MasterDeviceElement>(1824 + PatchOffset);

	public BeastCraftingUiElement BeastCraftingPannel => ReadObjectAt<BeastCraftingUiElement>(1832 + PatchOffset);

	public LabyrinthUiElement LabyrinthUi => ReadObjectAt<LabyrinthUiElement>(1840 + PatchOffset);

	public CardTradeElement CardTrade => ReadObjectAt<CardTradeElement>(1896 + PatchOffset);

	public IncursionUiElement IncursionUi => ReadObjectAt<IncursionUiElement>(1904 + PatchOffset);

	public SubterainChartElement SubterainChartUi => ReadObjectAt<SubterainChartElement>(1936 + PatchOffset);

	public ZanaMissionElement ZanaMissionlUi => ReadObjectAt<ZanaMissionElement>(1952 + PatchOffset);

	public BetryalElement BetryalUi => ReadObjectAt<BetryalElement>(1968 + PatchOffset);

	public HideoutSelectionElement HideoutSelection => ReadObjectAt<HideoutSelectionElement>(1976 + PatchOffset);

	public CraftingBenchElement CraftingBenchUi => ReadObjectAt<CraftingBenchElement>(1984 + PatchOffset);

	public UnveilingElement UnveilingUi => ReadObjectAt<UnveilingElement>(1992 + PatchOffset);

	public AnointingElement AnointingUi => ReadObjectAt<AnointingElement>(2024 + PatchOffset);

	public MetamorphElement MetamorphUi => ReadObjectAt<MetamorphElement>(2032 + PatchOffset);

	public LabMetamorphElement LabMetamorphUi => ReadObjectAt<LabMetamorphElement>(2040 + PatchOffset);

	public HorticraftingElement HorticraftingUi => ReadObjectAt<HorticraftingElement>(2048 + PatchOffset);

	public HeistContractElement HeistContractUi => ReadObjectAt<HeistContractElement>(2056 + PatchOffset);

	public GrandHeistContractElement GrandHeistContractUi => ReadObjectAt<GrandHeistContractElement>(2064 + PatchOffset);

	public HeistAllyEquipmentElement HeistAllyEquipmentUi => ReadObjectAt<HeistAllyEquipmentElement>(2072 + PatchOffset);

	public Element HeistBluprintUi => ReadObjectAt<Element>(2080 + PatchOffset);

	public HeisLockerElement HeisLockerUi => ReadObjectAt<HeisLockerElement>(2088 + PatchOffset);

	public RitualFavorElement RitualFavorUi => ReadObjectAt<RitualFavorElement>(2096 + PatchOffset);

	public UltimatumRewardUiElement UltimatumRewardUi => ReadObjectAt<UltimatumRewardUiElement>(2112 + PatchOffset);

	public Element ExpeditionMapUi => ReadObjectAt<Element>(2120 + PatchOffset);

	public Element ExpeditionUi => ReadObjectAt<Element>(2128 + PatchOffset);

	public ExpeditionLockerUiElement ExpeditionLockerUi => ReadObjectAt<ExpeditionLockerUiElement>(2136 + PatchOffset);

	public Element ItemBxPannel => ReadObjectAt<Element>(2144 + PatchOffset);

	public Element MirroredTablePannel => ReadObjectAt<Element>(2152 + PatchOffset);

	public Element ReflectionPannel => ReadObjectAt<Element>(2160 + PatchOffset);

	public SanctumArchivesElement SanctumArchives => ReadObjectAt<SanctumArchivesElement>(2168 + PatchOffset);

	public Element SanctumRunReport => ReadObjectAt<Element>(2176 + PatchOffset);

	public Element SanctumParchaise => ReadObjectAt<Element>(2184 + PatchOffset);

	public Element CruciblePassiveSkillTree => ReadObjectAt<Element>(2192 + PatchOffset);

	public Element ForgeOfTheTitans => ReadObjectAt<Element>(2200 + PatchOffset);

	public Element UnknownCrucibleCraft => ReadObjectAt<Element>(2208 + PatchOffset);

	public Element MinionsDisplaydUi => ReadObjectAt<Element>(2224 + PatchOffset);

	public Element SigilsDisplayUi => ReadObjectAt<Element>(2232 + PatchOffset);

	public Element BuffsDisplayUi => ReadObjectAt<Element>(2240 + PatchOffset);

	public Element DeBuffsDisplayUi => ReadObjectAt<Element>(2248 + PatchOffset);

	public Element UarmonyGaugeDisplay => ReadObjectAt<Element>(2256 + PatchOffset);

	public PremiumStashSettingElement PremiumStashSettingUi => ReadObjectAt<PremiumStashSettingElement>(2280 + PatchOffset);

	public DisplayNoteElement DisplayNoteUI => ReadObjectAt<DisplayNoteElement>(2288 + PatchOffset);

	public SplitStackUiElement SplitStackUi => ReadObjectAt<SplitStackUiElement>(2296 + PatchOffset);

	public InstanceManager InstanceManager => ReadObjectAt<InstanceManager>(2312 + PatchOffset);

	public AtlasWarningElement AtlasWarningDialog => ReadObjectAt<AtlasWarningElement>(2320 + PatchOffset);

	public Element GlobalWarningDialog => ReadObjectAt<Element>(2328 + PatchOffset);

	public ResurrectElement ResurrectPannel => ReadObjectAt<ResurrectElement>(2392 + PatchOffset);

	public MetamorphSummonElement MetamorphSummonUi => ReadObjectAt<MetamorphSummonElement>(2456 + PatchOffset);

	public ShowRitualRewardElement ShowRitualRewardButton => ReadObjectAt<ShowRitualRewardElement>(2464 + PatchOffset);

	public ToggleExplosivePlacementElement ExplosivePlacementPannel => ReadObjectAt<ToggleExplosivePlacementElement>(2472 + PatchOffset);

	public Element HideoutControlPannel => ReadObjectAt<Element>(2488 + PatchOffset);

	public Element HideoutMusicPannel => ReadObjectAt<Element>(2496 + PatchOffset);

	public Element EnteringAreaMessage => ReadObjectAt<Element>(2520 + PatchOffset);

	public NotificationHudElement NotificationHud => ReadObjectAt<NotificationHudElement>(2528 + PatchOffset);

	public SkillGemHudElement SkillGemHud => ReadObjectAt<SkillGemHudElement>(2608 + PatchOffset);

	public BlightElement BlightUI => ReadObjectAt<BlightElement>(2752 + PatchOffset);

	public Element DeiriumRewardUi => ReadObjectAt<Element>(2776 + PatchOffset);

	public HeistAlertLevelElement HeistAlertLevelUi => ReadObjectAt<HeistAlertLevelElement>(2784 + PatchOffset);

	public Element ObjectsOnGround => ReadObjectAt<Element>(1576 + PatchOffset).Children[0];

	internal long ObjectsOnGroundAddress => base.M.ReadLong(base.Address + 1616L + PatchOffset);

	public ItemsOnGroundLabelElement ItemsOnGroundLabelElement => ReadObjectAt<ItemsOnGroundLabelElement>(1576 + PatchOffset);

	public IEnumerable<ItemsOnGroundLabelElement> ItemsOnGroundLabels => ItemsOnGroundLabelElement.Children;

	[Obsolete("Deprecated, not to be used.", false)]
	public ItemOnGroundTooltip ItemOnGroundTooltip => ReadObjectAt<ItemOnGroundTooltip>(2792 + PatchOffset);

	public List<Tuple<Quest, int>> GetUncompletedQuests
	{
		get
		{
			List<Tuple<long, int>> source = base.M.ReadDoublePointerIntList(base.M.ReadLong(base.Address + 592L));
			return (from x in source
				where x.Item2 > 0
				select new Tuple<Quest, int>(GameController.Instance.Files.Quests.GetByAddress(x.Item1), x.Item2)).ToList();
		}
	}

	public List<Tuple<Quest, int>> GetCompletedQuests
	{
		get
		{
			List<Tuple<long, int>> source = base.M.ReadDoublePointerIntList(base.M.ReadLong(base.Address + 592L));
			return (from x in source
				where x.Item2 == 0
				select new Tuple<Quest, int>(GameController.Instance.Files.Quests.GetByAddress(x.Item1), x.Item2)).ToList();
		}
	}

	public Dictionary<string, KeyValuePair<Quest, QuestState>> GetQuestStates
	{
		get
		{
			Dictionary<string, KeyValuePair<Quest, QuestState>> dictionary = new Dictionary<string, KeyValuePair<Quest, QuestState>>();
			foreach (Tuple<Quest, int> getQuest in GetQuests)
			{
				if (getQuest != null && !(getQuest.Item1 == null))
				{
					QuestState questState = GameController.Instance.Files.QuestStates.GetQuestState(getQuest.Item1.Id, getQuest.Item2);
					if (!(questState == null) && !dictionary.ContainsKey(getQuest.Item1.Id))
					{
						dictionary.Add(getQuest.Item1.Id, new KeyValuePair<Quest, QuestState>(getQuest.Item1, questState));
					}
				}
			}
			return dictionary.OrderBy((KeyValuePair<string, KeyValuePair<Quest, QuestState>> x) => x.Key).ToDictionary((KeyValuePair<string, KeyValuePair<Quest, QuestState>> Key) => Key.Key, (KeyValuePair<string, KeyValuePair<Quest, QuestState>> Value) => Value.Value);
		}
	}

	public List<Tuple<Quest, int>> GetQuests
	{
		get
		{
			List<Tuple<long, int>> source = base.M.ReadDoublePointerIntList(base.M.ReadLong(base.Address + 592L));
			return source.Select((Tuple<long, int> x) => new Tuple<Quest, int>(GameController.Instance.Files.Quests.GetByAddress(x.Item1), x.Item2)).ToList();
		}
	}

	internal Vector2i ElementClickLocation(Element element)
	{
		if (element == null)
		{
			return Vector2i.Zero;
		}
		float num = (element.X + element.Width / 2f) * element.Scale;
		float num2 = (element.Y + element.Height / 2f) * element.Scale;
		Element parent = element.Parent;
		while (parent.Address != 0L && parent.IdLabel != "root")
		{
			num += parent.X * parent.Scale;
			num2 += parent.Y * parent.Scale;
			parent = parent.Parent;
		}
		return new Vector2i((int)num, (int)num2);
	}
}
