using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Structures.ns19;
using log4net;

namespace DreamPoeBot.Loki.Game.Objects;

public class ModAffix
{
	public class StatContainer
	{
		private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

		public int Min { get; private set; }

		public int Max { get; private set; }

		public StatTypeGGG Stat { get; private set; }

		public string Description { get; private set; }

		internal StatContainer(KeyValuePair<int, int> minMax, Struct243 datRef)
		{
			Min = minMax.Key;
			Max = minMax.Value;
			if (datRef.intptr_1 == 0L)
			{
				return;
			}
			DatStatWrapper statWrapperByAddress = Dat.GetStatWrapperByAddress(datRef.intptr_1, bool_0: true);
			StatTypeGGG value;
			try
			{
				if (string.IsNullOrEmpty(statWrapperByAddress.ApiId))
				{
					value = StatTypeGGG.Level;
				}
				else if (!LokiPoe.StringStatTypeGGG.TryGetValue(statWrapperByAddress.ApiId, out value))
				{
					ilog_0.ErrorFormat("[StatContainer] The stat \"{0}\" does not exist. Please report this issue, because it's related to your system culture settings.", (object)statWrapperByAddress.ApiId);
					value = StatTypeGGG.Level;
				}
			}
			catch (Exception)
			{
				value = StatTypeGGG.Level;
			}
			Stat = value;
			Description = statWrapperByAddress.Description;
		}

		public override string ToString()
		{
			return string.Format("{2} [{0} - {1}] ({3})", Min, Max, Stat, Description);
		}
	}

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public string TierString { get; private set; }

	public int Level { get; set; }

	public string Category { get; private set; }

	public string InternalName { get; private set; }

	public string DisplayName { get; private set; }

	public bool IsHidden { get; private set; }

	public bool IsPrefix { get; private set; }

	public bool IsSuffix { get; private set; }

	public bool IsFractured { get; private set; }

	public StatContainer[] Stats { get; private set; }

	public List<int> Values { get; private set; }

	internal ModAffix(Mods.StructModsInfo container, bool isFractured = false)
	{
		Memory memory = LokiPoe.Memory;
		Values = Containers.StdIntVector<int>(container.ModsValues);
		DatModsWrapper.Struct316 @struct = memory.FastIntPtrToStruct<DatModsWrapper.Struct316>(container.struct243_0.intptr_1);
		Level = @struct.int_Level;
		InternalName = memory.ReadStringU(@struct.intptr_Id);
		DisplayName = memory.ReadStringU(@struct.intptr_Name);
		Category = memory.ReadStringU(memory.ReadLong(memory.ReadLong(@struct.intptr_Group4)));
		IsPrefix = @struct.int_3 == 1;
		IsSuffix = @struct.int_3 == 2;
		IsHidden = @struct.int_3 == 3;
		IsFractured = isFractured;
		Stats = new StatContainer[4];
		Stats[0] = new StatContainer(@struct.keyValuePair_Stat1Values, @struct.struct243_Stats0);
		Stats[1] = new StatContainer(@struct.keyValuePair_Stat2Values, @struct.struct243_Stats1);
		Stats[2] = new StatContainer(@struct.keyValuePair_Stat3Values, @struct.struct243_Stats2);
		Stats[3] = new StatContainer(@struct.keyValuePair_Stat4Values, @struct.struct243_Stats3);
		TierString = "";
	}

	public override string ToString()
	{
		string format = "TierString: {9}, Level: {0}, Category: {1}, InternalName: {2}, DisplayName: {3}, IsHidden: {4}, IsPrefix: {5}, IsSuffix: {6}, IsFractured: {10}, Stats: {7}, Values: {8}";
		return string.Format(format, Level, Category, InternalName, DisplayName, IsHidden, IsPrefix, IsSuffix, string.Join(", ", Stats.Select((StatContainer x) => x.ToString())), string.Join(", ", Values.Select((int x) => x.ToString())), TierString, IsFractured);
	}
}
