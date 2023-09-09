using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Chest : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct156
	{
		private Struct253 struct253_0;

		private long intptr_0;

		private long intptr_1;

		public long intptr_181;

		private NativeVector unusednativeVector_0;

		private long intptr_10;

		private long intptr_11;

		private long intptr_12;

		private long intptr_13;

		private long intptr_14;

		private long intptr_15;

		private long intptr_16;

		private long intptr_17;

		private long intptr_18;

		private long intptr_19;

		private long intptr_20;

		private long intptr_21;

		private long intptr_22;

		private long intptr_23;

		private long intptr_24;

		private long intptr_25;

		private NativeVector nativeVector_0;

		private long intptr_26;

		private long intptr_27;

		private long intptr_28;

		private long intptr_29;

		private long intptr_30;

		private long intptr_31;

		private long intptr_32;

		private long intptr_33;

		private long intptr_34;

		private long intptr_35;

		private long intptr_36;

		private long intptr_37;

		private long intptr_38;

		private long intptr_39;

		private long intptr_40;

		private long intptr_41;

		private long intptr_42;

		public long intptr_1Struct157;

		public byte byte_4IsOpened;

		public byte byte_5IsLocked;

		private byte byte_6;

		private byte byte_7;

		private byte byte_9;

		public byte byte_8Quality;

		private ushort ushort_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct157
	{
		private long intptr_0;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		public byte byte_0OpeningDestroys;

		public byte byte_1IsLarge;

		public byte byte_2Stompable;

		public byte byte_3AxisAligned;

		private byte byte_4;

		public byte byte_5OpenOnDamage;

		private byte byte_6;

		private byte byte_7;

		public byte byte_8OpenChestWhenDemonsDie;

		private byte byte_9;

		private byte byte_10;

		private byte byte_11;

		private int unusedInt_0;

		private long int_0;

		private long int_1;

		private long int_2;

		private long int_3;

		private long int_4;

		private long int_5;

		public int int_6DropSlots;

		private int int_7;

		private int int_8;

		private int int_9;

		private int int_10;

		private int int_11;

		private int int_12;
	}

	private bool? nullable_0;

	private int? nullable_1;

	private bool? nullable_2;

	private bool? nullable_3;

	private bool? nullable_4;

	private bool? nullable_5;

	private bool? nullable_6;

	private PerFrameCachedValue<Struct156> perFrameCachedValue_1;

	private PerFrameCachedValue<Struct157> perFrameCachedValue_2;

	public int DropSlots
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				nullable_1 = Struct157_0.int_6DropSlots;
			}
			return nullable_1.Value;
		}
	}

	public bool OpenOnDamage
	{
		get
		{
			if (!nullable_4.HasValue)
			{
				nullable_4 = Struct157_0.byte_5OpenOnDamage > 0;
			}
			return nullable_4.Value;
		}
	}

	public bool OpeningDestroys
	{
		get
		{
			if (!nullable_5.HasValue)
			{
				nullable_5 = Struct157_0.byte_0OpeningDestroys > 0;
			}
			return nullable_5.Value;
		}
	}

	public bool AxisAligned
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				nullable_0 = Struct157_0.byte_3AxisAligned > 0;
			}
			return nullable_0.Value;
		}
	}

	public bool Stompable
	{
		get
		{
			if (!nullable_6.HasValue)
			{
				nullable_6 = Struct157_0.byte_2Stompable > 0;
			}
			return nullable_6.Value;
		}
	}

	public bool IsLarge
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				nullable_2 = Struct157_0.byte_1IsLarge > 0;
			}
			return nullable_2.Value;
		}
	}

	public bool OpenChestWhenDemonsDie
	{
		get
		{
			if (!nullable_3.HasValue)
			{
				nullable_3 = Struct157_0.byte_8OpenChestWhenDemonsDie > 0;
			}
			return nullable_3.Value;
		}
	}

	public bool IsOpened => Struct156_0.byte_4IsOpened > 0;

	public bool IsLocked => Struct156_0.byte_5IsLocked > 0;

	public int Quality => Struct156_0.byte_8Quality;

	public Vector2i Position
	{
		get
		{
			LokiPoe.ObjectManager.Objects.Where((NetworkObject x) => x.Components.ChestComponent != null);
			if (base.Owner.PositionedComponent_0 == null)
			{
				return new Vector2i(0, 0);
			}
			return new Vector2i(base.Owner.PositionedComponent_0.GridX, base.Owner.PositionedComponent_0.GridY);
		}
	}

	internal Struct156 Struct156_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct156>(() => base.M.FastIntPtrToStruct<Struct156>(base.Address));
			}
			return perFrameCachedValue_1;
		}
	}

	internal Struct157 Struct157_0
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Struct157>(() => base.M.FastIntPtrToStruct<Struct157>(Struct156_0.intptr_1Struct157));
			}
			return perFrameCachedValue_2;
		}
	}

	public override string ToString()
	{
		_ = Struct156_0;
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine(string.Format("[{0}]", "ChestComponent"));
		stringBuilder.AppendLine($"\tBaseAddress: 0x{base.Address:X}");
		stringBuilder.AppendLine($"IsOpened: {IsOpened}");
		stringBuilder.AppendLine($"IsLocked: {IsLocked}");
		stringBuilder.AppendLine($"Quality: {Quality}");
		stringBuilder.AppendLine($"DropSlots: {DropSlots}");
		stringBuilder.AppendLine($"OpenOnDamage: {OpenOnDamage}");
		stringBuilder.AppendLine($"OpeningDestroys: {OpeningDestroys}");
		stringBuilder.AppendLine($"AxisAligned: {AxisAligned}");
		stringBuilder.AppendLine($"Stompable: {Stompable}");
		stringBuilder.AppendLine($"IsLarge: {IsLarge}");
		stringBuilder.AppendLine($"OpenChestWhenDemonsDie: {OpenChestWhenDemonsDie}");
		return stringBuilder.ToString();
	}

	[CompilerGenerated]
	private Struct156 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct156>(base.Address);
	}

	[CompilerGenerated]
	private Struct157 method_2()
	{
		return base.M.FastIntPtrToStruct<Struct157>(Struct156_0.intptr_1Struct157);
	}
}
