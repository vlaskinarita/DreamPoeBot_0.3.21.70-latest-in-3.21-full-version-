namespace DreamPoeBot.Loki.Elements;

public class EntityLabel : Element
{
	private int offset = 744;

	public ulong Length
	{
		get
		{
			ulong num = base.M.ReadULong(base.Address + offset + 24L);
			if (num > 0L && num <= 4192L)
			{
				return num;
			}
			return 0uL;
		}
	}

	public new string Text
	{
		get
		{
			ulong length = Length;
			if (length <= 0L)
			{
				return "";
			}
			ulong num = base.M.ReadULong(base.Address + offset);
			ulong num2 = base.M.ReadULong(base.Address + offset + 8L);
			if (num > 0L && num != num2)
			{
				if (length >= 8L)
				{
					return base.M.ReadStringU((long)num, (int)(length * 2L));
				}
				return base.M.ReadStringU(base.Address + offset, (int)(length * 2L));
			}
			return "";
		}
	}
}
