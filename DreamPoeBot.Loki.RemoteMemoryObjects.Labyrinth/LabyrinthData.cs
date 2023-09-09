using System.Collections.Generic;

namespace DreamPoeBot.Loki.RemoteMemoryObjects.Labyrinth;

public class LabyrinthData : RemoteMemoryObject
{
	internal static Dictionary<long, LabyrinthRoom> CachedRoomsDictionary;

	public List<LabyrinthRoom> Rooms
	{
		get
		{
			long num = base.M.ReadLong(base.Address);
			long num2 = base.M.ReadLong(base.Address + 8L);
			List<LabyrinthRoom> list = new List<LabyrinthRoom>();
			CachedRoomsDictionary = new Dictionary<long, LabyrinthRoom>();
			int num3 = 0;
			for (long num4 = num; num4 < num2; num4 += 96L)
			{
				if (num4 != 0L)
				{
					LabyrinthRoom labyrinthRoom = new LabyrinthRoom(base.M, num4);
					labyrinthRoom.Id = num3++;
					list.Add(labyrinthRoom);
					CachedRoomsDictionary.Add(num4, labyrinthRoom);
				}
			}
			return list;
		}
	}

	public LabyrinthData()
	{
	}

	public LabyrinthData(long address)
		: base(address)
	{
	}

	internal static LabyrinthRoom GetRoomById(long roomId)
	{
		CachedRoomsDictionary.TryGetValue(roomId, out var value);
		return value;
	}
}
