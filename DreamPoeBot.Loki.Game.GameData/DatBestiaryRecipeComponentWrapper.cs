using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatBestiaryRecipeComponentWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct297
	{
		public long intptr_0;

		public int int_0;

		public Struct243 struct243_0;

		public Struct243 struct243_1;

		public Struct243 struct243_2;

		public Struct243 struct243_3;

		public int int_1;

		public Struct243 struct243_4;
	}

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct297 Struct297_0 { get; set; }

	internal long IntPtr_0 { get; set; }

	public string Id { get; private set; }

	internal long IntPtr_1 { get; private set; }

	internal DatBestiaryRecipeComponentWrapper(long address, Struct297 native, int index)
	{
		IntPtr_0 = address;
		Struct297_0 = native;
		Index = index;
		Id = ExternalProcessMemory_0.ReadStringU(Struct297_0.intptr_0);
		IntPtr_1 = Struct297_0.struct243_3.intptr_1;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[{Index}] {Id}");
		return stringBuilder.ToString();
	}
}
