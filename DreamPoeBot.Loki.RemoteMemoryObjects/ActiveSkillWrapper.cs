using System.Collections.Generic;

namespace DreamPoeBot.Loki.RemoteMemoryObjects;

public class ActiveSkillWrapper : RemoteMemoryObject
{
	public string InternalName => base.M.ReadStringU(base.M.ReadLong(base.Address));

	public string DisplayName => base.M.ReadStringU(base.M.ReadLong(base.Address + 8L));

	public string Description => base.M.ReadStringU(base.M.ReadLong(base.Address + 16L));

	public string SkillName => base.M.ReadStringU(base.M.ReadLong(base.Address + 24L));

	public string Icon => base.M.ReadStringU(base.M.ReadLong(base.Address + 32L));

	public List<int> CastTypes
	{
		get
		{
			List<int> list = new List<int>();
			int num = base.M.ReadInt(base.Address + 40L);
			long num2 = base.M.ReadLong(base.Address + 48L);
			for (int i = 0; i < num; i++)
			{
				list.Add(base.M.ReadInt(num2));
				num2 += 4L;
			}
			return list;
		}
	}

	public List<int> SkillTypes
	{
		get
		{
			List<int> list = new List<int>();
			int num = base.M.ReadInt(base.Address + 56L);
			long num2 = base.M.ReadLong(base.Address + 64L);
			for (int i = 0; i < num; i++)
			{
				list.Add(base.M.ReadInt(num2));
				num2 += 4L;
			}
			return list;
		}
	}

	public string LongDescription => base.M.ReadStringU(base.M.ReadLong(base.Address + 80L));

	public string AmazonLink => base.M.ReadStringU(base.M.ReadLong(base.Address + 96L));
}
