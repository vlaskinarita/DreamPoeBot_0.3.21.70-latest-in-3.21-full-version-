using System.Collections.Generic;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.Objects;

public class Player : Actor
{
	public PantheonGod PantheonMajor => base.Components.PlayerComponent.PantheonMajor;

	public PantheonGod PantheonMinor => base.Components.PlayerComponent.PantheonMinor;

	public int HideoutLevel => base.Components.PlayerComponent.HideoutLevel;

	public DatHideoutWrapper Hideout => base.Components.PlayerComponent.Hideout;

	public bool HasHideout => base.Components.PlayerComponent.HasHideout;

	public List<Prophecy> Prophecies => base.Components.PlayerComponent.Prophecies;

	public int Level => base.Components.PlayerComponent.Level;

	public CharacterClass Class => base.Components.PlayerClassComponent.Class;

	public AscendancyClass AscendencyClass => base.Components.PlayerClassComponent.AscendencyClass;

	public uint Experience => base.Components.PlayerComponent.Experience;

	public uint ExperienceNextLevel
	{
		get
		{
			if (Level == 100)
			{
				return uint.MaxValue;
			}
			return GameConstants.PlayerExperienceLevels[Level + 1];
		}
	}

	public uint ExperienceLastLevel => GameConstants.PlayerExperienceLevels[Level];

	public uint ExperienceGainedThisLevel
	{
		get
		{
			uint num = GameConstants.PlayerExperienceLevels[Level];
			return Experience - num;
		}
	}

	public uint ExperienceLeftThisLevel => ExperienceNextLevel - Experience;

	public float ExperiencePercent
	{
		get
		{
			uint experienceNextLevel = ExperienceNextLevel;
			uint experience = Experience;
			if (experienceNextLevel == experience)
			{
				return 100f;
			}
			uint experienceLastLevel = ExperienceLastLevel;
			uint num = experienceNextLevel - experienceLastLevel;
			return (float)((experience - experienceLastLevel) / num) * 100f;
		}
	}

	internal Player(EntityWrapper entry)
		: base(entry)
	{
	}

	public Player(Entity player)
		: base(player)
	{
		EntityWrapper entity = new EntityWrapper(player.Address);
		base._entity = entity;
	}

	public bool IsAscendencyTrialCompleted(string areaId)
	{
		return base.Components.PlayerComponent.IsAscendencyTrialCompleted(areaId);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Player]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Entity.Address:X}");
		stringBuilder.AppendLine($"\tId: {base.Id}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tType: {base.Type}");
		stringBuilder.AppendLine($"\tPosition: {base.Position}");
		stringBuilder.AppendLine($"\tClass: {Class}");
		stringBuilder.AppendLine($"\tLevel: {Level}");
		stringBuilder.AppendLine($"\tExperience: {Experience}");
		stringBuilder.AppendLine($"\tPantheonMajor: {PantheonMajor}");
		stringBuilder.AppendLine($"\tPantheonMinor: {PantheonMinor}");
		stringBuilder.AppendLine($"\tHasHideout: {HasHideout}");
		DatHideoutWrapper hideout = Hideout;
		if (hideout != null)
		{
			stringBuilder.AppendLine($"\tHideout: {hideout.Id}");
			stringBuilder.AppendLine($"\tHideoutLevel: {HideoutLevel}");
		}
		stringBuilder.AppendLine($"\t[Stats]");
		foreach (KeyValuePair<StatTypeGGG, int> stat in base.Stats)
		{
			stringBuilder.AppendLine($"\t\t{stat.Key}: {stat.Value}");
		}
		foreach (Aura aura in base.Auras)
		{
			stringBuilder.AppendLine(aura.ToString());
		}
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftHandWeaponVisual", base.LeftHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightHandWeaponVisual", base.RightHandWeaponVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "ChestVisual", base.ChestVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "HelmVisual", base.HelmVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "GlovesVisual", base.GlovesVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BootsVisual", base.BootsVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "UnknownVisual", base.UnknownVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "LeftRingVisual", base.LeftRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "RightRingVisual", base.RightRingVisual));
		stringBuilder.AppendLine(string.Format("\t{0}: {1}", "BeltVisual", base.BeltVisual));
		string[] labyrinthTrialAreaIds = LokiPoe.LabyrinthTrialAreaIds;
		foreach (string text in labyrinthTrialAreaIds)
		{
			stringBuilder.AppendLine($"\t{text}: {IsAscendencyTrialCompleted(text)}");
		}
		return stringBuilder.ToString();
	}
}
