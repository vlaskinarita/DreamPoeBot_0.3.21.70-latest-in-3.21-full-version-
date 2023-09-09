using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class WorldArea : RemoteMemoryObject
{
	private string id;

	private string name;

	private List<WorldArea> connections;

	private List<WorldArea> corruptedAreas;

	public string Id
	{
		get
		{
			if (id == null)
			{
				return id = base.M.ReadStringU(base.M.ReadLong(base.Address));
			}
			return id;
		}
	}

	public int Index { get; internal set; }

	public string Name
	{
		get
		{
			if (name == null)
			{
				return name = base.M.ReadStringU(base.M.ReadLong(base.Address + 8L), 255);
			}
			return name;
		}
	}

	public int Act => base.M.ReadInt(base.Address + 16L);

	public bool IsTown => base.M.ReadByte(base.Address + 20L) == 1;

	public bool IsHideOut => Id.Contains("Hideout");

	public bool IsMenagerieArea => Id.Contains("Menagerie_Hub");

	public bool HasWaypoint => base.M.ReadByte(base.Address + 21L) == 1;

	public int AreaLevel => base.M.ReadInt(base.Address + 38L);

	public int WorldAreaId => base.M.ReadInt(base.Address + 42L);

	public bool IsAtlasMap => Id.StartsWith("MapAtlas");

	public bool IsMapWorlds => Id.StartsWith("MapWorlds");

	public bool IsCorruptedArea
	{
		get
		{
			if (!Id.Contains("SideArea"))
			{
				return Id.Contains("Sidearea");
			}
			return true;
		}
	}

	public bool IsMissionArea => Id.Contains("Mission");

	public bool IsDailyArea => Id.Contains("Daily");

	public bool IsMapTrialArea => Id.StartsWith("EndGame_Labyrinth_trials");

	public bool IsLabyrinthArea
	{
		get
		{
			if (!IsMapTrialArea)
			{
				return Id.Contains("Labyrinth");
			}
			return false;
		}
	}

	public bool IsAspirantsPlaza
	{
		get
		{
			if (!IsMapTrialArea)
			{
				return Id.Contains("Labyrinth_Airlock");
			}
			return false;
		}
	}

	public bool IsAbyssArea
	{
		get
		{
			if (!Id.Equals("AbyssLeague") && !Id.Equals("AbyssLeague2") && !Id.Equals("AbyssLeagueBoss") && !Id.Equals("AbyssLeagueBoss2"))
			{
				return Id.Equals("AbyssLeagueBoss3");
			}
			return true;
		}
	}

	public List<WorldArea> Connections
	{
		get
		{
			if (connections == null)
			{
				connections = new List<WorldArea>();
				Memory memory = GameController.Instance.Memory;
				int num = base.M.ReadInt(base.Address + 22L);
				long num2 = base.M.ReadLong(base.Address + 30L);
				for (int i = 0; i < num; i++)
				{
					WorldArea byAddress = GameController.Instance.Files.WorldAreas.GetByAddress(memory.ReadLong(num2));
					connections.Add(byAddress);
					num2 += 8L;
				}
			}
			return connections;
		}
	}

	public List<WorldArea> CorruptedAreas
	{
		get
		{
			if (corruptedAreas == null)
			{
				corruptedAreas = new List<WorldArea>();
				Memory memory = GameController.Instance.Memory;
				long num = base.M.ReadLong(base.Address + 259L);
				int num2 = base.M.ReadInt(base.Address + 251L);
				for (int i = 0; i < num2; i++)
				{
					WorldArea byAddress = GameController.Instance.Files.WorldAreas.GetByAddress(memory.ReadLong(num));
					corruptedAreas.Add(byAddress);
					num += 8L;
				}
			}
			return corruptedAreas;
		}
	}

	public override string ToString()
	{
		return Name ?? "";
	}
}
