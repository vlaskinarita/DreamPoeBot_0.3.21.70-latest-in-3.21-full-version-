namespace DreamPoeBot.Loki.Elements;

public class HeistContractElement : Element
{
	public Element SignContractElement
	{
		get
		{
			if (base.ChildCount < 3L)
			{
				return null;
			}
			Element element = base.Children[2];
			if (element.ChildCount >= 3L)
			{
				Element element2 = element.Children[2];
				return element2.Children[0];
			}
			return null;
		}
	}

	public AgentSelectionElement AgentSelectionPannelElement
	{
		get
		{
			if (base.ChildCount < 3L)
			{
				return null;
			}
			Element element = base.Children[2];
			if (element.ChildCount < 2L)
			{
				return null;
			}
			Element element2 = element.Children[1];
			return element2.Children[0].GetObjectAt<AgentSelectionElement>(0);
		}
	}

	public TeamElement TeamElement
	{
		get
		{
			if (base.ChildCount < 3L)
			{
				return null;
			}
			Element element = base.Children[2];
			if (element.ChildCount >= 1L)
			{
				Element element2 = element.Children[0];
				return element2.Children[0].Children[2].Children[1].GetObjectAt<TeamElement>(0);
			}
			return null;
		}
	}

	public Element ContractDettailsElement
	{
		get
		{
			if (base.ChildCount < 3L)
			{
				return null;
			}
			Element element = base.Children[2];
			if (element.ChildCount >= 1L)
			{
				Element element2 = element.Children[0];
				return element2.Children[0].Children[0].Children[1];
			}
			return null;
		}
	}

	public Element ContractFeesElement
	{
		get
		{
			if (base.ChildCount < 3L)
			{
				return null;
			}
			Element element = base.Children[2];
			if (element.ChildCount < 1L)
			{
				return null;
			}
			Element element2 = element.Children[0];
			return element2.Children[0].Children[4].Children[0];
		}
	}
}
