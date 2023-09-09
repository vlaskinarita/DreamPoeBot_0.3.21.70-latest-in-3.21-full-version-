using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.FilesInMemory;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class MonsterVariety : RemoteMemoryObject
{
	private string varietyId;

	public int Id { get; internal set; }

	public string VarietyId
	{
		get
		{
			if (varietyId == null)
			{
				return varietyId = base.M.ReadStringU(base.M.ReadLong(base.Address));
			}
			return varietyId;
		}
	}

	public int ObjectSize => base.M.ReadInt(base.Address + 28L);

	public int MinimumAttackDistance => base.M.ReadInt(base.Address + 32L);

	public int MaximumAttackDistance => base.M.ReadInt(base.Address + 36L);

	public string ACTFile => base.M.ReadStringU(base.M.ReadLong(base.Address + 40L));

	public string AOFile => base.M.ReadStringU(base.M.ReadLong(base.Address + 48L));

	public string BaseMonsterTypeIndex => base.M.ReadStringU(base.M.ReadLong(base.Address + 56L));

	public List<ModsDat.ModRecord> Mods
	{
		get
		{
			int count = base.M.ReadInt(base.Address + 64L);
			List<long> source = base.M.ReadSecondPointerArray_Count(base.M.ReadLong(base.Address + 72L), count);
			return source.Select((long x) => GameController.Instance.Files.Mods.GetModByAddress(x)).ToList();
		}
	}

	public int ModelSizeMultiplier => base.M.ReadInt(base.Address + 100L);

	public int ExperienceMultiplier => base.M.ReadInt(base.Address + 140L);

	public int CriticalStrikeChance => base.M.ReadInt(base.Address + 172L);

	public string AISFile => base.M.ReadStringU(base.M.ReadLong(base.Address + 196L));

	public string MonsterName => base.M.ReadStringU(base.M.ReadLong(base.Address + 244L));

	public int DamageMultiplier => base.M.ReadInt(base.Address + 252L);

	public int LifeMultiplier => base.M.ReadInt(base.Address + 256L);

	public int AttackSpeed => base.M.ReadInt(base.Address + 260L);

	public override string ToString()
	{
		return "Name: " + MonsterName + ", VarietyId: " + VarietyId + ", BaseMonsterTypeIndex: " + BaseMonsterTypeIndex;
	}
}
