using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class PartyMember : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct280
	{
		public byte byte_0PartyStatus;

		public byte byte_1;

		public byte byte_2;

		public byte byte_3;

		private int unusedInt0;

		public long intptr_0;
	}

	private readonly Struct280? nullable_0;

	public PartyStatus MemberStatus => (PartyStatus)Struct280_0.byte_0PartyStatus;

	public PlayerEntry PlayerEntry => new PlayerEntry(Struct280_0.intptr_0);

	internal Struct280 Struct280_0
	{
		get
		{
			if (nullable_0.HasValue)
			{
				return nullable_0.Value;
			}
			return base.M.FastIntPtrToStruct<Struct280>(base.Address);
		}
	}

	internal PartyMember(long address)
		: base(address)
	{
	}

	internal PartyMember(long ptr, Struct280 native)
		: base(ptr)
	{
		nullable_0 = native;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("[MemberStatus: {0}]", MemberStatus.ToString());
		stringBuilder.AppendFormat("[PlayerEntry: {0}]", PlayerEntry.ToString());
		return stringBuilder.ToString();
	}
}
