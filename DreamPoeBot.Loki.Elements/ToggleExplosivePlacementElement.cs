using System;

namespace DreamPoeBot.Loki.Elements;

public class ToggleExplosivePlacementElement : Element
{
	public Element MainExplosiveElement => base.Children[0];

	public Element ModElement => base.Children[2];

	public Element ToggleButton => MainExplosiveElement.Children[3];

	public Element UndoButton => MainExplosiveElement.Children[0].Children[1];

	public int RemainingExplosive
	{
		get
		{
			if (!base.IsVisible)
			{
				return 0;
			}
			string text = MainExplosiveElement.Children[0].Children[0].Text;
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}
			return Convert.ToInt32(text);
		}
	}
}
