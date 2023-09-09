using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class ArchnemesisMod : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ArchnemesisWorldItemStruct
	{
		private long vTable;

		private long intptr_Owner;

		private long intptr_0;

		public long intptr_ArchnemesisModsDat;

		private long intptr_ArchnemesisModsDatFile;
	}

	private PerFrameCachedValue<ArchnemesisWorldItemStruct> perFrameCachedValue_1;

	private PerFrameCachedValue<DatArchnemesisModWrapper> perFrameCachedValue_2;

	public List<string> RewardList => PCV_ArchnemesisModStruct.RewardTypes;

	public DatModsWrapper ModWrapper => PCV_ArchnemesisModStruct.Mod;

	internal ArchnemesisWorldItemStruct PCV_ArchnemesisWorldItemStruct
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<ArchnemesisWorldItemStruct>(() => GetArchnemesisWorldItemStruct);
			}
			return perFrameCachedValue_1.Value;
		}
	}

	internal ArchnemesisWorldItemStruct GetArchnemesisWorldItemStruct => base.M.FastIntPtrToStruct<ArchnemesisWorldItemStruct>(base.Address);

	internal DatArchnemesisModWrapper PCV_ArchnemesisModStruct
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<DatArchnemesisModWrapper>(GetArchnemesisModStruct);
			}
			return perFrameCachedValue_2.Value;
		}
	}

	internal DatArchnemesisModWrapper GetArchnemesisModStruct()
	{
		return new DatArchnemesisModWrapper(base.M.FastIntPtrToStruct<DatArchnemesisModWrapper.ArchnemesisModStruct>(GetArchnemesisWorldItemStruct.intptr_ArchnemesisModsDat));
	}
}
