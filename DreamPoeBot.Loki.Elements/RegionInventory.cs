using DreamPoeBot.Loki.Game;

namespace DreamPoeBot.Loki.Elements;

internal class RegionInventory : Element
{
	internal LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum Region
	{
		get
		{
			if (!string.IsNullOrEmpty(base.Children[3]?.Children[0]?.Children[0]?.Text))
			{
				return GetRegionEnum(base.Children[3].Children[0].Children[0].Text);
			}
			return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown;
		}
	}

	internal bool IsOccupied => base.Children[0].IsVisibleLocal;

	internal LokiPoe.InstanceInfo.Atlas.Conqueror Conqueror => GetConqueror();

	internal int RequiredWatchstone => GetRequiredWatchstone();

	internal int RequiredMaps => GetRequiredMaps();

	internal Element Red => base.Children[4];

	internal Element Green => base.Children[5];

	internal Element Blue => base.Children[6];

	internal Element Yellow => base.Children[7];

	private LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum GetRegionEnum(string region)
	{
		if (region != null)
		{
			uint num = default(uint);
			char c = default(char);
			while (true)
			{
				switch (region.Length)
				{
				default:
				{
					int num2 = ((int)num * -6645221) ^ 0x572268E1;
					while (true)
					{
						switch ((num = (uint)num2 ^ 0xF1F10666u) % 36u)
						{
						case 27u:
							num2 = (int)((num * 785438555) ^ 0x724ECD7C);
							continue;
						case 4u:
						case 12u:
							break;
						case 25u:
							goto IL_00f9;
						case 22u:
							goto IL_0101;
						case 32u:
							goto IL_0106;
						case 2u:
							goto IL_010b;
						case 33u:
							goto IL_011b;
						case 17u:
							goto IL_011d;
						case 6u:
							goto IL_0122;
						case 23u:
							goto IL_012f;
						case 26u:
							goto IL_0131;
						case 30u:
							goto IL_013e;
						case 29u:
							goto IL_0140;
						case 21u:
							goto IL_014d;
						case 1u:
							goto IL_014f;
						case 14u:
							goto IL_015c;
						case 13u:
							goto IL_0169;
						case 5u:
							goto IL_016b;
						case 7u:
							goto IL_0172;
						case 24u:
							goto IL_017f;
						case 19u:
							goto IL_0181;
						case 31u:
							goto IL_018e;
						case 18u:
							goto IL_0190;
						case 10u:
							goto IL_019d;
						default:
							goto end_IL_00d7;
						}
						break;
					}
					continue;
				}
				case 10:
					goto IL_00f9;
				case 11:
					goto IL_0140;
				case 12:
					goto IL_014f;
				case 14:
					goto IL_0181;
				case 15:
					goto IL_0190;
				case 13:
					break;
					IL_013e:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Ejoris;
					IL_0190:
					if (!(region == "Glennach Cairns"))
					{
						break;
					}
					goto IL_019d;
					IL_019d:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Glennach_Cairns;
					IL_0181:
					if (!(region == "Haewark Hamlet"))
					{
						break;
					}
					goto IL_018e;
					IL_018e:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Haewark_Hamlet;
					IL_014f:
					c = region[0];
					if (c == 'L')
					{
						goto IL_015c;
					}
					goto IL_016b;
					IL_015c:
					if (!(region == "Lira Arthain"))
					{
						break;
					}
					goto IL_0169;
					IL_0169:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lira_Arthain;
					IL_016b:
					if (c != 'V')
					{
						break;
					}
					goto IL_0172;
					IL_0172:
					if (!(region == "Valdo's Rest"))
					{
						break;
					}
					goto IL_017f;
					IL_017f:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Valdos_Rest;
					IL_0140:
					if (!(region == "Lex Proxima"))
					{
						break;
					}
					goto IL_014d;
					IL_014d:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Lex_Proxima;
					IL_00f9:
					c = region[0];
					goto IL_0101;
					IL_0101:
					if (c != 'L')
					{
						goto IL_0106;
					}
					goto IL_0131;
					IL_0106:
					if (c == 'N')
					{
						goto IL_010b;
					}
					goto IL_011d;
					IL_010b:
					if (!(region == "New Vastir"))
					{
						break;
					}
					goto IL_011b;
					IL_011b:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.New_Vastir;
					IL_011d:
					if (c != 'T')
					{
						break;
					}
					goto IL_0122;
					IL_0122:
					if (!(region == "Tirn's End"))
					{
						break;
					}
					goto IL_012f;
					IL_012f:
					return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Tirns_End;
					IL_0131:
					if (!(region == "Lex Ejoris"))
					{
						break;
					}
					goto IL_013e;
					end_IL_00d7:
					break;
				}
				break;
			}
		}
		return LokiPoe.InGameState.AtlasUi.AtlasRegionsEnum.Unknown;
	}

	private LokiPoe.InstanceInfo.Atlas.Conqueror GetConqueror()
	{
		if (!IsOccupied)
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (text.Contains("Crusader"))
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Crusader;
		}
		if (text.Contains("Hunter"))
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Hunter;
		}
		if (text.Contains("Warlord"))
		{
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Warlord;
		}
		if (!text.Contains("Redeemer"))
		{
			if (!text.Contains("Awakener"))
			{
				return LokiPoe.InstanceInfo.Atlas.Conqueror.None;
			}
			return LokiPoe.InstanceInfo.Atlas.Conqueror.Awakener;
		}
		return LokiPoe.InstanceInfo.Atlas.Conqueror.Redeemer;
	}

	private int GetRequiredWatchstone()
	{
		if (!IsOccupied)
		{
			return 0;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (text.Contains("Region with 0 Watchstones socketed"))
		{
			return 0;
		}
		if (!text.Contains("Region with 1 Watchstones socketed"))
		{
			if (text.Contains("Region with 2 Watchstones socketed"))
			{
				return 2;
			}
			if (text.Contains("Region with 3 Watchstones socketed"))
			{
				return 3;
			}
			if (text.Contains("Region with 4 Watchstones socketed"))
			{
				return 4;
			}
			return 0;
		}
		return 1;
	}

	private int GetRequiredMaps()
	{
		if (!IsOccupied)
		{
			return -1;
		}
		string text = base.Children[0].Children[1].Children[0].Tooltip.Text;
		if (text.Contains("Completing 1 more Maps"))
		{
			return 1;
		}
		if (text.Contains("Completing 2 more Maps"))
		{
			return 2;
		}
		if (!text.Contains("Completing 3 more Maps"))
		{
			if (!text.Contains("Completing 4 more Maps"))
			{
				if (text.Contains("Completing 5 more Maps"))
				{
					return 5;
				}
				if (text.Contains("Completing 6 more Maps"))
				{
					return 6;
				}
				if (text.Contains("Completing 7 more Maps"))
				{
					return 7;
				}
				if (!text.Contains("Completing 8 more Maps"))
				{
					if (text.Contains("Completing 9 more Maps"))
					{
						return 9;
					}
					if (text.Contains("Completing 10 more Maps"))
					{
						return 10;
					}
					if (text.Contains("Completing 11 more Maps"))
					{
						return 11;
					}
					if (!text.Contains("Completing 12 more Maps"))
					{
						return 0;
					}
					return 12;
				}
				return 8;
			}
			return 4;
		}
		return 3;
	}
}
