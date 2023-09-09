using System;
using System.Globalization;

namespace DreamPoeBot.Common;

public struct Vector2i : IEquatable<Vector2i>
{
	public int X;

	public int Y;

	public static Vector2i Zero { get; set; }

	public static Vector2i One { get; set; }

	public Vector2i GetPointAtDistanceAfterThis(Vector2i end, float distance)
	{
		return ToVector2().GetPointAtDistanceAfterThis(end.ToVector2(), distance).ToVector2i();
	}

	public Vector2i GetPointAtDistanceBeforeThis(Vector2i end, float distance)
	{
		return ToVector2().GetPointAtDistanceBeforeThis(end.ToVector2(), distance).ToVector2i();
	}

	public Vector2i GetPointAtDistanceBeforeEnd(Vector2i end, float distance)
	{
		return ToVector2().GetPointAtDistanceBeforeEnd(end.ToVector2(), distance).ToVector2i();
	}

	public Vector2i GetPointAtDistanceAfterEnd(Vector2i end, float distance)
	{
		return ToVector2().GetPointAtDistanceAfterEnd(end.ToVector2(), distance).ToVector2i();
	}

	static Vector2i()
	{
		Zero = new Vector2i(0, 0);
		One = new Vector2i(1, 1);
	}

	public Vector2i(int x, int y)
	{
		X = x;
		Y = y;
	}

	public Vector2i(Vector2i vector)
	{
		X = vector.X;
		Y = vector.Y;
	}

	public int Length()
	{
		return (int)Math.Sqrt(LengthSqr());
	}

	public int LengthSqr()
	{
		return X * X + Y * Y;
	}

	public void Normalize()
	{
		int divisor = Length();
		Divide(ref this, divisor, out this);
	}

	public int Distance(Vector2i v)
	{
		return Distance(ref this, ref v);
	}

	public float DistanceF(Vector2i v)
	{
		return DistanceF(ref this, ref v);
	}

	public int Distance(ref Vector2i v)
	{
		return Distance(ref this, ref v);
	}

	public int DistanceSqr(Vector2i v)
	{
		return DistanceSqr(ref this, ref v);
	}

	public int DistanceSqr(ref Vector2i v)
	{
		return DistanceSqr(ref this, ref v);
	}

	public Vector3 ToVector3()
	{
		return new Vector3(X, Y, 0f);
	}

	public Vector2 ToVector2()
	{
		return new Vector2(X, Y);
	}

	public bool Equals(Vector2i other)
	{
		return Equals(ref this, ref other);
	}

	public bool Equals(ref Vector2i other)
	{
		return Equals(ref this, ref other);
	}

	public static bool Equals(ref Vector2i v1, ref Vector2i v2)
	{
		if (v1.X == v2.X)
		{
			return v1.Y == v2.Y;
		}
		return false;
	}

	public static bool operator ==(Vector2i ls, Vector2i rs)
	{
		return Equals(ref ls, ref rs);
	}

	public static bool operator !=(Vector2i ls, Vector2i rs)
	{
		return !Equals(ref ls, ref rs);
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		try
		{
			return Equals((Vector2i)obj);
		}
		catch (InvalidCastException)
		{
			return false;
		}
	}

	public override int GetHashCode()
	{
		return (X.GetHashCode() * 397) ^ Y.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{{{0}, {1}}}", X, Y);
	}

	public static Vector2i operator +(Vector2i ls, Vector2i rs)
	{
		Add(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector2i operator -(Vector2i ls, Vector2i rs)
	{
		Subtract(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector2i operator -(Vector2i v)
	{
		v.X = -v.X;
		v.Y = -v.Y;
		return v;
	}

	public static Vector2i operator *(Vector2i ls, Vector2i rs)
	{
		Multiply(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector2i operator *(Vector2i ls, int rs)
	{
		Multiply(ref ls, rs, out var result);
		return result;
	}

	public static Vector2i operator *(Vector2i ls, float rs)
	{
		return new Vector2i((int)((float)ls.X * rs), (int)((float)ls.Y * rs));
	}

	public static Vector2i operator /(Vector2i ls, Vector2i rs)
	{
		Multiply(ref ls, ref rs, out var result);
		return result;
	}

	public static Vector2i operator /(Vector2i ls, int rs)
	{
		Divide(ref ls, rs, out var result);
		return result;
	}

	public static void Add(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		result.X = v1.X + v2.X;
		result.Y = v1.Y + v2.Y;
	}

	public static void Subtract(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		result.X = v1.X - v2.X;
		result.Y = v1.Y - v2.Y;
	}

	public static void Multiply(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		result.X = v1.X * v2.X;
		result.Y = v1.Y * v2.Y;
	}

	public static void Multiply(ref Vector2i v1, int scalar, out Vector2i result)
	{
		result.X = v1.X * scalar;
		result.Y = v1.Y * scalar;
	}

	public static void Divide(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		if (v2.X == 2)
		{
			result.X = v1.X >> 1;
		}
		else if (v2.X != 4)
		{
			result.X = v1.X / v2.X;
		}
		else
		{
			result.X = v1.X >> 2;
		}
		if (v2.Y == 2)
		{
			result.Y = v1.Y >> 1;
		}
		else if (v2.Y != 4)
		{
			result.Y = v1.Y / v2.Y;
		}
		else
		{
			result.Y = v1.Y >> 2;
		}
	}

	public static void Divide(ref Vector2i v1, int divisor, out Vector2i result)
	{
		int scalar = 1 / divisor;
		Multiply(ref v1, scalar, out result);
	}

	public static int Distance(ref Vector2i v1, ref Vector2i v2)
	{
		return (int)Math.Sqrt(DistanceSqr(ref v1, ref v2));
	}

	public static float DistanceF(ref Vector2i v1, ref Vector2i v2)
	{
		return (float)Math.Sqrt(DistanceSqr(ref v1, ref v2));
	}

	public static int DistanceSqr(ref Vector2i v1, ref Vector2i v2)
	{
		int num = v1.Y - v2.Y;
		int num2 = v1.X - v2.X;
		return num2 * num2 + num * num;
	}

	public static void GetDirection(ref Vector2i from, ref Vector2i to, out Vector2i dir)
	{
		Subtract(ref to, ref from, out dir);
		dir.Normalize();
	}

	public static Vector2i Min(Vector2i v1, Vector2i v2)
	{
		Min(ref v1, ref v2, out var result);
		return result;
	}

	public static void Min(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		result.X = Math.Min(v1.X, v2.X);
		result.Y = Math.Min(v1.Y, v2.Y);
	}

	public static Vector2i Max(Vector2i v1, Vector2i v2)
	{
		Max(ref v1, ref v2, out var result);
		return result;
	}

	public static void Max(ref Vector2i v1, ref Vector2i v2, out Vector2i result)
	{
		result.X = Math.Max(v1.X, v2.X);
		result.Y = Math.Max(v1.Y, v2.Y);
	}

	public static int Dot(Vector2i v1, Vector2i v2)
	{
		return v1.X * v2.X + v1.Y * v2.Y;
	}
}
