using System;
using System.Collections.Generic;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.FilesInMemory;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.Objects;

public class Chest : NetworkObject
{
	private PerFrameCachedValue<int> perFrameCachedValue_5;

	private PerFrameCachedValue<bool> perFrameCachedValue_6;

	private PerFrameCachedValue<bool> perFrameCachedValue_7;

	private PerFrameCachedValue<bool> perFrameCachedValue_8;

	private PerFrameCachedValue<bool> perFrameCachedValue_9;

	private PerFrameCachedValue<bool> perFrameCachedValue_10;

	private PerFrameCachedValue<bool> perFrameCachedValue_11;

	private PerFrameCachedValue<bool> perFrameCachedValue_12;

	private PerFrameCachedValue<int> perFrameCachedValue_13;

	private PerFrameCachedValue<bool> perFrameCachedValue_14;

	private PerFrameCachedValue<bool> perFrameCachedValue_15;

	private PerFrameCachedValue<bool> perFrameCachedValue_16;

	private PerFrameCachedValue<bool> perFrameCachedValue_17;

	private PerFrameCachedValue<Rarity> perFrameCachedValue_18;

	public int Quality
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<int>(method_8);
			}
			return perFrameCachedValue_5;
		}
	}

	public bool IsIdentified
	{
		get
		{
			if (perFrameCachedValue_6 == null)
			{
				perFrameCachedValue_6 = new PerFrameCachedValue<bool>(method_9);
			}
			return perFrameCachedValue_6;
		}
	}

	public bool IsCorrupted
	{
		get
		{
			if (perFrameCachedValue_7 == null)
			{
				perFrameCachedValue_7 = new PerFrameCachedValue<bool>(method_10);
			}
			return perFrameCachedValue_7;
		}
	}

	public bool IsOpened
	{
		get
		{
			if (perFrameCachedValue_8 == null)
			{
				perFrameCachedValue_8 = new PerFrameCachedValue<bool>(method_11);
			}
			return perFrameCachedValue_8;
		}
	}

	public bool IsLocked
	{
		get
		{
			if (perFrameCachedValue_9 == null)
			{
				perFrameCachedValue_9 = new PerFrameCachedValue<bool>(method_12);
			}
			return perFrameCachedValue_9;
		}
	}

	public bool IsVaalVessel
	{
		get
		{
			if (perFrameCachedValue_10 == null)
			{
				perFrameCachedValue_10 = new PerFrameCachedValue<bool>(method_13);
			}
			return perFrameCachedValue_10;
		}
	}

	public bool IsStrongBox
	{
		get
		{
			if (perFrameCachedValue_11 == null)
			{
				perFrameCachedValue_11 = new PerFrameCachedValue<bool>(method_14);
			}
			return perFrameCachedValue_11;
		}
	}

	public bool IsStompable
	{
		get
		{
			if (perFrameCachedValue_12 == null)
			{
				perFrameCachedValue_12 = new PerFrameCachedValue<bool>(method_15);
			}
			return perFrameCachedValue_12;
		}
	}

	public int DropSlots
	{
		get
		{
			if (perFrameCachedValue_13 == null)
			{
				perFrameCachedValue_13 = new PerFrameCachedValue<int>(method_16);
			}
			return perFrameCachedValue_13;
		}
	}

	public bool OpensOnDamage
	{
		get
		{
			if (perFrameCachedValue_14 == null)
			{
				perFrameCachedValue_14 = new PerFrameCachedValue<bool>(method_17);
			}
			return perFrameCachedValue_14;
		}
	}

	public bool OpeningDestroys
	{
		get
		{
			if (perFrameCachedValue_15 == null)
			{
				perFrameCachedValue_15 = new PerFrameCachedValue<bool>(method_18);
			}
			return perFrameCachedValue_15;
		}
	}

	public bool AxisAligned
	{
		get
		{
			if (perFrameCachedValue_16 == null)
			{
				perFrameCachedValue_16 = new PerFrameCachedValue<bool>(method_19);
			}
			return perFrameCachedValue_16;
		}
	}

	public bool IsLarge
	{
		get
		{
			if (perFrameCachedValue_17 == null)
			{
				perFrameCachedValue_17 = new PerFrameCachedValue<bool>(method_20);
			}
			return perFrameCachedValue_17;
		}
	}

	public Rarity Rarity
	{
		get
		{
			if (perFrameCachedValue_18 == null)
			{
				perFrameCachedValue_18 = new PerFrameCachedValue<Rarity>(method_21);
			}
			return perFrameCachedValue_18;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> AffixStats
	{
		get
		{
			Dictionary<StatTypeGGG, int> dictionary = new Dictionary<StatTypeGGG, int>();
			ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
			if (!(component == null))
			{
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
			return dictionary;
		}
	}

	public IEnumerable<ModsDat.ModRecord> ExplicitAffixes
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
				if (!affix.InternalName.Contains("Implicit"))
				{
					list.Add(affix);
				}
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
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					if (affix.InternalName.Contains("Implicit"))
					{
						list.Add(affix);
					}
				}
				return list;
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
			if (!(component == null))
			{
				foreach (ModsDat.ModRecord affix in component.Affixes)
				{
					if (!affix.InternalName.Contains("Implicit"))
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
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public IEnumerable<KeyValuePair<StatTypeGGG, int>> Stats => AffixStats;

	internal Chest(EntityWrapper entity)
		: base(entity)
	{
	}

	private int method_8()
	{
		DreamPoeBot.Loki.Components.Chest component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Chest>();
		if (!(component != null))
		{
			return 0;
		}
		return component.Quality;
	}

	private bool method_9()
	{
		ObjectMagicProperties component = base._entity.GetComponent<ObjectMagicProperties>();
		if (component != null)
		{
			return component.IsIdentified;
		}
		return true;
	}

	private bool method_10()
	{
		Base baseComponent = base.Components.BaseComponent;
		if (!(baseComponent != null))
		{
			return false;
		}
		return baseComponent.IsCorrupted;
	}

	private bool method_11()
	{
		DreamPoeBot.Loki.Components.Chest component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Chest>();
		if (component == null)
		{
			return false;
		}
		return component.IsOpened;
	}

	private bool method_12()
	{
		DreamPoeBot.Loki.Components.Chest component = base._entity.GetComponent<DreamPoeBot.Loki.Components.Chest>();
		if (!(component == null))
		{
			return component.IsLocked;
		}
		return false;
	}

	private bool method_13()
	{
		return base.Type.Equals("Metadata/Chests/SideArea/SideAreaChest", StringComparison.OrdinalIgnoreCase);
	}

	private bool method_14()
	{
		return base.Type.Contains("/StrongBoxes/");
	}

	private bool method_15()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return false;
		}
		return chestComponent.Stompable;
	}

	private int method_16()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return 0;
		}
		return chestComponent.DropSlots;
	}

	private bool method_17()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return false;
		}
		return chestComponent.OpenOnDamage;
	}

	private bool method_18()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return false;
		}
		return chestComponent.OpeningDestroys;
	}

	private bool method_19()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return false;
		}
		return chestComponent.AxisAligned;
	}

	private bool method_20()
	{
		DreamPoeBot.Loki.Components.Chest chestComponent = base.Components.ChestComponent;
		if (chestComponent == null)
		{
			return false;
		}
		return chestComponent.IsLarge;
	}

	private Rarity method_21()
	{
		ObjectMagicProperties objectMagicPropertiesComponent = base.Components.ObjectMagicPropertiesComponent;
		if (!(objectMagicPropertiesComponent != null))
		{
			return Rarity.Normal;
		}
		return objectMagicPropertiesComponent.Rarity;
	}
}
