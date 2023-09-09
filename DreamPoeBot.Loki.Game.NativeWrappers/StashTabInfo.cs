using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class StashTabInfo
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StashTabInfoStruct277
	{
		private readonly int int_0;

		private readonly int int_1;

		public readonly NativeStringWCustom nativeStringW_DisplayName;

		public readonly int int_InventoryId;

		public readonly uint uint_Color;

		public readonly InventoryTabPermissions inventoryTabPermissions_MembersFlag;

		public readonly InventoryTabPermissions inventoryTabPermissions_OfficersFlag;

		public readonly InventoryTabType inventoryTabType_0;

		public readonly ushort ushort_DysplayIndex;

		public readonly ushort ushort_LinkedParentId;

		public readonly InventoryTabMapSeries inventoryTabMapSeries_0;

		public readonly InventoryTabFlags inventoryTabFlags_0;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		private readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;

		private readonly byte byte_8;

		private readonly byte byte_9;

		private long intPtr_0;

		private long intPtr_1;

		private long intPtr_2;

		private readonly int int_2;

		private readonly int int_3;
	}

	private readonly StashTabInfoStruct277 struct277_0;

	private ServerStashTab stashElement { get; set; }

	public bool IsGuild { get; private set; }

	public int InventoryId => struct277_0.int_InventoryId;

	public uint Color => struct277_0.uint_Color;

	public string DisplayName => Containers.StdStringWCustom(struct277_0.nativeStringW_DisplayName);

	public ushort DisplayIndex => struct277_0.ushort_DysplayIndex;

	public ushort LinkedParentId => struct277_0.ushort_LinkedParentId;

	public bool IsPremiumFlagged => struct277_0.inventoryTabFlags_0.HasFlag(InventoryTabFlags.Premium);

	public bool IsRemoveOnlyFlagged => struct277_0.inventoryTabFlags_0.HasFlag(InventoryTabFlags.RemoveOnly);

	public bool IsPublicFlagged => struct277_0.inventoryTabFlags_0.HasFlag(InventoryTabFlags.Public);

	public bool IsHiddenFlagged => struct277_0.inventoryTabFlags_0.HasFlag(InventoryTabFlags.Hidden);

	public InventoryTabType TabType => struct277_0.inventoryTabType_0;

	public InventoryTabFlags TabFlags => struct277_0.inventoryTabFlags_0;

	public bool IsPremium => struct277_0.inventoryTabType_0 == InventoryTabType.Premium;

	public bool IsNormalTab => struct277_0.inventoryTabType_0 == InventoryTabType.Normal;

	public bool IsPremiumCurrency => struct277_0.inventoryTabType_0 == InventoryTabType.Currency;

	public bool IsPremiumEssence => struct277_0.inventoryTabType_0 == InventoryTabType.Essence;

	public bool IsPremiumQuad => struct277_0.inventoryTabType_0 == InventoryTabType.Quad;

	public bool IsPremiumDivination => struct277_0.inventoryTabType_0 == InventoryTabType.Divination;

	public bool IsPremiumMap
	{
		get
		{
			if (struct277_0.inventoryTabType_0 != InventoryTabType.Map)
			{
				return struct277_0.inventoryTabType_0 == InventoryTabType.UniqueCollection;
			}
			return true;
		}
	}

	public bool IsUniqueCollection => struct277_0.inventoryTabType_0 == InventoryTabType.UniqueCollection;

	public bool IsPremiumFragment => struct277_0.inventoryTabType_0 == InventoryTabType.Fragment;

	public bool IsPremiumDelve => struct277_0.inventoryTabType_0 == InventoryTabType.Delve;

	public bool IsPremiumBlight => struct277_0.inventoryTabType_0 == InventoryTabType.Blight;

	public bool IsPremiumMetamorph => struct277_0.inventoryTabType_0 == InventoryTabType.Metamorph;

	public bool IsPremiumDelirium => struct277_0.inventoryTabType_0 == InventoryTabType.Delirium;

	public bool IsFolder => struct277_0.inventoryTabType_0 == InventoryTabType.Folder;

	public bool IsPremiumGem => struct277_0.inventoryTabType_0 == InventoryTabType.Gem;

	public bool IsPremiumFlask => struct277_0.inventoryTabType_0 == InventoryTabType.Flask;

	public bool IsPremiumSpecial
	{
		get
		{
			if (!IsPremiumDivination && !IsPremiumEssence && !IsPremiumCurrency && !IsPremiumMap && !IsPremiumFragment && !IsPremiumDelve && !IsPremiumDelirium && !IsPremiumBlight && !IsPremiumMetamorph && !IsUniqueCollection && !IsPremiumGem)
			{
				return IsPremiumFlask;
			}
			return true;
		}
	}

	public InventoryTabPermissions MemberFlags => struct277_0.inventoryTabPermissions_MembersFlag;

	public InventoryTabPermissions OfficerFlags => struct277_0.inventoryTabPermissions_OfficersFlag;

	public InventoryTabMapSeries MapSeries => struct277_0.inventoryTabMapSeries_0;

	public StashTabInfo(ServerStashTab element, bool isGuildStashTab)
	{
		stashElement = element;
		IsGuild = isGuildStashTab;
	}

	internal StashTabInfo(StashTabInfoStruct277 native, bool isGuildStashTab)
	{
		struct277_0 = native;
		IsGuild = isGuildStashTab;
	}
}
