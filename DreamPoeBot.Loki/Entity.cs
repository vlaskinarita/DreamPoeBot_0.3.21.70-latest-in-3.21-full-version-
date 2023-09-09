using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Components;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.Game.Utilities;

namespace DreamPoeBot.Loki;

public abstract class Entity : RemoteMemoryObject
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct EntityStructure
	{
		private long vtable;

		public long intptr_EntityDataStructure;

		public long intptr_ComponentList;

		private long intptr_3;

		private long intptr_4;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct EntityDataStructure
	{
		private long vtable;

		public NativeStringWCustom Metadata;

		private short shprt0;

		private short shprt1;

		private short shprt2;

		private short shprt3;

		public long intptr_EntityComponentStructure;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct EntityComponentStructure
	{
		private long vtable;

		private long intptr_1;

		private long intptr_2;

		private long intptr_3;

		private long intptr_4;

		public NativeHashMap ComponentIndices;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct BaseComponentStructure
	{
		public long Name;

		public int Index;

		private int int_0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct ComponentIndicesStructure
	{
		public byte idx0;

		public byte idx1;

		public byte idx2;

		public byte idx3;

		public byte idx4;

		public byte idx5;

		public byte idx6;

		public byte idx7;

		public BaseComponentStructure data0;

		public BaseComponentStructure data1;

		public BaseComponentStructure data2;

		public BaseComponentStructure data3;

		public BaseComponentStructure data4;

		public BaseComponentStructure data5;

		public BaseComponentStructure data6;

		public BaseComponentStructure data7;
	}

	private int _id = -1;

	private string _type;

	private Dictionary<string, long> componentsDictionary;

	private PerFrameCachedValue<EntityStructure> perFrameCachedValue_0;

	private PerFrameCachedValue<EntityDataStructure> perFrameCachedValue_1;

	private PerFrameCachedValue<EntityComponentStructure> perFrameCachedValue_2;

	public Dictionary<string, long> ComponentIndices
	{
		get
		{
			if (componentsDictionary == null)
			{
				componentsDictionary = BuildComponentIndices;
			}
			return componentsDictionary;
		}
	}

	public Dictionary<string, long> BuildComponentIndices
	{
		get
		{
			Dictionary<string, long> dictionary = new Dictionary<string, long>();
			NativeHashMap componentIndices = entityComponentStructure.ComponentIndices;
			long head = componentIndices.List.Head;
			uint size = componentIndices.List.Size;
			if (size <= 100)
			{
				int num = 0;
				int size2 = MarshalCache<ComponentIndicesStructure>.Size;
				for (int num2 = (int)size; num2 > 0; num2 -= 8)
				{
					ComponentIndicesStructure componentIndicesStructure = base.M.FastIntPtrToStruct<ComponentIndicesStructure>(head + size2 * num, size2);
					if (componentIndicesStructure.idx0 != byte.MaxValue)
					{
						string text = base.M.ReadString(componentIndicesStructure.data0.Name);
						if (string.IsNullOrEmpty(text))
						{
							continue;
						}
						int index = componentIndicesStructure.data0.Index;
						long value = base.M.ReadLong(entityStructure.intptr_ComponentList + index * 8);
						dictionary.Add(text, value);
					}
					if (componentIndicesStructure.idx1 != byte.MaxValue)
					{
						string text2 = base.M.ReadString(componentIndicesStructure.data1.Name);
						if (string.IsNullOrEmpty(text2))
						{
							continue;
						}
						int index2 = componentIndicesStructure.data1.Index;
						long value2 = base.M.ReadLong(entityStructure.intptr_ComponentList + index2 * 8);
						dictionary.Add(text2, value2);
					}
					if (componentIndicesStructure.idx2 != byte.MaxValue)
					{
						string text3 = base.M.ReadString(componentIndicesStructure.data2.Name);
						if (string.IsNullOrEmpty(text3))
						{
							continue;
						}
						int index3 = componentIndicesStructure.data2.Index;
						long value3 = base.M.ReadLong(entityStructure.intptr_ComponentList + index3 * 8);
						dictionary.Add(text3, value3);
					}
					if (componentIndicesStructure.idx3 != byte.MaxValue)
					{
						string text4 = base.M.ReadString(componentIndicesStructure.data3.Name);
						if (string.IsNullOrEmpty(text4))
						{
							continue;
						}
						int index4 = componentIndicesStructure.data3.Index;
						long value4 = base.M.ReadLong(entityStructure.intptr_ComponentList + index4 * 8);
						dictionary.Add(text4, value4);
					}
					if (componentIndicesStructure.idx4 != byte.MaxValue)
					{
						string text5 = base.M.ReadString(componentIndicesStructure.data4.Name);
						if (string.IsNullOrEmpty(text5))
						{
							continue;
						}
						int index5 = componentIndicesStructure.data4.Index;
						long value5 = base.M.ReadLong(entityStructure.intptr_ComponentList + index5 * 8);
						dictionary.Add(text5, value5);
					}
					if (componentIndicesStructure.idx5 != byte.MaxValue)
					{
						string text6 = base.M.ReadString(componentIndicesStructure.data5.Name);
						if (string.IsNullOrEmpty(text6))
						{
							continue;
						}
						int index6 = componentIndicesStructure.data5.Index;
						long value6 = base.M.ReadLong(entityStructure.intptr_ComponentList + index6 * 8);
						dictionary.Add(text6, value6);
					}
					if (componentIndicesStructure.idx6 != byte.MaxValue)
					{
						string text7 = base.M.ReadString(componentIndicesStructure.data6.Name);
						if (string.IsNullOrEmpty(text7))
						{
							continue;
						}
						int index7 = componentIndicesStructure.data6.Index;
						long value7 = base.M.ReadLong(entityStructure.intptr_ComponentList + index7 * 8);
						dictionary.Add(text7, value7);
					}
					if (componentIndicesStructure.idx7 != byte.MaxValue)
					{
						string text8 = base.M.ReadString(componentIndicesStructure.data7.Name);
						if (string.IsNullOrEmpty(text8))
						{
							continue;
						}
						int index8 = componentIndicesStructure.data7.Index;
						long value8 = base.M.ReadLong(entityStructure.intptr_ComponentList + index8 * 8);
						dictionary.Add(text8, value8);
					}
					num++;
				}
				return dictionary;
			}
			return dictionary;
		}
	}

	public string Type
	{
		get
		{
			if (_type == null)
			{
				_type = base.M.ReadStringU(base.M.ReadLong(base.Address + 8L, 8L));
			}
			return _type;
		}
	}

	public string Metadata
	{
		get
		{
			string text = Type;
			int num = text.IndexOf("@", StringComparison.Ordinal);
			if (num != -1)
			{
				text = text.Substring(0, num);
			}
			return text;
		}
	}

	public new bool IsValid => base.M.ReadInt(base.Address + 8L, 8L, 0L) == 6619213;

	public int Id
	{
		get
		{
			if (_id == -1)
			{
				_id = base.M.ReadInt(base.Address + 96L);
			}
			return _id;
		}
	}

	public string Name
	{
		get
		{
			try
			{
				Player component = GetComponent<Player>();
				if (component != null)
				{
					string name = component.Name;
					if (!string.IsNullOrEmpty(name))
					{
						return name;
					}
				}
				ArchnemesisMod component2 = GetComponent<ArchnemesisMod>();
				if (component2 != null)
				{
					string name = component2.ModWrapper.DisplayName;
					if (!string.IsNullOrWhiteSpace(name))
					{
						return name;
					}
				}
				WorldItem component3 = GetComponent<WorldItem>();
				if (component3 != null)
				{
					string name = component3.ItemEntity.Name;
					if (!string.IsNullOrEmpty(name))
					{
						return name;
					}
				}
				Render component4 = GetComponent<Render>();
				if (component4 != null)
				{
					string name = component4.Name;
					if (!string.IsNullOrEmpty(name))
					{
						return name;
					}
				}
				Base component5 = GetComponent<Base>();
				if (component5 != null)
				{
					string name = component5.Name;
					if (!string.IsNullOrEmpty(name))
					{
						return name;
					}
				}
				string metadata = Metadata;
				if (string.IsNullOrEmpty(metadata))
				{
					return "Unknown";
				}
				return metadata;
			}
			catch (Exception)
			{
				return "Unknown";
			}
		}
	}

	public Vector2i Position => new Vector2i(PositionedComp.GridX, PositionedComp.GridY);

	public Positioned PositionedComp => ReadObject<Positioned>(base.Address + 128L);

	public byte Reaction => PositionedComp.Reaction;

	internal EntityStructure entityStructure
	{
		get
		{
			if (perFrameCachedValue_0 == null)
			{
				perFrameCachedValue_0 = new PerFrameCachedValue<EntityStructure>(() => base.M.FastIntPtrToEntityStructure(base.Address));
			}
			return perFrameCachedValue_0;
		}
	}

	internal EntityDataStructure entityDataStructure
	{
		get
		{
			if (perFrameCachedValue_1 == null)
			{
				perFrameCachedValue_1 = new PerFrameCachedValue<EntityDataStructure>(() => base.M.FastIntPtrToEntityDataStructure(entityStructure.intptr_EntityDataStructure));
			}
			return perFrameCachedValue_1;
		}
	}

	internal EntityComponentStructure entityComponentStructure
	{
		get
		{
			if (perFrameCachedValue_2 == null)
			{
				perFrameCachedValue_2 = new PerFrameCachedValue<EntityComponentStructure>(() => base.M.FastIntPtrToEntityComponentStructure(entityDataStructure.intptr_EntityComponentStructure));
			}
			return perFrameCachedValue_2;
		}
	}

	public Entity()
	{
	}

	public Entity(long address)
		: base(address)
	{
	}

	public bool HasComponent<T>() where T : Component, new()
	{
		long addr;
		return HasComponent<T>(out addr);
	}

	private bool HasComponent<T>(out long addr) where T : Component, new()
	{
		addr = 0L;
		if (!ComponentIndices.TryGetValue(typeof(T).Name, out addr))
		{
			return false;
		}
		return true;
	}

	public T GetComponent<T>() where T : Component, new()
	{
		if (ComponentIndices.TryGetValue(typeof(T).Name, out var value))
		{
			return GetObject<T>(value);
		}
		return null;
	}

	public override string ToString()
	{
		return Metadata;
	}
}
