using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Weapon : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct231
	{
		public Struct253 struct253_0;

		public long intptr_0;

		public long intptr_1;

		public long intptr_2_IntPtr_0;

		public long intptr_3;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct232
	{
		public int int_0BaseWeaponType;

		public int int_1BaseMinPhysicalDamage;

		public int int_2BaseMaxPhysicalDamage;

		public int int_3BaseAttacksPerSecondRaw;

		public int int_4BaseCritialStrikeChanceRaw;

		public int int_5;

		public int int_6WeaponRange;

		public int int_7;

		private long intptr_0;
	}

	private PerFrameCachedValue<Struct231> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct232> perFrameCachedValue_2;

	public int BaseWeaponType => Struct232_0.int_0BaseWeaponType;

	public int BaseMinPhysicalDamage => Struct232_0.int_1BaseMinPhysicalDamage;

	public int BaseMaxPhysicalDamage => Struct232_0.int_2BaseMaxPhysicalDamage;

	public double BaseAttacksPerSecond => 1000.0 / (double)Struct232_0.int_3BaseAttacksPerSecondRaw;

	public int BaseAttacksPerSecondRaw => Struct232_0.int_3BaseAttacksPerSecondRaw;

	public double BaseCritialStrikeChance => (double)Struct232_0.int_4BaseCritialStrikeChanceRaw / 100.0;

	public int BaseCritialStrikeChanceRaw => Struct232_0.int_4BaseCritialStrikeChanceRaw;

	public int _14 => Struct232_0.int_5;

	public int WeaponRange => Struct232_0.int_6WeaponRange;

	public int _1C => Struct232_0.int_7;

	internal Struct231 Struct231_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct231>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	internal long IntPtr_0 => Struct231_0.intptr_2_IntPtr_0;

	internal Struct232 Struct232_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct232>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	private Struct231 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct231>(base.Address);
	}

	private Struct232 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct232>(IntPtr_0);
	}
}
