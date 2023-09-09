namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class AreaTemplate : RemoteMemoryObject
{
	public string Id => base.M.ReadStringU(base.M.ReadLong(base.Address));

	public string Name => base.M.ReadStringU(base.M.ReadLong(base.Address + 8L));

	public int Act => base.M.ReadInt(base.Address + 16L);

	public bool IsTown => base.M.ReadByte(base.Address + 20L) == 1;

	public bool IsHideOut => base.M.ReadByte(base.Address + 328L) == 1;

	public bool HasWaypoint => base.M.ReadByte(base.Address + 21L) == 1;

	public int NominalLevel => base.M.ReadInt(base.Address + 22L);

	public AreaTemplate()
	{
	}

	public AreaTemplate(long address)
		: base(address)
	{
	}
}
