using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.GameData;

public class ExpeditionWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ExpeditionAreaStructure
	{
		public readonly long WorldAreaAdr;

		public readonly long WorldAreaDatFile;

		public readonly int X;

		public readonly int Y;

		public int count1;

		public int unknown1;

		public long listPtr1;

		public int count2;

		public int unknown2;

		public long listPtr2;

		public byte byte1;

		public long TextAudio;

		public long CompletitionAchievements;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ExpeditionFactionStructure
	{
		public readonly long Id;

		public readonly long Name;

		public readonly long FactionFlag;
	}

	private DatWorldAreaWrapper _areaName;

	private string _faction;

	private ExpeditionSaga.ExpeditionDataStructure _expeditionStructure;

	public IEnumerable<ModAffix> ExpeditionMods
	{
		get
		{
			foreach (Mods.StructModsInfo item in Containers.StdStruct178Vector<Mods.StructModsInfo>(_expeditionStructure.Mods))
			{
				yield return new ModAffix(item);
			}
		}
	}

	public IEnumerable<string> ExpeditionAreaSpecificModsString
	{
		get
		{
			for (long i = _expeditionStructure.StringMods1.First; i < _expeditionStructure.StringMods1.Last; i += 32L)
			{
				yield return LokiPoe.Memory.ReadNativeString(i);
			}
		}
	}

	public IEnumerable<string> ExpeditionAreaSpecificModsStringExtended
	{
		get
		{
			for (long i = _expeditionStructure.StringMods2.First; i < _expeditionStructure.StringMods2.Last; i += 32L)
			{
				yield return LokiPoe.Memory.ReadNativeString(i);
			}
		}
	}

	public DatWorldAreaWrapper WorldArea
	{
		get
		{
			if (_areaName == null)
			{
				_areaName = Dat.GetWorldArea(LokiPoe.Memory.FastIntPtrToStruct<ExpeditionAreaStructure>(_expeditionStructure.ExpeditioAreaAdr).WorldAreaAdr, bool_0: true);
			}
			return _areaName;
		}
	}

	public string ExpeditionFaction
	{
		get
		{
			if (_faction == null)
			{
				ExpeditionFactionStructure expeditionFactionStructure = LokiPoe.Memory.FastIntPtrToStruct<ExpeditionFactionStructure>(_expeditionStructure.ExpeditionFactionAdr);
				_faction = LokiPoe.Memory.ReadStringU(expeditionFactionStructure.Name);
			}
			return _faction;
		}
	}

	internal ExpeditionWrapper(ExpeditionSaga.ExpeditionDataStructure expeditionStructure)
	{
		_expeditionStructure = expeditionStructure;
	}
}
