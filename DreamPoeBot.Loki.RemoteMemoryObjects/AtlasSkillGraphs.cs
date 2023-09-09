using System.Runtime.InteropServices;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class AtlasSkillGraphs : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructAtlasRegionsFile
	{
		public long Unknown;

		public long Metadata;

		public long RegionName;

		public int int_0;

		public int int_1;

		public long FavoriteMapSlots;
	}
}
