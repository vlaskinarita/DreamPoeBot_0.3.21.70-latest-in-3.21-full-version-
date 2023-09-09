using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatLabyrinthTrialWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct313
	{
		public Struct243 struct243_0;

		public int int_Id;

		public int int_1;

		public int int_2;

		private Struct243 struct243_1;

		public long intptr_0;

		public long intptr_1;

		private long intptr_3;

		private long intptr_4;
	}

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct313 Struct313_0 { get; set; }

	public int Id { get; }

	public DatWorldAreaWrapper WorldArea { get; }

	internal DatLabyrinthTrialWrapper(Struct313 native, int index)
	{
		Struct313_0 = native;
		Index = index;
		Id = Struct313_0.int_Id;
		WorldArea = Dat.GetWorldArea(Struct313_0.struct243_0.intptr_1, bool_0: true);
	}

	public override string ToString()
	{
		Struct313 struct313_ = Struct313_0;
		StringBuilder stringBuilder = new StringBuilder();
		DatWorldAreaWrapper worldArea = Dat.GetWorldArea(struct313_.struct243_0.intptr_1, bool_0: true);
		stringBuilder.AppendLine(worldArea.ToString());
		stringBuilder.AppendLine($"Id: {struct313_.int_Id}");
		stringBuilder.AppendLine($"_0C: {struct313_.int_1}");
		stringBuilder.AppendLine($"_10: {struct313_.int_2}");
		stringBuilder.AppendLine($"_1C: {ExternalProcessMemory_0.ReadStringU(struct313_.intptr_0)}");
		stringBuilder.AppendLine($"_20: {ExternalProcessMemory_0.ReadStringU(struct313_.intptr_1)}");
		return stringBuilder.ToString();
	}
}
