using System;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatIncursionArchitectWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct311
	{
		public Struct243 struct243_0;

		public int int_0;
	}

	public int Index { get; private set; }

	public string Name { get; private set; }

	public string Metadata { get; private set; }

	public int MonsterId { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	public long BaseAddress { get; private set; }

	internal Struct311 Struct311_0 { get; set; }

	private void method_0(Struct311 struct311_1)
	{
		Struct311_0 = struct311_1;
		Dat.Runtime.DatMonsterVarietyWrapper2 datMonsterVarietyWrapper = new Dat.Runtime.DatMonsterVarietyWrapper2(ExternalProcessMemory_0.FastIntPtrToStruct<Dat.Runtime.DatMonsterVarietyWrapper2.Struct286>(struct311_1.struct243_0.intptr_1), -1);
		Metadata = datMonsterVarietyWrapper.Metadata;
		Name = datMonsterVarietyWrapper.Name;
		MonsterId = datMonsterVarietyWrapper.MonsterId;
	}

	internal DatIncursionArchitectWrapper(long address, Struct311 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatIncursionArchitectWrapper(long ptr)
	{
		if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
		{
			throw new Exception("This client version is not supported.");
		}
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct311>(BaseAddress));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[{Index}] [{MonsterId}] {Metadata}: {Name}");
		return stringBuilder.ToString();
	}
}
