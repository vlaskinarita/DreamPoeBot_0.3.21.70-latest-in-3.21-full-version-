using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Structures.ns16;

namespace DreamPoeBot.Loki.Elements;

public class MainUiElement : Element
{
	internal Struct124 Struct124 => GameController.Instance.Memory.FastIntPtrToStruct<Struct124>(base.Address, MarshalCache<Struct124>.Size);

	public List<long> test
	{
		get
		{
			List<long> list = new List<long>();
			int num = 16;
			for (int i = 0; i < 100; i++)
			{
				list.Add(GameController.Instance.Memory.ReadLong(base.Address + num));
				num += 128;
			}
			return list;
		}
	}
}
