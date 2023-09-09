using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki.Elements;

public class GatewayComboBoxElement : Element
{
	public enum GatewayEnum
	{
		Unknown = -1,
		Auto,
		Texas,
		Washington,
		California,
		Amsterdam,
		London,
		Frankfurt,
		Milan,
		Singapore,
		Australia,
		SanPaulo,
		Paris,
		Moscow,
		Japan,
		Canada,
		SouthAfrica
	}

	public class GatewayComboBoxEntry
	{
		private Element _baseElement;

		private readonly long _address;

		private readonly Memory M;

		private PerFrameCachedValue<StructGatewayComboBoxEntryComboBoxEntry> _perFrameStructComboBoxEntry;

		private StructGatewayComboBoxEntryComboBoxEntry _structComboBoxEntry
		{
			get
			{
				if (_perFrameStructComboBoxEntry == null)
				{
					_perFrameStructComboBoxEntry = new PerFrameCachedValue<StructGatewayComboBoxEntryComboBoxEntry>(GetStructure);
				}
				return _perFrameStructComboBoxEntry;
			}
		}

		public bool IsVisible => _structComboBoxEntry.IsVisible == 1;

		public string Name => Containers.StdStringWCustom(_structComboBoxEntry.Name);

		public string Ping => Containers.StdStringWCustom(_structComboBoxEntry.Ping);

		public float DeltaYMax => _structComboBoxEntry.deltaYMax;

		public float DeltaYMin => _structComboBoxEntry.deltaYMin;

		public float CellHeight => Math.Abs(DeltaYMax - DeltaYMin);

		public float CellWidth => _structComboBoxEntry.cellW;

		public Vector2i ClickPosition
		{
			get
			{
				Vector2i vector2i = _baseElement.CenterClickLocation();
				float num = (DeltaYMin - CellHeight - CellHeight / 2f) * _baseElement.Scale;
				return new Vector2i(vector2i.X, (int)((float)vector2i.Y + num));
			}
		}

		public GatewayComboBoxEntry(long address, Memory m, Element element)
		{
			_address = address;
			M = m;
			_baseElement = element;
		}

		private StructGatewayComboBoxEntryComboBoxEntry GetStructure()
		{
			return M.FastIntPtrToStruct<StructGatewayComboBoxEntryComboBoxEntry>(_address);
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct StructGatewayComboBoxEntryComboBoxEntry
	{
		public NativeStringWCustom Name;

		private readonly long intptr_4;

		public NativeStringWCustom Ping;

		private readonly long intptr_9;

		private readonly long intptr_10;

		private readonly long intptr_11;

		private readonly long intptr_12;

		private readonly long intptr_13;

		private readonly long intptr_14;

		private readonly long intptr_15;

		private readonly byte byte_0;

		public readonly byte IsVisible;

		private readonly byte byte_1;

		private readonly byte byte_2;

		private readonly float float_0;

		public readonly float deltaYMax;

		public readonly float cellW;

		public readonly float deltaYMin;

		private readonly int int_0;
	}

	private Element CurrentSelectedElement => ReadObject<Element>(base.Address + 824L);

	public List<GatewayComboBoxEntry> DropboxItems
	{
		get
		{
			List<GatewayComboBoxEntry> list = new List<GatewayComboBoxEntry>();
			long num = base.M.ReadLong(base.Address + 1312L);
			long num2 = base.M.ReadLong(base.Address + 1320L);
			for (int size = DreamPoeBot.Loki.Game.Std.MarshalCache<StructGatewayComboBoxEntryComboBoxEntry>.Size; num != num2; num += size)
			{
				list.Add(new GatewayComboBoxEntry(num, base.M, this));
			}
			return list;
		}
	}

	public Element ExpandButtonElement => ReadObject<Element>(base.Address + 816L);

	public Element scrollBar => ReadObject<Element>(base.Address + 968L);

	public bool isExpanded
	{
		get
		{
			if (base.M.ReadByte(base.Address + 364L) == 1)
			{
				return base.M.ReadByte(base.Address + 956L) == 1;
			}
			return false;
		}
	}

	public int selectedIndex => base.M.ReadInt(base.Address + 948L);

	public string CurrentSelectedGateway
	{
		get
		{
			if (CurrentSelectedElement == null)
			{
				return "";
			}
			if (!string.IsNullOrEmpty(CurrentSelectedElement.Text))
			{
				return CurrentSelectedElement.Text;
			}
			return "";
		}
	}
}
