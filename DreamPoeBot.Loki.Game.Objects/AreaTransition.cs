using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class AreaTransition : NetworkObject
{
	public DatWorldAreaWrapper Destination
	{
		get
		{
			DreamPoeBot.Loki.Components.AreaTransition component = base._entity.GetComponent<DreamPoeBot.Loki.Components.AreaTransition>();
			if (component == null)
			{
				return null;
			}
			return component.Destination;
		}
	}

	public TransitionTypes TransitionType
	{
		get
		{
			DreamPoeBot.Loki.Components.AreaTransition component = base._entity.GetComponent<DreamPoeBot.Loki.Components.AreaTransition>();
			if (component == null)
			{
				return TransitionTypes.Unknown;
			}
			return component.TransitionType;
		}
	}

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
						dictionary.Add(result, affix.StatRange[num].Min);
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
						dictionary.Add(result, affix.StatRange[num].Min);
					}
				}
			}
			return dictionary;
		}
	}

	internal AreaTransition(EntityWrapper entry)
		: base(entry)
	{
	}
}
