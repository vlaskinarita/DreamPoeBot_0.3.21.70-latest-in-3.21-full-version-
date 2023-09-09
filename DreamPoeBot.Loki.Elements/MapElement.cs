namespace DreamPoeBot.Loki.Elements;

public class MapElement : Element
{
	public Element LargeMap => base.Children[0];

	public float LargeMapShiftX => base.M.ReadFloat(LargeMap.Address + 744L);

	public float LargeMapShiftY => base.M.ReadFloat(LargeMap.Address + 748L);

	public float LargeMapDefaultShiftX => base.M.ReadFloat(LargeMap.Address + 752L);

	public float LargeMapDefaultShiftY => base.M.ReadFloat(LargeMap.Address + 756L);

	public float LargeMapZoom => base.M.ReadFloat(LargeMap.Address + 812L);

	public Element SmallMinimap => base.Children[1];

	public float SmallMinimapX => base.M.ReadFloat(SmallMinimap.Address + 744L);

	public float SmallMinimapY => base.M.ReadFloat(SmallMinimap.Address + 748L);

	public float SmallMinimapDefaultX => base.M.ReadFloat(SmallMinimap.Address + 752L);

	public float SmallMinimapDefaultY => base.M.ReadFloat(SmallMinimap.Address + 756L);

	public float SmallMinimapZoom => base.M.ReadFloat(SmallMinimap.Address + 812L);

	public Element ZoneDescriptionElement => base.Children[2];

	public string ZoneDescription
	{
		get
		{
			string text = "";
			if (ZoneDescriptionElement.ChildCount < 1L)
			{
				return text;
			}
			foreach (Element child in ZoneDescriptionElement.Children[0].Children)
			{
				if (!(child == null) && !string.IsNullOrEmpty(child.Text))
				{
					text = text + child.Text + "\n";
				}
			}
			return text;
		}
	}
}
