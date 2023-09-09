namespace DreamPoeBot.Loki.Components;

public class CurrencyInfo : Component
{
	public int MaxStackSize
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address + 40L);
		}
	}
}
