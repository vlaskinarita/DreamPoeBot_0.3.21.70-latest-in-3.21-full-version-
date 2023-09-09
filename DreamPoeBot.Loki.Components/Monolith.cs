using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Monolith : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct181
	{
		private readonly Struct253 struct253_0;

		private readonly NativeVector nativeVector_1;

		private readonly NativeVector nativeVector_2;

		private readonly NativeVector nativeVector_3;

		private readonly NativeVector nativeVector_4;

		private readonly NativeVector nativeVector_5;

		private readonly NativeVector nativeVector_6;

		private readonly NativeVector nativeVector_7;

		private readonly IntPtr intptr_0;

		private readonly IntPtr intptr_01;

		public readonly NativeVector nativeVector_DataEssence;

		public readonly long intptr_1MonsterVariety;

		private readonly long intptr_2MonsterVarietyFile;

		public readonly byte byte_IsCorrupted;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;

		private readonly int int_0;

		private readonly long intptr_3;

		public readonly byte byte_OpenPhase;

		private readonly byte byte_9;

		private readonly byte byte_10;

		private readonly byte byte_11;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MonsterVariety
	{
		internal readonly long long_ID;

		internal readonly long DatMosterTypeData;

		private readonly long DatMosterTypeFile;

		private readonly int Int0;

		private readonly int Int1;

		private readonly int Int2MinAttackDistance;

		private readonly int Int3MaxAttackDistance;

		private readonly int Int4;

		private readonly int Int5;

		private readonly long long_4;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly byte byte_3;

		private readonly int Int6;

		private readonly long long_5;

		private readonly long long_6;

		private readonly byte byte_4;

		private readonly byte byte_5;

		private readonly byte byte_6;

		private readonly byte byte_7;

		private readonly int Int7;

		private readonly long long_7;

		private readonly byte byte_8;

		private readonly byte byte_9;

		private readonly byte byte_10;

		private readonly byte byte_11;

		private readonly long long_8;

		private readonly long long_9;

		private readonly int Int8;

		private readonly int Int9;

		private readonly int Int10;

		private readonly int Int11;

		private readonly int Int12;

		private readonly int Int13;

		private readonly int Int14;

		private readonly int Int15;

		private readonly long long_10;

		private readonly int Int16;

		private readonly int Int17;

		private readonly int Int18;

		private readonly int Int19;

		private readonly int Int20;

		private readonly int Int21;

		private readonly int Int22;

		private readonly int Int23;

		private readonly int Int24;

		private readonly int Int25;

		private readonly int Int26;

		private readonly int Int27;

		private readonly long long_11;

		private readonly long long_12;

		private readonly int Int28;

		private readonly int Int29;

		private readonly int Int30;

		private readonly int Int31;

		private readonly long long_13;

		private readonly long long_14;

		private readonly long long_15;

		private readonly long long_Name;

		private readonly int Int32;

		private readonly int Int33;

		private readonly int Int34;

		private int Int35;

		private readonly long long_16;

		private readonly long long_17;

		private readonly long long_18;

		private readonly long long_19;

		private readonly long long_20;

		private readonly long long_21;

		private readonly long long_22;

		private readonly long long_23;

		private readonly long long_24;

		private readonly long long_25;

		private readonly long long_26;

		private readonly long long_27;

		private readonly long long_28;

		private readonly long long_29;

		private readonly long long_30;

		private readonly long long_31;

		private readonly long long_32;

		private readonly long long_33;

		private readonly int Int36;

		private readonly int Int37;

		private readonly long long_34;

		private readonly int Int38;

		private readonly int Int39;

		private readonly int Int40;

		private readonly int Int41;

		private readonly int Int42;

		private readonly int Int43;

		private readonly int Int44;

		private readonly byte byte_12;

		private readonly byte byte_13;

		private readonly long long_341;

		private readonly long long_35;

		private readonly long long_36;

		private readonly long long_37;

		private readonly long long_38;

		private readonly long long_39;

		private readonly long long_40;

		private readonly long long_41;

		private readonly long long_42;

		private readonly long long_43;

		private readonly long long_44;

		private readonly long long_45;

		private readonly long long_46;

		private readonly long long_47;

		private readonly long long_48;

		private readonly long long_49;

		private readonly long long_50;

		private readonly long long_51;

		private readonly long long_52;

		private readonly long long_53;

		private readonly long long_54;

		private readonly long long_55;

		private readonly int Int45;

		private readonly long long_56;

		private readonly long long_57;

		private readonly long long_58;

		private readonly long long_59;

		private readonly long long_60;

		private readonly int Int46;

		private readonly long long_61;

		private readonly long long_62;

		private readonly long long_63;

		private readonly int Int47;

		private readonly int Int48;

		private readonly byte byte_14;

		private readonly byte byte_15;

		private readonly byte byte_16;
	}

	private string _monsterTypeId;

	private string _monsterTypeMetadata;

	private List<DatBaseItemTypeWrapper> _essenceBaseItemTypes;

	public List<DatBaseItemTypeWrapper> EssenceBaseItemTypes
	{
		get
		{
			if (_essenceBaseItemTypes == null)
			{
				_essenceBaseItemTypes = new List<DatBaseItemTypeWrapper>();
				long first = Struct181_0.nativeVector_DataEssence.First;
				long last = Struct181_0.nativeVector_DataEssence.Last;
				for (long num = first; num < last; num += 16L)
				{
					_essenceBaseItemTypes.Add(new DatBaseItemTypeWrapper(base.M.ReadLong(base.M.ReadLong(num))));
				}
			}
			return _essenceBaseItemTypes;
		}
	}

	public bool IsCorrupted => Struct181_0.byte_IsCorrupted == 1;

	public string MonsterTypeId
	{
		get
		{
			if (_monsterTypeId == null)
			{
				_monsterTypeId = base.M.ReadStringU(Struct_StructMonsterTypeId.intptr_TypeId);
			}
			return _monsterTypeId;
		}
	}

	public string MonsterTypeMetadata
	{
		get
		{
			if (_monsterTypeMetadata == null)
			{
				_monsterTypeMetadata = base.M.ReadStringU(Struct_MonsterVariety.long_ID);
			}
			return _monsterTypeMetadata;
		}
	}

	public int OpenPhase => Struct181_0.byte_OpenPhase;

	internal Struct273MonsteTypeComp Struct_StructMonsterTypeId => GameController.Instance.Memory.FastIntPtrToStruct<Struct273MonsteTypeComp>(Struct_MonsterVariety.DatMosterTypeData);

	internal MonsterVariety Struct_MonsterVariety => GameController.Instance.Memory.FastIntPtrToStruct<MonsterVariety>(Struct181_0.intptr_1MonsterVariety);

	internal Struct181 Struct181_0 => GameController.Instance.Memory.FastIntPtrToStruct<Struct181>(base.Address, MarshalCache<Struct181>.Size);
}
