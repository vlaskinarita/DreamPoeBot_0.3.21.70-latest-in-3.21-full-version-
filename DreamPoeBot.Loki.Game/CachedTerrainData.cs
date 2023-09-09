namespace DreamPoeBot.Loki.Game;

public class CachedTerrainData
{
	public const int TileSize = 23;

	public uint AreaHash { get; set; }

	public byte[] Data { get; set; }

	public byte[] FlyData { get; set; }

	public byte[,] JumpMask { get; set; }

	public int BPR { get; set; }

	public int Cols { get; set; }

	public int Rows { get; set; }

	public byte Value { get; set; }

	public string AreaId { get; set; }
}
