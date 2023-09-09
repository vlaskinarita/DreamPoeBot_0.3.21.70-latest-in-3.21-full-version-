using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatBuffDefinitionWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct300
	{
		public long intptr_0InternalName;

		public long intptr_1Description;

		public byte byte_0IsInvisible;

		public byte byte_1IsRemovable;

		public long intptr_2Name;

		public int int_StatsCount;

		public int int_Filler;

		public long intptr_Stats;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public int int_0;

		public int int_1;

		public long long_0;

		public int int_2;

		public int int_3;

		public long long_1;

		public int int_4;

		public int int_5;

		public long long_2;

		public long long_3;

		public byte byte_5;

		public byte byte_6;

		public int int_BuffType;
	}

	public int Index { get; private set; }

	public string Desc { get; private set; }

	public string Id { get; private set; }

	public string Name { get; private set; }

	public int BuffType { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct300 Struct300_0 { get; set; }

	internal DatBuffDefinitionWrapper(Struct300 native, int index)
	{
		Struct300_0 = native;
		Index = index;
		Id = ExternalProcessMemory_0.ReadStringU(Struct300_0.intptr_0InternalName);
		Desc = ExternalProcessMemory_0.ReadStringU(Struct300_0.intptr_1Description);
		Name = ExternalProcessMemory_0.ReadStringU(Struct300_0.intptr_2Name);
		BuffType = Struct300_0.int_BuffType;
	}
}
