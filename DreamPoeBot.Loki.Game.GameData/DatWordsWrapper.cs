using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatWordsWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct326
	{
		public int int_0;

		public long intptr_0OriginalName;

		public int int_1;

		public int int_11;

		public long intptr_1;

		public int int_2;

		public int int_22;

		public long intptr_2;

		public uint uint_0Hash;

		public long intptr_3RealName;

		public long intptr_4;
	}

	private readonly List<string> list_0;

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct326 Struct326_0 { get; set; }

	public string OriginalName { get; internal set; }

	public string RealName { get; internal set; }

	public uint Hash { get; internal set; }

	public List<string> Tags => list_0;

	internal DatWordsWrapper(Struct326 native, int index)
	{
		Struct326_0 = native;
		Index = index;
		OriginalName = ExternalProcessMemory_0.ReadStringU(Struct326_0.intptr_0OriginalName);
		RealName = ExternalProcessMemory_0.ReadStringU(Struct326_0.intptr_3RealName);
		Hash = native.uint_0Hash;
		list_0 = new List<string>();
		for (int i = 0; i < Struct326_0.int_1; i++)
		{
			Struct242 @struct = ExternalProcessMemory_0.FastIntPtrToStruct<Struct242>(Struct326_0.intptr_1 + i * MarshalCache<Struct242>.Size);
			Struct271 struct2 = ExternalProcessMemory_0.FastIntPtrToStruct<Struct271>(@struct.intptr_1);
			list_0.Add(ExternalProcessMemory_0.ReadStringU(struct2.intptr_0));
		}
	}

	public override string ToString()
	{
		string format = "[{0}] {1} | {2} | {3} | {5} | {6:X} | {7:X} | {8} | {9:X}";
		return string.Format(format, Index, Struct326_0.int_0, OriginalName, string.Join("+", Tags), 0, Struct326_0.int_2, Struct326_0.intptr_2, Struct326_0.uint_0Hash, RealName, Struct326_0.intptr_4);
	}
}
