using System.Collections.Generic;
using System.Linq;

namespace DreamPoeBot.Loki.Elements;

public class AtlasElement : Element
{
	private Element AtlasMap => base.Children[0];

	private Element AtlasInventory => base.Children[6];

	private Element AtlasVoidstonesElement
	{
		get
		{
			Element element = AtlasMap.Children[(int)AtlasMap.ChildCount - 2];
			if (!element.IsVisible)
			{
				return null;
			}
			return element;
		}
	}

	internal Element AtlasCerimonialVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return AtlasVoidstonesElement?.Children[0]?.Children[0];
		}
	}

	internal Element AtlasDecayedVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return AtlasVoidstonesElement?.Children[0]?.Children[1];
		}
	}

	internal Element AtlasGraspingVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return AtlasVoidstonesElement?.Children[0]?.Children[2];
		}
	}

	internal Element AtlasOmniscientVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return AtlasVoidstonesElement?.Children[0]?.Children[3];
		}
	}

	internal Element AtlasInventoryCerimonialVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return base.Children[4]?.Children[2]?.Children[0];
		}
	}

	internal Element AtlasInventoryDecayedVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return base.Children[4]?.Children[2]?.Children[1];
		}
	}

	internal Element AtlasInventoryGraspingVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return base.Children[4]?.Children[2]?.Children[2];
		}
	}

	internal Element AtlasInventoryOmniscientVoidstone
	{
		get
		{
			if (AtlasMap == null)
			{
				return null;
			}
			return base.Children[4]?.Children[2]?.Children[3];
		}
	}

	public List<CitadelElement> Citadels
	{
		get
		{
			List<CitadelElement> list = new List<CitadelElement>();
			List<Element> list2 = AtlasMap.Children.Where((Element x) => x.ChildCount == 5L).ToList();
			foreach (Element item in list2)
			{
				list.Add(base.M.GetObject<CitadelElement>(item.Address));
			}
			return list;
		}
	}

	internal List<RegionInventory> Inventory
	{
		get
		{
			List<RegionInventory> list = new List<RegionInventory>();
			List<Element> children = AtlasInventory.Children[1].Children[0].Children;
			foreach (Element item in children)
			{
				list.Add(base.M.GetObject<RegionInventory>(item.Address));
			}
			return list;
		}
	}
}
