using System.Collections.Generic;
using System.Runtime.InteropServices;
using DreamPoeBot.Loki.Game;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class BeastCraftingUiElement : Element
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	private struct StructBeast
	{
		private readonly long intPtr0;

		private readonly long intPtr1;

		private readonly long intPtr2;

		private readonly long intPtr3;

		public readonly long intPtr4Loading;

		private readonly long intPtr5;

		private readonly long intPtr6;

		public readonly long intPtr7CraftCutton;

		private readonly long intPtr8;

		public readonly long intPtr9CraftSloot;

		private readonly long intPtr9;

		private readonly long intPtr10;

		private readonly long intPtr11;

		private readonly long intPtr12;

		private readonly long intPtr13;

		private readonly long intPtr14;

		public readonly long intPtr15HideUnusable;

		public readonly long intPtr16ScrollBar;

		public readonly long intPtr17Menu;

		private readonly long intPtr18;

		private readonly long intPtr19;

		private readonly long intPtr20;
	}

	public Element ScrollBarButtonUp => base.M.GetObject<Element>(structBeast.intPtr16ScrollBar).Children[0];

	public Element ScrollBarButtonDown => base.M.GetObject<Element>(structBeast.intPtr16ScrollBar).Children[1];

	public Element LoadingScreen => base.M.GetObject<Element>(structBeast.intPtr4Loading);

	public Element HideUnusableElement => base.M.GetObject<Element>(structBeast.intPtr15HideUnusable);

	public bool IsHideUnusableSelected => base.M.ReadByte(HideUnusableElement.Address + 1162L) == 1;

	public Element MemuScreenElement => base.M.GetObject<Element>(structBeast.intPtr17Menu);

	public List<LokiPoe.InGameState.BeastCraftingingUi.MenuCategory> Menu
	{
		get
		{
			List<LokiPoe.InGameState.BeastCraftingingUi.MenuCategory> list = new List<LokiPoe.InGameState.BeastCraftingingUi.MenuCategory>();
			foreach (Element child in MemuScreenElement.Children)
			{
				list.Add(new LokiPoe.InGameState.BeastCraftingingUi.MenuCategory(child));
			}
			return list;
		}
	}

	public Element CraftButton => base.M.GetObject<Element>(structBeast.intPtr7CraftCutton);

	internal Element CraftSlot => base.M.GetObject<Element>(structBeast.intPtr9CraftSloot);

	public DreamPoeBot.Loki.RemoteMemoryObjects.Inventory Inventory => GetObject<DreamPoeBot.Loki.RemoteMemoryObjects.Inventory>(CraftSlot.Address);

	private StructBeast structBeast => base.M.FastIntPtrToStruct<StructBeast>(base.Address + 480L);

	private static bool IngredientAviable(Element elem)
	{
		return LokiPoe.Memory.ReadByte(elem.Address + 291L) == byte.MaxValue;
	}
}
