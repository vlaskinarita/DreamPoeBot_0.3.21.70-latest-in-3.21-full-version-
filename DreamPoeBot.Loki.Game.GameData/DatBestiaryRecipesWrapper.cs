using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatBestiaryRecipesWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct299
	{
		public long intptr_0Id;

		public long intptr_1Name;

		public int int_0;

		public int int_00;

		public long intptr_2;

		public long intptr_3Desc;

		public long intptr_4Action;

		public byte byte_0;

		public int int_1;

		public int int_11;

		public long intptr_5;

		public int int_2;

		public byte byte_1;
	}

	private int _struct243Size = -1;

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct299 Struct299_0 { get; set; }

	internal long IntPtr_0 { get; set; }

	public string Id { get; private set; }

	public string Name { get; private set; }

	public string Desc { get; private set; }

	public string Action { get; private set; }

	public List<int> _1D { get; private set; }

	public List<string> ComponentIds { get; private set; }

	private int Struct243Size
	{
		get
		{
			if (_struct243Size == -1)
			{
				_struct243Size = MarshalCache<Struct243>.Size;
			}
			return _struct243Size;
		}
	}

	internal DatBestiaryRecipesWrapper(long address, Struct299 native, int index)
	{
		IntPtr_0 = address;
		Struct299_0 = native;
		Index = index;
		Id = ExternalProcessMemory_0.ReadStringU(Struct299_0.intptr_0Id);
		Name = ExternalProcessMemory_0.ReadStringU(Struct299_0.intptr_1Name);
		Desc = ExternalProcessMemory_0.ReadStringU(Struct299_0.intptr_3Desc);
		Action = ExternalProcessMemory_0.ReadStringU(Struct299_0.intptr_4Action);
		_1D = new List<int>(ExternalProcessMemory_0.ReadArrayInt(Struct299_0.intptr_5, native.int_1));
		ComponentIds = new List<string>();
		Struct243[] array = ExternalProcessMemory_0.IntptrToStructArray<Struct243>(Struct299_0.intptr_2, native.int_0, Struct243Size);
		for (int i = 0; i < array.Length; i++)
		{
			Struct243 @struct = array[i];
			DatBestiaryRecipeComponentWrapper.Struct297 struct2 = ExternalProcessMemory_0.FastIntPtrToStruct<DatBestiaryRecipeComponentWrapper.Struct297>(@struct.intptr_1);
			ComponentIds.Add(ExternalProcessMemory_0.ReadStringU(struct2.intptr_0));
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}] {1} | {2} | {3} | {4} | [{5}] | [{6}] ", Index, Id, Name, Desc, Action, string.Join(", ", ComponentIds), string.Join(" ", _1D)));
		return stringBuilder.ToString();
	}
}
