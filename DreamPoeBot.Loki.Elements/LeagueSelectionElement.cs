namespace DreamPoeBot.Loki.Elements;

public class LeagueSelectionElement : Element
{
	public Element StandardLeague => base.Children[1].Children[0].Children[2];

	public Element CurrentLeague => base.Children[1].Children[1].Children[2];

	public Element CurrentLeagueHardCore => base.Children[1].Children[2].Children[2];

	public Element Ok => base.Children[2].Children[1].Children[0];

	public Element Cancel => base.Children[2].Children[0].Children[0];
}
