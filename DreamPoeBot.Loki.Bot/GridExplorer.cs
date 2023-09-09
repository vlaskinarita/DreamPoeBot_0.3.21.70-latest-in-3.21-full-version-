using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Bot.Pathfinding;
using DreamPoeBot.Loki.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using log4net;

namespace DreamPoeBot.Loki.Bot;

public class GridExplorer : IExplorer, IStartStopEvents, ITickEvents
{
	public enum ExplorationMethodEnum
	{
		Breadth_First,
		Depth_First
	}

	public enum Flags
	{
		Unknown = 0,
		Known = 1,
		Seen = 2,
		Ignored = 4,
		Disconnected = 8
	}

	public class Node
	{
		public Flags Flag { get; internal set; }

		public Vector2i Location { get; internal set; }

		public Vector2i Size { get; internal set; }

		public Vector2i Index { get; internal set; }

		public Vector2i NavigableLocation { get; internal set; }

		public Vector2i Center { get; internal set; }

		public Node(int x, int y)
		{
			Flag = Flags.Unknown;
			Location = new Vector2i(x * 23, y * 23);
			Index = new Vector2i(x, y);
			Size = new Vector2i(23, 23);
			Center = Location + Size / 2;
			NavigableLocation = Center;
		}
	}

	private sealed class Class441
	{
		public GridExplorer gridExplorer;

		public int myNodeX;

		public int myNodeY;

		public Vector2i myPosition;
	}

	private sealed class Class442
	{
		public CachedTerrainData cachedTerrainData;

		public Class441 class441;

		internal void UpdateNodesFlag()
		{
			for (int i = -class441.gridExplorer.TileKnownRadius; i <= class441.gridExplorer.TileKnownRadius; i++)
			{
				for (int j = -class441.gridExplorer.TileKnownRadius; j <= class441.gridExplorer.TileKnownRadius; j++)
				{
					if (class441.myNodeX + i < 0 || class441.myNodeX + i >= class441.gridExplorer.Cols || class441.myNodeY + j < 0 || class441.myNodeY + j >= class441.gridExplorer.Rows)
					{
						continue;
					}
					Node node = class441.gridExplorer.node_0[class441.myNodeX + i, class441.myNodeY + j];
					if (i <= class441.gridExplorer.TileSeenRadius && i >= -class441.gridExplorer.TileSeenRadius && j >= -class441.gridExplorer.TileSeenRadius && j <= class441.gridExplorer.TileSeenRadius)
					{
						if (node.Flag == Flags.Unknown || node.Flag == Flags.Known)
						{
							class441.gridExplorer.GetNodesByFlag(node.Flag).Remove(node);
							node.Flag = Flags.Seen;
							class441.gridExplorer.GetNavigablePositionForNode(cachedTerrainData, class441.myPosition, node, verifyWalkability: false);
							class441.gridExplorer.GetNodesByFlag(node.Flag).Add(node);
						}
					}
					else if (node.Flag == Flags.Unknown)
					{
						class441.gridExplorer.GetNodesByFlag(node.Flag).Remove(node);
						node.Flag = Flags.Known;
						class441.gridExplorer.GetNavigablePositionForNode(cachedTerrainData, class441.myPosition, node, verifyWalkability: true);
						class441.gridExplorer.GetNodesByFlag(node.Flag).Add(node);
					}
				}
			}
		}
	}

	private sealed class Class444
	{
		public GridExplorer gridExplorer_0;

		public CachedTerrainData cachedTerrainData_0;

		public Vector2i vector2i_0;

		internal void SegmentingArea()
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			ilog_0.DebugFormat("[GridExplorer] Now segmenting the current area.", Array.Empty<object>());
			for (int i = 0; i < gridExplorer_0.Cols; i++)
			{
				for (int j = 0; j < gridExplorer_0.Rows; j++)
				{
					Node node = new Node(i, j);
					gridExplorer_0.node_0[i, j] = node;
					gridExplorer_0.GetNavigablePositionForNode(cachedTerrainData_0, vector2i_0, node, verifyWalkability: false);
					gridExplorer_0.GetNodesByFlag(node.Flag).Add(node);
				}
			}
			gridExplorer_0.IncursionData = new IncursionDataClass();
			gridExplorer_0.SacredGroveData = new SacredGroveDataClass();
			gridExplorer_0.SyntesisData = new SynthesisDataClass();
			gridExplorer_0.SanctumData = new SanctumDataClass();
			if (!LokiPoe.CurrentWorldArea.IsTown && !LokiPoe.CurrentWorldArea.IsHideoutArea)
			{
				ExamineSpecialAreas();
				if (LokiPoe.ObjectManager.Me.League.Contains("Synthesis"))
				{
					ilog_0.DebugFormat("[GridExplorer] Processing Synthesis data.", Array.Empty<object>());
					SynthesisDataClass syntesisData = gridExplorer_0.SyntesisData;
					Node[,] node_ = gridExplorer_0.node_0;
					foreach (Node node2 in node_)
					{
						if (syntesisData.IsInSynthesis(node2.Center.X, node2.Center.Y))
						{
							gridExplorer_0.ForceNodeFlags(node2.Location, Flags.Ignored);
						}
					}
				}
				ilog_0.DebugFormat("[GridExplorer] Processing Harvest data.", Array.Empty<object>());
				SacredGroveDataClass sacredGroveData = gridExplorer_0.SacredGroveData;
				if (sacredGroveData.HasSacredGrove)
				{
					ilog_0.DebugFormat("[GridExplorer] Harvest Detected!.", Array.Empty<object>());
					if (!sacredGroveData.IsInSacredGrove())
					{
						DisableSacredGrove();
					}
					else
					{
						EnableSacredGrove();
					}
				}
				ilog_0.DebugFormat("[GridExplorer] Processing Incursion data.", Array.Empty<object>());
				IncursionDataClass incursionData = gridExplorer_0.IncursionData;
				if (incursionData.HasIncursion)
				{
					ilog_0.DebugFormat("[GridExplorer] Incursion Detected!.", Array.Empty<object>());
					if (incursionData.IsMeInIncursion())
					{
						EnableIncursion();
					}
					else
					{
						DisableIncursion();
					}
				}
				else
				{
					ilog_0.DebugFormat("[GridExplorer] Incursion NOT Detected!.", Array.Empty<object>());
				}
			}
			ilog_0.DebugFormat("[GridExplorer] Area segmentation complete {0}.", (object)stopwatch.Elapsed);
		}

		public void DisableSacredGrove()
		{
			ilog_0.DebugFormat("[GridExplorer-DisableSacredGrove] Disable Sacred Grove data.", Array.Empty<object>());
			SacredGroveDataClass sacredGroveData = gridExplorer_0.SacredGroveData;
			int num = 0;
			Node[,] node_ = gridExplorer_0.node_0;
			foreach (Node node in node_)
			{
				if (node.Flag != Flags.Seen && node.Flag != Flags.Ignored && node.Flag != Flags.Disconnected && sacredGroveData.IsInSacredGrove(node.Center.X, node.Center.Y))
				{
					num++;
					gridExplorer_0.ForceNodeFlags(node.Location, Flags.Seen);
				}
			}
			ilog_0.DebugFormat($"[GridExplorer-DisableSacredGrove] Marked {num} nodes as Ignored.", Array.Empty<object>());
		}

		public void EnableSacredGrove()
		{
			ilog_0.DebugFormat("[GridExplorer-EnableSacredGrove] Eneble Sacred Grove data.", Array.Empty<object>());
			SacredGroveDataClass sacredGroveData = gridExplorer_0.SacredGroveData;
			int num = 0;
			Node[,] node_ = gridExplorer_0.node_0;
			foreach (Node node in node_)
			{
				if (node.Flag != Flags.Seen && node.Flag != Flags.Ignored && node.Flag != Flags.Disconnected && sacredGroveData.IsInSacredGrove(node.Center.X, node.Center.Y))
				{
					num++;
					gridExplorer_0.ForceNodeFlags(node.Location, Flags.Unknown);
				}
			}
			ilog_0.DebugFormat($"[GridExplorer-EnableSacredGrove] Marked {num} nodes as Unknown.", Array.Empty<object>());
		}

		public void DisableIncursion()
		{
			ilog_0.DebugFormat("[GridExplorer-DisableIncursion] Disable Incursion data.", Array.Empty<object>());
			IncursionDataClass incursionData = gridExplorer_0.IncursionData;
			int num = 0;
			Node[,] node_ = gridExplorer_0.node_0;
			foreach (Node node in node_)
			{
				if (node.Flag != Flags.Seen && node.Flag != Flags.Ignored && node.Flag != Flags.Disconnected && incursionData.IsPositionInIncursions(node.Center.X, node.Center.Y))
				{
					num++;
					gridExplorer_0.ForceNodeFlags(node.Location, Flags.Seen);
				}
			}
			ilog_0.DebugFormat($"[GridExplorer-DisableIncursion] Marked {num} nodes as Ignored.", Array.Empty<object>());
		}

		public void EnableIncursion()
		{
			ilog_0.DebugFormat("[GridExplorer-EnableIncursion] Eneble Incursion data.", Array.Empty<object>());
			IncursionDataClass incursionData = gridExplorer_0.IncursionData;
			int num = 0;
			Node[,] node_ = gridExplorer_0.node_0;
			foreach (Node node in node_)
			{
				if (node.Flag != Flags.Seen && node.Flag != Flags.Ignored && node.Flag != Flags.Disconnected && incursionData.IsPositionInIncursions(node.Center.X, node.Center.Y))
				{
					num++;
					gridExplorer_0.ForceNodeFlags(node.Location, Flags.Unknown);
				}
			}
			ilog_0.DebugFormat($"[GridExplorer-EnableIncursion] Marked {num} nodes as Unknown.", Array.Empty<object>());
		}

		private void ExamineSpecialAreas()
		{
			Vector2i vector2i = FindMainMapIndices();
			Rect rect = new Rect(0.0, 0.0, vector2i.X, vector2i.Y);
			LokiPoe.TerrainDataEntry[,] array = LokiPoe.TerrainData.smethod_2TerrainDataEntryArray();
			bool flag = LokiPoe.ObjectManager.Me.League.Contains("Synthesis");
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					if (rect.Contains(i, j))
					{
						continue;
					}
					LokiPoe.TerrainDataEntry terrainDataEntry = array[i, j];
					if (terrainDataEntry == null)
					{
						continue;
					}
					Vector2i vector2i2 = new Vector2i(i * 23, j * 23);
					if (flag && terrainDataEntry.TgtName.Contains("Synthesis"))
					{
						int x = vector2i2.X;
						int y = vector2i2.Y;
						if (gridExplorer_0.SyntesisData.LowestSynthX == -1)
						{
							gridExplorer_0.SyntesisData.LowestSynthX = x;
							gridExplorer_0.SyntesisData.LowestSynthY = y;
							gridExplorer_0.SyntesisData.HighestSynthX = x;
							gridExplorer_0.SyntesisData.HighestSynthY = y;
						}
						if (x < gridExplorer_0.SyntesisData.LowestSynthX)
						{
							gridExplorer_0.SyntesisData.LowestSynthX = x;
						}
						if (y < gridExplorer_0.SyntesisData.LowestSynthY)
						{
							gridExplorer_0.SyntesisData.LowestSynthY = y;
						}
						if (x > gridExplorer_0.SyntesisData.HighestSynthX)
						{
							gridExplorer_0.SyntesisData.HighestSynthX = x;
						}
						if (y > gridExplorer_0.SyntesisData.HighestSynthY)
						{
							gridExplorer_0.SyntesisData.HighestSynthY = y;
						}
					}
					if (terrainDataEntry.TgtName.Contains("Grove/harvest"))
					{
						int x2 = vector2i2.X;
						int y2 = vector2i2.Y;
						if (!gridExplorer_0.SacredGroveData.HasSacredGrove)
						{
							gridExplorer_0.SacredGroveData.HasSacredGrove = true;
						}
						if (gridExplorer_0.SacredGroveData.LowestSynthX == -1)
						{
							gridExplorer_0.SacredGroveData.LowestSynthX = x2;
							gridExplorer_0.SacredGroveData.LowestSynthY = y2;
							gridExplorer_0.SacredGroveData.HighestSynthX = x2;
							gridExplorer_0.SacredGroveData.HighestSynthY = y2;
						}
						if (x2 < gridExplorer_0.SacredGroveData.LowestSynthX)
						{
							gridExplorer_0.SacredGroveData.LowestSynthX = x2;
						}
						if (y2 < gridExplorer_0.SacredGroveData.LowestSynthY)
						{
							gridExplorer_0.SacredGroveData.LowestSynthY = y2;
						}
						if (x2 > gridExplorer_0.SacredGroveData.HighestSynthX)
						{
							gridExplorer_0.SacredGroveData.HighestSynthX = x2;
						}
						if (y2 > gridExplorer_0.SacredGroveData.HighestSynthY)
						{
							gridExplorer_0.SacredGroveData.HighestSynthY = y2;
						}
					}
					if (terrainDataEntry.TgtName != "Art/Models/Terrain/IncaDungeon/dungeon_blackness_v01_01.tgt" && terrainDataEntry.TgtName.Contains("IncaDungeon"))
					{
						if (!gridExplorer_0.IncursionData.HasIncursion)
						{
							gridExplorer_0.IncursionData.HasIncursion = true;
						}
						int x3 = vector2i2.X;
						int y3 = vector2i2.Y;
						if (gridExplorer_0.IncursionData.LowestSynthX == -1)
						{
							gridExplorer_0.IncursionData.LowestSynthX = x3;
							gridExplorer_0.IncursionData.LowestSynthY = y3;
							gridExplorer_0.IncursionData.HighestSynthX = x3;
							gridExplorer_0.IncursionData.HighestSynthY = y3;
						}
						if (x3 < gridExplorer_0.IncursionData.LowestSynthX)
						{
							gridExplorer_0.IncursionData.LowestSynthX = x3;
						}
						if (y3 < gridExplorer_0.IncursionData.LowestSynthY)
						{
							gridExplorer_0.IncursionData.LowestSynthY = y3;
						}
						if (x3 > gridExplorer_0.IncursionData.HighestSynthX)
						{
							gridExplorer_0.IncursionData.HighestSynthX = x3;
						}
						if (y3 > gridExplorer_0.IncursionData.HighestSynthY)
						{
							gridExplorer_0.IncursionData.HighestSynthY = y3;
						}
					}
				}
			}
		}

		private Vector2i FindMainMapIndices()
		{
			LokiPoe.TerrainDataEntry[,] array = LokiPoe.TerrainData.smethod_2TerrainDataEntryArray();
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				LokiPoe.TerrainDataEntry terrainDataEntry = array[i, 0];
				if (terrainDataEntry == null)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				num = array.GetLength(0);
			}
			for (int j = 0; j < array.GetLength(1); j++)
			{
				LokiPoe.TerrainDataEntry terrainDataEntry2 = array[0, j];
				if (terrainDataEntry2 == null)
				{
					num2 = j;
					break;
				}
			}
			if (num2 == -1)
			{
				num2 = array.GetLength(1);
			}
			return new Vector2i(num, num2);
		}
	}

	public class SynthesisDataClass
	{
		public int LowestSynthX = -1;

		public int LowestSynthY = -1;

		public int HighestSynthX = -1;

		public int HighestSynthY = -1;

		public bool IsInSynthesis()
		{
			int x = LokiPoe.LocalData.MyPosition.X;
			int y = LokiPoe.LocalData.MyPosition.Y;
			return IsInSynthesis(x, y);
		}

		public bool IsInSynthesis(int x, int y)
		{
			if (x > LowestSynthX && x < HighestSynthX && y > LowestSynthY)
			{
				return y < HighestSynthY;
			}
			return false;
		}
	}

	public class IncursionDataClass
	{
		public int LowestSynthX = -1;

		public int LowestSynthY = -1;

		public int HighestSynthX = -1;

		public int HighestSynthY = -1;

		public bool HasIncursion;

		public bool IsMeInIncursion()
		{
			if (!HasIncursion)
			{
				return false;
			}
			int x = LokiPoe.LocalData.MyPosition.X;
			int y = LokiPoe.LocalData.MyPosition.Y;
			return IsPositionInIncursions(x, y);
		}

		public bool IsPositionInIncursions(int x, int y)
		{
			if (!HasIncursion)
			{
				return false;
			}
			if (x > LowestSynthX && x < HighestSynthX && y > LowestSynthY)
			{
				return y < HighestSynthY;
			}
			return false;
		}
	}

	public class SyndacateDataClass
	{
		public int LowestSynthX = -1;

		public int LowestSynthY = -1;

		public int HighestSynthX = -1;

		public int HighestSynthY = -1;

		public bool HasSyndacate;

		public bool IsMeInSyndacate()
		{
			if (!HasSyndacate)
			{
				return false;
			}
			int x = LokiPoe.LocalData.MyPosition.X;
			int y = LokiPoe.LocalData.MyPosition.Y;
			return IsPositionInSyndacate(x, y);
		}

		public bool IsPositionInSyndacate(int x, int y)
		{
			if (!HasSyndacate)
			{
				return false;
			}
			if (x > LowestSynthX && x < HighestSynthX && y > LowestSynthY)
			{
				return y < HighestSynthY;
			}
			return false;
		}

		public SyndacateDataClass()
		{
			LowestSynthX = -1;
			LowestSynthY = -1;
			HighestSynthX = -1;
			HighestSynthY = -1;
			HasSyndacate = false;
		}
	}

	public class SacredGroveDataClass
	{
		public int LowestSynthX = -1;

		public int LowestSynthY = -1;

		public int HighestSynthX = -1;

		public int HighestSynthY = -1;

		public bool HasSacredGrove;

		public bool IsInSacredGrove()
		{
			int x = LokiPoe.LocalData.MyPosition.X;
			int y = LokiPoe.LocalData.MyPosition.Y;
			return IsInSacredGrove(x, y);
		}

		public bool IsInSacredGrove(int x, int y)
		{
			if (x > LowestSynthX && x < HighestSynthX && y > LowestSynthY)
			{
				return y < HighestSynthY;
			}
			return false;
		}
	}

	public class SanctumDataClass
	{
		public int LowestSynthX = -1;

		public int LowestSynthY = -1;

		public int HighestSynthX = -1;

		public int HighestSynthY = -1;

		public bool IsInSanctum()
		{
			int x = LokiPoe.LocalData.MyPosition.X;
			int y = LokiPoe.LocalData.MyPosition.Y;
			return IsInSanctum(x, y);
		}

		public bool IsInSanctum(int x, int y)
		{
			if (x > LowestSynthX && x < HighestSynthX && y > LowestSynthY)
			{
				return y < HighestSynthY;
			}
			return false;
		}
	}

	public IncursionDataClass IncursionData;

	public SynthesisDataClass SyntesisData;

	public SacredGroveDataClass SacredGroveData;

	public SanctumDataClass SanctumData;

	public ExplorationMethodEnum ExplorationMethod;

	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	private int int_0;

	private int int_1;

	private bool bool_0;

	private int int_4 = -1;

	private int int_5 = -1;

	private Node[,] node_0;

	private readonly Dictionary<Flags, List<Node>> dictionary_0 = new Dictionary<Flags, List<Node>>();

	internal const int int_6 = 23;

	private bool NeedToProcess = true;

	public bool AutoResetOnAreaChange
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			ilog_0.InfoFormat("[GridExplorer] AutoResetOnAreaChange is being set to {0}.", (object)bool_0);
		}
	}

	public int TileKnownRadius
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
			if (int_1 < 1)
			{
				int_1 = 1;
			}
			ilog_0.InfoFormat("[GridExplorer] TileKnownRadius is being set to {0}.", (object)int_1);
		}
	}

	public int TileSeenRadius
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
			if (int_0 < 1)
			{
				int_0 = 1;
			}
			ilog_0.InfoFormat("[GridExplorer] TileSeenRadius is being set to {0}.", (object)int_0);
		}
	}

	public DatWorldAreaWrapper Area { get; private set; }

	public uint Hash { get; private set; }

	public int Cols { get; private set; }

	public int Rows { get; private set; }

	public bool HasLocation => Location != Vector2i.Zero;

	public Vector2i Location { get; private set; } = Vector2i.Zero;


	public Node LocationNode
	{
		get
		{
			if (Location == Vector2i.Zero)
			{
				return null;
			}
			return GetNodeForLocation(Location);
		}
	}

	public float PercentComplete { get; private set; }

	public GridExplorer()
	{
		AutoResetOnAreaChange = true;
		TileKnownRadius = 7;
		TileSeenRadius = 5;
	}

	public void Start()
	{
	}

	public void Stop()
	{
	}

	public void Tick()
	{
		Class441 @class = new Class441();
		@class.gridExplorer = this;
		if (!LokiPoe.IsInGame)
		{
			Unload();
			return;
		}
		ProcessArea();
		@class.myPosition = LokiPoe.LocalData.MyPosition;
		@class.myNodeX = @class.myPosition.X / 23;
		@class.myNodeY = @class.myPosition.Y / 23;
		if (int_4 == @class.myNodeX && int_5 == @class.myNodeY && Location != Vector2i.Zero)
		{
			return;
		}
		if (int_4 != @class.myNodeX || int_5 != @class.myNodeY)
		{
			Class442 class2 = new Class442();
			class2.class441 = @class;
			int_4 = class2.class441.myNodeX;
			int_5 = class2.class441.myNodeY;
			class2.cachedTerrainData = LokiPoe.TerrainData.Cache;
			class2.UpdateNodesFlag();
		}
		float num = GetNodesByFlag(Flags.Unknown).Count;
		float num2 = GetNodesByFlag(Flags.Known).Count;
		float num3 = GetNodesByFlag(Flags.Seen).Count;
		PercentComplete = 100f * num3 / (num2 + num3 + num);
		if (Location != Vector2i.Zero)
		{
			Node locationNode = LocationNode;
			if (locationNode == null || locationNode.Flag != Flags.Known)
			{
				Location = Vector2i.Zero;
			}
		}
		if (!(Location == Vector2i.Zero))
		{
			return;
		}
		List<Node> nodesByFlag = GetNodesByFlag(Flags.Known);
		if (nodesByFlag.Count != 0)
		{
			Location = nodesByFlag.OrderBy((Node x) => x.NavigableLocation.Distance(LokiPoe.LocalData.MyPosition)).ThenBy(method_0).First()
				.NavigableLocation;
		}
	}

	private float method_0(Node node_1)
	{
		float num = 0f;
		float num2 = 0f;
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				int num3 = node_1.Index.X + i;
				int num4 = node_1.Index.Y + j;
				if (num3 < 0 || num3 >= Cols || num4 < 0 || num4 >= Rows)
				{
					continue;
				}
				Flags flag = node_0[num3, num4].Flag;
				if (ExplorationMethod == ExplorationMethodEnum.Breadth_First)
				{
					if (flag != 0)
					{
						num += 1f;
					}
					if (flag == Flags.Seen)
					{
						num2 += 1f;
					}
				}
				else if (ExplorationMethod == ExplorationMethodEnum.Depth_First)
				{
					if (flag != Flags.Known)
					{
						num += 1f;
					}
					if (flag == Flags.Seen)
					{
						num2 += 1f;
					}
				}
			}
		}
		return 1f - num2 / num;
	}

	public Node GetNodeForLocation(Vector2i location)
	{
		try
		{
			return node_0[location.X / 23, location.Y / 23];
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("[GetNodeForLocation] Failed to get node for location {0}: {1}", (object)location, (object)ex);
		}
		return null;
	}

	public void ForceNodeFlags(Vector2i location, Flags flags)
	{
		try
		{
			Node nodeForLocation = GetNodeForLocation(location);
			if (nodeForLocation != null)
			{
				GetNodesByFlag(nodeForLocation.Flag).Remove(nodeForLocation);
				nodeForLocation.Flag = flags;
				GetNodesByFlag(nodeForLocation.Flag).Add(nodeForLocation);
				Node locationNode = LocationNode;
				if (locationNode != null && nodeForLocation.Index == locationNode.Index)
				{
					Location = Vector2i.Zero;
					ilog_0.DebugFormat("[ForceNodeFlags] Now clearing the current location since its flags are being changed.", Array.Empty<object>());
				}
			}
		}
		catch (Exception ex)
		{
			ilog_0.ErrorFormat("[ForceNodeFlags] Failed to set flags {0} for location {1}: {2}", (object)flags, (object)location, (object)ex);
		}
	}

	public void Ignore(Vector2i location)
	{
		ForceNodeFlags(location, Flags.Ignored);
	}

	public List<Node> GetNodesByFlag(Flags flag)
	{
		return dictionary_0[flag];
	}

	public void Reset()
	{
		NeedToProcess = true;
		ProcessArea();
	}

	private void ProcessArea()
	{
		Class444 @class = new Class444();
		@class.gridExplorer_0 = this;
		if (!LokiPoe.IsInGame)
		{
			Unload();
			return;
		}
		if (!NeedToProcess)
		{
			if (LokiPoe.LocalData.AreaHash == Hash || !AutoResetOnAreaChange)
			{
				return;
			}
			NeedToProcess = true;
		}
		Area = LokiPoe.CurrentWorldArea;
		Hash = LokiPoe.LocalData.AreaHash;
		Cols = LokiPoe.TerrainData.Cols;
		Rows = LokiPoe.TerrainData.Rows;
		PercentComplete = 0f;
		Location = Vector2i.Zero;
		int_4 = -1;
		int_5 = -1;
		dictionary_0.Clear();
		dictionary_0.Add(Flags.Unknown, new List<Node>());
		dictionary_0.Add(Flags.Known, new List<Node>());
		dictionary_0.Add(Flags.Seen, new List<Node>());
		dictionary_0.Add(Flags.Ignored, new List<Node>());
		dictionary_0.Add(Flags.Disconnected, new List<Node>());
		node_0 = new Node[Cols, Rows];
		@class.vector2i_0 = LokiPoe.LocalData.MyPosition;
		@class.cachedTerrainData_0 = LokiPoe.TerrainData.Cache;
		@class.SegmentingArea();
		NeedToProcess = false;
	}

	private void GetNavigablePositionForNode(CachedTerrainData cachedTerrainData_0, Vector2i position, Node node, bool verifyWalkability)
	{
		FindNavigablePositionInNode(cachedTerrainData_0, position, node, node.NavigableLocation, verifyWalkability);
	}

	private void FindNavigablePositionInNode(CachedTerrainData cachedTerrainData, Vector2i position, Node node, Vector2i navigableLocation, bool verifyWalkability)
	{
		if (navigableLocation == default(Vector2i))
		{
			navigableLocation = node.Center;
		}
		bool flag = false;
		if (!WalkabilityGrid.IsWalkable(cachedTerrainData.Data, cachedTerrainData.BPR, navigableLocation, cachedTerrainData.Value))
		{
			List<Vector2i> list = new List<Vector2i>();
			for (int i = node.Location.X; i < node.Location.X + 23; i++)
			{
				for (int j = node.Location.Y; j < node.Location.Y + 23; j++)
				{
					list.Add(new Vector2i(i, j));
				}
			}
			Vector2i vector2i = (from x in list
				where WalkabilityGrid.IsWalkable(cachedTerrainData.Data, cachedTerrainData.BPR, x, cachedTerrainData.Value)
				orderby x.DistanceSqr(navigableLocation)
				select x).FirstOrDefault();
			if (vector2i != default(Vector2i))
			{
				node.NavigableLocation = vector2i;
			}
			else
			{
				flag = true;
			}
		}
		else
		{
			node.NavigableLocation = navigableLocation;
		}
		if (verifyWalkability && !flag)
		{
			PathfindingCommand command = new PathfindingCommand(position, node.NavigableLocation, 15f, avoidWallHugging: false);
			if (!ExilePather.FindPath(ref command, dontLeaveFrame: true))
			{
				flag = true;
			}
		}
		if (flag)
		{
			node.Flag = Flags.Disconnected;
		}
	}

	public void Unload()
	{
		NeedToProcess = true;
		PercentComplete = 0f;
		Location = Vector2i.Zero;
		int_4 = -1;
		int_5 = -1;
		dictionary_0.Clear();
		node_0 = null;
		Area = null;
		Hash = 0u;
		Cols = 0;
		Rows = 0;
	}
}
