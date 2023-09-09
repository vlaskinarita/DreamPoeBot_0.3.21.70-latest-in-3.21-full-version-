using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using DreamPoeBot.Loki.Game.Utilities;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class StashElement : Element
{
	private PerAreaCachedValue<Element> _searchElement;

	private PerAreaCachedValue<Element> _searchCloseElement;

	private PerAreaCachedValue<Element> _stashOptionsElement;

	private PerAreaCachedValue<Element> _mainControl;

	public long TotalStashes => StashInventoryPanel.ChildCount;

	public string SearchElementText => SearchElement?.Text;

	public Element SearchElement
	{
		get
		{
			if (_searchElement == null)
			{
				_searchElement = new PerAreaCachedValue<Element>(GetSearchElement);
			}
			return _searchElement.Value;
		}
	}

	public Element SearchCloseElement
	{
		get
		{
			if (_searchCloseElement == null)
			{
				_searchCloseElement = new PerAreaCachedValue<Element>(GetSearchCloseElement);
			}
			return _searchCloseElement.Value;
		}
	}

	public Element StashOptionsElement
	{
		get
		{
			if (_stashOptionsElement == null)
			{
				_stashOptionsElement = new PerAreaCachedValue<Element>(GetStashOptionsElement);
			}
			return _stashOptionsElement.Value;
		}
	}

	public Element MainControl
	{
		get
		{
			if (_mainControl == null)
			{
				_mainControl = new PerAreaCachedValue<Element>(GetMainControl);
			}
			return _mainControl.Value;
		}
	}

	public bool HideRemoveOnlyTabs => base.M.ReadByte(StashOptionsElement.Children[0].Children[0].Children[1].Address + 994L) == 1;

	public Element TabListButton => MainControl.Children.FirstOrDefault((Element x) => x.IdLabel == "tab_list_button");

	public bool IsTabListButtonVisible
	{
		get
		{
			if (TabListButton != null)
			{
				return TabListButton.IsVisible;
			}
			return false;
		}
	}

	public List<Element> UpperTabsContainer
	{
		get
		{
			List<Element> list = new List<Element>();
			if (MainControl == null)
			{
				return list;
			}
			if (MainControl.ChildCount >= 1L)
			{
				foreach (Element child in MainControl.Children[0].Children)
				{
					if (string.IsNullOrEmpty(child.IdLabel))
					{
						list.Add(child.Children[0].Children[1]);
					}
				}
				return list;
			}
			return list;
		}
	}

	internal float UpperTabContainerXOffset
	{
		get
		{
			if (MainControl == null)
			{
				return 0f;
			}
			if (MainControl.ChildCount >= 1L)
			{
				float num = base.M.ReadFloat(MainControl.Children[0].Address + 168L);
				if (num >= 20000f || num <= -20000f)
				{
					num = 0f;
				}
				return num * MainControl.Children[0].Scale;
			}
			return 0f;
		}
	}

	public Element RightTabsContainerElement
	{
		get
		{
			if (MainControl == null)
			{
				return null;
			}
			return MainControl.Children[4];
		}
	}

	public float RightTabsContainerYOffset
	{
		get
		{
			if (RightTabsContainerElement == null)
			{
				return 0f;
			}
			float num = base.M.ReadFloat(RightTabsContainerElement.Address + 172L);
			if (num >= 20000f || num <= -20000f)
			{
				num = 0f;
			}
			return num * MainControl.Children[0].Scale;
		}
	}

	public float RightTabsContainerHeight
	{
		get
		{
			if (RightTabsContainerElement == null)
			{
				return 0f;
			}
			return RightTabsContainerElement.Height;
		}
	}

	public Element RightTabsContainerScrollUp
	{
		get
		{
			if (RightTabsContainerElement == null)
			{
				return null;
			}
			return RightTabsContainerElement.Children.FirstOrDefault((Element x) => x.IsVisible && x.Width == 47f).Children[0];
		}
	}

	public Element RightTabsContainerScrollDown
	{
		get
		{
			if (RightTabsContainerElement == null)
			{
				return null;
			}
			return RightTabsContainerElement.Children.FirstOrDefault((Element x) => x.IsVisible && x.Width == 47f).Children[1];
		}
	}

	public bool IsRightTabsContainerElementVisible
	{
		get
		{
			if (RightTabsContainerElement != null)
			{
				return RightTabsContainerElement.IsVisible;
			}
			return false;
		}
	}

	public List<Element> RightButtonContainer
	{
		get
		{
			List<Element> list = new List<Element>();
			if (!(RightTabsContainerElement == null))
			{
				if (RightTabsContainerElement.ChildCount < 3L)
				{
					return list;
				}
				Element element = RightTabsContainerElement.Children.FirstOrDefault((Element x) => x.IsVisible && x.Width > 47f);
				{
					foreach (Element child in element.Children)
					{
						list.Add(child.Children[0].Children[1]);
					}
					return list;
				}
			}
			return list;
		}
	}

	public Element StashInventoryPanel
	{
		get
		{
			if (base.Address == 0L)
			{
				return null;
			}
			return GetObject<Element>(base.M.ReadLong(MainControl.Address + 2424L));
		}
	}

	public byte IndexVisibleStash => base.M.ReadByte(MainControl.Address + 2528L);

	public Inventory VisibleStash => GetVisibleStash();

	internal MapsTabElement MapsTabElement
	{
		get
		{
			byte indexVisibleStash = IndexVisibleStash;
			if (indexVisibleStash >= TotalStashes)
			{
				return null;
			}
			if (StashInventoryPanel.Children[indexVisibleStash].ChildCount == 0L)
			{
				Stopwatch stopwatch = Stopwatch.StartNew();
				while (StashInventoryPanel.Children[indexVisibleStash].ChildCount == 0L)
				{
					if (stopwatch.ElapsedMilliseconds < 80L)
					{
						Thread.Sleep(1);
						continue;
					}
					return null;
				}
			}
			Element element = StashInventoryPanel.Children[IndexVisibleStash];
			return element.Children[0].AsObject<MapsTabElement>();
		}
	}

	private Element GetMainControl()
	{
		return base.Children[2].Children[0].Children[0].Children[1];
	}

	private Element GetStashOptionsElement()
	{
		return base.Children[4];
	}

	private Element GetSearchCloseElement()
	{
		return base.Children[3].Children[3].Children[1];
	}

	private Element GetSearchElement()
	{
		return base.Children[3]?.Children[3]?.Children[0];
	}

	private Inventory GetVisibleStash()
	{
		return GetStashInventoryByIndex(IndexVisibleStash);
	}

	public Inventory GetStashInventoryByIndex(int index)
	{
		Thread.Sleep(0);
		Element element = StashInventoryPanel.Children.FirstOrDefault((Element x) => x != null && x.IsVisible);
		Stopwatch stopwatch = Stopwatch.StartNew();
		while (element == null)
		{
			if (stopwatch.ElapsedMilliseconds < 5000L)
			{
				Thread.Sleep(1);
				element = StashInventoryPanel.Children.FirstOrDefault((Element x) => x != null && x.IsVisible);
				continue;
			}
			return null;
		}
		stopwatch = Stopwatch.StartNew();
		while (element.ChildCount == 0L)
		{
			if (stopwatch.ElapsedMilliseconds < 5000L)
			{
				Thread.Sleep(1);
				continue;
			}
			return null;
		}
		stopwatch = Stopwatch.StartNew();
		return element.Children[0].Children[0].AsObject<Inventory>();
	}
}
