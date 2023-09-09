using System.Runtime.Serialization;
using DreamPoeBot.Common;

namespace DreamPoeBot.Auth.Objects;

[KnownType(typeof(Vector3))]
[DataContract(Name = "WoWMailbox", Namespace = "Buddy.Auth.Objects")]
internal class WoWMailbox
{
	[DataMember]
	public uint Entry { get; set; }

	[DataMember]
	public Vector3 Location { get; set; }

	[DataMember]
	public uint FactionId { get; set; }

	[DataMember]
	public int MapId { get; set; }
}
