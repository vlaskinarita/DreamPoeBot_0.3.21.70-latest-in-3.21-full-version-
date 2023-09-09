using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class HiddenSkillBarElement : Element
{
	public Dictionary<Element, KeyValuePair<long, ushort>> SkillsDictionary
	{
		get
		{
			Dictionary<Element, KeyValuePair<long, ushort>> dictionary = new Dictionary<Element, KeyValuePair<long, ushort>>();
			foreach (Element skillsElement in SkillsElements)
			{
				long num = LokiPoe.Memory.ReadLong(skillsElement.Address + 632L);
				ushort value = LokiPoe.Memory.ReadUShort(skillsElement.Address + 640L);
				if (num == 0L)
				{
					Skill skill = LokiPoe.ObjectManager.Me.Components.ActorComponent.AvailableSkills.FirstOrDefault((Skill x) => x.Name == "Move");
					if (!(skill == null))
					{
						dictionary.Add(skillsElement, new KeyValuePair<long, ushort>(skill.Address, skill.Id));
					}
				}
				else
				{
					dictionary.Add(skillsElement, new KeyValuePair<long, ushort>(num, value));
				}
			}
			return dictionary;
		}
	}

	public Element ClearSkillElement => base.Children.LastOrDefault();

	public List<Element> SkillsElements
	{
		get
		{
			List<Element> list = new List<Element>();
			if (base.ChildCount < 4L)
			{
				return list;
			}
			list.Add(base.Children[1]);
			list.Add(base.Children[(int)base.ChildCount - 2]);
			if (base.ChildCount > 4L)
			{
				for (int i = 2; i < (int)base.ChildCount - 2; i++)
				{
					list.Add(base.Children[i]);
				}
				return list;
			}
			return list;
		}
	}
}
