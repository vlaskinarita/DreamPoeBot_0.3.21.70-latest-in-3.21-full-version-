using System;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Life : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct167
	{
		private IntPtr vTable;

		private IntPtr intptr_0;

		public int int_5Reserved;

		public int int_6ReservedPct;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private IntPtr intptr_1;

		public float float_0Regen;

		public int int_3Max;

		public int int_4Actual;

		private int unusedInt1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct168
	{
		public Struct167 struct167_0;

		private ushort ushort_0;

		private byte byte_0;

		private byte byte_1;

		private float float_0;

		private float float_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct169
	{
		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private IntPtr intptr_0;

		private IntPtr intptr_1;

		private IntPtr intptr_2;

		private IntPtr intptr_3;

		private IntPtr intptr_4;

		private IntPtr intptr_5;

		private IntPtr intptr_6;

		private IntPtr intptr_7;

		private IntPtr intptr_8;

		private IntPtr intptr_9;

		private IntPtr intptr_10;

		private IntPtr intptr_11;

		private IntPtr intptr_12;

		private IntPtr intptr_13;

		private IntPtr intptr_14;

		private IntPtr intptr_15;

		private IntPtr intptr_16;

		private IntPtr intptr_17;

		private IntPtr intptr_18;

		private IntPtr intptr_19;

		private IntPtr intptr_20;

		private IntPtr intptr_21;

		private IntPtr intptr_22;

		private IntPtr intptr_23;

		private IntPtr intptr_24;

		private IntPtr intptr_25;

		private IntPtr intptr_26;

		private IntPtr intptr_27;

		private IntPtr intptr_28;

		private IntPtr intptr_29;

		private IntPtr intptr_30;

		private IntPtr intptr_31;

		private IntPtr intptr_32;

		private IntPtr intptr_33;

		private IntPtr intptr_34;

		private IntPtr intptr_35;

		private IntPtr intptr_36;

		private IntPtr intptr_37;

		private IntPtr intptr_38;

		private IntPtr intptr_39;

		private IntPtr intptr_40;

		private IntPtr intptr_41;

		private IntPtr intptr_42;

		private IntPtr intptr_43;

		public Struct167 struct167_0Health;

		private IntPtr intptr_47;

		private IntPtr intptr_48;

		private IntPtr intptr_49;

		public Struct167 struct167_1Mana;

		public Struct168 struct168_0ES;

		private int unusedInt1;

		private IntPtr intptr_50;

		private IntPtr intptr_51;

		public byte byte_12;

		public byte byte_13CorpseUsable;

		public byte byte_14;

		public byte byte_15;

		public byte byte_16;

		public byte byte_17;

		private byte byte_18;

		private byte byte_19;
	}

	private PerFrameCachedValue<Struct169> perFrameCachedValue_1;

	public int Health => Struct169_0.struct167_0Health.int_4Actual;

	public int MaxHealth => Struct169_0.struct167_0Health.int_3Max;

	public float HealthPercent
	{
		get
		{
			float num = MaxHealth;
			if (num > 0f)
			{
				float num2 = num - (float)HealthReserved;
				float num3 = (float)Math.Ceiling(num * (float)HealthReservedPercent / 100f);
				return (float)Math.Round((float)Health / (num2 - num3) * 100f, 2, MidpointRounding.ToEven);
			}
			return 0f;
		}
	}

	internal float HealthPercentTotal
	{
		get
		{
			if (MaxHealth <= 0)
			{
				return 0f;
			}
			return (float)Math.Round((float)Health / (float)MaxHealth * 100f, 2, MidpointRounding.ToEven);
		}
	}

	public int HealthReserved => Struct169_0.struct167_0Health.int_5Reserved;

	public int HealthReservedPercent
	{
		get
		{
			if (Struct169_0.struct167_0Health.int_6ReservedPct > 0)
			{
				return Struct169_0.struct167_0Health.int_6ReservedPct / 100;
			}
			return 0;
		}
	}

	public float HealthRegen => Struct169_0.struct167_0Health.float_0Regen;

	public int Mana => Struct169_0.struct167_1Mana.int_4Actual;

	public int MaxMana => Struct169_0.struct167_1Mana.int_3Max;

	public float ManaPercent
	{
		get
		{
			float num = MaxMana;
			if (num <= 0f)
			{
				return 0f;
			}
			float num2 = num - (float)ManaReserved;
			float num3 = (float)Math.Ceiling(num * (ManaReservedPercent / 100f));
			return (float)Math.Round((float)Mana / (num2 - num3) * 100f, 2, MidpointRounding.ToEven);
		}
	}

	public float ManaPercentTotal
	{
		get
		{
			if (MaxMana <= 0)
			{
				return 0f;
			}
			return (float)Math.Round((float)Mana / (float)MaxMana * 100f, 2, MidpointRounding.ToEven);
		}
	}

	public int ManaReserved => Struct169_0.struct167_1Mana.int_5Reserved;

	public float ManaReservedPercent
	{
		get
		{
			if (Struct169_0.struct167_1Mana.int_6ReservedPct > 0)
			{
				return (float)Struct169_0.struct167_1Mana.int_6ReservedPct / 100f;
			}
			return 0f;
		}
	}

	public float ManaRegen => Struct169_0.struct167_1Mana.float_0Regen;

	public int EnergyShield => Struct169_0.struct168_0ES.struct167_0.int_4Actual;

	public int EnergyShieldMax => Struct169_0.struct168_0ES.struct167_0.int_3Max;

	public float EnergyShieldPercent
	{
		get
		{
			float num = EnergyShieldMax;
			if (num > 0f)
			{
				float num2 = num - (float)EnergyShieldReserved;
				float num3 = (float)Math.Ceiling(num * EnergyShieldReservedPercent / 100f);
				return (float)Math.Round((float)EnergyShield / (num2 - num3) * 100f, 2, MidpointRounding.ToEven);
			}
			return 0f;
		}
	}

	public float EnergyShieldPercentTotal
	{
		get
		{
			if (EnergyShieldMax <= 0)
			{
				return 0f;
			}
			return (float)Math.Round((float)EnergyShield / (float)EnergyShieldMax * 100f, 2, MidpointRounding.ToEven);
		}
	}

	public int EnergyShieldReserved => Struct169_0.struct168_0ES.struct167_0.int_5Reserved;

	public float EnergyShieldReservedPercent
	{
		get
		{
			if (Struct169_0.struct168_0ES.struct167_0.int_6ReservedPct > 0)
			{
				return (float)Struct169_0.struct168_0ES.struct167_0.int_6ReservedPct / 100f;
			}
			return 0f;
		}
	}

	public float EnergyShieldRegen => Struct169_0.struct168_0ES.struct167_0.float_0Regen;

	public bool CorpseUsable => Struct169_0.byte_13CorpseUsable == 1;

	public byte _BC => Struct169_0.byte_12;

	public byte _BD => Struct169_0.byte_15;

	public byte _BE => Struct169_0.byte_14;

	public byte _C0 => Struct169_0.byte_16;

	public byte _C1 => Struct169_0.byte_17;

	internal Struct169 Struct169_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct169>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[LifeComponent]");
		stringBuilder.AppendLine($"\tCorpseUsable: {CorpseUsable}");
		stringBuilder.AppendLine($"\tHealth");
		stringBuilder.AppendLine($"\t\tMaxHealth: {MaxHealth}");
		stringBuilder.AppendLine($"\t\tHealth: {Health}");
		stringBuilder.AppendLine($"\t\tHealthPercent: {HealthPercent}");
		stringBuilder.AppendLine($"\t\tHealthPercentTotal: {HealthPercentTotal}");
		stringBuilder.AppendLine($"\t\tHealthReserved: {HealthReserved}");
		stringBuilder.AppendLine($"\t\tHealthReservedPercent: {HealthReservedPercent}");
		stringBuilder.AppendLine($"\t\tHealthRegen: {HealthRegen}");
		stringBuilder.AppendLine($"\tMana");
		stringBuilder.AppendLine($"\t\tMaxMana: {MaxMana}");
		stringBuilder.AppendLine($"\t\tMana: {Mana}");
		stringBuilder.AppendLine($"\t\tManaPercent: {ManaPercent}");
		stringBuilder.AppendLine($"\t\tManaPercentTotal: {ManaPercentTotal}");
		stringBuilder.AppendLine($"\t\tManaReserved: {ManaReserved}");
		stringBuilder.AppendLine($"\t\tManaReservedPercent: {ManaReservedPercent}");
		stringBuilder.AppendLine($"\t\tManaRegen: {ManaRegen}");
		stringBuilder.AppendLine($"\tEnergyShield");
		stringBuilder.AppendLine($"\t\tEnergyShieldMax: {EnergyShieldMax}");
		stringBuilder.AppendLine($"\t\tEnergyShield: {EnergyShield}");
		stringBuilder.AppendLine($"\t\tEnergyShieldPercent: {EnergyShieldPercent}");
		stringBuilder.AppendLine($"\t\tEnergyShieldPercentTotal: {EnergyShieldPercentTotal}");
		stringBuilder.AppendLine($"\t\tEnergyShieldReserved: {EnergyShieldReserved}");
		stringBuilder.AppendLine($"\t\tEnergyShieldReservedPercent: {EnergyShieldReservedPercent}");
		stringBuilder.AppendLine($"\t\tEnergyShieldRegen: {EnergyShieldRegen}");
		return stringBuilder.ToString();
	}

	private Struct169 method_1()
	{
		return base.M.FastIntPtrToStruct169(base.Address);
	}
}
