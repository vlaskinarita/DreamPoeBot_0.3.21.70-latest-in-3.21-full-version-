using System;
using System.Globalization;
using SharpDX;

namespace DreamPoeBot.Framework.Helpers;

public static class ConvertHelper
{
	public static string ToShorten(double value, string format = "0")
	{
		double num = Math.Abs(value);
		if (num >= 1000000.0)
		{
			return (value / 1000000.0).ToString("F2") + "M";
		}
		if (num < 1000.0)
		{
			return value.ToString(format);
		}
		return (value / 1000.0).ToString("F1") + "K";
	}

	public static Color ToBGRAColor(this string value)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (!uint.TryParse(value, NumberStyles.HexNumber, null, out var result))
		{
			return Color.Black;
		}
		return Color.FromBgra(result);
	}

	public static Color? ConfigColorValueExtractor(this string[] line, int index)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (!IsNotNull(line, index))
		{
			return null;
		}
		return line[index].ToBGRAColor();
	}

	public static string ConfigValueExtractor(this string[] line, int index)
	{
		if (!IsNotNull(line, index))
		{
			return null;
		}
		return line[index];
	}

	private static bool IsNotNull(string[] line, int index)
	{
		if (line.Length > index)
		{
			return !string.IsNullOrEmpty(line[index]);
		}
		return false;
	}
}
