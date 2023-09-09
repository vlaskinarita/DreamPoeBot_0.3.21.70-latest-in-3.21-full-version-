using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatStatWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct325
	{
		public long intptr_0Id;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		public long intptr_1Name;

		private byte byte_8;

		private byte byte_9;

		private IntPtr intptr_2;

		private IntPtr intptr_3;

		private byte byte_10;

		private byte byte_11;

		private byte byte_12;

		private byte byte_13;

		private byte byte_14;

		private IntPtr intptr_4;

		private IntPtr intptr_5;

		private Struct242 struct242_0;

		private byte byte_15;

		private byte byte_16;

		private byte byte_17;

		private IntPtr intptr_6;

		private IntPtr intptr_7;

		private IntPtr intptr_8;

		private IntPtr intptr_9;
	}

	private static int struct325Size => MarshalCache<Struct325>.Size;

	public string ApiId { get; private set; }

	public string Id { get; private set; }

	public string Name { get; private set; }

	public string Description { get; private set; }

	public int Index { get; private set; }

	public long BaseAddress { get; private set; }

	internal Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	internal Struct325 Struct325_0 { get; set; }

	internal DatStatWrapper(long ptr)
	{
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct325>(BaseAddress, struct325Size));
	}

	internal DatStatWrapper(long address, Struct325 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	private void method_0(Struct325 struct325_1)
	{
		Struct325_0 = struct325_1;
		Id = ExternalProcessMemory_0.ReadStringU(Struct325_0.intptr_0Id);
		if (!string.IsNullOrEmpty(Id))
		{
			Name = ExternalProcessMemory_0.ReadStringU(Struct325_0.intptr_1Name);
			ApiId = LokiPoe.CleanifyStatString(Id);
			Description = (GameController.Instance.Files.StatDescription.Data.TryGetValue(ApiId, out var value) ? value : string.Empty);
		}
		else
		{
			Name = "";
			ApiId = "";
			Description = "";
		}
	}
}
