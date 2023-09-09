using System.Runtime.Serialization;
using DreamPoeBot.Common;

namespace DreamPoeBot.Auth.Objects;

[DataContract(Name = "WoWFragment", Namespace = "Buddy.Auth.Objects")]
[KnownType(typeof(Vector3))]
internal class WoWFragment
{
	[DataMember]
	public uint DigsiteId { get; set; }

	[DataMember]
	public Vector3 Location { get; set; }

	[DataMember]
	public string Type { get; set; }

	[DataMember]
	public bool HigherZExists { get; set; }

	[DataMember]
	public bool Outdoors { get; set; }
}
