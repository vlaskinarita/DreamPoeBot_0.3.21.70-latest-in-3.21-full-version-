using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatDivinationCardStashTabLayoutWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct304
	{
		public long intptr_0;

		public long intptr_1;

		public byte byte_0;
	}

	public int Index { get; private set; }

	public DatBaseItemTypeWrapper BaseItemTypeWrapper { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct304 Struct304_0 { get; set; }

	internal DatDivinationCardStashTabLayoutWrapper(Struct304 native, int index)
	{
		Struct304_0 = native;
		Index = index;
		BaseItemTypeWrapper = Dat.GetBaseItemTypeWrapperByAddress(Struct304_0.intptr_1);
	}
}
