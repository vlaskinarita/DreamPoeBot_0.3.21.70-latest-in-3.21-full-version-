using System.Runtime.InteropServices;
using System.Text;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatHideoutWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct310
	{
		public long intptr_0Id;

		public long intptr_1;

		public long intptr_2WorldArea1;

		public int intptr_3;

		public long intptr_4;

		public long intptr_5;

		public long intptr_6WorldArea2;

		public long intptr_7;

		public long intptr_8WorldArea3;

		public int int_0;
	}

	public int Index { get; private set; }

	public string Id { get; private set; }

	public DatWorldAreaWrapper WorldArea1 { get; private set; }

	public DatWorldAreaWrapper WorldArea2 { get; private set; }

	public DatWorldAreaWrapper WorldArea3 { get; private set; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct310 Struct310_0 { get; set; }

	internal long IntPtr_0 { get; set; }

	internal DatHideoutWrapper(long address, Struct310 native, int index)
	{
		IntPtr_0 = address;
		Index = index;
		method_0(native);
	}

	internal DatHideoutWrapper(long ptr)
	{
		IntPtr_0 = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct310>(IntPtr_0));
	}

	private void method_0(Struct310 struct310_1)
	{
		Struct310_0 = struct310_1;
		Id = ExternalProcessMemory_0.ReadStringU(Struct310_0.intptr_0Id);
		WorldArea1 = Dat.GetWorldArea(Struct310_0.intptr_2WorldArea1, bool_0: true);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Id: {Id}");
		if (WorldArea1 != null)
		{
			stringBuilder.AppendLine($"WorldArea1: {WorldArea1}");
		}
		else
		{
			stringBuilder.AppendLine($"WorldArea1: <null>");
		}
		return stringBuilder.ToString();
	}
}
