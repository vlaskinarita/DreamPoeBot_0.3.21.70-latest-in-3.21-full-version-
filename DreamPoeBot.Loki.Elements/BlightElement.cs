using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using DreamPoeBot.Loki.Common;
using log4net;

namespace DreamPoeBot.Loki.Elements;

public class BlightElement : Element
{
	private static readonly ILog ilog_0 = Logger.GetLoggerInstanceForType();

	public bool IsOpen
	{
		get
		{
			if (base.Children[0].ChildCount > 2L)
			{
				return base.Children[0].Children[3].IsVisible;
			}
			return false;
		}
	}

	public bool IsPumpDurabilityVisible
	{
		get
		{
			if (!IsOpen)
			{
				return false;
			}
			return base.Children[0].Children[3].Children[1].IsVisible;
		}
	}

	public int DurabilityPct
	{
		get
		{
			if (!IsOpen)
			{
				return 0;
			}
			if (base.Children[0].Children[3].ChildCount < 2L)
			{
				return 0;
			}
			if (base.Children[0].Children[3].Children[1].ChildCount >= 2L)
			{
				if (base.Children[0].Children[3].Children[1].Children[1].ChildCount < 1L)
				{
					return 0;
				}
				string text = base.Children[0].Children[3].Children[1].Children[1].Children[0].Text;
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split('/');
					int num = Convert.ToInt32(array[1]);
					int num2 = Convert.ToInt32(array[0]);
					if (num2 != 0)
					{
						return num2 / num * 100;
					}
					return 0;
				}
				return 0;
			}
			return 0;
		}
	}

	public int Resources
	{
		get
		{
			if (!IsOpen)
			{
				return 0;
			}
			if (!base.Children[0].Children[3].Children[1].Children[2].IsVisible)
			{
				return 0;
			}
			if (!base.Children[0].Children[3].Children[2].Children[0].IsVisible)
			{
				return 0;
			}
			if (base.Children[0].Children[3].Children[2].Children[0].ChildCount >= 2L)
			{
				string text = base.Children[0].Children[3].Children[2].Children[0].Children[1].Text;
				if (!string.IsNullOrEmpty(text))
				{
					string text2 = text.Replace(".", "").Replace(",", "");
					string input = text2.Replace(".", "").Replace(",", "").Replace(" ", "");
					string pattern = "[\\u0020\\u0009\\u000D\\u00A0]+";
					string replacement = "";
					Regex regex = new Regex(pattern);
					string text3 = regex.Replace(input, replacement).Trim();
					if (int.TryParse(text3, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
					{
						return result;
					}
					ilog_0.ErrorFormat("[BlightElement-Resources] Error parsing Resources lable: Original: " + text2 + ", Parsed: " + text3, Array.Empty<object>());
					return 0;
				}
				ilog_0.ErrorFormat("[BlightElement-Resources] Error Resources lable Text is null", Array.Empty<object>());
				return 0;
			}
			return 0;
		}
	}

	internal bool IsRewardVisible => RewardsElement.Any();

	internal List<Element> RewardsElement
	{
		get
		{
			List<Element> result = new List<Element>();
			if (!IsOpen)
			{
				return result;
			}
			if (base.Children[0].IsVisible)
			{
				if (base.Children[0].Children[3].IsVisible)
				{
					List<Element> children = base.Children[0].Children[3].Children;
					return children.Where((Element x) => x.Children[0].Children[0].IsVisible).ToList();
				}
				return result;
			}
			return result;
		}
	}
}
