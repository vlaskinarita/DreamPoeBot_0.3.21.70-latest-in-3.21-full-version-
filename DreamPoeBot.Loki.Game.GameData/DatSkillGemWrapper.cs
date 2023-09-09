using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatSkillGemWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct324
	{
		public readonly Struct243 struct243_0;

		private readonly Struct243 struct243_1;

		public readonly int int_Str;

		public readonly int int_Dex;

		public readonly int int_Int;

		public readonly int int_3;

		private readonly int int_4;

		public readonly long intptr_0;

		public readonly Struct243 struct243_2;

		public readonly byte byte_IsVaal;

		public readonly long intptr_1;

		private readonly Struct243 struct243_3;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly long intptr_4;

		private readonly long intptr_5;

		private readonly long intptr_6;

		private readonly long intptr_7;

		private readonly long intptr_8;

		private readonly long intptr_9;

		private readonly long intptr_10;

		private readonly long intptr_11;

		private readonly long intptr_12;

		private readonly long intptr_13;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly long intptr_14;

		private readonly long intptr_15;
	}

	private readonly List<string> list_0;

	public int Index { get; private set; }

	internal long Address { get; set; }

	internal Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	internal Struct324 Struct324_0 { get; set; }

	public DatBaseItemTypeWrapper BaseItemTypeWrapper { get; private set; }

	public DatBaseItemTypeWrapper VaalBaseItemTypeWrapper { get; private set; }

	public int StrRatio { get; private set; }

	public int DexRatio { get; private set; }

	public int IntRatio { get; private set; }

	public bool IsVaal { get; private set; }

	public SocketColor SocketColor { get; private set; }

	public string SupportsText { get; private set; }

	public List<string> Tags => list_0;

	internal DatSkillGemWrapper(long address, Struct324 native, int index)
	{
		Address = address;
		Struct324_0 = native;
		Index = index;
		StrRatio = Struct324_0.int_Str;
		DexRatio = Struct324_0.int_Dex;
		IntRatio = Struct324_0.int_Int;
		IsVaal = Struct324_0.byte_IsVaal == 1;
		BaseItemTypeWrapper = new DatBaseItemTypeWrapper(Struct324_0.struct243_0.intptr_1);
		VaalBaseItemTypeWrapper = ((Struct324_0.struct243_2.intptr_1 != 0L) ? new DatBaseItemTypeWrapper(Struct324_0.struct243_2.intptr_1) : null);
		SupportsText = ExternalProcessMemory_0.ReadStringU(Struct324_0.intptr_1);
		list_0 = new List<string>();
		for (int i = 0; i < Struct324_0.int_3; i++)
		{
			Struct242 @struct = ExternalProcessMemory_0.FastIntPtrToStruct<Struct242>(Struct324_0.intptr_0 + i * MarshalCache<Struct242>.Size);
			Struct271 struct2 = ExternalProcessMemory_0.FastIntPtrToStruct<Struct271>(@struct.intptr_1);
			list_0.Add(ExternalProcessMemory_0.ReadStringU(struct2.intptr_0));
		}
		if (list_0.Contains("intelligence"))
		{
			SocketColor = SocketColor.Blue;
		}
		else if (list_0.Contains("dexterity"))
		{
			SocketColor = SocketColor.Green;
		}
		else if (list_0.Contains("strength"))
		{
			SocketColor = SocketColor.Red;
		}
		else
		{
			SocketColor = SocketColor.None;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0} | {2}] [{3}] {1} [Adr: {4}]", BaseItemTypeWrapper.Name, SupportsText, SocketColor.ToString(), string.Join("+", Tags), Address.ToString("X")));
		return stringBuilder.ToString();
	}
}
