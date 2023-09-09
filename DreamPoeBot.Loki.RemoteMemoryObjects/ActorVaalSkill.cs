using System.Runtime.InteropServices;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ActorVaalSkill : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct138
	{
		public Struct243 struct243_0;

		public int int_0;

		public int int_1;

		public int int_2;

		public byte byte_0;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;
	}

	private const int NAMES_POINTER_OFFSET = 8;

	private const int INTERNAL_NAME_OFFSET = 0;

	private const int NAME_OFFSET = 8;

	private const int DESCRIPTION_OFFSET = 16;

	private const int SKILL_NAME_OFFSET = 24;

	private const int ICON_OFFSET = 32;

	private const int MAX_VAAL_SOULS_OFFSET = 16;

	private const int VAAL_SOULS_PER_USE_OFFSET = 20;

	private const int CURRENT_VAAL_SOULS_OFFSET = 24;

	public string VaalSkillInternalName => base.M.ReadStringU(base.M.ReadLong(8L));

	public string VaalSkillDisplayName => base.M.ReadStringU(base.M.ReadLong(8L) + 8L);

	public string VaalSkillDescription => base.M.ReadStringU(base.M.ReadLong(8L) + 16L);

	public string VaalSkillSkillName => base.M.ReadStringU(base.M.ReadLong(8L) + 24L);

	public string VaalSkillIcon => base.M.ReadStringU(base.M.ReadLong(8L) + 32L);

	public int VaalMaxSouls => base.M.ReadInt(base.Address + 16L);

	public int VaalSoulsPerUse => base.M.ReadInt(base.Address + 20L);

	public int CurrVaalSouls => base.M.ReadInt(base.Address + 24L);

	internal Struct138 struct138 => base.M.FastIntPtrToStruct<Struct138>(base.Address);
}
