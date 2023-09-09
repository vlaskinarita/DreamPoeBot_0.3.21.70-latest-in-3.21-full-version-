using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.PathfindingClient;
using log4net;
using Newtonsoft.Json;

namespace DreamPoeBot.Loki.Bot.Pathfinding;

public class RDPathfinder
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public Dictionary<Vector2i, float> Obstacles = new Dictionary<Vector2i, float>();

	public uint GeneratedAreaHash;

	public bool AreaGenerated => RDClient.Channel.AreaGenerated(RDClient.Name);

	public RDPathfinder()
	{
		RDClient.Channel.CreateNewPathfinder(RDClient.Name);
	}

	~RDPathfinder()
	{
	}

	public void AddObstacle(Vector2i triggerableBlockagePosition, float range)
	{
		RDClient.Channel.AddObstacle(RDClient.Name, triggerableBlockagePosition.X, triggerableBlockagePosition.Y, range);
		if (!Obstacles.ContainsKey(triggerableBlockagePosition))
		{
			Obstacles.Add(triggerableBlockagePosition, range);
			ExilePather.SignalObstacleUpdate();
		}
	}

	public void RemoveObstacle(Vector2i triggerableBlockagePosition)
	{
		RDClient.Channel.RemoveObstacle(RDClient.Name, triggerableBlockagePosition.X, triggerableBlockagePosition.Y);
		if (Obstacles.ContainsKey(triggerableBlockagePosition))
		{
			Obstacles.Remove(triggerableBlockagePosition);
			ExilePather.SignalObstacleUpdate();
		}
	}

	public void ClearObstacles()
	{
		RDClient.Channel.ClearObstacles(RDClient.Name);
		Obstacles.Clear();
		ExilePather.SignalObstacleUpdate();
	}

	public void UpdateObstacles()
	{
		RDClient.Channel.UpdateObstacles(RDClient.Name);
	}

	public void Destroy()
	{
		RDClient.Channel.DestroyPathfinder(RDClient.Name);
		GeneratedAreaHash = 0u;
		Obstacles.Clear();
		ExilePather.SignalObstacleUpdate();
	}

	public void ProcessEntireZone(CachedTerrainData cachedTerrainData, bool multiThreadProcessing)
	{
		RDClient.Channel.ProcessEntireZone(RDClient.Name, cachedTerrainData.AreaHash, cachedTerrainData.Data, cachedTerrainData.BPR, cachedTerrainData.Cols, cachedTerrainData.Rows, cachedTerrainData.Value, cachedTerrainData.AreaId, multiThreadProcessing);
		GeneratedAreaHash = cachedTerrainData.AreaHash;
		Obstacles.Clear();
		ExilePather.SignalObstacleUpdate();
	}

	public bool LiesOnPoly(Vector2i location)
	{
		return RDClient.Channel.LiesOnPoly(RDClient.Name, location.X, location.Y);
	}

	public bool FindPath(ref PathfindingCommand pathfindingCommand0)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		if (pathfindingCommand0 == null)
		{
			ilog_0.ErrorFormat("[RDPathfinder] Command is null.", Array.Empty<object>());
			return false;
		}
		JsonSerializerSettings val = new JsonSerializerSettings();
		val.NullValueHandling = (NullValueHandling)0;
		string data = JsonConvert.SerializeObject((object)pathfindingCommand0, val);
		string text = RDClient.Channel.FindPath(RDClient.Name, data);
		PathfindingCommand pathfindingCommand = JsonConvert.DeserializeObject<PathfindingCommand>(text);
		pathfindingCommand0 = pathfindingCommand;
		if (pathfindingCommand0 != null)
		{
			if (pathfindingCommand0.Path == null)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public void SaveMapPicture()
	{
		RDClient.Channel.SaveMapPicture(RDClient.Name);
	}

	public NewTrisClass ExternalGetTris()
	{
		string text = RDClient.Channel.ExternalGetTris(RDClient.Name);
		if (!string.IsNullOrEmpty(text))
		{
			NewTrisClass newTrisClass = null;
			try
			{
				return JsonConvert.DeserializeObject<NewTrisClass>(text);
			}
			catch (Exception value)
			{
				Console.WriteLine(value);
				return null;
			}
		}
		return null;
	}
}
