using System.Runtime.Serialization;

namespace DreamPoeBot.Auth.Objects;

[KnownType(typeof(WoWMailbox))]
[DataContract(Name = "WoWMailboxEx", Namespace = "Buddy.Auth.Objects")]
internal class WoWMailboxEx : WoWMailbox
{
	[DataMember]
	public uint PlayerCondition { get; set; }
}
