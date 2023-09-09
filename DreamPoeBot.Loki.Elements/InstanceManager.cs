using System;
using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class InstanceManager : Element
{
	public int OpenInstances => CountOpenInstance();

	public Element MyInstance
	{
		get
		{
			List<Element> source = FindElementWithText("-");
			if (source.Any())
			{
				return source.FirstOrDefault();
			}
			return null;
		}
	}

	public Element NewInstance
	{
		get
		{
			List<Element> source = FindElementWithText("new");
			if (!source.Any())
			{
				return null;
			}
			return source.FirstOrDefault();
		}
	}

	public Vector2i NewInstanceClickPosition
	{
		get
		{
			if (NewInstance == null)
			{
				throw new Exception("No control found for new instance.");
			}
			return LokiPoe.ElementClickLocation(NewInstance);
		}
	}

	private int CountOpenInstance()
	{
		List<Element> list = FindElementWithText("enter");
		return list.Count;
	}

	internal List<Element> FindElementWithText(string text)
	{
		List<Element> list = new List<Element>();
		if (base.Text != null && base.Text == text)
		{
			list.Add(this);
		}
		if (base.ChildCount == 0L)
		{
			return list;
		}
		foreach (Element child in base.Children)
		{
			List<Element> list2 = FindElementTextInChildren(child, text);
			if (list2 == null)
			{
				continue;
			}
			foreach (Element item in list2)
			{
				list.Add(item);
			}
		}
		return list;
	}

	private List<Element> FindElementTextInChildren(Element elem, string text)
	{
		List<Element> list = new List<Element>();
		if (elem.Text != null && elem.Text == text)
		{
			list.Add(elem);
		}
		if (elem.ChildCount != 0L)
		{
			foreach (Element child in elem.Children)
			{
				List<Element> list2 = FindElementTextInChildren(child, text);
				if (list2 != null)
				{
					foreach (Element item in list2)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}
		return list;
	}
}
