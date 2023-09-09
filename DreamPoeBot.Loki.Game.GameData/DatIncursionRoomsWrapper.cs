using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatIncursionRoomsWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct104
	{
		public long intptr_0;

		public long intptr_1;

		public int int_0;

		private int int_1;

		public long intptr_2;

		private Struct243 struct243_0;

		private long intptr_3;

		public int int_2;

		public Struct243 struct243_1;

		private long intptr_4;

		private long intptr_5;

		private long intptr_6;

		public long intptr_7;

		public long intptr_8;

		private Struct243 struct243_2;

		private int int_3;

		private int int_4;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;
	}

	private DatIncursionRoomsWrapper datIncursionRoomsWrapper_0;

	private DatIncursionArchitectWrapper datIncursionArchitectWrapper_0;

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct104 Struct104_0 { get; set; }

	public string Id { get; internal set; }

	public string Name { get; internal set; }

	public int AreaId { get; internal set; }

	public string Description { get; internal set; }

	public string Lore { get; internal set; }

	public int Tier { get; internal set; }

	public DatIncursionRoomsWrapper UpgradedRoom
	{
		get
		{
			if (datIncursionRoomsWrapper_0 == null)
			{
				if (Struct104_0.intptr_2 == 0L)
				{
					return null;
				}
				datIncursionRoomsWrapper_0 = new DatIncursionRoomsWrapper(ExternalProcessMemory_0.FastIntPtrToStruct<Struct104>(Struct104_0.intptr_2), -1);
			}
			return datIncursionRoomsWrapper_0;
		}
	}

	public DatIncursionArchitectWrapper IncursionArchitect
	{
		get
		{
			if (datIncursionArchitectWrapper_0 == null)
			{
				if (Struct104_0.struct243_1.intptr_1 == 0L)
				{
					return null;
				}
				datIncursionArchitectWrapper_0 = Dat.smethod_53(Struct104_0.struct243_1.intptr_1, bool_0: true);
			}
			return datIncursionArchitectWrapper_0;
		}
	}

	internal DatIncursionRoomsWrapper(Struct104 native, int index)
	{
		Struct104_0 = native;
		Index = index;
		Id = ExternalProcessMemory_0.ReadStringU(Struct104_0.intptr_0);
		Name = ExternalProcessMemory_0.ReadStringU(Struct104_0.intptr_1);
		AreaId = Struct104_0.int_2;
		Description = ExternalProcessMemory_0.ReadStringU(Struct104_0.intptr_8);
		Lore = ExternalProcessMemory_0.ReadStringU(Struct104_0.intptr_7);
		Tier = Struct104_0.int_0;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format($"[{Index}] [{AreaId}] {Id}: {Name} (Tier {Tier}) | {Description} | {Lore}" + ((UpgradedRoom != null) ? $" | => {UpgradedRoom.Id}: {UpgradedRoom.Name}" : "") + ((IncursionArchitect != null) ? $" | [{IncursionArchitect.MonsterId}] {IncursionArchitect.Metadata}: {IncursionArchitect.Name}" : "")));
		return stringBuilder.ToString();
	}
}
