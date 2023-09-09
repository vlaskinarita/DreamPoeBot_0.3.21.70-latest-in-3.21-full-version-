using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatPassiveSkillMasteryWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct DatStructure
	{
		public readonly long intptr_0Name;

		private long intptr_1;

		public int int_0StatListCount;

		private int unusedInt0;

		public long intptr_2StatListAddress;

		public int int_1Stat1Value;

		public int int_2Stat2Value;

		public int int_3Stat3Value;

		public int int_4Stat1Value;

		public int int_5PassiveId;

		public long intptr_3Name;

		private int int_6;

		private int unusedInt1;

		private long intptr_4;

		private byte byte_0;

		private byte byte_1;

		private long intptr_5;

		private byte byte_2;

		private long intptr_6;

		private long intptr_7;

		private byte byte_3;

		private int unusedInt2;

		private long intptr_8;

		private long intptr_9;

		public int int_7;

		private byte byte_4;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private byte byte_5;

		private byte byte_6;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private byte byte_7;

		private byte byte_8;

		private byte byte_9;

		private byte byte_10;

		private byte byte_11;

		private byte byte_12;

		private byte byte_13;

		private byte byte_14;

		private byte byte_15;

		private byte byte_16;

		private byte byte_17;

		private byte byte_18;

		private byte byte_19;

		private byte byte_20;

		private byte byte_21;

		private byte byte_22;

		private byte byte_23;

		private byte byte_24;

		private byte byte_25;

		private byte byte_26;

		private byte byte_27;

		private byte byte_28;

		private byte byte_29;

		private byte byte_30;

		private byte byte_31;

		private byte byte_32;

		private byte byte_33;

		private byte byte_34;

		private byte byte_35;

		private byte byte_36;

		private byte byte_37;

		private byte byte_38;

		private byte byte_39;

		private byte byte_40;

		private byte byte_41;

		private byte byte_42;

		private byte byte_43;

		private byte byte_44;

		private byte byte_45;

		private byte byte_46;

		private byte byte_47;

		private byte byte_48;

		private byte byte_49;

		private byte byte_50;

		private byte byte_51;

		private long intptr_16;

		private int int_8;

		private short short_0;
	}

	private int _struct242Size = -1;

	public int Index { get; private set; }

	public string Name { get; private set; }

	public int Id { get; private set; }

	public List<KeyValuePair<DatStatWrapper, int>> Stats { get; private set; }

	public int Stat1Value { get; private set; }

	public int Stat2Value { get; private set; }

	public int Stat3Value { get; private set; }

	internal Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	internal DatStructure Struct131_0 { get; set; }

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

	internal DatPassiveSkillMasteryWrapper(DatStructure native, int index)
	{
		Struct131_0 = native;
		Index = index;
		Name = ExternalProcessMemory_0.ReadStringU(Struct131_0.intptr_0Name);
		Id = Struct131_0.int_5PassiveId;
		Stats = new List<KeyValuePair<DatStatWrapper, int>>();
		Struct242[] array = ExternalProcessMemory_0.IntptrToStructArray<Struct242>(Struct131_0.intptr_2StatListAddress, Struct131_0.int_0StatListCount, Struct242Size);
		for (int i = 0; i < array.Length; i++)
		{
			Struct242 @struct = array[i];
			DatStatWrapper.Struct325 struct2 = ExternalProcessMemory_0.FastIntPtrToStruct<DatStatWrapper.Struct325>(@struct.intptr_1);
			string key = ExternalProcessMemory_0.ReadStringU(struct2.intptr_0Id);
			int value = i switch
			{
				0 => Struct131_0.int_1Stat1Value, 
				1 => Struct131_0.int_2Stat2Value, 
				2 => Struct131_0.int_3Stat3Value, 
				3 => Struct131_0.int_4Stat1Value, 
				4 => Struct131_0.int_7, 
				_ => throw new Exception("[DatPassiveSkillWrapper] Unexpected passive detected!"), 
			};
			Stats.Add(new KeyValuePair<DatStatWrapper, int>(Dat.IdToStatWrapper[key], value));
		}
	}
}
