using System.Collections.Generic;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.FilesInMemory;

public class ItemClasses
{
	public Dictionary<string, ItemClass> contents;

	public const string StackableCurrency = "StackableCurrency";

	public const string Microtransaction = "Microtransaction";

	public const string TwoHandSword = "Two Hand Sword";

	public const string Wand = "Wand";

	public const string Dagger = "Dagger";

	public const string Claw = "Claw";

	public const string OneHandAxe = "One Hand Axe";

	public const string OneHandSword = "One Hand Sword";

	public const string ThrustingOneHandSword = "Thrusting One Hand Sword";

	public const string OneHandMace = "One Hand Mace";

	public const string Sceptre = "Sceptre";

	public const string Bow = "Bow";

	public const string Staff = "Staff";

	public const string TwoHandAxe = "Two Hand Axe";

	public const string TwoHandMace = "Two Hand Mace";

	public const string FishingRod = "FishingRod";

	public const string Ring = "Ring";

	public const string Amulet = "Amulet";

	public const string Belt = "Belt";

	public const string Shield = "Shield";

	public const string Helmet = "Helmet";

	public const string BodyArmour = "Body Armour";

	public const string Boots = "Boots";

	public const string Gloves = "Gloves";

	public const string LifeFlask = "LifeFlask";

	public const string ManaFlask = "ManaFlask";

	public const string HybridFlask = "HybridFlask";

	public const string UtilityFlaskCritical = "UtilityFlaskCritical";

	public const string UtilityFlask = "UtilityFlask";

	public const string Quiver = "Quiver";

	public const string QuestItem = "QuestItem";

	public const string LabyrinthItem = "LabyrinthItem";

	public const string IncursionItem = "IncursionItem";

	public const string ActiveSkillGem = "Active Skill Gem";

	public const string SupportSkillGem = "Support Skill Gem";

	public const string Jewel = "Jewel";

	public const string AbyssJewel = "AbyssJewel";

	public const string Map = "Map";

	public const string MapFragment = "MapFragment";

	public const string MiscMapItem = "MiscMapItem";

	public const string HideoutDoodad = "HideoutDoodad";

	public const string DivinationCard = "DivinationCard";

	public const string LabyrinthTrinket = "LabyrinthTrinket";

	public const string LabyrinthMapItem = "LabyrinthMapItem";

	public const string Leaguestone = "Leaguestone";

	public const string PantheonSoul = "PantheonSoul";

	public const string UniqueFragment = "UniqueFragment";

	public ItemClasses()
	{
		contents = new Dictionary<string, ItemClass>
		{
			{
				"LifeFlask",
				new ItemClass("Life Flasks", "Flasks")
			},
			{
				"ManaFlask",
				new ItemClass("Mana Flasks", "Flasks")
			},
			{
				"HybridFlask",
				new ItemClass("Hybrid Flasks", "Flasks")
			},
			{
				"Currency",
				new ItemClass("Currency", "Other")
			},
			{
				"Amulet",
				new ItemClass("Amulets", "Jewellery")
			},
			{
				"Ring",
				new ItemClass("Rings", "Jewellery")
			},
			{
				"Claw",
				new ItemClass("Claws", "One Handed Weapon")
			},
			{
				"Dagger",
				new ItemClass("Daggers", "One Handed Weapon")
			},
			{
				"Wand",
				new ItemClass("Wands", "One Handed Weapon")
			},
			{
				"One Hand Sword",
				new ItemClass("One Hand Swords", "One Handed Weapon")
			},
			{
				"Thrusting One Hand Sword",
				new ItemClass("Thrusting One Hand Swords", "One Handed Weapon")
			},
			{
				"One Hand Axe",
				new ItemClass("One Hand Axes", "One Handed Weapon")
			},
			{
				"One Hand Mace",
				new ItemClass("One Hand Maces", "One Handed Weapon")
			},
			{
				"Bow",
				new ItemClass("Bows", "Two Handed Weapon")
			},
			{
				"Staff",
				new ItemClass("Staves", "Two Handed Weapon")
			},
			{
				"Two Hand Sword",
				new ItemClass("Two Hand Swords", "Two Handed Weapon")
			},
			{
				"Two Hand Axe",
				new ItemClass("Two Hand Axes", "Two Handed Weapon")
			},
			{
				"Two Hand Mace",
				new ItemClass("Two Hand Maces", "Two Handed Weapon")
			},
			{
				"Active Skill Gem",
				new ItemClass("Active Skill Gems", "Gems")
			},
			{
				"Support Skill Gem",
				new ItemClass("Support Skill Gems", "Gems")
			},
			{
				"Quiver",
				new ItemClass("Quivers", "Off-hand")
			},
			{
				"Belt",
				new ItemClass("Belts", "Jewellery")
			},
			{
				"Gloves",
				new ItemClass("Gloves", "Armor")
			},
			{
				"Boots",
				new ItemClass("Boots", "Armor")
			},
			{
				"Body Armour",
				new ItemClass("Body Armours", "Armor")
			},
			{
				"Helmet",
				new ItemClass("Helmets", "Armor")
			},
			{
				"Shield",
				new ItemClass("Shields", "Off-hand")
			},
			{
				"SmallRelic",
				new ItemClass("Small Relics", "")
			},
			{
				"MediumRelic",
				new ItemClass("Medium Relics", "")
			},
			{
				"LargeRelic",
				new ItemClass("Large Relics", "")
			},
			{
				"StackableCurrency",
				new ItemClass("Stackable Currency", "")
			},
			{
				"QuestItem",
				new ItemClass("Quest Items", "")
			},
			{
				"Sceptre",
				new ItemClass("Sceptres", "One Handed Weapon")
			},
			{
				"UtilityFlask",
				new ItemClass("Utility Flasks", "Flasks")
			},
			{
				"UtilityFlaskCritical",
				new ItemClass("Critical Utility Flasks", "")
			},
			{
				"Map",
				new ItemClass("Maps", "Other")
			},
			{
				"Unarmed",
				new ItemClass("", "")
			},
			{
				"FishingRod",
				new ItemClass("Fishing Rods", "")
			},
			{
				"MapFragment",
				new ItemClass("Map Fragments", "Other")
			},
			{
				"HideoutDoodad",
				new ItemClass("Hideout Doodads", "")
			},
			{
				"Microtransaction",
				new ItemClass("Microtransactions", "")
			},
			{
				"Jewel",
				new ItemClass("Jewel", "Other")
			},
			{
				"DivinationCard",
				new ItemClass("Divination Card", "Other")
			},
			{
				"LabyrinthItem",
				new ItemClass("Labyrinth Item", "")
			},
			{
				"LabyrinthTrinket",
				new ItemClass("Labyrinth Trinket", "")
			},
			{
				"LabyrinthMapItem",
				new ItemClass("Labyrinth Map Item", "Other")
			},
			{
				"MiscMapItem",
				new ItemClass("Misc Map Items", "")
			},
			{
				"Leaguestone",
				new ItemClass("Leaguestones", "Other")
			}
		};
	}
}
