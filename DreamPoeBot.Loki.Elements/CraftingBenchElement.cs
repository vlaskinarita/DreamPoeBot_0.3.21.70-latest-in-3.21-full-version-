using System;
using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class CraftingBenchElement : Element
{
	public class Recipe
	{
		public class Price
		{
			public Element _element;

			public List<Cost> PriceList
			{
				get
				{
					List<Cost> list = new List<Cost>();
					if (_element.ChildCount < 2L)
					{
						return list;
					}
					long childCount = _element.ChildCount;
					for (int i = 0; i < childCount; i += 2)
					{
						int quantity = GetQuantity(i);
						if (quantity != -1)
						{
							string currency = GetCurrency(i + 1);
							Cost cost = new Cost();
							cost.Quantity = quantity;
							cost.Currency = currency;
							list.Add(cost);
						}
					}
					return list;
				}
			}

			public Price(Element element)
			{
				_element = element;
			}

			public int GetQuantity(int idx)
			{
				Element element = _element.Children[idx];
				if (string.IsNullOrEmpty(element.Text))
				{
					return -1;
				}
				if (int.TryParse(element.Text.Replace("x", "").Replace(",", "").Replace(".", ""), out var result))
				{
					return result;
				}
				return -1;
			}

			public string GetCurrency(int idx)
			{
				long addr = LokiPoe.Memory.ReadLong(_element.Children[idx].Address + 416L);
				return LokiPoe.Memory.ReadNativeString(addr).Replace("Art/2DItems/Currency/", "").Replace(".dds", "");
			}
		}

		public class Cost
		{
			public int Quantity { get; set; }

			public string Currency { get; set; }
		}

		private Element _listElement;

		public Element _element;

		private string _category;

		public bool IsVisible => _element.IsVisibleLocal;

		public bool IsSelected => LokiPoe.Memory.ReadByte(_element.Address + 710L) == 1;

		public bool CanBeCrafted
		{
			get
			{
				if (LokiPoe.Memory.ReadByte(_element.Address + 714L) == 0 && LokiPoe.Memory.ReadByte(_element.Address + 704L) == 1)
				{
					return LokiPoe.Memory.ReadByte(_element.Address + 707L) == 1;
				}
				return false;
			}
		}

		public string Name => _element.Children[0].Children[1].Text;

		public string Category => _category;

		public int Level
		{
			get
			{
				try
				{
					Element element = _element.Children[0].Children[2].Children[0];
					if (string.IsNullOrEmpty(element.Text))
					{
						return -1;
					}
					if (int.TryParse(element.Text.Replace("lvl ", ""), out var result))
					{
						return result;
					}
					return -1;
				}
				catch (Exception)
				{
				}
				return -1;
			}
		}

		public Price Prices => new Price(_element.Children[0].Children[2].Children[1]);

		public Vector2i ClickLocation => _element.CenterClickLocation();

		public Recipe(string category, Element element, Element listElement)
		{
			_element = element;
			_category = category;
			_listElement = listElement;
		}
	}

	public Element CraftButtonElement => base.Children[2]?.Children[3]?.Children[0]?.Children[0];

	public Element SearchElement => base.Children[2]?.Children[0]?.Children[1]?.Children[0];

	public string SearchElementText => base.Children[2]?.Children[0]?.Children[1]?.Children[0]?.Children[0]?.Text;

	public Element ItemSlotElement => base.Children[2]?.Children[3]?.Children[1];

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory ItemSlotInventory => GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(ItemSlotElement.Address);

	public List<Element> RecipesListElement => base.Children[2]?.Children[1]?.Children[0]?.Children;

	public List<Recipe> RecipeList
	{
		get
		{
			Element listElement = base.Children[2]?.Children[1]?.Children[0];
			List<Recipe> list = new List<Recipe>();
			foreach (Element item in RecipesListElement)
			{
				string text = item.Children[0]?.Children[1]?.Text;
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				foreach (Element child in item.Children[1].Children[0].Children)
				{
					foreach (Element child2 in child.Children[0].Children[0].Children)
					{
						list.Add(new Recipe(text, child2, listElement));
					}
				}
			}
			return list;
		}
	}
}
