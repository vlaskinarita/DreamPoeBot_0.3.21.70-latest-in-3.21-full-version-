using System.Collections.Generic;
using System.Linq;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Elements;

namespace DreamPoeBot.Loki.Game.Objects;

public class AflictionInitiator : NetworkObject
{
	public Element Ui
	{
		get
		{
			ItemsOnGroundLabelElement itemsOnGroundLabelElement = GameController.Instance.Game.IngameState.IngameUi.ItemsOnGroundLabels.FirstOrDefault((ItemsOnGroundLabelElement x) => x.ItemOnGround.Address == base.Entity.Address);
			if (itemsOnGroundLabelElement == null)
			{
				return null;
			}
			Element label = itemsOnGroundLabelElement.Label;
			if (label == null)
			{
				return null;
			}
			return label.GetObjectAt<Element>(0);
		}
	}

	private List<string> AllStrings
	{
		get
		{
			List<string> list = new List<string>();
			if (Ui == null)
			{
				return list;
			}
			foreach (Element child in Ui.Children[0].Children)
			{
				if (!string.IsNullOrEmpty(child.Text))
				{
					list.Add(child.Text);
				}
			}
			return list;
		}
	}

	public int CurrentWave
	{
		get
		{
			string text = AllStrings.FirstOrDefault((string x) => x.Contains("Wave"));
			if (string.IsNullOrEmpty(text))
			{
				return -1;
			}
			string text2 = text.Replace("Wave ", "");
			string s = text2.Split('/')[0];
			if (int.TryParse(s, out var result))
			{
				return result;
			}
			return -1;
		}
	}

	public int MaxWave
	{
		get
		{
			string text = AllStrings.FirstOrDefault((string x) => x.Contains("Wave"));
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = text.Replace("Wave ", "");
				string s = text2.Split('/')[1];
				if (int.TryParse(s, out var result))
				{
					return result;
				}
				return -1;
			}
			return -1;
		}
	}

	internal AflictionInitiator(NetworkObject entry)
		: base(entry._entity)
	{
	}

	public void HideUi()
	{
		if (!(Ui == null))
		{
			Ui.SetZoom(-10f);
		}
	}

	public void ShowUi()
	{
		if (!(Ui == null))
		{
			Ui.SetZoom(1f);
		}
	}
}
