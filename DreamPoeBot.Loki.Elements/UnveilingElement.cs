using System.Collections.Generic;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Loki.RemoteMemoryObjects;

namespace DreamPoeBot.Loki.Elements;

public class UnveilingElement : Element
{
	internal class ModifierOption : Element
	{
		public int RecipeCompletitionPct
		{
			get
			{
				float num = base.M.ReadFloat(base.Address + 868L);
				return (int)(num * 100f);
			}
		}

		public bool IsSelected => base.M.ReadByte(base.Address + 820L) == 1;

		public DatModsWrapper Mod
		{
			get
			{
				DatModsWrapper.Struct316 native = base.M.FastIntPtrToStruct<DatModsWrapper.Struct316>(base.M.ReadLong(base.Address + 784L));
				return new DatModsWrapper(native, -1);
			}
		}

		public List<int> ModValues
		{
			get
			{
				List<int> list = new List<int>();
				NativeVector nativeVector = base.M.FastIntPtrToStruct<NativeVector>(base.Address + 752L);
				for (long num = nativeVector.First; num < nativeVector.Last; num += 4L)
				{
					list.Add(base.M.ReadInt(num));
				}
				return list;
			}
		}
	}

	public Element ConfirmButtonElement => base.Children[3].Children[1];

	public Element UnveilButtonElement => base.Children[3].Children[0];

	internal List<ModifierOption> OptionsElements
	{
		get
		{
			List<ModifierOption> list = new List<ModifierOption>();
			List<Element> children = base.Children[4].Children[0].Children;
			foreach (Element item in children)
			{
				list.Add(GetObject<ModifierOption>(item.Address));
			}
			return list;
		}
	}

	public Inventory MainInventory
	{
		get
		{
			if (GameController.Instance?.Game?.IngameState?.IngameUi?.UnveilingUi == null)
			{
				return null;
			}
			if (!GameController.Instance.Game.IngameState.IngameUi.UnveilingUi.IsVisible)
			{
				return null;
			}
			return GetObject<Inventory>(base.Children[3].Children[2].Address);
		}
	}
}
