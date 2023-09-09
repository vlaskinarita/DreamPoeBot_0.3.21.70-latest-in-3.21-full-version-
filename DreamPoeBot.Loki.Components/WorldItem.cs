using System;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.Models;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class WorldItem : Component
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct Struct233
	{
		private Struct253WorldItemComp struct253_0;

		private byte byte_0;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private int int00;

		private long intptr_0;

		private long intptr_1;

		public long intptr_2Entity;

		private long intptr_3;

		private long intptr_4;

		public uint uint_0AllocatedToPlayer;

		public int int_0AllocatedToOtherTime;

		public int int_1DroppedTime;

		private float float_0;

		private byte byte_4;

		private byte byte_5;

		private byte byte_6;

		private byte byte_7;

		private int int01;

		private long intptr_5;
	}

	private PerFrameCachedValue<Struct233> perFrameCachedValue_1;

	private PerFrameCachedValue<Entity> perFrameCachedValue_2;

	private int _struct233Size = -1;

	public bool IsPermanentlyAllocated => AllocatedToOtherTime == 300000;

	public int AllocatedToOtherTime => reader.int_0AllocatedToOtherTime;

	public bool AllocatedToSomeoneElse
	{
		get
		{
			if (AllocatedToPlayer != 0)
			{
				return LokiPoe.ObjectManager.Me.Components.PlayerComponent.AllocatedLootId != AllocatedToPlayer;
			}
			return false;
		}
	}

	public uint AllocatedToPlayer => reader.uint_0AllocatedToPlayer;

	public DateTime DroppedTime => smethod_1(reader.int_1DroppedTime);

	public DateTime PublicTime => DroppedTime + TimeSpan.FromMilliseconds(AllocatedToOtherTime);

	internal int Struct233Size
	{
		get
		{
			if (_struct233Size == -1)
			{
				_struct233Size = MarshalCache<Struct233>.Size;
			}
			return _struct233Size;
		}
	}

	internal Struct233 reader
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<Struct233>(method_1);
			}
			return perFrameCachedValue_1;
		}
	}

	public Entity ItemEntity
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<Entity>(method_2);
			}
			return perFrameCachedValue_2;
		}
	}

	internal static DateTime smethod_1(int int_0)
	{
		return DateTime.Now - TimeSpan.FromMilliseconds(Environment.TickCount) + TimeSpan.FromMilliseconds(int_0);
	}

	private Struct233 method_1()
	{
		return base.M.FastIntPtrToStruct<Struct233>(base.Address, Struct233Size);
	}

	public EntityWrapper method_2()
	{
		if (base.Address == 0L)
		{
			return GetObject<EntityWrapper>(0L);
		}
		return CreateObject<EntityWrapper>(reader.intptr_2Entity);
	}
}
