using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Components;

public class Inventories : Component
{
	private NativeVector inventoryVector => LokiPoe.Memory.ReadNativeVector(base.Address + 200L);

	public InventoryVisual LeftHand => ReadVisual(0);

	public InventoryVisual RightHand => ReadVisual(1);

	public InventoryVisual Chest => ReadVisual(2);

	public InventoryVisual Helm => ReadVisual(3);

	public InventoryVisual Gloves => ReadVisual(4);

	public InventoryVisual Boots => ReadVisual(5);

	public InventoryVisual Unknown => ReadVisual(6);

	public InventoryVisual LeftRing => ReadVisual(7);

	public InventoryVisual RightRing => ReadVisual(8);

	public InventoryVisual Belt => ReadVisual(9);

	internal InventoryVisual ReadVisual(int index)
	{
		long addressPointer = LokiPoe.Memory.ReadLong(inventoryVector.First + index * 120 + 8L);
		return ReadObject<InventoryVisual>(addressPointer);
	}
}
