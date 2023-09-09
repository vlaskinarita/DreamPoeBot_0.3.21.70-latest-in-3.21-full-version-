using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class Aura : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MainAurasStructure
	{
		public ushort ushort_0AuraId;

		private ushort ushort_1;

		private int unusedInt0;

		public long aurasInfoStructure;

		private NativeVector nativeVector_0;

		private NativeVector nativeVector_1;

		private long intptr_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct AurasInfoStructure
	{
		private readonly long intptr_00;

		public readonly long intptr_1BuffDefination;

		private readonly long intptr_0;

		private readonly float float_0;

		public readonly float float_1TimeLeft;

		private readonly float float_2;

		private readonly int int_0CasterId;

		public readonly int int_1OwnerId;

		private readonly int int_2;

		private readonly long intptr_1;

		private readonly int int_3;

		private readonly ushort ushort_03;

		public readonly ushort ushort_Charges;

		public readonly ushort ushort_FlaskSlot;

		public readonly ushort ushort_Effectiveness;

		private readonly ushort ushort_12;

		public readonly ushort ushort_2SkillOwnerId;

		public readonly ushort ushort_3BuffType;

		private readonly ushort ushort_4;

		private readonly ushort ushort_5;

		private readonly ushort ushort_6;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly long intptr_4;

		private readonly long intptr_5;

		private readonly long intptr_6;

		private readonly long intptr_7;

		public readonly long StacksData;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StackDataStructure
	{
		public readonly int Stasks;

		public readonly int MaxStaks;

		public readonly int IsActive;

		public readonly int Unknown;
	}

	private PerFrameCachedValue<AurasInfoStructure> perFrameCachedValue_1;

	private PerFrameCachedValue<StackDataStructure> perFrameCachedValue_stackDataStructure;

	private PerFrameCachedValue<DatBuffDefinitionWrapper.Struct300> perFrameCachedValue_2;

	private PerFrameCachedValue<int> perFrameCachedValue_3;

	private PerFrameCachedValue<int> perFrameCachedValue_4;

	private PerFrameCachedValue<ushort> perFrameCachedValue_SkillOwnerId;

	private PerFrameCachedValue<int> perFrameCachedValue_5;

	private PerFrameCachedValue<TimeSpan> perFrameCachedValue_6;

	private PerFrameCachedValue<TimeSpan> perFrameCachedValue_7;

	private PerFrameCachedValue<int> perFrameCachedValue_8;

	private PerFrameCachedValue<string> perFrameCachedValue_9;

	private PerFrameCachedValue<bool> perFrameCachedValue_10;

	private PerFrameCachedValue<bool> perFrameCachedValue_11;

	private PerFrameCachedValue<string> perFrameCachedValue_12;

	private PerFrameCachedValue<string> perFrameCachedValue_13;

	private PerFrameCachedValue<int> perFrameCachedValue_Stacks;

	private PerFrameCachedValue<int> perFrameCachedValue_MaxStacks;

	private PerFrameCachedValue<bool> perFrameCachedValue_IsPlagueActive;

	private PerFrameCachedValue<int> perFrameCachedValue_FlaskSlot;

	private PerFrameCachedValue<short> perFrameCachedValue_Effectiveness;

	public bool IsCasterMe => CasterId == LokiPoe.MyId;

	public int CasterId
	{
		get
		{
			if (perFrameCachedValue_3 == null)
			{
				perFrameCachedValue_3 = new PerFrameCachedValue<int>(() => aurasInfoStructure.int_1OwnerId);
			}
			return perFrameCachedValue_3;
		}
	}

	public int OwnerId
	{
		get
		{
			if (perFrameCachedValue_4 == null)
			{
				perFrameCachedValue_4 = new PerFrameCachedValue<int>(() => aurasInfoStructure.int_1OwnerId);
			}
			return perFrameCachedValue_4;
		}
	}

	public ushort SkillOwnerId
	{
		get
		{
			if (perFrameCachedValue_SkillOwnerId == null)
			{
				perFrameCachedValue_SkillOwnerId = new PerFrameCachedValue<ushort>(() => aurasInfoStructure.ushort_2SkillOwnerId);
			}
			return perFrameCachedValue_SkillOwnerId;
		}
	}

	public int BuffType
	{
		get
		{
			if (perFrameCachedValue_5 == null)
			{
				perFrameCachedValue_5 = new PerFrameCachedValue<int>(() => Struct300_0.int_BuffType);
			}
			return perFrameCachedValue_5;
		}
	}

	public TimeSpan MaxTimeLeft
	{
		get
		{
			if (perFrameCachedValue_6 == null)
			{
				perFrameCachedValue_6 = new PerFrameCachedValue<TimeSpan>(maxTimeLeft);
			}
			return perFrameCachedValue_6;
		}
	}

	public TimeSpan TimeLeft
	{
		get
		{
			if (perFrameCachedValue_7 == null)
			{
				perFrameCachedValue_7 = new PerFrameCachedValue<TimeSpan>(timeLeft);
			}
			return perFrameCachedValue_7;
		}
	}

	public int Charges
	{
		get
		{
			if (perFrameCachedValue_8 == null)
			{
				perFrameCachedValue_8 = new PerFrameCachedValue<int>(() => aurasInfoStructure.ushort_Charges);
			}
			return perFrameCachedValue_8;
		}
	}

	public string Name
	{
		get
		{
			if (perFrameCachedValue_9 == null)
			{
				perFrameCachedValue_9 = new PerFrameCachedValue<string>(() => LokiPoe.staticStringCache_0.ReadStringW(Struct300_0.intptr_2Name));
			}
			return perFrameCachedValue_9;
		}
	}

	public bool IsInvisible
	{
		get
		{
			if (perFrameCachedValue_10 == null)
			{
				perFrameCachedValue_10 = new PerFrameCachedValue<bool>(() => Struct300_0.byte_0IsInvisible > 0);
			}
			return perFrameCachedValue_10;
		}
	}

	public bool IsRemovable
	{
		get
		{
			if (perFrameCachedValue_11 == null)
			{
				perFrameCachedValue_11 = new PerFrameCachedValue<bool>(() => Struct300_0.byte_1IsRemovable > 0);
			}
			return perFrameCachedValue_11;
		}
	}

	public string InternalName
	{
		get
		{
			if (perFrameCachedValue_12 == null)
			{
				perFrameCachedValue_12 = new PerFrameCachedValue<string>(() => LokiPoe.staticStringCache_0.ReadStringW(Struct300_0.intptr_0InternalName));
			}
			return perFrameCachedValue_12;
		}
	}

	public string Description
	{
		get
		{
			if (perFrameCachedValue_13 == null)
			{
				perFrameCachedValue_13 = new PerFrameCachedValue<string>(() => LokiPoe.staticStringCache_0.ReadStringW(Struct300_0.intptr_1Description));
			}
			return perFrameCachedValue_13;
		}
	}

	public int Stacks
	{
		get
		{
			if (perFrameCachedValue_Stacks == null)
			{
				perFrameCachedValue_Stacks = new PerFrameCachedValue<int>(() => stackDataStructure.Stasks);
			}
			return perFrameCachedValue_Stacks;
		}
	}

	public int MaxStacks
	{
		get
		{
			if (perFrameCachedValue_MaxStacks == null)
			{
				perFrameCachedValue_MaxStacks = new PerFrameCachedValue<int>(() => stackDataStructure.MaxStaks);
			}
			return perFrameCachedValue_MaxStacks;
		}
	}

	public int StacksPct
	{
		get
		{
			if (Stacks != 0 && MaxStacks != 0)
			{
				return (int)((double)Stacks / (double)MaxStacks * 100.0);
			}
			return 0;
		}
	}

	public bool IsPlagueActive
	{
		get
		{
			if (perFrameCachedValue_IsPlagueActive == null)
			{
				perFrameCachedValue_IsPlagueActive = new PerFrameCachedValue<bool>(() => stackDataStructure.IsActive != 0);
			}
			return perFrameCachedValue_IsPlagueActive;
		}
	}

	public int FlaskSlot
	{
		get
		{
			if (perFrameCachedValue_FlaskSlot == null)
			{
				perFrameCachedValue_FlaskSlot = new PerFrameCachedValue<int>(GetFlaskSlot);
			}
			return perFrameCachedValue_FlaskSlot;
		}
	}

	public short Effectiveness
	{
		get
		{
			if (perFrameCachedValue_Effectiveness == null)
			{
				perFrameCachedValue_Effectiveness = new PerFrameCachedValue<short>(() => (short)aurasInfoStructure.ushort_Effectiveness);
			}
			return perFrameCachedValue_Effectiveness;
		}
	}

	internal AurasInfoStructure aurasInfoStructure
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<AurasInfoStructure>(() => base.M.FastIntPtrToStruct<AurasInfoStructure>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}

	internal StackDataStructure stackDataStructure
	{
		get
		{
			if (perFrameCachedValue_stackDataStructure == null)
			{
				perFrameCachedValue_stackDataStructure = new PerFrameCachedValue<StackDataStructure>(() => base.M.FastIntPtrToStruct<StackDataStructure>(aurasInfoStructure.StacksData));
			}
			return perFrameCachedValue_stackDataStructure;
		}
	}

	internal DatBuffDefinitionWrapper.Struct300 Struct300_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<DatBuffDefinitionWrapper.Struct300>(() => base.M.FastIntPtrToStruct<DatBuffDefinitionWrapper.Struct300>(aurasInfoStructure.intptr_1BuffDefination));
			}
			return perFrameCachedValue_2;
		}
	}

	public Aura(long address)
	{
		base.Address = address;
	}

	private TimeSpan maxTimeLeft()
	{
		float float_1TimeLeft = aurasInfoStructure.float_1TimeLeft;
		if (float_1TimeLeft < 0f)
		{
			return TimeSpan.Zero;
		}
		if (!float.IsInfinity(float_1TimeLeft) && !float_1TimeLeft.Equals(float.MaxValue))
		{
			return TimeSpan.FromSeconds(float_1TimeLeft);
		}
		return TimeSpan.MaxValue;
	}

	private TimeSpan timeLeft()
	{
		float float_1TimeLeft = aurasInfoStructure.float_1TimeLeft;
		if (float_1TimeLeft < 0f)
		{
			return TimeSpan.Zero;
		}
		if (!float.IsInfinity(float_1TimeLeft) && !float_1TimeLeft.Equals(float.MaxValue))
		{
			return TimeSpan.FromSeconds(float_1TimeLeft);
		}
		return TimeSpan.MaxValue;
	}

	private int GetFlaskSlot()
	{
		if (OwnerId != LokiPoe.ObjectManager.Me.Id)
		{
			return -1;
		}
		if (BuffType == 4)
		{
			return aurasInfoStructure.ushort_FlaskSlot;
		}
		return -1;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Aura]");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Address:X}");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tInternalName: {InternalName}");
		stringBuilder.AppendLine($"\tDescription: {Description}");
		stringBuilder.AppendLine($"\tCasterId: {CasterId}");
		stringBuilder.AppendLine($"\tOwnerId: {OwnerId}");
		Skill skill = LokiPoe.ObjectManager.Me.AvailableSkills.FirstOrDefault((Skill x) => x.Id == SkillOwnerId);
		if (!(skill != null))
		{
			stringBuilder.AppendLine($"\tSkillOwnerId: {SkillOwnerId}");
		}
		else
		{
			stringBuilder.AppendLine($"\tSkillOwnerId: {SkillOwnerId} (Skill Name: {skill.Name}, InternalName: {skill.InternalName}, InternalId: {skill.InternalId})");
		}
		stringBuilder.AppendLine($"\tBuffType: {BuffType}");
		int flaskSlot = FlaskSlot;
		if (flaskSlot != -1)
		{
			Item item = LokiPoe.InGameState.InventoryUi.InventoryControl_Flasks.Inventory.Items.FirstOrDefault((Item x) => x.LocationTopLeft.X == flaskSlot);
			if (item != null)
			{
				stringBuilder.AppendLine($"\tFlaskSlot: {flaskSlot} [Flask: {item.Name} {item.FullName}]");
			}
			else
			{
				stringBuilder.AppendLine($"\tFlaskSlot: {flaskSlot} [Flask is Null]");
			}
		}
		else
		{
			stringBuilder.AppendLine($"\tFlaskSlot: {flaskSlot}");
		}
		stringBuilder.AppendLine($"\tTimeLeft: {TimeLeft}");
		stringBuilder.AppendLine($"\tMaxTimeLeft: {MaxTimeLeft}");
		stringBuilder.AppendLine($"\tCharges: {Charges}");
		stringBuilder.AppendLine($"\tStacksPct: {StacksPct}[{Stacks}/{MaxStacks}]");
		stringBuilder.AppendLine($"\tIsPlagueActive: {IsPlagueActive}");
		stringBuilder.AppendLine($"\tIsInvisible: {IsInvisible}");
		stringBuilder.AppendLine($"\tIsRemovable: {IsRemovable}");
		return stringBuilder.ToString();
	}
}
