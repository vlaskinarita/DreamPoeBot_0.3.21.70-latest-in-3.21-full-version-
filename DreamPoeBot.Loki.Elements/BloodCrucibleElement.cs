using System.Collections.Generic;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class BloodCrucibleElement : Element
{
	public class CrucibleItemSlotElement : Element
	{
		public Element TransformButtonElement => base.Children[4];

		public Element Gauge => base.Children[3];

		public Element Inventory => base.Children[2];
	}

	private const long tabContainerOffset = 568L;

	public int IndexVisibleStash => base.M.ReadInt(base.Address + 568L, 2536L);

	internal Element CrucibleButtonElement => base.Children[2].Children[0].Children[2].Children[0].Children[0];

	internal Element SkillsButtonElement => base.Children[2].Children[0].Children[2].Children[0].Children[1];

	internal Element CrucibleElement => base.Children[2].Children[0].Children[0];

	internal Element SkillsElement => base.Children[2].Children[0].Children[1];

	internal List<CrucibleItemSlotElement> AllItemSlots
	{
		get
		{
			List<CrucibleItemSlotElement> list = new List<CrucibleItemSlotElement>();
			Element element = CrucibleElement.Children[0].Children[0];
			foreach (Element child in element.Children)
			{
				if (child.IsVisible)
				{
					list.Add(GetObject<CrucibleItemSlotElement>(child.Address));
				}
			}
			return list;
		}
	}

	internal List<CrucibleItemSlotElement> AllMapSlots
	{
		get
		{
			List<CrucibleItemSlotElement> list = new List<CrucibleItemSlotElement>();
			Element element = CrucibleElement.Children[0].Children[1];
			foreach (Element child in element.Children)
			{
				if (child.IsVisible)
				{
					list.Add(GetObject<CrucibleItemSlotElement>(child.Address));
				}
			}
			return list;
		}
	}

	internal List<LokiPoe.InGameState.BloodCrucibleUi.Skills.HellscapeSkillSlot> AllSkills
	{
		get
		{
			List<LokiPoe.InGameState.BloodCrucibleUi.Skills.HellscapeSkillSlot> list = new List<LokiPoe.InGameState.BloodCrucibleUi.Skills.HellscapeSkillSlot>();
			for (int i = 3; i <= 7; i++)
			{
				foreach (Element child in SkillsElement.Children[i].Children)
				{
					list.Add(new LokiPoe.InGameState.BloodCrucibleUi.Skills.HellscapeSkillSlot(child, i - 2));
				}
			}
			return list;
		}
	}

	internal Element ApplayPointsButton => SkillsElement.Children[8];

	internal Element CancelButton => SkillsElement.Children[9];
}
