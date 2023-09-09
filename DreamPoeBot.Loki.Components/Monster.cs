using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Components;

public class Monster : Component
{
	private string metadata;

	private string id;

	private string baseResistance;

	private string name;

	private long Struct272MonsteResistanceAddress => Struct273MonsterType.intptr_3MonsteResistanceStruct;

	private Struct272MonsteResistanceComp Struct272 => base.M.FastIntPtrToStruct<Struct272MonsteResistanceComp>(Struct272MonsteResistanceAddress, MarshalCache<Struct272MonsteResistanceComp>.Size);

	private long Struct273MonsterTypeAddress => Struct274MonsteVariety.intptr_DatMosterTypeData;

	private Struct273MonsteTypeComp Struct273MonsterType => base.M.FastIntPtrToStruct<Struct273MonsteTypeComp>(Struct273MonsterTypeAddress, MarshalCache<Struct273MonsteTypeComp>.Size);

	private long Struct274MonsteVarietyAddress => Struct275.intptr_MonsteVarietyAddress;

	private Struct274MonsteVarietyComp Struct274MonsteVariety => base.M.FastIntPtrToStruct<Struct274MonsteVarietyComp>(Struct274MonsteVarietyAddress, MarshalCache<Struct274MonsteVarietyComp>.Size);

	private Struct275MonsteComp Struct275 => base.M.FastIntPtrToStruct<Struct275MonsteComp>(base.M.ReadLong(base.Address + 24L), MarshalCache<Struct275MonsteComp>.Size);

	public int Level => Struct275.int_0Level;

	public List<string> Tags
	{
		get
		{
			List<string> list = new List<string>();
			long address = GameController.Instance.Files.Tags.Address;
			for (int i = 0; i < 100; i++)
			{
				Struct242 @struct = base.M.FastIntPtrToStruct<Struct242>(Struct274MonsteVariety.intptr11_TaGS + i * MarshalCache<Struct242>.Size, MarshalCache<Struct242>.Size);
				if (@struct.intptr_0 != address)
				{
					break;
				}
				Struct271 struct2 = base.M.FastIntPtrToStruct<Struct271>(@struct.intptr_1, MarshalCache<Struct271>.Size);
				list.Add(base.M.ReadStringU(struct2.intptr_0));
			}
			return list;
		}
	}

	public string MonsterTypeMetadata
	{
		get
		{
			if (string.IsNullOrEmpty(metadata))
			{
				metadata = base.M.ReadStringU(Struct274MonsteVariety.intptr_0Metadata);
			}
			return metadata;
		}
	}

	public string MonsterTypeId
	{
		get
		{
			if (string.IsNullOrEmpty(id))
			{
				id = base.M.ReadStringU(Struct273MonsterType.intptr_TypeId);
			}
			return id;
		}
	}

	public string BaseResistenceName
	{
		get
		{
			if (string.IsNullOrEmpty(baseResistance))
			{
				baseResistance = base.M.ReadStringU(Struct272.intptr_BaseResistanceName);
			}
			return baseResistance;
		}
	}

	public string MonsterName
	{
		get
		{
			if (string.IsNullOrEmpty(name))
			{
				name = base.M.ReadStringU(Struct274MonsteVariety.IntPtr_MonsterName);
			}
			return name;
		}
	}
}
