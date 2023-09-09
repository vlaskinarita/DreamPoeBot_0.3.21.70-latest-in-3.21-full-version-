using System.Collections.Generic;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class SkillGemHudElement : Element
{
	internal List<Element> ListOfSkillElements
	{
		get
		{
			List<Element> list = new List<Element>();
			foreach (Element child in base.Children[0].Children)
			{
				if (child.Children[1].IsVisible)
				{
					list.Add(child);
				}
			}
			return list;
		}
	}

	public bool AreIconsDisplayed => ListOfSkillElements.Any();

	internal long IntPtr_1 => base.Children[0].Address;
}
