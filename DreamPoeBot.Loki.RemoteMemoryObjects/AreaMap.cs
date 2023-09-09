using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class AreaMap : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructMap
	{
		private readonly long vTable;

		private readonly long unusedPtr_2;

		private readonly long unusedPtr_00;

		private readonly long unusedPtr_0;

		private readonly long unusedPtr_1;

		public NativeVector TerrainDataEntryArrayVector;

		private readonly long unusedPtr_5;

		private readonly long unusedPtr_6;

		private readonly NativeVector unusedVector_1;

		private readonly NativeVector unusedVector_2;

		public readonly int unusedInt_0;

		private readonly int unusedInt_1;

		public readonly Vector2i MapSize;

		private readonly long unusedPtr_11;

		private readonly long unusedPtr_12;

		private readonly long unusedPtr_13;

		private readonly long unusedPtr_14;

		private readonly long unusedPtr_15;

		private readonly long unusedPtr_16;

		private readonly long unusedPtr_17;

		private readonly long unusedPtr_18;

		public readonly NativeVector MapLayer0;

		public readonly NativeVector MapLayer1;

		public readonly int MapWidth;

		public readonly int TileHeightMultiplyer;
	}

	private static readonly int tileStructureSize = Marshal.SizeOf<LokiPoe.TerrainData.TileStructure>();

	private PerAreaCachedValue<StructMap> _perAreaCachedValueStructMap;

	private PerAreaCachedValue<LokiPoe.TerrainData.TileStructure[]> _terrainDataEntryArray;

	public Memory Memory => base.M;

	public long GrountMapStart => StructMap_0.MapLayer0.First;

	public long GroundMapEnd => StructMap_0.MapLayer0.Last;

	public long FlyMapStart => StructMap_0.MapLayer1.First;

	public long FlyMapEnd => StructMap_0.MapLayer1.Last;

	public int MapWidth => StructMap_0.MapWidth;

	public int TileHeightMultiplyier => StructMap_0.TileHeightMultiplyer;

	private StructMap StructMap_0
	{
		get
		{
			if (_perAreaCachedValueStructMap == null)
			{
				_perAreaCachedValueStructMap = new PerAreaCachedValue<StructMap>(() => base.M.FastIntPtrToStruct<StructMap>(base.Address + 2464L));
			}
			return _perAreaCachedValueStructMap;
		}
	}

	public byte[] GroundLayer0
	{
		get
		{
			NativeVector mapLayer = StructMap_0.MapLayer0;
			long first = mapLayer.First;
			long last = mapLayer.Last;
			int length = (int)(last - first);
			return base.M.ReadBytes(first, length);
		}
	}

	public byte[] FlyLayer1
	{
		get
		{
			NativeVector mapLayer = StructMap_0.MapLayer1;
			long first = mapLayer.First;
			long last = mapLayer.Last;
			int length = (int)(last - first);
			return base.M.ReadBytes(first, length);
		}
	}

	public Vector2i Size => StructMap_0.MapSize;

	public int Cols => Size.X;

	public int Rows => Size.Y;

	public Vector2i SizeInNavCells => Size * 23;

	public int BytesPerRow => MapWidth;

	public long TerrainDataEntryArrayPointer => StructMap_0.TerrainDataEntryArrayVector.First;

	public long TerrainDataEntryArrayPointerLast => StructMap_0.TerrainDataEntryArrayVector.Last;

	internal LokiPoe.TerrainData.TileStructure[] TerrainDataEntryArray
	{
		get
		{
			if (_terrainDataEntryArray == null)
			{
				_terrainDataEntryArray = new PerAreaCachedValue<LokiPoe.TerrainData.TileStructure[]>(GetTerrainDataEntryArray);
			}
			return _terrainDataEntryArray;
		}
	}

	private LokiPoe.TerrainData.TileStructure[] GetTerrainDataEntryArray()
	{
		long num = (TerrainDataEntryArrayPointerLast - TerrainDataEntryArrayPointer) / tileStructureSize;
		return base.M.ReadTerrainStructsArray<LokiPoe.TerrainData.TileStructure>(TerrainDataEntryArrayPointer, (int)num);
	}
}
