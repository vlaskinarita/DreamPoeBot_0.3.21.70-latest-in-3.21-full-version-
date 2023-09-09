namespace DreamPoeBot.Loki.Elements;

public class ShowRitualRewardElement : Element
{
	public string text => base.Children[0]?.Children[0]?.Text;

	public int RitualRemaining
	{
		get
		{
			if (string.IsNullOrEmpty(text))
			{
				return 3;
			}
			string[] array = text.Split('/');
			if (array.Length >= 2)
			{
				int result = 0;
				if (int.TryParse(array[0], out result))
				{
					int result2 = 0;
					if (int.TryParse(array[1], out result2))
					{
						return result2 - result;
					}
					return 3;
				}
				return 3;
			}
			return 3;
		}
	}
}
