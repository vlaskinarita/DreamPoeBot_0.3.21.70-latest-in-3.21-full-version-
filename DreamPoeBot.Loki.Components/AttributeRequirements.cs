namespace DreamPoeBot.Loki.Components;

public class AttributeRequirements : Component
{
	public int Str
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address + 16L, 16L);
		}
	}

	public int Dex
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address + 16L, 20L);
		}
	}

	public int Int
	{
		get
		{
			if (base.Address == 0L)
			{
				return 0;
			}
			return base.M.ReadInt(base.Address + 16L, 24L);
		}
	}
}
