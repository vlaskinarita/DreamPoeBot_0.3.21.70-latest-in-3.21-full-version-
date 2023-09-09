using System;
using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatMinimapIconWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct315
	{
		public long intptr_0;

		public int int_0;

		public int int_1;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public byte byte_8;

		public byte byte_9;

		public byte byte_10;
	}

	public int Index { get; private set; }

	public string Name { get; private set; }

	public int _04 { get; private set; }

	public int _08 { get; private set; }

	public byte _0C { get; private set; }

	public byte _0D { get; private set; }

	public byte _0E { get; private set; }

	public long BaseAddress { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct315 Struct315_0 { get; set; }

	private void method_0(Struct315 struct315_1)
	{
		Struct315_0 = struct315_1;
		Name = LokiPoe.staticStringCache_0.ReadStringW(Struct315_0.intptr_0);
		if (Name == null)
		{
			Name = "";
		}
		_04 = Struct315_0.int_0;
		_08 = Struct315_0.int_1;
		_0C = Struct315_0.byte_0;
		_0D = Struct315_0.byte_1;
		_0E = Struct315_0.byte_2;
	}

	internal DatMinimapIconWrapper(long address, Struct315 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatMinimapIconWrapper(long ptr)
	{
		if (LokiPoe.ClientVersion != LokiPoe.PoeVersion.Official && LokiPoe.ClientVersion != LokiPoe.PoeVersion.OfficialSteam)
		{
			throw new Exception("This client version is not supported.");
		}
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct315>(BaseAddress));
	}
}
