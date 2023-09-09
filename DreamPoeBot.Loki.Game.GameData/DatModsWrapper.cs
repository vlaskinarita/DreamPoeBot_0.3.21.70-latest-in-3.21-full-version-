using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatModsWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct316
	{
		public readonly long intptr_Id;

		public readonly int int_0;

		public readonly long intptr_ModTypeDatAccress;

		private readonly long intptr_ModTypeDatFile;

		public readonly int int_Level;

		public readonly Struct243 struct243_Stats0;

		public readonly Struct243 struct243_Stats1;

		public readonly Struct243 struct243_Stats2;

		public readonly Struct243 struct243_Stats3;

		private readonly int int_2;

		public readonly long intptr_Name;

		public readonly int int_3;

		private int int_98;

		private int int_99;

		public readonly long intptr_Group4;

		public readonly KeyValuePair<int, int> keyValuePair_Stat1Values;

		public readonly KeyValuePair<int, int> keyValuePair_Stat2Values;

		public readonly KeyValuePair<int, int> keyValuePair_Stat3Values;

		public readonly KeyValuePair<int, int> keyValuePair_Stat4Values;

		private readonly int int_4;

		private readonly int int_4x;

		private readonly long intptr_5;

		private readonly int int_5;

		private readonly int int_5x;

		private readonly long intptr_6;

		private readonly long intptr_341;

		private readonly long intptr_342;

		private readonly long intptr_343;

		private readonly long intptr_344;

		private readonly long intptr_345;

		private readonly long intptr_346;

		private readonly long intptr_27;

		private readonly long intptr_28;

		private readonly long intptr_29;

		private readonly long intptr_30;

		private readonly long intptr_31;

		private readonly long intptr_32;

		private readonly long intptr_33;

		private readonly long intptr_19x;

		private readonly long intptr_20;

		private readonly long intptr_21;

		private readonly long intptr_22;

		private readonly long intptr_23;

		private readonly long intptr_24;

		private readonly long intptr_25;

		public readonly int int_6TagsCount;

		private readonly int int_6x;

		public readonly long intptr_8TagsKey;

		private readonly int int_7;

		private readonly int int_7x;

		private readonly long intptr_9GrantedEffect;

		private readonly int int_8;

		private readonly int int_8x;

		private readonly long intptr_10;

		private readonly long intptr_11MonsterMetadataMeyby;

		private readonly int int_9;

		private readonly int int_9x;

		private readonly long intptr_11;

		private readonly int int_10;

		private readonly int int_10x;

		private readonly long intptr_12;

		private readonly int int_stat5Min;

		private readonly int int_stat5Max;

		private readonly long intptr_Stat5;

		private readonly long intptr_StatsDatFile5;

		private readonly long intptr_99;

		private readonly int int_11;

		private readonly int int_11x;

		private readonly long intptr_13;

		private readonly int int_12;

		private readonly int int_12x;

		private readonly long intptr_14;

		private readonly int int_13;

		private readonly int int_13x;

		private readonly long intptr_15;

		private readonly long intptr_16x;

		private readonly long intptr_16;

		private readonly long intptr_17;

		private readonly int int_stat6Min;

		private readonly int int_stat6Max;

		private readonly long intptr_Stat6;

		private readonly long intptr_StatsDatFile6;

		private readonly int int_MaxLevel;

		private readonly int int_15x;

		private readonly long intptr_18;

		private readonly int int_16x;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly long intptr_19;

		private readonly byte byte_2;

		private readonly byte byte_3;

		private readonly int int_HeistStatValue1;

		private readonly int int_HeistStatValue2;

		private readonly long intptr_HeistStatKey0;

		private readonly long intptr_HeistStatKey1;

		private readonly int int_HeistAddStatValue1;

		private readonly int int_HeistAddStatValue2;

		private readonly long intptr_18x;

		private readonly long intptr_26;

		private readonly int int_34;

		private readonly byte byte_35;

		private readonly byte byte_36;

		private readonly byte byte_37;
	}

	[Serializable]
	private sealed class Class376
	{
		public static readonly Class376 Class9 = new Class376();

		internal string method_0(ModAffix.StatContainer statContainer_0)
		{
			return statContainer_0.ToString();
		}
	}

	public int Index { get; }

	public int ModId { get; }

	public int Level { get; }

	public string Category { get; }

	public string InternalName { get; }

	public string DisplayName { get; }

	public ModType ModType { get; }

	public ModAffix.StatContainer[] Stats { get; }

	public List<string> Tags { get; }

	public string TypeName { get; }

	public string TierString { get; }

	internal Memory ExternalProcessMemory_0 => LokiPoe.Memory;

	internal Struct316 Struct316_0 { get; set; }

	internal DatModsWrapper(Struct316 native, int index)
	{
		Struct316_0 = native;
		Index = index;
		ModId = Struct316_0.int_0;
		Level = Struct316_0.int_Level;
		InternalName = ExternalProcessMemory_0.ReadStringU(Struct316_0.intptr_Id);
		DisplayName = ExternalProcessMemory_0.ReadStringU(Struct316_0.intptr_Name);
		Category = ExternalProcessMemory_0.ReadStringU(ExternalProcessMemory_0.ReadLong(Struct316_0.intptr_Group4, default(long)));
		ModType = (ModType)Struct316_0.int_3;
		Stats = new ModAffix.StatContainer[4];
		Stats[0] = new ModAffix.StatContainer(Struct316_0.keyValuePair_Stat1Values, Struct316_0.struct243_Stats0);
		Stats[1] = new ModAffix.StatContainer(Struct316_0.keyValuePair_Stat2Values, Struct316_0.struct243_Stats1);
		Stats[2] = new ModAffix.StatContainer(Struct316_0.keyValuePair_Stat3Values, Struct316_0.struct243_Stats2);
		Stats[3] = new ModAffix.StatContainer(Struct316_0.keyValuePair_Stat4Values, Struct316_0.struct243_Stats3);
		Tags = new List<string>();
		Struct242[] array = ExternalProcessMemory_0.ReadStructure242StructsArray<Struct242>(Struct316_0.intptr_8TagsKey, Struct316_0.int_6TagsCount);
		for (int i = 0; i < array.Length; i++)
		{
			Struct242 @struct = array[i];
			Tags.Add(ExternalProcessMemory_0.ReadStringU(ExternalProcessMemory_0.ReadLong(@struct.intptr_1)));
		}
		TypeName = ExternalProcessMemory_0.ReadStringU(ExternalProcessMemory_0.ReadLong(Struct316_0.intptr_ModTypeDatAccress));
		TierString = "";
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = stringBuilder;
		string format = "[{8}] Level: {0}, Category: {1}, InternalName: {2}, DisplayName: {3}, ModType: {4}, TypeName: {5}, Stats: {6}, Tags: {7}";
		stringBuilder2.AppendLine(string.Format(format, Level, Category, InternalName, DisplayName, ModType, TypeName, string.Join(", ", Stats.Select(Class376.Class9.method_0)), string.Join(", ", Tags), TierString));
		return stringBuilder.ToString();
	}
}
