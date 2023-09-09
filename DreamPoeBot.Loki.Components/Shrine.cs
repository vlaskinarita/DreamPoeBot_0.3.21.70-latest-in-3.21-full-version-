using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Shrine : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct207
	{
		public Struct253 struct253_0;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		public int unusedInt0;

		public long unusedIntPtr0;

		public int int_0;

		public byte byte_4IsDeactivated;

		public byte byte_5;

		public byte byte_6;

		public byte byte_7;

		public long intptr_0;

		public long intptr_1Struct208;

		public long intptr_2;

		public long intptr_3;

		public long intptr_4;

		public Struct242 struct242_0;

		public long intptr_5;

		public long intptr_6;

		public long intptr_7;

		public long intptr_8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct208
	{
		public long intptr_0ShrineId;

		public int int_0;

		public long intptr_1ShrineName;

		public byte byte_0;

		public long intptr_2;

		public long intptr_3;

		public int int_1;

		public int int_2;

		public long intptr_4ShrineDescription;

		public long intptr_5;

		public long intptr_6;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public int int_7;

		public int int_8;

		public long intptr_7;

		public long intptr_8;

		public byte byte_1;

		public int int_9;

		public long intptr_9;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;
	}

	private PerFrameCachedValue<Struct207> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct208> perFrameCachedValue_2;

	private int Int32_0
	{
		get
		{
			if (IsDeactivated)
			{
				return Struct207_0.int_0;
			}
			return 0;
		}
	}

	public bool IsDeactivated => Struct207_0.byte_4IsDeactivated == 1;

	public string ShrineId => base.M.ReadStringU(Struct208_0.intptr_0ShrineId);

	public string ShrineName => base.M.ReadStringU(Struct208_0.intptr_1ShrineName);

	public string ShrineDescription => base.M.ReadStringU(Struct208_0.intptr_4ShrineDescription);

	internal Struct207 Struct207_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct207>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct208 Struct208_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct208>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	public override string ToString()
	{
		_ = Struct207_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "ShrineComponent"));
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Address:X}");
		stringBuilder.AppendLine($"IsDeactivated: {IsDeactivated}");
		stringBuilder.AppendLine($"ShrineId: {ShrineId}");
		stringBuilder.AppendLine($"ShrineName: {ShrineName}");
		stringBuilder.AppendLine($"ShrineDescription: {ShrineDescription}");
		return stringBuilder.ToString();
	}

	private Struct207 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct207>(base.Address);
	}

	private Struct208 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct208>(Struct207_0.intptr_1Struct208);
	}
}
