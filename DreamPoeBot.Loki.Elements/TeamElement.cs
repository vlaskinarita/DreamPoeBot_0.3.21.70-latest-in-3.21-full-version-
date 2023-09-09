using System;

namespace DreamPoeBot.Loki.Elements;

public class TeamElement : Element
{
	public bool IsSelected => !base.Children[0].Children[0].IsVisible;

	public string SelectedAgentName
	{
		get
		{
			if (!IsSelected)
			{
				return "";
			}
			return base.Children[0].Children[2].Children[0].Text;
		}
	}

	public int SelectedAgentLevel
	{
		get
		{
			if (!IsSelected)
			{
				return -1;
			}
			string text = base.Children[0].Children[1].Children[2].Text;
			if (string.IsNullOrEmpty(text))
			{
				return -1;
			}
			string text2 = "Level ";
			return Convert.ToInt32(text.Trim(text2.ToCharArray()));
		}
	}
}
