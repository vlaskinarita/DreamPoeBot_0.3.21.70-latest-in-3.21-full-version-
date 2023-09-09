using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class SkillGem : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct209
	{
		private Struct253 struct253_0;

		private uint uint_0;

		private uint uint_1;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int int_unused0;

		public long intptr_StructSkillGemsDat;

		public uint uint_2ExperienceLastLevel;

		public int int_0Level;

		public uint uint_3Experience;

		public uint uint_4ExperienceMaxLevel;

		private uint uint_2;

		public byte QualityType;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct ExtraInfo
	{
		private long BaseItemTypesData;

		private long BaseItemTypesDatFile;

		private long GrantedEffectsData;

		private long GrantedEffectsDatFile;

		private int int_0;

		private int int_1;

		private int int_2;

		public int int_3GemTagsKeyCount;

		private int int_unused0;

		public long intptr_4GemTagsKey;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private byte byte_8;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructSkillGemsDat
	{
		private long intptr_0;

		private long intptr_1;

		public int int_0SocketColor;

		private int int_unused0;

		public long intptr_6ExtraInfo;

		private long intptr_7;

		private int int_1;

		public int int_3AttributeModifiersSTR;

		public int int_4AttributeModifiersDEX;

		public int int_5AttributeModifiersINT;

		public long GrantedEffectsData;

		private long GrantedEffectsDatFile;

		public long GrantedEffectsData_copy;

		private long GrantedEffectsDatFile_copy;
	}

	private PerFrameCachedValue<Struct209> perFrameCachedValue_1;

	private int _struct242Size = -1;

	public int GemLevel => Struct209_0.int_0Level;

	public float[] AttributeModifiers => new float[3]
	{
		(float)Struct211_0.int_3AttributeModifiersSTR * 0.01f,
		(float)Struct211_0.int_4AttributeModifiersDEX * 0.01f,
		(float)Struct211_0.int_5AttributeModifiersINT * 0.01f
	};

	public int AttributeModifiersStr => Struct211_0.int_3AttributeModifiersSTR;

	public int AttributeModifiersDex => Struct211_0.int_4AttributeModifiersDEX;

	public int AttributeModifiersInt => Struct211_0.int_5AttributeModifiersINT;

	public uint Experience => Struct209_0.uint_3Experience;

	public uint ExperienceLastLevel => Struct209_0.uint_2ExperienceLastLevel;

	public uint ExperienceMaxLevel => Struct209_0.uint_4ExperienceMaxLevel;

	public int RequiredDex => method_2(1, bool_0: false);

	public int RequiredInt => method_2(2, bool_0: false);

	public int RequiredLevel => method_1(nextLevel: false);

	public int RequiredLevelForNextLevel => method_1(nextLevel: true);

	public int RequiredStr => method_2(0, bool_0: false);

	public GemQualityType GemQualityType => (GemQualityType)Struct209_0.QualityType;

	public SocketColor SocketColor => (SocketColor)Struct211_0.int_0SocketColor;

	private int Struct242Size
	{
		get
		{
			if (_struct242Size == -1)
			{
				_struct242Size = MarshalCache<Struct242>.Size;
			}
			return _struct242Size;
		}
	}

	public IEnumerable<string> GemTypes
	{
		get
		{
			List<string> list = new List<string>();
			ExtraInfo extraInfo = base.M.FastIntPtrToStruct<ExtraInfo>(Struct211_0.intptr_6ExtraInfo);
			Struct242[] array = base.M.IntptrToStructArray<Struct242>(extraInfo.intptr_4GemTagsKey, extraInfo.int_3GemTagsKeyCount, Struct242Size);
			for (int i = 0; i < array.Length; i++)
			{
				Struct242 @struct = array[i];
				Struct271 struct2 = base.M.FastIntPtrToStruct<Struct271>(@struct.intptr_1);
				list.Add(base.M.ReadStringU(struct2.intptr_0));
			}
			array = null;
			return list;
		}
	}

	internal Struct209 Struct209_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct209>(method_3);
			}
			return perFrameCachedValue_1;
		}
	}

	internal StructSkillGemsDat Struct211_0 => base.M.FastIntPtrToStruct<StructSkillGemsDat>(Struct209_0.intptr_StructSkillGemsDat);

	private int method_1(bool nextLevel)
	{
		int level = (nextLevel ? (GemLevel + 1) : GemLevel);
		if (Dat.GrantedEffectsPerLevel.contents.ContainsKey(Struct211_0.GrantedEffectsData))
		{
			return Dat.GrantedEffectsPerLevel.contents[Struct211_0.GrantedEffectsData].FirstOrDefault((GrantedEffectsPerLevel x) => x.Level == level)?.RequiredLevel ?? 0;
		}
		return 0;
	}

	private int method_2(int int_0, bool bool_0)
	{
		return 0;
	}

	private Struct209 method_3()
	{
		return base.M.FastIntPtrToStruct<Struct209>(base.Address);
	}
}
