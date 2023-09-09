using System.Collections.Generic;

namespace DreamPoeBot.Loki.Game.GameData;

public class CompositeItemType
{
	internal static readonly CompositeItemType compositeItemType_0 = new CompositeItemType(ItemTypes.Unknown, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask);

	internal static readonly Dictionary<string, CompositeItemType> dictionary_0 = new Dictionary<string, CompositeItemType>
	{
		{
			"Body Armour",
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.BodyArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Helmet",
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Helmet, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Gloves",
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Gloves, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Boots",
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Boots, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Shield",
			new CompositeItemType(ItemTypes.Armor, ArmorTypes.Shield, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Dagger",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Dagger, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Claw",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Claw, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Bow",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Bow, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			"Wand",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Wand, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Staff",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Staff, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			"One Hand Axe",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Axe1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Two Hand Axe",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Axe2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			"One Hand Mace",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Mace1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Sceptre",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sceptre, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Two Hand Mace",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Mace2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			"One Hand Sword",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sword1H, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Thrusting One Hand Sword",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.SwordThrusting, WeaponHandTypes.OneHanded, FlaskTypes.NonFlask)
		},
		{
			"Two Hand Sword",
			new CompositeItemType(ItemTypes.Weapon, ArmorTypes.NonArmor, WeaponTypes.Sword2H, WeaponHandTypes.TwoHanded, FlaskTypes.NonFlask)
		},
		{
			"Belt",
			new CompositeItemType(ItemTypes.Belt, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Quiver",
			new CompositeItemType(ItemTypes.Quiver, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Ring",
			new CompositeItemType(ItemTypes.Ring, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Amulet",
			new CompositeItemType(ItemTypes.Amulet, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"LifeFlask",
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Life)
		},
		{
			"ManaFlask",
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Mana)
		},
		{
			"HybridFlask",
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Hybrid)
		},
		{
			"UtilityFlask",
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Utility)
		},
		{
			"UtilityFlaskCritical",
			new CompositeItemType(ItemTypes.Flask, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.Utility)
		},
		{
			"StackableCurrency",
			new CompositeItemType(ItemTypes.Currency, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Active Skill Gem",
			new CompositeItemType(ItemTypes.Gem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Support Skill Gem",
			new CompositeItemType(ItemTypes.Gem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Map",
			new CompositeItemType(ItemTypes.Map, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"MapFragment",
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"LabyrinthMapItem",
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"MiscMapItem",
			new CompositeItemType(ItemTypes.MapFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Jewel",
			new CompositeItemType(ItemTypes.Jewel, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"DivinationCard",
			new CompositeItemType(ItemTypes.DivinationCard, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"QuestItem",
			new CompositeItemType(ItemTypes.Quest, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"IncursionItem",
			new CompositeItemType(ItemTypes.IncursionItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"LabyrinthItem",
			new CompositeItemType(ItemTypes.LabyrinthItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"LabyrinthTrinket",
			new CompositeItemType(ItemTypes.LabyrinthItem, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Leaguestone",
			new CompositeItemType(ItemTypes.Leaguestone, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"FishingRod",
			new CompositeItemType(ItemTypes.FishingRod, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"Microtransaction",
			new CompositeItemType(ItemTypes.Microtransaction, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"HideoutDoodad",
			new CompositeItemType(ItemTypes.HideoutDoodad, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"PantheonSoul",
			new CompositeItemType(ItemTypes.PantheonSoul, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"UniqueFragment",
			new CompositeItemType(ItemTypes.UniqueFragment, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		},
		{
			"AbyssJewel",
			new CompositeItemType(ItemTypes.AbyssJewel, ArmorTypes.NonArmor, WeaponTypes.NonWeapon, WeaponHandTypes.NonWeapon, FlaskTypes.NonFlask)
		}
	};

	public ItemTypes ItemType { get; }

	public ArmorTypes ArmorType { get; }

	public WeaponTypes WeaponType { get; }

	public WeaponHandTypes WeaponHandType { get; }

	public FlaskTypes FlaskType { get; }

	internal CompositeItemType(ItemTypes itemType, ArmorTypes armorType, WeaponTypes weaponType, WeaponHandTypes weaponHandType, FlaskTypes flaskType)
	{
		ItemType = itemType;
		ArmorType = armorType;
		WeaponType = weaponType;
		WeaponHandType = weaponHandType;
		FlaskType = flaskType;
	}

	public override string ToString()
	{
		return $"Item type: {ItemType}, Armor type: {ArmorType}, Weapon type: {WeaponType}, Weapon hand type: {WeaponHandType}, Flask type: {FlaskType}";
	}
}
