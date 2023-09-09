using DreamPoeBot.Common;

namespace DreamPoeBot.Loki.Models;

public class AreaTilesData
{
	public Vector2i Point { get; set; }

	public int X { get; set; }

	public int Y { get; set; }

	public byte Byte { get; set; }

	public bool IsWalkable => Byte > 17;
}
