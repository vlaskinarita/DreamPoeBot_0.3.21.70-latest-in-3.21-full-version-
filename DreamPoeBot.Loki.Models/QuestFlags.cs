using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.Models;

public class QuestFlags
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct QuestFlagsStructure
	{
		public long Id;

		public long Hash32;
	}

	public long Address { get; set; }

	public string Id { get; set; }

	public long Hash32 { get; set; }

	public int index { get; set; }
}
