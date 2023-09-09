using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Armour : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct144
	{
		public Struct253 struct253_0;

		public long intptr_Struct145;

		public long intptr_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct145
	{
		public long intptr_0;

		public long intptr_1;

		public int int_0BaseEvasionMin;

		public int int_0BaseEvasionMax;

		public int int_1BaseArmorMin;

		public int int_1BaseArmorMax;

		public int int_2BaseEnergyShieldMin;

		public int int_2BaseEnergyShieldMax;
	}

	private PerFrameCachedValue<Struct144> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct145> perFrameCachedValue_2;

	internal Struct144 Struct144_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct144>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct145 Struct145_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct145>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	public int BaseEvasion => Struct145_0.int_0BaseEvasionMin;

	public int BaseArmor => Struct145_0.int_1BaseArmorMin;

	public int BaseEnergyShield => Struct145_0.int_2BaseEnergyShieldMin;

	private Struct144 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct144>(base.Address);
	}

	private Struct145 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct145>(Struct144_0.intptr_Struct145);
	}
}
