using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatGrantedEffectWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct309
	{
		public long intptr_0Name;

		public byte byte_0;

		private int int_0;

		private int intUnused0;

		private long intptr_1;

		public long intptr_2SupportLetter;

		private int int_1;

		private int int_2;

		private long intptr_3;

		private int int_3;

		private int intUnused1;

		private long intptr_4;

		public byte byte_1SupportAffectsSkillGem;

		private uint uint_0UserEffectHash;

		private int int_4;

		private long intptr_5;

		private byte byte_2;

		private int int_5;

		public int int_6CastTime;

		private int intUnused2;

		private int intUnused3;

		public long intptr_7DatActiveSkillWrapper;

		private long intptr_7DatActiveSkillWrapperFile;

		private long intptr_8;

		private long intptr_9;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private int int_7;

		private int intUnused4;

		private long intptr_17;

		private long intptr_GrantedEffectStatSets;

		private long intptr_GrantedEffectStatSetsFile;

		private long intptr_20;

		private long intptr_21;
	}

	public int Index { get; private set; }

	public string Name { get; private set; }

	public byte _04 { get; private set; }

	public string SupportLetter { get; private set; }

	public bool SupportAffectsSkillGem { get; private set; }

	private float CastTime { get; set; }

	public long BaseAddress { get; private set; }

	private Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	private Struct309 Struct309_0 { get; set; }

	public DatActiveSkillWrapper ActiveSkill => Dat.smethod_11(Struct309_0.intptr_7DatActiveSkillWrapper, bool_0: true);

	private void method_0(Struct309 struct309_1)
	{
		Struct309_0 = struct309_1;
		Name = ExternalProcessMemory_0.ReadStringU(Struct309_0.intptr_0Name);
		_04 = Struct309_0.byte_0;
		SupportLetter = ExternalProcessMemory_0.ReadStringU(Struct309_0.intptr_2SupportLetter);
		SupportAffectsSkillGem = Struct309_0.byte_1SupportAffectsSkillGem > 0;
		CastTime = (float)Struct309_0.int_6CastTime / 1000f;
	}

	internal DatGrantedEffectWrapper(long address, Struct309 native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatGrantedEffectWrapper(long ptr, int index = -1)
	{
		BaseAddress = ptr;
		Index = index;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct309>(BaseAddress));
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[{Index}]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{BaseAddress:X}");
		stringBuilder.AppendLine($"Name: {Name}");
		stringBuilder.AppendLine($"CastTime: {CastTime} SEC");
		if (SupportLetter != string.Empty)
		{
			stringBuilder.AppendLine($"SupportLetter: {SupportLetter}");
		}
		if (SupportAffectsSkillGem)
		{
			stringBuilder.AppendLine($"SupportAffectsSkillGem: {SupportAffectsSkillGem}");
		}
		return stringBuilder.ToString();
	}
}
