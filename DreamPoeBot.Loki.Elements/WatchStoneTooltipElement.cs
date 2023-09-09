using System;

namespace DreamPoeBot.Loki.Elements;

public class WatchStoneTooltipElement : Element
{
	public class WatchStoneInfo : Element
	{
		public bool IsObatained
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[1].Text))
				{
					return base.Children[1].Text == "Obtained";
				}
				return false;
			}
		}

		public bool CanObatain
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[2].Text))
				{
					return base.Children[2].Text != "Conqueror cannot spawn";
				}
				return false;
			}
		}

		public bool ConquerorInCitadel
		{
			get
			{
				if (!string.IsNullOrEmpty(base.Children[2].Text))
				{
					return base.Children[2].Text != "Conqueror in Citadel";
				}
				return false;
			}
		}

		public int RequiredWatchstone
		{
			get
			{
				string text = base.Children[2].Text;
				if (!string.IsNullOrEmpty(text))
				{
					if (!(text == "Conqueror cannot spawn"))
					{
						if (text == "Conqueror in Citadel")
						{
							return 0;
						}
						string oldValue = "Number of socketed Watchstones: ";
						string oldValue2 = " required to spawn Conqueror";
						string text2 = text.Replace(oldValue, "");
						string value = text2.Replace(oldValue2, "");
						return Convert.ToInt32(value);
					}
					return 0;
				}
				return 0;
			}
		}
	}

	public WatchStoneInfo Red => base.M.GetObject<WatchStoneInfo>(base.Children[0].Address);

	public WatchStoneInfo Green => base.M.GetObject<WatchStoneInfo>(base.Children[1].Address);

	public WatchStoneInfo Blue => base.M.GetObject<WatchStoneInfo>(base.Children[2].Address);

	public WatchStoneInfo Yellow => base.M.GetObject<WatchStoneInfo>(base.Children[3].Address);
}
