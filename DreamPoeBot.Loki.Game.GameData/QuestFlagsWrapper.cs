using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Models;

namespace DreamPoeBot.Loki.Game.GameData;

public class QuestFlagsWrapper
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct QuestFlagsWrapperStructure
	{
		public long QuestStateData;

		private long QuestStateFile;

		public byte isUnlocked;

		private byte byte_0;

		private short shotr_0;

		private short shotr_1;

		private short shotr_2;
	}

	public long Address { get; }

	public string Id { get; }

	public int IsUnlocked { get; }

	public QuestFlagsWrapper(long address)
	{
		QuestFlagsWrapperStructure questFlagsWrapperStructure = LokiPoe.Memory.FastIntPtrToStruct<QuestFlagsWrapperStructure>(address);
		QuestFlags.QuestFlagsStructure questFlagsStructure = LokiPoe.Memory.FastIntPtrToStruct<QuestFlags.QuestFlagsStructure>(questFlagsWrapperStructure.QuestStateData);
		Id = LokiPoe.Memory.ReadStringU(questFlagsStructure.Id);
		IsUnlocked = questFlagsWrapperStructure.isUnlocked;
		Address = questFlagsWrapperStructure.QuestStateData;
	}
}
