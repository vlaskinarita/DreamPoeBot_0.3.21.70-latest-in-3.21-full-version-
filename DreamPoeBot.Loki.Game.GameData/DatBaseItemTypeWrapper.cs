using System;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Models;
using log4net;

namespace DreamPoeBot.Loki.Game.GameData;

public class DatBaseItemTypeWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DatBaseItemTypeStucture
	{
		public long intptr_0Metadata;

		public long intptr_1ItemClass;

		private long intptr_2;

		private int int_0;

		private int int_1;

		public long intptr_3Name;

		private long intptr_4;

		public int int_2DropLevel;

		private int int_3;

		private int int_4;

		private int int_5;

		private long intptr_5;

		private int int_6;

		private long intptr_6;

		private long intptr_7;

		private int int_7;

		private long intptr_8;

		private int int_8;

		private long intptr_9;

		private int int_9;

		private long intptr_10;

		private int int_10;

		private long intptr_11;

		private int int_11;

		private long intptr_12;

		private int int_12;

		private byte byte_0;

		private long intptr_13;

		private long intptr_14;

		private uint uint_0;

		private int int_13;

		private long intptr_15;

		private int int_14;

		private long intptr_16;

		private int int_15;

		private long intptr_17;

		private int int_16;

		private long intptr_18;

		private int int_17;

		private long intptr_19;

		private long intptr_20;

		private int int_18;

		private byte byte_1;

		private int int_19;

		private int int_20;

		private long intptr_21;

		private long intptr_22;

		private long intptr_23;

		private long intptr_24;

		private long intptr_25;

		private long intptr_26;

		private byte byte_2;

		private int int_21;
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	internal BaseItemTypeEnum BaseItemTypeEnum { get; private set; }

	public string Metadata { get; private set; }

	public string Name { get; private set; }

	public string ItemClass { get; private set; }

	public int DropLevel { get; private set; }

	public int Index { get; private set; }

	public long BaseAddress { get; }

	internal Memory M => GameController.Instance.Memory;

	private void method_0(BaseItemType native, string metadata)
	{
		Metadata = metadata;
		Name = native.BaseName;
		ItemClass = native.ClassName;
		DropLevel = native.DropLevel;
		if (!Enum.TryParse<BaseItemTypeEnum>(LokiPoe.CleanifyMetadataString(Metadata), ignoreCase: true, out var result))
		{
			BaseItemTypeEnum--;
		}
		else
		{
			BaseItemTypeEnum = result;
		}
	}

	private void method_0(DatBaseItemTypeStucture struct292_1)
	{
		DatBaseItemTypeStucture datBaseItemTypeStucture = struct292_1;
		Metadata = M.ReadStringU(datBaseItemTypeStucture.intptr_0Metadata);
		Name = M.ReadStringU(datBaseItemTypeStucture.intptr_3Name);
		ItemClass = M.ReadStringU(M.ReadLong(datBaseItemTypeStucture.intptr_1ItemClass));
		DropLevel = datBaseItemTypeStucture.int_2DropLevel;
		if (!Enum.TryParse<BaseItemTypeEnum>(LokiPoe.CleanifyMetadataString(Metadata), ignoreCase: true, out var result))
		{
			BaseItemTypeEnum--;
			if (!Metadata.Contains("Royale") && !Metadata.Contains("Metadata/Items/Heist/"))
			{
				ilog_0.ErrorFormat("[DatBaseItemTypeWrapper] No enum found for {0}.", (object)Metadata);
			}
		}
		else
		{
			BaseItemTypeEnum = result;
		}
	}

	internal DatBaseItemTypeWrapper(long ptr)
	{
		BaseAddress = ptr;
		Index = -1;
		method_0(M.FastIntPtrToStruct<DatBaseItemTypeStucture>(BaseAddress));
	}

	internal DatBaseItemTypeWrapper(long address, BaseItemType native, string metadata, int index)
	{
		BaseAddress = address;
		Index = index;
		method_0(native, metadata);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[{Index}] ");
		stringBuilder.AppendLine($"\tBaseAddress: 0x{BaseAddress:X} ");
		stringBuilder.AppendLine($"Name: {Name} ");
		stringBuilder.AppendLine($"Metadata: {Metadata}");
		return stringBuilder.ToString();
	}
}
