using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Components;

public class Buffs : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct BuffsStructure
	{
		private long vTable;

		private long intptr1;

		private long intptr2;

		private long intptr3;

		private long intptr4;

		private long intptr5;

		private long intptr6;

		private long intptr7;

		private long intptr8;

		private long intptr9;

		private long intptr10;

		private long intptr11;

		private long intptr12;

		private long intptr13;

		private long intptr14;

		private long intptr15;

		private long intptr16;

		private long intptr17;

		private long intptr18;

		private long intptr19;

		private long intptr20;

		private long intptr21;

		private long intptr22;

		private long intptr23;

		private long intptr24;

		private long intptr25;

		private long intptr26;

		private long intptr27;

		private long intptr28;

		private long intptr29;

		private long intptr30;

		private long intptr31;

		private long intptr32;

		private long intptr33;

		private long intptr34;

		private long intptr35;

		private long intptr36;

		private long intptr37;

		private long intptr38;

		private long intptr39;

		private long intptr40;

		private long intptr41;

		private long intptr42;

		private long intptr43;

		public NativeVector BuffVector;
	}

	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct BuffOffsets
	{
		[FieldOffset(0)]
		public long Name;

		[FieldOffset(16)]
		public byte IsInvisible;

		[FieldOffset(17)]
		public byte IsRemovable;

		[FieldOffset(62)]
		public byte Charges;

		[FieldOffset(16)]
		public float MaxTime;

		[FieldOffset(20)]
		public float Timer;
	}

	private PerFrameCachedValue<List<Aura>> _cachedValueBuffs;

	private PerFrameCachedValue<BuffsStructure> perFrameCachedValue;

	public List<Aura> Auras
	{
		get
		{
			if (_cachedValueBuffs == null)
			{
				_cachedValueBuffs = new PerFrameCachedValue<List<Aura>>(method_2);
			}
			return _cachedValueBuffs;
		}
	}

	internal BuffsStructure buffsStructure
	{
		get
		{
			if (perFrameCachedValue == null)
			{
				perFrameCachedValue = new PerFrameCachedValue<BuffsStructure>(GetStructure);
			}
			return perFrameCachedValue;
		}
	}

	public bool HasBuff(string buff)
	{
		return Auras.Any((Aura x) => x.Name == buff);
	}

	private List<Aura> method_2()
	{
		NativeVector buffVector = buffsStructure.BuffVector;
		if (buffVector.First != 0L && buffVector.Last != 0L && buffVector.End != 0L)
		{
			return (from x in Containers.StdLongVector<long>(buffVector)
				select new Aura(x)).ToList();
		}
		return new List<Aura>();
	}

	private BuffsStructure GetStructure()
	{
		return base.M.FastIntPtrToStruct<BuffsStructure>(base.Address);
	}
}
