using System.Collections.Generic;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class HorticraftingElement : Element
{
	public class Recipe
	{
		public class Price
		{
			public Element _element;

			public List<Lifeforce> PriceList
			{
				get
				{
					List<Lifeforce> list = new List<Lifeforce>();
					long childCount = _element.ChildCount;
					for (int i = 0; i < childCount; i++)
					{
						int quantity = GetQuantity(i);
						if (quantity != -1)
						{
							string currency = GetCurrency(i);
							Lifeforce lifeforce = new Lifeforce();
							lifeforce.Quantity = quantity;
							lifeforce.Currency = currency;
							list.Add(lifeforce);
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
				Element element = _element.Children[idx].Children[0];
				if (string.IsNullOrEmpty(element.Text))
				{
					return -1;
				}
				if (!int.TryParse(element.Text.Replace("x", "").Replace(",", "").Replace(".", ""), out var result))
				{
					return -1;
				}
				return result;
			}

			public string GetCurrency(int idx)
			{
				long addr = LokiPoe.Memory.ReadLong(_element.Children[idx].Children[1].Address + 416L);
				return LokiPoe.Memory.ReadNativeString(addr).Replace("Art/2DItems/Currency/Harvest/", "").Replace(".dds", "");
			}
		}

		public Element _element;

		public bool IsVisible => _element.IsVisibleLocal;

		public bool IsSelected => LokiPoe.Memory.ReadByte(_element.Address + 642L) == 1;

		public bool CanBeCrafted => LokiPoe.Memory.ReadByte(_element.Address + 640L) == 1;

		public string Name => _element.Children[1].Text;

		public Price Prices => new Price(_element.Children[0]);

		public Vector2i ClickLocation => _element.CenterClickLocation();

		public Recipe(Element element)
		{
			_element = element;
		}
	}

	public class Lifeforce
	{
		public int Quantity { get; set; }

		public string Currency { get; set; }
	}

	public Element CraftButtonElement => base.Children[11]?.Children[1];

	public List<Element> RecipesListElement => base.Children[7]?.Children[0]?.Children[1]?.Children;

	public Element SearchElement => base.Children[8]?.Children[3];

	public string SearchElementText => SearchElement?.Children[0]?.Text;

	public Element ItemSlotElement => base.Children[11]?.Children[0]?.Children[0]?.Children[0];

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory ItemSlotInventory => GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(ItemSlotElement.Address);

	public Element CurrencyInventory => base.Children[11].Children[2];

	public List<Lifeforce> AvailableLifeforces
	{
		get
		{
			List<Lifeforce> list = new List<Lifeforce>();
			foreach (Element child in CurrencyInventory.Children)
			{
				int quantity = 0;
				string text = "";
				if (int.TryParse(child.Children[1].Text.Replace("x", "").Replace(",", "").Replace(".", ""), out var result))
				{
					quantity = result;
				}
				long addr = LokiPoe.Memory.ReadLong(child.Children[0].Address + 384L);
				text = LokiPoe.Memory.ReadNativeString(addr).Replace("Art/2DItems/Currency/Harvest/", "").Replace(".dds", "");
				Lifeforce lifeforce = new Lifeforce();
				lifeforce.Currency = text;
				lifeforce.Quantity = quantity;
				list.Add(lifeforce);
			}
			return list;
		}
	}

	public List<Recipe> RecipeList
	{
		get
		{
			List<Recipe> list = new List<Recipe>();
			foreach (Element item in RecipesListElement)
			{
				list.Add(new Recipe(item));
			}
			return list;
		}
	}
}
