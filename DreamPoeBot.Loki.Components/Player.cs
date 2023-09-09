using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Player : Component
{
	public class TrialState
	{
		public string TrialAreaName { get; internal set; }

		public string TrialAreaId { get; internal set; }

		public bool IsCompleted { get; internal set; }

		public override string ToString()
		{
			return $"Completed: {IsCompleted}, Trial {TrialAreaName}, AreaId: {TrialAreaId}";
		}
	}

	private sealed class Class325
	{
		public string string_0;

		internal bool method_0(DatLabyrinthTrialWrapper datLabyrinthTrialWrapper_0)
		{
			return datLabyrinthTrialWrapper_0.WorldArea.Id.Equals(string_0, StringComparison.OrdinalIgnoreCase);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct189
	{
		public int int_0CurExp;

		public int int_1MaxExp;

		public int int_2;

		public int int_3;

		public new string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("[CurExp: {0}]", int_0CurExp);
			stringBuilder.AppendFormat("[MaxExp: {0}]", int_1MaxExp);
			stringBuilder.AppendFormat("[_08: {0}]", int_2);
			stringBuilder.AppendFormat("[_0C: {0}]", int_3);
			return stringBuilder.ToString();
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct190
	{
		public ushort ushort_0;

		public byte byte_0;

		public byte byte_1;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct191
	{
		[StructLayout(LayoutKind.Sequential, Size = 282)]
		[UnsafeValueType]
		public struct Struct192
		{
			public unsafe fixed byte byte_0[282];
		}

		[StructLayout(LayoutKind.Sequential, Size = 56)]
		[UnsafeValueType]
		public struct Struct193
		{
			public unsafe fixed byte byte_0[56];
		}

		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private long intptr_00;

		private long intptr_01;

		private long intptr_02;

		private long intptr_03;

		private long intptr_04;

		private long intptr_05;

		private long intptr_06;

		private long intptr_07;

		private long intptr_08;

		private long intptr_09;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		private long intptr_18;

		private long intptr_19;

		private long intptr_20;

		private long intptr_21;

		private long intptr_22;

		private long intptr_23;

		private long intptr_24;

		private long intptr_25;

		private long intptr_26;

		private long intptr_27;

		private long intptr_28;

		private long intptr_29;

		private long intptr_30;

		private long intptr_31;

		private long intptr_32;

		private long intptr_33;

		private long intptr_34;

		private long intptr_35;

		private long intptr_36;

		private long intptr_37;

		private long intptr_38;

		private long intptr_39;

		private long intptr_40;

		private long intptr_41;

		public NativeStringWCustom nativeStringW_0Name;

		public uint uint_0AllocatedLootId;

		public uint uint_1Experience;

		public int int_0Strength;

		public int int_1Dexterity;

		public int int_2Intelligence;

		public int int_0Strength2;

		public int int_1Dexterity2;

		public int int_2Intelligence2;

		private byte byte_8;

		private byte byte_9;

		private byte byte_11;

		private byte byte_14;

		public byte byte_10Level;

		public byte byte_12PantheonMinor;

		public byte byte_13PantheonMajor;

		private byte byte_15;

		private int int_7;

		private int int_71;

		private NativeVector nativeVector_1;

		public NativeVector nativeVector_2TrialData;

		private int unusedInt9;

		private int unusedInt10;

		public long long_1HideoutData;

		public long long_1HideoutDatFile;
	}

	private int _struct191Size = -1;

	private PerFrameCachedValue<Struct191> perFrameCachedValue_1;

	private List<DatLabyrinthTrialWrapper> list_0;

	public int Strength => Struct191_0.int_0Strength;

	public int Dexterity => Struct191_0.int_1Dexterity;

	public int Intelligence => Struct191_0.int_2Intelligence;

	public int MasterFavour => 0;

	public byte PropheciesCount => 0;

	public PantheonGod PantheonMajor => (PantheonGod)Struct191_0.byte_13PantheonMajor;

	public PantheonGod PantheonMinor => (PantheonGod)Struct191_0.byte_12PantheonMinor;

	public int HideoutLevel => 0;

	public bool HasHideout => Hideout != null;

	public DatHideoutWrapper Hideout
	{
		get
		{
			long long_1HideoutData = Struct191_0.long_1HideoutData;
			if (long_1HideoutData == 0L)
			{
				return null;
			}
			return new DatHideoutWrapper(long_1HideoutData);
		}
	}

	public List<DreamPoeBot.Loki.Game.Objects.Prophecy> Prophecies => new List<DreamPoeBot.Loki.Game.Objects.Prophecy>();

	public int Level => Struct191_0.byte_10Level;

	public uint Experience => Struct191_0.uint_1Experience;

	public string Name => Containers.StdStringWCustom(Struct191_0.nativeStringW_0Name);

	public uint AllocatedLootId => Struct191_0.uint_0AllocatedLootId;

	internal int Struct191Size
	{
		get
		{
			if (_struct191Size == -1)
			{
				_struct191Size = MarshalCache<Struct191>.Size;
			}
			return _struct191Size;
		}
	}

	private Struct191 Struct191_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct191>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public byte[] Byte_0
	{
		get
		{
			byte[] array = new byte[36];
			byte[] array2 = base.M.ReadBytes(Struct191_0.nativeVector_2TrialData.First, 36);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array2[i];
			}
			return array;
		}
	}

	internal BitArray BitArray_0 => new BitArray(Byte_0);

	public string DebugPlayerComponent(string byte0Offset, string menagerieOffset)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[PlayerComponent]");
		stringBuilder.AppendLine($"\t[Trials]");
		foreach (TrialState item in TrialStatesDegug(byte0Offset))
		{
			stringBuilder.AppendLine($"\t\t{item.TrialAreaName} Completed:{item.IsCompleted}");
		}
		return stringBuilder.ToString();
	}

	private BitArray TrialPassStatesDebug(string byte0Offset)
	{
		int num = (int)(Struct191_0.nativeVector_2TrialData.Last - Struct191_0.nativeVector_2TrialData.First);
		byte[] bytes = base.M.ReadBytes(Struct191_0.nativeVector_2TrialData.First + num / 6 / 2, 36);
		return new BitArray(bytes);
	}

	public List<TrialState> TrialStatesDegug(string byte0Offset)
	{
		List<TrialState> list = new List<TrialState>();
		if (list_0 == null)
		{
			list_0 = Dat.LabyrinthTrials.ToList();
		}
		foreach (DatLabyrinthTrialWrapper item in list_0)
		{
			list.Add(new TrialState
			{
				TrialAreaId = item.WorldArea.Id,
				TrialAreaName = item.WorldArea.Name,
				IsCompleted = test(item.Id - 1)
			});
		}
		return list;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[PlayerComponent]");
		stringBuilder.AppendLine($"\tName: {Name}");
		stringBuilder.AppendLine($"\tLevel: {Level}");
		stringBuilder.AppendLine($"\tHasHideout: {HasHideout}");
		stringBuilder.AppendLine($"\t[Trials]");
		foreach (TrialState item in TrialStatesDegug("5"))
		{
			stringBuilder.AppendLine($"\t\t{item.TrialAreaName} Completed:{item.IsCompleted}");
		}
		stringBuilder.AppendLine($"\t[Prophecys]");
		foreach (DreamPoeBot.Loki.Game.Objects.Prophecy prophecy in Prophecies)
		{
			stringBuilder.AppendLine($"\t\t{prophecy.DatPropheciesWrapper.Name}");
		}
		return stringBuilder.ToString();
	}

	private Struct191 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct191>(base.Address, Struct191Size);
	}

	public bool IsAscendencyTrialCompleted(string areaId)
	{
		Class325 @class = new Class325();
		@class.string_0 = areaId;
		if (list_0 == null)
		{
			list_0 = Dat.LabyrinthTrials.ToList();
		}
		DatLabyrinthTrialWrapper datLabyrinthTrialWrapper = list_0.FirstOrDefault(@class.method_0);
		return test(datLabyrinthTrialWrapper.Id - 1);
	}

	private bool test(int id)
	{
		long num = Struct191_0.nativeVector_2TrialData.Last;
		long num2 = Struct191_0.nativeVector_2TrialData.First;
		int num3 = id >> 6;
		long first = Struct191_0.nativeVector_2TrialData.First;
		int num4 = (int)((Struct191_0.nativeVector_2TrialData.Last - Struct191_0.nativeVector_2TrialData.First) / 9L);
		if (num4 > 0)
		{
			do
			{
				byte b = base.M.ReadByte(num2 + (8 * (num4 >> 1) + (num4 >> 1)));
				if (b < num3)
				{
					num2 += 8 * (num4 >> 1) + (num4 >> 1) + 9;
					num4 += -1 - (num4 >> 1);
				}
				else
				{
					num4 >>= 1;
				}
			}
			while (num4 > 0);
			num = first + 8L;
		}
		int num5 = 1 << (id & 7);
		byte b2 = base.M.ReadByte(num2 + ((id & 0x3F) >> 3) + 1L);
		int num6 = num5 & b2;
		if (num2 != num && base.M.ReadByte(num2) == (byte)num3)
		{
			return num6 > 0;
		}
		return false;
	}
}
