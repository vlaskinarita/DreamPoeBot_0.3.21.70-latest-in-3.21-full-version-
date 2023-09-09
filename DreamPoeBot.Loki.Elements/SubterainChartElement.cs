using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.BotFramework;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Elements;

public class SubterainChartElement : Element
{
	public class DelveBigCell : Element
	{
		public List<DelveNode> Cels
		{
			get
			{
				List<DelveNode> list = new List<DelveNode>();
				foreach (Element item in base.Children.Where((Element x) => x.ChildCount > 0L))
				{
					if (item.Address != base.Children.Last().Address)
					{
						list.Add(base.M.GetObject<DelveNode>(item.Address));
					}
				}
				return list;
			}
		}
	}

	public class DelveNode : Element
	{
		private PerFrameCachedValue<DelveCellStruct> _pFvDelveCellStruct;

		private PerFrameCachedValue<DelveFeatureStruct> _pFvDelveFeatureStruct;

		private PerFrameCachedValue<DevlveBiomesStruct> _pFvDevlveBiomesStruct;

		private PerFrameCachedValue<NodeInfoStructure> _pFvNodeInfoStructure;

		private DelveLevelScalingWrapper _delveLevelScalingWrapper;

		private DelveLevelScalingWrapper DelveLevelScaling
		{
			get
			{
				if (_delveLevelScalingWrapper == null)
				{
					_delveLevelScalingWrapper = Dat.DelveLevelScaling.FirstOrDefault((DelveLevelScalingWrapper x) => x.Index == Row);
				}
				return _delveLevelScalingWrapper;
			}
		}

		private DelveCellStruct PfvDelveCellStruct
		{
			get
			{
				if (_pFvDelveCellStruct == null)
				{
					_pFvDelveCellStruct = new PerFrameCachedValue<DelveCellStruct>(() => base.M.FastIntPtrToStruct<DelveCellStruct>(base.Address + 1592L));
				}
				return _pFvDelveCellStruct;
			}
		}

		private DelveFeatureStruct PfvDelveFeatureStruct
		{
			get
			{
				if (_pFvDelveFeatureStruct == null)
				{
					_pFvDelveFeatureStruct = new PerFrameCachedValue<DelveFeatureStruct>(() => base.M.FastIntPtrToStruct<DelveFeatureStruct>(PfvDelveCellStruct.intptr_DelveFeature));
				}
				return _pFvDelveFeatureStruct;
			}
		}

		private DevlveBiomesStruct PfvDevlveBiomesStruct
		{
			get
			{
				if (_pFvDevlveBiomesStruct == null)
				{
					_pFvDevlveBiomesStruct = new PerFrameCachedValue<DevlveBiomesStruct>(() => base.M.FastIntPtrToStruct<DevlveBiomesStruct>(PfvDelveCellStruct.intptr_DelveBiomes));
				}
				return _pFvDevlveBiomesStruct;
			}
		}

		private NodeInfoStructure PfvNodeInfoStructure
		{
			get
			{
				if (_pFvNodeInfoStructure == null)
				{
					_pFvNodeInfoStructure = new PerFrameCachedValue<NodeInfoStructure>(() => base.M.FastIntPtrToStruct<NodeInfoStructure>(base.Address + 1144L));
				}
				return _pFvNodeInfoStructure;
			}
		}

		private float iconX => PfvDelveCellStruct.iconPositionX;

		private float iconY => PfvDelveCellStruct.iconPositionY;

		public int Row
		{
			get
			{
				int num = ((base.Parent.Y != 0f) ? ((int)(base.Parent.Y / 1152f)) : 0);
				return PfvNodeInfoStructure.chartRow + num * 8;
			}
		}

		public int Column
		{
			get
			{
				int num = ((base.Parent.X != 0f) ? ((int)(base.Parent.X / 1152f)) : 0);
				return PfvNodeInfoStructure.chartColumn + num * 8;
			}
		}

		public string Name => base.M.ReadStringU(PfvDelveFeatureStruct.intptr_Name);

		public string ZoneName => base.M.ReadStringU(PfvDevlveBiomesStruct.intptr_Name);

		public string LootDescription => base.M.ReadStringU(PfvDelveFeatureStruct.intptr_LootDescription);

		public int Depth => DelveLevelScaling.Depth;

		public int MonsterLevel => DelveLevelScaling.MonsterLevel;

		public int SulphiteCost => DelveLevelScaling.SulphiteCost;

		public int DarknessResistanceModificator => DelveLevelScaling.DarknessResistance;

		public int LightRadiusModificator => DelveLevelScaling.LightRadius;

		public int MonsterLifeModificator => DelveLevelScaling.MoreMonsterLife;

		public int MonsterDamageModificator => DelveLevelScaling.MoreMonsterDamage;

		public bool Visited => PfvNodeInfoStructure.byte_Visited == 1;

		public bool YouAreHere => PfvNodeInfoStructure.byte_YouAreHere == 1;

		public bool IsMineShaft => PfvNodeInfoStructure.byte_IsMineShaft == 1;

		public bool IsNodeVisible => PfvNodeInfoStructure.byte_IsNotCoveredByFog == 1;

		public bool NodeContainIcon => PfvNodeInfoStructure.byte_NodeContainIcon == 1;

		public bool IsPathHidden => PfvNodeInfoStructure.byte_IsPathHidden == 1;

		public string ArtTexture => base.M.ReadStringU(base.M.ReadLong(PfvDelveCellStruct.intptr_0ArtTexture));

		public bool IsMouseOverCell => PfvDelveCellStruct.byte8IsMouseOverCell == 1;

		public bool IsMouseOverIcon => PfvDelveCellStruct.byte7IsMouseOverIcon == 1;

		public string IconImmage => base.M.ReadStringU(PfvDelveFeatureStruct.intptr_Immage);

		public List<DelveNode> Connections
		{
			get
			{
				List<DelveNode> list = new List<DelveNode>();
				if (PfvNodeInfoStructure.connection1.unknownAddressThatIndicateConnection != 0L)
				{
					DelveNode @object = base.M.GetObject<DelveNode>(PfvNodeInfoStructure.connection1.nodeAddress);
					list.Add(@object);
				}
				if (PfvNodeInfoStructure.connection2.unknownAddressThatIndicateConnection != 0L)
				{
					DelveNode object2 = base.M.GetObject<DelveNode>(PfvNodeInfoStructure.connection2.nodeAddress);
					list.Add(object2);
				}
				if (PfvNodeInfoStructure.connection3.unknownAddressThatIndicateConnection != 0L)
				{
					DelveNode object3 = base.M.GetObject<DelveNode>(PfvNodeInfoStructure.connection3.nodeAddress);
					list.Add(object3);
				}
				if (PfvNodeInfoStructure.connection4.unknownAddressThatIndicateConnection != 0L)
				{
					DelveNode object4 = base.M.GetObject<DelveNode>(PfvNodeInfoStructure.connection4.nodeAddress);
					list.Add(object4);
				}
				return list;
			}
		}

		public bool SelectIcon()
		{
			float num = base.X * base.Scale;
			float num2 = base.Y * base.Scale;
			Element parent = base.Parent;
			while (parent.Address != 0L && parent.IdLabel != "root")
			{
				num += parent.X * parent.Scale;
				num2 += parent.Y * parent.Scale;
				parent = parent.Parent;
			}
			float num3 = num2;
			float num4 = num + base.Width * base.Scale;
			float num5 = num2 + base.Height * base.Scale;
			bool flag = false;
			for (; num3 < num5; num3 += 4f)
			{
				float num6;
				for (num6 = num; num6 < num4; num6 += 4f)
				{
					MouseManager.SetMousePosition(new Vector2(num6, num3), sleep: false);
					if (IsMouseOverIcon)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					MouseManager.SetMousePosition(new Vector2(num6 + 1f, num3 + 1f), sleep: false);
					break;
				}
			}
			return flag;
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct DelveCellStruct
	{
		private readonly long intptr_vTable;

		public readonly long intptr_0ArtTexture;

		private readonly long intptr_1;

		public readonly long intptr_DelveFeature;

		private readonly long intptr_DelveFeatureFile;

		public readonly long intptr_DelveBiomes;

		private readonly long intptr_DelveBiomesFile;

		private readonly int intrestingInt;

		public readonly float iconPositionX;

		public readonly float iconPositionY;

		private readonly float float3;

		private readonly float lastClickX;

		private readonly float lastClickY;

		private readonly long intPtr_3;

		private readonly long intPtr_4;

		private readonly byte byte0;

		private readonly byte byte1;

		private readonly byte byte2;

		private readonly byte byte3;

		private readonly byte byte4;

		private readonly byte byte5;

		private readonly byte byte6NotExploredMaybe;

		public readonly byte byte7IsMouseOverIcon;

		public readonly byte byte8IsMouseOverCell;

		private readonly byte byte9IsCellVisible;

		private readonly byte byte10;

		private readonly byte byte11;

		private readonly byte byte12;

		private readonly byte byte13;

		private readonly byte byte14;

		private readonly byte byte15;

		private readonly long intPtr_5;

		private readonly NativeVector vector0;

		public readonly NativeVector vector1ConnectionMaybe;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct DelveFeatureStruct
	{
		private readonly long intptr_Id;

		public readonly long intptr_Name;

		private readonly int int_SpawnWeight;

		private readonly int int_0;

		private readonly long intptr_WorldAreaKeys;

		private readonly long intptr_0;

		private readonly long intptr_1;

		public readonly long intptr_Immage;

		private readonly long intptr_2;

		private readonly long intptr_3;

		private readonly int int_1MinTierCount;

		private readonly int int_2;

		private readonly long intptr_MinTierAddress;

		private readonly int int_3MinDepthCount;

		private readonly int int_4;

		private readonly long intptr_MinDepthAddress;

		public readonly long intptr_LootDescription;

		private readonly int int_Unknown;

		private readonly int int_Data1Count;

		private readonly int int_7;

		private readonly long intptr_Data1Address;

		private readonly int int_Data2Count;

		private readonly int int_9;

		private readonly long intptr_Data2Address;

		private readonly int int_Data3Count;

		private readonly int int_11;

		private readonly long intptr_Data3Address;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct DevlveBiomesStruct
	{
		public readonly long intptr_Name;

		private readonly long intptr_WorldAreaKeys;

		private readonly int int_WorldAreaKeysCount;

		private readonly int int_0;

		private readonly long intptr_UiImage;

		private readonly long intptr_SpawnWeightDepth;

		private readonly int int_SpawnWeightDepthCount;

		private readonly int int_1;

		private readonly long intptr_SpawnWeightValue;

		private readonly int int_SpawnWeightValueCount;

		private readonly int int_2;

		private readonly long intptr_Unknown;

		private readonly int int_UnknownCount;

		private readonly int int_3;

		private readonly long intptr_Unknown1;

		private readonly int int_Unknown1Count;

		private readonly int int_4;

		private readonly long intptr_Art2D;

		private readonly long intptr_AchievementItemKey;

		private readonly int int_AchievementItemKeyCount;

		private readonly int int_5;

		private readonly byte UnknownFlag;

		private readonly int int_Unknown3Count;

		private readonly int int_6;

		private readonly long intptr_Unknown3;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct NodeInfoStructure
	{
		public readonly int chartColumn;

		public readonly int chartRow;

		private readonly byte byte_0;

		private readonly byte byte_1;

		private readonly byte byte_IsHiddenNode;

		public readonly byte byte_NodeContainIcon;

		public readonly byte byte_IsNotCoveredByFog;

		public readonly byte byte_YouAreHere;

		private readonly byte byte_IsSelected;

		public readonly byte byte_IsPathHidden;

		public readonly byte byte_Visited;

		private readonly byte byte_9;

		public readonly byte byte_IsMineShaft;

		private readonly byte byte_11;

		private readonly byte byte_12;

		private readonly byte byte_13;

		private readonly byte byte_14;

		private readonly byte byte_15;

		private readonly long unknown0;

		public readonly ConnectionStructure connection1;

		public readonly ConnectionStructure connection2;

		public readonly ConnectionStructure connection3;

		public readonly ConnectionStructure connection4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct ConnectionStructure
	{
		public readonly long nodeAddress;

		public readonly long unknownAddressThatIndicateConnection;

		public readonly int connectionIndex;

		public readonly int unknownInt;
	}

	internal Element SubterranGroundMap => base.Children[0]?.Children[0]?.Children[2];

	internal Element ChartFullMap => base.Children[0]?.Children[0];

	internal Element ChartWindow => base.Children[0];

	internal bool IsLoading
	{
		get
		{
			if (ChartLoadingElement.Children[0].IsVisible)
			{
				return true;
			}
			if (base.M.ReadByte(ChartFullMap.Address + 1820L) == 0)
			{
				return false;
			}
			return true;
		}
	}

	internal Element ChartLoadingElement => base.Children[6];

	internal Element LeftPannel => base.Children[3];

	internal Element RightPannel => base.Children[1];

	internal Element VisitMineEncampment
	{
		get
		{
			IEnumerable<Element> enumerable = LeftPannel.Children.Where((Element x) => x.IsVisible);
			foreach (Element item in enumerable)
			{
				Element element = LokiPoe.FindTextInElementChildrens(item, "Mine Encampment");
				if (element != null)
				{
					return element;
				}
			}
			return null;
		}
	}

	internal Element VisitTheMine
	{
		get
		{
			IEnumerable<Element> enumerable = LeftPannel.Children.Where((Element x) => x.IsVisible);
			foreach (Element item in enumerable)
			{
				Element element = LokiPoe.FindTextInElementChildrens(item, "The Mine");
				if (element != null)
				{
					return element;
				}
			}
			return null;
		}
	}

	public List<DelveBigCell> Map
	{
		get
		{
			List<DelveBigCell> list = new List<DelveBigCell>();
			foreach (Element child in SubterranGroundMap.Children)
			{
				list.Add(base.M.GetObject<DelveBigCell>(child.Address));
			}
			return list;
		}
	}
}
