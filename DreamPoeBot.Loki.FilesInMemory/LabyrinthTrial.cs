using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.FilesInMemory;

public class LabyrinthTrial : RemoteMemoryObject
{
	private int id = -1;

	public WorldArea area;

	public int Id
	{
		get
		{
			if (id == -1)
			{
				return id = base.M.ReadInt(base.Address + 16L);
			}
			return id;
		}
	}

	public WorldArea Area
	{
		get
		{
			if (area == null)
			{
				long address = GameController.Instance.Memory.ReadLong(base.Address + 8L);
				area = GameController.Instance.Files.WorldAreas.GetByAddress(address);
			}
			return area;
		}
	}
}
