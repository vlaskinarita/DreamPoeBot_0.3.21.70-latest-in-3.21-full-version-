using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Structures.ns19;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Struct244Inventory
{
	public readonly InventoryType inventoryType_0;

	public readonly InventorySlot inventorySlot_0;

	private readonly byte hasSingleItemOverride;

	private readonly byte byte_1;

	public readonly byte isRequested;

	private readonly byte byte_3;

	public readonly int cols;

	public readonly int rows;

	private readonly int int_4;

	private readonly long intptr_0;

	private readonly uint uint_0;

	private readonly uint uint_1;

	private readonly uint uint_2;

	private readonly int uint_3;

	public readonly NativeVector nativeVector_ItemPlacementGraph;

	public readonly NativeMap nativeMap_ItemMap;
}
