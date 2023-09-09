using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class AreaTransition : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct143
	{
		private Struct253 struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int unusedInt0;

		private long intptr_0;

		private ushort ushort_0;

		private ushort ushort_1;

		private float float_0;

		public ushort ushort_2Destination;

		public byte byte_4TransitionType;

		private ushort ushort_3;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private Struct243 struct243_0;

		private Struct243 struct243_1;

		private long intptr_3;

		private long intptr_4;

		private long intptr_5;
	}

	private int _struct143Size = -1;

	private PerFrameCachedValue<Struct143> perFrameCachedValue_1;

	private DatWorldAreaWrapper datWorldAreaWrapper_0;

	internal int Struct143Size
	{
		get
		{
			if (_struct143Size == -1)
			{
				_struct143Size = MarshalCache<Struct143>.Size;
			}
			return _struct143Size;
		}
	}

	internal Struct143 Struct143_0
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct143>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public DatWorldAreaWrapper Destination
	{
		get
		{
			if (datWorldAreaWrapper_0 == null)
			{
				datWorldAreaWrapper_0 = ((TransitionType == TransitionTypes.Local) ? Dat.LookupWorldArea(1) : Dat.LookupWorldArea(Struct143_0.ushort_2Destination + 1));
			}
			return datWorldAreaWrapper_0;
		}
	}

	public TransitionTypes TransitionType
	{
		get
		{
			byte byte_4TransitionType = Struct143_0.byte_4TransitionType;
			uint num = default(uint);
			while (true)
			{
				switch (byte_4TransitionType)
				{
				default:
				{
					int num2 = ((int)num * -1240977694) ^ -2073893313;
					while (true)
					{
						switch ((num = (uint)num2 ^ 0x94111u) % 9u)
						{
						case 6u:
							num2 = (int)(num * 380015037) ^ -1269532898;
							continue;
						case 1u:
						case 7u:
							break;
						case 5u:
							goto IL_0080;
						case 3u:
							goto IL_0082;
						case 8u:
							goto IL_0084;
						case 2u:
							goto IL_0086;
						default:
							goto IL_0088;
						case 4u:
							goto end_IL_0061;
						}
						break;
					}
					continue;
				}
				case 0:
					goto IL_0080;
				case 1:
					goto IL_0082;
				case 2:
					goto IL_0084;
				case 3:
					goto IL_0086;
				case 4:
					goto IL_0088;
				case 5:
					break;
					IL_0080:
					return TransitionTypes.Normal;
					IL_0088:
					return TransitionTypes.Unknown;
					IL_0086:
					return TransitionTypes.CorruptedToNormal;
					IL_0084:
					return TransitionTypes.NormalToCorrupted;
					IL_0082:
					return TransitionTypes.Local;
					end_IL_0061:
					break;
				}
				break;
			}
			return TransitionTypes.Labyrinth;
		}
	}

	private Struct143 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct143>(base.Address, Struct143Size);
	}
}
