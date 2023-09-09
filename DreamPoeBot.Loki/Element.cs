using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Elements;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using SharpDX;

namespace DreamPoeBot.Loki;

public class Element : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct StructElement
	{
		public long vTable;

		public int int0_ControlType;

		private int int1;

		private long long1;

		private long long2;

		private long long3;

		private long long4;

		public NativeVector Vector_child1;

		private long long5;

		private long long6;

		private long long51;

		private long long61;

		public NativeVector Vector_child2;

		private long long7;

		private long long8;

		private long long9;

		private long long10;

		private long long11;

		public float deltaX;

		public float deltaY;

		public NativeStringWCustom label;

		private long long13;

		private long long14;

		public long parent;

		public Vector2 position;

		private long long16;

		private long long17;

		public float elementZoom;

		private int int0;

		public long tooltip;

		private long long19;

		private long long20;

		private long long21;

		private long long22;

		private long long23;

		private long long24;

		private long long25;

		private long long26;

		private long long27;

		public float Scale;

		private int int2;

		private byte byte0;

		public byte isVisibleLocal;

		private byte byte2;

		private byte byte3;

		private byte byte4;

		public byte isEnable;

		private byte byte6;

		private byte byte7;

		private long long28;

		private long long29;

		private long long30;

		public Vector2 Size;
	}

	private static int _structureElementSize = -1;

	private PerFrameCachedValue<StructElement> perFrameCachedValue_StructElement;

	public const int OffsetBuffers = 0;

	private Element _parent;

	private GuiControlType _guiControlType;

	private readonly Dictionary<int, GuiControlType> _guiTypeDictionary = new Dictionary<int, GuiControlType>
	{
		{
			55040,
			GuiControlType.Label
		},
		{
			1656,
			GuiControlType.TextBox
		},
		{
			792,
			GuiControlType.Button
		},
		{
			16800,
			GuiControlType.ImageButton
		},
		{
			17568,
			GuiControlType.CheckBox
		},
		{
			37720,
			GuiControlType.ScrollBar
		},
		{
			15296,
			GuiControlType.ScrollableFrame
		},
		{
			21096,
			GuiControlType.ComboBox
		},
		{
			16872,
			GuiControlType.Frame
		},
		{
			2768,
			GuiControlType.StackLayout
		},
		{
			35400,
			GuiControlType.FlowLayout
		},
		{
			10712,
			GuiControlType.TabContainer
		},
		{
			47736,
			GuiControlType.PassiveTreeUi
		},
		{
			3256,
			GuiControlType.ExperienceBar
		},
		{
			688,
			GuiControlType.FlaskBar
		},
		{
			42376,
			GuiControlType.Orb
		},
		{
			10720,
			GuiControlType.Clock
		},
		{
			776,
			GuiControlType.PlayerShield
		},
		{
			9600,
			GuiControlType.Frame2
		},
		{
			51952,
			GuiControlType.InventoryPanel
		},
		{
			584,
			GuiControlType.BanditsPannel
		},
		{
			528,
			GuiControlType.TimersPannel
		},
		{
			26040,
			GuiControlType.CursorOverlay
		},
		{
			40264,
			GuiControlType.ContextMenu
		},
		{
			12960,
			GuiControlType.SkillsBar
		},
		{
			760,
			GuiControlType.HiddenSkillsBar
		},
		{
			608,
			GuiControlType.PartyHud
		},
		{
			1528,
			GuiControlType.ChatBox
		},
		{
			31264,
			GuiControlType.StashPannel
		},
		{
			29040,
			GuiControlType.GuildStashPannel
		},
		{
			58536,
			GuiControlType.ShopPannel
		},
		{
			64648,
			GuiControlType.SocialPannel
		},
		{
			26648,
			GuiControlType.AtlasPanel
		},
		{
			27816,
			GuiControlType.CharacterPannel
		},
		{
			59808,
			GuiControlType.OptionsPannel
		},
		{
			64016,
			GuiControlType.ChallengesPannel
		},
		{
			5240,
			GuiControlType.PantheonPannel
		},
		{
			15264,
			GuiControlType.WorldPannel
		},
		{
			17280,
			GuiControlType.HelpPannel
		},
		{
			36560,
			GuiControlType.BloodCruciblePannel
		},
		{
			49824,
			GuiControlType.MapPannel
		},
		{
			36816,
			GuiControlType.BlightTowers
		},
		{
			17976,
			GuiControlType.NpcDialog
		},
		{
			23024,
			GuiControlType.NewNpcDialog
		},
		{
			18816,
			GuiControlType.RewardPannel
		},
		{
			23184,
			GuiControlType.ParchasePanell
		},
		{
			39320,
			GuiControlType.ExpeditionDealerPanell
		},
		{
			30720,
			GuiControlType.SellPanell
		},
		{
			38592,
			GuiControlType.SellPanellNew
		},
		{
			49648,
			GuiControlType.TradePannel
		},
		{
			33512,
			GuiControlType.MapDevicePannel
		},
		{
			8880,
			GuiControlType.CadiroOffertPannel
		},
		{
			64928,
			GuiControlType.DivineFontPannel
		},
		{
			55048,
			GuiControlType.StoneAltarPannel
		},
		{
			10400,
			GuiControlType.TrialPlaquePannel
		},
		{
			9584,
			GuiControlType.AscendPannel
		},
		{
			35760,
			GuiControlType.MasterDevicePannel
		},
		{
			4344,
			GuiControlType.DarkshrinePannel
		},
		{
			8176,
			GuiControlType.BeastCraftingPannel
		},
		{
			51304,
			GuiControlType.LabyrinthPannel
		},
		{
			6456,
			GuiControlType.CardTradePannel
		},
		{
			58232,
			GuiControlType.IncursionPannel
		},
		{
			10136,
			GuiControlType.SubterrainChartPannel
		},
		{
			51464,
			GuiControlType.ZanaMissionPannel
		},
		{
			46544,
			GuiControlType.BetryalPannel
		},
		{
			2208,
			GuiControlType.HideoutSelectionPannel
		},
		{
			56008,
			GuiControlType.CraftingBenchPannel
		},
		{
			52168,
			GuiControlType.UnveilingPannel
		},
		{
			5856,
			GuiControlType.AnointingPannel
		},
		{
			31816,
			GuiControlType.MetamorphPannel
		},
		{
			37544,
			GuiControlType.LabMetamorphPannel
		},
		{
			44824,
			GuiControlType.LifeforceCaftingPannel
		},
		{
			43416,
			GuiControlType.HorticraftingPannel
		},
		{
			62432,
			GuiControlType.HeistContractPannel
		},
		{
			64560,
			GuiControlType.GrandHeistContractPannel
		},
		{
			58880,
			GuiControlType.HeistAllyEquipmentPannel
		},
		{
			65288,
			GuiControlType.HeistBluprintPannel
		},
		{
			52984,
			GuiControlType.HeisLockerPannel
		},
		{
			25856,
			GuiControlType.RitualFavorPannel
		},
		{
			9040,
			GuiControlType.UltimatumRewardPannel
		},
		{
			40992,
			GuiControlType.ExpeditionMapPannel
		},
		{
			39536,
			GuiControlType.ExpeditionPannel
		},
		{
			38064,
			GuiControlType.ExpeditionLockerPannel
		},
		{
			47480,
			GuiControlType.MinionsDisplaydPannel
		},
		{
			29368,
			GuiControlType.SigilsDisplayPannel
		},
		{
			26264,
			GuiControlType.BuffsorDeBuffDisplayPannel
		},
		{
			46144,
			GuiControlType.UarmonyGaugeDisplayPannel
		},
		{
			19688,
			GuiControlType.PremiumStashSettingPannel
		},
		{
			54144,
			GuiControlType.DisplayNotePannel
		},
		{
			17576,
			GuiControlType.SplitStackPannel
		},
		{
			2912,
			GuiControlType.InstanceManagerPannel
		},
		{
			312,
			GuiControlType.GlobalWarningDialogPannel
		},
		{
			32264,
			GuiControlType.HideoutControlPannel
		},
		{
			5048,
			GuiControlType.HideoutMusicPannel
		},
		{
			36120,
			GuiControlType.NotificationHudPannel
		},
		{
			664,
			GuiControlType.SkillGemHudPannel
		},
		{
			4128,
			GuiControlType.BlightPannel
		},
		{
			45328,
			GuiControlType.DeliriumRewardPannel
		},
		{
			60296,
			GuiControlType.HeistAlertLevelPannel
		},
		{
			62024,
			GuiControlType.ObjectsOnGroundPannel
		},
		{
			464,
			GuiControlType.ResurrectPannel
		}
	};

	private PerFrameCachedValue<List<Element>> perFrameCachedValue_Children;

	internal StructElement _structElement
	{
		get
		{
			if (perFrameCachedValue_StructElement == null)
			{
				perFrameCachedValue_StructElement = new PerFrameCachedValue<StructElement>(GetStructElement);
			}
			return perFrameCachedValue_StructElement.Value;
		}
	}

	public long vTable => _structElement.vTable;

	public long ChildCount => (_structElement.Vector_child1.Last - _structElement.Vector_child1.First) / 8L;

	public string IdLabel => Containers.StdStringWCustom(_structElement.label);

	public Element Parent => GetObject<Element>(_structElement.parent);

	public float X => _structElement.position.X;

	public float DeltaX => _structElement.deltaX;

	public long XAddress => base.Address + 232L;

	public float Y => _structElement.position.Y;

	public float DeltaY => _structElement.deltaY;

	public long YAddress => base.Address + 236L;

	public long zoomAddress => base.Address + 256L;

	public float ElementZoom => _structElement.elementZoom;

	public Element Tooltip
	{
		get
		{
			long addressPointer = base.M.ReadLong(base.Address + 264L);
			return ReadObject<Element>(addressPointer);
		}
	}

	public float Scale => _structElement.Scale;

	public bool IsVisibleLocal
	{
		get
		{
			if (base.Address != 0L)
			{
				return (_structElement.isVisibleLocal & 8) == 8;
			}
			return false;
		}
	}

	public bool IsEnable => _structElement.isEnable == byte.MaxValue;

	public bool IsItemTransparent => _structElement.isEnable != byte.MaxValue;

	public float Width => _structElement.Size.X;

	public float Height => _structElement.Size.Y;

	public GuiControlType GuiControlType
	{
		get
		{
			if (_guiControlType == GuiControlType.Unset)
			{
				int int0_ControlType = _structElement.int0_ControlType;
				_guiControlType = ((!_guiTypeDictionary.TryGetValue(int0_ControlType, out var value)) ? GuiControlType.Unknown : value);
			}
			return _guiControlType;
		}
	}

	public Element Root
	{
		get
		{
			Element parent = Parent;
			if (parent.Address <= 0L)
			{
				return this;
			}
			while (parent.Parent.Address > 0L)
			{
				parent = parent.Parent;
			}
			return parent;
		}
	}

	public string Text
	{
		get
		{
			string text = AsObject<EntityLabel>().Text;
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			return null;
		}
	}

	public bool IsVisible
	{
		get
		{
			if (IsVisibleLocal)
			{
				return GetParentChain().All((Element current) => current.IsVisibleLocal);
			}
			return false;
		}
	}

	public List<Element> Children
	{
		get
		{
			if (perFrameCachedValue_Children == null)
			{
				perFrameCachedValue_Children = new PerFrameCachedValue<List<Element>>(GetChildren<Element>);
			}
			return perFrameCachedValue_Children.Value;
		}
	}

	private StructElement GetStructElement()
	{
		if (_structureElementSize == -1)
		{
			_structureElementSize = MarshalCache<StructElement>.Size;
		}
		return base.M.FastIntPtrToStruct<StructElement>(base.Address, _structureElementSize);
	}

	public string Dump()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "Element"));
		stringBuilder.AppendLine($"Address: 0x{base.Address:X}");
		stringBuilder.AppendLine($"vTable: 0x{vTable:X}");
		stringBuilder.AppendLine($"IdLabel: {IdLabel}");
		stringBuilder.AppendLine($"Width,Height: {Width},{Height}");
		stringBuilder.AppendLine($"X,Y: {X},{Y}");
		stringBuilder.AppendLine($"ChildCount: {ChildCount}");
		stringBuilder.AppendLine($"IsEnable: {IsEnable}");
		stringBuilder.AppendLine($"IsVisible: {IsVisible}");
		stringBuilder.AppendLine(string.Format("IsVisibleLocal: {0} ({1})", IsVisibleLocal, base.M.ReadByte(base.Address + 273L).ToString("D")));
		stringBuilder.AppendLine($"Text: {Text}");
		stringBuilder.AppendLine($"Scale: {Scale}");
		stringBuilder.AppendLine($"ElementZoom: {ElementZoom}");
		stringBuilder.AppendLine($"Parent: 0x{Parent.Address:X}");
		stringBuilder.AppendLine($"GuiControlType: {GuiControlType}");
		stringBuilder.AppendLine(string.Format(""));
		stringBuilder.AppendLine($"ToolTip:");
		stringBuilder.AppendLine($"\tAddress: 0x{Tooltip.Address:X}");
		stringBuilder.AppendLine($"\tvTable: 0x{Tooltip.vTable:X}");
		stringBuilder.AppendLine($"\tIdLabel: {Tooltip.IdLabel}");
		stringBuilder.AppendLine($"\tWidth,Height: {Tooltip.Width},{Tooltip.Height}");
		stringBuilder.AppendLine($"\tX,Y: {Tooltip.X},{Tooltip.Y}");
		stringBuilder.AppendLine($"\tChildCount: {Tooltip.ChildCount}");
		stringBuilder.AppendLine($"\tIsEnable: {Tooltip.IsEnable}");
		stringBuilder.AppendLine($"\tIsVisible: {Tooltip.IsVisible}");
		stringBuilder.AppendLine($"\tIsVisibleLocal: {Tooltip.IsVisibleLocal}");
		stringBuilder.AppendLine($"\tText: {Tooltip.Text}");
		stringBuilder.AppendLine($"\tGuiControlType: {Tooltip.GuiControlType}");
		return stringBuilder.ToString();
	}

	protected List<T> GetChildren<T>() where T : Element, new()
	{
		List<T> list = new List<T>();
		if (_structElement.Vector_child2.Last != 0L && _structElement.Vector_child2.First != 0L && ChildCount <= 1000L)
		{
			for (int i = 0; i < ChildCount; i++)
			{
				list.Add(GetObject<T>(base.M.ReadLong(base.Address + 104L, i * 8)));
			}
			return list;
		}
		return list;
	}

	private IEnumerable<Element> GetParentChain()
	{
		HashSet<Element> hashSet = new HashSet<Element>();
		Element root = Root;
		Element parent = Parent;
		while (!hashSet.Contains(parent) && root.Address != parent.Address && parent.Address != 0L)
		{
			hashSet.Add(parent);
			parent = parent.Parent;
		}
		return hashSet;
	}

	public Vector2 GetParentPos()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		float num = 0f;
		float num2 = 0f;
		IEnumerable<Element> parentChain = GetParentChain();
		foreach (Element item in parentChain)
		{
			num += item.X;
			num2 += item.Y;
		}
		return new Vector2(num, num2);
	}

	public virtual RectangleF GetClientRect()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		Vector2 parentPos = GetParentPos();
		float num = base.Game.IngameState.Camera.Width;
		float num2 = base.Game.IngameState.Camera.Height;
		float num3 = num / num2 / 1.6f;
		float num4 = num / 2560f / num3;
		float num5 = num2 / 1600f;
		float num6 = (parentPos.X + X) * num4;
		float num7 = (parentPos.Y + Y) * num5;
		return new RectangleF(num6, num7, num4 * Width, num5 * Height);
	}

	public Element GetChildFromIndices(params int[] indices)
	{
		Element element = this;
		foreach (int index in indices)
		{
			element = element.GetChildAtIndex(index);
			if (element == null)
			{
				return null;
			}
		}
		return element;
	}

	public Element GetChildAtIndex(int index)
	{
		if (index < ChildCount)
		{
			return ReadObject<Element>(base.M.ReadLong(base.Address + 48L, index * 8));
		}
		return null;
	}

	public Vector2i CenterClickLocation()
	{
		float num = (X + Width / 2f) * Scale;
		float num2 = (Y + Height / 2f) * Scale;
		Element parent = Parent;
		while (parent.Address != 0L && parent.IdLabel != "root")
		{
			num += parent.X * parent.Scale;
			num2 += parent.Y * parent.Scale;
			parent = parent.Parent;
		}
		return new Vector2i((int)num, (int)num2);
	}

	public void WriteVisibleFlag(int flag)
	{
		base.M.WriteByte(base.Address + 353L, (byte)flag);
	}

	public void ToggleVisibility()
	{
		byte b = base.M.ReadByte(base.Address + 353L);
		byte data = b;
		switch (b)
		{
		case 19:
			data = 23;
			break;
		case 23:
			data = 19;
			break;
		case 46:
			data = 38;
			break;
		case 38:
			data = 46;
			break;
		case 102:
			data = 110;
			break;
		case 110:
			data = 102;
			break;
		case 51:
			data = 55;
			break;
		case 55:
			data = 51;
			break;
		}
		base.M.WriteByte(base.Address + 353L, data);
	}

	public void SetZoom(float zoom)
	{
		base.M.WriteFloat(base.Address + 256L, zoom);
	}
}
