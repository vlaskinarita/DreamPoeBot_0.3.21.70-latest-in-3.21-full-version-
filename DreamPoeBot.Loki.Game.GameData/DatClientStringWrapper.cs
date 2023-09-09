using System;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatClientStringWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct Struct302
	{
		public long intptr_0;

		public long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private int int_1;

		private long intptr_4;
	}

	public int Index { get; private set; }

	public string Key { get; private set; }

	public string Value { get; private set; }

	public long BaseAddress { get; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct302 Struct302_0 { get; set; }

	private void method_0(Struct302 struct302_1)
	{
		Struct302_0 = struct302_1;
		Key = ExternalProcessMemory_0.ReadStringU(Struct302_0.intptr_0);
		Value = ExternalProcessMemory_0.ReadStringU(Struct302_0.intptr_1);
	}

	internal DatClientStringWrapper(long address, Struct302 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatClientStringWrapper(long ptr)
	{
		if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
		{
			throw new Exception("This client version is not supported.");
		}
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct302>(BaseAddress));
	}
}
