using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Elements;

public class BlightTowerOption : Element
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct TowerOptionStructure
	{
		public readonly long intptrId;

		public readonly long intptrName;

		public readonly long intptrDescription;

		public readonly long intptrIcon;
	}

	private PerFrameCachedValue<TowerOptionStructure> perFrameCachedValue;

	public string Id => base.M.ReadStringU(towerOptionStructure.intptrId);

	public string Name => base.M.ReadStringU(towerOptionStructure.intptrName);

	public string Description => base.M.ReadStringU(towerOptionStructure.intptrDescription);

	public string Icon => base.M.ReadStringU(towerOptionStructure.intptrIcon);

	public int Cost => base.M.ReadShort(base.Address + 1288L);

	public Vector2i ElementClickLocation => CenterClickLocation();

	public bool IsVisibleInGameWindow
	{
		get
		{
			Vector2i elementClickLocation = ElementClickLocation;
			Interop.RectWin32 client = LokiPoe.ClientWindowInfo.Client;
			if (elementClickLocation.X >= client.Left - 5 && elementClickLocation.X <= client.Right - 5 && elementClickLocation.Y >= client.Top - 5 && elementClickLocation.Y <= client.Bottom - 5)
			{
				return true;
			}
			return false;
		}
	}

	internal TowerOptionStructure towerOptionStructure
	{
		get
		{
			if (perFrameCachedValue == null)
			{
				perFrameCachedValue = new PerFrameCachedValue<TowerOptionStructure>(GetStructure);
			}
			return perFrameCachedValue;
		}
	}

	private TowerOptionStructure GetStructure()
	{
		return base.M.FastIntPtrToStruct<TowerOptionStructure>(base.M.ReadLong(base.Address + 1272L));
	}
}
