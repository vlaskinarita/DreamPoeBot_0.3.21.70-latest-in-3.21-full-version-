namespace DreamPoeBot.Loki.Elements;

public class PartElement : Element
{
	public bool IsSelected
	{
		get
		{
			if (base.ChildCount == 0L)
			{
				return false;
			}
			return base.M.ReadInt(base.Children[0].Address + 5856L) != 0;
		}
	}
}
