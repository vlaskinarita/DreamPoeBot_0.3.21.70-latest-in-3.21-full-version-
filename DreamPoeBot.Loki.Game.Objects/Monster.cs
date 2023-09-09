using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.NativeWrappers;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Monster : Actor
{
	private PerFrameCachedValue<bool> perFrameCachedValue_10;

	private bool? nullable_23;

	public bool IsAliveHostile
	{
		get
		{
			if (base.Reaction == Reaction.Enemy)
			{
				return !base.IsDead;
			}
			return false;
		}
	}

	public new bool CorpseUsable
	{
		get
		{
			Life component = base.Entity.GetComponent<Life>();
			if (component == null)
			{
				return false;
			}
			return component.CorpseUsable;
		}
	}

	public bool IsImprisoned
	{
		get
		{
			if (!nullable_23.HasValue)
			{
				if (perFrameCachedValue_10 == null)
				{
					perFrameCachedValue_10 = new PerFrameCachedValue<bool>(method_16);
				}
				return perFrameCachedValue_10;
			}
			return nullable_23.Value;
		}
	}

	public bool IsActive
	{
		get
		{
			if (base.Reaction == Reaction.Enemy && !base.IsDead && base.IsTargetable && !base.Invincible)
			{
				return !IsHidden;
			}
			return false;
		}
	}

	public bool IsActiveDead
	{
		get
		{
			if (base.Reaction == Reaction.Enemy && base.IsDead && base.IsTargetable)
			{
				return !IsHidden;
			}
			return false;
		}
	}

	public bool IsHidden => GetStat(StatTypeGGG.IsHiddenMonster) != 0;

	public Rarity Rarity
	{
		get
		{
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				return component.Rarity;
			}
			return Rarity.Normal;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> AffixStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return dictionary;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				int num = -1;
				StatsDat.StatRecord[] statNames = affix.StatNames;
				foreach (StatsDat.StatRecord statRecord in statNames)
				{
					num++;
					if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
					{
						dictionary.Add(result, affix.StatRange[num].Min);
					}
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<ModsDat.ModRecord> Affixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					list.Add(affix);
				}
				return list;
			}
			return list;
		}
	}

	public IEnumerable<ModsDat.ModRecord> ExplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					if (!affix.InternalName.Contains("Implicit"))
					{
						list.Add(affix);
					}
				}
				return list;
			}
			return list;
		}
	}

	public IEnumerable<ModsDat.ModRecord> ImplicitAffixes
	{
		get
		{
			List<ModsDat.ModRecord> list = new List<ModsDat.ModRecord>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return list;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				if (affix.InternalName.Contains("Implicit"))
				{
					list.Add(affix);
				}
			}
			return list;
		}
	}

	public Dictionary<StatTypeGGG, int> ImplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return dictionary;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				if (!affix.InternalName.Contains("Implicit"))
				{
					continue;
				}
				int num = -1;
				StatsDat.StatRecord[] statNames = affix.StatNames;
				foreach (StatsDat.StatRecord statRecord in statNames)
				{
					num++;
					if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
					{
						if (!dictionary.ContainsKey(result))
						{
							dictionary.Add(result, affix.StatRange[num].Min);
						}
						else
						{
							dictionary[result] += affix.StatRange[num].Min;
						}
					}
				}
			}
			return dictionary;
		}
	}

	public Dictionary<StatTypeGGG, int> ExplicitStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (component == null)
			{
				return dictionary;
			}
			foreach (ModsDat.ModRecord affix in component.Affixes)
			{
				if (affix.InternalName.Contains("Implicit"))
				{
					continue;
				}
				int num = -1;
				StatsDat.StatRecord[] statNames = affix.StatNames;
				foreach (StatsDat.StatRecord statRecord in statNames)
				{
					num++;
					if (statRecord != null && Enum.TryParse<StatTypeGGG>(statRecord.StatTypeGGG, out var result))
					{
						if (!dictionary.ContainsKey(result))
						{
							dictionary.Add(result, affix.StatRange[num].Min);
						}
						else
						{
							dictionary[result] += affix.StatRange[num].Min;
						}
					}
				}
			}
			return dictionary;
		}
	}

	public bool IsCursable
	{
		get
		{
			if (LokiPoe.LocalData.MapMods.TryGetValue(StatTypeGGG.MapMonstersAreImmuneToCurses, out var value) && value != 0)
			{
				return false;
			}
			if (Affixes.FirstOrDefault((ModsDat.ModRecord x) => x.InternalName == "MonsterImmuneToCurses1") != null)
			{
				return false;
			}
			if (Affixes.FirstOrDefault((ModsDat.ModRecord x) => x.InternalName == "MonsterImplicitImmuneToCurses1") == null)
			{
				if (GetStat(StatTypeGGG.ImmuneToCurses) == 1)
				{
					return false;
				}
				if (GetStat(StatTypeGGG.Hexproof) != 1)
				{
					if (LokiPoe.LocalData.MapMods.TryGetValue(StatTypeGGG.MapMonstersAreHexproof, out value) && value != 0)
					{
						return false;
					}
					return true;
				}
				return false;
			}
			return false;
		}
	}

	public bool HasSpeciesBeenNettedAlready => false;

	public bool IsSpeciesCapturableForBestiary => false;

	public bool HasBestiaryEnragedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_enraged);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryTrappedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_trapped);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryCapturedAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_captured);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool HasBestiaryDisappearingAura
	{
		get
		{
			Aura buff = GetBuff(BuffDefinitionsEnum.capture_monster_disappearing);
			if (buff != null && buff.Charges > 0)
			{
				return buff.TimeLeft.TotalMilliseconds > 0.0;
			}
			return false;
		}
	}

	public bool CannotDie
	{
		get
		{
			List<Aura> list = base.Auras.Where((Aura x) => x.InternalName == "monster_aura_cannot_die").ToList();
			Aura aura = list.FirstOrDefault();
			if (!(aura != null))
			{
				return false;
			}
			if (base.Id == aura.CasterId)
			{
				return list.Count != 1;
			}
			return true;
		}
	}

	public List<string> Tags => base.Components.MonsterComponent.Tags;

	public string MonsterTypeId => base.Components.MonsterComponent.MonsterTypeId;

	public string MonsterTypeMetadata => base.Components.MonsterComponent.MonsterTypeMetadata;

	public int Level => base.Components.MonsterComponent.Level;

	public string BaseResistenceName => base.Components.MonsterComponent.BaseResistenceName;

	public bool IsMapBoss
	{
		get
		{
			if (Rarity == Rarity.Unique)
			{
				return Affixes.Any((ModsDat.ModRecord x) => x.Category == "MonsterMapBoss");
			}
			return false;
		}
	}

	public bool DropMetamorphosisIngredient
	{
		get
		{
			IEnumerable<MinimapIconWrapper> source = LokiPoe.InstanceInfo.MinimapIcons.Where((MinimapIconWrapper x) => x != null && x.MinimapIcon != null && x.MinimapIcon.Name == "MetamorphosisBoss" && x.NetworkObject != null);
			return source.Any((MinimapIconWrapper x) => x.NetworkObject.Id == base.Id);
		}
	}

	internal Monster(EntityWrapper entity)
		: base(entity)
	{
	}

	public new string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Monster:]");
		if (base.CurrentAction == null)
		{
			stringBuilder.AppendLine($"\t[CurrentAction] None");
		}
		else if (base.CurrentAction.Skill == null)
		{
			stringBuilder.AppendLine($"\t\t-NoName [NoInternalName], Destination: {base.CurrentAction.Destination.X},{base.CurrentAction.Destination.Y}");
		}
		else
		{
			stringBuilder.AppendLine($"\t\t-{base.CurrentAction.Skill.Name} [{base.CurrentAction.Skill.InternalName}], Destination: {base.CurrentAction.Destination.X},{base.CurrentAction.Destination.Y}");
		}
		if (base.Components.ActorComponent != null)
		{
			stringBuilder.AppendLine($"\t[AvailableSkills]");
			foreach (Skill availableSkill in base.AvailableSkills)
			{
				stringBuilder.AppendLine($"\t\t{availableSkill.Name} ({availableSkill.InternalName})");
				stringBuilder.AppendLine($"\t\t\tStats:");
				foreach (KeyValuePair<StatTypeGGG, int> stat in availableSkill.Stats)
				{
					stringBuilder.AppendLine($"\t\t\t\t{stat.Key.ToString()}: {stat.Value}");
				}
			}
		}
		if (base.Components.BuffsComponent != null)
		{
			stringBuilder.AppendLine($"\t[Buffs]");
			foreach (Aura aura in base.Auras)
			{
				stringBuilder.AppendLine($"\t\tName: {aura.Name} ");
				stringBuilder.AppendLine($"\t\tInternalName: {aura.InternalName} ");
				stringBuilder.AppendLine($"\t\tDescription: {aura.Description} ");
			}
		}
		stringBuilder.AppendLine($"\t[CorpseUsable] {CorpseUsable}");
		stringBuilder.AppendLine($"\t[IsImprisoned] {IsImprisoned}");
		stringBuilder.AppendLine($"\t[IsActive] {IsActive}");
		stringBuilder.AppendLine($"\t[IsTargetable] {base.IsTargetable}");
		stringBuilder.AppendLine($"\t[Invincible] {base.Invincible}");
		stringBuilder.AppendLine($"\t[IsImprisoned] {IsImprisoned}");
		stringBuilder.AppendLine($"\t[Health] {base.Health}");
		stringBuilder.AppendLine($"\t[IsDead] {base.IsDead}");
		stringBuilder.AppendLine($"\t[IsActiveDead] {IsActiveDead}");
		stringBuilder.AppendLine($"\t[IsHidden] {IsHidden}");
		stringBuilder.AppendLine($"\t[Rarity] {Rarity}");
		stringBuilder.AppendLine($"\t[IsCursable] {IsCursable}");
		stringBuilder.AppendLine($"\t[CannotDie] {CannotDie}");
		stringBuilder.AppendLine($"\t[IsMapBoss] {IsMapBoss}");
		stringBuilder.AppendLine($"\t[DropMetamorphosisIngredient] {DropMetamorphosisIngredient}");
		stringBuilder.AppendLine($"\t[HasBestiaryEnragedAura] {HasBestiaryEnragedAura}");
		stringBuilder.AppendLine($"\t[HasBestiaryTrappedAura] {HasBestiaryTrappedAura}");
		stringBuilder.AppendLine($"\t[HasBestiaryCapturedAura] {HasBestiaryCapturedAura}");
		stringBuilder.AppendLine($"\t[HasBestiaryDisappearingAura] {HasBestiaryDisappearingAura}");
		stringBuilder.AppendLine($"\t[MonsterTypeId] {MonsterTypeId}");
		stringBuilder.AppendLine($"\t[MonsterTypeMetadata] {MonsterTypeMetadata}");
		stringBuilder.AppendLine($"\t[Tags]");
		foreach (string tag in Tags)
		{
			stringBuilder.AppendLine($"\t\t{tag}");
		}
		stringBuilder.AppendLine($"\t[ImplicitStats]");
		foreach (KeyValuePair<StatTypeGGG, int> implicitStat in ImplicitStats)
		{
			stringBuilder.AppendLine($"\t\t{implicitStat.Key.ToString()} : {implicitStat.Value}");
		}
		stringBuilder.AppendLine($"\t[ExplicitStats]");
		foreach (KeyValuePair<StatTypeGGG, int> explicitStat in ExplicitStats)
		{
			stringBuilder.AppendLine($"\t\t{explicitStat.Key.ToString()} : {explicitStat.Value}");
		}
		return stringBuilder.ToString();
	}

	private bool method_16()
	{
		if (!nullable_23.HasValue)
		{
			foreach (Monolith item in LokiPoe.ObjectManager.GetObjectsByType<Monolith>().ToList())
			{
				NetworkObject childNetworkObject = item.ChildNetworkObject;
				if (childNetworkObject != null && childNetworkObject.Id == base.Id)
				{
					return true;
				}
			}
			nullable_23 = false;
		}
		return nullable_23.Value;
	}
}
