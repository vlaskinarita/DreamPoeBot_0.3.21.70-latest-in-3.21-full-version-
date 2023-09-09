using DreamPoeBot.Common;
using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

public class CitadelElement : Element
{
	public string Name
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Tooltip.Children[1].Text))
			{
				return base.Tooltip.Children[1].Text;
			}
			return "";
		}
	}

	public Vector2i PassiveButtonLocation => LokiPoe.ElementClickLocation(base.Children[0].Children[4]);

	public WatchStoneElement WatchStonesElement => base.M.GetObject<WatchStoneElement>(base.Children[0].Address);

	public WatchStoneTooltipElement WatchStonesTooltipElement => base.M.GetObject<WatchStoneTooltipElement>(base.Tooltip.Children[3].Address);

	public Element MavenElement => base.M.GetObject<Element>(base.Children[2].Address);

	public PassiveElement PassiveElement => base.M.GetObject<PassiveElement>(base.Children[4].Address);
}
