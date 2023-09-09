using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements;

public class ProphecyUiElement : Element
{
	public Element SeekButtonElement => base.Children[0]?.Children[2];

	public List<ProphecyElement> ProphecyList
	{
		get
		{
			List<ProphecyElement> list = new List<ProphecyElement>();
			if (base.ChildCount >= 1L)
			{
				foreach (Element item in base.Children[0]?.Children[0]?.Children)
				{
					list.Add(base.M.GetObject<ProphecyElement>(item.Address));
				}
				return list;
			}
			return list;
		}
	}
}
