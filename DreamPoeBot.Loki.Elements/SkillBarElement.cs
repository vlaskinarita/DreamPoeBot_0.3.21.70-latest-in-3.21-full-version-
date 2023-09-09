using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class SkillBarElement : Element
{
	public long TotalSkills => base.ChildCount;

	public SkillElement this[int k] => base.Children[k].AsObject<SkillElement>();

	public Dictionary<Element, KeyValuePair<long, ushort>> SkillsDictionary
	{
		get
		{
			Dictionary<Element, KeyValuePair<long, ushort>> dictionary = new Dictionary<Element, KeyValuePair<long, ushort>>();
			foreach (Element skillsElement in SkillsElements)
			{
				long key = LokiPoe.Memory.ReadLong(skillsElement.Address + 632L);
				ushort value = LokiPoe.Memory.ReadUShort(skillsElement.Address + 640L);
				dictionary.Add(skillsElement, new KeyValuePair<long, ushort>(key, value));
			}
			return dictionary;
		}
	}

	public Dictionary<Element, KeyValuePair<long, ushort>> ControlSkillsDictionary
	{
		get
		{
			Dictionary<Element, KeyValuePair<long, ushort>> dictionary = new Dictionary<Element, KeyValuePair<long, ushort>>();
			foreach (Element controlSkillsElement in ControlSkillsElements)
			{
				long key = LokiPoe.Memory.ReadLong(controlSkillsElement.Address + 632L);
				ushort value = LokiPoe.Memory.ReadUShort(controlSkillsElement.Address + 640L);
				dictionary.Add(controlSkillsElement, new KeyValuePair<long, ushort>(key, value));
			}
			return dictionary;
		}
	}

	public List<Element> SkillsElements
	{
		get
		{
			List<Element> list = new List<Element>();
			for (int i = 0; i <= 7; i++)
			{
				list.Add(base.Children[i]);
			}
			return list;
		}
	}

	public List<Element> ControlSkillsElements
	{
		get
		{
			List<Element> list = new List<Element>();
			for (int i = 8; i <= 12; i++)
			{
				list.Add(base.Children[i]);
			}
			return list;
		}
	}
}
