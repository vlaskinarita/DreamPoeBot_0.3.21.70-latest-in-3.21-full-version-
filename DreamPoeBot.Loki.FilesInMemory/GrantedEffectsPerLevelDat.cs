using System.Collections.Generic;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.FilesInMemory;

public class GrantedEffectsPerLevelDat : FileInMemory
{
	public readonly Dictionary<long, List<GrantedEffectsPerLevel>> contents = new Dictionary<long, List<GrantedEffectsPerLevel>>();

	public GrantedEffectsPerLevelDat(Memory m, long address)
		: base(m, address)
	{
		LoadItemTypes();
	}

	private void LoadItemTypes()
	{
		IEnumerable<long> enumerable = RecordAddresses();
		foreach (long item in enumerable)
		{
			GrantedEffectsPerLevel grantedEffectsPerLevel = new GrantedEffectsPerLevel
			{
				Address = item,
				GrantedEffect = new DatGrantedEffectWrapper(base.M.ReadLong(item)),
				Level = base.M.ReadInt(item + 16L),
				RequiredLevel = (int)base.M.ReadFloat(item + 20L)
			};
			long baseAddress = grantedEffectsPerLevel.GrantedEffect.BaseAddress;
			if (!contents.ContainsKey(baseAddress))
			{
				contents.Add(baseAddress, new List<GrantedEffectsPerLevel>());
			}
			contents[baseAddress].Add(grantedEffectsPerLevel);
		}
	}
}
