using System;
using System.Globalization;

namespace DreamPoeBot.Loki.Common.Math;

[Serializable]
public struct Point : IEquatable<Point>
{
	public int X;

	public int Y;

	private static readonly Point _zero;

	public static Point Zero => _zero;

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}

	public bool Equals(Point other)
	{
		if (X == other.X)
		{
			return Y == other.Y;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		bool result = false;
		if (obj is Point)
		{
			result = Equals((Point)obj);
		}
		return result;
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() + Y.GetHashCode();
	}

	public override string ToString()
	{
		CultureInfo currentCulture = CultureInfo.CurrentCulture;
		return string.Format(currentCulture, "{{X:{0} Y:{1}}}", new object[2]
		{
			X.ToString(currentCulture),
			Y.ToString(currentCulture)
		});
	}

	public static bool operator ==(Point a, Point b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Point a, Point b)
	{
		if (a.X == b.X)
		{
			return a.Y != b.Y;
		}
		return true;
	}
}
