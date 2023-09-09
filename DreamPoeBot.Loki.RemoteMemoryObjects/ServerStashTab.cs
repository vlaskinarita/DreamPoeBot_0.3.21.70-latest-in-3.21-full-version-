using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ServerStashTab : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct277
	{
		public readonly int int_0;

		public readonly int int_1;

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

		private readonly short ushort_0;

		private readonly short ushort_1;

		private readonly short ushort_2;

		private readonly short ushort_3;
	}

	internal const int StructSize = 64;

	private PerFrameCachedValue<Struct277> perFrameCachedValue_1;

	public string DisplayName => Containers.StdStringWCustom(struct277_0.nativeStringW_DisplayName);

	public int InventoryId => struct277_0.int_InventoryId;

	public uint Color => struct277_0.uint_Color;

	public InventoryTabPermissions inventoryMemberFlags => struct277_0.inventoryTabPermissions_MembersFlag;

	public InventoryTabPermissions inventoryOfficerFlags => struct277_0.inventoryTabPermissions_OfficersFlag;

	public InventoryTabType inventoryTabType => struct277_0.inventoryTabType_0;

	public ushort DisplayIndex => struct277_0.ushort_DysplayIndex;

	public ushort LinkedParentId => struct277_0.ushort_LinkedParentId;

	public InventoryTabMapSeries inventoryTabMapSeries => struct277_0.inventoryTabMapSeries_0;

	public InventoryTabFlags inventoryTabFlags => struct277_0.inventoryTabFlags_0;

	internal Struct277 struct277_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct277>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		Struct277 @struct = struct277_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"\t_00: {@struct.int_0}");
		stringBuilder.AppendLine($"\t_04: 0x{@struct.int_1:X}");
		stringBuilder.AppendLine($"\tDisplayName: {DisplayName}");
		stringBuilder.AppendLine($"\tDisplayIndex: {DisplayIndex}");
		stringBuilder.AppendLine($"\tLinkedParentId: {LinkedParentId}");
		stringBuilder.AppendLine($"\tColor: {Color:X}");
		stringBuilder.AppendLine($"\tType: {inventoryTabType}");
		stringBuilder.AppendLine($"\tMemberFlags: {inventoryMemberFlags}");
		stringBuilder.AppendLine($"\tOfficerFlags: {inventoryOfficerFlags}");
		stringBuilder.AppendLine($"\tMapSeries: {inventoryTabMapSeries}");
		stringBuilder.AppendLine($"\tTabFlags: {inventoryTabFlags}");
		return stringBuilder.ToString();
	}

	private Struct277 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct277>(base.Address);
	}
}
