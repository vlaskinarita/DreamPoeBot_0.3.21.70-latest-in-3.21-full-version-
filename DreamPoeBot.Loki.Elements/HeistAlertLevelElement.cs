namespace DreamPoeBot.Loki.Elements;

public class HeistAlertLevelElement : Element
{
	internal Element AlertLevelElement => base.Children[0];

	internal Element ImminentLockdownElement => base.Children[1];

	internal Element EscapeTheFacilityElement => base.Children[2];

	public bool IsAllertVisible => AlertLevelElement.IsVisible;

	public bool IsImminentLockdownVisible => ImminentLockdownElement.IsVisible;

	public bool IsEscapeTheFacilityVisible => EscapeTheFacilityElement.IsVisible;

	public int AlertLevelPct
	{
		get
		{
			if (!(AlertLevelElement == null) && AlertLevelElement.IsVisible)
			{
				float num = base.M.ReadFloat(AlertLevelElement.Children[1].Address + 384L);
				if (num <= 0f)
				{
					return 0;
				}
				return (int)(num / 740f * 100f);
			}
			return 100;
		}
	}

	public int LastObjectOveredAlertLevelPct
	{
		get
		{
			if (!(AlertLevelElement == null) && AlertLevelElement.IsVisible)
			{
				float num = base.M.ReadFloat(AlertLevelElement.Children[0].Address + 384L);
				if (num <= 0f)
				{
					return 0;
				}
				return (int)(num / 740f * 100f);
			}
			return 100;
		}
	}
}
