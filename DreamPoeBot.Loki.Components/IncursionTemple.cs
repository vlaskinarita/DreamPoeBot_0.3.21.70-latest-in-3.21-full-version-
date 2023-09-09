using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Components;

public class IncursionTemple : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ChronicleofAtzoatlStructure
	{
		public long vTable;

		public long intptr_Owner;

		public long intptr_0;

		public int AreaLevel;

		public int int_0;

		public Struct_rooms Rooms;
	}

	[StructLayout(LayoutKind.Sequential, Size = 22)]
	[UnsafeValueType]
	public struct Struct_rooms
	{
		public unsafe fixed short byte_0[11];
	}

	private PerFrameCachedValue<ChronicleofAtzoatlStructure> perFrameCachedValue_1;

	public int AreaLevel => ChronicleofAtzoatlStructure_0.AreaLevel;

	internal ChronicleofAtzoatlStructure ChronicleofAtzoatlStructure_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<ChronicleofAtzoatlStructure>(() => base.M.FastIntPtrToStruct<ChronicleofAtzoatlStructure>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}
}
