using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements;

public class BlightTowerElement : Element
{
	private Element Interface => base.Children[0]?.Children[3];

	public List<BlightTowerOption> Menu
	{
		get
		{
			List<BlightTowerOption> list = new List<BlightTowerOption>();
			if (Interface == null)
			{
				return list;
			}
			if (!Interface.IsVisible)
			{
				list.Add(Interface.GetObjectAt<BlightTowerOption>(0));
			}
			foreach (Element child in Interface.Children)
			{
				if (child.IsVisible)
				{
					list.Add(child.GetObjectAt<BlightTowerOption>(0));
				}
			}
			return list;
		}
	}
}
