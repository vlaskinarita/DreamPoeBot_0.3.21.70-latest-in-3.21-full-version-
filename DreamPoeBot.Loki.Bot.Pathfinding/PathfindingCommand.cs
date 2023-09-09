using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Common;

namespace DreamPoeBot.Loki.Bot.Pathfinding;

public class PathfindingCommand
{
	public TimeSpan Elapsed { get; set; }

	public Vector2i StartPoint { get; set; }

	public Vector2i EndPoint { get; set; }

	public IndexedList<Vector2i> Path { get; set; }

	public List<Vector2i> Jumps { get; set; }

	public PathfindingError Error { get; set; }

	public float TotalDistance { get; set; }

	public float DistanceFromDestination { get; set; }

	public float DistanceBetweenHops { get; set; }

	public bool Humanize { get; set; } = true;


	public bool AvoidWallHugging { get; set; }

	public float DistanceFromWall { get; set; }

	public bool UseJumpMesh { get; set; }

	public PathfindingCommand(Vector2i start, Vector2i end, float distanceBetweenHops = 15f, bool avoidWallHugging = true, float distanceFromWall = 9f, bool useJumpMesh = false)
	{
		Elapsed = TimeSpan.MinValue;
		StartPoint = start;
		EndPoint = end;
		Error = PathfindingError.None;
		AvoidWallHugging = avoidWallHugging;
		DistanceFromWall = distanceFromWall;
		DistanceBetweenHops = distanceBetweenHops;
		UseJumpMesh = useJumpMesh;
	}
}
