using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures._18;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Base : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct148
	{
		private Struct253 struct253_0;

		public long intptr_0Struct149_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;

		private NativeStringWCustom nativeStringW_0;

		public NativeStringWCustom nativeStringW_1DisplayNote;

		public NativeVector nativeVector_0Struct150MicrotansactionAttached;

		private long Intptr_6;

		private NativeVector nativeVector_1;

		private long Intptr_7;

		private int int_0;

		private byte byte_0;

		private byte byte_1;

		public byte byte_1ItemInfluence;

		public byte byte_2IsCorruptedOrVeiled;

		public int AbsorbedCorruption;

		public int ScourgedTier;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct149
	{
		private long intptr_0;

		private long intptr_1;

		public byte Size_X;

		public byte Size_Y;

		public byte byte_BaseLevel;

		private byte byte_1;

		private short short_0;

		private short short_1;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		public NativeStringWCustom nativeStringW_0Name;

		public Struct243 struct243_0BaseItemType;

		public NativeVector nativeVector_0Struct242Tags;

		public NativeStringWCustom nativeStringW_1DescriptionText;
	}

	private int _struct150Size = -1;

	private int _struct242Size = -1;

	private PerFrameCachedValue<Struct148> perFrameCachedValue_1;

	private PerFrameCachedValue<string> perFrameCachedValue_2;

	private PerFrameCachedValue<string> perFrameCachedValue_3;

	private PerFrameCachedValue<string> perFrameCachedValue_4;

	private List<string> list_0;

	private DatBaseItemTypeWrapper datBaseItemTypeWrapper_0;

	public string Name
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<string>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	public string DescriptionText
	{
		get
		{
			if (perFrameCachedValue_3 == null)
			{
				perFrameCachedValue_3 = new PerFrameCachedValue<string>(method_3);
			}
			return perFrameCachedValue_3;
		}
	}

	public string DisplayNote
	{
		get
		{
			if (perFrameCachedValue_4 == null)
			{
				perFrameCachedValue_4 = new PerFrameCachedValue<string>(method_4);
			}
			return perFrameCachedValue_4;
		}
	}

	public int BaseLevel => Struct149_0.byte_BaseLevel;

	public Vector2i Size => new Vector2i(Struct149_0.Size_X, Struct149_0.Size_Y);

	public int WorldObjectSize
	{
		get
		{
			Vector2i size = Size;
			return size.X * size.Y;
		}
	}

	public bool IsCorrupted
	{
		get
		{
			byte byte_2IsCorruptedOrVeiled = Struct148_0.byte_2IsCorruptedOrVeiled;
			return (byte_2IsCorruptedOrVeiled & 1) == 1;
		}
	}

	public bool IsShaperItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 1) == 1;
		}
	}

	public bool IsElderItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 2) == 2;
		}
	}

	public bool IsHunterItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 0x10) == 16;
		}
	}

	public bool IsWarlordItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 0x20) == 32;
		}
	}

	public bool IsCrusaderItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 4) == 4;
		}
	}

	public bool IsRedeemerItem
	{
		get
		{
			byte byte_1ItemInfluence = Struct148_0.byte_1ItemInfluence;
			return (byte_1ItemInfluence & 8) == 8;
		}
	}

	public bool IsTradeAndModifiedLocked => false;

	public int AbsorbedCorruption => Struct148_0.AbsorbedCorruption;

	public int ScourgedTier => Struct148_0.ScourgedTier;

	private int Struct150Size
	{
		get
		{
			if (_struct150Size == -1)
			{
				_struct150Size = MarshalCache<Struct150>.Size;
			}
			return _struct150Size;
		}
	}

	public List<string> MicrotransactionAttachments
	{
		get
		{
			List<string> list = new List<string>();
			Struct150[] array = base.M.IntptrToStructArray<Struct150>(Struct148_0.nativeVector_0Struct150MicrotansactionAttached, Struct150Size);
			for (int i = 0; i < array.Length; i++)
			{
				Struct150 @struct = array[i];
				Struct151 struct2 = base.M.FastIntPtrToStruct<Struct151>(@struct.intptr_1);
				DatBaseItemTypeWrapper.DatBaseItemTypeStucture datBaseItemTypeStucture = base.M.FastIntPtrToStruct<DatBaseItemTypeWrapper.DatBaseItemTypeStucture>(struct2.struct243_0.intptr_1);
				list.Add(base.M.ReadStringU(datBaseItemTypeStucture.intptr_3Name));
			}
			return list;
		}
	}

	private int Struct242Size
	{
		get
		{
			if (_struct242Size == -1)
			{
				_struct242Size = MarshalCache<Struct242>.Size;
			}
			return _struct242Size;
		}
	}

	public List<string> Tags
	{
		get
		{
			if (list_0 == null)
			{
				list_0 = base.M.IntptrToStructArray<Struct242>(Struct149_0.nativeVector_0Struct242Tags, Struct242Size).Select(method_5).ToList();
			}
			return list_0;
		}
	}

	public DatBaseItemTypeWrapper BaseItemType
	{
		get
		{
			DatBaseItemTypeWrapper result;
			if ((result = datBaseItemTypeWrapper_0) == null)
			{
				result = (datBaseItemTypeWrapper_0 = new DatBaseItemTypeWrapper(Struct149_0.struct243_0BaseItemType.intptr_1));
			}
			return result;
		}
	}

	internal Struct149 Struct149_0 => base.M.FastIntPtrToStruct<Struct149>(Struct148_0.intptr_0Struct149_0);

	internal Struct148 Struct148_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct148>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	private Struct148 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct148>(base.Address);
	}

	private string method_2()
	{
		return Containers.StdStringWCustom(Struct149_0.nativeStringW_0Name);
	}

	private string method_3()
	{
		return Containers.StdStringWCustom(Struct149_0.nativeStringW_1DescriptionText);
	}

	private string method_4()
	{
		return Containers.StdStringWCustom(Struct148_0.nativeStringW_1DisplayNote);
	}

	private string method_5(Struct242 struct242_0)
	{
		return base.M.ReadStringU(base.M.ReadLong(struct242_0.intptr_1));
	}
}
