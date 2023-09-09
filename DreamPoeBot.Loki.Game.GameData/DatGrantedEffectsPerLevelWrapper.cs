using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatGrantedEffectsPerLevelWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct308_DatGrantedEffectsPerLevel
	{
		public Struct243 struct243_GrantedEffect;

		public int int_0Level;

		private int int_1Int32_0;

		private int int_CostMultiplyer;

		private int int_StoredUse;

		public int int_Cooldown;

		private int int_CooldownByPassTipe;

		private int int_VaalSouls;

		private int int_VaalStoredUses;

		private int int_CooldownGroup;

		private int int_Unused7;

		private int int_Unused8;

		private int int_Unused9;

		private int int_Unused10;

		private int int_Unused11;

		private int int_Unused12;

		private long intptr_CostType;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		public int int_Unused13;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct308
	{
		public Struct243 struct243_GrantedEffect;

		public int int_0Level;

		public int int_1Int32_0;

		private int int_Unused0;

		public long intptr_0Stats;

		private float float_0;

		private float float_1;

		private float float_2;

		private float float_3;

		private float float_4;

		private float float_5;

		private float float_6;

		private float float_7;

		private float float_8;

		public int int_2TagsCount;

		private int int_Unused1;

		public long intptr_1TagsStruct242;

		public int int_3Stat1Value;

		public int int_4Stat2Value;

		public int int_5Stat3Value;

		public int int_6Stat4Value;

		public int int_7Stat5Value;

		public int int_8Stat6Value;

		public int int_9Stat7Value;

		public int int_10Stat8Value;

		public int int_10Stat9Value;

		public int int_10Stat10Value;

		public int int_11RequiredLevel;

		public int int_12ManaMultiplier;

		public int int_13AttributesLevel;

		public int int_14;

		public int int_141;

		public int int_18ManaCost;

		public int int_19EffectivenessOfAddedDamage;

		public int int_20;

		public int int_21Cooldown;

		public int int_142;

		public int int_23TypeStatsCount;

		private int int_Unused2;

		public long intptr_4TypeStats;

		public byte byte_0;

		public int int_24SoulsPerUse;

		public int int_25SoulUsesStored;

		public int int_CooldownGroup;

		public int int_28;

		public int int_DamageMultiplier;

		public int int_30;

		public int int_ArtVariation;
	}

	public int Index { get; private set; }

	public long BaseAddress { get; private set; }

	public int Level { get; private set; }

	public int Cooldown { get; private set; }

	internal Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	internal Struct308_DatGrantedEffectsPerLevel Struct308_0 { get; set; }

	public DatGrantedEffectWrapper GrantedEffect => new DatGrantedEffectWrapper(Struct308_0.struct243_GrantedEffect.intptr_1, Index);

	public DatActiveSkillWrapper ActiveSkill => GrantedEffect.ActiveSkill;

	private void method_0(Struct308_DatGrantedEffectsPerLevel struct308_1)
	{
		Struct308_0 = struct308_1;
		Level = Struct308_0.int_0Level;
		Cooldown = Struct308_0.int_Cooldown;
	}

	internal DatGrantedEffectsPerLevelWrapper(long address, Struct308_DatGrantedEffectsPerLevel native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatGrantedEffectsPerLevelWrapper(long ptr, int index = -1)
	{
		BaseAddress = ptr;
		Index = index;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<Struct308_DatGrantedEffectsPerLevel>(BaseAddress));
	}

	private int method_1(int int_27, Dictionary<long, DatSkillGemWrapper> dictionary_0)
	{
		float num = 0.7f;
		if (GrantedEffect._04 != 0)
		{
			num = 0.5f;
		}
		if (!dictionary_0.TryGetValue(Struct308_0.struct243_GrantedEffect.intptr_1, out var value))
		{
			return 0;
		}
		float num2 = 0f;
		switch (int_27)
		{
		case 1:
			num2 = (float)value.DexRatio / 100f;
			break;
		case 2:
			num2 = (float)value.IntRatio / 100f;
			break;
		case 0:
			num2 = (float)value.StrRatio / 100f;
			break;
		}
		float num3 = (float)Math.Pow(num2, 0.89999998);
		int num4 = Struct308_0.int_Unused13 + 2 * Struct308_0.int_Unused13 + 11;
		return (int)(num3 * (float)num4 * num + 0.5f);
	}

	public int GetRequiredStr(Dictionary<long, DatSkillGemWrapper> SkillGems)
	{
		return method_1(0, SkillGems);
	}

	public int GetRequiredDex(Dictionary<long, DatSkillGemWrapper> SkillGems)
	{
		return method_1(1, SkillGems);
	}

	public int GetRequiredInt(Dictionary<long, DatSkillGemWrapper> SkillGems)
	{
		return method_1(2, SkillGems);
	}
}
