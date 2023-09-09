using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatArchnemesisModWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ArchnemesisModStruct
	{
		public long intptr_ModsDat;

		private long intptr_ModsDatFile;

		public int genericRewardCount;

		private int int_filler_0;

		public long intptr_GenericRewardInfo;

		private int int_filler_1;

		private int int_filler_2;

		private int int_filler_3;

		private int int_filler_4;

		private long intptr_NameUnknown;

		private long intptr_ArtName;

		private byte byte_0;

		private byte byte_1;

		private long intptr_ArchnemesisModVisualDat;

		private long intptr_ArchnemesisModVisualDatFile;

		private long intptr_2;

		private long intptr_3;

		private long intptr_StringMonsterMod;

		private long intptr_AchievementItemDat;

		private long intptr_AchievementItemDatFile;

		private int int_filler_5;
	}

	private Memory M = LokiPoe.Memory;

	internal ArchnemesisModStruct _archnemesisModStruct { get; set; }

	public DatModsWrapper Mod { get; set; }

	public List<string> RewardTypes { get; set; }

	public DatArchnemesisModWrapper(ArchnemesisModStruct archnemesisModStruct)
	{
		_archnemesisModStruct = archnemesisModStruct;
		DatModsWrapper.Struct316 native = M.FastIntPtrToStruct<DatModsWrapper.Struct316>(_archnemesisModStruct.intptr_ModsDat);
		Mod = new DatModsWrapper(native, -1);
		List<string> list = new List<string>();
		for (int i = 0; i < archnemesisModStruct.genericRewardCount; i++)
		{
			list.Add(M.ReadStringU(M.ReadLong(archnemesisModStruct.intptr_GenericRewardInfo, default(long))));
		}
		RewardTypes = list;
	}
}
