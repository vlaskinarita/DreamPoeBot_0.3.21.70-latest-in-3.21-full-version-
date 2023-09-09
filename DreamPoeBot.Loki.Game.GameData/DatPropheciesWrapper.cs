using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatPropheciesWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct321
	{
		public long intptr_0Id;

		public long intptr_1Description;

		public int int_0ProphecyId;

		public long intptr_2Name;

		public long intptr_3FlavourText;

		public int int_1ClientStringsount;

		public int unusedInt0;

		public long intptr_4ClientStringsPtr;

		public long intptr_5;

		public long intptr_6;

		public int unusedInt1;

		public int int_2;

		public byte byte_0;

		public int unusedInt2;

		public int int_3SealCost;

		public long unusedLong0;
	}

	public int Index { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct321 Struct321_0 { get; set; }

	public string Id { get; private set; }

	public string Name { get; private set; }

	public string Description { get; private set; }

	public int ProphecyId { get; private set; }

	public int SealCost { get; private set; }

	public string FlavourText { get; private set; }

	public List<DatClientStringWrapper> ClientStrings { get; private set; }

	public long BaseAddress { get; private set; }

	private void method_0(Struct321 struct321_1)
	{
		Struct321_0 = struct321_1;
		Id = ExternalProcessMemory_0.ReadStringU(Struct321_0.intptr_0Id);
		Name = ExternalProcessMemory_0.ReadStringU(Struct321_0.intptr_2Name);
		Description = ExternalProcessMemory_0.ReadStringU(Struct321_0.intptr_1Description);
		ProphecyId = Struct321_0.int_0ProphecyId;
		SealCost = Struct321_0.int_3SealCost;
		FlavourText = ExternalProcessMemory_0.ReadStringU(Struct321_0.intptr_3FlavourText);
		ClientStrings = new List<DatClientStringWrapper>();
		Struct243[] array = ExternalProcessMemory_0.ReadStructure243StructsArray<Struct243>(struct321_1.intptr_4ClientStringsPtr, Struct321_0.int_1ClientStringsount);
		for (int i = 0; i < array.Length; i++)
		{
			Struct243 @struct = array[i];
			ClientStrings.Add(Dat.smethod_30(@struct.intptr_1, bool_0: true));
		}
	}

	internal DatPropheciesWrapper(long address, Struct321 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatPropheciesWrapper(long ptr)
	{
		if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
		{
			throw new Exception("This client version is not supported.");
		}
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct321>(BaseAddress));
	}
}
