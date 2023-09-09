namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class DeployedObject
{
	public uint ObjectId { get; private set; }

	public ushort ObjectKey { get; private set; }

	internal DeployedObject(uint objId, ushort objectKey)
	{
		ObjectId = objId;
		ObjectKey = objectKey;
	}
}
