using System.Runtime.Serialization;

namespace DreamPoeBot.Auth.Objects;

[DataContract(Name = "StoreProduct", Namespace = "Buddy.Auth.Objects")]
internal class StoreProduct
{
	[DataMember]
	public string ProductName { get; set; }

	[DataMember]
	public string Version { get; set; }

	[DataMember]
	public int ProductType { get; set; }

	[DataMember]
	public byte[] Data { get; set; }
}
