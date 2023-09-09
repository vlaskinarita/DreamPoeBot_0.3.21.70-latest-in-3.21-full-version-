using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class BlightTower : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct BlightTowerStructure
	{
		public long vTable;

		public long intptr1;

		public long intptr2;

		public long intptr3;

		public long intptr4;

		public long intptr5;

		public long intptr6;

		public long intptr7;

		public int int1;

		public int int2;

		public long intptr8;

		public long intptr9;

		public long end;
	}

	private PerFrameCachedValue<BlightTowerStructure> perFrameCachedValue;

	internal BlightTowerStructure blightTowerStructure
	{
		get
		{
			if (perFrameCachedValue == null)
			{
				perFrameCachedValue = new PerFrameCachedValue<BlightTowerStructure>(GetStructure);
			}
			return perFrameCachedValue;
		}
	}

	private BlightTowerStructure GetStructure()
	{
		return base.M.FastIntPtrToStruct<BlightTowerStructure>(base.Address);
	}
}
