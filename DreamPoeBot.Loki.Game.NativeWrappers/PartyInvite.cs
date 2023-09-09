using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;

namespace DreamPoeBot.Loki.Game.NativeWrappers;

public class PartyInvite : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct279
	{
		public int int_0;

		public int Unusedint_0;

		public NativeStringWCustom nativeStringW_0;

		public NativeStringWCustom nativeStringW_1;

		public NativeStringWCustom nativeStringW_2;

		public NativeStringWCustom nativeStringW_3;

		public int int_1;

		public int Unusedint_1;

		public NativeVector nativeVector_0;

		public byte byte_2;

		public byte byte_3;

		public byte byte_4;

		public byte byte_5;

		public int Unusedint_2;
	}

	private readonly Struct279? nullable_0;

	internal Struct279 Struct279_0
	{
		get
		{
			if (nullable_0.HasValue)
			{
				return nullable_0.Value;
			}
			return base.M.FastIntPtrToStruct<Struct279>(base.Address);
		}
	}

	public int PartyId => Struct279_0.int_0;

	public string Unknown_04 => Containers.StdStringWCustom(Struct279_0.nativeStringW_0);

	public string PartyDescription => Containers.StdStringWCustom(Struct279_0.nativeStringW_1);

	public string CreatorAccountName => Containers.StdStringWCustom(Struct279_0.nativeStringW_2);

	public int Unknown_4C => Struct279_0.int_1;

	public List<PartyMember> PartyMembers
	{
		get
		{
			List<KeyValuePair<long, PartyMember.Struct280>> source = Containers.StdLong_Struct280List<PartyMember.Struct280>(Struct279_0.nativeVector_0);
			return source.Select((KeyValuePair<long, PartyMember.Struct280> x) => new PartyMember(x.Key, x.Value)).ToList();
		}
	}

	public PartyAllocationType PartyAllocation => (PartyAllocationType)Struct279_0.byte_2;

	internal PartyInvite(long address)
		: base(address)
	{
	}

	internal PartyInvite(long ptr, Struct279 native)
		: base(ptr)
	{
		nullable_0 = native;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("[BaseAddress: {0}]", base.Address);
		stringBuilder.AppendFormat("[Id: {0}]", PartyId);
		stringBuilder.AppendFormat("[Unknown_04: {0}]", Unknown_04);
		stringBuilder.AppendFormat("[PartyDescription: {0}]", PartyDescription);
		stringBuilder.AppendFormat("[CreatorAccountName: {0}]", CreatorAccountName);
		stringBuilder.AppendFormat("[Unknown_4C: {0}]", Unknown_4C);
		foreach (PartyMember partyMember in PartyMembers)
		{
			stringBuilder.AppendFormat("[PartyMembers: {0}]", partyMember.ToString());
		}
		stringBuilder.AppendFormat("[PartyAllocation: {0}]", PartyAllocation.ToString());
		return stringBuilder.ToString();
	}
}
