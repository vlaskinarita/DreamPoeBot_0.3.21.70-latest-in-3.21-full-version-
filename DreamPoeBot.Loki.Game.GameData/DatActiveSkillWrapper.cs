using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatActiveSkillWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ActiveSkills
	{
		public long intptr_0InternalId;

		public long intptr_1DisplayName;

		public long intptr_2Description;

		public long intptr_3InternalName;

		public long intptr_4Icon;

		public int int_0CastTypesCount;

		private int int_unused0;

		public long intptr_5CastTypesAddress;

		public int int_1SkillTypesCount;

		private int int_unused1;

		public long intptr_6SkillTypesAddress;

		private int int_2unused;

		private int int_unused2;

		private long intptr_7unused;

		public long intptr_8LongDescription;

		public long intptr_9AmazonLink;

		private byte byte_0unused;

		public long intptr_10BaseInternalName;

		private byte byte_1unused;

		private long intptr_11unused;

		private byte byte_2unused;

		public int int_3SkillStatsCount;

		public long intptr_12SkillStatsAddress;

		public int int_4BaseStatsCount;

		private int int_unused3;

		public long intptr_13BaseStatsAddress;

		public int int_5_53Count;

		private int int_unused4;

		public long intptr_14_53Address;

		private byte byte_3unused;

		private byte byte_4unused;

		private byte byte_5unused;

		private byte byte_6unused;

		private byte byte_7unused;

		private int int_unused5;

		private long intptr_15_53;

		private byte byte_8unused;

		private byte byte_9unused;

		private byte byte_10unused;

		private byte byte_11unused;

		private byte byte_12unused;

		private long intptr_15_54;

		private long intptr_15_55;

		private byte byte_13unused;

		public long intptr_0;

		private int int_unused6;

		private int int_unused7;

		public long intptr_1;

		private byte byte_14unused;

		private byte byte_15unused;

		private byte byte_16unused;
	}

	private int _struct243Size = -1;

	private int _activeSkillsSize = -1;

	public int Index { get; private set; }

	public string InternalId { get; private set; }

	public string DisplayName { get; private set; }

	public string InternalName { get; private set; }

	public string BaseInternalName { get; private set; }

	public string Icon { get; private set; }

	public string Description { get; private set; }

	public string LongDescription { get; private set; }

	public string AmazonLink { get; private set; }

	public List<int> CastTypes { get; private set; }

	public List<int> _53 { get; private set; }

	public List<int> SkillTypes { get; private set; }

	public bool SkillTypeRequiresPercentPower { get; private set; }

	public bool SkillTypeRequiresReservedPower { get; private set; }

	private int Struct243Size
	{
		get
		{
			if (_struct243Size == -1)
			{
				_struct243Size = MarshalCache<Struct243>.Size;
			}
			return _struct243Size;
		}
	}

	public List<DatStatWrapper> SkillStats
	{
		get
		{
			List<DatStatWrapper> list = new List<DatStatWrapper>();
			Struct243[] array = ExternalProcessMemory_0.IntptrToStructArray<Struct243>(Struct289_0.intptr_12SkillStatsAddress, Struct289_0.int_3SkillStatsCount, Struct243Size);
			for (int i = 0; i < array.Length; i++)
			{
				Struct243 @struct = array[i];
				list.Add(new DatStatWrapper(@struct.intptr_1));
			}
			return list;
		}
	}

	public List<DatStatWrapper> BaseStats
	{
		get
		{
			List<DatStatWrapper> list = new List<DatStatWrapper>();
			Struct243[] array = ExternalProcessMemory_0.IntptrToStructArray<Struct243>(Struct289_0.intptr_13BaseStatsAddress, Struct289_0.int_4BaseStatsCount, Struct243Size);
			for (int i = 0; i < array.Length; i++)
			{
				Struct243 @struct = array[i];
				list.Add(new DatStatWrapper(@struct.intptr_1));
			}
			return list;
		}
	}

	public long BaseAddress { get; private set; }

	internal Memory ExternalProcessMemory_0 => GameController.Instance.Memory;

	internal ActiveSkills Struct289_0 { get; set; }

	private int ActiveSkillsSize
	{
		get
		{
			if (_activeSkillsSize == -1)
			{
				_activeSkillsSize = MarshalCache<ActiveSkills>.Size;
			}
			return _activeSkillsSize;
		}
	}

	public bool IsCastType(int index)
	{
		return CastTypes.Contains(index);
	}

	public bool IsSkillType(int index)
	{
		return SkillTypes.Contains(index);
	}

	private void method_0(ActiveSkills struct289_1)
	{
		Struct289_0 = struct289_1;
		InternalId = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_0InternalId);
		DisplayName = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_1DisplayName);
		InternalName = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_3InternalName);
		BaseInternalName = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_10BaseInternalName);
		Icon = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_4Icon);
		Description = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_2Description);
		LongDescription = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_8LongDescription);
		AmazonLink = LokiPoe.staticStringCache_0.ReadStringW(Struct289_0.intptr_9AmazonLink);
		_53 = ExternalProcessMemory_0.ReadArrayInt(Struct289_0.intptr_14_53Address, Struct289_0.int_5_53Count).ToList();
		CastTypes = new List<int>();
		int[] array = ExternalProcessMemory_0.ReadArrayInt(Struct289_0.intptr_5CastTypesAddress, Struct289_0.int_0CastTypesCount);
		int num = 0;
		int num2;
		while (true)
		{
			if (num < array.Length)
			{
				num2 = array[num];
				CastTypes.Add(num2);
				if (num2 < 0 || num2 > 23)
				{
					break;
				}
				num++;
				continue;
			}
			SkillTypes = new List<int>();
			List<long> list = ExternalProcessMemory_0.ReadFirstPointerArray_Count(Struct289_0.intptr_6SkillTypesAddress, Struct289_0.int_1SkillTypesCount);
			foreach (long item in list)
			{
				string text = ExternalProcessMemory_0.ReadStringU(ExternalProcessMemory_0.ReadLong(item));
				if (Enum.TryParse<ActiveSkillTypeEnum>(text, out var result))
				{
					SkillTypes.Add((int)result);
					continue;
				}
				throw new Exception("ActiveSkillTypeEnum Do not contain definition for: " + text + ".");
			}
			return;
		}
		throw new Exception($"New CastType [{num2}]");
	}

	internal DatActiveSkillWrapper(long address, ActiveSkills native, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native);
	}

	internal DatActiveSkillWrapper(long ptr)
	{
		BaseAddress = ptr;
		Index = -1;
		method_0(ExternalProcessMemory_0.FastIntPtrToStruct<ActiveSkills>(BaseAddress, ActiveSkillsSize));
	}

	public override string ToString()
	{
		_ = Struct289_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[{Index}]");
		stringBuilder.AppendLine($"\tInternalId: {InternalId}");
		stringBuilder.AppendLine($"\tDisplayName: {DisplayName}");
		stringBuilder.AppendLine($"\tInternalName: {InternalName}");
		stringBuilder.AppendLine($"\tBaseInternalName: {BaseInternalName}");
		stringBuilder.AppendLine($"\tIcon: {Icon}");
		stringBuilder.AppendLine($"\tLongDescription: {LongDescription}");
		stringBuilder.AppendLine($"\tAmazonLink: {AmazonLink}");
		stringBuilder.AppendLine(string.Format("\tCastTypes: {0}", string.Join(" | ", CastTypes)));
		stringBuilder.AppendLine(string.Format("\tSkillTypes: {0}", string.Join(" | ", SkillTypes)));
		List<DatStatWrapper> skillStats = SkillStats;
		if (skillStats.Any())
		{
			stringBuilder.AppendLine($"\tSkillStats");
			foreach (DatStatWrapper item in skillStats)
			{
				stringBuilder.AppendLine($"\t\t{item.Id}");
			}
		}
		skillStats = BaseStats;
		if (skillStats.Any())
		{
			stringBuilder.AppendLine($"\tBaseStats");
			foreach (DatStatWrapper item2 in skillStats)
			{
				stringBuilder.AppendLine($"\t\t{item2.Id}");
			}
		}
		if (_53.Any())
		{
			stringBuilder.AppendLine(string.Format("\t_53: {0}", string.Join(" | ", _53)));
		}
		return stringBuilder.ToString();
	}
}
