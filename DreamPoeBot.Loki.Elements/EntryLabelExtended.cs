namespace DreamPoeBot.Loki.Elements;

internal class EntryLabelExtended : Element
{
	public int Length
	{
		get
		{
			int num = base.M.ReadInt(base.Address + 824L);
			if (num > 0 && num <= 512)
			{
				return num;
			}
			return 0;
		}
	}

	public new string Text
	{
		get
		{
			int length = Length;
			if (length > 0 && length <= 512)
			{
				if (length >= 8)
				{
					return base.M.ReadStringU(base.M.ReadLong(base.Address + 800L), length * 2);
				}
				return base.M.ReadStringU(base.Address + 800L, length * 2);
			}
			return "";
		}
	}
}
