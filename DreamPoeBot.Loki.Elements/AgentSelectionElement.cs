using System.Collections.Generic;

namespace DreamPoeBot.Loki.Elements;

public class AgentSelectionElement : Element
{
	public List<AgentElement> Agents
	{
		get
		{
			List<AgentElement> list = new List<AgentElement>();
			Element element = base.Children[2];
			foreach (Element child in element.Children)
			{
				AgentElement objectAt = child.GetObjectAt<AgentElement>(0);
				if (objectAt != null)
				{
					list.Add(objectAt);
				}
			}
			return list;
		}
	}
}
