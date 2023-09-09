using System.Runtime.Serialization;
using DreamPoeBot.Common;

namespace DreamPoeBot.Auth.Objects;

[DataContract(Name = "WoWNpc", Namespace = "Buddy.Auth.Objects")]
[KnownType(typeof(Vector3))]
internal class WoWNpc
{
	[DataMember]
	public uint Entry { get; set; }

	[DataMember]
	public string Name { get; set; }

	[DataMember]
	public uint NpcFlags { get; set; }

	[DataMember]
	public uint NpcFlags2 { get; set; }

	[DataMember]
	public Vector3 Location { get; set; }

	[DataMember]
	public uint FactionId { get; set; }

	[DataMember]
	public string Title { get; set; }

	[DataMember]
	public int TrainerClass { get; set; }

	[DataMember]
	public int MapId { get; set; }

	[DataMember]
	public int Level { get; set; }
}
